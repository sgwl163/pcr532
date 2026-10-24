export type ValueEncoding =
  | "utf8"
  | "unix-seconds-le"
  | "unix-seconds-be"
  | "bcd-date"
  | "packed-date-2000-be";

/** Explicit user-selected interpretations, never evidence of a card's field semantics. */
export function decodeNfcValue(
  hex: string,
  encoding: ValueEncoding,
  offset: number,
): { value: string; raw: string; bytes: number } {
  if (!/^(?:[0-9a-fA-F]{2})+$/.test(hex) || hex.length > 8192)
    throw new Error("需要有效的原始十六进制字节。");
  const bytes = Uint8Array.from(hex.match(/../g)!, (byte) =>
    Number.parseInt(byte, 16),
  );
  if (!Number.isSafeInteger(offset) || offset < 0 || offset >= bytes.length)
    throw new Error("字节偏移超出所选数据单元。");
  const data = bytes.subarray(offset);
  const raw = (length: number) =>
    hex.slice(offset * 2, (offset + length) * 2).toUpperCase();
  if (encoding === "utf8") {
    let end = data.length;
    while (end && data[end - 1] === 0) end--;
    let value: string;
    try {
      value = new TextDecoder("utf-8", { fatal: true }).decode(
        data.subarray(0, end),
      );
    } catch {
      throw new Error("所选字节不是有效的 UTF-8 文本。");
    }
    if (
      !value ||
      /[\u0000-\u0008\u000B\u000C\u000E-\u001F\u007F-\u009F]/.test(value)
    )
      throw new Error("所选字节包含二进制控制字符或没有文本。");
    return { value, raw: raw(data.length), bytes: data.length };
  }
  if (encoding === "packed-date-2000-be") {
    if (data.length < 2) throw new Error("压缩日期需要从偏移处起至少 2 字节。");
    const packed = data[0] * 256 + data[1];
    const year = 2000 + (packed >> 9);
    const month = (packed >> 5) & 15;
    const day = packed & 31;
    const leap = year % 4 === 0 && (year % 100 !== 0 || year % 400 === 0);
    const days = [31, leap ? 29 : 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
    if (month < 1 || month > 12 || day < 1 || day > days[month - 1])
      throw new Error("所选字节不是有效的 2000 年基准压缩日期。");
    return {
      value: `${year}-${String(month).padStart(2, "0")}-${String(day).padStart(2, "0")}（无时区的日期）`,
      raw: raw(2), bytes: 2,
    };
  }
  if (data.length < 4)
    throw new Error(
      "此编码需要从偏移处起至少 4 字节；不会跨越缺失或其他数据单元。",
    );
  if (encoding === "unix-seconds-le" || encoding === "unix-seconds-be") {
    const seconds = new DataView(data.buffer, data.byteOffset, 4).getUint32(
      0,
      encoding === "unix-seconds-le",
    );
    return {
      value: `${new Date(seconds * 1000).toISOString().replace(".000Z", "Z")}（UTC）`,
      raw: raw(4),
      bytes: 4,
    };
  }
  if (encoding !== "bcd-date") throw new Error("不支持此编码。");
  const digits = Array.from(data.subarray(0, 4))
    .map((byte) => {
      if (byte >> 4 > 9 || (byte & 15) > 9)
        throw new Error("BCD 日期的每个半字节必须为 0–9。");
      return String(byte >> 4) + String(byte & 15);
    })
    .join("");
  const year = Number(digits.slice(0, 4));
  const month = Number(digits.slice(4, 6));
  const day = Number(digits.slice(6, 8));
  const leap = year % 4 === 0 && (year % 100 !== 0 || year % 400 === 0);
  const days = [31, leap ? 29 : 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
  if (year < 1 || month < 1 || month > 12 || day < 1 || day > days[month - 1])
    throw new Error("BCD 内容不是有效的 YYYYMMDD 日期。");
  return {
    value: `${digits.slice(0, 4)}-${digits.slice(4, 6)}-${digits.slice(6, 8)}（无时区的日期）`,
    raw: raw(4),
    bytes: 4,
  };
}
