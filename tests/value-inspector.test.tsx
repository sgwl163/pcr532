import { cleanup, render, screen } from "@testing-library/react";
import userEvent from "@testing-library/user-event";
import { afterEach, expect, it, vi } from "vitest";
import { ValueInspector } from "../src/components/value-inspector";
import { parseClassicDump } from "../src/lib/dump-file";


afterEach(cleanup);

it("keeps trailer key bytes out of manual text and date interpretation", async () => {
  const user = userEvent.setup();
  const dump = { ...parseClassicDump(new Uint8Array(1024)), rows: [{ address: 3, hex: "414243444546FF0780694748494A4B4C" }] };
  render(<ValueInspector dump={dump} onSelect={vi.fn()} />);
  await user.click(screen.getByText("按指定编码查看字节（人工解释）"));
  await user.selectOptions(screen.getByLabelText("数据解释编码"), "utf8");
  expect(screen.getByText(/尾块密钥位置不参与人工解释/)).toBeTruthy();
  expect(screen.queryByRole("button", { name: "定位解释字节" })).toBeNull();
  await user.clear(screen.getByLabelText("解释字节偏移"));
  await user.type(screen.getByLabelText("解释字节偏移"), "9");
  await user.selectOptions(screen.getByLabelText("数据解释编码"), "packed-date-2000-be");
  expect(screen.getByText(/至少 2 字节/)).toBeTruthy();
  expect(screen.queryByText(/GHIJKL/)).toBeNull();
});


it("follows selected bytes and can locate exactly the manually interpreted date", async () => {
  const user = userEvent.setup();
  const bytes = new Uint8Array(1024);
  bytes.set([0x37, 0x5f], 5 * 16 + 10);
  const dump = parseClassicDump(bytes);
  const onSelect = vi.fn();
  render(<ValueInspector dump={dump} selection={{ address: 5, offset: 10, length: 2 }} onSelect={onSelect} />);
  await user.click(screen.getByText("按指定编码查看字节（人工解释）"));
  expect((screen.getByLabelText("解释数据地址") as HTMLSelectElement).value).toBe("5");
  expect((screen.getByLabelText("解释字节偏移") as HTMLInputElement).value).toBe("10");
  await user.selectOptions(screen.getByLabelText("数据解释编码"), "packed-date-2000-be");
  expect(screen.getByText("2027-10-31（无时区的日期）")).toBeTruthy();
  await user.click(screen.getByRole("button", { name: "定位解释字节" }));
  expect(onSelect).toHaveBeenCalledWith({ address: 5, offset: 10, length: 2 });
});

it("resets manual settings for new captures and follows later address selections", async () => {
  const user = userEvent.setup();
  const dump = parseClassicDump(new Uint8Array(1024));
  const view = render(<ValueInspector dump={dump} selection={{ address: 5, offset: 10, length: 2 }} />);
  await user.click(screen.getByText("按指定编码查看字节（人工解释）"));
  await user.selectOptions(screen.getByLabelText("数据解释编码"), "unix-seconds-le");
  view.rerender(<ValueInspector dump={dump} selection={{ address: 8, offset: 2, length: 4 }} />);
  expect((screen.getByLabelText("解释数据地址") as HTMLSelectElement).value).toBe("8");
  expect((screen.getByLabelText("解释字节偏移") as HTMLInputElement).value).toBe("2");
  view.rerender(<ValueInspector dump={{ ...dump }} />);
  expect((screen.getByLabelText("解释数据地址") as HTMLSelectElement).value).toBe("0");
  expect((screen.getByLabelText("数据解释编码") as HTMLSelectElement).value).toBe("bcd-date");
});
