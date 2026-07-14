use sha2::{Sha256, Digest};
use std::fs::File;
use std::io::{self, Read};

fn calculate_sha256(path: &str) -> io::Result<String> {
    let mut file = File::open(path)?;
    let mut hasher = Sha256::new();
    let mut buffer = [0; 1024];

    loop {
        let count = file.read(&mut buffer)?;
        if count == 0 { break; }
        hasher.update(&buffer[..count]);
    }

    Ok(format!("{:x}", hasher.finalize()))
}

fn main() {
    let file_path = "wichtige_datei.txt"; // Pfad anpassen
    match calculate_sha256(file_path) {
        Ok(hash) => println!("[+] SHA-256 für '{}':\n    {}", file_path, hash),
        Err(e) => println!("[-] Fehler beim Lesen der Datei: {}", e),
    }
}
