using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace SwarmServer
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				TcpListener myList = new TcpListener(IPAddress.Any, 8000);
				myList.Start();
				Console.WriteLine("Server running - Port: 8000");
				Console.WriteLine("Local end point:" +
											myList.LocalEndpoint);
				Console.WriteLine("Waiting for connections...");

				Socket s = myList.AcceptSocket();

				Console.WriteLine("Connection accepted from " + s.RemoteEndPoint);

				byte[] b = new byte[100];
				int k = s.Receive(b);
				Console.WriteLine("Recieved...");

				for (int i = 0; i < k; i++)
				{
					Console.Write(Convert.ToChar(b[i]));
				}
				ASCIIEncoding asen = new ASCIIEncoding();

				s.Send(asen.GetBytes("Automatic message:" + "String received by server!"));

				Console.WriteLine("\n Automatic message sent!");

				s.Close();
				myList.Stop();
			}

			catch (System.IO.IOException e)
			{
				Console.WriteLine("Error..... " + e.StackTrace);
			}



		}
	}
}
