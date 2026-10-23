//! PN532 UART framing for initialization, identification and read-only card operations.

use crate::cards::CardTarget;

/// Encode a normal host frame; extended frames are intentionally unsupported.
pub fn command(payload: &[u8]) -> Result<Vec<u8>, String> {
    if payload.is_empty() || payload.len() > 253 {
        return Err("PN532 命令长度无效".into());
    }
    let len = (payload.len() + 1) as u8;
    let mut bytes = vec![0, 0, 255, len, len.wrapping_neg(), 0xd4];
    bytes.extend_from_slice(payload);
    bytes.push(payload.iter().fold(0xd4_u8, |sum, byte| sum.wrapping_add(*byte)).wrapping_neg());
    bytes.push(0);
    Ok(bytes)
}

/// Outer None means incomplete UART frame; inner None is a confirmed no-card response.
pub fn parse_target(bytes: &[u8]) -> Result<Option<Option<CardTarget>>, String> {
    let Some(data) = parse_response(bytes, 0x4b)? else { return Ok(None); };
    parse_target_payload(&data).map(Some)
}

pub fn parse_target_payload(data: &[u8]) -> Result<Option<CardTarget>, String> {
    if data == [0] { return Ok(None); }
    if data.len() < 6 || data[0] != 1 || data[1] != 1 {
        return Err("寻卡响应无效：仅支持一个 ISO 14443A 目标".into());
    }
    let length = usize::from(data[5]);
    if ![4, 7, 10].contains(&length) || data.len() < 6 + length {
        return Err("卡片 UID 长度无效或响应不完整".into());
    }
    Ok(Some(CardTarget {
        number: data[1], atqa: [data[2], data[3]], sak: data[4], uid: data[6..6 + length].to_vec(),
    }))
}

pub fn exchange_data(data: &[u8], expected_length: usize) -> Result<&[u8], String> {
    let Some((&status, payload)) = data.split_first() else { return Err("卡片响应缺少状态码".into()); };
    if status != 0 {
        return Err(match status & 0x3f {
            0x01 => "卡片未应答，可能已移开".into(),
            0x14 => "卡片认证失败，请检查提供的密钥和访问权限".into(),
            0x27 | 0x29 => "卡片已移开或目标已释放，请重新寻卡".into(),
            _ => format!("PN532 卡片操作失败（状态 {status:02X}），请检查卡片类型和权限"),
        });
    }
    if payload.len() != expected_length {
        return Err(format!("卡片响应长度不符：期望 {expected_length} 字节，收到 {} 字节", payload.len()));
    }
    Ok(payload)
}

// Normal SAM mode is needed when the PN532 starts in LowVbat mode.
pub const SAM_NORMAL: [u8; 10] = [0, 0, 255, 3, 253, 212, 20, 1, 23, 0];
pub const GET_FIRMWARE_VERSION: [u8; 9] = [0, 0, 255, 2, 254, 212, 2, 42, 0];
pub const ACK: [u8; 6] = [0, 0, 255, 0, 255, 0];
pub const WAKEUP: [u8; 16] = [0x55, 0x55, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];

#[derive(Debug, PartialEq, Eq)]
pub struct Firmware {
    pub version: String,
    pub support: u8,
}

/// UART reads may contain noise, ACK, and only part of the response frame.
/// An ACK alone is not proof of a reader; require a checksummed command response.
pub fn parse_response(bytes: &[u8], response_code: u8) -> Result<Option<Vec<u8>>, String> {
    let mut cursor = 0;
    while cursor + 3 <= bytes.len() {
        if bytes[cursor..cursor + 3] != [0, 0, 255] {
            cursor += 1;
            continue;
        }
        if bytes.len() < cursor + 6 {
            return Ok(None);
        }
        let len = bytes[cursor + 3];
        let lcs = bytes[cursor + 4];
        if len == 0 && lcs == 255 && bytes[cursor + 5] == 0 {
            cursor += 6;
            continue;
        }
        if len == 255 && lcs == 0 {
            return Err("读卡器拒绝了命令（NACK）".into());
        }
        if len == 255 || len == 0 || len.wrapping_add(lcs) != 0 {
            return Err("设备响应的帧长度校验失败，请检查波特率".into());
        }
        let end = cursor + 7 + usize::from(len);
        if bytes.len() < end {
            return Ok(None);
        }
        let payload_end = cursor + 5 + usize::from(len);
        let sum = bytes[cursor + 5..=payload_end]
            .iter()
            .fold(0_u8, |sum, byte| sum.wrapping_add(*byte));
        if sum != 0 || bytes[end - 1] != 0 {
            return Err("设备响应的校验和或结束字节错误，请检查波特率".into());
        }
        let payload = &bytes[cursor + 5..payload_end];
        if payload.len() < 2 || payload[..2] != [0xd5, response_code] {
            return Err("设备返回了非预期的 PN532 响应".into());
        }
        return Ok(Some(payload[2..].to_vec()));
    }
    Ok(None)
}

pub fn parse_firmware(bytes: &[u8]) -> Result<Option<Firmware>, String> {
    let Some(payload) = parse_response(bytes, 0x03)? else {
        return Ok(None);
    };
    if payload.len() != 4 {
        return Err("设备返回的不是完整 PN532 固件信息".into());
    }
    if payload[0] != 0x32 {
        return Err(format!("设备芯片编号为 {:02X}，不是 PN532", payload[0]));
    }
    Ok(Some(Firmware {
        version: format!("{}.{}", payload[1], payload[2]),
        support: payload[3],
    }))
}

