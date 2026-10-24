import { useRef, useState } from "react";
import { FileUp, X } from "lucide-react";
import { Button } from "@/components/ui/button";
import { parseClassicDump } from "@/lib/dump-file";
import type { CardDump } from "@/lib/cards";

export type OfflineDump = { name: string; dump: CardDump };

export function DumpImport({ onImport, onClose, activeName, disabled }: {
  onImport: (result: OfflineDump) => void;
  onClose: () => void;
  activeName?: string;
  disabled: boolean;
}) {
  const input = useRef<HTMLInputElement>(null);
  const [error, setError] = useState("");
  const [loading, setLoading] = useState(false);
  async function load(file: File) {
    if (disabled || loading) return;
    setError("");
    setLoading(true);
    try {
      if (![320, 1024, 4096].includes(file.size)) throw new Error("仅支持 320、1024 或 4096 字节的 Classic 原始 .dump 文件。");
      onImport({ name: file.name, dump: parseClassicDump(new Uint8Array(await file.arrayBuffer())) });
    } catch (cause) {
      setError(cause instanceof Error ? cause.message : "文件读取失败，请重新选择。");
    } finally {
      setLoading(false);
    }
  }
  return <section className="control-section" aria-labelledby="dump-import-title">
    <h2 className="control-heading" id="dump-import-title"><FileUp aria-hidden="true" />离线文件 / 数据查看</h2>
    <div className="space-y-2 p-3 text-[11px] leading-5">
      <p className="text-muted-foreground">支持 Classic Mini / 1K / 4K 原始 .dump。仅本地解析，无需连接设备；不上传、不作为写入原数据。</p>
      <input ref={input} type="file" accept=".dump,.bin,.mfd" aria-label="选择离线 dump 文件" className="sr-only" disabled={disabled || loading} onChange={e => {
        const file = e.target.files?.[0];
        e.target.value = "";
        if (file) void load(file);
      }} />
      <div className="flex flex-wrap gap-2">
        <Button size="sm" variant="outline" disabled={disabled || loading} onClick={() => input.current?.click()}><FileUp aria-hidden="true" />{loading ? "正在载入…" : "导入 .dump"}</Button>
        {activeName && <Button size="sm" variant="ghost" disabled={disabled || loading} onClick={() => { setError(""); onClose(); }}><X aria-hidden="true" />关闭离线文件</Button>}
      </div>
      {activeName && <p className="break-all" role="status">当前查看：{activeName}（只读）</p>}
      {error && <p role="alert" className="text-destructive">{error}</p>}
    </div>
  </section>;
}
