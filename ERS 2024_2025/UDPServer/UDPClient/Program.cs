using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UDPClient
{
    class Program
    {
        const string SERVER_IP_ADDRESS = "127.0.0.1";
        const int SERVER_PORT = 52000;
        const int BUFFER_SIZE = 512;

        static void Main(string[] args)
        {
            EndPoint serverAddress;
            Socket clientSocket;

            try
            {
                serverAddress = new IPEndPoint(IPAddress.Parse(SERVER_IP_ADDRESS),SERVER_PORT);
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            }
            catch (SocketException ex)
            {
                Console.WriteLine($"Creation of Udp Client socket failed with error: {ex.SocketErrorCode} ");
                Console.ReadKey();
                return;

            }

            Console.WriteLine("Enter message to send: ");
            string message = Console.ReadLine();
            byte[] dataBuffer = Encoding.UTF8.GetBytes(message);

            try
            {
                int iResult = clientSocket.SendTo(dataBuffer, serverAddress);
            }catch(SocketException ex) {
                Console.WriteLine($"Sendto socket failed with error: {ex.SocketErrorCode} ");
                Console.ReadKey();
                return;
            }
            clientSocket.Close();
            Console.WriteLine("Press and key exit");
            Console.ReadLine();
        }
    }
}
