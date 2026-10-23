import assert from "node:assert/strict";
import test from "node:test";
import { type CardDump, type CardInfo, type ReadRequest } from "../src/lib/cards.ts";
import {
  BAUD_RATES,
  choosePort,
  initialReaderState,
  ReaderController,
  readerStatus,
  type DeviceSnapshot,
  type ReaderApi,
  type ReaderConnection,
  type SerialDevice,
} from "../src/lib/reader.ts";

const port: SerialDevice = {
  portName: "COM7", label: "USB-SERIAL CH340 (COM7)", transport: "usb",
  vid: "1A86", pid: "7523", manufacturer: "wch.cn", serialNumber: null,
  isCandidate: true,
};
const connection: ReaderConnection = {
  portName: "COM7", baudRate: 115200, chip: "PN532", firmwareVersion: "1.6", support: 7,
};
const detected: DeviceSnapshot = { ports: [port], connection: null, connectionError: null };
const connected: DeviceSnapshot = { ...detected, connection };
const card: CardInfo = { uid: "12345678", uidLength: 4, atqa: "0004", sak: "08", family: "classic1k", typeName: "MIFARE Classic 1K（初步识别）" };
function readRequest(): ReadRequest {
  return { uid: card.uid, mode: "classic", start: 4, count: 1, keyType: "A", key: "112233445566" };
}

function fixture() {
  let snapshot = detected;
  const calls: string[] = [];
  const api: ReaderApi = {
    async snapshot() { calls.push("snapshot"); return snapshot; },
    async connect(name, baud) {
      calls.push(`connect:${name}:${baud}`);
      snapshot = { ...connected, connection: { ...connection, baudRate: baud } };
      return snapshot.connection!;
    },
    async disconnect() { calls.push("disconnect"); snapshot = detected; },
    async scanCard() { calls.push("scanCard"); return card; },
    async readCard(request) {
      calls.push(`readCard:${request.uid}`);
      return { card, mode: request.mode, rows: [{ address: request.start, hex: "00".repeat(16) }], complete: true, error: null };
    },
  };
  return { api, calls, setSnapshot(value: DeviceSnapshot) { snapshot = value; } };
}

function deferred<T>() {
  let resolve: (value: T) => void = () => { throw new Error("not initialized"); };
  const promise = new Promise<T>((done) => { resolve = done; });
  return { promise, resolve };
}

test("startup begins by detecting system serial ports", () => {
  assert.equal(readerStatus(initialReaderState()).title, "正在检测系统串口");
});

test("only a single candidate is selected automatically; existing selection is preserved", () => {
  const unknown = { ...port, portName: "COM9", isCandidate: false };
  assert.equal(choosePort([port, unknown], ""), "COM7");
  assert.equal(choosePort([port, unknown], "COM9"), "COM9");
  assert.equal(choosePort([port, { ...port, portName: "COM8" }], ""), "");
  assert.equal(choosePort([unknown], "COM7"), "");
});

test("detecting an inserted adapter reports discovered, never falsely connected", async () => {
  const f = fixture();
  const reader = new ReaderController(f.api, { autoConnect: false });
  await reader.refresh();
  assert.equal(reader.getState().selectedPort, "COM7");
  assert.match(readerStatus(reader.getState()).title, /已发现 1 个串口/);
  assert.equal(readerStatus(reader.getState()).kind, "neutral");
  assert.deepEqual(f.calls, ["snapshot"]);
});

test("verified connection uses selected baud rate and reports chip and firmware", async () => {
  const f = fixture();
  const reader = new ReaderController(f.api, { autoConnect: false });
  await reader.refresh();
  reader.selectBaud(9600);
  reader.selectBaud(123);
  assert.ok(BAUD_RATES.includes(reader.getState().baudRate));
  await reader.connect();
  assert.ok(f.calls.includes("connect:COM7:9600"));
  assert.equal(readerStatus(reader.getState()).title, "已连接 PN532");
  assert.match(readerStatus(reader.getState()).detail, /COM7 · 9600 baud · 固件 1.6/);
  reader.selectPort("COM9");
  reader.selectBaud(115200);
  assert.equal(reader.getState().selectedPort, "COM7");
  assert.equal(reader.getState().baudRate, 9600);
});

