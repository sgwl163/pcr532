import {
  useEffect,
  useState,
  useSyncExternalStore,
  type FormEvent,
} from "react";
import { KeyRound, LoaderCircle, Square } from "lucide-react";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { classicSectors, makeDictionaryRequest } from "@/lib/dictionary";
import { ReaderController } from "@/lib/reader";

/** Explicitly a dictionary checker, never labelled as nested/hardnested recovery. */
export function DictionaryPanel({
  controller,
}: {
  controller: ReaderController;
}) {
  const state = useSyncExternalStore(controller.subscribe, controller.getState);
  const { card } = state.cardState;
  const { runId, result, progress, error, cancelling } = state.dictionary;
  const sectors = card ? classicSectors(card) : null;
  const connected = !!state.snapshot?.connection && !state.scanError;
  const busy = !["idle", "scanning"].includes(state.activity);
  const [start, setStart] = useState("0");
  const [count, setCount] = useState("1");
  const [useCommonKeys, setUseCommonKeys] = useState(true);
  const [dictionary, setDictionary] = useState("");
  const [confirmed, setConfirmed] = useState(false);
  const [showKeys, setShowKeys] = useState(false);
  const [formError, setFormError] = useState("");

  useEffect(() => {
    if (!runId) return;
    void controller.pollDictionary();
    const timer = window.setInterval(
      () => void controller.pollDictionary(),
      400,
    );
    return () => window.clearInterval(timer);
  }, [controller, runId]);

  function submit(event: FormEvent<HTMLFormElement>) {
    event.preventDefault();
    if (busy || !connected || !card || !sectors) return;
    setFormError("");
    try {
      const request = makeDictionaryRequest(
        card,
        {
          startSector: start,
          sectorCount: count,
          useCommonKeys,
          dictionary,
          confirmed,
        },
        crypto.randomUUID(),
      );
      setDictionary("");
      setConfirmed(false);
      setShowKeys(false);
      void controller.checkDictionary(request);
    } catch (cause) {
      setFormError(cause instanceof Error ? cause.message : String(cause));
    }
  }

  return (
    <section className="control-section" aria-labelledby="dictionary-title">
      <h2 id="dictionary-title" className="control-heading">
        <KeyRound aria-hidden="true" />
        密钥检测 / 字典
      </h2>
      <div className="space-y-3 p-3 text-[11px] leading-5">
        <p className="text-muted-foreground">
          未知密钥的第一步：尝试有限的候选密钥，命中后读取扇区。
          <strong className="font-medium text-foreground">
            不推导字典外密钥
          </strong>
          ，尚未集成 nested / hardnested（嵌套认证密钥恢复）。不修改
          UID、密钥或锁定位。
        </p>
        {!connected || !card ? (
          <p>先连接读卡器并点击“寻卡 / 重新识别”确定卡型。</p>
        ) : !sectors ? (
          <p className="text-amber-800">
            此卡暂不支持字典检测。Type 2、DESFire 等不能套用 Classic
            恢复方法；永久锁定位不能通用解除。
          </p>
        ) : !runId ? (
          <form
            aria-label="字典密钥检测"
            onSubmit={submit}
            className="space-y-3"
          >
            <fieldset disabled={busy} className="space-y-3">
              <legend className="sr-only">检测范围与字典</legend>
              <div className="grid grid-cols-2 gap-2">
                <div>
                  <label htmlFor="dictionary-start">起始扇区</label>
                  <Input
                    id="dictionary-start"
                    type="number"
                    min={0}
                    max={sectors - 1}
                    step={1}
                    required
                    value={start}
                    onChange={(e) => setStart(e.target.value)}
                  />
                </div>
                <div>
                  <label htmlFor="dictionary-count">扇区数量</label>
                  <Input
                    id="dictionary-count"
                    type="number"
                    min={1}
                    max={sectors}
                    step={1}
                    required
                    value={count}
                    onChange={(e) => setCount(e.target.value)}
                  />
                </div>
              </div>
              <Button
                type="button"
                variant="outline"
                size="xs"
                onClick={() => {
                  setStart("0");
                  setCount(String(sectors));
                }}
              >
                选择全部 {sectors} 扇区
              </Button>
              <label className="flex items-start gap-2">
                <input
                  type="checkbox"
                  className="mt-1"
                  checked={useCommonKeys}
                  onChange={(e) => setUseCommonKeys(e.target.checked)}
                />
                尝试内置 8 个常见密钥（含 FFFFFFFFFFFF）
              </label>
              <div>
                <label htmlFor="dictionary-keys">
                  自定义候选密钥（可选，最多 64 个）
                </label>
                <textarea
                  id="dictionary-keys"
                  className="mt-1 min-h-16 w-full rounded border bg-background p-2 font-mono text-xs outline-none focus-visible:ring-2 focus-visible:ring-ring disabled:opacity-50"
                  rows={3}
                  maxLength={4096}
                  autoComplete="off"
                  spellCheck={false}
                  autoCapitalize="off"
                  value={dictionary}
                  onChange={(e) => setDictionary(e.target.value)}
                  placeholder="每个 12 位 HEX，用空格或换行分隔"
                />
              </div>
              <label className="flex items-start gap-2">
                <input
                  type="checkbox"
                  className="mt-1"
                  checked={confirmed}
                  onChange={(e) => setConfirmed(e.target.checked)}
                />
                我确认卡片为自有或已获授权测试卡，允许尝试候选密钥并读取。
              </label>
            </fieldset>
            <p className="text-muted-foreground">
              地址按扇区计，不是块。分别检测 Key A /
              B；每次认证前重新激活并核对标识。运行约 10
              分钟后会在命令边界停止，可取消，不会穷举 48
              位密钥空间。输入提交后清空。
            </p>
            <Button
              type="submit"
              className="w-full"
              disabled={busy || !confirmed}
            >
              <KeyRound aria-hidden="true" />
              开始字典检测并读取
            </Button>
          </form>
        ) : null}
        {runId && (
          <div
            role="status"
            className="space-y-2 rounded border bg-muted/30 p-2"
          >
            <p className="flex items-center gap-1">
              <LoaderCircle
                className="size-3.5 motion-safe:animate-spin"
                aria-hidden="true"
              />
              {cancelling
                ? "等待当前命令结束并取消…"
                : progress?.phase === "reading"
                  ? "正在读取命中扇区"
                  : "正在检测候选密钥"}
            </p>
            {progress && (
              <>
                <p>
                  完成 {progress.completedSectors} / {progress.totalSectors}{" "}
                  扇区 · 当前 {progress.currentSector}
                </p>
                <p>
                  候选认证 {progress.attempts} / 最多 {progress.maxAttempts} ·
                  命中 {progress.foundKeys} 个
                </p>
              </>
            )}
            <Button
              type="button"
              variant="outline"
              size="sm"
              disabled={cancelling}
              onClick={() => void controller.cancelDictionary()}
            >
              <Square aria-hidden="true" />
              取消检测
            </Button>
          </div>
        )}
        {(formError || error) && (
          <p role="alert" className="text-destructive">
            {formError || error}
          </p>
        )}
        {result && (
          <div
            className="space-y-2 rounded border bg-muted/20 p-2"
            aria-label="字典检测结果"
          >
            <p className="font-medium">
              {result.cancelled
                ? "检测已取消，部分结果"
                : result.error
                  ? "检测中断，部分结果"
                  : "字典检测结束"}
            </p>
            <p>
              候选认证 {result.attempts} 次；读取 {result.dump.rows.length}{" "}
              块。原始数据已显示在数据表 A；“完整”仅指所选扇区数据。
            </p>
            {(result.error || result.dump.error) && (
              <p className="text-amber-800">
                {result.error || result.dump.error}
              </p>
            )}
            <label className="flex items-center gap-2">
              <input
                type="checkbox"
                checked={showKeys}
                onChange={(e) => setShowKeys(e.target.checked)}
              />
              显示已认证密钥（敏感）
            </label>
            <div className="max-h-56 space-y-2 overflow-auto">
              {result.sectors.map((sector) => (
                <div key={sector.sector} className="border-t pt-1">
                  <p className="font-medium">扇区 {sector.sector}</p>
                  {(["A", "B"] as const).map((kind) => {
                    const key = kind === "A" ? sector.keyA : sector.keyB;
                    const checked =
                      kind === "A" ? sector.keyAChecked : sector.keyBChecked;
                    return (
                      <div key={kind} className="flex items-center gap-2">
                        <span>Key {kind}</span>
                        {key ? (
                          <input
                            aria-label={`扇区 ${sector.sector} Key ${kind}`}
                            className="min-w-0 flex-1 bg-transparent font-mono text-xs"
                            readOnly
                            type={showKeys ? "text" : "password"}
                            autoComplete="off"
                            value={key}
                          />
                        ) : (
                          <span className="text-muted-foreground">
                            {checked ? "字典未命中" : "尚未完成检测"}
                          </span>
                        )}
                      </div>
                    );
                  })}
                </div>
              ))}
            </div>
            <p className="text-muted-foreground">
              密钥来自成功认证，不从尾块字节猜测。未命中不等于无法恢复；读取权限仍受卡片规则限制。结果仅在当前会话保留，清除结果、重新寻卡或断开后移除，不保存或上传。
            </p>
          </div>
        )}
      </div>
    </section>
  );
}
