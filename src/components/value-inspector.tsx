import { useMemo, useState } from "react";
import { Binary } from "lucide-react";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { NativeSelect } from "@/components/ui/native-select";
import { decodeNfcValue, type ValueEncoding } from "@/lib/nfc-values";
import { spacedHex, type CardDump } from "@/lib/cards";
import type { ByteSelection } from "@/lib/data-navigation";
import { classicTrailer } from "@/lib/classic-layout";

export function ValueInspector({ dump, selection, onSelect }: {
  dump: CardDump;
  selection?: ByteSelection | null;
  onSelect?: (selection: ByteSelection) => void;
}) {
  const initial = { dump, selection, address: String(selection?.address ?? dump.rows[0]?.address ?? ""), offset: String(selection?.offset ?? 0), encoding: "bcd-date" as ValueEncoding };
  const [settings, setSettings] = useState(initial);
  // New captures reset the encoding; new selections retain it but follow their byte location.
  const current = settings.dump !== dump ? initial : settings.selection !== selection
    ? { ...settings, selection, address: String(selection?.address ?? settings.address), offset: String(selection?.offset ?? 0) }
    : settings;
  const { address, offset, encoding } = current;
  const update = (patch: Partial<typeof current>) => setSettings({ ...current, ...patch });
  const result = useMemo(() => {
    const row = dump.rows.find((item) => item.address === Number(address));
    if (!row) return null;
    try {
      if (!/^\d+$/.test(offset)) throw new Error("偏移须为非负整数。");
      const trailer = dump.mode === "classic" && classicTrailer(row.address);
      if (trailer && (Number(offset) < 6 || Number(offset) >= 10))
        throw new Error("尾块密钥位置不参与人工解释；仅允许偏移 6–9 的访问数据。");
      return {
        decoded: decodeNfcValue(trailer ? row.hex.slice(0, 20) : row.hex, encoding, Number(offset)),
        error: null,
      };
    } catch (cause) {
      return {
        decoded: null,
        error: cause instanceof Error ? cause.message : String(cause),
      };
    }
  }, [dump, address, offset, encoding]);
  if (!dump.rows.length) return null;
  return (
    <details className="mt-3 rounded border bg-muted/20 p-2.5 text-xs">
      <summary className="cursor-pointer font-medium">
        <Binary className="mr-1.5 inline size-3.5" aria-hidden="true" />
        按指定编码查看字节（人工解释）
      </summary>
      <div className="mt-3 space-y-2">
        <p className="text-[11px] leading-5 text-muted-foreground">
          已知厂商编码时可在这里选择解释方式。显示日期只代表所选编码下的计算结果，不会自动认定为卡片有效期。只使用单个块或页内的字节。
        </p>
        <div className="grid grid-cols-3 gap-2">
          <label className="space-y-1">
            <span>{dump.mode === "type2" ? "页" : "块"}地址</span>
            <NativeSelect
              aria-label="解释数据地址"
              value={address}
              onChange={(event) => update({ address: event.target.value, offset: "0" })}
            >
              {dump.rows.map((row) => (
                <option key={row.address} value={row.address}>
                  {row.address}
                </option>
              ))}
            </NativeSelect>
          </label>
          <label className="space-y-1">
            <span>字节偏移</span>
            <Input
              aria-label="解释字节偏移"
              type="number"
              min={0}
              step={1}
              value={offset}
              onChange={(event) => update({ offset: event.target.value })}
            />
          </label>
          <label className="space-y-1">
            <span>编码</span>
            <NativeSelect
              aria-label="数据解释编码"
              value={encoding}
              onChange={(event) =>
                update({ encoding: event.target.value as ValueEncoding })
              }
            >
              <option value="bcd-date">BCD YYYYMMDD</option>
              <option value="packed-date-2000-be">压缩日期 · 2000 年基准 · 大端</option>
              <option value="unix-seconds-le">Unix 秒 · 小端</option>
              <option value="unix-seconds-be">Unix 秒 · 大端</option>
              <option value="utf8">UTF-8 文本</option>
            </NativeSelect>
          </label>
        </div>
        <div
          aria-live="polite"
          className="rounded border bg-background p-2 text-xs leading-5"
        >
          {result?.decoded ? (
            <>
              <p className="break-words font-mono select-text">
                {result.decoded.value}
              </p>
              <p className="mt-1 text-[10px] text-muted-foreground">
                来源{dump.mode === "type2" ? "页" : "块"} {address} · 偏移{" "}
                {offset} · {result.decoded.bytes} 字节 ·{" "}
                {spacedHex(result.decoded.raw)}
              </p>
              {onSelect && <Button type="button" size="xs" variant="outline" className="mt-2" onClick={() => onSelect({ address: Number(address), offset: Number(offset), length: result.decoded!.bytes })}>定位解释字节</Button>}
            </>
          ) : (
            <p className="text-muted-foreground">
              {result?.error ?? "请先选择数据地址。"}
            </p>
          )}
        </div>
      </div>
    </details>
  );
}
