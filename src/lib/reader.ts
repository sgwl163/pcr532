import { initialCardState, type CardDump, type CardInfo, type CardState, type ReadRequest } from "./cards.ts";

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

export type ReaderState = {
  snapshot: DeviceSnapshot | null;
  scanError: string | null;
  actionError: string | null;
  activity: "idle" | "scanning" | "connecting" | "disconnecting" | "findingCard" | "readingCard";
  cardState: CardState;
  selectedPort: string;
  baudRate: number;
  checkedAt: number | null;
};

export const BAUD_RATES = [9600, 19200, 38400, 57600, 115200, 230400, 460800, 921600];

export interface ReaderApi {
  snapshot(): Promise<DeviceSnapshot>;
  connect(portName: string, baudRate: number): Promise<ReaderConnection>;
  disconnect(): Promise<void>;
  scanCard(): Promise<CardInfo | null>;
  readCard(request: ReadRequest): Promise<CardDump>;
}

export function initialReaderState(): ReaderState {
  return {
    snapshot: null,
    scanError: null,
    actionError: null,
    activity: "idle",
    cardState: initialCardState(),
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
    return { title: "设备状态暂不可验证", detail: state.scanError, kind: "error" as const };
  }
  if (!state.snapshot) {
    return { title: "正在检测系统串口", detail: "正在读取系统设备列表，请稍候。", kind: "neutral" as const };
  }
  if (state.activity === "connecting") {
    return { title: "正在连接并验证读卡器", detail: `${state.selectedPort} · ${state.baudRate} baud · 正在查询 PN532 固件信息。`, kind: "neutral" as const };
  }
  if (state.activity === "disconnecting") {
    return { title: "正在断开读卡器", detail: "正在释放串口，请稍候。", kind: "neutral" as const };
  }
  if (state.actionError) {
    return { title: "设备操作失败", detail: state.actionError, kind: "error" as const };
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
    return { title: "读卡器连接已中断", detail: state.snapshot.connectionError, kind: "error" as const };
  }
  if (state.snapshot.ports.length > 0) {
    return {
      title: `已发现 ${state.snapshot.ports.length} 个串口，等待验证`,
      detail: "系统已识别串口。选择读卡器对应的端口并点击“连接并验证”，确认是否为 PN532 读卡器。",
      kind: "neutral" as const,
    };
  }
  return {
    title: "系统未发现串口",
    detail: "请检查 USB 数据线和驱动；如果读卡器不是串口型号，需要对应的其他连接方式。",
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
  private refreshing = false;

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
    return () => { this.listeners.delete(listener); };
  };

  private update(patch: Partial<ReaderState>) {
    this.state = { ...this.state, ...patch };
    this.listeners.forEach((listener) => listener());
  }

  private enqueue(work: () => Promise<void>) {
    const result = this.queue.then(work);
    this.queue = result.catch(() => {});
    return result;
  }

  private async scan() {
    try {
      const snapshot = await this.api.snapshot();
      const presentDevices = new Set(snapshot.ports.map(deviceKey));
      this.attemptedDevices = new Set([...this.attemptedDevices].filter((key) => presentDevices.has(key)));
      const activePort = snapshot.ports.find((port) => port.portName === snapshot.connection?.portName);
      if (activePort) this.attemptedDevices.add(deviceKey(activePort));
      this.update({
        snapshot,
        scanError: null,
        selectedPort: snapshot.connection?.portName ?? choosePort(snapshot.ports, this.state.selectedPort),
        checkedAt: Date.now(),
        ...(!snapshot.connection || this.state.scanError || !this.state.snapshot?.connection
          || snapshot.connection.portName !== this.state.snapshot.connection.portName
          || snapshot.connection.baudRate !== this.state.snapshot.connection.baudRate
          ? { cardState: initialCardState() } : {}),
      });
    } catch (error) {
      // Keep the last list for diagnosis, but never report stale data as current.
      this.update({ scanError: `设备检测失败：${errorText(error)}`, cardState: initialCardState() });
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
      const candidates = this.state.snapshot?.ports.filter((port) => port.isCandidate) ?? [];
      const candidate = candidates.length === 1 ? candidates[0] : undefined;
      if (this.autoConnect && candidate && !this.state.scanError && !this.pendingActions
        && !this.state.snapshot?.connection && candidate.portName === this.state.selectedPort
        && !this.attemptedDevices.has(deviceKey(candidate))) {
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
    if (!BAUD_RATES.includes(baudRate) || this.pendingActions || this.state.snapshot?.connection) return;
    this.update({ baudRate, actionError: null });
  };

  connect = async () => {
    if (this.pendingActions || this.state.snapshot?.connection) return;
    if (!this.state.selectedPort || this.state.scanError) return;
    const { selectedPort, baudRate } = this.state;
    const selected = this.state.snapshot?.ports.find((port) => port.portName === selectedPort);
    if (selected) this.attemptedDevices.add(deviceKey(selected));
    this.pendingActions++;
    this.update({ activity: "connecting", actionError: null });
    try {
      await this.enqueue(async () => {
        this.update({ activity: "connecting" });
        try {
          const connection = await this.api.connect(selectedPort, baudRate);
          this.update({
            snapshot: { ports: this.state.snapshot?.ports ?? [], connection, connectionError: null },
            scanError: null,
          });
        } catch (error) {
          this.update({ actionError: errorText(error) });
        }
        await this.scan();
      });
    } finally {
      this.pendingActions--;
      this.update({ activity: "idle" });
    }
  };

  private async cardAction(activity: "findingCard" | "readingCard", work: () => Promise<void>) {
    if (this.pendingActions || !this.state.snapshot?.connection || this.state.scanError) return;
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
      this.update({ cardState: initialCardState() });
      try {
        const card = await this.api.scanCard();
        this.update({ cardState: { card, dump: null, error: null, checkedAt: Date.now() } });
      } catch (error) {
        this.update({ cardState: { ...initialCardState(), error: errorText(error) } });
      }
    });
  };

  readCard = async (request: ReadRequest) => {
    try {
      await this.cardAction("readingCard", async () => {
        if (this.state.cardState.card?.uid !== request.uid) return;
        this.update({ cardState: { ...this.state.cardState, dump: null, error: null } });
        try {
          const dump = await this.api.readCard(request);
          this.update({ cardState: { card: dump.card, dump, error: null, checkedAt: Date.now() } });
        } catch (error) {
          // A failed activation or UID mismatch requires a new identification.
          this.update({ cardState: { ...initialCardState(), error: errorText(error) } });
        }
      });
    } finally {
      // Request objects are ephemeral and never part of observable state.
      request.key = null;
    }
  };

  clearCard = () => {
    if (this.pendingActions) return;
    this.update({ cardState: initialCardState() });
  };

  disconnect = async () => {
    if (this.pendingActions) return;
    const selected = this.state.snapshot?.ports.find((port) => port.portName === this.state.snapshot?.connection?.portName);
    if (selected) this.attemptedDevices.add(deviceKey(selected));
    this.pendingActions++;
    this.update({ activity: "disconnecting", actionError: null, cardState: initialCardState() });
    try {
      await this.enqueue(async () => {
        this.update({ activity: "disconnecting" });
        try {
          await this.api.disconnect();
          this.update({
            snapshot: { ports: this.state.snapshot?.ports ?? [], connection: null, connectionError: null },
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
