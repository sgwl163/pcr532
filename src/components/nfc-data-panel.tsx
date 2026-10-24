import { useMemo } from "react";
import { CalendarDays, FileSearch, FileText, Info } from "lucide-react";

import { ValueInspector } from "@/components/value-inspector";
import { analyzeCardData } from "@/lib/nfc-data";
import type { CardDump } from "@/lib/cards";

export function NfcDataPanel({ dump, showInspector = true }: { dump: CardDump | null; showInspector?: boolean }) {
  const analysis = useMemo(() => (dump ? analyzeCardData(dump) : null), [dump]);
  const unit = dump?.mode === "type2" ? "页" : "块";
  return (
    <section
      id="nfc-analysis"
      className="work-pane analysis-pane"
      aria-labelledby="analysis-title"
    >
      <header className="pane-heading">
        <div className="flex items-center gap-2">
          <FileSearch className="size-4 text-primary" aria-hidden="true" />
          <h2 id="analysis-title">NFC 内容与日期解析</h2>
        </div>
        <span className="text-[10px] text-muted-foreground">
          本地解析 · 不上传
        </span>
      </header>
      <div className="analysis-content">
        {!analysis ? (
          <div className="flex items-start gap-2 text-xs leading-6 text-muted-foreground">
            <Info className="mt-1 size-4 shrink-0" aria-hidden="true" />
            <p>
              读取后自动分析 NFC
              数据交换格式（NDEF）中的文本、链接和日历记录，以及用户区可读文本中的明确日期。卡片没有统一的“到期日期”字段；门禁或厂商私有数据需要对应格式说明。
            </p>
          </div>
        ) : (
          <>
            <div className="mb-3 flex flex-wrap items-center gap-2 text-xs">
              <span className="rounded bg-primary/8 px-2 py-1 font-medium text-primary">
                {analysis.format}
              </span>
              <span className="text-muted-foreground">
                {analysis.records.length} 条记录 · {analysis.dates.length}{" "}
                个日期
              </span>
            </div>
            <div className="analysis-columns">
              <section aria-label="解析记录" className="min-w-0 space-y-2">
                <h3 className="flex items-center gap-1.5 text-xs font-semibold">
                  <FileText className="size-3.5" aria-hidden="true" />
                  文本与内容
                </h3>
                {analysis.records.map((record, index) => (
                  <div key={index} className="analysis-item">
                    <p className="mb-1 text-[10px] text-muted-foreground">
                      {record.type}
                      {record.language ? ` · ${record.language}` : ""} ·
                      记录起始
                      {unit} {record.address}
                    </p>
                    <p className="break-words whitespace-pre-wrap text-xs select-text">
                      {record.text}
                    </p>
                  </div>
                ))}
                {analysis.textSegments.map((segment, index) => (
                  <div key={`text-${index}`} className="analysis-item">
                    <p className="mb-1 text-[10px] text-muted-foreground">
                      用户区可读文本 · 片段起始{unit} {segment.address} ·
                      含义未确认
                    </p>
                    <p className="break-words whitespace-pre-wrap text-xs select-text">
                      {segment.text}
                    </p>
                  </div>
                ))}
                {!analysis.records.length && !analysis.textSegments.length && (
                  <p className="text-xs leading-5 text-muted-foreground">
                    此范围未解析出可读内容。原始字节仍保留在数据表 A 中。
                  </p>
                )}
              </section>
              <section aria-label="卡内日期" className="min-w-0 space-y-2">
                <h3 className="flex items-center gap-1.5 text-xs font-semibold">
                  <CalendarDays className="size-3.5" aria-hidden="true" />
                  数据中的日期
                </h3>
                {analysis.dates.map((date, index) => (
                  <div
                    key={index}
                    className="analysis-item border-l-2 border-l-primary/50"
                  >
                    <p className="font-mono text-sm font-medium select-text">
                      {date.value}
                    </p>
                    <p className="mt-1 break-words text-[10px] leading-5 text-muted-foreground">
                      {date.source} · 来源记录/片段起始{unit} {date.address}
                    </p>
                  </div>
                ))}
                {!analysis.dates.length && (
                  <p className="text-xs leading-5 text-muted-foreground">
                    未找到可确认编码的日期。二进制数据不会自动推断为时间戳或有效期。
                  </p>
                )}
                <p className="text-[11px] leading-5 text-muted-foreground">
                  此处日期来自已读取内容，不是电脑时间；即使发现日期，也不能据此确认它表示开卡、到期或最后使用时间。
                </p>
              </section>
            </div>
            {analysis.warnings.length > 0 && (
              <ul className="mt-3 space-y-1 rounded border border-amber-600/20 bg-amber-50/60 p-2.5 text-[11px] leading-5 text-amber-900">
                {analysis.warnings.map((warning, index) => (
                  <li key={index}>• {warning}</li>
                ))}
              </ul>
            )}
          </>
        )}
        {dump && showInspector && (
          <ValueInspector
            key={`${dump.card.uid}:${dump.rows.map((row) => `${row.address}:${row.hex}`).join(",")}`}
            dump={dump}
          />
        )}
      </div>
    </section>
  );
}
