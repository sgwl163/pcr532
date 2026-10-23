import { act, cleanup, render, screen, waitFor } from "@testing-library/react";
import userEvent from "@testing-library/user-event";
import { afterEach, describe, expect, it, vi } from "vitest";

import { CardPanel } from "../src/components/card-panel";
import { ReaderPanel } from "../src/components/reader-panel";
import { type CardInfo } from "../src/lib/cards";
import { ReaderController, type DeviceSnapshot, type ReaderApi } from "../src/lib/reader";

const card: CardInfo = { uid: "04112233445566", uidLength: 7, atqa: "0004", sak: "08", family: "classic1k", typeName: "MIFARE Classic 1K（初步识别）" };
const connection = { portName: "COM7", baudRate: 115200, chip: "PN532", firmwareVersion: "1.6", support: 7 };
const port = { portName: "COM7", label: "CH340 (COM7)", transport: "usb" as const, vid: "1A86", pid: "7523", manufacturer: null, serialNumber: null, isCandidate: true };

async function fixture(currentCard: CardInfo = card, options: { partial?: boolean } = {}) {
  let snapshot: DeviceSnapshot = { ports: [port], connection, connectionError: null };
  const reads: unknown[] = [];
  const api: ReaderApi = {
    snapshot: vi.fn(async () => snapshot),
    connect: vi.fn(async () => connection),
    disconnect: vi.fn(async () => { snapshot = { ...snapshot, connection: null }; }),
    scanCard: vi.fn(async () => currentCard),
    readCard: vi.fn(async (request) => {
      reads.push({ ...request });
      return {
        card: currentCard, mode: request.mode, rows: [{ address: request.start, hex: request.mode === "type2" ? "00112233" : "00112233445566778899AABBCCDDEEFF" }],
        complete: !options.partial, error: options.partial ? "地址 5：卡片未应答" : null,
      };
    }),
  };
  const controller = new ReaderController(api, { autoConnect: false });
  await controller.refresh();
  return { api, controller, reads };
}

afterEach(cleanup);

