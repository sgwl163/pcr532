import { invoke } from "@tauri-apps/api/core";
import { type ReaderApi } from "./reader";

/** Desktop-only bridge. All device and card commands use one controller queue. */
export const readerApi: ReaderApi = {
  snapshot: () => invoke("get_device_snapshot"),
  connect: (portName, baudRate) => invoke("connect_reader", { portName, baudRate }),
  disconnect: () => invoke("disconnect_reader"),
  scanCard: () => invoke("scan_card"),
  readCard: (request) => invoke("read_card", { request }),
};
