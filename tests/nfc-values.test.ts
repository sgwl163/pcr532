import assert from "node:assert/strict";
import test from "node:test";
import { decodeNfcValue } from "../src/lib/nfc-values.ts";

test("explicit Unix interpretation respects byte order, offset and UTC", () => {
  assert.equal(
    decodeNfcValue("00000000", "unix-seconds-be", 0).value,
    "1970-01-01T00:00:00Z（UTC）",
  );
  assert.equal(
    decodeNfcValue("FF00000001", "unix-seconds-be", 1).value,
    "1970-01-01T00:00:01Z（UTC）",
  );
  assert.equal(
    decodeNfcValue("01000000", "unix-seconds-le", 0).value,
    "1970-01-01T00:00:01Z（UTC）",
  );
  assert.equal(
    decodeNfcValue("FFFFFFFF", "unix-seconds-be", 0).value,
    "2106-02-07T06:28:15Z（UTC）",
  );
});

test("explicit BCD interpretation validates calendar dates and preserves provenance", () => {
  assert.deepEqual(decodeNfcValue("FF20261024AA", "bcd-date", 1), {
    value: "2026-10-24（无时区的日期）",
    raw: "20261024",
    bytes: 4,
  });
  assert.equal(
    decodeNfcValue("20240229", "bcd-date", 0).value,
    "2024-02-29（无时区的日期）",
  );
  for (const value of [
    "20260229",
    "20261301",
    "20260001",
    "20260431",
    "00000101",
    "20A61024",
  ])
    assert.throws(() => decodeNfcValue(value, "bcd-date", 0));
});

test("UTF8 interpretation accepts text and trailing padding but rejects malformed and control data", () => {
  assert.equal(decodeNfcValue("E697A5E69C9F0000", "utf8", 0).value, "日期");
  for (const hex of ["FF", "410042", "1B4142", "00"])
    assert.throws(() => decodeNfcValue(hex, "utf8", 0));
});

test("manual interpretation requires valid offsets, whole bytes and sufficient data", () => {
  for (const offset of [-1, 0.5, 4, NaN, Infinity])
    assert.throws(() => decodeNfcValue("00000000", "bcd-date", offset));
  for (const hex of ["", "123", "GG", " 20261024"])
    assert.throws(() => decodeNfcValue(hex, "bcd-date", 0));
  assert.throws(() => decodeNfcValue("20261024", "bcd-date", 1), /4 字节/);
});
