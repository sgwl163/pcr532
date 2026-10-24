import { cleanup, render, screen, within } from "@testing-library/react";
import userEvent from "@testing-library/user-event";
import { afterEach, expect, it, vi } from "vitest";

import { FieldAnalysisPanel } from "../src/components/field-analysis-panel";
import { parseClassicDump } from "../src/lib/dump-file";

afterEach(() => { cleanup(); vi.restoreAllMocks(); vi.unstubAllGlobals(); });


it("filters by evidence and keyword and resets filters for a different capture", async () => {
  const user = userEvent.setup();
  const dump = sample();
  const view = render(<FieldAnalysisPanel dump={dump} onSelect={vi.fn()} />);
  await user.click(screen.getByRole("button", { name: "参考日期" }));
  await user.selectOptions(screen.getByLabelText("字段证据筛选"), "candidate");
  expect(screen.getAllByRole("rowheader")).toHaveLength(1);
  expect(screen.queryByText("普通数据（未解码）")).toBeNull();
  await user.type(screen.getByRole("textbox", { name: "搜索分析字段" }), "不存在的字段");
  expect(screen.getByText("没有符合筛选条件的字段；原始数据未改变。")).toBeTruthy();
  view.rerender(<FieldAnalysisPanel dump={{ ...dump }} onSelect={vi.fn()} />);
  expect((screen.getByLabelText("字段证据筛选") as HTMLSelectElement).value).toBe("all");
  expect((screen.getByRole("textbox", { name: "搜索分析字段" }) as HTMLInputElement).value).toBe("");
  expect(screen.getByText("普通数据（未解码）")).toBeTruthy();
});

it("downloads a local analysis report and releases its object URL", async () => {
  const user = userEvent.setup();
  const createObjectURL = vi.fn((_blob: Blob) => "blob:analysis-report");
  const revokeObjectURL = vi.fn();
  vi.stubGlobal("URL", { createObjectURL, revokeObjectURL });
  const click = vi.spyOn(HTMLAnchorElement.prototype, "click").mockImplementation(() => {});
  render(<FieldAnalysisPanel dump={sample()} sourceName="本地卡.dump" onSelect={vi.fn()} />);
  await user.click(screen.getByRole("button", { name: "导出分析报告" }));
  expect(createObjectURL).toHaveBeenCalledOnce();
  expect(createObjectURL.mock.calls[0][0]).toBeInstanceOf(Blob);
  expect(click).toHaveBeenCalledOnce();
  expect(revokeObjectURL).toHaveBeenCalledWith("blob:analysis-report");
  expect(screen.getByRole("status", { name: "报告导出状态" }).textContent).toContain("已发起");
});

it("reports unavailable local download APIs without claiming a saved report", async () => {
  const user = userEvent.setup();
  vi.stubGlobal("URL", {});
  render(<FieldAnalysisPanel dump={sample()} onSelect={vi.fn()} />);
  await user.click(screen.getByRole("button", { name: "导出分析报告" }));
  expect(screen.getByRole("status", { name: "报告导出状态" }).textContent).toContain("不支持");
});

function sample(date: number[] = [0x37, 0x5f]) {
  const bytes = new Uint8Array(1024);
  bytes.set(date, 5 * 16 + 10);
  bytes.set([0xff, 0x07, 0x80, 0x69], 3 * 16 + 6);
  return parseClassicDump(bytes);
}

it("shows the four screenshot-style columns and keeps reference dates opt-in", async () => {
  const user = userEvent.setup();
  const onSelect = vi.fn();
  render(<FieldAnalysisPanel dump={sample()} onSelect={onSelect} />);
  for (const name of ["数据项", "位置", "数据", "说明"])
    expect(screen.getByRole("columnheader", { name })).toBeTruthy();
  expect(screen.queryByText("日期候选（截图参考规则）")).toBeNull();
  expect(screen.getByRole("button", { name: "自动分析" }).getAttribute("aria-pressed")).toBe("true");

  await user.click(screen.getByRole("button", { name: "参考日期" }));
  const row = screen.getByRole("rowheader", { name: /日期候选/ }).closest("tr")!;
  expect(row.getAttribute("data-evidence")).toBe("candidate");
  expect(within(row).getByText("待验证")).toBeTruthy();
  expect(within(row).getByText("37 5F")).toBeTruthy();
  expect(within(row).getByText(/2027-10-31.*字段用途待验证/)).toBeTruthy();
  await user.click(within(row).getByRole("button", { name: "定位块 5 偏移 10 长度 2" }));
  expect(onSelect).toHaveBeenCalledWith({ address: 5, offset: 10, length: 2 });

  await user.click(screen.getByRole("button", { name: "自动分析" }));
  expect(screen.queryByText("日期候选（截图参考规则）")).toBeNull();
});

it("clears a selected reference rule when a different dump is loaded", async () => {
  const user = userEvent.setup();
  const view = render(<FieldAnalysisPanel dump={sample()} onSelect={vi.fn()} />);
  await user.selectOptions(screen.getByLabelText("字段解析方案"), "reference-date");
  view.rerender(<FieldAnalysisPanel dump={sample([0x35, 0x21])} onSelect={vi.fn()} />);
  expect(screen.queryByText("日期候选（截图参考规则）")).toBeNull();
  await user.click(screen.getByRole("button", { name: "参考日期" }));
  const row = screen.getByRole("rowheader", { name: /日期候选/ }).closest("tr")!;
  expect(within(row).getByText("35 21")).toBeTruthy();
  expect(within(row).getByText(/2026-09-01/)).toBeTruthy();
});

it("disables the reference rule when its source block is missing", () => {
  const dump = sample();
  dump.rows = dump.rows.filter((row) => row.address !== 5);
  render(<FieldAnalysisPanel dump={dump} onSelect={vi.fn()} />);
  expect(screen.getByRole("button", { name: "参考日期" }).hasAttribute("disabled")).toBe(true);
  expect(screen.queryByText("日期候选（截图参考规则）")).toBeNull();
});

it("preserves invalid date bytes without publishing a calendar date", async () => {
  const user = userEvent.setup();
  render(<FieldAnalysisPanel dump={sample([0xff, 0xff])} onSelect={vi.fn()} />);
  await user.click(screen.getByRole("button", { name: "参考日期" }));
  const row = screen.getByRole("rowheader", { name: /日期候选/ }).closest("tr")!;
  expect(within(row).getByText("FF FF")).toBeTruthy();
  expect(within(row).getByText(/不是有效日历日期/)).toBeTruthy();
});
