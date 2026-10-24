import { invoke, isTauri, type InvokeArgs } from "@tauri-apps/api/core";
import { type ReaderApi } from "./reader";

/** Fail clearly in browser previews without attempting any device command. */
function desktopInvoke<T>(command: string, args?: InvokeArgs): Promise<T> {
  if (!isTauri()) {
    return Promise.reject(new Error(
      "浏览器预览不能访问 PN532 读卡器；请运行 PCR532 桌面程序或使用 npm run tauri dev。离线 .dump 分析仍可使用。",
    ));
  }
  return args === undefined ? invoke<T>(command) : invoke<T>(command, args);
}

/** Desktop-only bridge. All device and card commands use one controller queue. */
export const readerApi: ReaderApi = {
  snapshot: () => desktopInvoke("get_device_snapshot"),
  connect: (portName, baudRate) => desktopInvoke("connect_reader", { portName, baudRate }),
  disconnect: () => desktopInvoke("disconnect_reader"),
  scanCard: () => desktopInvoke("scan_card"),
  readCard: (request) => desktopInvoke("read_card", { request }),
  writeCard: (request) => desktopInvoke("write_card", { request }),
  checkDictionary: (request) => desktopInvoke("check_dictionary", { request }),
  dictionaryProgress: (runId) => desktopInvoke("dictionary_progress", { runId }),
  cancelDictionary: (runId) => desktopInvoke("cancel_dictionary", { runId }),
};
