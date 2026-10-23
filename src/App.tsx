import { useState } from "react";
import { invoke } from "@tauri-apps/api/core";
import { CheckCircle2, CircleAlert, Cpu, LoaderCircle, Monitor, Nfc, TerminalSquare } from "lucide-react";

import { ReaderPanel } from "@/components/reader-panel";
import { CardPanel } from "@/components/card-panel";
import { ReaderController } from "@/lib/reader";
import { readerApi } from "@/lib/desktop-reader";
import { Alert, AlertDescription, AlertTitle } from "@/components/ui/alert";
import { Badge } from "@/components/ui/badge";
import { Button } from "@/components/ui/button";
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "@/components/ui/card";
import { Separator } from "@/components/ui/separator";

type AppInfo = {
  name: string;
  version: string;
  os: string;
  arch: string;
};

function App() {
  const [reader] = useState(() => new ReaderController(readerApi));
  const [appInfo, setAppInfo] = useState<AppInfo | null>(null);
  const [isChecking, setIsChecking] = useState(false);
  const [error, setError] = useState("");

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
    <main className="mx-auto flex min-h-svh w-full max-w-5xl flex-col gap-5 px-5 py-6 sm:px-8 sm:py-8">
      <header className="flex flex-wrap items-center gap-3 sm:gap-4">
        <div className="flex size-12 shrink-0 items-center justify-center rounded-xl bg-primary text-primary-foreground shadow-sm">
          <Nfc className="size-6" aria-hidden="true" />
        </div>
        <div>
          <p className="text-[11px] font-semibold tracking-[0.18em] text-muted-foreground">PCR532 DESKTOP</p>
          <h1 className="mt-1 text-xl font-semibold tracking-tight">读卡器工作台</h1>
        </div>
        <Badge variant="outline" className="ml-auto h-auto gap-1.5 bg-card px-3 py-1.5">
          <Monitor className="size-3.5" aria-hidden="true" />
          Tauri 桌面端
        </Badge>
      </header>

      <Separator />
      <ReaderPanel controller={reader} />
      <CardPanel controller={reader} />

      <section aria-labelledby="connection-title">
        <Card className="gap-4 py-5 shadow-sm">
          <CardHeader className="gap-3 px-6 sm:px-8">
            <div className="flex flex-col items-start justify-between gap-4 sm:flex-row sm:items-center">
              <div className="space-y-2">
                <p className="flex items-center gap-2 text-xs font-medium text-muted-foreground">
                  <TerminalSquare className="size-3.5" aria-hidden="true" />
                  开发诊断
                </p>
                <CardTitle>
                  <h2 id="connection-title" className="text-base font-semibold">验证 Rust 后端</h2>
                </CardTitle>
                <CardDescription className="leading-6">只读取应用版本及系统信息，与读卡器连接状态无关。</CardDescription>
              </div>
              <Button type="button" variant="outline" disabled={isChecking} onClick={checkBackend}>
                {isChecking ? <LoaderCircle className="motion-safe:animate-spin" aria-hidden="true" /> : <Cpu aria-hidden="true" />}
                {isChecking ? "正在验证…" : "测试后端通信"}
              </Button>
            </div>
          </CardHeader>
          <CardContent className="px-6 sm:px-8">
            <div role="status" aria-live="polite" aria-atomic="true">
              <Alert role="presentation" variant={error ? "destructive" : "default"} className="bg-muted/30">
                {appInfo ? <CheckCircle2 aria-hidden="true" /> : error ? <CircleAlert aria-hidden="true" /> : <TerminalSquare aria-hidden="true" />}
                <AlertTitle>{appInfo ? "通信成功" : error ? "通信失败" : "等待测试"}</AlertTitle>
                <AlertDescription className="break-words text-xs leading-6 sm:text-sm">
                  {appInfo ? (
                    <span>{appInfo.name} · v{appInfo.version} · {appInfo.os} / {appInfo.arch}</span>
                  ) : error ? (
                    <span>{error}</span>
                  ) : (
                    <span>点击按钮，验证 React 与 Rust 的本地通信。</span>
                  )}
                </AlertDescription>
              </Alert>
            </div>
          </CardContent>
        </Card>
      </section>

      <footer className="flex flex-wrap items-center justify-between gap-2 text-xs leading-6 text-muted-foreground">
        <span>当前支持：设备连接、卡片识别、授权只读查看</span>
        <span>只读操作 · v0.1.0</span>
      </footer>
    </main>
  );
}

export default App;
