using System;
using System.Diagnostics;

class DnsSecurityAuditor
{
    public static void CheckDnsSecurity(string domain)
    {
        Console.WriteLine($"[*] DNS-Sicherheitsaudit für Domain: {domain}");
        try
        {
            ProcessStartInfo procInfo = new ProcessStartInfo("nslookup", $"-type=TXT {domain}")
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process proc = Process.Start(procInfo))
            {
                string output = proc.StandardOutput.ReadToEnd();
                if (output.Contains("v=spf1"))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[+] SPF-Eintrag gefunden! Schutz vor E-Mail-Spoofing ist aktiv.");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("⚠️ [WARNUNG] Kein SPF-Eintrag gefunden! Angreifer könnten E-Mails im Namen dieser Domain fälschen.");
                }
                Console.ResetColor();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[-] Fehler beim DNS-Lookup: {ex.Message}");
        }
    }
}