test("disconnect clears verified state and allows reconnect", async () => {
  const f = fixture();
  const reader = new ReaderController(f.api, { autoConnect: false });
  await reader.refresh();
  await reader.connect();
  await reader.disconnect();
  assert.equal(reader.getState().snapshot?.connection, null);
  await reader.connect();
  assert.equal(reader.getState().snapshot?.connection?.chip, "PN532");
});

test("failed scan never displays a stale connection as currently verified", async () => {
  const f = fixture();
  const reader = new ReaderController(f.api, { autoConnect: false });
  await reader.refresh();
  await reader.connect();
  f.api.snapshot = async () => { throw new Error("枚举失败"); };
  await reader.refresh();
  assert.equal(readerStatus(reader.getState()).kind, "error");
  assert.match(readerStatus(reader.getState()).detail, /枚举失败/);
  assert.equal(reader.getState().activity, "idle");
});

test("removal clears connection and reinsertion does not claim a successful handshake", async () => {
  const f = fixture();
  const reader = new ReaderController(f.api, { autoConnect: false });
  await reader.refresh();
  await reader.connect();
  f.setSnapshot({ ports: [], connection: null, connectionError: "COM7 已移除" });
  await reader.refresh();
  assert.equal(reader.getState().selectedPort, "");
  assert.equal(readerStatus(reader.getState()).kind, "error");
  f.setSnapshot(detected);
  await reader.refresh();
  assert.equal(reader.getState().selectedPort, "COM7");
  assert.match(readerStatus(reader.getState()).title, /已发现/);
});

test("connection errors remain visible until retry or changing selection", async () => {
  const f = fixture();
  f.api.connect = async () => { throw new Error("串口被占用"); };
  const reader = new ReaderController(f.api, { autoConnect: false });
  await reader.refresh();
  await reader.connect();
  await reader.refresh();
  assert.match(readerStatus(reader.getState()).detail, /串口被占用/);
  reader.selectBaud(9600);
  assert.equal(reader.getState().actionError, null);
});

test("disconnect failure is visible even when the last connection remains active", async () => {
  const f = fixture();
  f.api.disconnect = async () => { throw new Error("后端不可用"); };
  const reader = new ReaderController(f.api, { autoConnect: false });
  await reader.refresh();
  await reader.connect();
  await reader.disconnect();
  const status = readerStatus(reader.getState());
  assert.equal(status.kind, "error");
  assert.match(status.detail, /断开失败/);
});

test("polling is deduplicated", async () => {
  const f = fixture();
  const pending = deferred<DeviceSnapshot>();
  f.api.snapshot = async () => { f.calls.push("snapshot"); return pending.promise; };
  const reader = new ReaderController(f.api, { autoConnect: false });
  const first = reader.refresh();
  const second = reader.refresh();
  pending.resolve(detected);
  await Promise.all([first, second]);
  assert.deepEqual(f.calls, ["snapshot"]);
});

test("a pending scan cannot reset a queued connection to idle", async () => {
  const f = fixture();
  const reader = new ReaderController(f.api, { autoConnect: false });
  await reader.refresh();
  const pending = deferred<DeviceSnapshot>();
  f.api.snapshot = () => pending.promise;
  const scan = reader.refresh();
  await Promise.resolve();
  const action = reader.connect();
  const activities: string[] = [];
  const unsubscribe = reader.subscribe(() => { activities.push(reader.getState().activity); });
  pending.resolve(detected);
  await scan;
  assert.ok(!activities.includes("idle"), "poll must not report idle before the queued action completes");
  f.api.snapshot = async () => connected;
  await action;
  unsubscribe();
  assert.equal(reader.getState().activity, "idle");
});

test("duplicate actions and refreshes cannot race a pending connection", async () => {
  const f = fixture();
  const pending = deferred<ReaderConnection>();
  f.api.connect = async () => { f.calls.push("connect"); return pending.promise; };
  const reader = new ReaderController(f.api, { autoConnect: false });
  await reader.refresh();
  const first = reader.connect();
  await reader.connect();
  await reader.refresh();
  await reader.disconnect();
  f.setSnapshot(connected);
  pending.resolve(connection);
  await first;
  assert.deepEqual(f.calls, ["snapshot", "connect", "snapshot"]);
});

