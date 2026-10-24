import {
  type DictionaryRequest,
  type DictionaryProgress,
  type DictionaryResult,
  classicSectors,
} from "./dictionary.ts";

import {
  initialCardState,
  type CardDump,
  type CardInfo,
  type CardState,
  type ReadRequest,
  type WriteRequest,
  type WriteResult,
} from "./cards.ts";

export type SerialDevice = {
  portName: string;
  label: string;
  transport: "usb" | "pci" | "bluetooth" | "unknown";
  vid: string | null;
  pid: string | null;
  manufacturer: string | null;
  serialNumber: string | null;
  isCandidate: boolean;
};

export type ReaderConnection = {
  portName: string;
  baudRate: number;
  chip: string;
  firmwareVersion: string;
  support: number;
};

export type DeviceSnapshot = {
  ports: SerialDevice[];
  connection: ReaderConnection | null;
  connectionError: string | null;
};

export type ReaderLog = {
  id: number;
  at: number;
  level: "info" | "success" | "error";
  message: string;
};

export type ReaderState = {
  logs: ReaderLog[];
  snapshot: DeviceSnapshot | null;
  scanError: string | null;
  actionError: string | null;
  activity:
    | "idle"
    | "scanning"
    | "connecting"
    | "disconnecting"
    | "findingCard"
    | "readingCard"
    | "writingCard"
    | "checkingKeys";
  dictionary: {
    runId: string | null;
    progress: DictionaryProgress | null;
    result: DictionaryResult | null;
    error: string | null;
    cancelling: boolean;
  };
  lastWrite: WriteResult | null;
  cardState: CardState;
  selectedPort: string;
  baudRate: number;
  checkedAt: number | null;
};

export const BAUD_RATES = [
  9600, 19200, 38400, 57600, 115200, 230400, 460800, 921600,
];

export interface ReaderApi {
  snapshot(): Promise<DeviceSnapshot>;
  connect(portName: string, baudRate: number): Promise<ReaderConnection>;
  disconnect(): Promise<void>;
  scanCard(): Promise<CardInfo | null>;
  readCard(request: ReadRequest): Promise<CardDump>;
  writeCard(request: WriteRequest): Promise<WriteResult>;
  checkDictionary(request: DictionaryRequest): Promise<DictionaryResult>;
  dictionaryProgress(runId: string): Promise<DictionaryProgress | null>;
  cancelDictionary(runId: string): Promise<boolean>;
}

export function initialReaderState(): ReaderState {
  return {
    logs: [],
    snapshot: null,
    scanError: null,
    actionError: null,
    activity: "idle",
    cardState: initialCardState(),
    dictionary: {
      runId: null,
      progress: null,
      result: null,
      error: null,
      cancelling: false,
    },
    lastWrite: null,
    selectedPort: "",
    baudRate: 115200,
    checkedAt: null,
  };
}

export function choosePort(ports: SerialDevice[], selected: string): string {
  if (ports.some((port) => port.portName === selected)) return selected;
  const candidates = ports.filter((port) => port.isCandidate);
  return candidates.length === 1 ? candidates[0].portName : "";
}

export function readerStatus(state: ReaderState) {
  if (state.scanError) {
    return {
      title: "设备状态暂不可验证",
      detail: state.scanError,
      kind: "error" as const,
    };
  }
  if (!state.snapshot) {
    return {
      title: "正在检测系统串口",
      detail: "正在读取系统设备列表，请稍候。",
      kind: "neutral" as const,
    };
  }
  if (state.activity === "connecting") {
    return {
      title: "正在连接并验证读卡器",
      detail: `${state.selectedPort} · ${state.baudRate} baud · 正在查询 PN532 固件信息。`,
      kind: "neutral" as const,
    };
  }
  if (state.activity === "disconnecting") {
    return {
      title: "正在断开读卡器",
      detail: "正在释放串口，请稍候。",
      kind: "neutral" as const,
    };
  }
  if (state.actionError) {
    return {
      title: "设备操作失败",
      detail: state.actionError,
      kind: "error" as const,
    };
  }
  const connection = state.snapshot.connection;
  if (connection) {
    return {
      title: `已连接 ${connection.chip}`,
      detail: `${connection.portName} · ${connection.baudRate} baud · 固件 ${connection.firmwareVersion}`,
      kind: "success" as const,
    };
  }
  if (state.snapshot.connectionError) {
    return {
      title: "读卡器连接已中断",
      detail: state.snapshot.connectionError,
      kind: "error" as const,
    };
  }
  if (state.snapshot.ports.length > 0) {
    return {
      title: `已发现 ${state.snapshot.ports.length} 个串口，等待验证`,
      detail:
        "系统已识别串口。选择读卡器对应的端口并点击“连接并验证”，确认是否为 PN532 读卡器。",
      kind: "neutral" as const,
    };
  }
  return {
    title: "系统未发现串口",
    detail:
      "请检查 USB 数据线和驱动；如果读卡器不是串口型号，需要对应的其他连接方式。",
    kind: "neutral" as const,
  };
}

