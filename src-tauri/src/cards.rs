//! Read-only ISO14443A card operations. No write or key-search commands.

#[derive(Clone, Debug, PartialEq, Eq)]
pub struct CardTarget {
    pub number: u8,
    pub uid: Vec<u8>,
    pub atqa: [u8; 2],
    pub sak: u8,
}

#[derive(Clone, Debug, serde::Serialize)]
#[serde(rename_all = "camelCase")]
pub struct CardInfo {
    pub uid: String,
    pub uid_length: usize,
    pub atqa: String,
    pub sak: String,
    pub family: &'static str,
    pub type_name: &'static str,
}

pub fn hex(bytes: &[u8]) -> String {
    bytes.iter().map(|byte| format!("{byte:02X}")).collect()
}

impl CardTarget {
    pub fn info(&self) -> CardInfo {
        let (family, type_name) = match self.sak {
            0x08 => ("classic1k", "MIFARE Classic 1K（初步识别）"),
            0x18 => ("classic4k", "MIFARE Classic 4K（初步识别）"),
            0x09 => ("classicMini", "MIFARE Mini（初步识别）"),
            0x00 => ("type2", "Ultralight / NTAG 等（初步识别）"),
            _ if self.sak & 0x20 != 0 => ("iso14443_4", "ISO 14443-4 A（仅识别）"),
            _ => ("unknown", "ISO 14443A（型号待确认）"),
        };
        CardInfo {
            uid: hex(&self.uid), uid_length: self.uid.len(), atqa: hex(&self.atqa),
            sak: format!("{:02X}", self.sak), family, type_name,
        }
    }
}

use crate::pn532;

// The closure exchanges one PN532 command and returns its checked payload.
type Exchange<'a> = dyn FnMut(&[u8], u8) -> Result<Vec<u8>, String> + 'a;

#[derive(serde::Deserialize)]
#[serde(rename_all = "camelCase", deny_unknown_fields)]
pub struct ReadRequest {
    pub uid: String,
    pub mode: String,
    pub start: u16,
    pub count: u16,
    pub key_type: Option<String>,
    pub key: Option<String>,
}

#[derive(Debug, serde::Serialize)]
#[serde(rename_all = "camelCase")]
pub struct DataRow {
    pub address: u16,
    pub hex: String,
}

#[derive(Debug, serde::Serialize)]
#[serde(rename_all = "camelCase")]
pub struct CardDump {
    pub card: CardInfo,
    pub mode: String,
    pub rows: Vec<DataRow>,
    pub complete: bool,
    pub error: Option<String>,
}

fn detect(exchange: &mut Exchange<'_>) -> Result<Option<CardTarget>, String> {
    // Finite passive activation retries: no-card must produce NbTg=0, not hang.
    let configured = exchange(&[0x32, 0x05, 0xff, 0x01, 0x01], 0x33)?;
    if !configured.is_empty() { return Err("寻卡参数设置响应异常".into()); }
    pn532::parse_target_payload(&exchange(&[0x4a, 1, 0], 0x4b)?)
}

fn release(exchange: &mut Exchange<'_>, number: u8) -> Result<(), String> {
    let response = exchange(&[0x52, number], 0x53)?;
    pn532::exchange_data(&response, 0)?;
    Ok(())
}

pub fn scan_card(exchange: &mut Exchange<'_>) -> Result<Option<CardInfo>, String> {
    let Some(target) = detect(exchange)? else { return Ok(None); };
    release(exchange, target.number)?;
    Ok(Some(target.info()))
}

fn key_bytes(key: Option<&str>) -> Result<[u8; 6], String> {
    let key = key.unwrap_or("");
    if key.len() != 12 || !key.bytes().all(|byte| byte.is_ascii_hexdigit()) {
        return Err("请输入已知密钥：12 位十六进制（6 字节），不会自动尝试其他密钥".into());
    }
    let mut bytes = [0; 6];
    for (index, byte) in bytes.iter_mut().enumerate() {
        *byte = u8::from_str_radix(&key[index * 2..index * 2 + 2], 16).map_err(|_| "密钥格式无效")?;
    }
    Ok(bytes)
}

fn sector(block: u16) -> u16 {
    if block < 128 { block / 4 } else { 32 + (block - 128) / 16 }
}

