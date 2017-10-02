using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp34
{
	class Program
	{
		static void Main(string[] args)
		{
			Task t = Echo();
			t.Wait();

		}

		
		public static async Task Echo()
		{
			
			        var message1 = ("{\"command\": \"request_session\",\"params\": {\"site_id\": 1,\"language\": \"arm\"}}");



			var message =  ("{\"command\": \"login\",\"params\": {\"username\": \"Sales1\",\"password\": \"Sales1!2\"}}");

			using (ClientWebSocket ws = new ClientWebSocket())
			{
				Uri serverUri = new Uri("wss://eu-spring-terminals-elk.betconstruct.com");
				await ws.ConnectAsync(serverUri, System.Threading.CancellationToken.None);
				while (ws.State == System.Net.WebSockets.WebSocketState.Open)
				{
					Console.Write("Input message ('exit' to exit): ");
					string msg = Console.ReadLine();
					if (msg == "exit")
					{
						break;
					}


							ArraySegment<byte> bytesToSend1 = new ArraySegment<byte>(Encoding.UTF8.GetBytes(message1));
							await ws.SendAsync(bytesToSend1, WebSocketMessageType.Text, true, CancellationToken.None);
							ArraySegment<byte> bytesReceived1 = new ArraySegment<byte>(new byte[1024]);
							WebSocketReceiveResult result1 = await ws.ReceiveAsync(bytesReceived1, CancellationToken.None);
							Console.WriteLine(Encoding.UTF8.GetString(bytesReceived1.Array, 0, result1.Count));
					
					//		ArraySegment<byte> bytesToSend2 = new ArraySegment<byte>(Encoding.UTF8.GetBytes(message));
					//await ws.SendAsync(bytesToSend2, WebSocketMessageType.Text, true, CancellationToken.None);
					//ArraySegment<byte> bytesReceived2 = new ArraySegment<byte>(new byte[1024]);
					//WebSocketReceiveResult result2 = await ws.ReceiveAsync(bytesReceived2, CancellationToken.None);
					//Console.WriteLine(Encoding.UTF8.GetString(bytesReceived2.Array, 0, result2.Count));


					//ArraySegment<byte> bytesToSend = new ArraySegment<byte>(Encoding.UTF8.GetBytes(msg));
					//await ws.SendAsync(bytesToSend, WebSocketMessageType.Text, true, CancellationToken.None);
					//ArraySegment<byte> bytesReceived = new ArraySegment<byte>(new byte[1024]);
					//WebSocketReceiveResult result = await ws.ReceiveAsync(bytesReceived, CancellationToken.None);
					//Console.WriteLine(Encoding.UTF8.GetString(bytesReceived.Array, 0, result.Count));
				}
			}


		}
	}

}