function deviceKey(port: SerialDevice) {
  return JSON.stringify([port.portName, port.vid, port.pid, port.serialNumber]);
}

function errorText(error: unknown) {
  return error instanceof Error ? error.message : String(error);
}

/** One command queue prevents polling results from overwriting a newer connect/disconnect. */
export class ReaderController {
  private state = initialReaderState();
  private listeners = new Set<() => void>();
  private queue: Promise<void> = Promise.resolve();
  private pendingActions = 0;
  private logId = 0;
  private refreshing = false;
  private progressPending = false;

  private readonly api: ReaderApi;
  private readonly autoConnect: boolean;
  private attemptedDevices = new Set<string>();

  constructor(api: ReaderApi, options: { autoConnect?: boolean } = {}) {
    this.api = api;
    this.autoConnect = options.autoConnect ?? true;
  }

  getState = () => this.state;

  subscribe = (listener: () => void) => {
    this.listeners.add(listener);
    return () => {
      this.listeners.delete(listener);
    };
  };

  private update(patch: Partial<ReaderState>) {
    this.state = { ...this.state, ...patch };
    this.listeners.forEach((listener) => listener());
  }

  /** Session-only, bounded history: never record keys, payloads or raw exception text. */
  private log(level: ReaderLog["level"], message: string) {
    this.update({
      logs: [
        ...this.state.logs.slice(-199),
        { id: ++this.logId, at: Date.now(), level, message },
      ],
    });
  }

  clearLogs = () => {
    this.update({ logs: [] });
  };

  private enqueue(work: () => Promise<void>) {
    const result = this.queue.then(work);
    this.queue = result.catch(() => {});
    return result;
  }

  private async scan() {
    try {
      const snapshot = await this.api.snapshot();
      const previous = this.state.snapshot;
      if (this.state.scanError)
        this.log("info", "设备状态检测已恢复，请以当前连接状态为准。");
      if (previous?.connection && !snapshot.connection)
        this.log(
          "error",
          "设备连接中断，已清除当前卡片数据；最近写入结果保留。请重新连接。",
        );
      else if (!previous?.connection && snapshot.connection)
        this.log(
          "success",
          `设备已验证：${snapshot.connection.portName} · ${snapshot.connection.baudRate} baud · PN532 固件 ${snapshot.connection.firmwareVersion}`,
        );
      const presentDevices = new Set(snapshot.ports.map(deviceKey));
      this.attemptedDevices = new Set(
        [...this.attemptedDevices].filter((key) => presentDevices.has(key)),
      );
      const activePort = snapshot.ports.find(
        (port) => port.portName === snapshot.connection?.portName,
      );
      if (activePort) this.attemptedDevices.add(deviceKey(activePort));
      this.update({
        snapshot,
        scanError: null,
        selectedPort:
          snapshot.connection?.portName ??
          choosePort(snapshot.ports, this.state.selectedPort),
        checkedAt: Date.now(),
        ...(!snapshot.connection ||
        this.state.scanError ||
        !this.state.snapshot?.connection ||
        snapshot.connection.portName !==
          this.state.snapshot.connection.portName ||
        snapshot.connection.baudRate !== this.state.snapshot.connection.baudRate
          ? {
              cardState: initialCardState(),
              dictionary: initialReaderState().dictionary,
            }
          : {}),
      });
    } catch (error) {
      // Keep the last list for diagnosis, but never report stale data as current.
      if (!this.state.scanError)
        this.log(
          "error",
          "设备状态无法验证，已清除当前卡片数据。请查看设备区域错误。",
        );
      this.update({
        scanError: `设备检测失败：${errorText(error)}`,
        cardState: initialCardState(),
        dictionary: initialReaderState().dictionary,
      });
    }
  }

