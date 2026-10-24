//! ISO14443A identification, reads and restricted single-unit writes. No key-search commands.

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
            uid: hex(&self.uid),
            uid_length: self.uid.len(),
            atqa: hex(&self.atqa),
            sak: format!("{:02X}", self.sak),
            family,
            type_name,
        }
    }
}

use crate::pn532;

// The closure exchanges one PN532 command and returns its checked payload.
pub(crate) type Exchange<'a> = dyn FnMut(&[u8], u8) -> Result<Vec<u8>, String> + 'a;

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

pub(crate) fn detect(exchange: &mut Exchange<'_>) -> Result<Option<CardTarget>, String> {
    // Finite passive activation retries: no-card must produce NbTg=0, not hang.
    let configured = exchange(&[0x32, 0x05, 0xff, 0x01, 0x01], 0x33)?;
    if !configured.is_empty() {
        return Err("寻卡参数设置响应异常".into());
    }
    pn532::parse_target_payload(&exchange(&[0x4a, 1, 0], 0x4b)?)
}

pub(crate) fn release(exchange: &mut Exchange<'_>, number: u8) -> Result<(), String> {
    let response = exchange(&[0x52, number], 0x53)?;
    pn532::exchange_data(&response, 0)?;
    Ok(())
}

pub fn scan_card(exchange: &mut Exchange<'_>) -> Result<Option<CardInfo>, String> {
    let Some(target) = detect(exchange)? else {
        return Ok(None);
    };
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
        *byte =
            u8::from_str_radix(&key[index * 2..index * 2 + 2], 16).map_err(|_| "密钥格式无效")?;
    }
    Ok(bytes)
}

fn sector(block: u16) -> u16 {
    if block < 128 {
        block / 4
    } else {
        32 + (block - 128) / 16
    }
}

pub fn read_card(request: &ReadRequest, exchange: &mut Exchange<'_>) -> Result<CardDump, String> {
    if ![8, 14, 20].contains(&request.uid.len())
        || !request.uid.bytes().all(|byte| byte.is_ascii_hexdigit())
    {
        return Err("卡片标识无效，请重新寻卡".into());
    }
    if request.count == 0 || request.count > 16 {
        return Err("每次只读 1–16 个数据单元".into());
    }
    let end = request
        .start
        .checked_add(request.count)
        .filter(|end| *end <= 256)
        .ok_or("读取范围超出地址上限")?;
    let classic_key = match request.mode.as_str() {
        "classic" => {
            if !matches!(request.key_type.as_deref(), Some("A" | "B")) {
                return Err("请选择 Key A 或 Key B".into());
            }
            Some(key_bytes(request.key.as_deref())?)
        }
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
            "classicMini" => 20,
            "classic1k" => 64,
            "classic4k" => 256,
            "type2" => 16,
            _ => return Err("此卡片类型暂不支持数据读取".into()),
        };
        if (classic_key.is_some() && !info.family.starts_with("classic"))
            || (classic_key.is_none() && info.family != "type2")
            || end > capacity
        {
            return Err("读取模式或地址范围与实际卡片不匹配".into());
        }
        let mut rows = Vec::new();
        let mut authenticated_sector = None;
        let mut failure = None;
        for address in request.start..end {
            let result = (|| {
                if let Some(key) = classic_key {
                    if target.uid.len() < 4 {
                        return Err("卡片 UID 不完整".into());
                    }
                    if authenticated_sector != Some(sector(address)) {
                        let mut auth = vec![
                            0x40,
                            target.number,
                            if request.key_type.as_deref() == Some("B") {
                                0x61
                            } else {
                                0x60
                            },
                            address as u8,
                        ];
                        auth.extend_from_slice(&key);
                        auth.extend_from_slice(&target.uid[target.uid.len() - 4..]);
                        let response = exchange(&auth, 0x41);
                        auth.fill(0); // Never retain or log key-bearing commands.
                        pn532::exchange_data(&response?, 0)?;
                        authenticated_sector = Some(sector(address));
                    }
                }
                // Both Classic and Type 2 use READ 0x30; Type 2 returns four pages.
                let read_address = if classic_key.is_none() {
                    address.min(12)
                } else {
                    address
                };
                let response = exchange(&[0x40, target.number, 0x30, read_address as u8], 0x41)?;
                let bytes = pn532::exchange_data(&response, 16)?;
                let data = if classic_key.is_some() {
                    bytes
                } else {
                    let offset = usize::from(address - read_address) * 4;
                    &bytes[offset..offset + 4]
                };
                rows.push(DataRow {
                    address,
                    hex: hex(data),
                });
                Ok::<(), String>(())
            })();
            if let Err(error) = result {
                failure = Some(format!("地址 {address}：{error}"));
                break;
            }
        }
        Ok(CardDump {
            card: info,
            mode: request.mode.clone(),
            rows,
            complete: failure.is_none(),
            error: failure,
        })
    })();
    let released = release(exchange, target.number);
    match result {
        Ok(mut dump) => {
            if let Err(error) = released {
                dump.complete = false;
                dump.error = Some(match dump.error {
                    Some(previous) => format!("{previous}；释放卡片失败：{error}"),
                    None => format!("释放卡片失败：{error}"),
                });
            }
            Ok(dump)
        }
        Err(error) => Err(error),
    }
}

