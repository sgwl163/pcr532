import { useEffect, useSyncExternalStore } from "react";
import { CheckCircle2, CircleAlert, LoaderCircle, PlugZap, RefreshCw, Unplug, Usb } from "lucide-react";

import { Alert, AlertDescription, AlertTitle } from "@/components/ui/alert";
import { Badge } from "@/components/ui/badge";
import { Button } from "@/components/ui/button";
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "@/components/ui/card";
import { NativeSelect } from "@/components/ui/native-select";
import { BAUD_RATES, ReaderController, readerStatus } from "@/lib/reader";

export function ReaderPanel({ controller }: { controller: ReaderController }) {
  const state = useSyncExternalStore(controller.subscribe, controller.getState);
  const status = readerStatus(state);
  const ports = state.snapshot?.ports ?? [];
  const connection = state.snapshot?.connection;
  const selected = ports.find((port) => port.portName === state.selectedPort);
  const busy = state.activity !== "idle";
  const acting = !["idle", "scanning"].includes(state.activity);
  const verified = status.kind === "success";
  const selectionDisabled = !!connection || acting || !!state.scanError;
  const badgeLabel = verified ? "已验证连接" : status.kind === "error" ? "设备异常"
    : acting ? "处理中" : !state.snapshot ? "检测中" : ports.length ? "等待验证" : "未发现串口";

  useEffect(() => {
    void controller.refresh();
    const timer = window.setInterval(() => { void controller.refresh(); }, 3_000);
    const onFocus = () => { void controller.refresh(); };
    window.addEventListener("focus", onFocus);
    return () => {
      window.clearInterval(timer);
      window.removeEventListener("focus", onFocus);
    };
  }, [controller]);

  return (
    <section aria-labelledby="reader-title">
      <Card className="gap-5 py-6 shadow-sm">
        <CardHeader className="gap-3 px-6 sm:px-8">
          <div className="flex flex-wrap items-start justify-between gap-3">
            <div className="space-y-2">
              <p className="flex items-center gap-2 text-xs font-medium text-muted-foreground">
                <Usb className="size-3.5" aria-hidden="true" />
                设备连接
              </p>
              <CardTitle>
                <h2 id="reader-title" className="text-lg font-semibold">PN532 读卡器</h2>
              </CardTitle>
            </div>
            <Badge variant="outline" className={verified ? "border-emerald-600/25 bg-emerald-500/10 text-emerald-700" : ""}>
              {badgeLabel}
            </Badge>
          </div>
          <CardDescription className="leading-6">
            启动或重新插入时，自动验证唯一的候选设备；有多个候选设备时请手动选择串口连接。
          </CardDescription>
        </CardHeader>
        <CardContent className="space-y-4 px-6 sm:px-8">
          <div role="status" aria-live="polite" aria-atomic="true">
            <Alert
              role="presentation"
              variant={status.kind === "error" ? "destructive" : "default"}
              className={verified ? "border-emerald-600/25 bg-emerald-500/5" : "bg-muted/30"}
            >
              {acting || (!state.snapshot && !state.scanError) ? (
                <LoaderCircle className="motion-safe:animate-spin" aria-hidden="true" />
              ) : verified ? (
                <CheckCircle2 className="text-emerald-600" aria-hidden="true" />
              ) : status.kind === "error" ? (
                <CircleAlert aria-hidden="true" />
              ) : (
                <Usb aria-hidden="true" />
              )}
              <AlertTitle>{status.title}</AlertTitle>
              <AlertDescription className="break-words text-sm leading-6">{status.detail}</AlertDescription>
            </Alert>
          </div>

          <div className="grid gap-4 sm:grid-cols-[minmax(0,1fr)_10rem]">
            <div className="min-w-0 space-y-2">
              <label htmlFor="reader-port" className="text-sm font-medium">串口</label>
              <NativeSelect
                id="reader-port"
                value={state.selectedPort}
                disabled={selectionDisabled || !ports.length}
                onChange={(event) => controller.selectPort(event.target.value)}
              >
                <option value="">{ports.length ? "请选择读卡器对应的串口" : "暂无可用串口"}</option>
                {ports.map((port) => (
                  <option key={port.portName} value={port.portName}>
                    {port.label}{verified && connection?.portName === port.portName ? " · 已连接" : port.isCandidate ? " · 候选设备" : ""}
                  </option>
                ))}
              </NativeSelect>
            </div>
            <div className="space-y-2">
              <label htmlFor="reader-baud" className="text-sm font-medium">波特率</label>
              <NativeSelect
                id="reader-baud"
                value={connection?.baudRate ?? state.baudRate}
                disabled={selectionDisabled}
                onChange={(event) => controller.selectBaud(Number(event.target.value))}
              >
                {BAUD_RATES.map((baud) => <option key={baud} value={baud}>{baud}</option>)}
              </NativeSelect>
            </div>
          </div>

          {selected && (
            <p className="break-words text-xs leading-6 text-muted-foreground">
              {selected.manufacturer ? `${selected.manufacturer} · ` : ""}
              {selected.vid && selected.pid ? `USB ${selected.vid}:${selected.pid} · ` : ""}
              {verified ? "固件验证通过，串口通信正常。" : "Windows 已识别此串口；连接仍需验证 PN532 固件响应。"}
            </p>
          )}

          <div className="flex flex-wrap items-center gap-2">
            {connection ? (
              <Button type="button" variant="outline" size="lg" disabled={acting} onClick={() => { void controller.disconnect(); }}>
                {state.activity === "disconnecting" ? <LoaderCircle className="motion-safe:animate-spin" aria-hidden="true" /> : <Unplug aria-hidden="true" />}
                {state.activity === "disconnecting" ? "正在断开…" : "断开连接"}
              </Button>
            ) : (
              <Button
                type="button"
                size="lg"
                disabled={!state.selectedPort || !!state.scanError || acting}
                onClick={() => { void controller.connect(); }}
              >
                {state.activity === "connecting" ? <LoaderCircle className="motion-safe:animate-spin" aria-hidden="true" /> : <PlugZap aria-hidden="true" />}
                {state.activity === "connecting" ? "正在验证…" : "连接并验证"}
              </Button>
            )}
            <Button type="button" size="lg" variant="outline" disabled={busy} onClick={() => { void controller.refresh(); }}>
              <RefreshCw className={state.activity === "scanning" ? "motion-safe:animate-spin" : ""} aria-hidden="true" />
              {state.activity === "scanning" ? "正在检测…" : "刷新设备"}
            </Button>
            {state.checkedAt && (
              <span className="text-xs text-muted-foreground">
                每 3 秒检测 · {new Date(state.checkedAt).toLocaleTimeString("zh-CN", { hour12: false })}
              </span>
            )}
          </div>

          <details className="rounded-lg border bg-muted/20 px-3 py-2 text-xs leading-6 text-muted-foreground">
            <summary className="cursor-pointer font-medium text-foreground">连接与驱动说明</summary>
            <div className="mt-2 space-y-1">
              <p>CH340/CH341 型号使用 WCH 的 CH341SER 串口驱动；设备管理器正常显示 COM 端口时，通常已安装对应驱动。</p>
              <p>端口已出现但连接失败，请先关闭原读卡软件，再检查波特率和 UART 模式；无需重复安装驱动。</p>
              <p>自动连接每次插入只尝试一次，失败后可手动重试。手动断开后保持断开，重新插入才会再次自动验证。</p>
            </div>
          </details>
          <p className="text-xs leading-6 text-muted-foreground">
            连接仅初始化芯片并查询固件，不读取或写入卡片。默认波特率为 115200。
          </p>
        </CardContent>
      </Card>
    </section>
  );
}
