using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace TeltonikaSender
{
    class Program
    {
        public static int Port = 700;

        static void Main(string[] args)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            byte[] sendbuf = Encoding.UTF8.GetBytes("Merhaba");
            IPEndPoint ep = new IPEndPoint(IPAddress.Broadcast, Port);

            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);

            int sayac = 0;
            while (true)
            {
                sayac++;
                sendbuf = Encoding.UTF8.GetBytes(sayac.ToString());
                socket.SendTo(sendbuf, ep);
                //Thread.Sleep(200);
               // Console.WriteLine($"sayac:{sayac}");
            }


            _ = Console.ReadLine();
        }
    }
}
