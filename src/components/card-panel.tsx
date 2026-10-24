import {
  useMemo,
  useState,
  useSyncExternalStore,
  type FormEvent,
  type ReactNode,
} from "react";
import {
  CheckCircle2,
  CircleAlert,
  Eraser,
  FileSearch,
  LoaderCircle,
  Nfc,
  PencilLine,
  ScanLine,
  ShieldCheck,
} from "lucide-react";

import { DictionaryPanel } from "@/components/dictionary-panel";
import { DataGrid, type ByteSelection } from "@/components/data-grid";
import { DataAcquisitionStatus } from "@/components/data-acquisition-status";
import { DumpImport, type OfflineDump } from "@/components/dump-import";
import { FieldAnalysisPanel } from "@/components/field-analysis-panel";
import { NfcDataPanel } from "@/components/nfc-data-panel";
import { WriteForm } from "@/components/write-form";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { NativeSelect } from "@/components/ui/native-select";
import {
  makeReadRequest,
  readCapability,
  spacedHex,
  writableAddress,
  type CardInfo,
  type WriteResult,
} from "@/lib/cards";
import { ReaderController } from "@/lib/reader";

function ReadForm({
  card,
  controller,
  disabled,
}: {
  card: CardInfo;
  controller: ReaderController;
  disabled: boolean;
}) {
  const capability = readCapability(card);
  const [start, setStart] = useState("0");
  const [count, setCount] = useState("1");
  const [keyType, setKeyType] = useState("A");
  const [key, setKey] = useState("");
  const [error, setError] = useState("");
  if (!capability)
    return (
      <p className="p-3 text-xs leading-5 text-muted-foreground">
        此类型当前仅支持识别，暂不支持数据读取。
      </p>
    );

  function read(allType2 = false) {
    if (disabled) return;
    setError("");
    try {
      const request = makeReadRequest(card, {
        start: allType2 ? "0" : start,
        count: allType2 ? "16" : count,
        keyType,
        key,
      });
      setKey("");
      void controller.readCard(request);
    } catch (cause) {
      setError(cause instanceof Error ? cause.message : String(cause));
    }
  }

  function submit(event: FormEvent<HTMLFormElement>) {
    event.preventDefault();
    read();
  }

  return (
    <form onSubmit={submit} className="space-y-3 p-3" aria-label="只读数据范围">
      <p
        id="read-range-help"
        className="text-[11px] leading-5 text-muted-foreground"
      >
        {capability.mode === "classic"
          ? `地址 0–${capability.units - 1}，16 字节/块。仅使用你提供的一个已知密钥。`
          : "型号未精确确认，保守开放前 16 页（0–15），4 字节/页。"}
        每次最多 16 {capability.unit}。
      </p>
      <fieldset disabled={disabled} className="grid min-w-0 grid-cols-2 gap-3">
        <legend className="sr-only">读取地址与认证信息</legend>
        <div className="space-y-1">
          <label htmlFor="card-start" className="text-xs">
            起始{capability.unit}地址
          </label>
          <Input
            id="card-start"
            type="number"
            inputMode="numeric"
            min={0}
            max={capability.units - 1}
            step={1}
            required
            value={start}
            onChange={(event) => setStart(event.target.value)}
            aria-describedby="read-range-help"
          />
        </div>
        <div className="space-y-1">
          <label htmlFor="card-count" className="text-xs">
            读取数量（{capability.unit}）
          </label>
          <Input
            id="card-count"
            type="number"
            inputMode="numeric"
            min={1}
            max={16}
            step={1}
            required
            value={count}
            onChange={(event) => setCount(event.target.value)}
            aria-describedby="read-range-help"
          />
        </div>
        {capability.mode === "classic" && (
          <>
            <div className="space-y-1">
              <label htmlFor="card-key-type" className="text-xs">
                认证密钥类型
              </label>
              <NativeSelect
                id="card-key-type"
                value={keyType}
                onChange={(event) => {
                  setKeyType(event.target.value);
                  setKey("");
                }}
              >
                <option value="A">Key A</option>
                <option value="B">Key B</option>
              </NativeSelect>
            </div>
            <div className="space-y-1">
              <label htmlFor="card-key" className="text-xs">
                已知密钥（6 字节）
              </label>
              <Input
                id="card-key"
                type="password"
                autoComplete="off"
                spellCheck={false}
                autoCapitalize="off"
                maxLength={12}
                minLength={12}
                pattern="[0-9a-fA-F]{12}"
                required
                value={key}
                onChange={(event) => setKey(event.target.value)}
                placeholder="12 位 HEX，无默认值"
                aria-describedby="card-key-help"
              />
            </div>
          </>
        )}
      </fieldset>
      {capability.mode === "classic" && (
        <p
          id="card-key-help"
          className="text-[11px] leading-5 text-muted-foreground"
        >
          密钥提交后清空，不写入文件或日志，不尝试其他密钥。跨扇区使用同一密钥。
        </p>
      )}
      {error && (
        <p role="alert" className="text-xs text-destructive">
          {error}
        </p>
      )}
      <Button type="submit" className="w-full" disabled={disabled}>
        <ShieldCheck aria-hidden="true" />
        读取所选范围
      </Button>
      {capability.mode === "type2" && (
        <Button
          type="button"
          variant="outline"
          className="w-full"
          disabled={disabled}
          onClick={() => read(true)}
        >
          <FileSearch aria-hidden="true" />
          读取 NFC 数据（0–15 页）
        </Button>
      )}
    </form>
  );
}

