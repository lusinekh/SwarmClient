using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Net.Mail;
using Newtonsoft.Json;

namespace TcpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Loopback, 1234);
            TcpListener listener = new TcpListener(ep);
            listener.Start();

            Console.WriteLine(@"
            ===================================================
                   Started listening requests at: {0}:{1}
            ===================================================", 
            ep.Address, ep.Port);

            // Run the loop continously; this is the server.
            while (true)
            {
                const int bytesize = 1024 * 1024;

                string message = null;
                byte[] buffer = new byte[bytesize];

                var sender = listener.AcceptTcpClient();
                sender.GetStream().Read(buffer, 0, bytesize);

                // Read the message, and perform different actions
                message = cleanMessage(buffer);

                // Save the data sent by the client;
                Person person = JsonConvert.DeserializeObject<Person>(message); // Deserialize

                byte[] bytes = System.Text.Encoding.Unicode.GetBytes("Thank you for your message, " + person.Name);
                sender.GetStream().Write(bytes, 0, bytes.Length); // Send the response

                sendEmail(person);
            }
        }

        private static void sendEmail(Person p)
        {
            try
            {
                // Send an email to user also to notify him of the delivery.
                using (SmtpClient client = new SmtpClient("<smtp-server>", 25))
                {
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential("<email>", "<pass>");

                    client.Send(
                        new MailMessage("<email>", p.Email,
                            "Thank you for using the Web Service",
                            string.Format(
    @"Thank you for using our Web Service, {0}. 

We have recieved your message, '{1}'.", p.Name, p.Message
                            )
                        )
                    );
                }

                Console.WriteLine("Email sent to " + p.Email); // Email sent successfully
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static string cleanMessage(byte[] bytes)
        {
            string message = System.Text.Encoding.Unicode.GetString(bytes);

            string messageToPrint = null;
            foreach (var nullChar in message)
            {
                if (nullChar != '\0')
                {
                    messageToPrint += nullChar;
                }
            }
            return messageToPrint;
        }

        // Sends the message string using the bytes provided.
        private static void sendMessage(byte[] bytes, TcpClient client)
        {
            client.GetStream()
                .Write(bytes, 0, 
                bytes.Length); // Send the stream
        }
    }

    class Person
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
