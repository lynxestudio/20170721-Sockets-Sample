using System;
using System.Net.Sockets;
using System.IO;
using System.Net;

#region Variables
IPAddress ip = IPAddress.Parse("127.0.0.1");
int port = 54321;
#endregion

Console.Clear();
Console.WriteLine("+---------------------------+");
Console.WriteLine("| Sample Socket Client      |");
Console.WriteLine("+---------------------------+");
Console.WriteLine("");
Console.Write("[ Enter Server IP address (default: 127.0.0.1)] ");
string? sIp = Console.ReadLine();
Console.Write("[ Enter port number (default: 54321)] ");
string? sPort = Console.ReadLine();
Console.WriteLine();

try
{
    if (!String.IsNullOrEmpty(sIp))
        ip = IPAddress.Parse(sIp);
    if(!String.IsNullOrEmpty(sPort))
        Int32.TryParse(sPort, out port);

    TcpClient socket = new TcpClient(ip.ToString(),port);
    NetworkStream inputStream = socket.GetStream();
    using (StreamReader reader = new StreamReader(inputStream))
    {
        string? message = reader.ReadLine();
        Console.WriteLine("[ Message from server ]");
        Console.WriteLine("===========================");
        Console.WriteLine($"\t{message}");
        Console.WriteLine();
        inputStream.Close();
        socket.Close();
    }
}
catch (SocketException socketException)
{
    Console.WriteLine("[ Exception ]");
    Console.WriteLine("===========================");
    Console.WriteLine($"SocketException: {socketException.Message}");
}
catch(Exception exception)
{
    Console.WriteLine("[ Exception ]");
    Console.WriteLine("===========================");
    Console.WriteLine($"Exception: {exception.Message}");
}
