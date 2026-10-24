import { useRef, useState, type ReactNode } from "react";
import { Binary, ChevronDown, ChevronUp, Columns3, Database, LockKeyhole, Search } from "lucide-react";

import { Badge } from "@/components/ui/badge";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { NativeSelect } from "@/components/ui/native-select";
import {
  readCapability,
  spacedHex,
  writableAddress,
  type CardDump,
} from "@/lib/cards";
import { classicSector, classicTrailer } from "@/lib/classic-layout";

import { findByteMatches, resolveLoadedAddress, type ByteSelection, type SearchEncoding } from "@/lib/data-navigation";

export type { ByteSelection } from "@/lib/data-navigation";

function ascii(hex: string, hideKeys: boolean) {
  return (hex.match(/../g) ?? []).map((byte, index) => {
    if (hideKeys && (index < 6 || index >= 10)) return "·";
    const value = Number.parseInt(byte, 16);
    return value >= 32 && value <= 126 ? String.fromCharCode(value) : "·";
  }).join("");
}

export function DataGrid({ dump, selectedAddress, onSelect, sourceName, fieldSelection, headerAction, onSelectBytes }: {
  dump: CardDump | null;
  selectedAddress: number | null;
  onSelect: (address: number) => void;
  sourceName?: string;
  fieldSelection?: ByteSelection | null;
  headerAction?: ReactNode;
  onSelectBytes?: (selection: ByteSelection) => void;
}) {
  const [showAscii, setShowAscii] = useState(true);
  const [hexAddress, setHexAddress] = useState(false);
  const [revealFor, setRevealFor] = useState<CardDump | null>(null);
  const showKeys = !!dump && revealFor === dump;
  const tableRef = useRef<HTMLDivElement>(null);
  const emptyNavigation = { dump, query: "", encoding: "hex" as SearchEncoding, jump: "", matches: [] as ByteSelection[], index: -1, message: "" };
  const [navigationState, setNavigation] = useState(emptyNavigation);
  // Bind searches to a capture identity: newly loaded data never inherits stale matches.
  const navigation = navigationState.dump === dump ? navigationState : emptyNavigation;
  const activeMatch = navigation.matches[navigation.index];
  function updateNavigation(patch: Partial<typeof navigation>) {
    setNavigation({ ...navigation, ...patch });
  }
  function scrollToAddress(address: number) {
    tableRef.current?.querySelector(`[data-address="${address}"]`)?.scrollIntoView?.({ block: "nearest", behavior: "smooth" });
  }
  function selectMatch(match: ByteSelection) {
    if (onSelectBytes) onSelectBytes(match);
    else onSelect(match.address);
    scrollToAddress(match.address);
  }
  function search() {
    if (!dump) return;
    try {
      const matches = findByteMatches(dump, navigation.query, navigation.encoding);
      updateNavigation({ matches, index: matches.length ? 0 : -1, message: matches.length ? "" : "未找到匹配；仅搜索已载入的单块 / 页，排除尾块密钥。" });
      if (matches[0]) selectMatch(matches[0]);
    } catch (cause) {
      updateNavigation({ matches: [], index: -1, message: cause instanceof Error ? cause.message : "搜索失败。" });
    }
  }
  function stepMatch(direction: number) {
    if (!navigation.matches.length) return;
    const index = (navigation.index + direction + navigation.matches.length) % navigation.matches.length;
    updateNavigation({ index, message: "" });
    selectMatch(navigation.matches[index]);
  }
  function jump() {
    if (!dump) return;
    try {
      const address = resolveLoadedAddress(dump, navigation.jump, hexAddress);
      updateNavigation({ message: `已定位${dump.mode === "type2" ? "页" : "块"} ${address}，未执行读取。` });
      onSelect(address);
      scrollToAddress(address);
    } catch (cause) {
      updateNavigation({ message: cause instanceof Error ? cause.message : "地址定位失败。" });
    }
  }
  const unit = dump?.mode === "type2" ? "页" : "块";
  const capability = dump ? readCapability(dump.card) : null;
  const rows = dump ? [...dump.rows].sort((a, b) => a.address - b.address) : [];
  const loadedRange = rows.length
    ? `${rows[0].address}–${rows[rows.length - 1].address}${unit}`
    : "—";
  const groups = new Map<number, typeof rows>();
  for (const row of rows) {
    const group = dump?.mode === "classic" ? classicSector(row.address) : Math.floor(row.address / 4);
    if (!groups.has(group)) groups.set(group, []);
    groups.get(group)!.push(row);
  }
  return (
    <section className="work-pane read-pane" aria-labelledby="read-data-title">
      <header className="pane-heading">
        <div className="flex items-center gap-2">
          <Database className="size-4 text-primary" aria-hidden="true" />
          <h2 id="read-data-title">数据表 A <span className="font-normal text-muted-foreground">/ 扇区原始数据</span></h2>
        </div>
        <div className="flex items-center gap-2">
          {headerAction}
          <Badge variant="secondary">{rows.length} {unit}</Badge>
        </div>
      </header>
      <div className="flex flex-wrap items-center gap-2 border-b bg-muted/30 px-3 py-2 text-xs">
        <Button size="xs" variant={hexAddress ? "secondary" : "ghost"} aria-pressed={hexAddress} onClick={() => setHexAddress(!hexAddress)}>
          <Binary aria-hidden="true" />十六进制地址
        </Button>
        <Button size="xs" variant={showAscii ? "secondary" : "ghost"} aria-pressed={showAscii} onClick={() => setShowAscii(!showAscii)}>
          <Columns3 aria-hidden="true" />ASCII
        </Button>
        {dump?.mode === "classic" && <label className="flex items-center gap-1.5 text-[10px]">
          <input type="checkbox" checked={showKeys} onChange={e => setRevealFor(e.target.checked ? dump : null)} />
          显示尾块密钥字节（敏感）
        </label>}
        {dump && <span className={dump.complete ? "ml-auto text-emerald-700" : "ml-auto text-destructive"}>
          {sourceName ? "文件完整载入（非实卡验证）" : dump.complete ? "所选范围读取完成" : "读取未完成"}
        </span>}
      </div>
      {rows.length > 0 && <div className="data-navigation" aria-label="原始数据搜索与定位">
        <form className="data-search-form" onSubmit={event => { event.preventDefault(); search(); }}>
          <NativeSelect aria-label="搜索编码" value={navigation.encoding} onChange={event => updateNavigation({ encoding: event.target.value as SearchEncoding, matches: [], index: -1, message: "" })}>
            <option value="hex">HEX 字节</option><option value="text">UTF-8 文本</option>
          </NativeSelect>
          <Input aria-label="搜索原始数据" autoComplete="off" spellCheck={false} maxLength={96} placeholder={navigation.encoding === "hex" ? "例如 37 5F" : "区分大小写"} value={navigation.query} onChange={event => updateNavigation({ query: event.target.value, matches: [], index: -1, message: "" })} />
          <Button type="submit" size="xs" variant="outline"><Search aria-hidden="true" />查找</Button>
          <Button type="button" size="icon-xs" variant="ghost" aria-label="上一个匹配" disabled={!navigation.matches.length} onClick={() => stepMatch(-1)}><ChevronUp aria-hidden="true" /></Button>
          <Button type="button" size="icon-xs" variant="ghost" aria-label="下一个匹配" disabled={!navigation.matches.length} onClick={() => stepMatch(1)}><ChevronDown aria-hidden="true" /></Button>
        </form>
        <form className="data-jump-form" onSubmit={event => { event.preventDefault(); jump(); }}>
          <Input aria-label="跳转地址" autoComplete="off" spellCheck={false} maxLength={12} placeholder={hexAddress ? "HEX 地址" : "地址 / 0x…"} value={navigation.jump} onChange={event => updateNavigation({ jump: event.target.value })} />
          <Button type="submit" size="xs" variant="outline">跳转</Button>
          <p role="status" aria-label="数据定位结果">{navigation.message || (activeMatch ? `匹配 ${navigation.index + 1} / ${navigation.matches.length} · ${unit} ${activeMatch.address} · 偏移 ${activeMatch.offset}` : "仅搜索已载入数据 · 尾块密钥不参与")}</p>
        </form>
      </div>}
      {dump && <div className="dump-meta-line">
        <span>{dump.card.typeName}</span>
        <span>模式：{dump.mode === "classic" ? "DUMP / Classic" : "NFC Type 2"}</span>
        <span>已载入长度：{rows.reduce((length, row) => length + row.hex.length / 2, 0)} B</span>
        {capability && dump.mode === "classic" && <span>布局容量：{capability.units * capability.bytes} B</span>}
        <span>地址跨度：{loadedRange}</span>
      </div>}
      {sourceName && <div className="dump-source-line">离线文件：<strong>{sourceName}</strong> · UID 候选 {dump?.card.uid}</div>}
      <div className="data-scroll" ref={tableRef}>
        {dump && rows.length ? <table className="hex-table sector-hex-table">
          <caption className="sr-only">本次数据的{unit}地址、十六进制原始数据和 ASCII；偏移从 0 开始</caption>
          <thead><tr>
            <th scope="col">{unit}地址{hexAddress ? "（HEX）" : "（十进制）"}</th>
            <th scope="col">十六进制数据 <span className="font-normal">/ 偏移 00–{dump.mode === "classic" ? "0F" : "03"}</span></th>
            {showAscii && <th scope="col">ASCII</th>}
          </tr></thead>
          {[...groups].map(([group, items]) => <tbody key={group}>
            <tr className="sector-heading"><th colSpan={showAscii ? 3 : 2} scope="rowgroup">{dump.mode === "classic" ? `扇区 ${group}` : `页组 ${group}`}<span>{items.length} {unit}已载入</span></th></tr>
            {items.map(row => {
              const protectedRow = !writableAddress(dump.card, row.address);
              const isTrailer = dump.mode === "classic" && classicTrailer(row.address);
              const isManufacturer = dump.mode === "classic" && row.address === 0;
              const selectedField = fieldSelection?.address === row.address ? fieldSelection : null;
              const searchMatch = activeMatch?.address === row.address ? activeMatch : null;
              const colored = isTrailer || isManufacturer || selectedField || searchMatch;
              return <tr key={row.address} data-address={row.address} data-selected={selectedAddress === row.address} data-protected={protectedRow}>
                <th scope="row"><button type="button" aria-label={`选择${unit} ${row.address}`} aria-pressed={selectedAddress === row.address} onClick={() => onSelect(row.address)}>
                  <span className="flex items-center gap-1.5">{hexAddress ? `0x${row.address.toString(16).toUpperCase().padStart(2, "0")}` : String(row.address).padStart(3, "0")}
                    {protectedRow && <LockKeyhole className="size-3 text-amber-600" aria-label="受保护地址" />}
                  </span>
                </button></th>
                <td><span className="whitespace-nowrap select-text" aria-label={`${unit} ${row.address} 数据`}>
                  {colored ? (row.hex.match(/../g) ?? []).map((byte, index) => {
                    const keyByte = isTrailer && (index < 6 || index >= 10);
                    const highlighted = selectedField && index >= selectedField.offset && index < selectedField.offset + selectedField.length;
                    const searched = searchMatch && index >= searchMatch.offset && index < searchMatch.offset + searchMatch.length;
                    return <span key={index} className={[highlighted ? "byte-highlight" : keyByte ? "byte-key" : isTrailer ? "byte-access" : isManufacturer && index < 4 ? "byte-uid" : "", searched ? "byte-search-match" : ""].filter(Boolean).join(" ") || undefined}>{keyByte && !showKeys ? "••" : byte.toUpperCase()}{index < row.hex.length / 2 - 1 ? " " : ""}</span>;
                  }) : spacedHex(row.hex)}
                </span></td>
                {showAscii && <td className="ascii-cell"><span>{ascii(row.hex, isTrailer && !showKeys)}</span></td>}
              </tr>;
            })}
          </tbody>)}
        </table> : <div className="pane-empty">
          <Database className="size-9 text-primary/35" aria-hidden="true" />
          <p className="font-medium text-foreground">{dump ? "本次未获得原始数据" : "等待读取或导入数据"}</p>
          <p>{dump ? "当前读取结果为 0 字节，请查看上方数据获取状态和读取错误。" : <>连接设备读取，或导入本地 .dump 文件。<br />原始数据按扇区显示，不自动补齐缺失块。</>}</p>
        </div>}
      </div>
      <footer className="pane-footnote">
        {dump?.error && <p className="mb-1 text-destructive">{dump.error}</p>}
        {sourceName ? "离线文件只用于查看和分析，不作为实卡写入依据。" : dump ? `已读取 ${rows.length} ${unit}，仅代表本次所选范围。` : "原始数据保留地址，不自动填补缺失内容。"} 点击地址选择单元；尾块密钥位置默认隐藏，显示值不代表可用认证密钥。
      </footer>
    </section>
  );
}
