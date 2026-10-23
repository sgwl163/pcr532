# PCR532 Desktop

基于 **Tauri 2 + React + TypeScript + Rust** 的桌面应用基础项目，面向 Windows 开发。界面统一使用 **shadcn/ui + Tailwind CSS v4 + lucide-react**。

目前支持真实串口枚举、自动或手动连接 PN532 读卡器、固件版本查询、连接心跳和断开连接，以及 **ISO 14443A 卡片识别与授权范围内的只读数据查看**；保留 `get_app_info` 命令验证前后端通信。应用只面向 Tauri 桌面端，不提供浏览器模式。当前不提供写卡、修改 UID、密钥搜索或破解功能。`反编译/` 中的 C# 文件仅作为分析参考，不参与构建，也不会执行其中的原程序或更新器。

## 开发环境

- Node.js 24 LTS + npm（Vite 要求 Node.js 20.19+ 或 22.12+）
- Rust stable，目标 `x86_64-pc-windows-msvc`
- Visual Studio 2022 / Build Tools，包含“使用 C++ 的桌面开发”工具链及 Windows SDK
- Microsoft Edge WebView2 Runtime

首次安装依赖运行 `npm install`。已有锁文件时建议使用 `npm ci`。

## 启动

在项目目录中执行 `npm run tauri dev`，启动 Windows 桌面应用，支持前端热更新。`npm run dev` 仅供 Tauri 在开发时启动内部前端服务器，请通过桌面窗口使用应用。

桌面启动后自动读取系统串口列表，每 3 秒刷新。启动或检测到重新插入时，如果只有一个候选设备，会按当前波特率（默认 115200）自动尝试一次连接；有多个候选设备或未知型号时，手动选择串口并点击“连接并验证”。只有收到校验正确、芯片编号为 PN532 的固件响应后才显示已连接，并保留串口用于连接心跳；点击断开或退出应用后释放串口。手动断开后保持断开；失败后保留具体错误，可手动重试，避免每次轮询重复探测。

CH340、CP210x、FTDI 等是通用 USB 转串口芯片，列表标记为候选设备，不代表已经确认 PN532。程序仅自动探测唯一的候选串口，不遍历其他串口，也不会改写设备波特率。初始化只发送 UART 唤醒序列、清理未完成命令的 ACK、SAM 正常模式设置和固件查询，不读取卡片、不写卡、不进行认证或刷写固件。连接失败时可检查原软件是否占用串口、选择的波特率是否匹配，以及硬件是否处于 UART 模式。

### 卡片识别与只读数据

1. 连接并验证读卡器，将自有或已获授权的卡片放稳在感应区。
2. 点击“寻卡 / 重新识别”，显示 UID、UID 长度、ATQA（应答类型）、SAK（选择应答）及初步卡片类型。无卡是正常结果；程序不自动轮询卡片。
3. 对支持的类型选择起始地址和数量，点击“读取所选范围”。读取前会再次寻卡并核对 UID；换卡后请重新识别，UID 相同不代表是同一张物理卡片。
4. 数据显示为十进制地址和十六进制原始字节。部分读取失败会标为“读取未完成”，并保留已成功读取的行和错误位置；不能视为整卡数据。

支持范围：

- MIFARE Mini / Classic 1K / Classic 4K：按块读取，每块 16 字节，范围分别为 0–19、0–63、0–255。每次 1–16 块；必须手动输入 Key A 或 Key B 的一个已知 6 字节密钥（12 位十六进制）。跨扇区继续使用同一密钥，认证失败即停止，不会尝试其他密钥。扇区尾块中的密钥字节受卡片访问规则影响，返回值不代表可用密钥。
- Ultralight / NTAG 等 Type 2：仅初步识别为家族，尚未确认精确型号，因此保守限定为前 16 页（0–15），每页 4 字节，每次 1–16 页。
- ISO 14443-4 A 及其他未知 ISO 14443A 类型：仅显示识别信息，不读取数据。不支持 ISO 14443B、FeliCa 等其他协议。

