//! Bounded MIFARE Classic dictionary checking. No Crypto1 key derivation or write commands.

use crate::cards;

const COMMON_KEYS: &[[u8; 6]] = &[
    [0xff; 6],
    [0; 6],
    [0xa0, 0xa1, 0xa2, 0xa3, 0xa4, 0xa5],
    [0xb0, 0xb1, 0xb2, 0xb3, 0xb4, 0xb5],
    [0xd3, 0xf7, 0xd3, 0xf7, 0xd3, 0xf7],
    [0x4d, 0x3a, 0x99, 0xc3, 0x51, 0xdd],
    [0x1a, 0x98, 0x2c, 0x7e, 0x45, 0x9a],
    [0xaa, 0xbb, 0xcc, 0xdd, 0xee, 0xff],
];

#[derive(serde::Deserialize)]
#[serde(rename_all = "camelCase", deny_unknown_fields)]
pub struct DictionaryRequest {
    pub run_id: String,
    pub uid: String,
    pub start_sector: u16,
    pub sector_count: u16,
    pub use_common_keys: bool,
    pub keys: Vec<String>,
    pub confirmed: bool,
}

fn validate(request: &DictionaryRequest) -> Result<(Vec<[u8; 6]>, u16), String> {
    if !request.confirmed {
        return Err("请确认仅对自有或已获授权卡片检测密钥".into());
    }
    if request.run_id.is_empty()
        || request.run_id.len() > 80
        || !request
            .run_id
            .bytes()
            .all(|b| b.is_ascii_alphanumeric() || b == b'-')
    {
        return Err("任务标识无效".into());
    }
    if ![8, 14, 20].contains(&request.uid.len())
        || !request.uid.bytes().all(|b| b.is_ascii_hexdigit())
    {
        return Err("卡片标识无效，请重新寻卡".into());
    }
    let end = request
        .start_sector
        .checked_add(request.sector_count)
        .filter(|&end| request.sector_count > 0 && end <= 40)
        .ok_or("扇区范围无效")?;
    if request.keys.len() > 64 {
        return Err("自定义字典最多 64 个密钥".into());
    }
    // Validate every string before retaining any decoded secrets.
    if request
        .keys
        .iter()
        .any(|key| key.len() != 12 || !key.bytes().all(|b| b.is_ascii_hexdigit()))
    {
        return Err("每个密钥须为 12 位十六进制".into());
    }
    let mut keys = if request.use_common_keys {
        COMMON_KEYS.to_vec()
    } else {
        vec![]
    };
    for text in &request.keys {
        let key = std::array::from_fn(|i| u8::from_str_radix(&text[i * 2..i * 2 + 2], 16).unwrap());
        if !keys.contains(&key) {
            keys.push(key);
        }
    }
    if keys.is_empty() {
        return Err("请选择常见密钥或提供自定义字典".into());
    }
    Ok((keys, end))
}

#[derive(Clone, Default, Debug, serde::Serialize)]
#[serde(rename_all = "camelCase")]
pub struct DictionaryProgress {
    pub attempts: u32,
    pub max_attempts: u32,
    pub completed_sectors: u16,
    pub total_sectors: u16,
    pub current_sector: u16,
    pub found_keys: u16,
    pub phase: &'static str,
}

#[derive(Debug, serde::Serialize)]
#[serde(rename_all = "camelCase")]
pub struct SectorKeys {
    pub sector: u16,
    pub key_a: Option<String>,
    pub key_b: Option<String>,
    pub key_a_checked: bool,
    pub key_b_checked: bool,
}

#[derive(Debug, serde::Serialize)]
#[serde(rename_all = "camelCase")]
pub struct DictionaryResult {
    pub dump: cards::CardDump,
    pub sectors: Vec<SectorKeys>,
    pub cancelled: bool,
    pub attempts: u32,
    pub error: Option<String>,
}

fn first_block(sector: u16) -> u16 {
    if sector < 32 {
        sector * 4
    } else {
        128 + (sector - 32) * 16
    }
}

