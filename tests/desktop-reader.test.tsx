import { beforeEach, expect, it, vi } from "vitest";
import { invoke } from "@tauri-apps/api/core";
import { readerApi } from "../src/lib/desktop-reader";

vi.mock("@tauri-apps/api/core", () => ({ invoke: vi.fn().mockResolvedValue(undefined) }));
beforeEach(() => vi.mocked(invoke).mockClear());

it("maps the desktop bridge to registered device and read-only card commands", async () => {
  await readerApi.snapshot();
  await readerApi.connect("COM7", 115200);
  await readerApi.disconnect();
  await readerApi.scanCard();
  const request = { uid: "04112233445566", mode: "type2" as const, start: 0, count: 4, keyType: null, key: null };
  await readerApi.readCard(request);
  expect(vi.mocked(invoke).mock.calls).toEqual([
    ["get_device_snapshot"],
    ["connect_reader", { portName: "COM7", baudRate: 115200 }],
    ["disconnect_reader"],
    ["scan_card"],
    ["read_card", { request }],
  ]);
});
