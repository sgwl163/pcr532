import { useState, useSyncExternalStore, type FormEvent } from "react";
import { CheckCircle2, CircleAlert, Eraser, LoaderCircle, Nfc, ScanLine, ShieldCheck } from "lucide-react";

import { Alert, AlertDescription, AlertTitle } from "@/components/ui/alert";
import { Badge } from "@/components/ui/badge";
import { Button } from "@/components/ui/button";
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { NativeSelect } from "@/components/ui/native-select";
import { makeReadRequest, readCapability, spacedHex, type CardInfo } from "@/lib/cards";
import { ReaderController } from "@/lib/reader";

function ReadForm({ card, controller, disabled }: { card: CardInfo; controller: ReaderController; disabled: boolean }) {
  const capability = readCapability(card);
  const [start, setStart] = useState("0");
  const [count, setCount] = useState("1");
  const [keyType, setKeyType] = useState("A");
  const [key, setKey] = useState("");
  const [error, setError] = useState("");
  if (!capability) {
    return <p className="rounded-lg border bg-muted/20 px-4 py-3 text-sm leading-6 text-muted-foreground">此类型当前仅支持识别，暂不支持数据读取。</p>;
  }

  function submit(event: FormEvent<HTMLFormElement>) {
    event.preventDefault();
    if (disabled) return;
    setError("");
    try {
      const request = makeReadRequest(card, { start, count, keyType, key });
      setKey("");
      void controller.readCard(request);
    } catch (cause) {
      setError(cause instanceof Error ? cause.message : String(cause));
    }
  }

  return (
    <form onSubmit={submit} className="space-y-4 rounded-lg border bg-muted/10 p-4" aria-label="只读数据范围">
      <div className="space-y-1">
        <h3 className="flex items-center gap-2 text-sm font-semibold"><ShieldCheck className="size-4" aria-hidden="true" />只读数据查看</h3>
        <p id="read-range-help" className="text-xs leading-6 text-muted-foreground">
          {capability.mode === "classic" ? `地址 0–${capability.units - 1}，每块 16 字节。仅使用你提供的一个已知密钥认证。` : "型号尚未精确确认，仅开放前 16 页（0–15），每页 4 字节。"}
          每次最多读取 16 {capability.unit}。
        </p>
      </div>
      <fieldset disabled={disabled} className="grid min-w-0 gap-4 sm:grid-cols-2">
        <legend className="sr-only">读取地址与认证信息</legend>
        <div className="space-y-2">
          <label htmlFor="card-start" className="text-sm font-medium">起始{capability.unit}地址</label>
          <Input id="card-start" type="number" inputMode="numeric" min={0} max={capability.units - 1} step={1} required value={start} onChange={(event) => setStart(event.target.value)} aria-describedby="read-range-help" />
        </div>
        <div className="space-y-2">
          <label htmlFor="card-count" className="text-sm font-medium">读取数量（{capability.unit}）</label>
          <Input id="card-count" type="number" inputMode="numeric" min={1} max={16} step={1} required value={count} onChange={(event) => setCount(event.target.value)} aria-describedby="read-range-help" />
        </div>
        {capability.mode === "classic" && (
          <>
            <div className="space-y-2">
              <label htmlFor="card-key-type" className="text-sm font-medium">认证密钥类型</label>
              <NativeSelect id="card-key-type" value={keyType} onChange={(event) => { setKeyType(event.target.value); setKey(""); }}>
                <option value="A">Key A</option><option value="B">Key B</option>
              </NativeSelect>
            </div>
            <div className="space-y-2">
              <label htmlFor="card-key" className="text-sm font-medium">已知密钥（6 字节）</label>
              <Input id="card-key" type="password" autoComplete="off" spellCheck={false} autoCapitalize="off" maxLength={12} minLength={12} pattern="[0-9a-fA-F]{12}" required value={key} onChange={(event) => setKey(event.target.value)} placeholder="12 位十六进制，无默认值" aria-describedby="card-key-help" />
            </div>
          </>
        )}
      </fieldset>
      {capability.mode === "classic" && <p id="card-key-help" className="text-xs leading-6 text-muted-foreground">密钥仅用于当前请求；提交后清空输入，不写入配置文件或日志，也不会尝试其他密钥。跨扇区读取使用同一密钥。</p>}
      {error && <p role="alert" className="text-sm text-destructive">{error}</p>}
      <div className="flex flex-wrap items-center gap-3">
        <Button type="submit" disabled={disabled}><ShieldCheck aria-hidden="true" />读取所选范围</Button>
        <span className="text-xs text-muted-foreground">请仅操作自有或已获授权的卡片。</span>
      </div>
    </form>
  );
}