// RF reset is necessary after failed Classic authentication; do not continue using
// a previous crypto/activation state. Re-identify and compare all captured identity fields.
fn activate(
    expected: &cards::CardTarget,
    exchange: &mut cards::Exchange<'_>,
) -> Result<cards::CardTarget, String> {
    for enabled in [0, 1] {
        if !exchange(&[0x32, 0x01, enabled], 0x33)?.is_empty() {
            return Err("RF 配置响应异常".into());
        }
        if enabled == 0 {
            std::thread::sleep(std::time::Duration::from_millis(5));
        }
    }
    let target = cards::detect(exchange)?.ok_or("卡片已移开，请重新识别")?;
    if &target != expected {
        return Err("检测到卡片标识或类型已变化，请重新寻卡".into());
    }
    Ok(target)
}

fn authenticate(
    target: &cards::CardTarget,
    address: u16,
    kind: u8,
    key: &[u8; 6],
    exchange: &mut cards::Exchange<'_>,
) -> Result<bool, String> {
    let mut command = vec![0x40, target.number, kind, address as u8];
    command.extend_from_slice(key);
    command.extend_from_slice(&target.uid[target.uid.len() - 4..]);
    let response = exchange(&command, 0x41);
    command.fill(0);
    let data = response?;
    if data == [0x14] {
        return Ok(false);
    }
    crate::pn532::exchange_data(&data, 0)?;
    Ok(true)
}

