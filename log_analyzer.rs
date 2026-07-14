use std::fs::File;
use std::io::{self, BufRead, BufReader};

fn analyze_auth_logs(log_path: &str) -> io::Result<()> {
    let file = File::open(log_path)?;
    let reader = BufReader::new(file);
    let mut alerts = 0;

    println!("[*] Analysiere Log-Datei...");
    for (line_num, line) in reader.lines().enumerate() {
        let line = line?;
        if line.contains("Failed password") || line.contains("Unauthorized") || line.contains("login failed") {
            println!("🚨 [ALERT] Zeile {}: Verdächtige Aktivität gefunden -> {}", line_num + 1, line.trim());
            alerts += 1;
        }
    }
    println!("[+] Analyse beendet. Verdächtige Einträge: {}", alerts);
    Ok(())
}

fn main() {
    let _ = analyze_auth_logs("auth.log");
}
