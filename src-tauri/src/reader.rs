use std::io;
use std::sync::{Arc, Mutex};
use std::time::{Duration, Instant};

use serialport::{SerialPort, SerialPortInfo, SerialPortType};

use crate::cards::{self, CardDump, CardInfo, ReadRequest, WriteRequest, WriteResult};
use crate::pn532::{self, Firmware};

const BAUD_RATES: &[u32] = &[
    9_600, 19_200, 38_400, 57_600, 115_200, 230_400, 460_800, 921_600,
];

#[derive(Clone, Debug, serde::Serialize)]
#[serde(rename_all = "camelCase")]
pub struct SerialDevice {
    pub port_name: String,
    pub label: String,
    pub transport: &'static str,
    pub vid: Option<String>,
    pub pid: Option<String>,
    pub manufacturer: Option<String>,
    pub serial_number: Option<String>,
    /// USB-to-UART adapters are candidates, never confirmed readers.
    pub is_candidate: bool,
}

#[derive(Clone, Debug, serde::Serialize)]
#[serde(rename_all = "camelCase")]
pub struct ReaderConnection {
    pub port_name: String,
    pub baud_rate: u32,
    pub chip: &'static str,
    pub firmware_version: String,
    pub support: u8,
}

#[derive(Debug, serde::Serialize)]
#[serde(rename_all = "camelCase")]
pub struct DeviceSnapshot {
    pub ports: Vec<SerialDevice>,
    pub connection: Option<ReaderConnection>,
    pub connection_error: Option<String>,
}

struct Session {
    port: Box<dyn SerialPort>,
    info: ReaderConnection,
}

#[derive(Default)]
struct ReaderState {
    session: Option<Session>,
    connection_error: Option<String>,
}

/// All commands and firmware heartbeats share one lock and one serial handle.
#[derive(Clone, Default)]
pub struct ReaderManager(Arc<Mutex<ReaderState>>);

fn describe_port(info: SerialPortInfo) -> SerialDevice {
    let mut device = SerialDevice {
        label: info.port_name.clone(),
        port_name: info.port_name,
        transport: "unknown",
        vid: None,
        pid: None,
        manufacturer: None,
        serial_number: None,
        is_candidate: false,
    };
    match info.port_type {
        SerialPortType::UsbPort(usb) => {
            device.transport = "usb";
            device.vid = Some(format!("{:04X}", usb.vid));
            device.pid = Some(format!("{:04X}", usb.pid));
            device.manufacturer = usb.manufacturer;
            device.serial_number = usb.serial_number;
            let product = usb.product.unwrap_or_else(|| "USB 串口".into());
            let name = product.to_ascii_lowercase();
            device.is_candidate = name.contains("pn532")
                || name.contains("pcr532")
                || matches!(
                    (usb.vid, usb.pid),
                    (0x1a86, 0x7523 | 0x5523 | 0x55d4)
                        | (0x10c4, 0xea60)
                        | (0x0403, 0x6001 | 0x6015)
                );
            device.label = if product.contains(&format!("({})", device.port_name)) {
                product
            } else {
                format!("{product} ({})", device.port_name)
            };
        }
        SerialPortType::PciPort => device.transport = "pci",
        SerialPortType::BluetoothPort => device.transport = "bluetooth",
        SerialPortType::Unknown => {}
    }
    device
}

fn list_ports() -> Result<Vec<SerialDevice>, String> {
    let mut devices: Vec<_> = serialport::available_ports()
        .map_err(|error| format!("读取系统串口列表失败：{error}"))?
        .into_iter()
        .map(describe_port)
        .collect();
    devices.sort_by(|a, b| {
        b.is_candidate.cmp(&a.is_candidate).then_with(|| {
            let number = |name: &str| name.strip_prefix("COM").and_then(|n| n.parse::<u32>().ok());
            match (number(&a.port_name), number(&b.port_name)) {
                (Some(a), Some(b)) => a.cmp(&b),
                _ => a.port_name.cmp(&b.port_name),
            }
        })
    });
    devices.dedup_by(|a, b| a.port_name == b.port_name);
    Ok(devices)
}