#[derive(serde::Deserialize)]
#[serde(rename_all = "camelCase", deny_unknown_fields)]
pub struct WriteRequest {
    pub uid: String,
    pub mode: String,
    pub address: u16,
    pub hex: String,
    pub expected_hex: String,
    pub key_type: Option<String>,
    pub key: Option<String>,
    pub confirmed: bool,
}

#[derive(Debug, serde::Serialize)]
#[serde(rename_all = "camelCase")]
pub struct WriteResult {
    pub card: CardInfo,
    pub mode: String,
    pub address: u16,
    pub before_hex: Option<String>,
    pub after_hex: Option<String>,
    /// True once the write command was handed to the transport, even on a timeout.
    pub write_attempted: bool,
    pub verified: bool,
    pub error: Option<String>,
}

fn data_bytes(value: &str, length: usize) -> Result<Vec<u8>, String> {
    if value.len() != length * 2 || !value.bytes().all(|byte| byte.is_ascii_hexdigit()) {
        return Err(format!(
            "数据必须是 {} 位十六进制（{length} 字节）",
            length * 2
        ));
    }
    (0..length)
        .map(|index| {
            u8::from_str_radix(&value[index * 2..index * 2 + 2], 16)
                .map_err(|_| "数据格式无效".into())
        })
        .collect()
}

fn writable_classic_address(address: u16) -> bool {
    address > 0
        && address < 256
        && if address < 128 {
            address % 4 != 3
        } else {
            (address - 128) % 16 != 15
        }
}

fn read_unit(
    target: &CardTarget,
    address: u16,
    classic: bool,
    exchange: &mut Exchange<'_>,
) -> Result<Vec<u8>, String> {
    let read_address = if classic { address } else { address.min(12) };
    let response = exchange(&[0x40, target.number, 0x30, read_address as u8], 0x41)?;
    let data = pn532::exchange_data(&response, 16)?;
    if classic {
        Ok(data.to_vec())
    } else {
        let offset = usize::from(address - read_address) * 4;
        Ok(data[offset..offset + 4].to_vec())
    }
}

