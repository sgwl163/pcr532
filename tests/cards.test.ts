import assert from "node:assert/strict";
import test from "node:test";
import { makeReadRequest, makeWriteRequest, writableAddress, readCapability, spacedHex, type CardInfo, type ReadSelection } from "../src/lib/cards.ts";

const card: CardInfo = { uid: "12345678", uidLength: 4, atqa: "0004", sak: "08", family: "classic1k", typeName: "MIFARE Classic 1K（初步识别）" };
const selection: ReadSelection = { start: "4", count: "2", keyType: "B", key: "112233445566" };

test("capabilities distinguish Classic block capacities and conservative Type 2 pages", () => {
  assert.deepEqual(readCapability(card), { mode: "classic", units: 64, unit: "块", bytes: 16 });
  assert.equal(readCapability({ ...card, family: "classic4k" })?.units, 256);
  assert.equal(readCapability({ ...card, family: "classicMini" })?.units, 20);
  assert.deepEqual(readCapability({ ...card, family: "type2" }), { mode: "type2", units: 16, unit: "页", bytes: 4 });
  assert.equal(readCapability({ ...card, family: "iso14443_4" }), null);
  assert.equal(readCapability({ ...card, family: "unknown" }), null);
});

test("known key and selected range produce one explicit read request", () => {
  assert.deepEqual(makeReadRequest(card, selection), {
    uid: card.uid, mode: "classic", start: 4, count: 2, keyType: "B", key: "112233445566",
  });
});

test("invalid or missing Classic key is never replaced with a default", () => {
  for (const key of ["", "FF", "00112233445566", "00112233445Z", " 112233445566", "１１2233445566"]) {
    assert.throws(() => makeReadRequest(card, { ...selection, key }), /12 位十六进制/);
  }
  assert.throws(() => makeReadRequest(card, { ...selection, keyType: "C" }), /Key A/);
});

test("invalid decimals, counts and capacity overruns are blocked", () => {
  for (const start of ["", "-1", "1.5", "0x04", "1e1", "NaN", "999999999999999999"]) {
    assert.throws(() => makeReadRequest(card, { ...selection, start }));
  }
  for (const count of ["", "0", "17", "1.1", "-1"]) {
    assert.throws(() => makeReadRequest(card, { ...selection, count }));
  }
  assert.throws(() => makeReadRequest(card, { ...selection, start: "63", count: "2" }), /0–63/);
  assert.equal(makeReadRequest(card, { ...selection, start: "63", count: "1" }).start, 63);
  assert.throws(() => makeReadRequest({ ...card, family: "classicMini" }, { ...selection, start: "20" }));
});

test("Type 2 omits credentials and stays inside the first 16 pages", () => {
  const type2 = { ...card, family: "type2" };
  const request = makeReadRequest(type2, { ...selection, start: "14", count: "2" });
  assert.equal(request.mode, "type2");
  assert.equal(request.key, null);
  assert.equal(request.keyType, null);
  assert.throws(() => makeReadRequest(type2, { ...selection, start: "15" }), /0–15/);
  assert.throws(() => makeReadRequest({ ...card, family: "unknown" }, selection), /仅支持识别/);
});

test("write policy protects manufacturer blocks, all sector trailers and Type 2 reserved pages", () => {
  for (const address of [0, 3, 7, 63, 127, 143, 159, 255, 256, -1, 1.5]) {
    assert.equal(writableAddress({ ...card, family: "classic4k" }, address), false);
  }
  for (const address of [1, 4, 126, 128, 142, 144, 254]) {
    assert.equal(writableAddress({ ...card, family: "classic4k" }, address), true);
  }
  for (const address of [0, 1, 2, 3, 16]) assert.equal(writableAddress({ ...card, family: "type2" }, address), false);
  assert.equal(writableAddress({ ...card, family: "type2" }, 15), true);
});

test("writes require a complete original read, explicit confirmation and exact-length data", () => {
  const dump = { card, mode: "classic" as const, rows: [{ address: 4, hex: "11".repeat(16) }], complete: true, error: null };
  const write = { address: 4, hex: "AA ".repeat(16), keyType: "A", key: "112233445566", confirmed: true };
  const request = makeWriteRequest(card, dump, write);
  assert.equal(request.hex, "AA".repeat(16));
  assert.equal(request.expectedHex, "11".repeat(16));
  assert.throws(() => makeWriteRequest(card, dump, { ...write, confirmed: false }), /确认/);
  assert.throws(() => makeWriteRequest(card, dump, { ...write, address: 3 }), /受保护/);
  assert.throws(() => makeWriteRequest(card, dump, { ...write, hex: "AA" }), /32/);
  assert.throws(() => makeWriteRequest(card, { ...dump, complete: false }, write), /重新读取/);
  assert.throws(() => makeWriteRequest(card, { ...dump, rows: [] }, write), /原数据/);
  assert.throws(() => makeWriteRequest(card, dump, { ...write, key: "" }), /密钥/);
  assert.throws(() => makeWriteRequest(card, { ...dump, card: { ...card, uid: "99887766" } }, write), /重新读取/);
});

test("hex display groups bytes without changing their order", () => {
  assert.equal(spacedHex("04112233AABBCC"), "04 11 22 33 AA BB CC");
  assert.equal(spacedHex(""), "");
});
