import { CircleAlert, Database } from "lucide-react";

import type { CardDump } from "@/lib/cards";
import { readCapability } from "@/lib/cards";
import type { ReaderState } from "@/lib/reader";

/** Explains acquisition separately from interpretation; never starts device commands. */
export function DataAcquisitionStatus({
  state,
  dump,
  sourceName,
}: {
  state: ReaderState;
  dump: CardDump | null;
  sourceName?: string;
}) {
  const bytes = dump?.rows.reduce((total, row) => total + row.hex.length / 2, 0) ?? 0;
  const unit = dump?.mode === "type2" ? "页" : "块";
  const connection = state.snapshot?.connection;
  const capability = state.cardState.card ? readCapability(state.cardState.card) : null;
  let title: string;
  let detail: string;
  let issue: string | null = null;
  let tone: "neutral" | "warning" | "success" = "neutral";

  if (sourceName && dump) {
    title = `离线文件已载入 ${bytes} B · ${dump.rows.length} ${unit}`;
    detail = "已取得原始字节不等于已解密业务字段。文本或日期为空时，可能缺少对应的编码规则；文件内容不代表实卡读取成功。";
    issue = dump.error;
    tone = issue ? "warning" : "neutral";
  } else if (["findingCard", "readingCard", "checkingKeys", "writingCard"].includes(state.activity)) {
    title = state.activity === "findingCard" ? "正在识别卡片" : state.activity === "readingCard" ? "正在获取原始数据" : state.activity === "checkingKeys" ? "正在执行已授权的密钥检测" : "正在写入并核对结果";
    detail = "等待本次操作结束；原始数据是否取得，以返回的字节数和错误提示为准。";
  } else if (state.scanError || !connection) {
    title = "尚未建立可验证的设备连接";
    issue = state.scanError || state.actionError || state.snapshot?.connectionError || null;
    detail = "请通过 PCR532 桌面程序连接并验证读卡器，再识别卡片。浏览器预览只能分析离线文件，不能访问串口。";
    tone = issue ? "warning" : "neutral";
  } else if (state.cardState.error || state.dictionary.error) {
    title = "卡片操作失败，当前没有读取结果";
    issue = state.cardState.error || state.dictionary.error;
    detail = "请根据错误检查连接和卡片位置，再重新识别。读取受保护内容需要合法的认证密钥，界面不能绕过认证。";
    tone = "warning";
  } else if (dump) {
    if (!dump.rows.length) {
      title = "本次读取未获得数据（0 B）";
      detail = "当前没有原始字节可供解析。认证失败时请向发卡方确认相应扇区的合法密钥和读取权限；通信失败时检查连接与卡片位置。";
      tone = "warning";
    } else {
      title = `已取得原始数据 ${bytes} B · ${dump.rows.length} ${unit}${dump.complete ? "" : "（部分结果）"}`;
      detail = "已取得原始字节不等于已解密业务字段。仅代表本次读取范围；房号、权限和有效期需要对应格式说明，不能从任意二进制数据直接确认。";
      tone = dump.complete && !dump.error ? "success" : "warning";
    }
    issue = dump.error;
  } else if (state.cardState.card) {
    title = capability ? "已识别卡片，尚未读取原始数据" : "已识别卡片，当前卡型仅支持识别";
    detail = capability
      ? "识别 UID 不等于读取用户区。请展开操作面板，选择读取范围；Classic 卡还需要输入已获授权的已知密钥。"
      : "此卡型的应用数据读取与认证尚未实现，需要匹配的卡片协议，不能套用 Classic 读取流程。";
  } else {
    title = state.cardState.checkedAt ? "本次识别没有发现卡片" : "设备已连接，等待识别卡片";
    detail = "将卡片放稳在感应区，展开操作面板并点击“寻卡 / 重新识别”；识别和读取是两个步骤。";
  }

  return (
    <section className="data-acquisition-status" data-tone={tone} aria-labelledby="acquisition-title">
      <div role="status" aria-live="polite" aria-atomic="true">
        <h2 id="acquisition-title" className="sr-only">数据获取状态</h2>
        <p className="acquisition-summary">
          {tone === "warning" ? <CircleAlert aria-hidden="true" /> : <Database aria-hidden="true" />}
          <strong>{title}</strong>
        </p>
        {issue && <p className="acquisition-error">{issue}</p>}
        <p className="acquisition-detail">{detail}</p>
      </div>
    </section>
  );
}