/// Writes exactly one ordinary data unit; no retries, sector trailers or manufacturer areas.
pub fn write_card(
    request: &WriteRequest,
    exchange: &mut Exchange<'_>,
) -> Result<WriteResult, String> {
    if !request.confirmed {
        return Err("请先确认写入预览和覆盖风险".into());
    }
    if ![8, 14, 20].contains(&request.uid.len())
        || !request.uid.bytes().all(|byte| byte.is_ascii_hexdigit())
    {
        return Err("卡片标识无效，请重新寻卡".into());
    }
    let classic = match request.mode.as_str() {
        "classic" if writable_classic_address(request.address) => true,
        "classic" => return Err("禁止写入制造商块、扇区尾块（密钥/访问条件）或越界地址".into()),
        "type2" if (4..=15).contains(&request.address) => false,
        "type2" => return Err("Type 2 仅允许写入用户数据页 4–15，禁止 UID、锁定及配置区域".into()),
        _ => return Err("此卡片类型暂不支持写入".into()),
    };
    let data = data_bytes(&request.hex, if classic { 16 } else { 4 })?;
    let expected = data_bytes(&request.expected_hex, data.len())?;
    let mut key = if classic {
        if !matches!(request.key_type.as_deref(), Some("A" | "B")) {
            return Err("请选择 Key A 或 Key B".into());
        }
        Some(key_bytes(request.key.as_deref())?)
    } else {
        None
    };
    let detected = detect(exchange);
    let target = match detected {
        Ok(Some(target)) => target,
        result => {
            if let Some(key) = key.as_mut() {
                key.fill(0);
            }
            return match result {
                Ok(None) => Err("未发现卡片，请重新寻卡".into()),
                Err(error) => Err(error),
                _ => unreachable!(),
            };
        }
    };
    let mut result = WriteResult {
        card: target.info(),
        mode: request.mode.clone(),
        address: request.address,
        before_hex: None,
        after_hex: None,
        write_attempted: false,
        verified: false,
        error: None,
    };
    let operation = (|| {
        if !request.uid.eq_ignore_ascii_case(&hex(&target.uid)) {
            return Err("检测到卡片已更换，请重新寻卡".into());
        }
        let capacity = match result.card.family {
            "classicMini" => 20,
            "classic1k" => 64,
            "classic4k" => 256,
            "type2" if !classic => 16,
            _ => return Err("写入模式与实际卡片不匹配".into()),
        };
        if classic != result.card.family.starts_with("classic") || request.address >= capacity {
            return Err("写入地址或模式与实际卡片不匹配".into());
        }
        if let Some(key) = key.as_ref() {
            let mut auth = vec![
                0x40,
                target.number,
                if request.key_type.as_deref() == Some("B") {
                    0x61
                } else {
                    0x60
                },
                request.address as u8,
            ];
            auth.extend_from_slice(key);
            auth.extend_from_slice(&target.uid[target.uid.len() - 4..]);
            let response = exchange(&auth, 0x41);
            auth.fill(0);
            pn532::exchange_data(&response?, 0)?;
        } else {
            // Require an NFC Type 2 capability container claiming at least 48 user bytes
            // and unrestricted read/write access. SAK alone cannot establish writable memory.
            let response = exchange(&[0x40, target.number, 0x30, 0], 0x41)?;
            let bytes = pn532::exchange_data(&response, 16)?;
            let cc = &bytes[12..16];
            if cc[0] != 0xe1 || cc[1] >> 4 != 1 || cc[2] < 6 || cc[3] != 0 {
                return Err(
                    "无法确认 Type 2 用户区可写：需要有效的 NFC 容量标记和开放读写权限".into(),
                );
            }
        }
        let before = read_unit(&target, request.address, classic, exchange)?;
        result.before_hex = Some(hex(&before));
        if before != expected {
            return Err("原数据已变化，未发送写入命令；请重新读取并确认".into());
        }
        if before == data {
            result.after_hex = Some(hex(&before));
            result.verified = true;
            return Ok(());
        }
        let mut command = vec![
            0x40,
            target.number,
            if classic { 0xa0 } else { 0xa2 },
            request.address as u8,
        ];
        command.extend_from_slice(&data);
        result.write_attempted = true;
        let response = exchange(&command, 0x41);
        command.fill(0);
        pn532::exchange_data(&response?, 0)?;
        let after = read_unit(&target, request.address, classic, exchange)?;
        result.after_hex = Some(hex(&after));
        if after != data {
            return Err("写后读回与目标数据不一致；请重新读取检查，不会自动重试或回滚".into());
        }
        result.verified = true;
        Ok::<(), String>(())
    })();
    if let Some(key) = key.as_mut() {
        key.fill(0);
    }
    result.error = operation.err();
    if let Err(error) = release(exchange, target.number) {
        result.error = Some(match result.error {
            Some(previous) => format!("{previous}；释放卡片失败：{error}"),
            None => format!("释放卡片失败：{error}"),
        });
    }
    Ok(result)
}