所有类型均由协议响应初步判断，不能据此验证真伪或确认厂商型号。密钥输入没有默认值，提交后清空，不写入配置文件或日志；卡片信息和数据仅保留在当前窗口状态，清除结果、断开连接或连接失效后移除。

寻卡、读取、固件心跳和连接操作共用执行队列及独占串口会话。操作期间暂停新的前端心跳和重复操作；每次结束后重新检查连接。串口超时或帧校验异常可能导致会话失效，需要重新连接，避免迟到响应影响后续命令。普通无卡和卡片认证失败与串口连接故障分别处理。

**验证范围：**新增卡片功能已通过模拟协议、状态及界面交互测试，尚未对实体卡片完成寻卡、认证与读取回归。上文 COM7 的历史实测只涵盖读卡器连接，不代表卡片功能已实测。

### 驱动

CH340/CH341 型号使用 WCH 的 CH341SER 串口驱动。Windows 设备管理器正常出现 `USB-SERIAL CH340 (COMx)` 表示系统已识别串口；若 PN532 固件握手成功，则当前串口驱动已可用于本应用，无需另装专用 NFC 驱动。仅当设备管理器出现未知设备、黄色感叹号或驱动错误时，再通过 Windows Update 或芯片厂商官方渠道安装匹配驱动。本应用不运行反编译目录附带的驱动安装器。

本机验证结果：`COM7`，WCH 已签名驱动 `3.9.2024.9`，115200 baud，PN532 固件 `1.6`。该结果是当前机器的实测记录，不硬编码到应用状态；实际界面始终读取系统和设备响应。

“测试后端通信”只读取应用名称、版本、操作系统和处理器架构，不访问硬件。

### 反编译代码参考范围

只读核对 `反编译/PCR532-recovered/PN532CardReader/MifareOneTool/` 中的连接流程：

- `drvier.cs` 第 49 行调用 `driver/CH341SER.EXE`；第 263、270 行区分 CH340 驱动和 CDC 型号。这是原软件的驱动入口，不是本应用运行时依赖。
- `Form1.cs` 第 13626–13949 行的 `a(string, string)` 使用所选串口、8 数据位、1 停止位、无校验；发送以 `55 55` 开头的唤醒与 SAM 正常模式命令，并比对 ACK 和 SAM 响应。它还先调用第 13253 行附近的 `b(string, string)` 发送 `SETTING=9\r\n`；这是原软件特定的前置命令，当前 PN532 已实测无需该命令即可连接，因此本应用没有照搬。
- 本应用独立使用 Rust 串口库，保留唤醒、ACK 和 SAM 初始化，同时额外验证带校验和的 PN532 固件响应。由于当前 COM7 的完整握手和心跳已通过，没有盲目移植原程序的延迟、联网或驱动安装逻辑。

这些是对现有反编译文本的静态核对；未运行原软件、驱动安装器或更新器，也不依赖其 `libnfc` 外部程序。

## 检查与构建

- `npm test`：全部前端逻辑与 React 界面交互测试，无需硬件（Node.js 24）。
- `npm run test:logic`：设备状态、自动连接、手动断开、卡片范围校验和串行操作回归测试。
- `npm run test:ui`：卡片界面交互测试，使用 Vitest、jsdom 和 React Testing Library。
- `npm run check`：应用、构建配置及测试的 TypeScript 类型检查。
- `npm run build`：类型检查及前端生产构建，输出至 `dist/`。
- `cargo fmt --manifest-path src-tauri/Cargo.toml -- --check`：Rust 格式检查。
- `cargo test --manifest-path src-tauri/Cargo.toml`：Rust 测试。
- `npm run tauri build -- --debug --no-bundle`：生成调试版桌面程序，不制作安装包。
- `npm run tauri build`：生成正式版桌面程序和安装包。

调试版可执行文件：`src-tauri/target/debug/pcr532-desktop.exe`。

正式版可执行文件：`src-tauri/target/release/pcr532-desktop.exe`。

安装包目录：`src-tauri/target/release/bundle/`（默认 Windows 打包目标为 MSI 和 NSIS）。首次正式打包可能需要联网下载相应工具；生成 MSI 还需要启用 Windows 的 VBSCRIPT 可选功能。仅运行开发模式或构建 EXE 不需要此功能。

