using System;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Linq.Expressions;

Console.Clear();
int port = 54321;
string? sPort = "54321";
TcpListener listener = new TcpListener(IPAddress.Loopback,port);
Console.WriteLine("+------------------------------------+");
Console.WriteLine("| Simple Server Sample               |");
Console.WriteLine("+------------------------------------+");
Console.WriteLine();
Console.Write("[ Enter a port number (default: 54321)]");
sPort = Console.ReadLine();
if(!string.IsNullOrEmpty(sPort))
    Int32.TryParse(sPort, out port);
try
{
    //Start listening for client requests
    listener.Start();
    Console.WriteLine($"Waiting for connections on {port}...");
    TcpClient socket = listener.AcceptTcpClient();
    NetworkStream outputStream = socket.GetStream();
    Console.Write("[ Enter message to the client ]\t");
    string? message = Console.ReadLine();
    using (StreamWriter writer = new StreamWriter(outputStream))
    {
        writer.WriteLine(message);
    }
}
catch (System.Exception ex)
{
    Console.WriteLine(ex.Message);
}
finally{
    //stop listening for client requests
    listener.Stop();
}
