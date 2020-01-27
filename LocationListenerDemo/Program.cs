using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace LocationListenerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            StartListener();
        }

        private static void StartListener()
        {
            bool done = false;

            UdpClient listener = new UdpClient(700);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, 700);

            try
            {
                Console.WriteLine("Broadcast veri bekleniyor");
                RabbitMqPublisher rabbitMqPublisher = new RabbitMqPublisher();

                while (!done)
                {
                    
                    byte[] bytes = listener.Receive(ref groupEP);

                     Console.WriteLine($"broadcast veri {groupEP.ToString()} : {Encoding.UTF8.GetString(bytes, 0, bytes.Length)} ");
                    rabbitMqPublisher.Queue(bytes);

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                listener.Close();
            }
        }
    }
}
