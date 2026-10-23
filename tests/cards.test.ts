import assert from "node:assert/strict";
import test from "node:test";
import { makeReadRequest, readCapability, spacedHex, type CardInfo, type ReadSelection } from "../src/lib/cards.ts";

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

test("hex display groups bytes without changing their order", () => {
  assert.equal(spacedHex("04112233AABBCC"), "04 11 22 33 AA BB CC");
  assert.equal(spacedHex(""), "");
});
