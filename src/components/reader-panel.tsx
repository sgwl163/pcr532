import { useEffect, useSyncExternalStore } from "react";
import {
  CheckCircle2,
  CircleAlert,
  LoaderCircle,
  PlugZap,
  RefreshCw,
  Unplug,
  Usb,
} from "lucide-react";

import { Button } from "@/components/ui/button";
import { NativeSelect } from "@/components/ui/native-select";
import { BAUD_RATES, ReaderController, readerStatus } from "@/lib/reader";

export function ReaderPanel({ controller }: { controller: ReaderController }) {
  const state = useSyncExternalStore(controller.subscribe, controller.getState);
  const status = readerStatus(state);
  const ports = state.snapshot?.ports ?? [];
  const connection = state.snapshot?.connection;
  const busy = state.activity !== "idle";
  const acting = !["idle", "scanning"].includes(state.activity);
  const verified = status.kind === "success";
  const selectionDisabled = !!connection || acting || !!state.scanError;

  useEffect(() => {
    void controller.refresh();
    const timer = window.setInterval(() => {
      void controller.refresh();
    }, 3_000);
    const onFocus = () => {
      void controller.refresh();
    };
    window.addEventListener("focus", onFocus);
    return () => {
      window.clearInterval(timer);
      window.removeEventListener("focus", onFocus);
    };
  }, [controller]);

  return (
    <section className="control-section" aria-labelledby="reader-title">
      <h2 id="reader-title" className="control-heading">
        <Usb aria-hidden="true" />
        设备连接{" "}
        <span
          className={`ml-auto status-dot ${verified ? "is-connected" : ""}`}
          aria-label={verified ? "已验证连接" : "未验证连接"}
        />
      </h2>
      <div className="space-y-3 p-3">
        <div className="grid grid-cols-[1fr_100px] gap-2">
          <div className="min-w-0 space-y-1">
            <label
              htmlFor="reader-port"
              className="text-xs text-muted-foreground"
            >
              串口
            </label>
            <NativeSelect
              id="reader-port"
              value={state.selectedPort}
              disabled={selectionDisabled || !ports.length}
              onChange={(event) => controller.selectPort(event.target.value)}
            >
              <option value="">{ports.length ? "选择串口" : "暂无串口"}</option>
              {ports.map((port) => (
                <option key={port.portName} value={port.portName}>
                  {port.label}
                  {connection?.portName === port.portName
                    ? " · 已连接"
                    : port.isCandidate
                      ? " · 候选"
                      : ""}
                </option>
              ))}
            </NativeSelect>
          </div>
          <div className="space-y-1">
            <label
              htmlFor="reader-baud"
              className="text-xs text-muted-foreground"
            >
              波特率
            </label>
            <NativeSelect
              id="reader-baud"
              value={connection?.baudRate ?? state.baudRate}
              disabled={selectionDisabled}
              onChange={(event) =>
                controller.selectBaud(Number(event.target.value))
              }
            >
              {BAUD_RATES.map((baud) => (
                <option key={baud} value={baud}>
                  {baud}
                </option>
              ))}
            </NativeSelect>
          </div>
        </div>
        <div className="grid grid-cols-[1fr_auto] gap-2">
          {connection ? (
            <Button
              variant="outline"
              disabled={acting}
              onClick={() => {
                void controller.disconnect();
              }}
            >
              <Unplug aria-hidden="true" />
              {state.activity === "disconnecting" ? "正在断开…" : "断开连接"}
            </Button>
          ) : (
            <Button
              disabled={!state.selectedPort || !!state.scanError || acting}
              onClick={() => {
                void controller.connect();
              }}
            >
              {state.activity === "connecting" ? (
                <LoaderCircle className="animate-spin" aria-hidden="true" />
              ) : (
                <PlugZap aria-hidden="true" />
              )}
              {state.activity === "connecting" ? "正在验证…" : "连接并验证"}
            </Button>
          )}
          <Button
            variant="outline"
            size="icon"
            aria-label={
              state.activity === "scanning" ? "正在检测…" : "刷新设备"
            }
            disabled={busy}
            onClick={() => {
              void controller.refresh();
            }}
          >
            <RefreshCw
              className={
                state.activity === "scanning" ? "motion-safe:animate-spin" : ""
              }
              aria-hidden="true"
            />
          </Button>
        </div>
        <div
          role="status"
          aria-live="polite"
          className={`rounded border px-2.5 py-2 text-xs leading-5 ${status.kind === "error" ? "border-destructive/30 bg-destructive/5 text-destructive" : verified ? "border-emerald-600/20 bg-emerald-50 text-emerald-800" : "bg-muted/40 text-muted-foreground"}`}
        >
          <p className="flex items-center gap-1.5 font-medium">
            {verified ? (
              <CheckCircle2 className="size-3.5" aria-hidden="true" />
            ) : status.kind === "error" ? (
              <CircleAlert className="size-3.5" aria-hidden="true" />
            ) : (
              <Usb className="size-3.5" aria-hidden="true" />
            )}
            {status.title}
          </p>
          <p className="mt-1 break-words">{status.detail}</p>
        </div>
        <details className="text-[11px] leading-5 text-muted-foreground">
          <summary className="cursor-pointer">连接与驱动说明</summary>
          <p className="mt-1">
            每 3
            秒检测设备。仅对唯一候选设备自动验证一次；手动断开后保持断开。连接只初始化芯片和查询固件，不读写卡片。
          </p>
          <p>
            CH340/CH341 使用 WCH CH341SER 驱动。已有 COM
            端口通常无需重装；连接失败请检查串口占用、波特率和 UART 模式。
          </p>
        </details>
      </div>
    </section>
  );
}
