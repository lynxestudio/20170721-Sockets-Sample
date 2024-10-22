using System;
using System.Net.Sockets;
using System.IO;

Console.Clear();
try
{
    TcpClient socket = new TcpClient("127.0.0.1",54321);
    NetworkStream inputStream = socket.GetStream();
    using (StreamReader reader = new StreamReader(inputStream))
    {
        string? message = reader.ReadLine();
        Console.WriteLine($"[ Message from server ] = {message} ");
        Console.WriteLine();
        inputStream.Close();
        socket.Close();
    }
}
catch (SocketException socketException)
{
    Console.WriteLine($"SocketException: {socketException.Message}");
}
catch(Exception exception)
{
    Console.WriteLine($"Exception: {exception.Message}");
}
