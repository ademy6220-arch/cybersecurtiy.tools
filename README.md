# cybersecurtiy.tools
Markdown

# Multi-Language Network & Security Toolkit

A powerful, modular security suite combining **Rust**, **C# (.NET)**, and **Nmap** to perform high-performance network scans, directory auditing, cryptographic operations, system hardening, and real-time security monitoring.

---

## 🛠️ Features & Project Structure

### 1. 🦀 Rust Security Tools (`/rust-scanner` & `/rust-security-tools`)
Rust's memory safety and speed make it ideal for low-level system auditing and fast network operations.
* **Asynchronous IP & Port Scanner:** Built with `tokio` for concurrent port scanning.
* **Backup Finder:** Recursively scans directories for exposed sensitive backup extensions (`.bak`, `.zip`, etc.).
* **Proxy Validator:** Verifies if HTTP/SOCKS5 proxies are live and routing traffic securely.
* **SHA-256 Verifier (`sha256_verifier.rs`):** Computes cryptographic file hashes to verify integrity and detect tampering.
* **Secure Password Generator (`secure_password_gen.rs`):** Generates high-entropy passwords using cryptographically secure random number generation (`OsRng`).
* **Log Analyzer (`log_analyzer.rs`):** Scans system auth logs to detect potential brute-force and unauthorized access attempts.
* **Directory Monitor (`directory_monitor.rs`):** A lightweight Host Intrusion Detection (HIDS) component that monitors folder changes in real-time.
* **SSL Expiry Checker (`ssl_expiry_checker.rs`):** Validates SSL/TLS certificates of remote domains to prevent service disruptions.

### 2. ⚡ C# Security Tools (`/csharp-scanner` & `/csharp-security-tools`)
C# (.NET) is leveraged for Windows security analysis, API monitoring, and database logging.
* **Firewall Detector & Port Scanner:** Detects whether ports are open, closed, or actively filtered by a firewall (analyzing timeouts vs resets).
* **SQLite Database Logger:** Automatically logs network scanning diagnostics with timestamps in a local `scan_results.db`.
* **Process Security Auditor (`ProcessSecurityAuditor.cs`):** Audits running Windows processes to detect binaries spawning from untrusted directories (e.g., `Temp`, `AppData`).
* **Secure AES Encryptor (`SecureAesEncryptor.cs`):** Encrypts and decrypts sensitive files using military-grade AES-256 encryption.
* **Simple Port Listener / Honeypot (`SimplePortListener.cs`):** Listens on a specific port and triggers immediate intrusion alerts when unauthorized connections are attempted.
* **DNS Security Auditor (`DnsSecurityAuditor.cs`):** Audits target domains for vital anti-spoofing and anti-phishing DNS records like SPF.
* **Windows Event Log Monitor (`SystemEventLogMonitor.cs`):** Monitors the Windows Security Event Log in real-time to alert on failed login attempts (Event ID 4625).

### 3. 🔍 Nmap Scripts (`/nmap-scripts`)
* Pre-configured shell scripts to map active network firewalls using TCP-ACK and advanced SYN packets.

---

## 🚀 How to Run

### Rust Security Tools
Ensure you have [Rust](https://rustup.rs/) installed.
```bash
# To run the primary scanner
cd rust-scanner
cargo run

# To run a specific security script (e.g., Password Generator)
rustc rust-security-tools/secure_password_gen.rs
./secure_password_gen
# To run the primary C# database scanner
cd csharp-scanner
dotnet run
📊 Database Schema (SQLite)The C# network scanner automatically creates and logs results into scan_results.db:ColumnTypeDescriptionIdINTEGERPrimary Key (Auto-Increment)IPTEXTScanned Target IPPortINTEGERScanned PortStatusTEXTOpen / Closed / Filtered (Firewall)TimestampDATETIMETime of the scanDisclaimer: This repository is intended for educational, authorized penetration testing, and administrative security auditing purposes only.
