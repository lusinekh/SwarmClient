using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows;

namespace SwarmClient.ViewModels
{
	public class TcpServereConnect
	{
		#region Variables 
		private TcpClient client = null;
		private NetworkStream _stream = null;
		private String _responseData = null;
		

		#endregion
		#region Propertys
		
		public String responseData
		{
			set { _responseData = value; }
			get { return _responseData; }
		}


		public NetworkStream stream
		{
			set { _stream = value; }
			get { return _stream; }
		}


		public TcpClient Client
		{
			set { client = value; }
			get { return client; }
		}

		#endregion
		#region Function
		public void Connect(String server, int port)
		{
			try
			{
				// Create a TcpClient.
				// Note, for this client to work you need to have a TcpServer 
				// connected to the same address as specified by the server, port
				// combination.
				//Int32 port = 13000;
				client = new TcpClient(server, port);
			}
			catch (ArgumentNullException e)
			{
				Console.WriteLine("ArgumentNullException: {0}", e);
			}
			catch (SocketException e)
			{
				Console.WriteLine("SocketException: {0}", e);
			}
			/////////////////////////////////////////////////////////////////////////////////////////////////////
			////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		}
		public void SendMassage(String message)
		{
			try
			{
					// Translate the passed message into ASCII and store it as a Byte array.
					//Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

					Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

					// Get a client stream for reading and writing.
					//  Stream stream = client.GetStream();

					stream = client.GetStream();

					// Send the message to the connected TcpServer. 
					stream.Write(data, 0, data.Length);
					// Receive the TcpServer.response.

					// Buffer to store the response bytes.
					data = new Byte[256];

					// String to store the response ASCII representation.
					responseData = String.Empty;

					// Read the first batch of the TcpServer response bytes.
					Int32 bytes = stream.Read(data, 0, data.Length);
					responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
				// Close everything.
				//stream.Close();
				//client.Close();

			}
			catch (ArgumentNullException e)
			{
				Console.WriteLine("ArgumentNullException: {0}", e);
			}
			catch (SocketException e)
			{
				Console.WriteLine("SocketException: {0}", e);
			}
			
			finally
			{

				//stream.Close();
				//client.Close();
			}
			Console.WriteLine("\n Press Enter to continue...");
			Console.Read();
		}
#endregion
	}
}
