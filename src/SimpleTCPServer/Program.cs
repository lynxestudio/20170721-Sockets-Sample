using System;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Linq.Expressions;


int port = 54321;
TcpListener listener = new TcpListener(IPAddress.Loopback,port);
try
{
    //Start listening for client requests
    listener.Start();
    Console.WriteLine($"Waiting for connections on {port}...");
    TcpClient socket = listener.AcceptTcpClient();
    NetworkStream outputStream = socket.GetStream();
    using (StreamWriter writer = new StreamWriter(outputStream))
    {
        writer.WriteLine("Hello World to the client!");
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
