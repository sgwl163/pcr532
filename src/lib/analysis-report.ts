import { readCapability, spacedHex, type CardDump } from "./cards.ts";
import { classicTrailer } from "./classic-layout.ts";
import { analyzeFields, type FieldProfile } from "./field-analysis.ts";

const evidence = { structure: "结构", decoded: "已解码", candidate: "待验证", unknown: "未解码" };
const oneLine = (value: string) => value.replace(/[\u0000-\u001F\u007F-\u009F]/g, " ");

/** Read-only, human-readable report; never a restorable raw dump or credential export. */
export function createAnalysisReport(dump: CardDump, profile: FieldProfile, sourceName?: string): string {
  const capability = readCapability(dump.card);
  const seen = new Set<number>();
  if (!capability || capability.mode !== dump.mode || dump.rows.length > capability.units)
    throw new Error("数据布局不一致，无法生成报告。");
  const rows = [...dump.rows].sort((a, b) => a.address - b.address);
  for (const row of rows) {
    if (!Number.isInteger(row.address) || row.address < 0 || row.address >= capability.units || seen.has(row.address) || !new RegExp(`^[0-9a-fA-F]{${capability.bytes * 2}}$`).test(row.hex))
      throw new Error("数据布局不一致，无法生成报告。");
    seen.add(row.address);
  }
  const unit = dump.mode === "classic" ? "块" : "页";
  const fields = analyzeFields(dump, profile);
  const lines = [
    "PCR532 本地数据分析报告（尾块密钥已脱敏）",
    sourceName ? `离线文件：${oneLine(sourceName)}` : "来源：当前读取结果（仅代表本次取得的数据）",
    sourceName ? `UID 候选：${oneLine(dump.card.uid)}；文件布局不代表射频验证。` : `UID：${oneLine(dump.card.uid)}；标识相同不能证明同一张物理卡。`,
    `模式：${dump.mode === "classic" ? "Classic" : "NFC Type 2"}`,
    `已取得：${rows.length * capability.bytes} B · ${rows.length} ${unit}`,
    `范围状态：${sourceName ? "文件布局已载入（不代表实卡读取成功）" : dump.complete ? "所选范围完成，不代表整卡" : "部分结果，不代表整卡"}`,
    `解析方案：${profile === "reference-date" ? "参考日期（手动启用，待验证）" : "通用结构与可读内容"}`,
    "边界：取得字节不等于解密业务字段；不能确认房号、权限或有效期。",
    "日期候选仅是所选编码计算结果，不是电脑时间，也不证明字段用途。",
    "此报告包括全部字段，不受界面筛选影响；人工字节查看器的临时解释不计入字段。",
    "报告包含用户区内容和标识；分享前请自行审阅并删除其他敏感信息。",
    "尾块 Key A / B 字节始终替换为 **；不包含认证输入、命中密钥或原始错误文本。",
    "这是只读文本报告，不能用于写入恢复、克隆或补齐缺失数据。",
    "", `全部字段（${fields.length} 项）：`,
  ];
  for (const field of fields) {
    lines.push(`[${evidence[field.evidence]}] ${oneLine(field.name)} | ${unit} ${field.address} · 偏移 ${field.offset}${field.length ? ` · 长度 ${field.length}` : " · 片段起始"}`);
    lines.push(`数据：${field.raw === "—" ? "—" : spacedHex(field.raw)} | 说明：${oneLine(field.interpretation)}`);
  }
  if (!fields.length) lines.push("当前范围未识别出可列字段。");
  lines.push("", "已取得的原始行（尾块密钥已脱敏，不补齐缺失地址）：");
  for (const row of rows) {
    const trailer = dump.mode === "classic" && classicTrailer(row.address);
    const bytes = row.hex.toUpperCase().match(/../g)!;
    lines.push(`${unit} ${row.address}：${bytes.map((byte, offset) => trailer && (offset < 6 || offset >= 10) ? "**" : byte).join(" ")}`);
  }
  return lines.join("\r\n");
}
