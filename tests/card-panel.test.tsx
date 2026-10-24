import {
  act,
  cleanup,
  render,
  screen,
  waitFor,
  within,
} from "@testing-library/react";
import userEvent from "@testing-library/user-event";
import { afterEach, describe, expect, it, vi } from "vitest";

import { CardPanel } from "../src/components/card-panel";
import { ReaderPanel } from "../src/components/reader-panel";
import type {
  DictionaryRequest,
  DictionaryResult,
} from "../src/lib/dictionary";
import { type CardDump, type CardInfo } from "../src/lib/cards";
import {
  ReaderController,
  type DeviceSnapshot,
  type ReaderApi,
} from "../src/lib/reader";

const card: CardInfo = {
  uid: "04112233445566",
  uidLength: 7,
  atqa: "0004",
  sak: "08",
  family: "classic1k",
  typeName: "MIFARE Classic 1K（初步识别）",
};
const connection = {
  portName: "COM7",
  baudRate: 115200,
  chip: "PN532",
  firmwareVersion: "1.6",
  support: 7,
};
const port = {
  portName: "COM7",
  label: "CH340 (COM7)",
  transport: "usb" as const,
  vid: "1A86",
  pid: "7523",
  manufacturer: null,
  serialNumber: null,
  isCandidate: true,
};

async function fixture(
  currentCard: CardInfo = card,
  options: { partial?: boolean } = {},
) {
  let snapshot: DeviceSnapshot = {
    ports: [port],
    connection,
    connectionError: null,
  };
  const reads: unknown[] = [];
  const writes: unknown[] = [];
  const api: ReaderApi = {
    snapshot: vi.fn(async () => snapshot),
    connect: vi.fn(async () => connection),
    disconnect: vi.fn(async () => {
      snapshot = { ...snapshot, connection: null };
    }),
    scanCard: vi.fn(async () => currentCard),
    checkDictionary: vi.fn(async () => {
      throw new Error("not configured");
    }),
    dictionaryProgress: vi.fn(async () => null),
    cancelDictionary: vi.fn(async () => true),
    writeCard: vi.fn(async (request) => {
      writes.push({ ...request });
      return {
        card: currentCard,
        mode: request.mode,
        address: request.address,
        beforeHex: request.expectedHex,
        afterHex: request.hex,
        writeAttempted: true,
        verified: true,
        error: null,
      };
    }),
    readCard: vi.fn(async (request) => {
      reads.push({ ...request });
      return {
        card: currentCard,
        mode: request.mode,
        rows: [
          {
            address: request.start,
            hex:
              request.mode === "type2"
                ? "00112233"
                : "00112233445566778899AABBCCDDEEFF",
          },
        ],
        complete: !options.partial,
        error: options.partial ? "地址 5：卡片未应答" : null,
      };
    }),
  };
  const controller = new ReaderController(api, { autoConnect: false });
  await controller.refresh();
  return { api, controller, reads, writes };
}

it("imports an offline dump, links the reference date to its bytes and blocks device operations", async () => {
  const f = await fixture();
  const user = userEvent.setup();
  const bytes = new Uint8Array(1024);
  bytes.set([0x37, 0x5f], 5 * 16 + 10);
  const file = new File([bytes], "授权测试.dump");
  Object.defineProperty(file, "arrayBuffer", { value: async () => bytes.buffer });
  render(<CardPanel controller={f.controller} />);
  await user.upload(screen.getByLabelText("选择离线 dump 文件"), file);
  expect(await screen.findByText("文件完整载入（非实卡验证）")).toBeTruthy();
  const acquisition = screen.getByRole("region", { name: "数据获取状态" });
  expect(within(acquisition).getByText("离线文件已载入 1024 B · 64 块")).toBeTruthy();
  expect(within(acquisition).getByText(/已取得原始字节不等于已解密业务字段/)).toBeTruthy();
  expect(screen.getByRole("tab", { name: "用户区写入" }).hasAttribute("disabled")).toBe(true);
  expect(screen.getByRole("button", { name: "寻卡 / 重新识别" }).matches(":disabled")).toBe(true);
  await user.click(screen.getByRole("button", { name: "参考日期" }));
  const row = screen.getByRole("rowheader", { name: /日期候选/ }).closest("tr")!;
  expect(row.parentElement?.firstElementChild).toBe(row);
  expect(within(row).getByText(/2027-10-31/)).toBeTruthy();
  await user.click(within(row).getByRole("button", { name: "定位块 5 偏移 10 长度 2" }));
  expect(screen.getByRole("button", { name: "选择块 5" }).getAttribute("aria-pressed")).toBe("true");
  expect([...screen.getByLabelText("块 5 数据").querySelectorAll(".byte-highlight")].map((element) => element.textContent?.trim())).toEqual(["37", "5F"]);
  expect(f.api.readCard).not.toHaveBeenCalled();
  expect(f.api.writeCard).not.toHaveBeenCalled();
  expect(f.api.scanCard).not.toHaveBeenCalled();
  await user.click(screen.getByRole("button", { name: "关闭离线文件" }));
  expect(screen.queryByText("日期候选（截图参考规则）")).toBeNull();
});