#[cfg(test)]
mod write_tests {
    use super::*;

    fn request() -> WriteRequest {
        WriteRequest {
            uid: "12345678".into(),
            mode: "classic".into(),
            address: 4,
            hex: "AA".repeat(16),
            expected_hex: "11".repeat(16),
            key_type: Some("A".into()),
            key: Some("112233445566".into()),
            confirmed: true,
        }
    }

    #[test]
    fn protected_addresses_and_missing_confirmation_never_reach_device() {
        for address in [0, 3, 7, 127, 143, 159, 255, 256, u16::MAX] {
            let request = WriteRequest {
                address,
                ..request()
            };
            assert!(
                write_card(&request, &mut |_, _| panic!(
                    "protected address reached device"
                ))
                .is_err()
            );
        }
        let unconfirmed = WriteRequest {
            confirmed: false,
            ..request()
        };
        assert!(
            write_card(&unconfirmed, &mut |_, _| panic!(
                "unconfirmed write reached device"
            ))
            .is_err()
        );
        for address in [0, 1, 2, 3, 16, 255] {
            let request = WriteRequest {
                mode: "type2".into(),
                address,
                hex: "AA".repeat(4),
                expected_hex: "11".repeat(4),
                ..request()
            };
            assert!(
                write_card(&request, &mut |_, _| panic!(
                    "protected page reached device"
                ))
                .is_err()
            );
        }
    }

    #[test]
    fn changed_original_or_changed_uid_prevents_write_and_releases_card() {
        for changed_uid in [false, true] {
            let mut released = false;
            let result = write_card(&request(), &mut |command, _| {
                Ok(match command[0] {
                    0x32 => vec![],
                    0x4a => vec![
                        1,
                        1,
                        0,
                        4,
                        8,
                        4,
                        if changed_uid { 0x99 } else { 0x12 },
                        0x34,
                        0x56,
                        0x78,
                    ],
                    0x40 if command[2] == 0x60 => vec![0],
                    0x40 if command[2] == 0x30 => vec![0; 17],
                    0x52 => {
                        released = true;
                        vec![0]
                    }
                    _ => panic!("must not write"),
                })
            })
            .unwrap();
            assert!(!result.write_attempted);
            assert!(!result.verified);
            assert!(
                result
                    .error
                    .unwrap()
                    .contains(if changed_uid { "更换" } else { "变化" })
            );
            assert!(released);
        }
    }

    #[test]
    fn failed_authentication_never_sends_write_or_tries_another_key() {
        let mut authentications = 0;
        let result = write_card(&request(), &mut |command, _| {
            Ok(match command[0] {
                0x32 => vec![],
                0x4a => vec![1, 1, 0, 4, 8, 4, 0x12, 0x34, 0x56, 0x78],
                0x40 if command[2] == 0x60 => {
                    authentications += 1;
                    vec![0x14]
                }
                0x52 => vec![0],
                _ => panic!("must not write or read after authentication failure"),
            })
        })
        .unwrap();
        assert!(!result.write_attempted);
        assert_eq!(authentications, 1);
        assert!(result.error.unwrap().contains("认证"));
    }

