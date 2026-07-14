using System;
using System.IO;
using System.Security.Cryptography;

class SecureAesEncryptor
{
    public static void EncryptFile(string filePath, string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(16); // Kryptografischer Salt
        using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256))
        {
            byte[] key = deriveBytes.GetBytes(32); // 256-bit Key
            byte[] iv = deriveBytes.GetBytes(16);  // 128-bit IV

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                string encryptedPath = filePath + ".enc";
                using (var fsCrypt = new FileStream(encryptedPath, FileMode.Create))
                {
                    fsCrypt.Write(salt, 0, salt.Length); // Schreibe den Salt zuerst in die Datei
                    using (var cryptoStream = new CryptoStream(fsCrypt, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        using (var fsIn = new FileStream(filePath, FileMode.Open))
                        {
                            fsIn.CopyTo(cryptoStream);
                        }
                    }
                }
                Console.WriteLine($"[+] Datei erfolgreich verschlüsselt: {encryptedPath}");
            }
        }
    }
}
