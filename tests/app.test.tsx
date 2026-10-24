import { cleanup, render, screen, waitFor } from "@testing-library/react";
import userEvent from "@testing-library/user-event";
import { afterEach, beforeEach, expect, it, vi } from "vitest";
import App from "../src/App";
import { invoke } from "@tauri-apps/api/core";

vi.mock("@tauri-apps/api/core", () => ({ invoke: vi.fn(), isTauri: vi.fn(() => true) }));
afterEach(cleanup);
beforeEach(() => {
  vi.mocked(invoke).mockReset();
  vi.mocked(invoke).mockImplementation(async (cmd) => {
    if (cmd === "get_device_snapshot")
      return { ports: [], connection: null, connectionError: null };
    if (cmd === "get_app_info")
      return {
        name: "pcr532-desktop",
        version: "0.1.0",
        os: "windows",
        arch: "x86_64",
      };
    throw new Error(`Unexpected test command: ${cmd}`);
  });
});

it("shows device controls, side-by-side data work areas, analysis and a session log without scanning cards", async () => {
  render(<App />);
  expect(screen.getByRole("heading", { name: /NFC 工作台/ })).toBeTruthy();
  expect(screen.getByRole("heading", { name: /设备连接/ })).toBeTruthy();
  expect(screen.getByRole("heading", { name: /数据表 A/ })).toBeTruthy();
  expect(screen.getByRole("tab", { name: "数据分析" })).toBeTruthy();
  expect(screen.getByRole("tab", { name: "用户区写入" })).toBeTruthy();
  expect(screen.getByRole("tab", { name: "内容与日期" })).toBeTruthy();
  expect(screen.queryByRole("heading", { name: "NFC 内容与日期解析" })).toBeNull();
  expect(screen.getByRole("log")).toBeTruthy();
  await waitFor(() =>
    expect(invoke).toHaveBeenCalledWith("get_device_snapshot"),
  );
  expect(
    vi
      .mocked(invoke)
      .mock.calls.every(([command]) => command === "get_device_snapshot"),
  ).toBe(true);
});

it("opens stored content from the toolbar and can focus the two data panes", async () => {
  const user = userEvent.setup();
  render(<App />);
  await user.click(screen.getByRole("button", { name: "查看内容与日期" }));
  expect(screen.getByRole("tab", { name: "内容与日期" }).getAttribute("aria-selected")).toBe("true");
  expect(screen.getByRole("heading", { name: "NFC 内容与日期解析" })).toBeTruthy();
  await user.click(screen.getByRole("tab", { name: "数据分析" }));
  await user.click(screen.getByRole("button", { name: "专注数据" }));
  const focus = screen.getByRole("button", { name: "展开操作面板" });
  expect(focus.getAttribute("aria-pressed")).toBe("true");
  expect(focus.closest(".workspace-grid")?.getAttribute("data-focus")).toBe("true");
  await user.click(focus);
  expect(screen.getByRole("button", { name: "专注数据" }).getAttribute("aria-pressed")).toBe("false");
});

it("can collapse and restore the session log without clearing it or issuing card commands", async () => {
  const user = userEvent.setup();
  render(<App />);
  await waitFor(() => expect(invoke).toHaveBeenCalledWith("get_device_snapshot"));
  await user.click(screen.getByRole("button", { name: "收起日志" }));
  expect(screen.queryByRole("log")).toBeNull();
  const restore = screen.getByRole("button", { name: /展开日志/ });
  expect(restore.getAttribute("aria-expanded")).toBe("false");
  await user.click(restore);
  expect(screen.getByRole("log")).toBeTruthy();
  expect(vi.mocked(invoke).mock.calls.every(([command]) => command === "get_device_snapshot")).toBe(true);
});

it("keeps backend diagnostics behind the about button and only invokes app information", async () => {
  const user = userEvent.setup();
  render(<App />);
  expect(screen.queryByRole("button", { name: "测试后端通信" })).toBeNull();
  await user.click(screen.getByRole("button", { name: "关于与诊断" }));
  await user.click(screen.getByRole("button", { name: "测试后端通信" }));
  expect(
    await screen.findByText("pcr532-desktop · v0.1.0 · windows / x86_64"),
  ).toBeTruthy();
  expect(invoke).toHaveBeenCalledWith("get_app_info");
  expect(
    vi
      .mocked(invoke)
      .mock.calls.every(([command]) =>
        ["get_device_snapshot", "get_app_info"].includes(command),
      ),
  ).toBe(true);
});