#[cfg(test)]
mod tests {
    use super::*;

    fn frame(payload: &[u8]) -> Vec<u8> {
        let len = payload.len() as u8;
        let mut result = vec![0x00, 0x00, 0xff, len, len.wrapping_neg()];
        result.extend_from_slice(payload);
        result.push(
            payload
                .iter()
                .fold(0_u8, |sum, byte| sum.wrapping_add(*byte))
                .wrapping_neg(),
        );
        result.push(0x00);
        result
    }

    #[test]
    fn parses_no_card_and_fragmented_checked_target_frames() {
        let no_card = frame(&[0xd5, 0x4b, 0]);
        assert_eq!(parse_target(&no_card).unwrap(), Some(None));
        let mut response = ACK.to_vec();
        response.extend(frame(&[0xd5, 0x4b, 1, 1, 0, 4, 8, 4, 0x12, 0x34, 0x56, 0x78]));
        for end in 0..response.len() {
            assert_eq!(parse_target(&response[..end]).unwrap(), None);
        }
        let target = parse_target(&response).unwrap().unwrap().unwrap();
        assert_eq!(target.uid, [0x12, 0x34, 0x56, 0x78]);
        assert_eq!(target.sak, 8);
        assert!(parse_target(&frame(&[0xd5, 0x4b, 1, 1, 0, 4, 8, 7, 1, 2])).is_err());
        assert!(parse_target(&frame(&[0xd5, 0x4b, 2])).is_err());
    }

    #[test]
    fn encodes_known_target_command_and_validates_exchange_status_and_lengths() {
        assert_eq!(command(&[0x4a, 1, 0]).unwrap(), [0, 0, 255, 4, 252, 212, 74, 1, 0, 225, 0]);
        assert!(command(&[]).is_err());
        assert!(command(&[0; 254]).is_err());
        assert_eq!(exchange_data(&[0, 1, 2], 2).unwrap(), [1, 2]);
        assert!(exchange_data(&[0x14], 0).unwrap_err().contains("认证"));
        assert!(exchange_data(&[0x40, 1, 2], 2).is_err());
        assert!(exchange_data(&[0, 1], 16).is_err());
    }

    #[test]
    fn normal_mode_initialization_requires_its_own_response() {
        assert_eq!(SAM_NORMAL, frame(&[0xd4, 0x14, 0x01]).as_slice());
        assert_eq!(parse_response(&ACK, 0x15).unwrap(), None);
        let response = frame(&[0xd5, 0x15]);
        for end in 0..response.len() {
            assert_eq!(parse_response(&response[..end], 0x15).unwrap(), None);
        }
        assert_eq!(parse_response(&response, 0x15).unwrap(), Some(vec![]));
        assert!(parse_firmware(&response).is_err());
    }

    #[test]
    fn firmware_command_has_correct_checksum() {
        assert_eq!(GET_FIRMWARE_VERSION, [0, 0, 255, 2, 254, 212, 2, 42, 0]);
    }

    #[test]
    fn accepts_ack_and_firmware_response() {
        let mut bytes = vec![0, 0, 255, 0, 255, 0];
        bytes.extend(frame(&[0xd5, 0x03, 0x32, 0x01, 0x06, 0x07]));
        let firmware = parse_firmware(&bytes).unwrap().unwrap();
        assert_eq!(firmware.version, "1.6");
        assert_eq!(firmware.support, 7);
    }

    #[test]
    fn waits_for_every_fragment_including_ack_only() {
        let mut bytes = vec![0, 0, 255, 0, 255, 0];
        bytes.extend(frame(&[0xd5, 0x03, 0x32, 0x01, 0x06, 0x07]));
        for end in 0..bytes.len() {
            assert_eq!(
                parse_firmware(&bytes[..end]).unwrap(),
                None,
                "prefix: {end}"
            );
        }
    }

    #[test]
    fn accepts_leading_wakeup_noise_but_not_noise_as_firmware() {
        let mut bytes = vec![0x55, 0x55, 0, 0, 0];
        assert_eq!(parse_firmware(&bytes).unwrap(), None);
        bytes.extend(frame(&[0xd5, 0x03, 0x32, 0x01, 0x06, 0x07]));
        assert!(parse_firmware(&bytes).unwrap().is_some());
    }

    #[test]
    fn rejects_bad_length_and_data_checksums() {
        let mut bytes = frame(&[0xd5, 0x03, 0x32, 0x01, 0x06, 0x07]);
        bytes[4] ^= 1;
        assert!(parse_firmware(&bytes).is_err());
        bytes[4] ^= 1;
        bytes[11] ^= 1;
        assert!(parse_firmware(&bytes).is_err());
    }

    #[test]
    fn rejects_wrong_response_chip_and_postamble() {
        assert!(parse_firmware(&frame(&[0xd5, 0x15])).is_err());
        assert!(parse_firmware(&frame(&[0xd5, 0x03, 0x33, 1, 6, 7])).is_err());
        let mut bytes = frame(&[0xd5, 0x03, 0x32, 1, 6, 7]);
        *bytes.last_mut().unwrap() = 1;
        assert!(parse_firmware(&bytes).is_err());
    }

    #[test]
    fn rejects_nack_and_device_error() {
        assert!(parse_firmware(&[0, 0, 255, 255, 0, 0]).is_err());
        assert!(parse_firmware(&frame(&[0x7f])).is_err());
    }
}