pub(crate) fn check(
    request: &DictionaryRequest,
    exchange: &mut cards::Exchange<'_>,
    cancelled: &dyn Fn() -> bool,
    progress: &mut dyn FnMut(DictionaryProgress),
) -> Result<DictionaryResult, String> {
    let (mut keys, end) = validate(request)?;
    let outcome = (|| {
        if cancelled() {
            return Err("用户已取消任务".into());
        }
        let initial = cards::detect(exchange)?.ok_or("未发现卡片，请重新识别")?;
        let capacity = match initial.info().family {
            "classicMini" => 5,
            "classic1k" => 16,
            "classic4k" => 40,
            _ => {
                let _ = cards::release(exchange, initial.number);
                return Err("字典检测仅支持 MIFARE Classic / Mini；其他卡型无通用解锁".into());
            }
        };
        if !request.uid.eq_ignore_ascii_case(&cards::hex(&initial.uid)) || end > capacity {
            let _ = cards::release(exchange, initial.number);
            return Err("卡片已更换或扇区范围超出实际容量，请重新识别".into());
        }
        let mut result = DictionaryResult {
            dump: cards::CardDump {
                card: initial.info(),
                mode: "classic".into(),
                rows: vec![],
                complete: false,
                error: None,
            },
            sectors: vec![],
            cancelled: false,
            attempts: 0,
            error: None,
        };
        let mut state = DictionaryProgress {
            max_attempts: u32::from(request.sector_count) * 2 * keys.len() as u32,
            total_sectors: request.sector_count,
            phase: "checking",
            ..Default::default()
        };
        let started = std::time::Instant::now();
        let mut ensure_running = || -> Result<(), String> {
            if cancelled() {
                result.cancelled = true;
                return Err("用户已取消任务，已保留部分结果".into());
            }
            if started.elapsed() > std::time::Duration::from_secs(600) {
                return Err("达到 10 分钟任务上限，已停止；可缩小扇区范围".into());
            }
            Ok(())
        };
        let operation = (|| {
            for sector in request.start_sector..end {
                state.current_sector = sector;
                state.phase = "checking";
                progress(state.clone());
                let address = first_block(sector);
                let mut found = [None, None];
                result.sectors.push(SectorKeys {
                    sector,
                    key_a: None,
                    key_b: None,
                    key_a_checked: false,
                    key_b_checked: false,
                });
                let entry = result.sectors.last_mut().unwrap();
                for (slot, kind) in [0x60, 0x61].into_iter().enumerate() {
                    for key in &keys {
                        ensure_running()?;
                        let target = activate(&initial, exchange)?;
                        ensure_running()?;
                        state.attempts += 1;
                        if authenticate(&target, address, kind, key, exchange)? {
                            found[slot] =
                                Some(keys.iter().position(|candidate| candidate == key).unwrap());
                            if slot == 0 {
                                entry.key_a = Some(cards::hex(key));
                            } else {
                                entry.key_b = Some(cards::hex(key));
                            }
                            state.found_keys += 1;
                            if slot == 0 {
                                entry.key_a_checked = true;
                            } else {
                                entry.key_b_checked = true;
                            }
                            progress(state.clone());
                            break;
                        }
                        progress(state.clone());
                    }
                    if slot == 0 {
                        entry.key_a_checked = true;
                    } else {
                        entry.key_b_checked = true;
                    }
                }
                state.phase = "reading";
                progress(state.clone());
                // Read blocks independently with either verified key. Access rules may
                // permit different blocks with A and B. Trailer key bytes are not trusted.
                for block in address..address + if sector < 32 { 4 } else { 16 } {
                    let mut row = None;
                    for (slot, kind) in [0x60, 0x61].into_iter().enumerate() {
                        let Some(key_index) = found[slot] else {
                            continue;
                        };
                        let key = &keys[key_index];
                        ensure_running()?;
                        let target = activate(&initial, exchange)?;
                        ensure_running()?;
                        if !authenticate(&target, block, kind, key, exchange)? {
                            return Err("已命中的密钥重新认证失败，已停止；请重新识别卡片".into());
                        }
                        ensure_running()?;
                        let response = exchange(&[0x40, target.number, 0x30, block as u8], 0x41)?;
                        if response.first() == Some(&0x00) {
                            row = Some(cards::DataRow {
                                address: block,
                                hex: cards::hex(crate::pn532::exchange_data(&response, 16)?),
                            });
                            break;
                        }
                        // Permission failures allow trying the other verified key;
                        // missing cards and malformed frames stop the entire task.
                        if response != [0x13] && response != [0x14] {
                            crate::pn532::exchange_data(&response, 16)?;
                        }
                    }
                    if let Some(row) = row {
                        result.dump.rows.push(row);
                    }
                }
                state.completed_sectors += 1;
                progress(state.clone());
            }
            Ok::<(), String>(())
        })();
        result.attempts = state.attempts;
        if let Err(error) = operation {
            result.error = Some(error);
        }
        // ReaderManager forbids further wire commands after any transport failure.
        if let Err(error) = cards::release(exchange, initial.number) {
            result.error = Some(match result.error {
                Some(previous) => format!("{previous}；释放失败：{error}"),
                None => error,
            });
        }
        let expected_rows: u16 = (request.start_sector..end)
            .map(|s| if s < 32 { 4 } else { 16 })
            .sum();
        result.dump.complete =
            result.error.is_none() && result.dump.rows.len() == usize::from(expected_rows);
        result.dump.error = if result.dump.complete {
            None
        } else {
            Some(result.error.clone().unwrap_or_else(|| {
                "所选范围数据不完整：部分扇区密钥未命中或访问权限不足；不代表卡片无法恢复".into()
            }))
        };
        Ok(result)
    })();
    for key in &mut keys {
        key.fill(0);
    }
    outcome
}

use std::sync::{
    Arc, Mutex,
    atomic::{AtomicBool, Ordering},
};

#[derive(Default)]
struct TaskState {
    active: Option<ActiveTask>,
}
struct ActiveTask {
    run_id: String,
    cancelled: Arc<AtomicBool>,
    progress: DictionaryProgress,
}
#[derive(Clone, Default)]
pub struct DictionaryManager(Arc<Mutex<TaskState>>);

