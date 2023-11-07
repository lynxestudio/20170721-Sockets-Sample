using System;
using System.Net.Sockets;
using System.Net;
using System.IO;

class Program
{
        static void Main(string[] args)
        {
			TcpClient socket = null;
			NetworkStream outputStream = null;
			TcpListener listener = null;
			int port = 8080;
			if(args.Length == 1)
			{
				port = Int32.Parse(args[0]);
				try
				{
					listener = new TcpListener(IPAddress.Loopback,port);
					//Start listening for client requests
					listener.Start();
					Console.WriteLine("Waiting for connections on {0}...",port);
					socket = listener.AcceptTcpClient();
					outputStream = socket.GetStream();
					using(StreamWriter writer = new StreamWriter(outputStream))
					{
						writer.WriteLine("Hello World to the client!");
					}
				}
				catch (System.Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
				finally
				{
					//clean
					outputStream.Close();
					socket.Close();
					// Stop listening for clients requests
					listener.Stop();
				}
			}
			else
				Console.WriteLine("Usage: mono SimpleTCPServer.exe [port number]");
        }
}