    #[test]
    fn timeout_or_readback_mismatch_is_unverified_and_never_retried() {
        for timeout in [true, false] {
            let mut writes = 0;
            let result = write_card(&request(), &mut |command, _| {
                if command[0] == 0x40 && command[2] == 0xa0 {
                    writes += 1;
                    return if timeout {
                        Err("模拟写入超时".into())
                    } else {
                        Ok(vec![0])
                    };
                }
                Ok(match command[0] {
                    0x32 => vec![],
                    0x4a => vec![1, 1, 0, 4, 8, 4, 0x12, 0x34, 0x56, 0x78],
                    0x40 if command[2] == 0x60 => vec![0],
                    0x40 if command[2] == 0x30 => {
                        let mut bytes = vec![0];
                        bytes.extend([0x11; 16]);
                        bytes
                    }
                    0x52 => vec![0],
                    _ => panic!("unexpected command"),
                })
            })
            .unwrap();
            assert!(result.write_attempted);
            assert!(!result.verified);
            assert_eq!(writes, 1);
            assert!(result.error.is_some());
        }
    }

    #[test]
    fn type2_checks_capability_container_and_uses_single_page_a2_write() {
        for valid_cc in [true, false] {
            let request = WriteRequest {
                mode: "type2".into(),
                address: 15,
                hex: "AABBCCDD".into(),
                expected_hex: "11111111".into(),
                key: None,
                key_type: None,
                ..request()
            };
            let mut writes = 0;
            let result = write_card(&request, &mut |command, _| {
                Ok(match command[0] {
                    0x32 => vec![],
                    0x4a => vec![1, 1, 0, 0x44, 0, 4, 0x12, 0x34, 0x56, 0x78],
                    0x40 if command[2] == 0x30 && command[3] == 0 => {
                        let mut bytes = vec![0; 13];
                        bytes.extend(if valid_cc {
                            [0xe1, 0x10, 6, 0]
                        } else {
                            [0xe1, 0x10, 6, 0x0f]
                        });
                        bytes
                    }
                    0x40 if command[2] == 0x30 => {
                        assert_eq!(command[3], 12);
                        let mut bytes = vec![0; 13];
                        bytes.extend(if writes == 0 {
                            [0x11; 4]
                        } else {
                            [0xaa, 0xbb, 0xcc, 0xdd]
                        });
                        bytes
                    }
                    0x40 if command[2] == 0xa2 => {
                        assert_eq!(command, &[0x40, 1, 0xa2, 15, 0xaa, 0xbb, 0xcc, 0xdd]);
                        writes += 1;
                        vec![0]
                    }
                    0x52 => vec![0],
                    _ => panic!("unexpected Type 2 command"),
                })
            })
            .unwrap();
            assert_eq!(result.verified, valid_cc);
            assert_eq!(writes, usize::from(valid_cc));
        }
    }

    #[test]
    fn invalid_data_and_actual_capacity_are_rejected() {
        for request in [
            WriteRequest {
                hex: "AA".into(),
                ..request()
            },
            WriteRequest {
                expected_hex: "GG".repeat(16),
                ..request()
            },
            WriteRequest {
                key: Some("FF".into()),
                ..request()
            },
        ] {
            assert!(
                write_card(&request, &mut |_, _| panic!("invalid data reached device")).is_err()
            );
        }
        let request = WriteRequest {
            address: 20,
            ..request()
        };
        let result = write_card(&request, &mut |command, _| {
            Ok(match command[0] {
                0x32 => vec![],
                0x4a => vec![1, 1, 0, 4, 9, 4, 0x12, 0x34, 0x56, 0x78],
                0x52 => vec![0],
                _ => panic!("outside Mini capacity"),
            })
        })
        .unwrap();
        assert!(!result.write_attempted);
        assert!(result.error.unwrap().contains("不匹配"));
    }

    #[test]
    fn unchanged_data_is_verified_without_a_write_command() {
        let request = WriteRequest {
            hex: "11".repeat(16),
            ..request()
        };
        let result = write_card(&request, &mut |command, _| {
            Ok(match command[0] {
                0x32 => vec![],
                0x4a => vec![1, 1, 0, 4, 8, 4, 0x12, 0x34, 0x56, 0x78],
                0x40 if command[2] == 0x60 => vec![0],
                0x40 if command[2] == 0x30 => {
                    let mut bytes = vec![0];
                    bytes.extend([0x11; 16]);
                    bytes
                }
                0x52 => vec![0],
                _ => panic!("must not rewrite unchanged data"),
            })
        })
        .unwrap();
        assert!(result.verified);
        assert!(!result.write_attempted);
    }

