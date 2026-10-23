use std::io;
use std::sync::{Arc, Mutex};
use std::time::{Duration, Instant};

use serialport::{SerialPort, SerialPortInfo, SerialPortType};

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
            Err(error) => return Err(format!("读取固件失败，设备可能已拔出：{error}")),
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
