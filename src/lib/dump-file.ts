import type { CardDump } from "./cards.ts";

const layouts = new Map([
  [320, { family: "classicMini", name: "Classic Mini 布局候选" }],
  [1024, { family: "classic1k", name: "Classic 1K 布局候选" }],
  [4096, { family: "classic4k", name: "Classic 4K 布局候选" }],
]);

/** Raw files have no RF identity or read-success metadata. Never use this as live reader state. */
export function parseClassicDump(bytes: Uint8Array): CardDump {
  const layout = layouts.get(bytes.length);
  if (!layout)
    throw new Error("仅支持 320、1024 或 4096 字节的 Classic 原始 .dump；不猜测带头部或文本格式。");
  const hex = (data: Uint8Array) => Array.from(data, b => b.toString(16).padStart(2, "0")).join("").toUpperCase();
  const uid = hex(bytes.subarray(0, 4));
  const bccValid = bytes.subarray(0, 4).reduce((value, b) => value ^ b, 0) === bytes[4];
  return {
    card: { uid, uidLength: 4, atqa: "", sak: "", family: layout.family, typeName: layout.name },
    mode: "classic",
    rows: Array.from({ length: bytes.length / 16 }, (_, address) => ({
      address,
      hex: hex(bytes.subarray(address * 16, address * 16 + 16)),
    })),
    // Complete file layout, not proof that the original tool read every physical block.
    complete: true,
    error: bccValid ? null : "按四字节 UID 布局计算的 BCC 不一致；UID 仅为布局候选，未验证实际卡型。",
  };
}
