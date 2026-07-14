using System;
using System.Diagnostics;
using System.IO;

class ProcessSecurityAuditor
{
    public static void AuditProcesses()
    {
        Console.WriteLine("[*] Starte Prozess-Sicherheits-Audit...");
        Process[] processes = Process.GetProcesses();

        foreach (var proc in processes)
        {
            try
            {
                string path = proc.MainModule?.FileName;
                if (string.IsNullOrEmpty(path)) continue;

                // Warnung, wenn Prozesse aus dem Benutzerverzeichnis (Temp/AppData) ausgeführt werden
                if (path.Contains("\\AppData\\") || path.Contains("\\Temp\\"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"⚠️ [WARNUNG] Verdächtiger Prozesspfad: {proc.ProcessName} (PID: {proc.Id}) läuft aus: {path}");
                    Console.ResetColor();
                }
            }
            catch
            {
                // Ignoriere Systemprozesse, für die wir keine Leseberechtigungen besitzen
            }
        }
        Console.WriteLine("[+] Audit abgeschlossen.");
    }
}