pub fn read_card(request: &ReadRequest, exchange: &mut Exchange<'_>) -> Result<CardDump, String> {
    if ![8, 14, 20].contains(&request.uid.len()) || !request.uid.bytes().all(|byte| byte.is_ascii_hexdigit()) {
        return Err("卡片标识无效，请重新寻卡".into());
    }
    if request.count == 0 || request.count > 16 {
        return Err("每次只读 1–16 个数据单元".into());
    }
    let end = request.start.checked_add(request.count).filter(|end| *end <= 256)
        .ok_or("读取范围超出地址上限")?;
    let classic_key = match request.mode.as_str() {
        "classic" => {
            if !matches!(request.key_type.as_deref(), Some("A" | "B")) { return Err("请选择 Key A 或 Key B".into()); }
            Some(key_bytes(request.key.as_deref())?)
        },
        "type2" if end <= 16 => None,
        "type2" => return Err("型号未精确确认，当前仅允许读取 Type 2 的前 16 页".into()),
        _ => return Err("此卡片类型暂不支持数据读取".into()),
    };
    let target = detect(exchange)?.ok_or("未发现卡片，请保持卡片放在感应区")?;
    let result = (|| {
        if !request.uid.eq_ignore_ascii_case(&hex(&target.uid)) {
            return Err("检测到卡片已更换，请重新寻卡后读取".into());
        }
        let info = target.info();
        let capacity = match info.family {
            "classicMini" => 20, "classic1k" => 64, "classic4k" => 256,
            "type2" => 16, _ => return Err("此卡片类型暂不支持数据读取".into()),
        };
        if (classic_key.is_some() && !info.family.starts_with("classic"))
            || (classic_key.is_none() && info.family != "type2") || end > capacity {
            return Err("读取模式或地址范围与实际卡片不匹配".into());
        }
        let mut rows = Vec::new();
        let mut authenticated_sector = None;
        let mut failure = None;
        for address in request.start..end {
            let result = (|| {
                if let Some(key) = classic_key {
                    if target.uid.len() < 4 { return Err("卡片 UID 不完整".into()); }
                    if authenticated_sector != Some(sector(address)) {
                        let mut auth = vec![0x40, target.number, if request.key_type.as_deref() == Some("B") { 0x61 } else { 0x60 }, address as u8];
                        auth.extend_from_slice(&key);
                        auth.extend_from_slice(&target.uid[target.uid.len() - 4..]);
                        let response = exchange(&auth, 0x41);
                        auth.fill(0); // Never retain or log key-bearing commands.
                        pn532::exchange_data(&response?, 0)?;
                        authenticated_sector = Some(sector(address));
                    }
                }
                // Both Classic and Type 2 use READ 0x30; Type 2 returns four pages.
                let read_address = if classic_key.is_none() { address.min(12) } else { address };
                let response = exchange(&[0x40, target.number, 0x30, read_address as u8], 0x41)?;
                let bytes = pn532::exchange_data(&response, 16)?;
                let data = if classic_key.is_some() { bytes } else {
                    let offset = usize::from(address - read_address) * 4;
                    &bytes[offset..offset + 4]
                };
                rows.push(DataRow { address, hex: hex(data) });
                Ok::<(), String>(())
            })();
            if let Err(error) = result { failure = Some(format!("地址 {address}：{error}")); break; }
        }
        Ok(CardDump { card: info, mode: request.mode.clone(), rows, complete: failure.is_none(), error: failure })
    })();
    let released = release(exchange, target.number);
    match result {
        Ok(mut dump) => {
            if let Err(error) = released {
                dump.complete = false;
                dump.error = Some(match dump.error { Some(previous) => format!("{previous}；释放卡片失败：{error}"), None => format!("释放卡片失败：{error}") });
            }
            Ok(dump)
        },
        Err(error) => Err(error),
    }
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn read_requires_matching_card_and_valid_known_key_before_authentication() {
        let request = ReadRequest { uid: "12345678".into(), mode: "classic".into(), start: 0, count: 1, key_type: Some("A".into()), key: Some("112233445566".into()) };
        let mut calls = Vec::new();
        let result = read_card(&request, &mut |command, _| {
            calls.push(command.to_vec());
            match command[0] {
                0x32 => Ok(vec![]),
                0x4a => Ok(vec![1, 1, 0, 4, 8, 4, 0x98, 0x76, 0x54, 0x32]),
                0x52 => Ok(vec![0]),
                _ => panic!("must not authenticate/read a different card"),
            }
        });
        assert!(result.unwrap_err().contains("更换"));
        let invalid = ReadRequest { key: Some("FF".into()), ..request };
        assert!(read_card(&invalid, &mut |_, _| panic!("invalid key must not reach device")).unwrap_err().contains("12"));
    }

    #[test]
    fn known_key_reads_only_selected_range_and_releases_target() {
        let request = ReadRequest { uid: "04112233445566".into(), mode: "classic".into(), start: 4, count: 2, key_type: Some("B".into()), key: Some("112233445566".into()) };
        let mut commands = Vec::new();
        let dump = read_card(&request, &mut |command, _| {
            commands.push(command.to_vec());
            Ok(match command[0] {
                0x32 => vec![],
                0x4a => vec![1, 1, 0, 4, 8, 7, 4, 0x11, 0x22, 0x33, 0x44, 0x55, 0x66],
                0x40 if command[2] == 0x61 => vec![0],
                0x40 if command[2] == 0x30 => { let mut bytes = vec![0]; bytes.extend(0..16); bytes },
                0x52 => vec![0],
                _ => panic!("unexpected command"),
            })
        }).unwrap();
        assert!(dump.complete);
        assert_eq!(dump.rows.len(), 2);
        assert_eq!(dump.rows[0].address, 4);
        assert_eq!(dump.rows[0].hex, "000102030405060708090A0B0C0D0E0F");
        assert_eq!(commands[2], [0x40, 1, 0x61, 4, 0x11, 0x22, 0x33, 0x44, 0x55, 0x66, 0x33, 0x44, 0x55, 0x66]);
        assert_eq!(commands.iter().filter(|cmd| cmd.get(2) == Some(&0x61)).count(), 1);
        assert_eq!(commands.last().unwrap(), &[0x52, 1]);
    }

    #[test]
    fn failed_authentication_is_not_reported_as_complete_or_retried_with_other_keys() {
        let request = ReadRequest { uid: "12345678".into(), mode: "classic".into(), start: 0, count: 4, key_type: Some("A".into()), key: Some("112233445566".into()) };
        let mut authentications = 0;
        let dump = read_card(&request, &mut |command, _| {
            Ok(match command[0] {
                0x32 => vec![], 0x4a => vec![1, 1, 0, 4, 8, 4, 0x12, 0x34, 0x56, 0x78],
                0x40 => { authentications += 1; vec![0x14] }, 0x52 => vec![0],
                _ => unreachable!(),
            })
        }).unwrap();
        assert!(!dump.complete);
        assert!(dump.rows.is_empty());
        assert!(dump.error.unwrap().contains("认证失败"));
        assert_eq!(authentications, 1);
    }

    #[test]
    fn type2_reads_are_four_byte_pages_and_never_request_beyond_safe_window() {
        let request = ReadRequest { uid: "04112233445566".into(), mode: "type2".into(), start: 14, count: 2, key_type: None, key: None };
        let dump = read_card(&request, &mut |command, _| {
            Ok(match command[0] {
                0x32 => vec![], 0x4a => vec![1, 1, 0, 0x44, 0, 7, 4, 0x11, 0x22, 0x33, 0x44, 0x55, 0x66],
                0x40 => { assert_eq!(command, &[0x40, 1, 0x30, 12]); let mut bytes = vec![0]; bytes.extend(0..16); bytes },
                0x52 => vec![0], _ => unreachable!(),
            })
        }).unwrap();
        assert_eq!(dump.rows[0].hex, "08090A0B");
        assert_eq!(dump.rows[1].hex, "0C0D0E0F");
        let invalid = ReadRequest { count: 3, ..request };
        assert!(read_card(&invalid, &mut |_, _| panic!("invalid range")).is_err());
    }

    #[test]
    fn scan_no_card_is_a_normal_result_and_unknown_card_remains_identifiable() {
        assert!(scan_card(&mut |command, _| Ok(if command[0] == 0x32 { vec![] } else { vec![0] })).unwrap().is_none());
        let info = scan_card(&mut |command, _| Ok(match command[0] {
            0x32 => vec![], 0x4a => vec![1, 1, 0, 4, 0x20, 4, 1, 2, 3, 4], 0x52 => vec![0], _ => unreachable!(),
        })).unwrap().unwrap();
        assert_eq!(info.family, "iso14443_4");
    }

    #[test]
    fn identifies_classic_and_type2_without_claiming_exact_type2_model() {
        let classic = CardTarget { number: 1, uid: vec![0x12, 0x34, 0x56, 0x78], atqa: [0, 4], sak: 8 };
        let info = classic.info();
        assert_eq!(info.uid, "12345678");
        assert_eq!(info.atqa, "0004");
        assert_eq!(info.family, "classic1k");
        let type2 = CardTarget { sak: 0, ..classic };
        assert_eq!(type2.info().family, "type2");
        assert!(type2.info().type_name.contains("初步"));
    }
}
