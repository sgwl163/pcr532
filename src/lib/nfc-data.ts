import { readCapability, writableAddress, type CardDump } from "./cards.ts";

export type NfcAnalysis = {
  records: { type: string; text: string; language?: string; address: number }[];
  dates: { value: string; source: string; address: number }[];
  textSegments: { text: string; address: number }[];
  warnings: string[];
  format: string;
};

type Memory = { bytes: number[]; addresses: number[] };
type RecordData = {
  tnf: number;
  type: Uint8Array;
  payload: Uint8Array;
  address: number;
};
const MAX_BYTES = 4096;
const URI_PREFIXES = [
  "",
  "http://www.",
  "https://www.",
  "http://",
  "https://",
  "tel:",
  "mailto:",
  "ftp://anonymous:anonymous@",
  "ftp://ftp.",
  "ftps://",
  "sftp://",
  "smb://",
  "nfs://",
  "ftp://",
  "dav://",
  "news:",
  "telnet://",
  "imap:",
  "rtsp://",
  "urn:",
  "pop:",
  "sip:",
  "sips:",
  "tftp:",
  "btspp://",
  "btl2cap://",
  "btgoep://",
  "tcpobex://",
  "irdaobex://",
  "file://",
  "urn:epc:id:",
  "urn:epc:tag:",
  "urn:epc:pat:",
  "urn:epc:raw:",
  "urn:epc:",
  "urn:nfc:",
];
const CONTROLS = /[\u0000-\u0008\u000B\u000C\u000E-\u001F\u007F-\u009F]/;

function decode(bytes: Uint8Array, encoding = "utf-8") {
  const text = new TextDecoder(encoding, { fatal: true }).decode(bytes);
  if (CONTROLS.test(text)) throw new Error("内容包含非文本控制字符");
  return text;
}