impl DictionaryManager {
    fn begin(&self, request: &DictionaryRequest) -> Result<Arc<AtomicBool>, String> {
        // Validate before marking active. Decoded keys are cleared immediately;
        // actual work validates again while it owns the serial session.
        let (mut keys, _) = validate(request)?;
        for key in &mut keys {
            key.fill(0);
        }
        let mut state = self.0.lock().map_err(|_| "任务状态不可用")?;
        if state.active.is_some() {
            return Err("已有密钥检测任务正在运行".into());
        }
        let cancelled = Arc::new(AtomicBool::new(false));
        state.active = Some(ActiveTask {
            run_id: request.run_id.clone(),
            cancelled: cancelled.clone(),
            progress: DictionaryProgress::default(),
        });
        Ok(cancelled)
    }
    fn update(&self, run_id: &str, progress: DictionaryProgress) {
        if let Ok(mut state) = self.0.lock()
            && let Some(active) = state.active.as_mut().filter(|a| a.run_id == run_id)
        {
            active.progress = progress;
        }
    }
    fn cancel(&self, run_id: &str) -> Result<bool, String> {
        let state = self.0.lock().map_err(|_| "任务状态不可用")?;
        if let Some(active) = state.active.as_ref().filter(|a| a.run_id == run_id) {
            active.cancelled.store(true, Ordering::Relaxed);
            Ok(true)
        } else {
            Ok(false)
        }
    }
    fn finish(&self, run_id: &str) {
        if let Ok(mut state) = self.0.lock()
            && state.active.as_ref().is_some_and(|a| a.run_id == run_id)
        {
            state.active = None;
        }
    }
}

struct TaskGuard {
    manager: DictionaryManager,
    run_id: String,
}
impl Drop for TaskGuard {
    fn drop(&mut self) {
        self.manager.finish(&self.run_id);
    }
}

#[tauri::command]
pub async fn check_dictionary(
    request: DictionaryRequest,
    reader: tauri::State<'_, crate::reader::ReaderManager>,
    tasks: tauri::State<'_, DictionaryManager>,
) -> Result<DictionaryResult, String> {
    let cancelled = tasks.begin(&request)?;
    let reader = reader.inner().clone();
    let tasks = tasks.inner().clone();
    let guard = TaskGuard {
        manager: tasks.clone(),
        run_id: request.run_id.clone(),
    };
    tauri::async_runtime::spawn_blocking(move || {
        let _guard = guard;
        crate::reader::with_card_session(&reader, |exchange| {
            check(
                &request,
                exchange,
                &|| cancelled.load(Ordering::Relaxed),
                &mut |state| tasks.update(&request.run_id, state),
            )
        })
    })
    .await
    .map_err(|_| "密钥检测任务异常结束，请重新连接并识别卡片".to_string())?
}

#[tauri::command]
pub fn dictionary_progress(
    run_id: String,
    tasks: tauri::State<'_, DictionaryManager>,
) -> Result<Option<DictionaryProgress>, String> {
    let state = tasks.0.lock().map_err(|_| "任务状态不可用")?;
    Ok(state
        .active
        .as_ref()
        .filter(|a| a.run_id == run_id)
        .map(|a| a.progress.clone()))
}

#[tauri::command]
pub fn cancel_dictionary(
    run_id: String,
    tasks: tauri::State<'_, DictionaryManager>,
) -> Result<bool, String> {
    tasks.cancel(&run_id)
}

#[cfg(test)]
mod tests {
    use super::*;

    fn request() -> DictionaryRequest {
        DictionaryRequest {
            run_id: "test-run".into(),
            uid: "12345678".into(),
            start_sector: 0,
            sector_count: 1,
            use_common_keys: false,
            keys: vec!["112233445566".into()],
            confirmed: true,
        }
    }

    fn target_payload() -> Vec<u8> {
        vec![1, 1, 0, 4, 8, 4, 0x12, 0x34, 0x56, 0x78]
    }

