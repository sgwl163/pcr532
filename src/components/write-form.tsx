import { useEffect, useRef, useState, type FormEvent } from "react";
import { CircleAlert, PencilLine } from "lucide-react";

import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { NativeSelect } from "@/components/ui/native-select";
import {
  makeWriteRequest,
  readCapability,
  spacedHex,
  writableAddress,
  type CardDump,
  type CardInfo,
  type WriteRequest,
} from "@/lib/cards";
import { ReaderController } from "@/lib/reader";

export function WriteForm({
  card,
  dump,
  controller,
  disabled,
  selectedAddress,
}: {
  card: CardInfo;
  dump: CardDump | null;
  controller: ReaderController;
  disabled: boolean;
  selectedAddress?: number | null;
}) {
  const capability = readCapability(card);
  const rows = dump?.complete
    ? dump.rows.filter((row) => writableAddress(card, row.address))
    : [];
  const [address, setAddress] = useState(
    String(
      selectedAddress != null &&
        rows.some((row) => row.address === selectedAddress)
        ? selectedAddress
        : (rows[0]?.address ?? ""),
    ),
  );
  const [hex, setHex] = useState("");
  const [keyType, setKeyType] = useState("A");
  const [key, setKey] = useState("");
  const [preview, setPreview] = useState<Omit<
    WriteRequest,
    "key" | "keyType" | "confirmed"
  > | null>(null);
  const [acknowledged, setAcknowledged] = useState(false);
  const [error, setError] = useState("");
  const pending = useRef<WriteRequest | null>(null);

  useEffect(
    () => () => {
      if (pending.current) pending.current.key = null;
      pending.current = null;
    },
    [],
  );

  if (!capability) return null;
  if (!dump?.complete || rows.length === 0) {
    return (
      <p className="rounded-lg border border-dashed p-4 text-xs leading-6 text-muted-foreground">
        写入前，请先用左侧读取功能完整读取目标用户数据块或页。制造商块、扇区尾块、UID、锁定位和配置页不开放写入。
      </p>
    );
  }

  function changeAddress(value: string) {
    setAddress(value);
    setHex("");
    setKey("");
    setError("");
  }

  function prepare(event: FormEvent<HTMLFormElement>) {
    event.preventDefault();
    if (disabled || !dump) return;
    setError("");
    try {
      const request = makeWriteRequest(card, dump, {
        address: Number(address),
        hex,
        keyType,
        key,
        confirmed: true,
      });
      pending.current = request;
      setKey("");
      setAcknowledged(false);
      setPreview({
        uid: request.uid,
        mode: request.mode,
        address: request.address,
        hex: request.hex,
        expectedHex: request.expectedHex,
      });
    } catch (cause) {
      setError(cause instanceof Error ? cause.message : String(cause));
    }
  }

  function cancel() {
    if (pending.current) pending.current.key = null;
    pending.current = null;
    setPreview(null);
    setAcknowledged(false);
  }

  function confirm() {
    if (disabled || !acknowledged || !pending.current) return;
    const request = pending.current;
    pending.current = null;
    setPreview(null);
    setAcknowledged(false);
    setHex("");
    void controller.writeCard(request);
  }

  return (
    <div
      className="space-y-4 rounded-lg border border-amber-600/30 bg-amber-500/5 p-4"
      aria-label="用户数据写入"
    >
      <div className="space-y-1">
        <h3 className="flex items-center gap-2 text-sm font-semibold">
          <PencilLine className="size-4" aria-hidden="true" />单
          {capability.unit}写入
        </h3>
        <p className="text-xs leading-6 text-muted-foreground">
          每次覆盖一个已读取的{capability.unit}，共 {capability.bytes}{" "}
          字节。写入可能破坏已有内容；请事先自行备份，只操作自有或已获授权的测试卡。
        </p>
      </div>
      {preview ? (
        <section aria-label="写入确认" className="space-y-4">
          <h4 className="text-sm font-semibold">确认覆盖预览</h4>
          <dl className="space-y-2 text-xs leading-6">
            <div>
              <dt className="text-muted-foreground">目标 UID</dt>
              <dd className="break-all font-mono">{spacedHex(preview.uid)}</dd>
            </div>
            <div>
              <dt className="text-muted-foreground">
                {capability.unit}地址（十进制）
              </dt>
              <dd className="font-mono">{preview.address}</dd>
            </div>
            <div>
              <dt className="text-muted-foreground">原数据</dt>
              <dd className="break-all font-mono select-text">
                {spacedHex(preview.expectedHex)}
              </dd>
            </div>
            <div>
              <dt className="text-muted-foreground">新数据</dt>
              <dd className="break-all font-mono select-text">
                {spacedHex(preview.hex)}
              </dd>
            </div>
          </dl>
          <label className="flex items-start gap-2 text-sm leading-6">
            <input
              type="checkbox"
              className="mt-1 size-4 accent-primary"
              checked={acknowledged}
              disabled={disabled}
              onChange={(event) => setAcknowledged(event.target.checked)}
            />
            我确认已获授权并已备份，理解覆盖不可自动撤销。
          </label>
          <p className="flex items-start gap-2 text-xs leading-6 text-muted-foreground">
            <CircleAlert className="mt-1 size-4 shrink-0" aria-hidden="true" />
            写前会再次检查 UID
            和原数据。写后读回校验；超时或不一致时不自动重试、回滚。UID
            相同不能保证是同一张物理卡。
          </p>
          <div className="flex flex-wrap gap-2">
            <Button
              type="button"
              variant="destructive"
              disabled={disabled || !acknowledged}
              onClick={confirm}
            >
              确认写入此{capability.unit}
            </Button>
            <Button
              type="button"
              variant="outline"
              disabled={disabled}
              onClick={cancel}
            >
              取消写入
            </Button>
          </div>
        </section>
      ) : (
        <form onSubmit={prepare} className="space-y-4" aria-label="准备写入">
          <fieldset
            disabled={disabled}
            className="grid min-w-0 gap-3 write-fields"
          >
            <legend className="sr-only">写入目标及认证</legend>
            <div className="space-y-2">
              <label htmlFor="write-address" className="text-sm font-medium">
                目标{capability.unit}地址
              </label>
              <NativeSelect
                id="write-address"
                value={address}
                onChange={(event) => changeAddress(event.target.value)}
              >
                {rows.map((row) => (
                  <option key={row.address} value={row.address}>
                    {row.address}
                  </option>
                ))}
              </NativeSelect>
            </div>
            <div className="space-y-2 sm:col-span-2">
              <label htmlFor="write-hex" className="text-sm font-medium">
                新数据（{capability.bytes} 字节十六进制）
              </label>
              <Input
                id="write-hex"
                value={hex}
                onChange={(event) => setHex(event.target.value)}
                required
                spellCheck={false}
                autoComplete="off"
                className="font-mono"
                aria-describedby="write-data-help"
                placeholder={`${capability.bytes * 2} 位十六进制，可含空格`}
              />
              <p id="write-data-help" className="text-xs text-muted-foreground">
                按原始字节覆盖，不进行文字编码或自动补零。
              </p>
              <div className="rounded border bg-background p-2 text-xs leading-5">
                <span className="text-muted-foreground">当前原数据</span>
                <p className="break-all font-mono select-text">
                  {spacedHex(
                    rows.find((row) => row.address === Number(address))?.hex ??
                      "",
                  )}
                </p>
              </div>
              <Button
                type="button"
                variant="ghost"
                size="xs"
                onClick={() =>
                  setHex(
                    rows.find((row) => row.address === Number(address))?.hex ??
                      "",
                  )
                }
              >
                载入原数据到编辑框
              </Button>
            </div>
            {capability.mode === "classic" && (
              <>
                <div className="space-y-2">
                  <label
                    htmlFor="write-key-type"
                    className="text-sm font-medium"
                  >
                    写入认证类型
                  </label>
                  <NativeSelect
                    id="write-key-type"
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
                <div className="space-y-2">
                  <label htmlFor="write-key" className="text-sm font-medium">
                    写入已知密钥
                  </label>
                  <Input
                    id="write-key"
                    type="password"
                    autoComplete="off"
                    spellCheck={false}
                    required
                    minLength={12}
                    maxLength={12}
                    pattern="[0-9a-fA-F]{12}"
                    value={key}
                    onChange={(event) => setKey(event.target.value)}
                    placeholder="12 位十六进制，无默认值"
                  />
                </div>
              </>
            )}
          </fieldset>
          <p className="text-xs leading-6 text-muted-foreground">
            {capability.mode === "classic"
              ? "读取成功不代表当前密钥具有写入权限；写入认证失败即停止。密钥仅用于当前请求，预览后清空输入；取消或关闭表单时丢弃待用密钥。"
              : "仅允许用户数据页 4–15；写前额外检查 NFC 容量标记和开放读写权限，不执行密码认证或解锁。"}
          </p>
          {error && (
            <p role="alert" className="text-sm text-destructive">
              {error}
            </p>
          )}
          <Button type="submit" variant="outline" disabled={disabled}>
            <PencilLine aria-hidden="true" />
            预览写入
          </Button>
        </form>
      )}
    </div>
  );
}
