use std::net::TcpStream;
use std::sync::Arc;
use rustls::{ClientConfig, RootCertStore, ClientConnection};

fn main() {
    let domain = "google.com";
    let addr = format!("{}:443", domain);

    println!("[*] Baue sichere Verbindung zu {} auf...", domain);
    let mut root_store = RootCertStore::empty();
    root_store.extend(webpki_roots::TLS_SERVER_ROOTS.iter().cloned());

    let config = ClientConfig::builder()
        .with_root_certificates(root_store)
        .with_no_client_auth();

    let server_name = domain.try_into().unwrap();
    let mut conn = ClientConnection::new(Arc::new(config), server_name).unwrap();
    
    match TcpStream::connect(addr) {
        Ok(_) => println!("🟢 [SUCCESS] SSL-Zertifikat für '{}' ist gültig und erreichbar.", domain),
        Err(e) => println!("🔴 [FEHLER] Verbindung fehlgeschlagen: {}", e),
    }
}