describe("card panel desktop UI", () => {
  it("starts disabled without a verified device and never scans automatically", async () => {
    const f = await fixture();
    await f.controller.disconnect();
    render(<CardPanel controller={f.controller} />);
    expect(screen.getByRole("button", { name: "寻卡 / 重新识别" }).hasAttribute("disabled")).toBe(true);
    expect(screen.getByText("连接读卡器后开始寻卡")).toBeTruthy();
    expect(f.api.scanCard).not.toHaveBeenCalled();
  });

  it("identifies a card, shows raw identity, submits one known key and clears the input", async () => {
    const user = userEvent.setup();
    const f = await fixture();
    render(<CardPanel controller={f.controller} />);
    await user.click(screen.getByRole("button", { name: "寻卡 / 重新识别" }));
    expect(await screen.findByText("04 11 22 33 44 55 66")).toBeTruthy();
    expect(screen.getByText("MIFARE Classic 1K（初步识别）")).toBeTruthy();
    const keyInput = screen.getByLabelText("已知密钥（6 字节）") as HTMLInputElement;
    expect(keyInput.type).toBe("password");
    expect(keyInput.value).toBe("");
    await user.clear(screen.getByLabelText("起始块地址"));
    await user.type(screen.getByLabelText("起始块地址"), "4");
    await user.selectOptions(screen.getByLabelText("认证密钥类型"), "B");
    await user.type(keyInput, "112233445566");
    await user.click(screen.getByRole("button", { name: "读取所选范围" }));
    expect(await screen.findByText("所选范围读取完成")).toBeTruthy();
    expect(screen.getByText("00 11 22 33 44 55 66 77 88 99 AA BB CC DD EE FF")).toBeTruthy();
    expect(f.reads).toEqual([{ uid: card.uid, mode: "classic", start: 4, count: 1, keyType: "B", key: "112233445566" }]);
    expect(keyInput.value).toBe("");
    await user.click(screen.getByRole("button", { name: "清除结果" }));
    expect(screen.queryByText("所选范围读取完成")).toBeNull();
    expect(screen.queryByLabelText("已知密钥（6 字节）")).toBeNull();
  });

  it("rejects a range exceeding capacity before contacting the device", async () => {
    const f = await fixture({ ...card, family: "type2", sak: "00" });
    const user = userEvent.setup();
    render(<CardPanel controller={f.controller} />);
    await user.click(screen.getByRole("button", { name: "寻卡 / 重新识别" }));
    expect(screen.queryByLabelText("已知密钥（6 字节）")).toBeNull();
    await user.clear(screen.getByLabelText("起始页地址"));
    await user.type(screen.getByLabelText("起始页地址"), "15");
    await user.clear(screen.getByLabelText("读取数量（页）"));
    await user.type(screen.getByLabelText("读取数量（页）"), "2");
    await user.click(screen.getByRole("button", { name: "读取所选范围" }));
    expect(await screen.findByRole("alert")).toHaveProperty("textContent", "读取范围须在 0–15 页内。");
    expect(f.api.readCard).not.toHaveBeenCalled();
  });

  it("reads Type 2 pages without presenting or sending credentials", async () => {
    const f = await fixture({ ...card, family: "type2", sak: "00", typeName: "Ultralight / NTAG 等（初步识别）" });
    const user = userEvent.setup();
    render(<CardPanel controller={f.controller} />);
    await user.click(screen.getByRole("button", { name: "寻卡 / 重新识别" }));
    expect(screen.queryByLabelText("已知密钥（6 字节）")).toBeNull();
    await user.click(screen.getByRole("button", { name: "读取所选范围" }));
    expect(await screen.findByText("所选范围读取完成")).toBeTruthy();
    expect(screen.getByText("00 11 22 33")).toBeTruthy();
    expect(f.reads).toEqual([{ uid: card.uid, mode: "type2", start: 0, count: 1, keyType: null, key: null }]);
  });

  it("shows no-card and failed scans without retaining old identity", async () => {
    const f = await fixture();
    await f.controller.findCard();
    const user = userEvent.setup();
    render(<CardPanel controller={f.controller} />);
    f.api.scanCard = vi.fn(async () => null);
    await user.click(screen.getByRole("button", { name: "寻卡 / 重新识别" }));
    expect(await screen.findByText("感应区未发现卡片")).toBeTruthy();
    expect(screen.queryByText("04 11 22 33 44 55 66")).toBeNull();
    f.api.scanCard = vi.fn(async () => { throw new Error("寻卡响应无效"); });
    await user.click(screen.getByRole("button", { name: "寻卡 / 重新识别" }));
    expect(await screen.findByText("卡片操作失败")).toBeTruthy();
    expect(screen.getByText("寻卡响应无效")).toBeTruthy();
  });

  it("shows unsupported cards as identification-only with no read form", async () => {
    const f = await fixture({ ...card, family: "iso14443_4", typeName: "ISO 14443-4 A（仅识别）" });
    const user = userEvent.setup();
    render(<CardPanel controller={f.controller} />);
    await user.click(screen.getByRole("button", { name: "寻卡 / 重新识别" }));
    expect(await screen.findByText("此类型当前仅支持识别，暂不支持数据读取。")).toBeTruthy();
    expect(screen.queryByRole("button", { name: "读取所选范围" })).toBeNull();
  });

  it("preserves partial rows and labels an incomplete read", async () => {
    const f = await fixture(card, { partial: true });
    await f.controller.findCard();
    render(<CardPanel controller={f.controller} />);
    const user = userEvent.setup();
    await user.type(screen.getByLabelText("已知密钥（6 字节）"), "112233445566");
    await user.click(screen.getByRole("button", { name: "读取所选范围" }));
    expect(await screen.findByText("读取未完成")).toBeTruthy();
    expect(screen.getByText(/地址 5：卡片未应答/)).toBeTruthy();
    expect(screen.queryByText("所选范围读取完成")).toBeNull();
    expect(screen.getAllByRole("row")).toHaveLength(2);
  });

  it("clears identity, data and key form when disconnected", async () => {
    const f = await fixture();
    await f.controller.findCard();
    render(<CardPanel controller={f.controller} />);
    const user = userEvent.setup();
    await user.type(screen.getByLabelText("已知密钥（6 字节）"), "112233445566");
    await act(async () => { await f.controller.disconnect(); });
    expect(screen.queryByLabelText("已知密钥（6 字节）")).toBeNull();
    expect(screen.queryByText("04 11 22 33 44 55 66")).toBeNull();
    expect(screen.getByText("连接读卡器后开始寻卡")).toBeTruthy();
  });

  it("blocks duplicate card commands and disconnect while a card command is running", async () => {
    const f = await fixture();
    let finish!: (card: CardInfo | null) => void;
    f.api.scanCard = vi.fn(() => new Promise<CardInfo | null>((resolve) => { finish = resolve; }));
    const user = userEvent.setup();
    render(<><ReaderPanel controller={f.controller} /><CardPanel controller={f.controller} /></>);
    await user.click(screen.getByRole("button", { name: "寻卡 / 重新识别" }));
    await waitFor(() => expect(screen.getByRole("button", { name: "断开连接" }).hasAttribute("disabled")).toBe(true));
    expect(screen.getByRole("button", { name: "正在寻卡…" }).hasAttribute("disabled")).toBe(true);
    await act(async () => { finish(card); });
    await screen.findByText("04 11 22 33 44 55 66");
    await waitFor(() => expect(screen.getByRole("button", { name: "断开连接" }).hasAttribute("disabled")).toBe(false));
    expect(f.api.scanCard).toHaveBeenCalledTimes(1);
  });
});
