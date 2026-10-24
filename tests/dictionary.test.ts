import assert from "node:assert/strict";
import test from "node:test";
import {
  classicSectors,
  makeDictionaryRequest,
} from "../src/lib/dictionary.ts";
import type { CardInfo } from "../src/lib/cards.ts";

const card: CardInfo = {
  uid: "12345678",
  uidLength: 4,
  atqa: "0004",
  sak: "08",
  family: "classic1k",
  typeName: "Classic",
};
const selection = {
  startSector: "0",
  sectorCount: "1",
  useCommonKeys: true,
  dictionary: "",
  confirmed: true,
};

test("dictionary detection requires a supported family and explicit authorization", () => {
  assert.equal(classicSectors(card), 16);
  assert.equal(classicSectors({ ...card, family: "classic4k" }), 40);
  assert.equal(classicSectors({ ...card, family: "classicMini" }), 5);
  assert.throws(
    () =>
      makeDictionaryRequest(card, { ...selection, confirmed: false }, "run"),
    /授权/,
  );
  assert.throws(
    () => makeDictionaryRequest({ ...card, family: "type2" }, selection, "run"),
    /仅支持/,
  );
});

test("dictionary input is bounded, normalized, deduplicated and never invents a candidate", () => {
  const request = makeDictionaryRequest(
    card,
    {
      ...selection,
      useCommonKeys: false,
      dictionary: "aabbccddeeff\n112233445566;AABBCCDDEEFF",
    },
    "run",
  );
  assert.deepEqual(request.keys, ["AABBCCDDEEFF", "112233445566"]);
  assert.equal(request.useCommonKeys, false);
  assert.throws(
    () =>
      makeDictionaryRequest(
        card,
        { ...selection, useCommonKeys: false },
        "run",
      ),
    /字典/,
  );
  assert.throws(
    () =>
      makeDictionaryRequest(card, { ...selection, dictionary: "1234" }, "run"),
    /12/,
  );
  assert.throws(
    () =>
      makeDictionaryRequest(
        card,
        { ...selection, dictionary: Array(65).fill("112233445566").join(" ") },
        "run",
      ),
    /64/,
  );
});

test("dictionary range uses sectors rather than blocks, including the Classic 4K boundary", () => {
  assert.throws(
    () =>
      makeDictionaryRequest(
        card,
        { ...selection, startSector: "15", sectorCount: "2" },
        "run",
      ),
    /0–15/,
  );
  assert.throws(
    () =>
      makeDictionaryRequest(card, { ...selection, startSector: "1.5" }, "run"),
    /整数/,
  );
  const request = makeDictionaryRequest(
    { ...card, family: "classic4k" },
    { ...selection, startSector: "32", sectorCount: "8" },
    "run",
  );
  assert.equal(request.startSector, 32);
  assert.equal(request.sectorCount, 8);
});
