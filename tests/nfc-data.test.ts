import assert from "node:assert/strict";
import test from "node:test";
import { analyzeCardData } from "../src/lib/nfc-data.ts";
import type { CardDump, CardInfo } from "../src/lib/cards.ts";

const card: CardInfo = {
  uid: "04112233445566",
  uidLength: 7,
  atqa: "0044",
  sak: "00",
  family: "type2",
  typeName: "Type 2",
};
const utf8 = (text: string) => [...new TextEncoder().encode(text)];
const hex = (bytes: number[]) =>
  bytes
    .map((byte) => byte.toString(16).padStart(2, "0"))
    .join("")
    .toUpperCase();
function dump(bytes: number[], start = 4): CardDump {
  const padded = [...bytes];
  while (padded.length % 4) padded.push(0);
  return {
    card,
    mode: "type2",
    rows: Array.from({ length: padded.length / 4 }, (_, i) => ({
      address: start + i,
      hex: hex(padded.slice(i * 4, i * 4 + 4)),
    })),
    complete: true,
    error: null,
  };
}
function record(type: string, payload: number[], flags = 0xd1): number[] {
  const typeBytes = utf8(type);
  const length =
    flags & 0x10
      ? [payload.length]
      : [0, 0, payload.length >> 8, payload.length & 255];
  return [flags, typeBytes.length, ...length, ...typeBytes, ...payload];
}
function tlv(message: number[]) {
  return [
    3,
    ...(message.length < 255
      ? [message.length]
      : [255, message.length >> 8, message.length & 255]),
    ...message,
    254,
  ];
}
function classic(
  rows: { address: number; text?: string; hex?: string }[],
): CardDump {
  return {
    card: { ...card, family: "classic1k", sak: "08" },
    mode: "classic",
    complete: true,
    error: null,
    rows: rows.map((row) => ({
      address: row.address,
      hex:
        row.hex ??
        hex([
          ...utf8(row.text ?? ""),
          ...new Array(16 - utf8(row.text ?? "").length).fill(0),
        ]),
    })),
  };
}

test("Type 2 parses standard text with language and valid stored date provenance", () => {
  const data = dump(tlv(record("T", [2, 101, 110, ...utf8("2026-10-24")])));
  const result = analyzeCardData(data);
  assert.equal(result.format, "NFC Type 2 / NDEF");
  assert.deepEqual(result.records, [
    { type: "NDEF 文本", language: "en", text: "2026-10-24", address: 4 },
  ]);
  assert.equal(result.dates[0].value, "2026-10-24");
  assert.equal(result.dates[0].address, 4);
  assert.match(result.dates[0].source, /明确日期/);
  assert.deepEqual(result.textSegments, []);
});

test("Type 2 expands URI prefixes but never treats a URL path as a stored date field", () => {
  const result = analyzeCardData(
    dump(tlv(record("U", [4, ...utf8("example.com/2026-10-24")]))),
  );
  assert.equal(result.records[0].text, "https://example.com/2026-10-24");
  assert.deepEqual(result.dates, []);
  const invalid = analyzeCardData(dump(tlv(record("U", [255, 65]))));
  assert.deepEqual(invalid.records, []);
  assert.match(invalid.warnings.join(" "), /前缀/);
});

test("NDEF supports multiple records and long payload lengths with ID fields", () => {
  const a = record("T", [2, 101, 110, ...utf8("first")], 0x91);
  const b = record("T", [2, 101, 110, ...utf8("last")], 0x51);
  assert.deepEqual(
    analyzeCardData(dump(tlv([...a, ...b]))).records.map((item) => item.text),
    ["first", "last"],
  );
  const long = record(
    "text/plain",
    utf8("2024-02-29 " + "a".repeat(270)),
    0xc2,
  );
  const result = analyzeCardData(dump(tlv(long)));
  assert.equal(result.records[0].text.length, 281);
  assert.equal(result.dates[0].value, "2024-02-29");
  const identified = [
    0xd9, 1, 7, 2, 0x54, 0x01, 0x02, 2, 101, 110, 116, 101, 115, 116,
  ];
  assert.equal(analyzeCardData(dump(tlv(identified))).records[0].text, "test");
});