function WriteOutcome({ result }: { result: WriteResult }) {
  return (
    <section
      className="m-3 space-y-3 rounded border bg-muted/20 p-3 text-xs leading-5"
      aria-label="最近写入结果"
    >
      <div role="status" aria-live="polite">
        <p
          className={`flex items-center gap-1.5 font-semibold ${result.verified ? "text-emerald-700" : "text-destructive"}`}
        >
          {result.verified ? (
            <CheckCircle2 className="size-4" aria-hidden="true" />
          ) : (
            <CircleAlert className="size-4" aria-hidden="true" />
          )}
          {result.verified
            ? result.writeAttempted
              ? "写入已读回校验"
              : "数据一致，无需写入"
            : result.writeAttempted
              ? "写入结果未确认"
              : "已阻止写入"}
        </p>
        <p className="mt-2 break-words">
          UID {result.card.uid} · {result.mode === "type2" ? "页" : "块"}地址{" "}
          {result.address}。{result.error ?? "目标数据与读回数据一致。"}
          {result.writeAttempted &&
            !result.verified &&
            " 卡片数据可能已改变，请重新连接或读取检查，勿直接重试。"}
        </p>
      </div>
      <dl className="space-y-2">
        <div>
          <dt className="text-muted-foreground">写前数据</dt>
          <dd className="break-all font-mono select-text">
            {result.beforeHex ? spacedHex(result.beforeHex) : "未能读取"}
          </dd>
        </div>
        <div>
          <dt className="text-muted-foreground">写后读回</dt>
          <dd className="break-all font-mono select-text">
            {result.afterHex ? spacedHex(result.afterHex) : "未能读取"}
          </dd>
        </div>
      </dl>
      <p className="text-muted-foreground">
        最近一次写入记录，断开后仍保留，不代表当前卡片。点击“清除结果”移除；再次写入前须重新读取。
      </p>
    </section>
  );
}

