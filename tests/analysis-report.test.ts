import assert from "node:assert/strict";
import test from "node:test";
import { createAnalysisReport } from "../src/lib/analysis-report.ts";
import { parseClassicDump } from "../src/lib/dump-file.ts";
import type { CardDump } from "../src/lib/cards.ts";

function sample(): CardDump {
  const bytes = new Uint8Array(1024);
  bytes.set([0x37, 0x5f], 5 * 16 + 10);
  bytes.set([0x11, 0x22, 0x33, 0x44, 0x55, 0x66, 0xff, 0x07, 0x80, 0x69, 0xaa, 0xbb, 0xcc, 0xdd, 0xee, 0xff], 3 * 16);
  return parseClassicDump(bytes);
}

test("analysis report masks both trailer keys, preserves addresses and avoids arbitrary errors", () => {
  const dump = sample();
  dump.error = "秘密 112233445566";
  const original = JSON.stringify(dump);
  const report = createAnalysisReport(dump, "standard", "自有卡.dump");
  assert.match(report, /1024 B · 64 块/);
  assert.match(report, /离线文件：自有卡.dump/);
  assert.match(report, /UID 候选/);
  assert.match(report, /块 3：\*\* \*\* \*\* \*\* \*\* \*\* FF 07 80 69 \*\* \*\* \*\* \*\* \*\* \*\*/);
  assert.doesNotMatch(report, /11 22 33 44 55 66|AA BB CC DD EE FF|秘密|112233445566/);
  assert.match(report, /全部字段/);
  assert.match(report, /不能确认房号、权限或有效期/);
  assert.equal(JSON.stringify(dump), original);
});

test("manual reference dates remain opt-in candidates in the report", () => {
  const dump = sample();
  assert.doesNotMatch(createAnalysisReport(dump, "standard"), /2027-10-31/);
  const report = createAnalysisReport(dump, "reference-date");
  assert.match(report, /参考日期.*手动.*待验证/);
  assert.match(report, /\[待验证\].*日期候选/);
  assert.match(report, /2027-10-31/);
  assert.match(report, /字段用途待验证/);
});

test("partial captures never fabricate missing rows or claim whole-card completion", () => {
  const dump = sample();
  dump.complete = false;
  dump.rows = [dump.rows[5]];
  const report = createAnalysisReport(dump, "standard");
  assert.match(report, /16 B · 1 块/);
  assert.match(report, /部分结果/);
  assert.doesNotMatch(report, /块 4：|块 6：/);
  assert.match(report, /不代表整卡/);
});

test("report rejects inconsistent rows instead of exporting unvalidated bytes", () => {
  const dump = sample();
  assert.throws(() => createAnalysisReport({ ...dump, rows: [...dump.rows, dump.rows[0]] }, "standard"), /数据布局/);
  assert.throws(() => createAnalysisReport({ ...dump, rows: [{ address: 3, hex: "NOT HEX" }] }, "standard"), /数据布局/);
  assert.throws(() => createAnalysisReport({ ...dump, mode: "type2" }, "standard"), /数据布局/);
});
