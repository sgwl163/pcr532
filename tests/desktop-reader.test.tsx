import { beforeEach, expect, it, vi } from "vitest";
import { invoke, isTauri } from "@tauri-apps/api/core";
import { readerApi } from "../src/lib/desktop-reader";

vi.mock("@tauri-apps/api/core", () => ({
  invoke: vi.fn().mockResolvedValue(undefined),
  isTauri: vi.fn().mockReturnValue(true),
}));
beforeEach(() => {
  vi.mocked(invoke).mockClear();
  vi.mocked(isTauri).mockReturnValue(true);
});

it("explains browser preview limitations without invoking desktop commands", async () => {
  vi.mocked(isTauri).mockReturnValue(false);
  await expect(readerApi.snapshot()).rejects.toThrow("浏览器预览不能访问 PN532 读卡器");
  await expect(readerApi.scanCard()).rejects.toThrow("请运行 PCR532 桌面程序");
  expect(invoke).not.toHaveBeenCalled();
});

it("maps the desktop bridge to registered device and restricted read/write commands", async () => {
  await readerApi.snapshot();
  await readerApi.connect("COM7", 115200);
  await readerApi.disconnect();
  await readerApi.scanCard();
  const request = {
    uid: "04112233445566",
    mode: "type2" as const,
    start: 0,
    count: 4,
    keyType: null,
    key: null,
  };
  await readerApi.readCard(request);
  const writeRequest = {
    uid: request.uid,
    mode: "type2" as const,
    address: 4,
    hex: "AABBCCDD",
    expectedHex: "00112233",
    keyType: null,
    key: null,
    confirmed: true,
  };
  await readerApi.writeCard(writeRequest);
  const dictionary = {
    runId: "run",
    uid: "12345678",
    startSector: 0,
    sectorCount: 1,
    useCommonKeys: true,
    keys: [],
    confirmed: true,
  };
  await readerApi.checkDictionary(dictionary);
  await readerApi.dictionaryProgress("run");
  await readerApi.cancelDictionary("run");
  expect(vi.mocked(invoke).mock.calls).toEqual([
    ["get_device_snapshot"],
    ["connect_reader", { portName: "COM7", baudRate: 115200 }],
    ["disconnect_reader"],
    ["scan_card"],
    ["read_card", { request }],
    ["write_card", { request: writeRequest }],
    ["check_dictionary", { request: dictionary }],
    ["dictionary_progress", { runId: "run" }],
    ["cancel_dictionary", { runId: "run" }],
  ]);
});
