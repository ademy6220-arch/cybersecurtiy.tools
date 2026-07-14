using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

class SimplePortListener
{
    public static async Task StartHoneypot(int port)
    {
        TcpListener listener = new TcpListener(IPAddress.Any, port);
        listener.Start();
        Console.WriteLine($"🟢 [Honeypot] Überwache Port {port} auf unbefugte Zugriffe...");

        while (true)
        {
            TcpClient client = await listener.AcceptTcpClientAsync();
            string clientIp = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"🚨 [ALERT] Unerwarteter Verbindungsversuch von IP: {clientIp} auf Port {port}!");
            Console.ResetColor();
            
            client.Close();
        }
    }
}
