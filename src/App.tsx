import { useState, useSyncExternalStore } from "react";
import { invoke } from "@tauri-apps/api/core";
import {
  CheckCircle2,
  ChevronDown,
  ChevronUp,
  Cpu,
  FileSearch,
  Info,
  LoaderCircle,
  Nfc,
  TerminalSquare,
  Trash2,
} from "lucide-react";

import { ReaderPanel } from "@/components/reader-panel";
import { CardPanel } from "@/components/card-panel";
import { ReaderController } from "@/lib/reader";
import { readerApi } from "@/lib/desktop-reader";
import { Button } from "@/components/ui/button";

type AppInfo = { name: string; version: string; os: string; arch: string };

function App() {
  const [reader] = useState(() => new ReaderController(readerApi));
  const state = useSyncExternalStore(reader.subscribe, reader.getState);
  const [showDiagnostics, setShowDiagnostics] = useState(false);
  const [logCollapsed, setLogCollapsed] = useState(false);
  const [appInfo, setAppInfo] = useState<AppInfo | null>(null);
  const [isChecking, setIsChecking] = useState(false);
  const [error, setError] = useState("");
  const connection = state.snapshot?.connection;
  const active = !["idle", "scanning"].includes(state.activity);
  const activity = {
    idle: "空闲",
    scanning: "检测设备",
    connecting: "连接中",
    disconnecting: "断开中",
    findingCard: "寻卡中",
    readingCard: "读取中",
    writingCard: "写入校验中",
    checkingKeys: "字典密钥检测中",
  }[state.activity];

  async function checkBackend() {
    if (isChecking) return;
    setIsChecking(true);
    setAppInfo(null);
    setError("");
    try {
      setAppInfo(await invoke<AppInfo>("get_app_info"));
    } catch (cause) {
      setError(cause instanceof Error ? cause.message : String(cause));
    } finally {
      setIsChecking(false);
    }
  }

  return (
    <main className="desktop-workbench">
      <header className="app-header">
        <div className="flex items-center gap-2.5">
          <div className="flex size-8 items-center justify-center rounded-lg bg-primary text-primary-foreground">
            <Nfc className="size-5" aria-hidden="true" />
          </div>
          <div>
            <h1 className="text-sm font-semibold tracking-tight">
              PCR532{" "}
              <span className="ml-1 font-normal text-muted-foreground">
                NFC 工作台
              </span>
            </h1>
            <p className="text-[10px] text-muted-foreground">
              PN532 · ISO 14443A · 本地设备
            </p>
          </div>
        </div>
        <div className="ml-auto flex items-center gap-2">
          <span className="connection-pill">
            <span
              className={`status-dot ${connection && !state.scanError ? "is-connected" : ""}`}
            />
            {connection && !state.scanError
              ? `${connection.portName} 已连接`
              : "设备未连接"}
          </span>
          <Button
            variant="ghost"
            size="sm"
            aria-expanded={showDiagnostics}
            onClick={() => setShowDiagnostics(!showDiagnostics)}
          >
            <Info aria-hidden="true" />
            关于与诊断
          </Button>
        </div>
      </header>
      <nav className="app-toolbar" aria-label="工作台工具栏">
        <span className="toolbar-tab">
          <Nfc className="size-3.5" aria-hidden="true" />
          主工作台
        </span>
        <Button
          size="sm"
          variant="ghost"
          onClick={() =>
            document.getElementById("content-tab")?.click()
          }
        >
          <FileSearch aria-hidden="true" />
          查看内容与日期
        </Button>
        <span className="ml-auto hidden text-[11px] text-muted-foreground sm:inline">
          读取原数据 → 编辑预览 → 确认写入 → 读回校验
        </span>
      </nav>
      {showDiagnostics && (
        <section className="diagnostics-strip" aria-label="开发诊断">
          <div className="flex flex-wrap items-center gap-3">
            <Cpu className="size-4 text-primary" aria-hidden="true" />
            <p className="flex-1 text-xs">
              Tauri 2 桌面端 · v0.1.0。仅测试 React 与 Rust 通信，不访问硬件。
            </p>
            <Button
              size="sm"
              variant="outline"
              disabled={isChecking}
              onClick={checkBackend}
            >
              {isChecking && (
                <LoaderCircle
                  className="motion-safe:animate-spin"
                  aria-hidden="true"
                />
              )}
              测试后端通信
            </Button>
          </div>
          <p role="status" className="mt-2 text-xs">
            {appInfo
              ? `${appInfo.name} · v${appInfo.version} · ${appInfo.os} / ${appInfo.arch}`
              : error || "等待测试"}
          </p>
        </section>
      )}
      <CardPanel
        controller={reader}
        devicePanel={<ReaderPanel controller={reader} />}
      />
      <section className="session-log work-pane" data-collapsed={logCollapsed} aria-labelledby="log-title">
        <header className="pane-heading">
          <h2 id="log-title" className="flex items-center gap-2">
            <TerminalSquare
              className="size-4 text-primary"
              aria-hidden="true"
            />
            操作日志{" "}
            <span className="font-normal text-muted-foreground">
              / 当前会话
            </span>
          </h2>
          <div className="flex items-center gap-1">
          <Button variant="ghost" size="xs" aria-expanded={!logCollapsed} aria-controls="session-log-content" onClick={() => setLogCollapsed(!logCollapsed)}>
            {logCollapsed ? <ChevronUp aria-hidden="true" /> : <ChevronDown aria-hidden="true" />}
            {logCollapsed ? `展开日志（${state.logs.length}）` : "收起日志"}
          </Button>
          <Button
            variant="ghost"
            size="xs"
            disabled={!state.logs.length}
            onClick={reader.clearLogs}
          >
            <Trash2 aria-hidden="true" />
            清除日志
          </Button>
          </div>
        </header>
        {!logCollapsed && <div
          id="session-log-content"
          className="log-scroll"
          role="log"
          aria-live="polite"
          aria-relevant="additions"
        >
          {state.logs.length ? (
            [...state.logs].reverse().map((log) => (
              <p key={log.id} className={`log-entry log-${log.level}`}>
                <time className="shrink-0 text-muted-foreground">
                  {new Date(log.at).toLocaleTimeString("zh-CN", {
                    hour12: false,
                  })}
                </time>
                <span>{log.message}</span>
              </p>
            ))
          ) : (
            <p className="text-xs leading-6 text-muted-foreground">
              等待操作。日志仅保留本次会话的最近 200
              条状态，不记录密钥或卡片原始内容。
            </p>
          )}
        </div>}
      </section>
      <footer className="app-statusbar">
        <span className="flex items-center gap-1.5">
          {active ? (
            <LoaderCircle
              className="size-3 motion-safe:animate-spin"
              aria-hidden="true"
            />
          ) : (
            <CheckCircle2 className="size-3" aria-hidden="true" />
          )}
          {activity}
        </span>
        <span>
          当前卡号：
          <span className="font-mono">{state.cardState.card?.uid ?? "—"}</span>
        </span>
        <span className="ml-auto">
          {connection && !state.scanError
            ? `${connection.portName} / ${connection.baudRate} baud`
            : "未验证设备"}
        </span>
        <span className="hidden sm:inline">受限用户区读写 · v0.1.0</span>
      </footer>
    </main>
  );
}

export default App;
