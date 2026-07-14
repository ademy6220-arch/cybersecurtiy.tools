use rand::{Rng, rngs::OsRng};

fn generate_secure_password(length: usize) -> String {
    let charset = b"ABCDEFGHIJKLMNOPQRSTUVWXYZ\
                    abcdefghijklmnopqrstuvwxyz\
                    0123456789!@#$%^&*()_+-=[]{}|;:,.<>?";
    let mut rng = OsRng;
    
    (0..length)
        .map(|_| {
            let idx = rng.gen_range(0..charset.len());
            charset[idx] as char
        })
        .collect()
}

fn main() {
    let pwd = generate_secure_password(24);
    println!("[+] Generiertes Sicherheits-Passwort (24 Zeichen):");
    println!("    {}", pwd);
}