test("non-USB ports are described without claiming USB recognition", () => {
  const state = initialReaderState();
  state.snapshot = { ...detected, ports: [{ ...port, transport: "unknown", isCandidate: false }] };
  assert.ok(!readerStatus(state).detail.includes("USB 设备已被系统识别"));
});

test("startup automatically verifies one candidate at 115200", async () => {
  const f = fixture();
  const reader = new ReaderController(f.api);
  await reader.refresh();
  assert.equal(readerStatus(reader.getState()).title, "已连接 PN532");
  assert.deepEqual(f.calls, ["snapshot", "connect:COM7:115200", "snapshot"]);
});

test("automatic connection waits for firmware confirmation before reporting connected", async () => {
  const f = fixture();
  const pending = deferred<ReaderConnection>();
  f.api.connect = async () => { f.calls.push("connect"); return pending.promise; };
  const reader = new ReaderController(f.api);
  const refresh = reader.refresh();
  for (let i = 0; i < 8; i++) await Promise.resolve();
  assert.equal(reader.getState().activity, "connecting");
  assert.notEqual(readerStatus(reader.getState()).kind, "success");
  f.setSnapshot(connected);
  pending.resolve(connection);
  await refresh;
  assert.equal(readerStatus(reader.getState()).kind, "success");
});

test("multiple or unknown candidates require explicit port selection", async () => {
  for (const ports of [[port, { ...port, portName: "COM8" }], [{ ...port, isCandidate: false }]]) {
    const f = fixture();
    f.setSnapshot({ ...detected, ports });
    const reader = new ReaderController(f.api);
    await reader.refresh();
    assert.equal(reader.getState().snapshot?.connection, null);
    assert.deepEqual(f.calls, ["snapshot"]);
  }
});

test("failed automatic handshake is attempted once, with manual retry available", async () => {
  const f = fixture();
  f.api.connect = async () => { f.calls.push("failed-connect"); throw new Error("串口被占用"); };
  const reader = new ReaderController(f.api);
  await reader.refresh();
  await reader.refresh();
  assert.equal(f.calls.filter((call) => call === "failed-connect").length, 1);
  assert.match(readerStatus(reader.getState()).detail, /串口被占用/);
  await reader.connect();
  assert.equal(f.calls.filter((call) => call === "failed-connect").length, 2);
});

test("manual disconnect stays disconnected until manual retry or physical reinsertion", async () => {
  const f = fixture();
  const reader = new ReaderController(f.api);
  await reader.refresh();
  await reader.disconnect();
  await reader.refresh();
  assert.equal(reader.getState().snapshot?.connection, null);
  assert.equal(f.calls.filter((call) => call.startsWith("connect:")).length, 1);
  f.setSnapshot({ ports: [], connection: null, connectionError: null });
  await reader.refresh();
  f.setSnapshot(detected);
  await reader.refresh();
  assert.equal(readerStatus(reader.getState()).kind, "success");
  assert.equal(f.calls.filter((call) => call.startsWith("connect:")).length, 2);
});

test("card operations require a verified connection and identify only on request", async () => {
  const f = fixture();
  const reader = new ReaderController(f.api, { autoConnect: false });
  await reader.refresh();
  await reader.findCard();
  assert.ok(!f.calls.includes("scanCard"));
  await reader.connect();
  assert.ok(!f.calls.includes("scanCard"));
  await reader.findCard();
  assert.equal(reader.getState().cardState.card?.uid, card.uid);
  assert.ok(reader.getState().cardState.checkedAt);
  assert.deepEqual(f.calls.slice(-2), ["scanCard", "snapshot"]);
});

test("no card is a successful identification result and clears the previous data", async () => {
  const f = fixture();
  const reader = new ReaderController(f.api);
  await reader.refresh();
  await reader.findCard();
  await reader.readCard(readRequest());
  f.api.scanCard = async () => null;
  await reader.findCard();
  assert.deepEqual(reader.getState().cardState, { card: null, dump: null, error: null, checkedAt: reader.getState().cardState.checkedAt });
  assert.ok(reader.getState().cardState.checkedAt);
});