  refresh = async () => {
    if (this.refreshing || this.pendingActions) return;
    this.refreshing = true;
    try {
      await this.enqueue(async () => {
        this.update({ activity: "scanning" });
        await this.scan();
        if (!this.pendingActions) this.update({ activity: "idle" });
      });
      // Probe a single recognized adapter once per insertion, never every poll.
      const candidates =
        this.state.snapshot?.ports.filter((port) => port.isCandidate) ?? [];
      const candidate = candidates.length === 1 ? candidates[0] : undefined;
      if (
        this.autoConnect &&
        candidate &&
        !this.state.scanError &&
        !this.pendingActions &&
        !this.state.snapshot?.connection &&
        candidate.portName === this.state.selectedPort &&
        !this.attemptedDevices.has(deviceKey(candidate))
      ) {
        await this.connect();
      }
    } finally {
      this.refreshing = false;
    }
  };

  selectPort = (selectedPort: string) => {
    if (this.pendingActions || this.state.snapshot?.connection) return;
    this.update({ selectedPort, actionError: null });
  };

  selectBaud = (baudRate: number) => {
    if (
      !BAUD_RATES.includes(baudRate) ||
      this.pendingActions ||
      this.state.snapshot?.connection
    )
      return;
    this.update({ baudRate, actionError: null });
  };

  connect = async () => {
    if (this.pendingActions || this.state.snapshot?.connection) return;
    if (!this.state.selectedPort || this.state.scanError) return;
    const { selectedPort, baudRate } = this.state;
    const selected = this.state.snapshot?.ports.find(
      (port) => port.portName === selectedPort,
    );
    if (selected) this.attemptedDevices.add(deviceKey(selected));
    this.pendingActions++;
    this.log("info", `开始验证设备：${selectedPort} · ${baudRate} baud`);
    this.update({ activity: "connecting", actionError: null });
    try {
      await this.enqueue(async () => {
        this.update({ activity: "connecting" });
        try {
          const connection = await this.api.connect(selectedPort, baudRate);
          this.log(
            "success",
            `连接验证成功：PN532 固件 ${connection.firmwareVersion}`,
          );
          this.update({
            snapshot: {
              ports: this.state.snapshot?.ports ?? [],
              connection,
              connectionError: null,
            },
            scanError: null,
          });
        } catch (error) {
          this.log("error", "连接验证失败，请查看设备区域的具体错误。");
          this.update({ actionError: errorText(error) });
        }
        await this.scan();
      });
    } finally {
      this.pendingActions--;
      this.update({ activity: "idle" });
    }
  };

  private async cardAction(
    activity: "findingCard" | "readingCard" | "writingCard" | "checkingKeys",
    work: () => Promise<void>,
  ) {
    if (
      this.pendingActions ||
      !this.state.snapshot?.connection ||
      this.state.scanError
    )
      return;
    this.pendingActions++;
    this.update({ activity, actionError: null });
    try {
      await this.enqueue(async () => {
        // A preceding heartbeat may have invalidated the connection while this was queued.
        if (!this.state.snapshot?.connection || this.state.scanError) return;
        this.update({ activity });
        await work();
        await this.scan();
      });
    } finally {
      this.pendingActions--;
      this.update({ activity: "idle" });
    }
  }

  findCard = async () => {
    await this.cardAction("findingCard", async () => {
      this.log("info", "开始寻找 ISO 14443A 卡片。");
      this.update({
        cardState: initialCardState(),
        dictionary: initialReaderState().dictionary,
      });
      try {
        const card = await this.api.scanCard();
        this.log(
          card ? "success" : "info",
          card ? "已识别卡片，可选择读取范围。" : "感应区未发现卡片。",
        );
        this.update({
          cardState: { card, dump: null, error: null, checkedAt: Date.now() },
        });
      } catch (error) {
        this.log("error", "寻卡失败，请查看卡片操作区域的具体错误。");
        this.update({
          cardState: { ...initialCardState(), error: errorText(error) },
        });
      }
    });
  };

