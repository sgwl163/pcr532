import { cleanup, render, screen, within } from "@testing-library/react";
import userEvent from "@testing-library/user-event";
import { afterEach, expect, it, vi } from "vitest";
import { DataGrid } from "../src/components/data-grid";
import type { CardDump } from "../src/lib/cards";

const dump: CardDump = {
  card: {
    uid: "12345678",
    uidLength: 4,
    atqa: "0004",
    sak: "18",
    family: "classic4k",
    typeName: "Classic 4K",
  },
  mode: "classic",
  complete: true,
  error: null,
  rows: [
    { address: 127, hex: "00".repeat(16) },
    { address: 128, hex: "41424344" + "00".repeat(12) },
    { address: 143, hex: "00".repeat(16) },
  ],
};

afterEach(cleanup);

it("searches acquired bytes, highlights matches and jumps only to loaded addresses", async () => {
  const user = userEvent.setup();
  const onSelect = vi.fn();
  const onSelectBytes = vi.fn();
  render(<DataGrid dump={dump} selectedAddress={null} onSelect={onSelect} onSelectBytes={onSelectBytes} />);
  await user.type(screen.getByRole("textbox", { name: "搜索原始数据" }), "41 42");
  await user.click(screen.getByRole("button", { name: "查找" }));
  expect(screen.getByRole("status", { name: "数据定位结果" }).textContent).toContain("1 / 1");
  expect(onSelectBytes).toHaveBeenCalledWith({ address: 128, offset: 0, length: 2 });
  expect(screen.getByLabelText("块 128 数据").querySelectorAll(".byte-search-match")).toHaveLength(2);
  await user.type(screen.getByRole("textbox", { name: "跳转地址" }), "0x80");
  await user.click(screen.getByRole("button", { name: "跳转" }));
  expect(onSelect).toHaveBeenCalledWith(128);
  await user.clear(screen.getByRole("textbox", { name: "跳转地址" }));
  await user.type(screen.getByRole("textbox", { name: "跳转地址" }), "129");
  await user.click(screen.getByRole("button", { name: "跳转" }));
  expect(screen.getByRole("status", { name: "数据定位结果" }).textContent).toContain("未载入");
});

it("resets search on new data, validates HEX and keeps hidden keys unsearchable", async () => {
  const user = userEvent.setup();
  const view = render(<DataGrid dump={dump} selectedAddress={null} onSelect={vi.fn()} />);
  await user.type(screen.getByRole("textbox", { name: "搜索原始数据" }), "4");
  await user.click(screen.getByRole("button", { name: "查找" }));
  expect(screen.getByRole("status", { name: "数据定位结果" }).textContent).toContain("完整字节");
  await user.clear(screen.getByRole("textbox", { name: "搜索原始数据" }));
  await user.type(screen.getByRole("textbox", { name: "搜索原始数据" }), "41 42");
  await user.click(screen.getByRole("button", { name: "查找" }));
  view.rerender(<DataGrid dump={{ ...dump, rows: [{ address: 143, hex: "414243444546FF0780694748494A4B4C" }] }} selectedAddress={null} onSelect={vi.fn()} />);
  expect((screen.getByRole("textbox", { name: "搜索原始数据" }) as HTMLInputElement).value).toBe("");
  await user.type(screen.getByRole("textbox", { name: "搜索原始数据" }), "41 42");
  await user.click(screen.getByRole("button", { name: "查找" }));
  expect(screen.getByRole("status", { name: "数据定位结果" }).textContent).toContain("未找到");
});


it("groups Classic 4K large sectors correctly and marks protected trailers", () => {
  render(<DataGrid dump={dump} selectedAddress={128} onSelect={vi.fn()} />);
  expect(screen.getByText("扇区 31")).toBeTruthy();
  expect(screen.getAllByText("扇区 32")).toHaveLength(1);
  expect(screen.getAllByLabelText("受保护地址")).toHaveLength(2);
  expect(
    screen
      .getByRole("button", { name: "选择块 128" })
      .getAttribute("aria-pressed"),
  ).toBe("true");
});

it("address and display controls are local and preserve original bytes", async () => {
  const onSelect = vi.fn();
  const user = userEvent.setup();
  render(<DataGrid dump={dump} selectedAddress={null} onSelect={onSelect} />);
  await user.click(screen.getByRole("button", { name: "选择块 128" }));
  expect(onSelect).toHaveBeenCalledWith(128);
  await user.click(screen.getByRole("button", { name: "十六进制地址" }));
  expect(screen.getByText("0x80")).toBeTruthy();
  expect(screen.getByText("ABCD" + "·".repeat(12))).toBeTruthy();
  await user.click(screen.getByRole("button", { name: "ASCII" }));
  expect(screen.queryByText("ABCD" + "·".repeat(12))).toBeNull();
  await user.click(screen.getByRole("button", { name: "ASCII" }));
  expect(screen.getByText("ABCD" + "·".repeat(12))).toBeTruthy();
  expect(screen.getByText("41 42 43 44" + " 00".repeat(12))).toBeTruthy();
  expect(dump.rows[1].hex).toBe("41424344" + "00".repeat(12));
});

it("distinguishes loaded byte length from layout capacity for partial dumps", () => {
  render(<DataGrid dump={dump} sourceName="partial.dump" selectedAddress={null} onSelect={vi.fn()} />);
  expect(screen.getByText("已载入长度：48 B")).toBeTruthy();
  expect(screen.getByText("布局容量：4096 B")).toBeTruthy();
  expect(screen.getByText("地址跨度：127–143块")).toBeTruthy();
  expect(screen.getByText("partial.dump")).toBeTruthy();
});

it("masks trailer keys in both hex and ASCII and clears reveal permission for new data", async () => {
  const user = userEvent.setup();
  const sensitive = {
    ...dump,
    rows: [{ address: 143, hex: "414243444546FF0780694748494A4B4C" }],
  };
  const view = render(<DataGrid dump={sensitive} selectedAddress={null} onSelect={vi.fn()} />);
  const bytes = screen.getByLabelText("块 143 数据");
  expect(bytes.textContent).toBe("•• •• •• •• •• •• FF 07 80 69 •• •• •• •• •• ••");
  expect(screen.queryByText("ABCDEF···iGHIJKL")).toBeNull();
  await user.click(screen.getByRole("checkbox", { name: "显示尾块密钥字节（敏感）" }));
  expect(screen.getByText("ABCDEF···iGHIJKL")).toBeTruthy();
  view.rerender(<DataGrid dump={{ ...sensitive }} selectedAddress={null} onSelect={vi.fn()} />);
  expect(screen.queryByText("ABCDEF···iGHIJKL")).toBeNull();
  expect(screen.getByLabelText("块 143 数据").textContent).toContain("••");
});

it("highlights exactly the selected field bytes without modifying the capture", () => {
  const original = JSON.stringify(dump);
  render(<DataGrid dump={dump} selectedAddress={128} onSelect={vi.fn()} fieldSelection={{ address: 128, offset: 1, length: 2 }} />);
  const data = screen.getByLabelText("块 128 数据");
  expect([...data.querySelectorAll(".byte-highlight")].map((element) => element.textContent?.trim())).toEqual(["42", "43"]);
  expect(within(data.closest("tr")!).getByRole("button").getAttribute("aria-pressed")).toBe("true");
  expect(JSON.stringify(dump)).toBe(original);
});