/// Deadline and input bound prevent a silent or unrelated device from blocking indefinitely.
fn exchange<T>(
    port: &mut dyn SerialPort,
    command: &[u8],
    parse: impl Fn(&[u8]) -> Result<Option<T>, String>,
) -> Result<T, String> {
    port.write_all(command)
        .map_err(|error| format!("发送读卡器命令失败，设备可能已拔出：{error}"))?;
    let deadline = Instant::now() + Duration::from_millis(1_200);
    let mut bytes = Vec::new();
    let mut buffer = [0_u8; 64];
    while Instant::now() < deadline {
        match port.read(&mut buffer) {
            Ok(0) => std::thread::sleep(Duration::from_millis(5)),
            Ok(count) => {
                bytes.extend_from_slice(&buffer[..count]);
                if let Some(response) = parse(&bytes)? {
                    return Ok(response);
                }
                if bytes.len() > 1_024 {
                    return Err("串口返回过多非 PN532 数据，请确认设备和波特率".into());
                }
            }
            Err(error)
                if matches!(
                    error.kind(),
                    io::ErrorKind::TimedOut
                        | io::ErrorKind::WouldBlock
                        | io::ErrorKind::Interrupted
                ) => {}
            Err(error) => return Err(format!("读取读卡器响应失败，设备可能已拔出：{error}")),
        }
    }
    Err("PN532 应答超时：串口存在，但读卡器未应答。请检查波特率、设备 UART 模式及接线".into())
}

fn initialize(port: &mut dyn SerialPort) -> Result<(), String> {
    port.clear(serialport::ClearBuffer::Input)
        .map_err(|error| format!("清理串口接收缓冲区失败：{error}"))?;
    port.write_all(&pn532::WAKEUP)
        .map_err(|error| format!("发送读卡器唤醒序列失败：{error}"))?;
    std::thread::sleep(Duration::from_millis(5));
    // Cancel any unfinished exchange left by a previous application.
    port.write_all(&pn532::ACK)
        .map_err(|error| format!("清理读卡器未完成命令失败：{error}"))?;
    std::thread::sleep(Duration::from_millis(5));
    exchange(port, &pn532::SAM_NORMAL, |bytes| {
        pn532::parse_response(bytes, 0x15)
    })?;
    Ok(())
}

fn read_firmware(port: &mut dyn SerialPort) -> Result<Firmware, String> {
    exchange(port, &pn532::GET_FIRMWARE_VERSION, pn532::parse_firmware)
}

fn snapshot(manager: &ReaderManager) -> Result<DeviceSnapshot, String> {
    let ports = list_ports()?;
    let mut state = manager
        .0
        .lock()
        .map_err(|_| "设备状态锁不可用，请重启应用".to_string())?;
    if let Some(session) = state.session.as_mut() {
        let failure = if ports
            .iter()
            .any(|port| port.port_name == session.info.port_name)
        {
            match read_firmware(session.port.as_mut()) {
                Ok(firmware) => {
                    session.info.firmware_version = firmware.version;
                    session.info.support = firmware.support;
                    None
                }
                Err(error) => Some(format!("{} 连接已中断：{error}", session.info.port_name)),
            }
        } else {
            Some(format!(
                "{} 已从系统移除，读卡器可能已拔出",
                session.info.port_name
            ))
        };
        if let Some(error) = failure {
            state.session = None; // Drop the handle before allowing another connection.
            state.connection_error = Some(error);
        }
    }
    Ok(DeviceSnapshot {
        ports,
        connection: state.session.as_ref().map(|session| session.info.clone()),
        connection_error: state.connection_error.clone(),
    })
}

