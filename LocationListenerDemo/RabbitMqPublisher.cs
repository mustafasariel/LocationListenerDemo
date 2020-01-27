using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocationListenerDemo
{
    class RabbitMqPublisher
    {
        ConnectionFactory factory;
        IConnection connection;
        IModel channel;
        public RabbitMqPublisher()
        {
            factory = new ConnectionFactory();
            //factory.Uri = new Uri("amqp://yelfgfvk:YeJbM5bbqm-4T0Q8GCLgv06TspxeHymi@jaguar.rmq.cloudamqp.com/yelfgfvk");

            factory.HostName = "localhost";
            connection = factory.CreateConnection();

             channel = connection.CreateModel();

            channel.QueueDeclare("hello", durable: false, false, false, null);

            var basicProperties = channel.CreateBasicProperties();
            basicProperties.Persistent = true; // Instance restart olsa bile mesaj silinmez

        }
        public void Queue(byte[] byteMessages)
        {
            try
            {


                channel.BasicPublish("", routingKey: "hello", null, byteMessages);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
            // var bodyByte = Encoding.UTF8.GetBytes(message)

        }
    }
}
