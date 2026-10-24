import { readCapability, type CardDump } from "./cards.ts";
import { classicSector, classicTrailer } from "./classic-layout.ts";
import { analyzeCardData } from "./nfc-data.ts";
import { decodeNfcValue } from "./nfc-values.ts";

export type FieldAnalysis = {
  id: string;
  name: string;
  address: number;
  offset: number;
  length: number;
  raw: string;
  interpretation: string;
  evidence: "structure" | "decoded" | "candidate" | "unknown";
};
export type FieldProfile = "standard" | "reference-date";

/** A selected reference rule is a hypothesis, never automatic vendor recognition or expiry detection. */
export function analyzeFields(dump: CardDump, profile: FieldProfile): FieldAnalysis[] {
  const capability = readCapability(dump.card);
  if (!capability || capability.mode !== dump.mode || dump.rows.length > 256) return [];
  const rows = [...dump.rows].sort((a, b) => a.address - b.address);
  const seen = new Set<number>();
  for (const row of rows) {
    if (!Number.isInteger(row.address) || row.address < 0 || row.address >= capability.units || seen.has(row.address) || !new RegExp(`^[\\da-fA-F]{${capability.bytes * 2}}$`).test(row.hex)) return [];
    seen.add(row.address);
  }
  const fields: FieldAnalysis[] = [];
  const add = (field: FieldAnalysis) => fields.push(field);
  if (dump.mode === "classic") for (const row of rows) {
    const hex = row.hex.toUpperCase();
    if (row.address === 0) {
      if (dump.card.uidLength === 4) add({ id: "uid", name: "卡片标识（四字节布局）", address: 0, offset: 0, length: 4, raw: hex.slice(0, 8), interpretation: "UID 候选；文件内字节不代表射频检测或芯片真伪。", evidence: "structure" });
      continue;
    }
    if (classicTrailer(row.address)) {
      const bytes = hex.match(/../g)!.map(b => Number.parseInt(b, 16));
      const [a, b, c] = bytes.slice(6, 9);
      const valid = ((a & 15) ^ (b >> 4)) === 15 && ((a >> 4) ^ (c & 15)) === 15 && ((b & 15) ^ (c >> 4)) === 15;
      add({ id: `access-${row.address}`, name: `扇区 ${classicSector(row.address)} 访问条件`, address: row.address, offset: 6, length: 3, raw: hex.slice(12, 18), interpretation: valid ? "访问位冗余校验有效；不等于所有操作均获允许。" : "访问位冗余校验无效，检查导出数据或卡片布局。", evidence: "structure" });
      continue;
    }
    if (profile === "reference-date" && row.address === 5) {
      let interpretation: string;
      try {
        interpretation = `${decodeNfcValue(hex, "packed-date-2000-be", 10).value}；与截图的 375F → 2027-10-31 一致，字段用途待验证。`;
      } catch {
        interpretation = "按截图参考规则计算不是有效日历日期，未采用日期结果。";
      }
      add({ id: "reference-date", name: "日期候选（截图参考规则）", address: 5, offset: 10, length: 2, raw: hex.slice(20, 24), interpretation, evidence: "candidate" });
    }
  }
  const analysis = analyzeCardData(dump);
  analysis.records.forEach((record, index) => add({ id: `record-${index}`, name: record.type, address: record.address, offset: 0, length: 0, raw: "—", interpretation: record.text, evidence: "decoded" }));
  analysis.dates.forEach((date, index) => add({ id: `date-${index}`, name: "文本 / 日历日期", address: date.address, offset: 0, length: 0, raw: "—", interpretation: `${date.value} · ${date.source}`, evidence: "decoded" }));
  analysis.textSegments.forEach((segment, index) => add({ id: `text-${index}`, name: "可读文本片段", address: segment.address, offset: 0, length: 0, raw: "—", interpretation: segment.text, evidence: "decoded" }));
  if (dump.mode === "classic") for (const row of rows) {
    if (row.address === 0 || classicTrailer(row.address) || /^0{32}$/i.test(row.hex) || /^F{32}$/i.test(row.hex)) continue;
    add({ id: `raw-${row.address}`, name: "普通数据（未解码）", address: row.address, offset: 0, length: 16, raw: row.hex.toUpperCase(), interpretation: "保留原始字节，业务字段、校验或额外加密均未确认。", evidence: "unknown" });
  }
  return fields;
}
