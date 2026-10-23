export type CardInfo = {
  uid: string;
  uidLength: number;
  atqa: string;
  sak: string;
  family: string;
  typeName: string;
};

export type ReadMode = "classic" | "type2";

export type ReadRequest = {
  uid: string;
  mode: ReadMode;
  start: number;
  count: number;
  keyType: "A" | "B" | null;
  key: string | null;
};

export type CardDump = {
  card: CardInfo;
  mode: ReadMode;
  rows: { address: number; hex: string }[];
  complete: boolean;
  error: string | null;
};

export type CardState = {
  card: CardInfo | null;
  dump: CardDump | null;
  error: string | null;
  checkedAt: number | null;
};

export function initialCardState(): CardState {
  return { card: null, dump: null, error: null, checkedAt: null };
}

/** SAK identifies a family, not an exact tag model or authenticity. */
export function readCapability(card: CardInfo) {
  switch (card.family) {
    case "classicMini": return { mode: "classic" as const, units: 20, unit: "块", bytes: 16 };
    case "classic1k": return { mode: "classic" as const, units: 64, unit: "块", bytes: 16 };
    case "classic4k": return { mode: "classic" as const, units: 256, unit: "块", bytes: 16 };
    case "type2": return { mode: "type2" as const, units: 16, unit: "页", bytes: 4 };
    default: return null;
  }
}

export type ReadSelection = {
  start: string;
  count: string;
  keyType: string;
  key: string;
};

/** Validates before invoking Rust; Rust independently validates against the actual card. */
export function makeReadRequest(card: CardInfo, selection: ReadSelection): ReadRequest {
  const capability = readCapability(card);
  if (!capability) throw new Error("此卡片当前仅支持识别，暂不支持数据读取。");
  if (!/^\d+$/.test(selection.start) || !/^\d+$/.test(selection.count)) {
    throw new Error("起始地址和数量须为十进制整数。");
  }
  const start = Number(selection.start);
  const count = Number(selection.count);
  if (!Number.isSafeInteger(start) || !Number.isSafeInteger(count) || count < 1 || count > 16) {
    throw new Error("每次只读 1–16 个数据单元。");
  }
  if (start < 0 || start + count > capability.units) {
    throw new Error(`读取范围须在 0–${capability.units - 1} ${capability.unit}内。`);
  }
  if (capability.mode === "classic") {
    if (selection.keyType !== "A" && selection.keyType !== "B") throw new Error("请选择 Key A 或 Key B。");
    if (!/^[0-9a-fA-F]{12}$/.test(selection.key)) {
      throw new Error("请输入已知密钥：12 位十六进制（6 字节），不会自动尝试其他密钥。");
    }
  }
  return {
    uid: card.uid,
    mode: capability.mode,
    start,
    count,
    keyType: capability.mode === "classic" ? selection.keyType as "A" | "B" : null,
    key: capability.mode === "classic" ? selection.key : null,
  };
}

export function spacedHex(hex: string): string {
  return hex.match(/.{1,2}/g)?.join(" ") ?? "";
}