  readCard = async (request: ReadRequest) => {
    // Own the queued request so reusing an input object cannot alter an active command.
    const command = { ...request };
    try {
      await this.cardAction("readingCard", async () => {
        if (this.state.cardState.card?.uid !== command.uid) return;
        this.log(
          "info",
          `开始读取${command.mode === "type2" ? "页" : "块"} ${command.start}–${command.start + command.count - 1}，正在重新核对卡片。`,
        );
        this.update({
          cardState: { ...this.state.cardState, dump: null, error: null },
        });
        try {
          const dump = await this.api.readCard(command);
          this.log(
            dump.complete ? "success" : "error",
            `${dump.complete ? "所选范围读取完成" : "读取未完成"}：获得 ${dump.rows.length} 个数据单元。`,
          );
          this.update({
            cardState: {
              card: dump.card,
              dump,
              error: null,
              checkedAt: Date.now(),
            },
          });
        } catch (error) {
          // A failed activation or UID mismatch requires a new identification.
          this.log("error", "读取失败，请查看卡片操作区域的错误并重新识别。");
          this.update({
            cardState: { ...initialCardState(), error: errorText(error) },
            dictionary: initialReaderState().dictionary,
          });
        } finally {
          command.key = null;
        }
      });
    } finally {
      // Request objects are ephemeral and never part of observable state.
      command.key = null;
      request.key = null;
    }
  };

  writeCard = async (request: WriteRequest) => {
    const command = { ...request };
    try {
      await this.cardAction("writingCard", async () => {
        const { card, dump } = this.state.cardState;
        if (
          !card ||
          card.uid !== command.uid ||
          !dump?.complete ||
          dump.mode !== command.mode ||
          !dump.rows.some(
            (row) =>
              row.address === command.address &&
              row.hex.toUpperCase() === command.expectedHex.toUpperCase(),
          )
        )
          return;
        this.log(
          "info",
          `开始单${command.mode === "type2" ? "页" : "块"}写入：地址 ${command.address}；正在检查 UID 与原数据。`,
        );
        this.update({
          lastWrite: null,
          cardState: { ...this.state.cardState, dump: null, error: null },
        });
        try {
          const result = await this.api.writeCard(command);
          this.log(
            result.verified && !result.error ? "success" : "error",
            result.verified
              ? result.error
                ? "数据读回一致，但会话结束异常，请查看最近写入结果。"
                : result.writeAttempted
                  ? "写入已读回校验，目标数据一致。"
                  : "原数据与目标一致，未发送写入命令。"
              : result.writeAttempted
                ? "写入结果未确认，数据可能已改变。请重新读取，勿直接重试。"
                : "写入被阻止，未发送写入命令。",
          );
          this.update({
            lastWrite: result,
            cardState: {
              card: result.card,
              dump: null,
              error: null,
              checkedAt: Date.now(),
            },
          });
        } catch (error) {
          // A rejected IPC call cannot establish whether the device received the write.
          this.log(
            "error",
            "写入结果未知，卡片数据可能已改变。请重新读取，勿直接重试。",
          );
          this.update({
            lastWrite: {
              card,
              mode: command.mode,
              address: command.address,
              beforeHex: null,
              afterHex: null,
              writeAttempted: true,
              verified: false,
              error: `写入结果未知：${errorText(error)}。请重新读取检查，勿直接重试。`,
            },
            cardState: initialCardState(),
            dictionary: initialReaderState().dictionary,
          });
        } finally {
          command.key = null;
        }
      });
    } finally {
      command.key = null;
      request.key = null;
    }
  };

