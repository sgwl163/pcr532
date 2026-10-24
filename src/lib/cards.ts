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
  let keyType: ReadRequest["keyType"] = null;
  if (capability.mode === "classic") {
    if (selection.keyType !== "A" && selection.keyType !== "B") throw new Error("请选择 Key A 或 Key B。");
    keyType = selection.keyType;
    if (!/^[0-9a-fA-F]{12}$/.test(selection.key)) {
      throw new Error("请输入已知密钥：12 位十六进制（6 字节），不会自动尝试其他密钥。");
    }
  }
  return {
    uid: card.uid,
    mode: capability.mode,
    start,
    count,
    keyType,
    key: capability.mode === "classic" ? selection.key : null,
  };
}

export type WriteRequest = {
  uid: string;
  mode: ReadMode;
  address: number;
  hex: string;
  expectedHex: string;
  keyType: "A" | "B" | null;
  key: string | null;
  confirmed: boolean;
};

export type WriteResult = {
  card: CardInfo;
  mode: ReadMode;
  address: number;
  beforeHex: string | null;
  afterHex: string | null;
  writeAttempted: boolean;
  verified: boolean;
  error: string | null;
};

/** Excludes manufacturer blocks, all Classic trailers, Type 2 UID/locks/CC/config. */
export function writableAddress(card: CardInfo, address: number): boolean {
  const capability = readCapability(card);
  if (!capability || !Number.isInteger(address) || address < 0 || address >= capability.units) return false;
  if (capability.mode === "type2") return address >= 4 && address <= 15;
  return address > 0 && (address < 128 ? address % 4 !== 3 : (address - 128) % 16 !== 15);
}

export function makeWriteRequest(card: CardInfo, dump: CardDump, selection: {
  address: number; hex: string; keyType: string; key: string; confirmed: boolean;
}): WriteRequest {
  const capability = readCapability(card);
  if (!capability || !writableAddress(card, selection.address)) throw new Error("此地址受保护或超出可写用户区。");
  if (!dump.complete || dump.card.uid !== card.uid || dump.mode !== capability.mode) throw new Error("请先重新读取目标地址的原数据。");
  const original = dump.rows.find((row) => row.address === selection.address);
  const hex = selection.hex.replace(/\s/g, "").toUpperCase();
  const pattern = new RegExp(`^[0-9a-fA-F]{${capability.bytes * 2}}$`);
  if (!original || !pattern.test(original.hex)) throw new Error("当前读取结果缺少有效原数据，请重新读取。");
  if (!pattern.test(hex)) throw new Error(`新数据必须为 ${capability.bytes * 2} 位十六进制（${capability.bytes} 字节）。`);
  if (!selection.confirmed) throw new Error("请先预览并确认覆盖风险。");
  const read = makeReadRequest(card, { start: String(selection.address), count: "1", keyType: selection.keyType, key: selection.key });
  return { uid: card.uid, mode: capability.mode, address: selection.address, hex,
    expectedHex: original.hex.toUpperCase(), keyType: read.keyType, key: read.key, confirmed: true };
}

export function spacedHex(hex: string): string {
  return hex.match(/.{1,2}/g)?.join(" ") ?? "";
}
