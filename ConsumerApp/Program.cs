using DAL;
using ParserApp;
using System;
using System.Threading;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using CoreApp;

namespace ConsumerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionFactory connecfactory = new ConnectionFactory();
            ParserLocation parserLocation = new ParserLocation();
            DataAccesLayer dataAccesLayer = new DataAccesLayer();


            connecfactory.HostName = "localhost";
            using (var connection = connecfactory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("hello", durable: false, false, false, null);

                    channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);
                    // mesaj 1 tane gelsin doğru işlenirse 1 tane daha gönder
                    // diğer insantaların aldığınıda hesaba katmak için global=true yapılır. ama benim tercihim false yönünde
                    Console.WriteLine("Mesajları bekliyoum");


                    var consumer = new EventingBasicConsumer(channel);

                    channel.BasicConsume("hello", autoAck: false, consumer);// autoAck:false, silinmemesi için false yapmak gerekir.

                    consumer.Received += (model, e) =>
                    {
                        // int time = Convert.ToInt32(GetMessage(args));
                        // int time = 200;
                        //Thread.Sleep(1000);

                        var result = parserLocation.GetParser(e.Body);

                 
                        dataAccesLayer.Add((Location)result);


                        channel.BasicAck(deliveryTag: e.DeliveryTag, multiple: false);
                        // mesaj başarıyla işledim kuyruktan silebilirsin anlamına geliyor.

                    };
                    Console.WriteLine("Çıkmak için tıklayınız");
                    Console.ReadLine();


                }
            }





        }



    }
}