function validDate(year: number, month: number, day: number) {
  const leap = year % 4 === 0 && (year % 100 !== 0 || year % 400 === 0);
  const days = [31, leap ? 29 : 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
  return (
    year >= 1 &&
    year <= 9999 &&
    month >= 1 &&
    month <= 12 &&
    day >= 1 &&
    day <= days[month - 1]
  );
}

function addDate(
  result: NfcAnalysis,
  value: string,
  source: string,
  address: number,
) {
  if (
    !result.dates.some(
      (date) =>
        date.value === value &&
        date.source === source &&
        date.address === address,
    )
  )
    result.dates.push({ value, source, address });
}

function datesInText(
  result: NfcAnalysis,
  text: string,
  source: string,
  address: number,
) {
  const patterns = [
    /(?:^|[^\d])(\d{4})([-/])(\d{1,2})\2(\d{1,2})(?!\d)/g,
    /(?:^|[^\d])(\d{4})年(\d{1,2})月(\d{1,2})日/g,
  ];
  for (let i = 0; i < patterns.length; i++) {
    for (const match of text.matchAll(patterns[i])) {
      const year = Number(match[1]);
      const month = Number(match[i === 0 ? 3 : 2]);
      const day = Number(match[i === 0 ? 4 : 3]);
      if (validDate(year, month, day))
        addDate(
          result,
          `${String(year).padStart(4, "0")}-${String(month).padStart(2, "0")}-${String(day).padStart(2, "0")}`,
          source,
          address,
        );
    }
  }
}

function calendarDates(result: NfcAnalysis, text: string, address: number) {
  const unfolded = text.replace(/\r?\n[ \t]/g, "");
  if (
    !/^BEGIN:VCALENDAR\r?$/im.test(unfolded) ||
    !/^END:VCALENDAR\r?$/im.test(unfolded)
  ) {
    result.warnings.push(
      "日历文本缺少完整的 VCALENDAR 边界，未按日历字段解释日期。",
    );
    return;
  }
  for (const line of unfolded.split(/\r?\n/)) {
    const property =
      /^(DTSTART|DTEND|DTSTAMP|CREATED|LAST-MODIFIED)(;[^:]*)?:(.*)$/i.exec(
        line,
      );
    if (!property) continue;
    const params = property[2] ?? "";
    const match = /^(\d{4})(\d{2})(\d{2})(?:T(\d{2})(\d{2})(\d{2})(Z)?)?$/.exec(
      property[3],
    );
    if (
      !match ||
      !validDate(Number(match[1]), Number(match[2]), Number(match[3])) ||
      (match[4] !== undefined &&
        (Number(match[4]) > 23 ||
          Number(match[5]) > 59 ||
          Number(match[6]) > 59))
    ) {
      result.warnings.push(
        `日历 ${property[1].toUpperCase()} 日期无效，未采用。`,
      );
      continue;
    }
    const dateOnly = /(?:^|;)VALUE=DATE(?:;|$)/i.test(params);
    if (
      (dateOnly && match[4] !== undefined) ||
      (!dateOnly && match[4] === undefined) ||
      (/TZID=/i.test(params) && (dateOnly || match[7]))
    ) {
      result.warnings.push(
        `日历 ${property[1].toUpperCase()} 的日期类型或时区声明不一致，未采用。`,
      );
      continue;
    }
    let value = `${match[1]}-${match[2]}-${match[3]}`;
    if (match[4] !== undefined)
      value += `T${match[4]}:${match[5]}:${match[6]}${match[7] ?? ""}`;
    const timezone = /(?:^|;)TZID=([^;]+)/i.exec(params)?.[1];
    const source = `日历 ${property[1].toUpperCase()}${match[7] ? " · UTC" : timezone ? ` · TZID=${timezone}（未换算）` : match[4] !== undefined ? " · 浮动本地时间，无时区" : " · 日期，无时区"}`;
    addDate(result, value, source, address);
  }
}

/** Structural failures invalidate the entire NDEF message rather than publishing a misleading prefix. */
function ndefRecords(
  memory: Memory,
  start: number,
  length: number,
): RecordData[] {
  const bytes = Uint8Array.from(memory.bytes.slice(start, start + length));
  const records: RecordData[] = [];
  let cursor = 0;
  let ended = false;
  while (cursor < bytes.length) {
    if (records.length >= 128 || bytes.length - cursor < 3)
      throw new Error("NDEF 记录头截断或记录数量超限");
    const origin = cursor;
    const flags = bytes[cursor++];
    const tnf = flags & 7;
    const first = records.length === 0;
    if (Boolean(flags & 0x80) !== first)
      throw new Error("NDEF 消息起始标记 MB 不符合记录顺序");
    if (flags & 0x20) throw new Error("暂不支持分片 NDEF（CF），保留原始数据");
    if (tnf === 6 || tnf === 7)
      throw new Error("NDEF TNF 类型非法或仅可用于分片");
    const typeLength = bytes[cursor++];
    let payloadLength: number;
    if (flags & 0x10) payloadLength = bytes[cursor++];
    else {
      if (bytes.length - cursor < 4) throw new Error("NDEF 长记录长度字段截断");
      payloadLength = new DataView(
        bytes.buffer,
        bytes.byteOffset + cursor,
        4,
      ).getUint32(0, false);
      cursor += 4;
    }
    let idLength = 0;
    if (flags & 8) {
      if (cursor >= bytes.length) throw new Error("NDEF ID 长度字段截断");
      idLength = bytes[cursor++];
    }
    if (typeLength + idLength + payloadLength > bytes.length - cursor)
      throw new Error("NDEF 记录长度超过已读取内容，数据不足");
    if (
      (tnf === 0 && (typeLength || idLength || payloadLength)) ||
      (tnf === 5 && typeLength) ||
      (tnf >= 1 && tnf <= 4 && !typeLength)
    )
      throw new Error("NDEF 类型与记录长度字段不一致");
    const type = bytes.slice(cursor, cursor + typeLength);
    cursor += typeLength + idLength;
    const payload = bytes.slice(cursor, cursor + payloadLength);
    cursor += payloadLength;
    records.push({
      tnf,
      type,
      payload,
      address: memory.addresses[start + origin],
    });
    if (flags & 0x40) {
      ended = true;
      if (cursor !== bytes.length)
        throw new Error("NDEF 消息结束标记 ME 后仍有额外数据");
      break;
    }
  }
  if (!ended || !records.length)
    throw new Error("NDEF 消息缺少结束标记 ME 或内容为空");
  return records;
}

function publishRecord(result: NfcAnalysis, record: RecordData) {
  const { tnf, payload, address } = record;
  try {
    const type = decode(record.type);
    let text: string;
    let label: string;
    let language: string | undefined;
    let calendar = false;
    if (tnf === 1 && type === "T") {
      if (!payload.length || payload[0] & 0x40)
        throw new Error("NDEF 文本状态字无效");
      const languageLength = payload[0] & 0x3f;
      if (!languageLength || languageLength + 1 > payload.length)
        throw new Error("NDEF 文本语言长度无效");
      const languageBytes = payload.subarray(1, 1 + languageLength);
      if (languageBytes.some((byte) => byte > 127))
        throw new Error("NDEF 文本语言须为 ASCII");
      language = decode(languageBytes);
      if (!/^[A-Za-z]{1,8}(?:-[A-Za-z0-9]{1,8})*$/.test(language))
        throw new Error("NDEF 文本语言标记无效");
      let content = payload.subarray(1 + languageLength);
      if (payload[0] & 0x80) {
        if (content.length % 2)
          throw new Error("NDEF UTF-16 文本字节长度为奇数");
        const little = content[0] === 0xff && content[1] === 0xfe;
        if (little || (content[0] === 0xfe && content[1] === 0xff))
          content = content.subarray(2);
        text = decode(content, little ? "utf-16le" : "utf-16be");
      } else text = decode(content);
      label = "NDEF 文本";
    } else if (tnf === 1 && type === "U") {
      if (!payload.length || payload[0] >= URI_PREFIXES.length)
        throw new Error("NDEF URI 前缀编号无效");
      text = URI_PREFIXES[payload[0]] + decode(payload.subarray(1));
      if (!text || /\s/.test(text))
        throw new Error("NDEF URI 内容为空或包含空白");
      label = "NDEF 链接";
    } else if (
      tnf === 2 &&
      /^(text\/plain|text\/calendar)(?:\s*;|$)/i.test(type)
    ) {
      const charset = /;\s*charset\s*=\s*"?([^;"\s]+)/i.exec(type)?.[1];
      if (charset && !/^(utf-8|us-ascii)$/i.test(charset))
        throw new Error("此 MIME 文本字符集尚未支持");
      if (
        charset?.toLowerCase() === "us-ascii" &&
        payload.some((byte) => byte > 127)
      )
        throw new Error("MIME 声明 ASCII，但内容含非 ASCII 字节");
      text = decode(payload);
      calendar = /^text\/calendar(?:\s*;|$)/i.test(type);
      label = calendar ? "NDEF 日历" : "NDEF 文本（MIME）";
    } else if (tnf === 3) {
      text = type;
      if (/\s/.test(text)) throw new Error("绝对 URI 含空白");
      label = "NDEF 绝对 URI";
    } else {
      result.warnings.push(
        `来源地址 ${address}：已识别 NDEF 结构，暂不解释 TNF=${tnf} / ${type || "空类型"}（${payload.length} 字节）。`,
      );
      return;
    }
    result.records.push({
      type: label,
      text,
      ...(language ? { language } : {}),
      address,
    });
    // URI strings may contain path dates, but are not date records.
    if (label !== "NDEF 链接" && label !== "NDEF 绝对 URI") {
      datesInText(result, text, `${label}中的明确日期（含义未确认）`, address);
      if (calendar) calendarDates(result, text, address);
    }
  } catch (cause) {
    result.warnings.push(
      `来源地址 ${address}：${cause instanceof Error ? cause.message : "文本编码无效"}，保留原始字节。`,
    );
  }
}