fn connect(
    manager: &ReaderManager,
    port_name: &str,
    baud_rate: u32,
) -> Result<ReaderConnection, String> {
    if !BAUD_RATES.contains(&baud_rate) {
        return Err("不支持的波特率，请从列表中选择".into());
    }
    if !list_ports()?.iter().any(|port| port.port_name == port_name) {
        return Err(format!(
            "系统未发现串口 {port_name}，请刷新列表并确认 USB 连接"
        ));
    }
    let mut state = manager
        .0
        .lock()
        .map_err(|_| "设备状态锁不可用，请重启应用".to_string())?;
    if let Some(session) = &state.session {
        return Err(format!(
            "{} 已连接，请先断开后再连接",
            session.info.port_name
        ));
    }
    state.connection_error = None;
    let mut port = serialport::new(port_name, baud_rate)
        .data_bits(serialport::DataBits::Eight)
        .parity(serialport::Parity::None)
        .stop_bits(serialport::StopBits::One)
        .flow_control(serialport::FlowControl::None)
        .timeout(Duration::from_millis(100))
        .open()
        .map_err(|error| format!("无法打开 {port_name}：串口可能被其他软件占用、权限不足或设备已拔出。请关闭原读卡软件后重试。详情：{error}"))?;
    initialize(port.as_mut())?;
    let firmware = read_firmware(port.as_mut())?;
    let info = ReaderConnection {
        port_name: port_name.into(),
        baud_rate,
        chip: "PN532",
        firmware_version: firmware.version,
        support: firmware.support,
    };
    state.session = Some(Session {
        port,
        info: info.clone(),
    });
    Ok(info)
}

#[tauri::command]
pub async fn get_device_snapshot(
    manager: tauri::State<'_, ReaderManager>,
) -> Result<DeviceSnapshot, String> {
    let manager = manager.inner().clone();
    tauri::async_runtime::spawn_blocking(move || snapshot(&manager))
        .await
        .map_err(|error| format!("设备检测任务失败：{error}"))?
}

#[tauri::command]
pub async fn connect_reader(
    port_name: String,
    baud_rate: u32,
    manager: tauri::State<'_, ReaderManager>,
) -> Result<ReaderConnection, String> {
    let manager = manager.inner().clone();
    tauri::async_runtime::spawn_blocking(move || connect(&manager, &port_name, baud_rate))
        .await
        .map_err(|error| format!("读卡器连接任务失败：{error}"))?
}