export function CardPanel({
  controller,
  devicePanel,
}: {
  controller: ReaderController;
  devicePanel?: ReactNode;
}) {
  const state = useSyncExternalStore(controller.subscribe, controller.getState);
  const { card, dump: liveDump, error, checkedAt } = state.cardState;
  const [offline, setOffline] = useState<OfflineDump | null>(null);
  const [focusData, setFocusData] = useState(false);
  const [rightTab, setRightTab] = useState<"analysis" | "content" | "write">("analysis");
  const dump = offline?.dump ?? liveDump;
  const connected = !!state.snapshot?.connection && !state.scanError;
  const busy = !["idle", "scanning"].includes(state.activity);
  const finding = state.activity === "findingCard";
  const operating = [
    "findingCard",
    "readingCard",
    "writingCard",
    "checkingKeys",
  ].includes(state.activity);
  const [selection, setSelection] = useState<{
    dump: typeof dump;
    address: number;
    field?: ByteSelection;
  } | null>(null);
  const selectedAddress =
    selection?.dump === dump ? (selection?.address ?? null) : null;
  const selectedBytes = useMemo(() => selectedAddress == null ? null : selection?.field ?? { address: selectedAddress, offset: 0, length: 0 }, [selectedAddress, selection]);
  const selectBytes = (field: ByteSelection) => {
    setSelection({ dump, address: field.address, field });
    document.querySelector(`[aria-label="选择${dump?.mode === "type2" ? "页" : "块"} ${field.address}"]`)?.scrollIntoView?.({ block: "nearest", behavior: "smooth" });
  };
  const dumpKey = useMemo(
    () =>
      dump
        ? `${dump.card.uid}:${checkedAt}:${dump.rows.map((row) => `${row.address}:${row.hex}`).join(",")}`
        : "none",
    [dump, checkedAt],
  );
  const title = !connected
    ? "连接读卡器后开始寻卡"
    : finding
      ? "正在寻找 ISO 14443A 卡片"
      : state.activity === "readingCard"
        ? "正在读取所选范围"
        : state.activity === "checkingKeys"
          ? "正在进行字典密钥检测"
          : state.activity === "writingCard"
            ? "正在写入并读回校验"
            : error
              ? "卡片操作失败"
              : card
                ? "已识别卡片"
                : checkedAt
                  ? "感应区未发现卡片"
                  : "等待寻卡";

  return (
    <div className="workspace-grid" data-focus={focusData}>
      <aside className="workspace-controls">
        <DumpImport
          disabled={busy}
          activeName={offline?.name}
          onImport={result => { setOffline(result); setRightTab("analysis"); setSelection(null); }}
          onClose={() => { setOffline(null); setSelection(null); setRightTab("analysis"); }}
        />
        {offline && <p className="px-3 text-[11px] leading-5 text-muted-foreground">正在查看离线数据，实卡操作已禁用。关闭离线文件后恢复设备操作；文件数据不会载入写入表单。</p>}
        <fieldset disabled={!!offline} className="min-w-0 space-y-2.5 border-0 p-0">
        <legend className="sr-only">实卡设备操作</legend>
        {devicePanel}
        <section className="control-section" aria-labelledby="card-title">
          <h2 id="card-title" className="control-heading">
            <Nfc aria-hidden="true" />
            卡片识别{" "}
            <span className="ml-auto text-[10px] font-normal text-muted-foreground">
              ISO 14443A
            </span>
          </h2>
          <div className="space-y-3 p-3">
            <div role="status" aria-live="polite" className="text-xs leading-5">
              <p
                className={`flex items-center gap-1.5 font-medium ${error ? "text-destructive" : ""}`}
              >
                {operating ? (
                  <LoaderCircle
                    className="size-3.5 motion-safe:animate-spin"
                    aria-hidden="true"
                  />
                ) : (
                  <ScanLine className="size-3.5" aria-hidden="true" />
                )}
                {title}
              </p>
              <p className="mt-1 break-words text-muted-foreground">
                {operating
                  ? "保持卡片放在感应区，请勿移开。"
                  : (error ?? "仅在点击时寻卡。请操作自有或已获授权的卡片。")}
              </p>
            </div>
            <div className="flex gap-2">
              <Button
                className="flex-1"
                variant="outline"
                disabled={!connected || busy}
                onClick={() => {
                  void controller.findCard();
                }}
              >
                <ScanLine aria-hidden="true" />
                {finding ? "正在寻卡…" : "寻卡 / 重新识别"}
              </Button>
              <Button
                size="icon"
                variant="outline"
                aria-label="清除结果"
                disabled={
                  busy || (!card && !error && !checkedAt && !state.lastWrite)
                }
                onClick={controller.clearCard}
              >
                <Eraser aria-hidden="true" />
              </Button>
            </div>
            {connected && card && (
              <dl className="identity-grid">
                <dt>UID · {card.uidLength} B</dt>
                <dd className="font-mono select-text">{spacedHex(card.uid)}</dd>
                <dt>ATQA / SAK</dt>
                <dd className="font-mono">
                  {card.atqa} / {card.sak}
                </dd>
                <dt>卡片类型</dt>
                <dd>{card.typeName}</dd>
              </dl>
            )}
          </div>
        </section>
        {connected && card && (
          <section className="control-section" aria-labelledby="read-title">
            <h2 id="read-title" className="control-heading">
              <ShieldCheck aria-hidden="true" />
              读取范围与认证
            </h2>
            <ReadForm
              key={card.uid}
              card={card}
              controller={controller}
              disabled={busy}
            />
          </section>
        )}
        <DictionaryPanel key={card?.uid ?? "no-card"} controller={controller} />
        </fieldset>
        <div className="px-2 py-1 text-[11px] leading-5 text-muted-foreground">
          <ShieldCheck className="mr-1 inline size-3" aria-hidden="true" />
          禁止修改
          UID、密钥、访问条件、锁定位和配置。卡片类型仅为初步识别，不能验证真伪。
        </div>
      </aside>
      <div className="workspace-data">
        <DataAcquisitionStatus state={state} dump={dump} sourceName={offline?.name} />
        <div className="data-panes">
          <DataGrid
            dump={dump}
            headerAction={<Button size="xs" variant="ghost" aria-pressed={focusData} onClick={() => setFocusData(!focusData)}>{focusData ? "展开操作面板" : "专注数据"}</Button>}
            selectedAddress={selectedAddress}
            onSelect={(address) => setSelection({ dump, address })}
            onSelectBytes={selectBytes}
            sourceName={offline?.name}
            fieldSelection={selection?.dump === dump ? selection?.field : null}
          />
          <div className="work-pane right-data-pane">
            <div className="data-view-tabs" role="tablist" aria-label="数据查看方式">
              <Button id="analysis-tab" role="tab" aria-selected={rightTab === "analysis"} aria-controls="analysis-tabpanel" size="sm" variant={rightTab === "analysis" ? "secondary" : "ghost"} onClick={() => setRightTab("analysis")}>数据分析</Button>
              <Button id="content-tab" role="tab" aria-selected={rightTab === "content"} aria-controls="content-tabpanel" size="sm" variant={rightTab === "content" ? "secondary" : "ghost"} onClick={() => setRightTab("content")}>内容与日期</Button>
              <Button id="write-tab" role="tab" aria-selected={rightTab === "write"} aria-controls="write-tabpanel" size="sm" variant={rightTab === "write" ? "secondary" : "ghost"} disabled={!!offline} onClick={() => setRightTab("write")}>用户区写入</Button>
              <span className="ml-auto text-[10px] text-muted-foreground">{offline ? "离线文件 · 只读" : "当前读取结果"}</span>
            </div>
            {rightTab === "analysis" ? <div id="analysis-tabpanel" role="tabpanel" aria-labelledby="analysis-tab" className="right-tab-content">
              <FieldAnalysisPanel dump={dump} sourceName={offline?.name} selection={selectedBytes} onSelect={selectBytes} />
            </div> : rightTab === "content" ? <div id="content-tabpanel" role="tabpanel" aria-labelledby="content-tab" className="right-tab-content">
              <NfcDataPanel dump={dump} showInspector={false} />
            </div> : !offline && <div id="write-tabpanel" role="tabpanel" aria-labelledby="write-tab" className="right-tab-content">
          <section
            className="write-pane"
            aria-labelledby="write-data-title"
          >
            <header className="pane-heading">
              <div className="flex items-center gap-2">
                <PencilLine
                  className="size-4 text-primary"
                  aria-hidden="true"
                />
                <h2 id="write-data-title">
                  数据表 B{" "}
                  <span className="font-normal text-muted-foreground">
                    / 待写数据
                  </span>
                </h2>
              </div>
              <span className="text-[10px] text-amber-700">单块 / 单页</span>
            </header>
            <div className="write-scroll">
              {selectedAddress != null &&
                card &&
                !writableAddress(card, selectedAddress) && (
                  <p className="rounded border border-amber-600/20 bg-amber-50 p-2 text-[11px] leading-5 text-amber-900">
                    所选地址 {selectedAddress}{" "}
                    受保护，禁止写入。下方仅列出本次读取中可写的用户数据地址。
                  </p>
                )}
              {connected && card ? (
                <WriteForm
                  key={`${dumpKey}:${selectedAddress}`}
                  card={card}
                  dump={dump}
                  controller={controller}
                  disabled={busy}
                  selectedAddress={selectedAddress}
                />
              ) : (
                <div className="pane-empty">
                  <PencilLine
                    className="size-9 text-primary/35"
                    aria-hidden="true"
                  />
                  <p className="font-medium text-foreground">准备用户区数据</p>
                  <p>
                    先识别卡片并读取原数据，
                    <br />
                    再编辑、预览并确认写入。
                  </p>
                </div>
              )}
              {state.lastWrite && <WriteOutcome result={state.lastWrite} />}
            </div>
            <footer className="pane-footnote">
              写前核对 UID 与原数据，写后读回校验。异常不会自动重试或回滚；UID
              相同也不保证为同一张物理卡。
            </footer>
          </section>
            </div>}
          </div>
        </div>
      </div>
    </div>
  );
}