function parseType2(result: NfcAnalysis, memory: Memory) {
  let cursor = 0;
  let sawNdef = false;
  let terminated = false;
  while (cursor < memory.bytes.length) {
    const tag = memory.bytes[cursor++];
    if (tag === 0) continue;
    if (tag === 0xfe) {
      terminated = true;
      break;
    }
    if (cursor >= memory.bytes.length) {
      result.warnings.push("TLV 长度字段截断，请读取更多数据。");
      break;
    }
    let length = memory.bytes[cursor++];
    if (length === 0xff) {
      if (memory.bytes.length - cursor < 2) {
        result.warnings.push("TLV 扩展长度字段截断，请读取更多数据。");
        break;
      }
      length = memory.bytes[cursor++] * 256 + memory.bytes[cursor++];
      if (length < 255) {
        result.warnings.push("TLV 扩展长度编码无效，停止解析。");
        break;
      }
    }
    if (length > memory.bytes.length - cursor) {
      result.warnings.push(
        `TLV 声明 ${length} 字节，但当前连续范围数据不足；不能据此判断卡内没有内容。`,
      );
      break;
    }
    if (tag === 1 || tag === 2) {
      result.warnings.push(
        "发现锁定/保留内存控制 TLV，尚未实现其物理内存映射；停止后续 NDEF 解析。",
      );
      break;
    }
    if (tag === 3) {
      sawNdef = true;
      result.format = "NFC Type 2 / NDEF";
      if (!length)
        result.warnings.push("NDEF TLV 为空（已格式化但没有消息）。");
      else {
        try {
          for (const record of ndefRecords(memory, cursor, length))
            publishRecord(result, record);
        } catch (cause) {
          result.warnings.push(
            cause instanceof Error ? cause.message : "NDEF 结构无效",
          );
        }
      }
    } else if (tag !== 0xfd) {
      result.warnings.push(
        `遇到未支持的 TLV 类型 0x${tag.toString(16).toUpperCase()}，停止解析，不猜测后续偏移。`,
      );
      break;
    }
    cursor += length;
  }
  if (!sawNdef)
    result.warnings.push(
      "当前范围未确认有效 NDEF 消息；可能未格式化、使用私有格式或数据不完整。",
    );
  if (!terminated)
    result.warnings.push(
      "当前连续数据未包含 TLV 终止标记，解析仅覆盖已读取范围。",
    );
  return sawNdef;
}

