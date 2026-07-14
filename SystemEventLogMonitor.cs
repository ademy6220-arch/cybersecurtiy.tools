using System;
using System.Diagnostics;

class SystemEventLogMonitor
{
    public static void StartMonitoring()
    {
        Console.WriteLine("[*] Überwache Windows-Sicherheits-Eventlogs...");
        try
        {
            EventLog eventLog = new EventLog("Security");
            eventLog.EntryWritten += (sender, e) =>
            {
                // Event ID 4625 = Fehlgeschlagene Anmeldung auf dem Windows-System
                if (e.Entry.InstanceId == 4625)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"🚨 [WARNUNG] Fehlgeschlagener Windows-Anmeldeversuch erkannt um {e.Entry.TimeGenerated}!");
                    Console.ResetColor();
                }
            };
            eventLog.EnableRaisingEvents = true;
            Console.WriteLine("[+] Eventlog-Überwachung aktiv. Drücke Enter zum Beenden.");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[-] Fehler: Administrative Rechte erforderlich! ({ex.Message})");
        }
    }
}