it("keeps search and manual interpretation linked without invoking card commands", async () => {
  const f = await fixture();
  const user = userEvent.setup();
  const bytes = new Uint8Array(1024);
  bytes.set([0x37, 0x5f], 5 * 16 + 10);
  const file = new File([bytes], "本地分析.dump");
  Object.defineProperty(file, "arrayBuffer", { value: async () => bytes.buffer });
  render(<CardPanel controller={f.controller} />);
  await user.upload(screen.getByLabelText("选择离线 dump 文件"), file);
  await user.type(screen.getByRole("textbox", { name: "搜索原始数据" }), "37 5F");
  await user.click(screen.getByRole("button", { name: "查找" }));
  expect(screen.getByRole("button", { name: "选择块 5" }).getAttribute("aria-pressed")).toBe("true");
  await user.click(screen.getByText("按指定编码查看字节（人工解释）"));
  expect((screen.getByLabelText("解释数据地址") as HTMLSelectElement).value).toBe("5");
  expect((screen.getByLabelText("解释字节偏移") as HTMLInputElement).value).toBe("10");
  await user.selectOptions(screen.getByLabelText("数据解释编码"), "packed-date-2000-be");
  await user.click(screen.getByRole("button", { name: "定位解释字节" }));
  expect([...screen.getByLabelText("块 5 数据").querySelectorAll(".byte-highlight")].map(element => element.textContent?.trim())).toEqual(["37", "5F"]);
  expect(f.api.scanCard).not.toHaveBeenCalled();
  expect(f.api.readCard).not.toHaveBeenCalled();
  expect(f.api.writeCard).not.toHaveBeenCalled();
  expect(f.api.checkDictionary).not.toHaveBeenCalled();
});

it("explains CRC errors and shows acquired sector coverage without inventing missing data", async () => {
  const f = await fixture();
  f.api.readCard = vi.fn(async (): Promise<CardDump> => ({
    card, mode: "classic", complete: false,
    rows: Array.from({ length: 45 }, (_, address) => ({ address, hex: "00".repeat(16) })),
    error: "PN532 卡片操作失败（状态 02），请检查卡片类型和权限",
  }));
  await f.controller.findCard();
  await f.controller.readCard({ uid: card.uid, mode: "classic", start: 0, count: 1, keyType: "A", key: "112233445566" });
  const user = userEvent.setup();
  render(<CardPanel controller={f.controller} />);
  const status = screen.getByRole("region", { name: "数据获取状态" });
  expect(within(status).getByText(/射频响应.*CRC.*不能据此判断密钥错误/)).toBeTruthy();
  expect(within(status).getByText(/布局中未取得 19 块/)).toBeTruthy();
  await user.click(within(status).getByText(/扇区覆盖/));
  expect(within(status).getByRole("button", { name: "扇区 11：已取得 1 / 4 块" })).toBeTruthy();
  expect(within(status).getByRole("button", { name: "扇区 15：已取得 0 / 4 块" }).hasAttribute("disabled")).toBe(true);
  await user.click(within(status).getByRole("button", { name: "扇区 11：已取得 1 / 4 块" }));
  expect(screen.getByRole("button", { name: "选择块 44" }).getAttribute("aria-pressed")).toBe("true");
  expect(screen.queryByRole("button", { name: "选择块 45" })).toBeNull();
  expect(f.api.readCard).toHaveBeenCalledOnce();
  expect(f.api.checkDictionary).not.toHaveBeenCalled();
});

