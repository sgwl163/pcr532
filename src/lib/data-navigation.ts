import type { CardDump } from "./cards.ts";
import { classicTrailer } from "./classic-layout.ts";

export type ByteSelection = { address: number; offset: number; length: number };
export type SearchEncoding = "hex" | "text";

/** Local, exact, single-row search. Trailer keys are never a searchable side channel. */
export function findByteMatches(dump: CardDump, query: string, encoding: SearchEncoding): ByteSelection[] {
  if (!query.length || !query.trim().length) return [];
  let needle: Uint8Array;
  if (encoding === "hex") {
    const hex = query.replace(/\s/g, "");
    if (!/^(?:[0-9a-fA-F]{2})+$/.test(hex))
      throw new Error("请输入完整字节的十六进制数据，例如 37 5F。");
    if (hex.length > 32) throw new Error("搜索内容最多 16 字节，且不会跨块或页匹配。");
    needle = Uint8Array.from(hex.match(/../g)!, byte => Number.parseInt(byte, 16));
  } else {
    needle = new TextEncoder().encode(query);
    if (needle.length > 16) throw new Error("搜索内容最多 16 个 UTF-8 字节，且不会跨块或页匹配。");
  }
  const matches: ByteSelection[] = [];
  const width = dump.mode === "classic" ? 16 : 4;
  for (const row of [...dump.rows].sort((a, b) => a.address - b.address)) {
    if (!new RegExp(`^[0-9a-fA-F]{${width * 2}}$`).test(row.hex)) continue;
    const bytes = Uint8Array.from(row.hex.match(/../g)!, byte => Number.parseInt(byte, 16));
    const trailer = dump.mode === "classic" && classicTrailer(row.address);
    for (let offset = 0; offset + needle.length <= bytes.length; offset++) {
      if (trailer && (offset < 6 || offset + needle.length > 10)) continue;
      if (needle.every((byte, index) => byte === bytes[offset + index]))
        matches.push({ address: row.address, offset, length: needle.length });
    }
  }
  return matches;
}

/** Returns only an already acquired row; a jump never triggers a reader command. */
export function resolveLoadedAddress(dump: CardDump, input: string, hexAddress: boolean): number {
  const value = input.trim();
  const hex = /^0x/i.test(value) || hexAddress;
  if (!(hex ? /^(?:0x)?[0-9a-f]+$/i : /^\d+$/).test(value))
    throw new Error("请输入有效地址；十六进制可使用 0x 前缀。");
  const address = Number.parseInt(value.replace(/^0x/i, ""), hex ? 16 : 10);
  if (!Number.isSafeInteger(address) || !dump.rows.some(row => row.address === address))
    throw new Error("该地址未载入，本操作只定位已有数据，不会读取或补齐缺失块。");
  return address;
}
