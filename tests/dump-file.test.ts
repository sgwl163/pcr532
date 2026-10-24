import assert from "node:assert/strict";
import test from "node:test";
import { parseClassicDump } from "../src/lib/dump-file.ts";
import { analyzeFields } from "../src/lib/field-analysis.ts";
import { decodeNfcValue } from "../src/lib/nfc-values.ts";
import { classicSector, classicTrailer } from "../src/lib/classic-layout.ts";

function sample(date = "375F") {
  const bytes = new Uint8Array(1024);
  bytes.set([0x3d, 0x6a, 0xe7, 0xfa, 0x4a]);
  for (let sector = 0; sector < 16; sector++) bytes.set([0xff, 0x07, 0x80, 0x69], (sector * 4 + 3) * 16 + 6);
  bytes.set([Number.parseInt(date.slice(0, 2), 16), Number.parseInt(date.slice(2), 16)], 5 * 16 + 10);
  return bytes;
}

test("raw dump imports exact Classic layouts, preserves bytes and leaves RF metadata unknown", () => {
  for (const [size, family] of [[320, "classicMini"], [1024, "classic1k"], [4096, "classic4k"]] as const) {
    const bytes = new Uint8Array(size);
    const dump = parseClassicDump(bytes);
    assert.equal(dump.card.family, family);
    assert.equal(dump.rows.length, size / 16);
    assert.equal(dump.card.atqa, "");
    assert.equal(dump.card.sak, "");
    assert.equal(dump.rows.at(-1)?.address, size / 16 - 1);
    bytes.fill(0xff);
    assert.equal(dump.rows[0].hex, "00".repeat(16));
  }
  const dump = parseClassicDump(sample());
  assert.equal(dump.card.uid, "3D6AE7FA");
  assert.equal(dump.error, null);
  const malformedBcc = sample(); malformedBcc[4] = 0;
  assert.match(parseClassicDump(malformedBcc).error!, /BCC/);
});

test("dump import rejects truncated, text, oversized and header-bearing files without guessing", () => {
  for (const size of [0, 16, 319, 321, 1023, 1025, 4097, 1024 * 1024]) assert.throws(() => parseClassicDump(new Uint8Array(size)), /仅支持/);
});

test("packed 2000-based big endian date matches supplied screenshot but does not establish semantics", () => {
  assert.deepEqual(decodeNfcValue("375F", "packed-date-2000-be", 0), { raw: "375F", value: "2027-10-31（无时区的日期）", bytes: 2 });
  assert.equal(decodeNfcValue("AA3521BB", "packed-date-2000-be", 1).value, "2026-09-01（无时区的日期）");
  assert.equal(decodeNfcValue("305D", "packed-date-2000-be", 0).value, "2024-02-29（无时区的日期）");
  for (const hex of ["0000", "FFFF", "345D", "33DF", "37"]) assert.throws(() => decodeNfcValue(hex, "packed-date-2000-be", 0));
});

test("reference date is strictly opt-in, bounds checked, and excludes Key A and B from field output", () => {
  const bytes = sample();
  bytes.set([0x12, 0x34, 0x56, 0x78, 0x9a, 0xbc], 3 * 16);
  bytes.set([0xab, 0xcd, 0xef, 0x98, 0x76, 0x54], 3 * 16 + 10);
  const dump = parseClassicDump(bytes);
  const standard = analyzeFields(dump, "standard");
  assert.ok(!standard.some(field => field.id === "reference-date"));
  assert.ok(!JSON.stringify(standard).includes("123456789ABC"));
  assert.ok(!JSON.stringify(standard).includes("ABCDEF987654"));
  const reference = analyzeFields(dump, "reference-date").find(field => field.id === "reference-date")!;
  assert.equal(reference.evidence, "candidate");
  assert.equal(reference.raw, "375F");
  assert.equal(reference.offset, 10);
  assert.match(reference.interpretation, /2027-10-31.*待验证/);
  const expired = analyzeFields(parseClassicDump(sample("3521")), "reference-date").find(field => field.id === "reference-date")!;
  assert.match(expired.interpretation, /2026-09-01/);
  const invalid = analyzeFields(parseClassicDump(sample("FFFF")), "reference-date").find(field => field.id === "reference-date")!;
  assert.match(invalid.interpretation, /不是有效/);
  assert.ok(!analyzeFields({ ...dump, rows: dump.rows.filter(row => row.address !== 5) }, "reference-date").some(field => field.id === "reference-date"));
  for (const rows of [[dump.rows[0], dump.rows[0]], [{ address: 5, hex: "GG".repeat(16) }], [{ address: 64, hex: "00".repeat(16) }]]) assert.deepEqual(analyzeFields({ ...dump, rows }, "reference-date"), []);
});

test("sector geometry handles Mini, 1K and 4K large sectors without creating missing rows", () => {
  assert.equal(classicSector(127), 31);
  assert.equal(classicSector(128), 32);
  assert.equal(classicSector(143), 32);
  assert.equal(classicSector(144), 33);
  assert.equal(classicSector(255), 39);
  assert.equal(classicTrailer(128), false);
  assert.equal(classicTrailer(143), true);
  const dump = parseClassicDump(sample());
  const partial = { ...dump, complete: false, rows: [dump.rows[5]] };
  assert.deepEqual(analyzeFields(partial, "reference-date").map(field => field.address), [5, 5]);
});