it("explains that identification alone has not read card memory", async () => {
  const f = await fixture();
  await f.controller.findCard();
  render(<CardPanel controller={f.controller} />);
  const status = screen.getByRole("region", { name: "数据获取状态" });
  expect(within(status).getByText("已识别卡片，尚未读取原始数据")).toBeTruthy();
  expect(within(status).getByText(/识别 UID 不等于读取用户区/)).toBeTruthy();
  expect(f.api.readCard).not.toHaveBeenCalled();
});

it("shows a zero-byte read failure in the data workspace instead of a waiting message", async () => {
  const f = await fixture();
  f.api.readCard = vi.fn(async (): Promise<CardDump> => ({
    card,
    mode: "classic",
    rows: [],
    complete: false,
    error: "块 4：认证失败",
  }));
  await f.controller.findCard();
  await f.controller.readCard({
    uid: card.uid, mode: "classic", start: 4, count: 1,
    keyType: "A", key: "112233445566",
  });
  render(<CardPanel controller={f.controller} />);
  const status = screen.getByRole("region", { name: "数据获取状态" });
  expect(within(status).getByText("本次读取未获得数据（0 B）")).toBeTruthy();
  expect(within(status).getByText("块 4：认证失败")).toBeTruthy();
  const grid = screen.getByRole("region", { name: /数据表 A/ });
  expect(within(grid).getByText("本次未获得原始数据")).toBeTruthy();
  expect(within(grid).queryByText("等待读取或导入数据")).toBeNull();
  expect(f.api.writeCard).not.toHaveBeenCalled();
  expect(f.api.checkDictionary).not.toHaveBeenCalled();
});

it("keeps command failures visible when the operation sidebar is hidden", async () => {
  const f = await fixture();
  f.api.readCard = vi.fn(async () => { throw new Error("卡片已移开，请重新识别"); });
  await f.controller.findCard();
  await f.controller.readCard({
    uid: card.uid, mode: "classic", start: 4, count: 1,
    keyType: "A", key: "112233445566",
  });
  const user = userEvent.setup();
  render(<CardPanel controller={f.controller} />);
  await user.click(screen.getByRole("button", { name: "专注数据" }));
  const status = screen.getByRole("region", { name: "数据获取状态" });
  expect(within(status).getByText("卡片操作失败，当前没有读取结果")).toBeTruthy();
  expect(within(status).getByText("卡片已移开，请重新识别")).toBeTruthy();
});

it("distinguishes unsupported card types from authentication failures", async () => {
  const f = await fixture({ ...card, family: "iso14443_4" });
  await f.controller.findCard();
  render(<CardPanel controller={f.controller} />);
  const status = screen.getByRole("region", { name: "数据获取状态" });
  expect(within(status).getByText("已识别卡片，当前卡型仅支持识别")).toBeTruthy();
  expect(f.api.readCard).not.toHaveBeenCalled();
});