    #[test]
    fn release_failure_preserves_verified_data_but_reports_session_error() {
        let mut writes = 0;
        let result = write_card(&request(), &mut |command, _| {
            Ok(match command[0] {
                0x32 => vec![],
                0x4a => vec![1, 1, 0, 4, 8, 4, 0x12, 0x34, 0x56, 0x78],
                0x40 if command[2] == 0x60 => vec![0],
                0x40 if command[2] == 0x30 => {
                    let mut bytes = vec![0];
                    bytes.extend([if writes == 0 { 0x11 } else { 0xaa }; 16]);
                    bytes
                }
                0x40 if command[2] == 0xa0 => {
                    writes += 1;
                    vec![0]
                }
                0x52 => return Err("模拟释放时连接中断".into()),
                _ => panic!("unexpected command"),
            })
        })
        .unwrap();
        assert!(result.verified);
        assert!(result.write_attempted);
        assert_eq!(writes, 1);
        assert_eq!(
            result.after_hex.as_deref(),
            Some("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA")
        );
        assert!(result.error.unwrap().contains("释放卡片失败"));
    }

    #[test]
    fn classic_write_checks_original_writes_once_and_verifies() {
        let mut writes = 0;
        let mut released = false;
        let result = write_card(&request(), &mut |command, _| {
            Ok(match command[0] {
                0x32 => vec![],
                0x4a => vec![1, 1, 0, 4, 8, 4, 0x12, 0x34, 0x56, 0x78],
                0x40 if command[2] == 0x60 => vec![0],
                0x40 if command[2] == 0x30 => {
                    let mut bytes = vec![0];
                    bytes.extend([if writes == 0 { 0x11 } else { 0xaa }; 16]);
                    bytes
                }
                0x40 if command[2] == 0xa0 => {
                    assert_eq!(&command[4..], &[0xaa; 16]);
                    writes += 1;
                    vec![0]
                }
                0x52 => {
                    released = true;
                    vec![0]
                }
                _ => panic!("unexpected card command"),
            })
        })
        .unwrap();
        assert!(result.verified);
        assert!(result.write_attempted);
        assert!(result.error.is_none());
        assert_eq!(
            result.before_hex.as_deref(),
            Some("11111111111111111111111111111111")
        );
        assert_eq!(writes, 1);
        assert!(released);
    }
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn read_requires_matching_card_and_valid_known_key_before_authentication() {
        let request = ReadRequest {
            uid: "12345678".into(),
            mode: "classic".into(),
            start: 0,
            count: 1,
            key_type: Some("A".into()),
            key: Some("112233445566".into()),
        };
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
        let invalid = ReadRequest {
            key: Some("FF".into()),
            ..request
        };
        assert!(
            read_card(&invalid, &mut |_, _| panic!(
                "invalid key must not reach device"
            ))
            .unwrap_err()
            .contains("12")
        );
    }

    #[test]
    fn known_key_reads_only_selected_range_and_releases_target() {
        let request = ReadRequest {
            uid: "04112233445566".into(),
            mode: "classic".into(),
            start: 4,
            count: 2,
            key_type: Some("B".into()),
            key: Some("112233445566".into()),
        };
        let mut commands = Vec::new();
        let dump = read_card(&request, &mut |command, _| {
            commands.push(command.to_vec());
            Ok(match command[0] {
                0x32 => vec![],
                0x4a => vec![1, 1, 0, 4, 8, 7, 4, 0x11, 0x22, 0x33, 0x44, 0x55, 0x66],
                0x40 if command[2] == 0x61 => vec![0],
                0x40 if command[2] == 0x30 => {
                    let mut bytes = vec![0];
                    bytes.extend(0..16);
                    bytes
                }
                0x52 => vec![0],
                _ => panic!("unexpected command"),
            })
        })
        .unwrap();
        assert!(dump.complete);
        assert_eq!(dump.rows.len(), 2);
        assert_eq!(dump.rows[0].address, 4);
        assert_eq!(dump.rows[0].hex, "000102030405060708090A0B0C0D0E0F");
        assert_eq!(
            commands[2],
            [
                0x40, 1, 0x61, 4, 0x11, 0x22, 0x33, 0x44, 0x55, 0x66, 0x33, 0x44, 0x55, 0x66
            ]
        );
        assert_eq!(
            commands
                .iter()
                .filter(|cmd| cmd.get(2) == Some(&0x61))
                .count(),
            1
        );
        assert_eq!(commands.last().unwrap(), &[0x52, 1]);
    }