test("UTF16 text honors BOM or defaults to big-endian and rejects malformed code units", () => {
  for (const payload of [
    [0x82, 101, 110, 0xfe, 0xff, 0x65, 0xe5, 0x67, 0x1f],
    [0x82, 101, 110, 0xff, 0xfe, 0xe5, 0x65, 0x1f, 0x67],
    [0x82, 101, 110, 0x65, 0xe5, 0x67, 0x1f],
  ])
    assert.equal(
      analyzeCardData(dump(tlv(record("T", payload)))).records[0].text,
      "日期",
    );
  for (const payload of [
    [0x82, 101, 110, 0x65],
    [2, 101, 110, 0xff],
    [0x82, 101, 110, 0xd8, 0],
    [0x42, 101, 110, 65],
    [3, 101],
  ]) {
    const result = analyzeCardData(dump(tlv(record("T", payload))));
    assert.deepEqual(result.records, []);
    assert.ok(result.warnings.length);
  }
});

test("malformed message boundaries, impossible lengths and chunked records never publish records", () => {
  const good = record("T", [2, 101, 110, 65]);
  const malformed = [
    good.map((b, i) => (i === 0 ? 0x51 : b)),
    good.map((b, i) => (i === 0 ? 0x91 : b)),
    good.map((b, i) => (i === 0 ? 0xf1 : b)),
    good.map((b, i) => (i === 0 ? 0xd7 : b)),
    good.map((b, i) => (i === 2 ? 0xff : b)),
    [...good, 1],
    [0xc1, 1, 255, 255, 255, 255, 84],
    [0xd0, 1, 1, 84, 65],
    [0xd5, 1, 0, 84],
  ];
  for (const message of malformed) {
    const result = analyzeCardData(dump(tlv(message)));
    assert.deepEqual(result.records, []);
    assert.deepEqual(result.dates, []);
    assert.ok(result.warnings.length);
  }
});

test("truncated TLV, missing page4 and gaps warn without guessing later NDEF boundaries", () => {
  for (const bytes of [
    [3, 100, 0xd1, 1],
    [3, 255, 1, 0],
    [3, 255, 0, 2],
  ]) {
    const result = analyzeCardData(dump(bytes));
    assert.deepEqual(result.records, []);
    assert.match(result.warnings.join(" "), /截断|不足|无效/);
  }
  const source = dump(tlv(record("T", [2, 101, 110, ...utf8("2026-10-24")])));
  const missing = analyzeCardData({ ...source, rows: source.rows.slice(1) });
  assert.deepEqual(missing.records, []);
  assert.match(missing.warnings.join(" "), /用户页 4/);
  const gap = analyzeCardData({
    ...source,
    rows: source.rows.filter((row) => row.address !== 5),
  });
  assert.deepEqual(gap.records, []);
  assert.match(gap.warnings.join(" "), /间隔|不足/);
});

test("control TLVs stop interpretation before unimplemented reserved-memory mapping", () => {
  const result = analyzeCardData(
    dump([
      1,
      3,
      0xa0,
      0x10,
      0x44,
      ...tlv(record("T", [2, 101, 110, ...utf8("2026-10-24")])),
    ]),
  );
  assert.deepEqual(result.records, []);
  assert.deepEqual(result.dates, []);
  assert.match(result.warnings.join(" "), /物理内存映射/);
});

test("calendar dates retain field and timezone rather than guessing expiry semantics", () => {
  const text =
    "BEGIN:VCALENDAR\r\nBEGIN:VEVENT\r\nDTSTART;VALUE=DATE:20261024\r\nDTEND;TZID=Asia/Shanghai:20261025T090000\r\nDTSTAMP:20261023T010203Z\r\nEND:VEVENT\r\nEND:VCALENDAR";
  const result = analyzeCardData(
    dump(tlv(record("text/calendar", utf8(text), 0xd2))),
  );
  assert.equal(result.records[0].type, "NDEF 日历");
  assert.deepEqual(
    result.dates.map((date) => date.value),
    ["2026-10-24", "2026-10-25T09:00:00", "2026-10-23T01:02:03Z"],
  );
  assert.match(result.dates[0].source, /DTSTART/);
  assert.match(result.dates[1].source, /Asia\/Shanghai.*未换算/);
  assert.match(result.dates[2].source, /UTC/);
  assert.ok(!JSON.stringify(result.dates).includes("到期"));
});

test("invalid dates and contradictory calendar value types are rejected without rollover", () => {
  const text =
    "BEGIN:VCALENDAR\nDTSTART;VALUE=DATE:20260229\nDTEND:20260431T120000Z\nDTSTAMP:20261024T250000Z\nCREATED;VALUE=DATE:20261024T010203Z\nLAST-MODIFIED;TZID=Asia/Shanghai:20261024T010203Z\nEND:VCALENDAR";
  const result = analyzeCardData(
    dump(tlv(record("text/calendar", utf8(text), 0xd2))),
  );
  assert.deepEqual(result.dates, []);
  assert.ok(result.warnings.some((warning) => warning.includes("日期无效")));
});

