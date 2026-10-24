import assert from "node:assert/strict";
import test from "node:test";
import { findByteMatches, resolveLoadedAddress } from "../src/lib/data-navigation.ts";
import type { CardDump } from "../src/lib/cards.ts";

const dump: CardDump = {
  card: { uid: "12345678", uidLength: 4, atqa: "0004", sak: "08", family: "classic1k", typeName: "Classic 1K" },
  mode: "classic", complete: false, error: null,
  rows: [
    { address: 5, hex: "4142414241" + "00".repeat(11) },
    { address: 3, hex: "414243444546FF0780694748494A4B4C" },
    { address: 8, hex: "E697A5E69C9F" + "00".repeat(10) },
  ],
};

test("byte search preserves addresses, matches overlaps and never mutates input", () => {
  const original = JSON.stringify(dump);
  assert.deepEqual(findByteMatches(dump, "41 42 41", "hex"), [
    { address: 5, offset: 0, length: 3 },
    { address: 5, offset: 2, length: 3 },
  ]);
  assert.deepEqual(findByteMatches(dump, "日期", "text"), [{ address: 8, offset: 0, length: 6 }]);
  assert.deepEqual(findByteMatches(dump, "aba", "text"), []);
  assert.equal(JSON.stringify(dump), original);
});

test("search excludes all trailer key positions and cannot infer matches across gaps or rows", () => {
  assert.deepEqual(findByteMatches(dump, "ABCDEF", "text"), []);
  assert.deepEqual(findByteMatches(dump, "GHIJKL", "text"), []);
  assert.deepEqual(findByteMatches(dump, "46FF", "hex"), []);
  assert.deepEqual(findByteMatches(dump, "FF078069", "hex"), [{ address: 3, offset: 6, length: 4 }]);
  const separated = { ...dump, rows: [{ address: 4, hex: "00".repeat(15) + "41" }, { address: 5, hex: "42" + "00".repeat(15) }] };
  assert.deepEqual(findByteMatches(separated, "4142", "hex"), []);
});

test("search validates whole bytes and addresses without making missing data available", () => {
  assert.deepEqual(findByteMatches(dump, "", "hex"), []);
  for (const query of ["4", "GG", "0x41", "41,42"])
    assert.throws(() => findByteMatches(dump, query, "hex"), /完整.*十六进制/);
  assert.equal(resolveLoadedAddress(dump, "5", false), 5);
  assert.equal(resolveLoadedAddress(dump, "0x08", false), 8);
  assert.equal(resolveLoadedAddress(dump, "08", true), 8);
  for (const address of ["", "-1", "1.5", "Infinity"])
    assert.throws(() => resolveLoadedAddress(dump, address, false), /地址/);
  assert.throws(() => resolveLoadedAddress(dump, "4", false), /未载入/);
  assert.throws(() => resolveLoadedAddress(dump, "40", true), /未载入/);
});

test("Type 2 search uses page addresses and actual four-byte boundaries", () => {
  const type2: CardDump = { ...dump, card: { ...dump.card, family: "type2" }, mode: "type2", rows: [{ address: 4, hex: "41424142" }] };
  assert.deepEqual(findByteMatches(type2, "AB", "text"), [
    { address: 4, offset: 0, length: 2 }, { address: 4, offset: 2, length: 2 },
  ]);
});
