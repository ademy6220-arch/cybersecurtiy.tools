use std::fs;
use std::time::SystemTime;
use std::collections::HashMap;
use std::thread;
use std::time::Duration;

fn main() {
    let target_dir = "./wichtiger_ordner"; // Zu überwachender Ordner
    println!("[*] Überwache Ordner: {}", target_dir);
    
    let mut file_states: HashMap<String, SystemTime> = HashMap::new();

    loop {
        if let Ok(entries) = fs::read_dir(target_dir) {
            for entry in entries.flatten() {
                let path = entry.path();
                if path.is_file() {
                    let path_str = path.to_string_lossy().to_string();
                    if let Ok(metadata) = fs::metadata(&path) {
                        if let Ok(modified) = metadata.modified() {
                            if let Some(old_time) = file_states.get(&path_str) {
                                if *old_time != modified {
                                    println!("📝 [MODIFIZIERT] Datei wurde geändert: {}", path_str);
                                    file_states.insert(path_str, modified);
                                }
                            } else {
                                println!("🆕 [NEU] Neue Datei erkannt: {}", path_str);
                                file_states.insert(path_str, modified);
                            }
                        }
                    }
                }
            }
        }
        thread::sleep(Duration::from_secs(2));
    }
}