test("Classic extracts ordinary user text dates but excludes manufacturer and trailer bytes", () => {
  const result = analyzeCardData(
    classic([
      { address: 0, text: "2020-01-01" },
      { address: 1, text: "2024/02/29" },
      { address: 2, text: "2026-02-29" },
      { address: 3, text: "2021-01-01" },
      { address: 4, hex: "32303236E5B9B43130E69C883234E697" },
      { address: 5, hex: "A5" + "00".repeat(15) },
    ]),
  );
  assert.deepEqual(
    result.dates.map((date) => date.value),
    ["2024-02-29", "2026-10-24"],
  );
  assert.deepEqual(
    result.dates.map((date) => date.address),
    [1, 4],
  );
  assert.match(result.warnings.join(" "), /扇区映射/);
});

test("Classic never joins dates over sector trailers, manufacturer blocks or missing addresses", () => {
  const result = analyzeCardData(
    classic([
      { address: 2, text: "AAAAAA2026-10-" },
      { address: 3, text: "XX" },
      { address: 4, text: "24BBBBBBBBBBBB" },
      { address: 8, text: "AAAAAA2026-10-" },
      { address: 10, text: "24BBBBBBBBBBBB" },
    ]),
  );
  assert.deepEqual(result.dates, []);
});

test("binary values are never auto-detected as timestamps, and malformed memory is bounded", () => {
  const binary = analyzeCardData(
    classic([{ address: 4, hex: "20261024FFFFFFFF0000000000000000" }]),
  );
  assert.deepEqual(binary.dates, []);
  const source = dump([3, 0, 254, 0]);
  for (const rows of [
    [...source.rows, source.rows[0]],
    [{ address: 4, hex: "GGGGGGGG" }],
    [{ address: 4, hex: "00" }],
    [{ address: -1, hex: "00000000" }],
  ]) {
    const result = analyzeCardData({ ...source, rows });
    assert.deepEqual(result.records, []);
    assert.deepEqual(result.dates, []);
    assert.match(result.warnings.join(" "), /非法|无效|重复/);
  }
});

test("NULL/proprietary TLVs are skipped and CC/UID bytes are excluded from content", () => {
  const source = dump([
    0,
    0xfd,
    2,
    0x41,
    0x42,
    ...tlv(record("T", [2, 101, 110, ...utf8("2026-10-24")])),
  ]);
  source.rows.unshift(
    { address: 0, hex: "32303236" },
    { address: 3, hex: "E1100600" },
  );
  const result = analyzeCardData(source);
  assert.equal(result.records[0].text, "2026-10-24");
  assert.equal(result.records[0].address, 5);
  assert.equal(result.dates.length, 1);
  assert.equal(result.textSegments.length, 0);
});

test("non-NDEF Type 2 printable text can expose explicit dates without claiming a standard format", () => {
  const result = analyzeCardData(dump(utf8("expiry=2026-10-24")));
  assert.equal(result.records.length, 0);
  assert.equal(result.textSegments[0].text, "expiry=2026-10-24");
  assert.equal(result.dates[0].value, "2026-10-24");
  assert.match(result.dates[0].source, /含义未确认/);
  assert.match(result.warnings.join(" "), /不代表已确认/);
});

test("bounded arbitrary memory remains deterministic and never throws", () => {
  let seed = 12345;
  for (let i = 0; i < 300; i++) {
    const bytes = Array.from({ length: 48 }, () => {
      seed = (Math.imul(seed, 1664525) + 1013904223) | 0;
      return (seed >>> 24) & 255;
    });
    const source = dump(bytes);
    const before = JSON.stringify(source);
    const a = analyzeCardData(source);
    assert.deepEqual(analyzeCardData(source), a);
    assert.equal(JSON.stringify(source), before);
  }
});

test("incomplete reads and unknown record types preserve limitations instead of claiming empty card", () => {
  const unknown = dump(tlv(record("example:private", [1, 2, 3], 0xd4)));
  const result = analyzeCardData({
    ...unknown,
    complete: false,
    error: "read stopped",
  });
  assert.deepEqual(result.records, []);
  assert.match(result.warnings.join(" "), /未完成/);
  assert.match(result.warnings.join(" "), /暂不解释/);
  assert.match(result.warnings.join(" "), /0–15/);
});
