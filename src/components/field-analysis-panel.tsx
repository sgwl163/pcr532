import { useMemo, useState } from "react";
import { Download, FileSearch } from "lucide-react";

import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { createAnalysisReport } from "@/lib/analysis-report";
import { NativeSelect } from "@/components/ui/native-select";
import { ValueInspector } from "@/components/value-inspector";
import type { ByteSelection } from "@/components/data-grid";
import { spacedHex, type CardDump } from "@/lib/cards";
import { classicSector } from "@/lib/classic-layout";
import { analyzeFields, type FieldProfile } from "@/lib/field-analysis";

const evidence = {
  structure: "结构",
  decoded: "已解码",
  candidate: "待验证",
  unknown: "未解码",
};

export function FieldAnalysisPanel({
  dump,
  sourceName,
  selection,
  onSelect,
}: {
  dump: CardDump | null;
  sourceName?: string;
  selection?: ByteSelection | null;
  onSelect: (selection: ByteSelection) => void;
}) {
  const initialFilters = { dump, keyword: "", evidence: "all", exportMessage: "" };
  const [filterState, setFilters] = useState(initialFilters);
  const filters = filterState.dump === dump ? filterState : initialFilters;
  const updateFilters = (patch: Partial<typeof filters>) => setFilters({ ...filters, ...patch });
  const [referenceFor, setReferenceFor] = useState<CardDump | null>(null);
  const profile: FieldProfile = dump && referenceFor === dump
    ? "reference-date"
    : "standard";
  const setProfile = (next: FieldProfile) =>
    setReferenceFor(next === "reference-date" ? dump : null);
  const fields = useMemo(() => {
    const priority = { candidate: 0, decoded: 1, structure: 2, unknown: 3 };
    return dump
      ? analyzeFields(dump, profile).sort(
          (a, b) => priority[a.evidence] - priority[b.evidence],
        )
      : [];
  }, [dump, profile]);
  const visibleFields = fields.filter(field =>
    (filters.evidence === "all" || filters.evidence === field.evidence) &&
    `${field.name} ${field.raw} ${spacedHex(field.raw)} ${field.interpretation} ${field.address} ${evidence[field.evidence]}`.toLocaleLowerCase().includes(filters.keyword.trim().toLocaleLowerCase()),
  );
  function exportReport() {
    if (!dump?.rows.length) return;
    if (typeof URL.createObjectURL !== "function" || typeof URL.revokeObjectURL !== "function") {
      updateFilters({ exportMessage: "当前环境不支持本地报告下载。" });
      return;
    }
    let url: string | undefined;
    let link: HTMLAnchorElement | undefined;
    try {
      const report = createAnalysisReport(dump, profile, sourceName);
      url = URL.createObjectURL(new Blob(["\uFEFF", report], { type: "text/plain;charset=utf-8" }));
      link = document.createElement("a");
      link.href = url;
      link.download = "PCR532-analysis.txt";
      document.body.appendChild(link);
      link.click();
      updateFilters({ exportMessage: "已发起本地报告下载，请检查下载位置。尾块密钥已脱敏，分享前仍需审阅用户区内容。" });
    } catch {
      updateFilters({ exportMessage: "报告生成或下载失败，请检查数据布局和下载权限；未确认文件保存。" });
    } finally {
      link?.remove();
      if (url) URL.revokeObjectURL(url);
    }
  }
  const unit = dump?.mode === "type2" ? "页" : "块";
  const hasReferenceDate =
    dump?.mode === "classic" && dump.rows.some((row) => row.address === 5);

  return (
    <section
      className="field-analysis-panel"
      aria-labelledby="field-analysis-title"
    >
      <div className="field-analysis-toolbar">
        <div>
          <h3
            id="field-analysis-title"
            className="flex items-center gap-1.5 text-xs font-semibold"
          >
            <FileSearch className="size-3.5 text-primary" aria-hidden="true" />
            数据项
          </h3>
          <p className="mt-1 text-[10px] text-muted-foreground">
            位置、原始值和当前解释
          </p>
        </div>
        <div className="field-analysis-modes" role="group" aria-label="字段分析方式">
          <Button
            size="xs"
            variant={profile === "standard" ? "secondary" : "ghost"}
            aria-pressed={profile === "standard"}
            onClick={() => setProfile("standard")}
          >
            自动分析
          </Button>
          <Button
            size="xs"
            variant={profile === "reference-date" ? "secondary" : "ghost"}
            aria-pressed={profile === "reference-date"}
            disabled={!hasReferenceDate}
            onClick={() => setProfile("reference-date")}
          >
            参考日期
          </Button>
        </div>
      </div>
      <div className="field-analysis-toolbar-secondary">
        <NativeSelect
          aria-label="字段解析方案"
          value={profile}
          onChange={(event) =>
            setProfile(event.target.value as FieldProfile)
          }
        >
          <option value="standard">通用结构与可读文本</option>
          <option value="reference-date" disabled={!hasReferenceDate}>
            截图日期规则（待验证）
          </option>
        </NativeSelect>
        <span>
          {fields.length ? `显示 ${visibleFields.length} / ${fields.length} 项` : dump ? dump.rows.length ? "当前范围未识别出字段" : "本次读取为 0 字节" : "等待读取或导入数据"}
        </span>
      </div>
      <div className="field-filter-toolbar">
        <Input aria-label="搜索分析字段" placeholder="搜索字段、原始值或说明" value={filters.keyword} onChange={event => updateFilters({ keyword: event.target.value })} />
        <NativeSelect aria-label="字段证据筛选" value={filters.evidence} onChange={event => updateFilters({ evidence: event.target.value })}>
          <option value="all">全部证据</option>
          {Object.entries(evidence).map(([value, label]) => <option key={value} value={value}>{label}</option>)}
        </NativeSelect>
        <Button size="xs" variant="outline" disabled={!dump?.rows.length} onClick={exportReport}><Download aria-hidden="true" />导出分析报告</Button>
      </div>
      {filters.exportMessage && <p className="field-analysis-help" role="status" aria-label="报告导出状态">{filters.exportMessage}</p>}
      <p className="field-analysis-help">
        位置按从 0 开始的块 / 页及字节偏移显示。点击位置可高亮左侧数据；未确认字段保留为“未解码”，不编造房号、权限或有效期。
      </p>
      {profile === "reference-date" && (
        <p className="reference-rule-note">
          截图参考规则（待验证）：块 5、偏移 10–11，大端两字节；年 = 2000 + (值 &gt;&gt; 9)，月 = (值 &gt;&gt; 5) &amp; 15，日 = 值 &amp; 31。375F
          可得到截图中的 2027-10-31，仅验证该示例吻合，尚未确认厂商或有效期用途。
        </p>
      )}
      <div className="field-table-scroll">
        {visibleFields.length ? (
          <table className="field-table">
            <caption className="sr-only">
              数据项、原始位置、数据、解释与证据状态
            </caption>
            <thead>
              <tr>
                <th scope="col">数据项</th>
                <th scope="col">位置</th>
                <th scope="col">数据</th>
                <th scope="col">说明</th>
              </tr>
            </thead>
            <tbody>
              {visibleFields.map((field) => (
                <tr key={field.id} data-evidence={field.evidence}>
                  <th scope="row">
                    <span>{field.name}</span>
                    <span className="field-evidence">
                      {evidence[field.evidence]}
                    </span>
                  </th>
                  <td>
                    <Button
                      size="xs"
                      variant="ghost"
                      aria-label={`定位${unit} ${field.address} 偏移 ${field.offset}${field.length ? ` 长度 ${field.length}` : ""}`}
                      onClick={() =>
                        onSelect({
                          address: field.address,
                          offset: field.offset,
                          length: field.length,
                        })
                      }
                    >
                      {dump?.mode === "classic"
                        ? `扇区 ${classicSector(field.address)} / `
                        : ""}
                      {unit} {field.address}
                      {field.length
                        ? ` · ${field.offset}–${field.offset + field.length - 1}`
                        : " · 片段起始"}
                    </Button>
                  </td>
                  <td className="field-raw">
                    {field.raw === "—" ? "—" : spacedHex(field.raw)}
                  </td>
                  <td>{field.interpretation}</td>
                </tr>
              ))}
            </tbody>
          </table>
        ) : (
          <p className="p-4 text-xs leading-6 text-muted-foreground">
            {fields.length ? "没有符合筛选条件的字段；原始数据未改变。" : dump
              ? "当前范围没有可列出的结构或字段，请查看原始数据或“内容与日期”页签。"
              : "读取卡片或导入 .dump 后，在这里查看字段位置、原始值与解释。"}
          </p>
        )}
      </div>
      {dump && (
        <div className="field-inspector">
          <ValueInspector
            key={`${dump.card.uid}:${dump.rows.map((row) => `${row.address}:${row.hex}`).join(",")}`}
            dump={dump}
            selection={selection}
            onSelect={onSelect}
          />
        </div>
      )}
    </section>
  );
}