    #[test]
    fn authenticates_both_key_types_and_reads_without_ever_sending_a_write() {
        let input = request();
        let mut calls = vec![];
        let result = check(
            &input,
            &mut |command, _| {
                calls.push(command.to_vec());
                Ok(match command[0] {
                    0x32 => vec![],
                    0x4a => target_payload(),
                    0x52 => vec![0],
                    0x40 if command[2] == 0x60 || command[2] == 0x61 => vec![0],
                    0x40 if command[2] == 0x30 => {
                        let mut data = vec![0];
                        data.extend([0x42; 16]);
                        data
                    }
                    _ => panic!("unexpected command {command:02X?}"),
                })
            },
            &|| false,
            &mut |_| {},
        )
        .unwrap();
        assert_eq!(result.sectors.len(), 1);
        assert_eq!(result.sectors[0].key_a.as_deref(), Some("112233445566"));
        assert_eq!(result.sectors[0].key_b.as_deref(), Some("112233445566"));
        assert_eq!(result.dump.rows.len(), 4);
        assert!(result.dump.complete);
        assert_eq!(
            calls
                .iter()
                .filter(|c| c[0] == 0x40 && c[2] == 0x60)
                .count(),
            5
        );
        assert_eq!(
            calls
                .iter()
                .filter(|c| c[0] == 0x40 && c[2] == 0x61)
                .count(),
            1
        );
        assert!(
            calls
                .iter()
                .all(|c| c[0] != 0x40 || [0x60, 0x61, 0x30].contains(&c[2]))
        );
    }

    #[test]
    fn misses_are_not_claimed_as_recovery_and_reactivation_precedes_each_attempt() {
        let mut input = request();
        input.keys.push("AABBCCDDEEFF".into());
        let mut calls = vec![];
        let result = check(
            &input,
            &mut |command, _| {
                calls.push(command.to_vec());
                Ok(match command[0] {
                    0x32 => vec![],
                    0x4a => target_payload(),
                    0x52 => vec![0],
                    0x40 => {
                        assert!([0x60, 0x61].contains(&command[2]));
                        vec![0x14]
                    }
                    _ => panic!("unexpected command"),
                })
            },
            &|| false,
            &mut |_| {},
        )
        .unwrap();
        assert!(!result.dump.complete);
        assert!(result.dump.rows.is_empty());
        assert!(result.sectors[0].key_a.is_none() && result.sectors[0].key_b.is_none());
        assert_eq!(result.attempts, 4);
        for (index, command) in calls.iter().enumerate().filter(|(_, c)| c[0] == 0x40) {
            assert_eq!(calls[index - 4], [0x32, 0x01, 0]);
            assert_eq!(calls[index - 3], [0x32, 0x01, 1]);
            assert_eq!(calls[index - 1], [0x4a, 1, 0]);
            assert!(matches!(command[2], 0x60 | 0x61));
        }
    }

    #[test]
    fn a_card_change_aborts_before_authentication_and_keeps_no_new_card_data() {
        let mut detections = 0;
        let result = check(
            &request(),
            &mut |command, _| {
                Ok(match command[0] {
                    0x32 => vec![],
                    0x52 => vec![0],
                    0x4a => {
                        detections += 1;
                        let mut data = target_payload();
                        if detections > 1 {
                            data[6] = 0xff;
                        }
                        data
                    }
                    _ => panic!("must not authenticate a changed card"),
                })
            },
            &|| false,
            &mut |_| {},
        )
        .unwrap();
        assert!(result.error.unwrap().contains("变化"));
        assert_eq!(result.attempts, 0);
        assert!(result.dump.rows.is_empty());
    }

    #[test]
    fn cancellation_keeps_verified_keys_but_sends_no_further_auth_or_read() {
        let stop = std::cell::Cell::new(false);
        let mut auth_count = 0;
        let result = check(
            &request(),
            &mut |command, _| {
                Ok(match command[0] {
                    0x32 => vec![],
                    0x4a => target_payload(),
                    0x52 => vec![0],
                    0x40 => {
                        auth_count += 1;
                        assert_eq!(command[2], 0x60);
                        vec![0]
                    }
                    _ => panic!("unexpected command"),
                })
            },
            &|| stop.get(),
            &mut |state| {
                if state.found_keys == 1 {
                    stop.set(true);
                }
            },
        )
        .unwrap();
        assert!(result.cancelled);
        assert!(!result.sectors[0].key_b_checked);
        assert_eq!(auth_count, 1);
        assert_eq!(result.sectors[0].key_a.as_deref(), Some("112233445566"));
        assert!(!result.dump.complete);
    }