前端和 Rust 的依赖锁文件分别为 `package-lock.json` 与 `src-tauri/Cargo.lock`，请保留以便复现构建。

## 项目结构

- `src/App.tsx`：桌面工作台和后端诊断。
- `src/components/reader-panel.tsx`：设备面板及定时连接检测。
- `src/components/card-panel.tsx`：卡片识别、已知密钥输入及只读结果界面。
- `src/lib/reader.ts`：共享连接和卡片状态、命令串行化和唯一候选设备自动连接。
- `src/lib/cards.ts`：卡片数据类型、容量及读取参数校验。
- `src/lib/desktop-reader.ts`：桌面端 Tauri 命令调用。
- `tests/reader.test.ts`、`tests/cards.test.ts`：设备和卡片逻辑回归测试。
- `tests/card-panel.test.tsx`：卡片界面交互测试。
- `vitest.config.ts`、`tsconfig.test.json`：界面测试和测试类型检查配置。
- `src/index.css`：Tailwind CSS 入口及 shadcn/ui 主题变量。
- `src/components/ui/`：通过 shadcn CLI 引入的组件源码。
- `src/lib/utils.ts`：shadcn 生成的 className 合并工具入口。
- `components.json`：shadcn/ui 组件生成配置，使用 Radix Nova 风格及 Lucide 图标。
- `src-tauri/src/lib.rs`：Tauri 命令注册及应用初始化。
- `src-tauri/src/reader.rs`：串口枚举、串口独占会话、连接和心跳检测。
- `src-tauri/src/pn532.rs`：PN532 帧封装与校验、卡片响应解析及芯片初始化命令。
- `src-tauri/src/cards.rs`：ISO 14443A 寻卡、UID 核对、已知密钥认证和只读操作。
- `src-tauri/tauri.conf.json`：窗口、应用标识、构建和安全策略。
- `src-tauri/capabilities/default.json`：Tauri 2 权限配置。
- `vite.config.ts`：前端开发服务器配置，默认端口 1420。

当前应用标识为 `com.pcr532.desktop`，正式发布前应按实际归属修改。当前图标为 Tauri 模板图标。

## 界面开发约定

- 使用 `src/components/ui/` 中的 shadcn/ui 组件，按需添加，不一次性引入整套组件。
- 添加组件：`npx shadcn@latest add input select tabs`（示例；会生成本地组件源码及安装对应依赖）。
- 布局使用 Tailwind CSS 工具类；主题通过 `src/index.css` 中的语义变量统一调整。
- 图标从 `lucide-react` 按名称导入；纯装饰图标设置 `aria-hidden="true"`，仅图标按钮提供可访问名称。
- `@/` 指向 `src/`，已同时配置 TypeScript 和 Vite。
- Geist 字体随应用本地打包，中文回退到系统字体；运行时无需访问远程字体或 CSS 服务。
- `src/index.css` 保留亮色及暗色主题变量；当前页面使用亮色主题，尚未添加主题切换。
- shadcn 的共享样式已通过官方 `eject` 命令内联到 `src/index.css`，无需保留 CLI 的依赖树。组件源码仍可编辑、按需添加；升级共享样式需手动同步。

## 后续开发

设备连接和首版只读卡片流程已接入。下一步优先完成实体卡片回归，包括无卡、换卡、移开卡片、错误密钥、跨扇区与设备拔插；精确型号识别及扩大读取范围应在硬件验证后另行开发。

## 可选硬件回归

常规 `cargo test` 不打开串口。需要在本机验证真实设备时，在 PowerShell 中先将环境变量 `PCR532_TEST_PORT` 设置为设备管理器中对应的串口名（例如 COM7），可选设置 `PCR532_TEST_BAUD`（默认 115200），再运行 `cargo test --manifest-path src-tauri/Cargo.toml inspect_local_reader -- --ignored --nocapture`。请先在应用和其他软件中断开该串口。

此测试使用与应用相同的枚举、初始化、固件查询和连接管理代码，验证重复心跳、断开后的串口释放与重新连接，不发送卡片指令。物理拔出与重新插入需要在真实硬件上另行验证。