  checkDictionary = async (request: DictionaryRequest) => {
    const command = { ...request, keys: [...request.keys] };
    try {
      await this.cardAction("checkingKeys", async () => {
        const card = this.state.cardState.card;
        if (!card || card.uid !== command.uid || !classicSectors(card)) return;
        this.update({
          cardState: { ...this.state.cardState, dump: null, error: null },
          dictionary: {
            runId: command.runId,
            progress: null,
            result: null,
            error: null,
            cancelling: false,
          },
        });
        this.log(
          "info",
          `开始字典密钥检测：扇区 ${command.startSector}–${command.startSector + command.sectorCount - 1}。此操作不推导字典之外的密钥。`,
        );
        try {
          const result = await this.api.checkDictionary(command);
          this.update({
            cardState: {
              card: result.dump.card,
              dump: result.dump,
              error: null,
              checkedAt: Date.now(),
            },
            dictionary: {
              ...this.state.dictionary,
              runId: null,
              result,
              error: null,
              cancelling: false,
            },
          });
          const hits = result.sectors.reduce(
            (count, sector) =>
              count + Number(!!sector.keyA) + Number(!!sector.keyB),
            0,
          );
          this.log(
            result.error || !result.dump.complete ? "info" : "success",
            `字典检测${result.cancelled ? "已取消" : "已结束"}：命中 ${hits} 个认证密钥，读取 ${result.dump.rows.length} 块；请查看结果与范围。`,
          );
        } catch {
          // Raw errors from long-running work must not expose request keys in logs/state.
          this.update({
            cardState: initialCardState(),
            dictionary: {
              runId: null,
              progress: null,
              result: null,
              error: "字典检测未完成，请检查设备连接并重新识别卡片。",
              cancelling: false,
            },
          });
          this.log("error", "字典检测失败，请检查连接并重新识别卡片。");
        }
      });
    } finally {
      command.keys.fill("");
      command.keys = [];
      request.keys.fill("");
      request.keys = [];
    }
  };

  // Progress and cancellation deliberately bypass the serial queue. These commands
  // access only the task manager, never the UART handle held by the running job.
  pollDictionary = async () => {
    const runId = this.state.dictionary.runId;
    if (!runId || this.progressPending) return;
    this.progressPending = true;
    try {
      const progress = await this.api.dictionaryProgress(runId);
      if (this.state.dictionary.runId === runId && progress) {
        this.update({ dictionary: { ...this.state.dictionary, progress } });
      }
    } catch {
      /* A transient progress failure never fabricates completion. */
    } finally {
      this.progressPending = false;
    }
  };

  cancelDictionary = async () => {
    const runId = this.state.dictionary.runId;
    if (!runId || this.state.dictionary.cancelling) return;
    this.update({
      dictionary: { ...this.state.dictionary, cancelling: true, error: null },
    });
    try {
      const accepted = await this.api.cancelDictionary(runId);
      if (this.state.dictionary.runId === runId && !accepted) {
        this.update({
          dictionary: {
            ...this.state.dictionary,
            cancelling: false,
            error: "任务尚未确认取消，请稍后重试或等待结果。",
          },
        });
      }
    } catch {
      if (this.state.dictionary.runId === runId)
        this.update({
          dictionary: {
            ...this.state.dictionary,
            cancelling: false,
            error: "取消请求失败，请重试；任务可能仍在运行。",
          },
        });
    }
  };

  clearCard = () => {
    if (this.pendingActions) return;
    this.update({
      cardState: initialCardState(),
      lastWrite: null,
      dictionary: initialReaderState().dictionary,
    });
  };

  disconnect = async () => {
    if (this.pendingActions) return;
    const selected = this.state.snapshot?.ports.find(
      (port) => port.portName === this.state.snapshot?.connection?.portName,
    );
    if (selected) this.attemptedDevices.add(deviceKey(selected));
    this.pendingActions++;
    this.update({
      activity: "disconnecting",
      actionError: null,
      cardState: initialCardState(),
      dictionary: initialReaderState().dictionary,
    });
    try {
      await this.enqueue(async () => {
        this.update({ activity: "disconnecting" });
        try {
          await this.api.disconnect();
          this.log("info", "已手动断开设备，当前卡片数据已清除。");
          this.update({
            snapshot: {
              ports: this.state.snapshot?.ports ?? [],
              connection: null,
              connectionError: null,
            },
            scanError: null,
          });
        } catch (error) {
          this.update({ actionError: `断开失败：${errorText(error)}` });
        }
        await this.scan();
      });
    } finally {
      this.pendingActions--;
      this.update({ activity: "idle" });
    }
  };
}