pub(crate) fn with_card_session<T>(
    manager: &ReaderManager,
    operation: impl FnOnce(&mut cards::Exchange<'_>) -> Result<T, String>,
) -> Result<T, String> {
    let mut state = manager
        .0
        .lock()
        .map_err(|_| "设备状态锁不可用，请重启应用".to_string())?;
    let session = state
        .session
        .as_mut()
        .ok_or("读卡器未连接，请先连接并验证设备")?;
    let mut transport_error = None;
    let result = operation(&mut |payload, response_code| {
        // A timeout leaves the response boundary unknown. Do not send cleanup or more
        // commands into that stream; reconnect will cancel the unfinished exchange.
        if transport_error.is_some() {
            return Err("串口通信已失效，请重新连接读卡器".into());
        }
        let mut frame = pn532::command(payload)?;
        let response = exchange(session.port.as_mut(), &frame, |bytes| {
            pn532::parse_response(bytes, response_code)
        });
        frame.fill(0); // Includes the wire copy of a supplied authentication key.
        if let Err(error) = &response {
            transport_error = Some(format!(
                "{} 连接已中断：{error}；请重新连接读卡器",
                session.info.port_name
            ));
        }
        response
    });
    if let Some(error) = transport_error {
        state.session = None;
        state.connection_error = Some(error);
    }
    result
}

fn scan_connected_card(manager: &ReaderManager) -> Result<Option<CardInfo>, String> {
    with_card_session(manager, |exchange| cards::scan_card(exchange))
}

fn read_connected_card(manager: &ReaderManager, request: &ReadRequest) -> Result<CardDump, String> {
    with_card_session(manager, |exchange| cards::read_card(request, exchange))
}

#[tauri::command]
pub async fn scan_card(
    manager: tauri::State<'_, ReaderManager>,
) -> Result<Option<CardInfo>, String> {
    let manager = manager.inner().clone();
    tauri::async_runtime::spawn_blocking(move || scan_connected_card(&manager))
        .await
        .map_err(|error| format!("寻卡任务失败：{error}"))?
}

#[tauri::command]
pub async fn read_card(
    request: ReadRequest,
    manager: tauri::State<'_, ReaderManager>,
) -> Result<CardDump, String> {
    let manager = manager.inner().clone();
    tauri::async_runtime::spawn_blocking(move || read_connected_card(&manager, &request))
        .await
        .map_err(|error| format!("读取卡片任务失败：{error}"))?
}

fn write_connected_card(
    manager: &ReaderManager,
    request: &WriteRequest,
) -> Result<WriteResult, String> {
    with_card_session(manager, |exchange| cards::write_card(request, exchange))
}

#[tauri::command]
pub async fn write_card(
    request: WriteRequest,
    manager: tauri::State<'_, ReaderManager>,
) -> Result<WriteResult, String> {
    let manager = manager.inner().clone();
    tauri::async_runtime::spawn_blocking(move || write_connected_card(&manager, &request))
        .await
        .map_err(|_| {
            "写卡任务异常结束：写入结果未知，请重新连接并读取检查，勿直接重试".to_string()
        })?
}

fn disconnect(manager: &ReaderManager) -> Result<(), String> {
    let mut state = manager
        .0
        .lock()
        .map_err(|_| "设备状态锁不可用，请重启应用".to_string())?;
    state.session = None;
    state.connection_error = None;
    Ok(())
}

#[tauri::command]
pub async fn disconnect_reader(manager: tauri::State<'_, ReaderManager>) -> Result<(), String> {
    let manager = manager.inner().clone();
    tauri::async_runtime::spawn_blocking(move || disconnect(&manager))
        .await
        .map_err(|error| format!("断开读卡器任务失败：{error}"))?
}

#[cfg(test)]
mod tests {
    use super::*;

    struct ScriptedPort {
        responses: std::collections::VecDeque<Vec<u8>>,
        incoming: std::collections::VecDeque<u8>,
        idle_error: io::ErrorKind,
        writes: Arc<Mutex<Vec<Vec<u8>>>>,
    }

    impl io::Read for ScriptedPort {
        fn read(&mut self, buffer: &mut [u8]) -> io::Result<usize> {
            if self.incoming.is_empty() {
                return Err(io::Error::new(self.idle_error, "scripted serial error"));
            }
            // Deliberate fragmentation exercises the real UART frame parser.
            let count = buffer.len().min(self.incoming.len()).min(3);
            for byte in &mut buffer[..count] {
                *byte = self.incoming.pop_front().unwrap();
            }
            Ok(count)
        }
    }

    impl io::Write for ScriptedPort {
        fn write(&mut self, bytes: &[u8]) -> io::Result<usize> {
            self.writes.lock().unwrap().push(bytes.to_vec());
            if let Some(response) = self.responses.pop_front() {
                self.incoming.extend(response);
            }
            Ok(bytes.len())
        }
        fn flush(&mut self) -> io::Result<()> {
            Ok(())
        }
    }

    // Device-setting methods are unused by these already-connected session tests.
    macro_rules! unused_port_method {
        ($name:ident $(, $arg:ident: $kind:ty)* => $result:ty) => {
            fn $name(&mut self $(, $arg: $kind)*) -> serialport::Result<$result> {
                $(let _ = $arg;)*
                unreachable!("unexpected port setting in card operation")
            }
        };
    }

    impl SerialPort for ScriptedPort {
        fn name(&self) -> Option<String> {
            Some("MOCK".into())
        }
        fn baud_rate(&self) -> serialport::Result<u32> {
            Ok(115_200)
        }
        fn data_bits(&self) -> serialport::Result<serialport::DataBits> {
            Ok(serialport::DataBits::Eight)
        }
        fn flow_control(&self) -> serialport::Result<serialport::FlowControl> {
            Ok(serialport::FlowControl::None)
        }
        fn parity(&self) -> serialport::Result<serialport::Parity> {
            Ok(serialport::Parity::None)
        }
        fn stop_bits(&self) -> serialport::Result<serialport::StopBits> {
            Ok(serialport::StopBits::One)
        }
        fn timeout(&self) -> Duration {
            Duration::from_millis(100)
        }
        unused_port_method!(set_baud_rate, value: u32 => ());
        unused_port_method!(set_data_bits, value: serialport::DataBits => ());
        unused_port_method!(set_flow_control, value: serialport::FlowControl => ());
        unused_port_method!(set_parity, value: serialport::Parity => ());
        unused_port_method!(set_stop_bits, value: serialport::StopBits => ());
        unused_port_method!(set_timeout, value: Duration => ());
        unused_port_method!(write_request_to_send, value: bool => ());
        unused_port_method!(write_data_terminal_ready, value: bool => ());
        unused_port_method!(read_clear_to_send => bool);
        unused_port_method!(read_data_set_ready => bool);
        unused_port_method!(read_ring_indicator => bool);
        unused_port_method!(read_carrier_detect => bool);
        fn bytes_to_read(&self) -> serialport::Result<u32> {
            Ok(self.incoming.len() as u32)
        }
        fn bytes_to_write(&self) -> serialport::Result<u32> {
            Ok(0)
        }
        fn clear(&self, _: serialport::ClearBuffer) -> serialport::Result<()> {
            unreachable!()
        }
        fn try_clone(&self) -> serialport::Result<Box<dyn SerialPort>> {
            unreachable!()
        }
        fn set_break(&self) -> serialport::Result<()> {
            unreachable!()
        }
        fn clear_break(&self) -> serialport::Result<()> {
            unreachable!()
        }
    }

    fn response(code: u8, data: &[u8]) -> Vec<u8> {
        let mut bytes = vec![0xd5, code];
        bytes.extend_from_slice(data);
        let length = bytes.len() as u8;
        let mut frame = pn532::ACK.to_vec();
        frame.extend_from_slice(&[0, 0, 255, length, length.wrapping_neg()]);
        frame.extend_from_slice(&bytes);
        frame.push(
            bytes
                .iter()
                .fold(0_u8, |sum, byte| sum.wrapping_add(*byte))
                .wrapping_neg(),
        );
        frame.push(0);
        frame
    }

    fn scripted_manager(responses: Vec<Vec<u8>>) -> (ReaderManager, Arc<Mutex<Vec<Vec<u8>>>>) {
        scripted_manager_with_error(responses, io::ErrorKind::BrokenPipe)
    }

    fn scripted_manager_with_error(
        responses: Vec<Vec<u8>>,
        idle_error: io::ErrorKind,
    ) -> (ReaderManager, Arc<Mutex<Vec<Vec<u8>>>>) {
        let writes = Arc::new(Mutex::new(Vec::new()));
        let manager = ReaderManager::default();
        manager.0.lock().unwrap().session = Some(Session {
            port: Box::new(ScriptedPort {
                responses: responses.into(),
                incoming: Default::default(),
                idle_error,
                writes: writes.clone(),
            }),
            info: ReaderConnection {
                port_name: "MOCK".into(),
                baud_rate: 115_200,
                chip: "PN532",
                firmware_version: "1.6".into(),
                support: 7,
            },
        });
        (manager, writes)
    }

    fn known_key_request() -> ReadRequest {
        ReadRequest {
            uid: "12345678".into(),
            mode: "classic".into(),
            start: 4,
            count: 1,
            key_type: Some("A".into()),
            key: Some("112233445566".into()),
        }
    }

    #[test]
    fn write_transport_timeout_preserves_uncertainty_and_closes_the_session() {
        let original = {
            let mut bytes = vec![0];
            bytes.extend([0x11; 16]);
            bytes
        };
        let (manager, writes) = scripted_manager_with_error(
            vec![
                response(0x33, &[]),
                response(0x4b, &[1, 1, 0, 4, 8, 4, 0x12, 0x34, 0x56, 0x78]),
                response(0x41, &[0]),
                response(0x41, &original),
                pn532::ACK.to_vec(),
            ],
            io::ErrorKind::TimedOut,
        );
        let request = WriteRequest {
            uid: "12345678".into(),
            mode: "classic".into(),
            address: 4,
            hex: "AA".repeat(16),
            expected_hex: "11".repeat(16),
            key_type: Some("A".into()),
            key: Some("112233445566".into()),
            confirmed: true,
        };
        let result = write_connected_card(&manager, &request).unwrap();
        assert!(result.write_attempted);
        assert!(!result.verified);
        assert_eq!(
            result.before_hex.as_deref(),
            Some("11111111111111111111111111111111")
        );
        assert!(result.after_hex.is_none());
        assert!(result.error.unwrap().contains("超时"));
        assert!(manager.0.lock().unwrap().session.is_none());
        assert_eq!(
            writes.lock().unwrap().len(),
            5,
            "never send release or retry after losing response boundary"
        );
    }

    #[test]
    fn card_commands_require_an_active_session() {
        let manager = ReaderManager::default();
        assert!(
            scan_connected_card(&manager)
                .unwrap_err()
                .contains("未连接")
        );
        assert!(
            read_connected_card(&manager, &known_key_request())
                .unwrap_err()
                .contains("未连接")
        );
    }

    #[test]
    fn dictionary_transport_failure_invalidates_session_without_retry_or_release() {
        let (manager, writes) = scripted_manager(vec![
            response(0x33, &[]),
            response(0x4b, &[1, 1, 0, 4, 8, 4, 0x12, 0x34, 0x56, 0x78]),
            // RF-off fails at transport level: never issue RF-on, auth or release.
        ]);
        let request = crate::dictionary::DictionaryRequest {
            run_id: "test-run".into(),
            uid: "12345678".into(),
            start_sector: 0,
            sector_count: 1,
            use_common_keys: true,
            keys: vec![],
            confirmed: true,
        };
        let result = with_card_session(&manager, |exchange| {
            crate::dictionary::check(&request, exchange, &|| false, &mut |_| {})
        })
        .unwrap();
        assert!(!result.dump.complete);
        assert_eq!(result.attempts, 0);
        assert!(result.sectors[0].key_a.is_none());
        assert!(result.error.is_some());
        assert!(manager.0.lock().unwrap().session.is_none());
        assert_eq!(writes.lock().unwrap().len(), 3);
    }

    #[test]
    fn no_card_keeps_the_checked_serial_session() {
        let (manager, writes) = scripted_manager(vec![response(0x33, &[]), response(0x4b, &[0])]);
        assert!(scan_connected_card(&manager).unwrap().is_none());
        let state = manager.0.lock().unwrap();
        assert!(state.session.is_some());
        assert!(state.connection_error.is_none());
        assert_eq!(writes.lock().unwrap().len(), 2);
    }

    #[test]
    fn authentication_failure_is_a_card_error_and_session_remains_usable() {
        let (manager, writes) = scripted_manager(vec![
            response(0x33, &[]),
            response(0x4b, &[1, 1, 0, 4, 8, 4, 0x12, 0x34, 0x56, 0x78]),
            response(0x41, &[0x14]),
            response(0x53, &[0]),
        ]);
        let dump = read_connected_card(&manager, &known_key_request()).unwrap();
        assert!(!dump.complete);
        assert!(dump.error.unwrap().contains("认证失败"));
        assert!(manager.0.lock().unwrap().session.is_some());
        assert_eq!(writes.lock().unwrap().len(), 4);
    }

    #[test]
    fn broken_stream_drops_session_and_does_not_send_release_into_unknown_response() {
        let (manager, writes) = scripted_manager(vec![
            response(0x33, &[]),
            response(0x4b, &[1, 1, 0, 4, 8, 4, 0x12, 0x34, 0x56, 0x78]),
        ]);
        let dump = read_connected_card(&manager, &known_key_request()).unwrap();
        assert!(!dump.complete);
        assert!(dump.rows.is_empty());
        let state = manager.0.lock().unwrap();
        assert!(state.session.is_none());
        assert!(
            state
                .connection_error
                .as_ref()
                .unwrap()
                .contains("重新连接")
        );
        assert_eq!(writes.lock().unwrap().len(), 3);
    }

    #[test]
    fn silent_port_deadline_invalidates_session_without_sending_another_command() {
        let (manager, writes) =
            scripted_manager_with_error(vec![pn532::ACK.to_vec()], io::ErrorKind::TimedOut);
        assert!(scan_connected_card(&manager).unwrap_err().contains("超时"));
        assert!(manager.0.lock().unwrap().session.is_none());
        assert_eq!(writes.lock().unwrap().len(), 1);
    }

    #[test]
    fn invalid_frame_drops_session_before_another_card_command_can_start() {
        let mut bad = response(0x33, &[]);
        *bad.last_mut().unwrap() = 1;
        let (manager, writes) = scripted_manager(vec![bad]);
        assert!(scan_connected_card(&manager).is_err());
        assert!(
            scan_connected_card(&manager)
                .unwrap_err()
                .contains("未连接")
        );
        assert!(manager.0.lock().unwrap().session.is_none());
        assert_eq!(writes.lock().unwrap().len(), 1);
    }

    fn describe_connected_port(product: &str) -> SerialDevice {
        describe_port(SerialPortInfo {
            port_name: "COM7".into(),
            port_type: SerialPortType::UsbPort(serialport::UsbPortInfo {
                vid: 0x1a86,
                pid: 0x7523,
                manufacturer: Some("wch.cn".into()),
                product: Some(product.into()),
                serial_number: None,
            }),
        })
    }

    #[test]
    fn ch340_is_only_a_candidate_not_a_confirmed_reader() {
        let device = describe_connected_port("USB-SERIAL CH340");
        assert!(device.is_candidate);
        assert_eq!(device.vid.as_deref(), Some("1A86"));
        assert_eq!(device.pid.as_deref(), Some("7523"));
        assert_eq!(device.port_name, "COM7");
        assert!(ReaderManager::default().0.lock().unwrap().session.is_none());
    }

    #[test]
    fn windows_friendly_name_does_not_repeat_port_suffix() {
        assert_eq!(
            describe_connected_port("USB-SERIAL CH340 (COM7)").label,
            "USB-SERIAL CH340 (COM7)"
        );
        assert_eq!(
            describe_connected_port("USB-SERIAL CH340").label,
            "USB-SERIAL CH340 (COM7)"
        );
    }

    #[test]
    fn unknown_serial_port_remains_selectable() {
        let device = describe_port(SerialPortInfo {
            port_name: "COM9".into(),
            port_type: SerialPortType::Unknown,
        });
        assert_eq!(device.port_name, "COM9");
        assert!(!device.is_candidate);
        assert_eq!(device.vid, None);
    }

    #[test]
    fn validates_baud_rate_before_opening_any_port() {
        let error = connect(&ReaderManager::default(), "not-a-port", 1).unwrap_err();
        assert!(error.contains("波特率"));
    }

    /// Run manually with `cargo test inspect_local_reader -- --ignored --nocapture`.
    /// Uses the exact application's enumeration/probe path; never writes card data.
    #[test]
    #[ignore = "requires explicit PCR532_TEST_PORT environment variable and a plugged-in reader"]
    fn inspect_local_reader() {
        let port_name = std::env::var("PCR532_TEST_PORT").expect("set PCR532_TEST_PORT explicitly");
        let baud = std::env::var("PCR532_TEST_BAUD")
            .unwrap_or_else(|_| "115200".into())
            .parse()
            .unwrap();
        let manager = ReaderManager::default();
        let before = snapshot(&manager).unwrap();
        println!(
            "Enumerated devices: {}",
            serde_json::to_string(&before).unwrap()
        );
        assert!(before.ports.iter().any(|port| port.port_name == port_name));
        let connection = connect(&manager, &port_name, baud).expect("PN532 firmware handshake");
        println!(
            "Verified reader: {}",
            serde_json::to_string(&connection).unwrap()
        );
        for heartbeat in 0..5 {
            if heartbeat == 1 {
                // Exercise the idle interval used by the UI's three-second poll.
                std::thread::sleep(Duration::from_millis(3_100));
            }
            let after = snapshot(&manager).unwrap();
            assert!(
                after.connection.is_some(),
                "heartbeat {heartbeat} failed: {:?}",
                after.connection_error
            );
        }
        assert!(
            connect(&manager, &port_name, baud)
                .unwrap_err()
                .contains("已连接")
        );
        disconnect(&manager).unwrap();
        assert!(snapshot(&manager).unwrap().connection.is_none());
        // A second exclusive open proves the previous handle was released.
        connect(&manager, &port_name, baud).expect("reconnect after releasing port");
        assert!(snapshot(&manager).unwrap().connection.is_some());
        disconnect(&manager).unwrap();
    }
}
