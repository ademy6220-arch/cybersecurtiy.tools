# cybersecurtiy.tools
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
