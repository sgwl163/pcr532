import type { CardDump, CardInfo } from "./cards.ts";

export type DictionaryRequest = {
  runId: string;
  uid: string;
  startSector: number;
  sectorCount: number;
  useCommonKeys: boolean;
  keys: string[];
  confirmed: boolean;
};
export type DictionaryProgress = {
  attempts: number;
  maxAttempts: number;
  completedSectors: number;
  totalSectors: number;
  currentSector: number;
  foundKeys: number;
  phase: "checking" | "reading" | "";
};
export type DictionaryResult = {
  dump: CardDump;
  sectors: {
    sector: number;
    keyA: string | null;
    keyB: string | null;
    keyAChecked: boolean;
    keyBChecked: boolean;
  }[];
  cancelled: boolean;
  attempts: number;
  error: string | null;
};

export function classicSectors(card: CardInfo): number | null {
  return (
    (
      { classicMini: 5, classic1k: 16, classic4k: 40 } as Record<string, number>
    )[card.family] ?? null
  );
}

export function makeDictionaryRequest(
  card: CardInfo,
  selection: {
    startSector: string;
    sectorCount: string;
    useCommonKeys: boolean;
    dictionary: string;
    confirmed: boolean;
  },
  runId: string,
): DictionaryRequest {
  const sectors = classicSectors(card);
  if (!sectors)
    throw new Error(
      "字典检测仅支持 MIFARE Classic / Mini。其他卡型没有通用解锁功能。",
    );
  if (!selection.confirmed) throw new Error("请确认卡片归属和测试授权。");
  if (
    !/^\d+$/.test(selection.startSector) ||
    !/^\d+$/.test(selection.sectorCount)
  )
    throw new Error("扇区范围须为十进制整数。");
  const startSector = Number(selection.startSector),
    sectorCount = Number(selection.sectorCount);
  if (
    !Number.isSafeInteger(startSector) ||
    !Number.isSafeInteger(sectorCount) ||
    sectorCount < 1 ||
    startSector + sectorCount > sectors
  ) {
    throw new Error(`扇区范围须在 0–${sectors - 1} 内。`);
  }
  if (selection.dictionary.length > 4096)
    throw new Error("字典输入过长，最多 64 个密钥。");
  const entries = selection.dictionary.trim()
    ? selection.dictionary.trim().split(/[\s,;]+/)
    : [];
  if (
    entries.length > 64 ||
    entries.some((key) => !/^[\da-fA-F]{12}$/.test(key))
  )
    throw new Error(
      "最多 64 个密钥，每个为 12 位十六进制，以空格、逗号或换行分隔。",
    );
  const keys = [...new Set(entries.map((key) => key.toUpperCase()))];
  if (!selection.useCommonKeys && !keys.length)
    throw new Error("请选择常见密钥或输入自定义字典。");
  return {
    runId,
    uid: card.uid,
    startSector,
    sectorCount,
    keys,
    useCommonKeys: selection.useCommonKeys,
    confirmed: true,
  };
}