    #[test]
    fn failed_authentication_is_not_reported_as_complete_or_retried_with_other_keys() {
        let request = ReadRequest {
            uid: "12345678".into(),
            mode: "classic".into(),
            start: 0,
            count: 4,
            key_type: Some("A".into()),
            key: Some("112233445566".into()),
        };
        let mut authentications = 0;
        let dump = read_card(&request, &mut |command, _| {
            Ok(match command[0] {
                0x32 => vec![],
                0x4a => vec![1, 1, 0, 4, 8, 4, 0x12, 0x34, 0x56, 0x78],
                0x40 => {
                    authentications += 1;
                    vec![0x14]
                }
                0x52 => vec![0],
                _ => unreachable!(),
            })
        })
        .unwrap();
        assert!(!dump.complete);
        assert!(dump.rows.is_empty());
        assert!(dump.error.unwrap().contains("认证失败"));
        assert_eq!(authentications, 1);
    }

    #[test]
    fn type2_reads_are_four_byte_pages_and_never_request_beyond_safe_window() {
        let request = ReadRequest {
            uid: "04112233445566".into(),
            mode: "type2".into(),
            start: 14,
            count: 2,
            key_type: None,
            key: None,
        };
        let dump = read_card(&request, &mut |command, _| {
            Ok(match command[0] {
                0x32 => vec![],
                0x4a => vec![1, 1, 0, 0x44, 0, 7, 4, 0x11, 0x22, 0x33, 0x44, 0x55, 0x66],
                0x40 => {
                    assert_eq!(command, &[0x40, 1, 0x30, 12]);
                    let mut bytes = vec![0];
                    bytes.extend(0..16);
                    bytes
                }
                0x52 => vec![0],
                _ => unreachable!(),
            })
        })
        .unwrap();
        assert_eq!(dump.rows[0].hex, "08090A0B");
        assert_eq!(dump.rows[1].hex, "0C0D0E0F");
        let invalid = ReadRequest {
            count: 3,
            ..request
        };
        assert!(read_card(&invalid, &mut |_, _| panic!("invalid range")).is_err());
    }

    #[test]
    fn scan_no_card_is_a_normal_result_and_unknown_card_remains_identifiable() {
        assert!(
            scan_card(&mut |command, _| Ok(if command[0] == 0x32 { vec![] } else { vec![0] }))
                .unwrap()
                .is_none()
        );
        let info = scan_card(&mut |command, _| {
            Ok(match command[0] {
                0x32 => vec![],
                0x4a => vec![1, 1, 0, 4, 0x20, 4, 1, 2, 3, 4],
                0x52 => vec![0],
                _ => unreachable!(),
            })
        })
        .unwrap()
        .unwrap();
        assert_eq!(info.family, "iso14443_4");
    }

    #[test]
    fn partial_read_retains_only_successful_rows_and_reports_failure_address() {
        let request = ReadRequest {
            count: 3,
            ..request_at(4)
        };
        let mut releases = 0;
        let dump = read_card(&request, &mut |command, _| {
            Ok(match command[0] {
                0x32 => vec![],
                0x4a => vec![1, 1, 0, 4, 8, 4, 0x12, 0x34, 0x56, 0x78],
                0x40 if command[2] == 0x60 => vec![0],
                0x40 if command[3] == 4 => {
                    let mut bytes = vec![0];
                    bytes.extend([0xaa; 16]);
                    bytes
                }
                0x40 => vec![1],
                0x52 => {
                    releases += 1;
                    vec![0]
                }
                _ => unreachable!(),
            })
        })
        .unwrap();
        assert!(!dump.complete);
        assert_eq!(dump.rows.len(), 1);
        assert_eq!(dump.rows[0].address, 4);
        assert!(dump.error.unwrap().contains("地址 5"));
        assert_eq!(releases, 1);
    }