test("card read is serialized with heartbeat and duplicate actions are ignored", async () => {
  const f = fixture();
  const reader = new ReaderController(f.api);
  await reader.refresh();
  await reader.findCard();
  const pending = deferred<CardDump>();
  f.api.readCard = async () => { f.calls.push("read"); return pending.promise; };
  const request = readRequest();
  const result = reader.readCard(request);
  await Promise.resolve();
  await reader.refresh();
  await reader.findCard();
  await reader.readCard(readRequest());
  await reader.disconnect();
  reader.clearCard();
  assert.equal(reader.getState().activity, "readingCard");
  assert.equal(f.calls.at(-1), "read");
  pending.resolve({ card, mode: "classic", rows: [{ address: 4, hex: "00".repeat(16) }], complete: true, error: null });
  await result;
  assert.deepEqual(f.calls.slice(-2), ["read", "snapshot"]);
  assert.equal(reader.getState().cardState.dump?.complete, true);
  assert.equal(request.key, null);
  assert.ok(!JSON.stringify(reader.getState()).includes("112233445566"));
});

test("partial read preserves rows and never becomes a successful complete dump", async () => {
  const f = fixture();
  f.api.readCard = async () => ({ card, mode: "classic", rows: [{ address: 4, hex: "00".repeat(16) }], complete: false, error: "地址 5：卡片未应答" });
  const reader = new ReaderController(f.api);
  await reader.refresh();
  await reader.findCard();
  await reader.readCard(readRequest());
  assert.equal(reader.getState().cardState.dump?.complete, false);
  assert.equal(reader.getState().cardState.dump?.rows.length, 1);
  assert.match(reader.getState().cardState.dump?.error ?? "", /地址 5/);
});

test("a pending heartbeat losing the connection cancels a queued card command", async () => {
  const f = fixture();
  const reader = new ReaderController(f.api);
  await reader.refresh();
  const pending = deferred<DeviceSnapshot>();
  f.api.snapshot = () => pending.promise;
  const heartbeat = reader.refresh();
  await Promise.resolve();
  const find = reader.findCard();
  pending.resolve({ ports: [], connection: null, connectionError: "已拔出" });
  await Promise.all([heartbeat, find]);
  assert.ok(!f.calls.includes("scanCard"));
  assert.equal(reader.getState().activity, "idle");
});

test("disconnect, heartbeat failure and removal clear card identity and data", async () => {
  for (const action of ["disconnect", "error", "removal"] as const) {
    const f = fixture();
    const reader = new ReaderController(f.api);
    await reader.refresh();
    await reader.findCard();
    if (action === "disconnect") await reader.disconnect();
    else {
      if (action === "error") f.api.snapshot = async () => { throw new Error("枚举失败"); };
      else f.setSnapshot({ ports: [], connection: null, connectionError: "已拔出" });
      await reader.refresh();
    }
    assert.equal(reader.getState().cardState.card, null);
    assert.equal(reader.getState().cardState.dump, null);
  }
});

test("mismatched request never reaches the backend and failed activation requires a new scan", async () => {
  const f = fixture();
  const reader = new ReaderController(f.api);
  await reader.refresh();
  await reader.findCard();
  await reader.readCard({ ...readRequest(), uid: "99887766" });
  assert.ok(!f.calls.some((call) => call.startsWith("readCard:")));
  f.api.readCard = async () => { throw new Error("卡片已更换"); };
  const request = readRequest();
  await reader.readCard(request);
  assert.equal(reader.getState().cardState.card, null);
  assert.match(reader.getState().cardState.error ?? "", /已更换/);
  assert.equal(request.key, null);
});

test("an interrupted connection is not probed repeatedly while the device remains present", async () => {
  const f = fixture();
  const reader = new ReaderController(f.api);
  await reader.refresh();
  f.setSnapshot({ ...detected, connectionError: "PN532 心跳超时" });
  await reader.refresh();
  await reader.refresh();
  assert.equal(readerStatus(reader.getState()).kind, "error");
  assert.equal(f.calls.filter((call) => call.startsWith("connect:")).length, 1);
});
