mod cards;
mod pn532;
mod reader;

#[derive(serde::Serialize)]
struct AppInfo {
    name: &'static str,
    version: &'static str,
    os: &'static str,
    arch: &'static str,
}

/// A read-only command for checking frontend-to-Rust communication.
#[tauri::command]
fn get_app_info() -> AppInfo {
    AppInfo {
        name: "PCR532 Desktop",
        version: env!("CARGO_PKG_VERSION"),
        os: std::env::consts::OS,
        arch: std::env::consts::ARCH,
    }
}

#[cfg_attr(mobile, tauri::mobile_entry_point)]
pub fn run() {
    tauri::Builder::default()
        .plugin(tauri_plugin_opener::init())
        .manage(reader::ReaderManager::default())
        .invoke_handler(tauri::generate_handler![
            get_app_info,
            reader::get_device_snapshot,
            reader::connect_reader,
            reader::disconnect_reader,
        ])
        .run(tauri::generate_context!())
        .expect("error while running PCR532 Desktop");
}

#[cfg(test)]
mod tests {
    use super::get_app_info;

    #[test]
    fn app_info_matches_package_and_current_platform() {
        let info = get_app_info();
        assert_eq!(info.name, "PCR532 Desktop");
        assert_eq!(info.version, env!("CARGO_PKG_VERSION"));
        assert_eq!(info.os, std::env::consts::OS);
        assert_eq!(info.arch, std::env::consts::ARCH);
    }
}