    fn request_at(start: u16) -> ReadRequest {
        ReadRequest {
            uid: "12345678".into(),
            mode: "classic".into(),
            start,
            count: 1,
            key_type: Some("A".into()),
            key: Some("112233445566".into()),
        }
    }

    #[test]
    fn release_failure_marks_even_successful_rows_as_incomplete() {
        let dump = read_card(&request_at(4), &mut |command, _| {
            Ok(match command[0] {
                0x32 => vec![],
                0x4a => vec![1, 1, 0, 4, 8, 4, 0x12, 0x34, 0x56, 0x78],
                0x40 if command[2] == 0x60 => vec![0],
                0x40 => vec![0; 17],
                0x52 => vec![1],
                _ => unreachable!(),
            })
        })
        .unwrap();
        assert!(!dump.complete);
        assert_eq!(dump.rows.len(), 1);
        assert!(dump.error.unwrap().contains("释放卡片失败"));
    }

    #[test]
    fn classic4k_sector_boundaries_authenticate_once_per_sector() {
        for (start, count, expected) in [
            (3, 3, vec![3, 4]),
            (127, 3, vec![127, 128]),
            (142, 3, vec![142, 144]),
        ] {
            let request = ReadRequest {
                start,
                count,
                ..request_at(0)
            };
            let mut authenticated = Vec::new();
            let dump = read_card(&request, &mut |command, _| {
                Ok(match command[0] {
                    0x32 => vec![],
                    0x4a => vec![1, 1, 0, 4, 0x18, 4, 0x12, 0x34, 0x56, 0x78],
                    0x40 if command[2] == 0x60 => {
                        authenticated.push(u16::from(command[3]));
                        vec![0]
                    }
                    0x40 => vec![0; 17],
                    0x52 => vec![0],
                    _ => unreachable!(),
                })
            })
            .unwrap();
            assert!(dump.complete);
            assert_eq!(authenticated, expected);
        }
    }

    #[test]
    fn invalid_ranges_and_modes_never_reach_authentication() {
        for request in [
            ReadRequest {
                count: 0,
                ..request_at(0)
            },
            ReadRequest {
                count: 17,
                ..request_at(0)
            },
            request_at(256),
            request_at(u16::MAX),
        ] {
            assert!(
                read_card(&request, &mut |_, _| panic!("invalid range reached device")).is_err()
            );
        }
        for (sak, start) in [(0x09, 20), (0x08, 64)] {
            let mut released = false;
            let result = read_card(&request_at(start), &mut |command, _| {
                Ok(match command[0] {
                    0x32 => vec![],
                    0x4a => vec![1, 1, 0, 4, sak, 4, 0x12, 0x34, 0x56, 0x78],
                    0x52 => {
                        released = true;
                        vec![0]
                    }
                    _ => panic!("capacity mismatch must not authenticate"),
                })
            });
            assert!(result.unwrap_err().contains("不匹配"));
            assert!(released);
        }
    }

    #[test]
    fn identifies_classic_and_type2_without_claiming_exact_type2_model() {
        let classic = CardTarget {
            number: 1,
            uid: vec![0x12, 0x34, 0x56, 0x78],
            atqa: [0, 4],
            sak: 8,
        };
        let info = classic.info();
        assert_eq!(info.uid, "12345678");
        assert_eq!(info.atqa, "0004");
        assert_eq!(info.family, "classic1k");
        let type2 = CardTarget { sak: 0, ..classic };
        assert_eq!(type2.info().family, "type2");
        assert!(type2.info().type_name.contains("初步"));
    }
}