it("requires authorization before dictionary work, clears candidates and shows only verified keys", async () => {
  const user = userEvent.setup();
  const f = await fixture();
  const requests: unknown[] = [];
  f.api.checkDictionary = vi.fn(
    async (request: DictionaryRequest): Promise<DictionaryResult> => {
      requests.push({ ...request, keys: [...request.keys] });
      return {
        dump: {
          card,
          mode: "classic",
          rows: [{ address: 0, hex: "42".repeat(16) }],
          complete: false,
          error: "部分数据未读取",
        },
        sectors: [
          {
            sector: 0,
            keyA: "112233445566",
            keyB: null,
            keyAChecked: true,
            keyBChecked: true,
          },
        ],
        attempts: 3,
        cancelled: false,
        error: null,
      };
    },
  );
  render(<CardPanel controller={f.controller} />);
  expect(f.api.checkDictionary).not.toHaveBeenCalled();
  await user.click(screen.getByRole("button", { name: "寻卡 / 重新识别" }));
  const start = screen.getByRole("button", { name: "开始字典检测并读取" });
  expect((start as HTMLButtonElement).disabled).toBe(true);
  const custom = screen.getByLabelText(/自定义候选密钥/);
  await user.type(custom, "112233445566");
  await user.click(screen.getByRole("checkbox", { name: /我确认卡片为自有/ }));
  await user.click(start);
  const result = await screen.findByRole("generic", { name: "字典检测结果" });
  expect((custom as HTMLTextAreaElement).value).toBe("");
  expect(requests).toEqual([
    expect.objectContaining({
      uid: card.uid,
      startSector: 0,
      sectorCount: 1,
      keys: ["112233445566"],
      confirmed: true,
    }),
  ]);
  expect(within(result).getByText("字典未命中")).toBeTruthy();
  const key = screen.getByLabelText("扇区 0 Key A") as HTMLInputElement;
  expect(key.type).toBe("password");
  await user.click(
    screen.getByRole("checkbox", { name: "显示已认证密钥（敏感）" }),
  );
  expect(key.type).toBe("text");
  expect(key.value).toBe("112233445566");
  await user.click(screen.getByRole("button", { name: "清除结果" }));
  expect(screen.queryByLabelText("扇区 0 Key A")).toBeNull();
});

it("allows cancellation during dictionary checking while preventing read, write and device actions", async () => {
  const user = userEvent.setup();
  const f = await fixture();
  let finish!: (
    result: import("../src/lib/dictionary").DictionaryResult,
  ) => void;
  f.api.checkDictionary = vi.fn(
    () =>
      new Promise<DictionaryResult>((resolve) => {
        finish = resolve;
      }),
  );
  render(
    <CardPanel
      controller={f.controller}
      devicePanel={<ReaderPanel controller={f.controller} />}
    />,
  );
  await user.click(screen.getByRole("button", { name: "寻卡 / 重新识别" }));
  await user.click(screen.getByRole("checkbox", { name: /我确认卡片为自有/ }));
  await user.click(screen.getByRole("button", { name: "开始字典检测并读取" }));
  await waitFor(() => expect(f.api.checkDictionary).toHaveBeenCalledTimes(1));
  expect(
    (screen.getByRole("button", { name: "读取所选范围" }) as HTMLButtonElement)
      .disabled,
  ).toBe(true);
  expect(
    (screen.getByRole("button", { name: "断开连接" }) as HTMLButtonElement)
      .disabled,
  ).toBe(true);
  await user.click(screen.getByRole("button", { name: "取消检测" }));
  expect(f.api.cancelDictionary).toHaveBeenCalledTimes(1);
  expect(
    (screen.getByRole("button", { name: "取消检测" }) as HTMLButtonElement)
      .disabled,
  ).toBe(true);
  await act(async () =>
    finish({
      dump: {
        card,
        mode: "classic",
        rows: [],
        complete: false,
        error: "用户取消",
      },
      sectors: [],
      attempts: 0,
      cancelled: true,
      error: "用户取消",
    }),
  );
  expect(await screen.findByText("检测已取消，部分结果")).toBeTruthy();
  expect(screen.queryByRole("button", { name: "取消检测" })).toBeNull();
});

it("identifies unsupported families without offering a universal unlock action", async () => {
  const user = userEvent.setup();
  const f = await fixture({ ...card, family: "type2", sak: "00" });
  render(<CardPanel controller={f.controller} />);
  await user.click(screen.getByRole("button", { name: "寻卡 / 重新识别" }));
  expect(screen.getByText(/此卡暂不支持字典检测/)).toBeTruthy();
  expect(
    screen.queryByRole("button", { name: "开始字典检测并读取" }),
  ).toBeNull();
  expect(f.api.checkDictionary).not.toHaveBeenCalled();
});

afterEach(cleanup);