function extractText(result: NfcAnalysis, memory: Memory) {
  // Only printable, valid UTF-8 runs; no binary timestamps or random byte reinterpretation.
  let start = 0;
  for (let i = 0; i <= memory.bytes.length; i++) {
    const byte = memory.bytes[i];
    if (
      i !== memory.bytes.length &&
      byte !== 0 &&
      (byte >= 32 || byte === 9 || byte === 10 || byte === 13) &&
      byte !== 127
    )
      continue;
    if (i - start >= 4) {
      try {
        const text = decode(
          Uint8Array.from(memory.bytes.slice(start, i)),
        ).trim();
        if (text.length >= 4 && /[\p{L}\p{N}]/u.test(text)) {
          const address = memory.addresses[start];
          result.textSegments.push({ text, address });
          datesInText(
            result,
            text,
            "用户区可读文本中的明确日期（含义未确认）",
            address,
          );
        }
      } catch {
        /* Invalid binary runs are deliberately not turned into text. */
      }
    }
    start = i + 1;
  }
}

export function analyzeCardData(dump: CardDump): NfcAnalysis {
  const result: NfcAnalysis = {
    records: [],
    dates: [],
    textSegments: [],
    warnings: [],
    format: "原始用户区数据",
  };
  const capability = readCapability(dump.card);
  if (!capability || capability.mode !== dump.mode) {
    result.warnings.push("卡片类型与数据模式不匹配，未解释内容。");
    return result;
  }
  if (!dump.complete)
    result.warnings.push(
      "本次读取未完成，分析只针对已成功读取的部分，不代表整卡。",
    );
  if (dump.rows.length > 256) {
    result.warnings.push("数据单元数量超限，停止解析。");
    return result;
  }
  const sorted = [...dump.rows].sort((a, b) => a.address - b.address);
  const seen = new Set<number>();
  const segments: Memory[] = [];
  let segment: Memory = { bytes: [], addresses: [] };
  let previous = -1;
  let total = 0;
  for (const row of sorted) {
    // The analyzer accepts bounded memory captures independently of the live reader's 0–15 page policy.
    const addressLimit = dump.mode === "type2" ? 1024 : capability.units;
    if (
      !Number.isInteger(row.address) ||
      row.address < 0 ||
      row.address >= addressLimit ||
      seen.has(row.address) ||
      !new RegExp(`^[0-9a-fA-F]{${capability.bytes * 2}}$`).test(row.hex)
    ) {
      result.warnings.push(
        "发现重复地址、非法地址或无效原始字节，停止解析以避免拼接错误。",
      );
      return { ...result, records: [], dates: [], textSegments: [] };
    }
    seen.add(row.address);
    if (
      dump.mode === "classic"
        ? !writableAddress(dump.card, row.address)
        : row.address < 4
    ) {
      if (segment.bytes.length) segments.push(segment);
      segment = { bytes: [], addresses: [] };
      previous = -1;
      continue;
    }
    if (row.address !== previous + 1 && segment.bytes.length) {
      segments.push(segment);
      segment = { bytes: [], addresses: [] };
    }
    const bytes = row.hex
      .match(/../g)!
      .map((pair) => Number.parseInt(pair, 16));
    total += bytes.length;
    if (total > MAX_BYTES) {
      result.warnings.push("数据量超限，停止解析。");
      return result;
    }
    segment.bytes.push(...bytes);
    segment.addresses.push(...bytes.map(() => row.address));
    previous = row.address;
  }
  if (segment.bytes.length) segments.push(segment);
  if (dump.mode === "type2") {
    result.format = "NFC Type 2 用户区";
    const beginning = segments.find((part) => part.addresses[0] === 4);
    if (!beginning)
      result.warnings.push(
        "NDEF 解析需要从用户页 4 开始的连续数据，请读取 0–15 页；不会从消息中间猜测记录。",
      );
    else {
      const cc = sorted.find((row) => row.address === 3)?.hex;
      if (
        cc &&
        (!/^E1/i.test(cc) ||
          Number.parseInt(cc.slice(2, 4), 16) >> 4 !== 1 ||
          Number.parseInt(cc.slice(4, 6), 16) === 0)
      )
        result.warnings.push(
          "容量标记 CC 未确认是 NFC Type 2 v1，以下仅按用户区 TLV 尝试解析，不代表精确型号。",
        );
      const firstContentByte = beginning.bytes.find((byte) => byte !== 0);
      if (
        !parseType2(result, beginning) &&
        firstContentByte !== undefined &&
        firstContentByte >= 0x20 &&
        firstContentByte < 0xfd
      ) {
        extractText(result, beginning);
        if (result.textSegments.length)
          result.warnings.push(
            "可读文本仅为原始用户区内容，不代表已确认 NDEF 或业务字段。",
          );
      }
      if (segments.length > 1)
        result.warnings.push("读取地址存在间隔，后续片段未拼接到 NDEF 消息。");
    }
    result.warnings.push(
      "硬件读取当前仅开放页 0–15（48 字节用户区），较长文本或日历消息可能超出范围。",
    );
  } else {
    result.format = "Classic 用户区可读文本";
    result.warnings.push(
      "Classic 尚未实现 NDEF 扇区映射；仅提取普通用户块的可读文本，不跨制造商块、扇区尾块或缺失地址拼接。",
    );
    for (const part of segments) extractText(result, part);
  }
  result.warnings = [...new Set(result.warnings)];
  return result;
}
