using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace TcpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("================================");
            Console.WriteLine("=   Enter details and submit   =");
            Console.WriteLine("================================");

            // Get the details from the user, and store them.
            Person person = new Person();

            Console.Write("Enter your name: ");
            person.Name = Console.ReadLine();
            Console.Write("Enter your email address: ");
            person.Email = Console.ReadLine();
            Console.Write("Enter your message: ");
            person.Message = Console.ReadLine();

            // Send the message
            byte[] bytes = sendMessage(System.Text.Encoding.Unicode.GetBytes(person.ToJSON()));
            Console.WriteLine(cleanMessage(bytes));

            Console.Read();
        }

        private static byte[] sendMessage(byte[] messageBytes)
        {
            const int bytesize = 1024 * 1024;
            try
            {
                System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient("127.0.0.1", 1234); // Create a new connection
                NetworkStream stream = client.GetStream();

                stream.Write(messageBytes, 0, messageBytes.Length); // Write the bytes
                Console.WriteLine("================================");
                Console.WriteLine("=   Connected to the server    =");
                Console.WriteLine("================================");
                Console.WriteLine("Waiting for response...");

                messageBytes = new byte[bytesize];

                stream.Read(messageBytes, 0, messageBytes.Length);

                // Clean up
                stream.Dispose();
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return messageBytes;
        }

        private static string cleanMessage(byte[] bytes)
        {
            string message = System.Text.Encoding.Unicode.GetString(bytes);
            Console.WriteLine(message);

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
    }

    class Person
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }

        // Create the JSON representation of object
        public string ToJSON()
        {
            string str = "{";
            str += "'name': '" + Name;
            str += "','email': '" + Email;
            str += "','message': '" + Message;

            str += "'}";
            return str;
        }
    }
}