    #[test]
    fn malformed_auth_response_is_fatal_and_b_key_can_read_a_permission_denied_block() {
        for malformed in [true, false] {
            let mut reads = 0;
            let result = check(
                &request(),
                &mut |command, _| {
                    Ok(match command[0] {
                        0x32 => vec![],
                        0x4a => target_payload(),
                        0x52 => vec![0],
                        0x40 if [0x60, 0x61].contains(&command[2]) => {
                            if malformed {
                                vec![0, 0]
                            } else {
                                vec![0]
                            }
                        }
                        0x40 if command[2] == 0x30 => {
                            reads += 1;
                            if reads % 2 == 1 {
                                vec![0x14]
                            } else {
                                let mut data = vec![0];
                                data.extend([0x42; 16]);
                                data
                            }
                        }
                        _ => panic!("unexpected command"),
                    })
                },
                &|| false,
                &mut |_| {},
            )
            .unwrap();
            if malformed {
                assert!(result.error.unwrap().contains("长度"));
                assert!(result.sectors[0].key_a.is_none());
                assert_eq!(reads, 0);
            } else {
                assert!(result.dump.complete);
                assert_eq!(result.dump.rows.len(), 4);
                assert_eq!(reads, 8);
            }
        }
    }

    #[test]
    fn unsupported_cards_and_capacity_mismatches_never_authenticate() {
        for (sak, start, count) in [(0, 0, 1), (8, 15, 2), (9, 4, 2)] {
            let mut input = request();
            input.start_sector = start;
            input.sector_count = count;
            let error = check(
                &input,
                &mut |command, _| {
                    Ok(match command[0] {
                        0x32 => vec![],
                        0x52 => vec![0],
                        0x4a => {
                            let mut data = target_payload();
                            data[4] = sak;
                            data
                        }
                        _ => panic!("must reject before authentication"),
                    })
                },
                &|| false,
                &mut |_| {},
            )
            .unwrap_err();
            assert!(!error.is_empty());
        }
        assert_eq!(first_block(31), 124);
        assert_eq!(first_block(32), 128);
        assert_eq!(first_block(39), 240);
    }

    #[test]
    fn job_ownership_is_exclusive_and_cancel_is_run_specific() {
        let tasks = DictionaryManager::default();
        let cancelled = tasks.begin(&request()).unwrap();
        assert!(tasks.begin(&request()).is_err());
        tasks.finish("different-run");
        assert!(tasks.begin(&request()).is_err());
        assert!(!cancelled.load(Ordering::Relaxed));
        assert!(!tasks.cancel("other-run").unwrap());
        assert!(!cancelled.load(Ordering::Relaxed));
        assert!(tasks.cancel("test-run").unwrap());
        assert!(cancelled.load(Ordering::Relaxed));
        tasks.finish("test-run");
        assert!(tasks.begin(&request()).is_ok());
    }

    #[test]
    fn validates_authorization_bounds_and_keys_before_touching_the_reader() {
        let mut input = request();
        input.confirmed = false;
        assert!(validate(&input).unwrap_err().contains("授权"));
        input.confirmed = true;
        input.keys = vec!["not a key".into()];
        assert!(validate(&input).is_err());
        input.keys = vec!["112233445566".into(); 65];
        assert!(validate(&input).is_err());
        input.keys = vec!["112233445566".into(), "112233445566".into()];
        assert_eq!(validate(&input).unwrap().0.len(), 1);
        input.start_sector = 39;
        input.sector_count = 2;
        assert!(validate(&input).is_err());
    }
}