export function CardPanel({ controller }: { controller: ReaderController }) {
  const state = useSyncExternalStore(controller.subscribe, controller.getState);
  const { card, dump, error, checkedAt } = state.cardState;
  const connected = !!state.snapshot?.connection && !state.scanError;
  const busy = !["idle", "scanning"].includes(state.activity);
  const finding = state.activity === "findingCard";
  const reading = state.activity === "readingCard";
  const unit = dump?.mode === "type2" ? "页" : "块";
  const title = !connected ? "连接读卡器后开始寻卡" : finding ? "正在寻找 ISO 14443A 卡片" : reading ? "正在读取所选范围"
    : error ? "卡片操作失败" : card ? "已识别卡片" : checkedAt ? "感应区未发现卡片" : "等待寻卡";
  const detail = !connected ? "请先在上方连接并验证 PN532 读卡器。" : finding || reading ? "请保持卡片放在感应区，操作结束前请勿移开。"
    : error ?? (card ? "以下为最近一次识别结果；读取前会重新核对 UID。" : checkedAt ? "请放稳卡片后重新寻卡。未发现卡片属于正常结果。" : "将卡片放在感应区，点击“寻卡 / 重新识别”。仅在点击时寻卡，不自动轮询卡片。");

  return (
    <section aria-labelledby="card-title">
      <Card className="gap-5 py-6 shadow-sm">
        <CardHeader className="gap-3 px-6 sm:px-8">
          <div className="flex flex-wrap items-center justify-between gap-3">
            <div className="space-y-2">
              <p className="flex items-center gap-2 text-xs font-medium text-muted-foreground"><Nfc className="size-3.5" aria-hidden="true" />卡片操作</p>
              <CardTitle><h2 id="card-title" className="text-lg font-semibold">识别与只读查看</h2></CardTitle>
            </div>
            <Badge variant="outline">ISO 14443A · 只读</Badge>
          </div>
          <CardDescription className="leading-6">显示 UID、ATQA、SAK 和初步类型。卡片类型由协议响应判断，不用于验证真伪。</CardDescription>
        </CardHeader>
        <CardContent className="space-y-4 px-6 sm:px-8">
          <div role="status" aria-live="polite" aria-atomic="true">
            <Alert role="presentation" variant={error ? "destructive" : "default"} className="bg-muted/30">
              {finding || reading ? <LoaderCircle className="motion-safe:animate-spin" aria-hidden="true" /> : error ? <CircleAlert aria-hidden="true" /> : card ? <CheckCircle2 aria-hidden="true" /> : <ScanLine aria-hidden="true" />}
              <AlertTitle>{title}</AlertTitle>
              <AlertDescription className="break-words text-sm leading-6">{detail}</AlertDescription>
            </Alert>
          </div>
          <div className="flex flex-wrap items-center gap-2">
            <Button type="button" disabled={!connected || busy} onClick={() => { void controller.findCard(); }}>
              {finding ? <LoaderCircle className="motion-safe:animate-spin" aria-hidden="true" /> : <ScanLine aria-hidden="true" />}
              {finding ? "正在寻卡…" : "寻卡 / 重新识别"}
            </Button>
            <Button type="button" variant="outline" disabled={busy || (!card && !error && !checkedAt)} onClick={() => controller.clearCard()}><Eraser aria-hidden="true" />清除结果</Button>
            {checkedAt && <span className="text-xs text-muted-foreground">最近操作：{new Date(checkedAt).toLocaleTimeString("zh-CN", { hour12: false })}</span>}
          </div>
          {connected && card && (
            <>
              <dl className="grid gap-4 rounded-lg border p-4 text-sm sm:grid-cols-2 lg:grid-cols-4">
                <div className="space-y-1 sm:col-span-2"><dt className="text-xs text-muted-foreground">UID（{card.uidLength} 字节）</dt><dd className="break-all font-mono font-medium select-text">{spacedHex(card.uid)}</dd></div>
                <div className="space-y-1"><dt className="text-xs text-muted-foreground">ATQA（应答类型）</dt><dd className="font-mono select-text">{spacedHex(card.atqa)}</dd></div>
                <div className="space-y-1"><dt className="text-xs text-muted-foreground">SAK（选择应答）</dt><dd className="font-mono select-text">{card.sak}</dd></div>
                <div className="space-y-1 sm:col-span-2 lg:col-span-4"><dt className="text-xs text-muted-foreground">初步卡片类型</dt><dd>{card.typeName}</dd></div>
              </dl>
              <ReadForm key={card.uid} card={card} controller={controller} disabled={busy} />
            </>
          )}
          {dump && (
            <div className="space-y-3" aria-label="读取结果">
              <div role="status" aria-live="polite">
                <Alert role="presentation" variant={dump.complete ? "default" : "destructive"}>
                  {dump.complete ? <CheckCircle2 aria-hidden="true" /> : <CircleAlert aria-hidden="true" />}
                  <AlertTitle>{dump.complete ? "所选范围读取完成" : "读取未完成"}</AlertTitle>
                  <AlertDescription className="break-words text-sm leading-6">已读取 {dump.rows.length} {unit}。{dump.error ?? "以下仅为本次所选范围，不代表整张卡片。"}</AlertDescription>
                </Alert>
              </div>
              {dump.rows.length > 0 && (
                <div className="overflow-x-auto rounded-lg border">
                  <table className="w-full text-left text-sm">
                    <caption className="sr-only">本次读取的{unit}地址和十六进制原始数据</caption>
                    <thead className="bg-muted/40 text-xs text-muted-foreground"><tr><th scope="col" className="px-4 py-3 font-medium">{unit}地址（十进制）</th><th scope="col" className="px-4 py-3 font-medium">十六进制数据</th></tr></thead>
                    <tbody>{dump.rows.map((row) => <tr key={row.address} className="border-t"><th scope="row" className="px-4 py-3 font-mono font-normal">{row.address}</th><td className="px-4 py-3 font-mono text-xs whitespace-nowrap select-text">{spacedHex(row.hex)}</td></tr>)}</tbody>
                  </table>
                </div>
              )}
              <p className="text-xs leading-6 text-muted-foreground">数据仅显示在当前窗口，清除结果或断开连接后移除。Classic 扇区尾块可能按卡片访问规则隐藏密钥字节，显示值不代表可用密钥。</p>
            </div>
          )}
          <p className="text-xs leading-6 text-muted-foreground">本功能不写卡，不修改 UID、访问条件或卡片配置。换卡后请重新识别；UID 相同也不代表是同一张物理卡片。</p>
        </CardContent>
      </Card>
    </section>
  );
}
