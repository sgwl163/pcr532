// Read-only inspection of caller-selected card dump files. Never opens a reader.
import { readFile } from "node:fs/promises";
import { createHash } from "node:crypto";
import { analyzeCardData } from "../src/lib/nfc-data.ts";

const summaryOnly = process.argv.includes("--summary");
const paths = process.argv.slice(2).filter(arg => arg !== "--summary");
if (!paths.length) throw new Error("Pass explicit dump file paths.");
const digest = bytes => createHash("sha256").update(bytes).digest("hex");
const hex = bytes => Buffer.from(bytes).toString("hex").toUpperCase();
const trailer = address => address < 128 ? address % 4 === 3 : (address - 128) % 16 === 15;
const sector = address => address < 128 ? Math.floor(address / 4) : 32 + Math.floor((address - 128) / 16);
const files = [];
const snapshots = [];
for (const path of paths) {
  const data = await readFile(path);
  snapshots.push(data);
  if (data.length > 1024 * 1024) throw new Error("Input exceeds 1 MiB inspection limit.");
  const kind = new Map([[320, "Classic Mini-sized raw candidate"], [1024, "Classic 1K-sized raw candidate"], [4096, "Classic 4K-sized raw candidate"]]).get(data.length);
  const file = { path, bytes: data.length, sha256: digest(data), formatCandidate: kind ?? "unrecognized size", headerHex: hex(data.subarray(0, 32)) };
  if (kind) {
    const keyGroups = new Map();
    const keyGroup = key => {
      const id = hex(key);
      if (!keyGroups.has(id)) keyGroups.set(id, { group: `K${keyGroups.size + 1}`, allFF: key.every(b => b === 255), all00: key.every(b => b === 0), count: 0 });
      const entry = keyGroups.get(id); entry.count++;
      return entry.group;
    };
    const uid = data.subarray(0, 4);
    file.manufacturerBlock = { hex: hex(data.subarray(0, 16)), conventionalUid4: hex(uid), bccMatchesUid4: uid.reduce((x, b) => x ^ b, 0) === data[4] };
    file.blocks = [];
    file.trailers = [];
    file.valueBlocks = [];
    for (let address = 0; address < data.length / 16; address++) {
      const bytes = data.subarray(address * 16, address * 16 + 16);
      if (trailer(address)) {
        const [b6, b7, b8] = bytes.subarray(6, 9);
        const valid = ((b6 & 15) ^ (b7 >> 4)) === 15 && ((b6 >> 4) ^ (b8 & 15)) === 15 && ((b7 & 15) ^ (b8 >> 4)) === 15;
        file.trailers.push({ address, sector: sector(address), keyAGroup: keyGroup(bytes.subarray(0, 6)), keyBGroup: keyGroup(bytes.subarray(10, 16)), accessHex: hex(bytes.subarray(6, 10)), accessRedundancyValid: valid });
      } else {
        file.blocks.push({ address, sector: sector(address), zero: bytes.every(b => b === 0), hex: hex(bytes), ascii: [...bytes].map(b => b >= 32 && b <= 126 ? String.fromCharCode(b) : ".").join("") });
        if (address > 0 && [0,1,2,3].every(i => bytes[i] === bytes[i + 8] && (bytes[i] ^ bytes[i + 4]) === 255) && bytes[12] === bytes[14] && bytes[13] === bytes[15] && (bytes[12] ^ bytes[13]) === 255) {
          file.valueBlocks.push({ address, value: bytes.readInt32LE(0), storedAddress: bytes[12] });
        }
      }
    }
    file.keyGroups = [...keyGroups.values()];
    file.zeroDataBlocks = file.blocks.filter(b => b.address !== 0 && b.zero).length;
    // Family here is a layout assumption for the offline parser, not live chip detection.
    file.offlineTextAnalysis = analyzeCardData({
      card: { uid: hex(uid), uidLength: 4, atqa: "", sak: "", family: ({320: "classicMini", 1024: "classic1k", 4096: "classic4k"})[data.length], typeName: kind },
      mode: "classic", complete: true, error: null,
      rows: file.blocks.map(({ address, hex }) => ({ address, hex })),
    });
  }
  files.push(file);
}
const comparisons = [];
for (let i = 0; i < files.length; i++) for (let j = i + 1; j < files.length; j++) {
  const a = snapshots[i], b = snapshots[j];
  const differentOffsets = Array.from({ length: Math.min(a.length, b.length) }, (_, n) => n).filter(n => a[n] !== b[n]);
  comparisons.push({ a: paths[i], b: paths[j], equalSize: a.length === b.length, differentBytesInOverlap: differentOffsets.length,
    differentBlocks: [...new Set(differentOffsets.map(n => Math.floor(n / 16)))],
    dataBlockDifferences: files[i].blocks?.filter(row => row.address !== 0 && !trailer(row.address)).flatMap(row => {
      const address = row.address;
      if (!differentOffsets.some(n => Math.floor(n / 16) === address)) return [];
      return [{ address, sector: sector(address), a: hex(a.subarray(address * 16, address * 16 + 16)), b: hex(b.subarray(address * 16, address * 16 + 16)), byteOffsets: differentOffsets.filter(n => Math.floor(n / 16) === address).map(n => n % 16) }];
    }) });
}
// Confirm inputs still match the analyzed snapshots; nothing is written to the dumps.
for (let i = 0; i < paths.length; i++) {
  files[i].unchangedAfterInspection = digest(await readFile(paths[i])) === files[i].sha256;
}
const outputFiles = summaryOnly ? files.map(({ blocks, trailers, headerHex, ...rest }) => ({
  ...rest,
  blockCount: blocks && trailers ? blocks.length + trailers.length : undefined,
  trailerCount: trailers?.length,
  accessHex: [...new Set(trailers?.map(row => row.accessHex) ?? [])],
  validAccessTrailers: trailers?.filter(row => row.accessRedundancyValid).length,
})) : files;
console.log(JSON.stringify({ files: outputFiles, comparisons }, null, 2));
