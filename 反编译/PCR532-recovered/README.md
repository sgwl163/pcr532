# PCR532 代码恢复结果

已从 `D:\tools\PCR532` 的三个 .NET 程序导出 C# 代码、项目文件和资源。

| 原始程序 | 程序集版本 | C# 文件 | 资源文件 |
| --- | --- | ---: | ---: |
| PN532CardReader.exe | 1.0.6.9 | 40 | 12 |
| ChameleonMiniGUI.exe | 1.3.0.3 | 47 | 3 |
| update.exe | 1.0.0.0 | 6 | 1 |
| 合计 | | 93 | 16 |

主程序是 x86、.NET Framework 4.6、Windows Forms 应用。REA 静态检查识别到 102 个类型定义和 1,139 个方法定义，元数据覆盖状态为完整。类型定义包含嵌套类型、编译器生成类型和 `<Module>`，因此不会对应同等数量的 C# 文件。

## 从哪里开始阅读

- 主窗体：`PN532CardReader\MifareOneTool\Form1.cs`
- 其他界面：同目录下的 `FormHTool.cs`、`FormDiff.cs`、`cardinfo.cs` 等。
- 主程序项目：`PN532CardReader\PN532CardReader.csproj`
- ChameleonMiniGUI 和更新器：分别位于同名目录。
- 证据和反编译日志：`evidence` 目录。
- 程序哈希、版本、导出数量、REA 证据标识：`recovery-manifest.json`。

## 恢复范围与限制

这是从已编译程序生成的反编译代码，不是原始开发仓库。主程序存在 `DotfuscatorAttribute` 和名称、控制流混淆痕迹，部分名称为 `a`、`b` 等，部分方法包含较多跳转。原始注释、局部变量名、历史版本和原始工程组织无法据此完整还原。

`PN532CardReader.pdb` 和 `update.pdb` 均为 0 字节，不能提供有效调试符号。三个项目均导出成功，ILSpy 退出码为 0，日志为空，导出的 C# 文件未发现常见反编译失败标记。原始程序哈希在导出后已与 REA 记录核对一致。

尚未验证重新编译或功能等价性。当前机器有 .NET 运行时，未发现 .NET SDK；生成的项目引用仍指向原安装目录中的依赖 DLL。要获得可维护、可重新构建的工程，还需整理混淆代码、依赖、入口点及构建环境。

本次没有恢复 `nfc-bin` 下外部 EXE/DLL、驱动的源代码，也没有执行原程序或连接读卡设备。部分业务流程通过主程序调用这些外部组件，其内部实现不包含在本次恢复的 C# 项目中。

## 工具与证据

- REA 6.7.0：静态读取 PE/CLI 元数据和 CIL 成员信息。
- ILSpyCmd 9.1.0.7988：静态反编译并导出 C# 项目与资源，通过本机 .NET 8 运行时运行。
- 工具包来源：`https://api.nuget.org/v3-flatcontainer/ilspycmd/9.1.0.7988/ilspycmd.9.1.0.7988.nupkg`。
- 主程序 REA 证据：`ev_3e6df40380e7b6c48e0f3e7b900250ee52b460a5358a4bb4b4dea4168c903a61`。
- 主程序成员证据：`ev_e57d5ec617b4dd35589399d59b78d7924a6247dec6e78f66b9da31cab265450d`。

压缩包包含三个恢复项目、本说明和恢复清单；较大的完整 REA 证据保留在工作目录，未放入压缩包。