describe("card panel desktop UI", () => {
  it("starts disabled without a verified device and never scans automatically", async () => {
    const f = await fixture();
    await f.controller.disconnect();
    render(<CardPanel controller={f.controller} />);
    expect(
      screen
        .getByRole("button", { name: "寻卡 / 重新识别" })
        .hasAttribute("disabled"),
    ).toBe(true);
    expect(screen.getByText("连接读卡器后开始寻卡")).toBeTruthy();
    expect(f.api.scanCard).not.toHaveBeenCalled();
  });

  it("shows connection failures in the data workspace before card identification", async () => {
    const f = await fixture();
    f.api.snapshot = vi.fn(async () => { throw new Error("设备状态不可用"); });
    await f.controller.refresh();
    render(<CardPanel controller={f.controller} />);
    const acquisition = screen.getByRole("region", { name: "数据获取状态" });
    expect(within(acquisition).getByText("尚未建立可验证的设备连接")).toBeTruthy();
    expect(within(acquisition).getByText("设备检测失败：设备状态不可用")).toBeTruthy();
    expect(f.api.scanCard).not.toHaveBeenCalled();
  });

  it("identifies a card, shows raw identity, submits one known key and clears the input", async () => {
    const user = userEvent.setup();
    const f = await fixture();
    render(<CardPanel controller={f.controller} />);
    await user.click(screen.getByRole("button", { name: "寻卡 / 重新识别" }));
    expect(await screen.findByText("04 11 22 33 44 55 66")).toBeTruthy();
    expect(screen.getByText("MIFARE Classic 1K（初步识别）")).toBeTruthy();
    const keyInput = screen.getByLabelText(
      "已知密钥（6 字节）",
    ) as HTMLInputElement;
    expect(keyInput.type).toBe("password");
    expect(keyInput.value).toBe("");
    await user.clear(screen.getByLabelText("起始块地址"));
    await user.type(screen.getByLabelText("起始块地址"), "4");
    await user.selectOptions(screen.getByLabelText("认证密钥类型"), "B");
    await user.type(keyInput, "112233445566");
    await user.click(screen.getByRole("button", { name: "读取所选范围" }));
    expect(await screen.findByText("所选范围读取完成")).toBeTruthy();
    expect(
      within(screen.getByRole("region", { name: /数据表 A/ })).getByText(
        "00 11 22 33 44 55 66 77 88 99 AA BB CC DD EE FF",
      ),
    ).toBeTruthy();
    expect(f.reads).toEqual([
      {
        uid: card.uid,
        mode: "classic",
        start: 4,
        count: 1,
        keyType: "B",
        key: "112233445566",
      },
    ]);
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
    expect(await screen.findByRole("alert")).toHaveProperty(
      "textContent",
      "读取范围须在 0–15 页内。",
    );
    expect(f.api.readCard).not.toHaveBeenCalled();
  });

  it("reads Type 2 pages without presenting or sending credentials", async () => {
    const f = await fixture({
      ...card,
      family: "type2",
      sak: "00",
      typeName: "Ultralight / NTAG 等（初步识别）",
    });
    const user = userEvent.setup();
    render(<CardPanel controller={f.controller} />);
    await user.click(screen.getByRole("button", { name: "寻卡 / 重新识别" }));
    expect(screen.queryByLabelText("已知密钥（6 字节）")).toBeNull();
    await user.click(screen.getByRole("button", { name: "读取所选范围" }));
    expect(await screen.findByText("所选范围读取完成")).toBeTruthy();
    expect(screen.getByText("00 11 22 33")).toBeTruthy();
    expect(f.reads).toEqual([
      {
        uid: card.uid,
        mode: "type2",
        start: 0,
        count: 1,
        keyType: null,
        key: null,
      },
    ]);
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
    f.api.scanCard = vi.fn(async () => {
      throw new Error("寻卡响应无效");
    });
    await user.click(screen.getByRole("button", { name: "寻卡 / 重新识别" }));
    expect(await screen.findByText("卡片操作失败")).toBeTruthy();
    expect(within(screen.getByRole("region", { name: "数据获取状态" })).getByText("寻卡响应无效")).toBeTruthy();
  });

  it("shows unsupported cards as identification-only with no read form", async () => {
    const f = await fixture({
      ...card,
      family: "iso14443_4",
      typeName: "ISO 14443-4 A（仅识别）",
    });
    const user = userEvent.setup();
    render(<CardPanel controller={f.controller} />);
    await user.click(screen.getByRole("button", { name: "寻卡 / 重新识别" }));
    expect(
      await screen.findByText("此类型当前仅支持识别，暂不支持数据读取。"),
    ).toBeTruthy();
    expect(screen.queryByRole("button", { name: "读取所选范围" })).toBeNull();
  });

  it("preserves partial rows and labels an incomplete read", async () => {
    const f = await fixture(card, { partial: true });
    await f.controller.findCard();
    render(<CardPanel controller={f.controller} />);
    const user = userEvent.setup();
    await user.type(
      screen.getByLabelText("已知密钥（6 字节）"),
      "112233445566",
    );
    await user.click(screen.getByRole("button", { name: "读取所选范围" }));
    expect(await screen.findByText("读取未完成")).toBeTruthy();
    const acquisition = screen.getByRole("region", { name: "数据获取状态" });
    expect(within(acquisition).getByText("已取得原始数据 16 B · 1 块（部分结果）")).toBeTruthy();
    expect(within(acquisition).getByText(/地址 5：卡片未应答/)).toBeTruthy();
    expect(screen.queryByText("所选范围读取完成")).toBeNull();
    const readPane = screen.getByRole("region", { name: /数据表 A/ });
    expect(within(readPane).getAllByRole("row")).toHaveLength(3);
  });

  it("clears identity, data and key form when disconnected", async () => {
    const f = await fixture();
    await f.controller.findCard();
    render(<CardPanel controller={f.controller} />);
    const user = userEvent.setup();
    await user.type(
      screen.getByLabelText("已知密钥（6 字节）"),
      "112233445566",
    );
    await act(async () => {
      await f.controller.disconnect();
    });
    expect(screen.queryByLabelText("已知密钥（6 字节）")).toBeNull();
    expect(screen.queryByText("04 11 22 33 44 55 66")).toBeNull();
    expect(screen.getByText("连接读卡器后开始寻卡")).toBeTruthy();
  });

  it("requires original data, explicit preview and risk acknowledgement before one write", async () => {
    const f = await fixture();
    await f.controller.findCard();
    const user = userEvent.setup();
    render(<CardPanel controller={f.controller} />);
    expect(screen.queryByRole("button", { name: "预览写入" })).toBeNull();
    await user.clear(screen.getByLabelText("起始块地址"));
    await user.type(screen.getByLabelText("起始块地址"), "4");
    await user.type(
      screen.getByLabelText("已知密钥（6 字节）"),
      "112233445566",
    );
    await user.click(screen.getByRole("button", { name: "读取所选范围" }));
    await screen.findByText("所选范围读取完成");
    await user.click(screen.getByRole("tab", { name: "用户区写入" }));
    await screen.findByRole("button", { name: "预览写入" });
    await user.type(
      screen.getByLabelText("新数据（16 字节十六进制）"),
      "AA".repeat(16),
    );
    await user.type(screen.getByLabelText("写入已知密钥"), "112233445566");
    await user.click(screen.getByRole("button", { name: "预览写入" }));
    expect(screen.getByText("确认覆盖预览")).toBeTruthy();
    expect(f.api.writeCard).not.toHaveBeenCalled();
    const confirm = screen.getByRole("button", { name: "确认写入此块" });
    expect(confirm.hasAttribute("disabled")).toBe(true);
    await user.click(
      screen.getByRole("checkbox", {
        name: "我确认已获授权并已备份，理解覆盖不可自动撤销。",
      }),
    );
    await user.click(confirm);
    expect(await screen.findByText("写入已读回校验")).toBeTruthy();
    expect(f.writes).toEqual([
      {
        uid: card.uid,
        mode: "classic",
        address: 4,
        hex: "AA".repeat(16),
        expectedHex: "00112233445566778899AABBCCDDEEFF",
        keyType: "A",
        key: "112233445566",
        confirmed: true,
      },
    ]);
    expect(screen.queryByRole("button", { name: "预览写入" })).toBeNull();
    expect(screen.queryByText("所选范围读取完成")).toBeNull();
  });

  it("canceling the write preview sends no command and clears the pending key", async () => {
    const f = await fixture();
    await f.controller.findCard();
    await f.controller.readCard({
      uid: card.uid,
      mode: "classic",
      start: 4,
      count: 1,
      keyType: "A",
      key: "112233445566",
    });
    const user = userEvent.setup();
    render(<CardPanel controller={f.controller} />);
    await user.click(screen.getByRole("tab", { name: "用户区写入" }));
    await user.type(
      screen.getByLabelText("新数据（16 字节十六进制）"),
      "AA".repeat(16),
    );
    await user.type(screen.getByLabelText("写入已知密钥"), "112233445566");
    await user.click(screen.getByRole("button", { name: "预览写入" }));
    await user.click(screen.getByRole("button", { name: "取消写入" }));
    expect(
      (screen.getByLabelText("写入已知密钥") as HTMLInputElement).value,
    ).toBe("");
    expect(screen.queryByText("确认覆盖预览")).toBeNull();
    expect(f.api.writeCard).not.toHaveBeenCalled();
  });

  it("reserved-only or incomplete dumps cannot offer write controls", async () => {
    for (const address of [0, 3]) {
      const f = await fixture();
      await f.controller.findCard();
      await f.controller.readCard({
        uid: card.uid,
        mode: "classic",
        start: address,
        count: 1,
        keyType: "A",
        key: "112233445566",
      });
      const view = render(<CardPanel controller={f.controller} />);
      expect(screen.queryByRole("button", { name: "预览写入" })).toBeNull();
      view.unmount();
    }
    const f = await fixture(card, { partial: true });
    await f.controller.findCard();
    await f.controller.readCard({
      uid: card.uid,
      mode: "classic",
      start: 4,
      count: 1,
      keyType: "A",
      key: "112233445566",
    });
    render(<CardPanel controller={f.controller} />);
    expect(screen.queryByRole("button", { name: "预览写入" })).toBeNull();
  });

  it("keeps unknown write outcome visible after disconnect", async () => {
    const f = await fixture({ ...card, family: "type2", sak: "00" });
    await f.controller.findCard();
    await f.controller.readCard({
      uid: card.uid,
      mode: "type2",
      start: 4,
      count: 1,
      keyType: null,
      key: null,
    });
    f.api.writeCard = vi.fn(async () => {
      throw new Error("响应超时");
    });
    const user = userEvent.setup();
    render(<CardPanel controller={f.controller} />);
    await user.click(screen.getByRole("tab", { name: "用户区写入" }));
    await user.type(
      screen.getByLabelText("新数据（4 字节十六进制）"),
      "AABBCCDD",
    );
    await user.click(screen.getByRole("button", { name: "预览写入" }));
    await user.click(screen.getByRole("checkbox"));
    await user.click(screen.getByRole("button", { name: "确认写入此页" }));
    expect(await screen.findByText("写入结果未确认")).toBeTruthy();
    await act(async () => {
      await f.controller.disconnect();
    });
    expect(screen.getByText("写入结果未确认")).toBeTruthy();
    expect(screen.getByText(/卡片数据可能已改变/)).toBeTruthy();
    expect(f.api.writeCard).toHaveBeenCalledTimes(1);
  });

  it("reads the conservative Type 2 window and shows NDEF dates separately from raw bytes", async () => {
    const current = { ...card, family: "type2", sak: "00" };
    const f = await fixture(current);
    const text = new TextEncoder().encode("2026-10-24");
    const message = [0xd1, 1, text.length + 3, 0x54, 2, 0x65, 0x6e, ...text];
    const data = [3, message.length, ...message, 0xfe];
    while (data.length % 4) data.push(0);
    f.api.readCard = vi.fn(async (request) => ({
      card: current,
      mode: request.mode,
      rows: Array.from({ length: data.length / 4 }, (_, i) => ({
        address: 4 + i,
        hex: data
          .slice(i * 4, i * 4 + 4)
          .map((byte) => byte.toString(16).padStart(2, "0"))
          .join("")
          .toUpperCase(),
      })),
      complete: true,
      error: null,
    }));
    await f.controller.findCard();
    const user = userEvent.setup();
    render(<CardPanel controller={f.controller} />);
    await user.click(
      screen.getByRole("button", { name: "读取 NFC 数据（0–15 页）" }),
    );
    expect(f.api.readCard).toHaveBeenCalledWith(
      expect.objectContaining({ start: 0, count: 16, mode: "type2" }),
    );
    await user.click(screen.getByRole("tab", { name: "内容与日期" }));
    const dates = await screen.findByRole("region", { name: "卡内日期" });
    expect(within(dates).getByText("2026-10-24")).toBeTruthy();
    expect(screen.getByRole("heading", { name: /数据表 A/ })).toBeTruthy();
    expect(screen.getByRole("tab", { name: "用户区写入" })).toBeTruthy();
    expect(screen.getByText(/不.*确认它表示开卡/)).toBeTruthy();
    expect(f.api.writeCard).not.toHaveBeenCalled();
  });

  it("selects read addresses for writing and keeps manual date interpretation explicit", async () => {
    const f = await fixture();
    f.api.readCard = vi.fn(async (request) => ({
      card,
      mode: request.mode,
      rows: [
        { address: 4, hex: "20261024" + "00".repeat(12) },
        { address: 5, hex: "11".repeat(16) },
      ],
      complete: true,
      error: null,
    }));
    await f.controller.findCard();
    await f.controller.readCard({
      uid: card.uid,
      mode: "classic",
      start: 4,
      count: 2,
      keyType: "A",
      key: "112233445566",
    });
    const user = userEvent.setup();
    render(<CardPanel controller={f.controller} />);
    await user.click(screen.getByRole("tab", { name: "用户区写入" }));
    await user.click(screen.getByRole("button", { name: "选择块 5" }));
    expect(
      (screen.getByLabelText("目标块地址") as HTMLSelectElement).value,
    ).toBe("5");
    await user.click(
      screen.getByRole("button", { name: "载入原数据到编辑框" }),
    );
    expect(
      (screen.getByLabelText("新数据（16 字节十六进制）") as HTMLInputElement)
        .value,
    ).toBe("11".repeat(16));
    await user.click(screen.getByRole("tab", { name: "数据分析" }));
    await user.click(screen.getByText("按指定编码查看字节（人工解释）"));
    expect((screen.getByLabelText("解释数据地址") as HTMLSelectElement).value).toBe("5");
    await user.selectOptions(screen.getByLabelText("解释数据地址"), "4");
    expect(screen.getByText("2026-10-24（无时区的日期）")).toBeTruthy();
    expect(screen.getByText(/不会自动认定为卡片有效期/)).toBeTruthy();
    expect(f.api.writeCard).not.toHaveBeenCalled();
  });

  it("blocks duplicate card commands and disconnect while a card command is running", async () => {
    const f = await fixture();
    let finish!: (card: CardInfo | null) => void;
    f.api.scanCard = vi.fn(
      () =>
        new Promise<CardInfo | null>((resolve) => {
          finish = resolve;
        }),
    );
    const user = userEvent.setup();
    render(
      <>
        <ReaderPanel controller={f.controller} />
        <CardPanel controller={f.controller} />
      </>,
    );
    await user.click(screen.getByRole("button", { name: "寻卡 / 重新识别" }));
    await waitFor(() =>
      expect(
        screen
          .getByRole("button", { name: "断开连接" })
          .hasAttribute("disabled"),
      ).toBe(true),
    );
    expect(
      screen
        .getByRole("button", { name: "正在寻卡…" })
        .hasAttribute("disabled"),
    ).toBe(true);
    await act(async () => {
      finish(card);
    });
    await screen.findByText("04 11 22 33 44 55 66");
    await waitFor(() =>
      expect(
        screen
          .getByRole("button", { name: "断开连接" })
          .hasAttribute("disabled"),
      ).toBe(false),
    );
    expect(f.api.scanCard).toHaveBeenCalledTimes(1);
  });
});
