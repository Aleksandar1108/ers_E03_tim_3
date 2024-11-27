using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UDPServer
{
    class Program
    {
        const int SERVER_PORT = 52000;
        const int BUFFER_SIZE = 512;
        static void Main(string[] args)
        {
            Socket serverSocket;
            byte[] dataBuffer = new byte[BUFFER_SIZE];

            
            try
            {
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            }
            catch(SocketException ex)
            {

                Console.WriteLine($"Creation of UDP Server socket failed with error: { ex.SocketErrorCode } ");
                Console.ReadKey();
                return;
            }


            try
            {
                serverSocket.Bind(new IPEndPoint(IPAddress.Any, SERVER_PORT));
            }
            catch (SocketException ex)
            {

                Console.WriteLine($"Binding of UDP Server socket failed with error: {ex.SocketErrorCode} ");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("UDP Server started and waiting for Client messages.");


            while (true)
            {
                EndPoint clientAddress = new IPEndPoint(IPAddress.Any, 0);

                try
                {
                    int iResult = serverSocket.ReceiveFrom(dataBuffer,ref clientAddress);
                    string messageRecieved = Encoding.UTF8.GetString(dataBuffer);
                    messageRecieved = messageRecieved.Substring(0,iResult);
                    Console.WriteLine($"Client connected from IP: {(clientAddress as IPEndPoint).Address}, Port: {(clientAddress as IPEndPoint).Port} sent: {messageRecieved}");


                }
                catch(SocketException ex)
                {

                    Console.WriteLine($"Recieve from socket failed with error: {ex.SocketErrorCode} ");
                    Console.ReadKey();
                    continue;
                }
                serverSocket.Close();
                Console.WriteLine("UDP Server successfully shut down");
                Console.ReadKey();
            }

        }
    }
}
