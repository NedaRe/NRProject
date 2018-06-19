using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace SearchEngine
{
    class Program
    {
        static void Main(string[] args)
        {
           EventingBasicConsumer consumer;
           var _factory = new ConnectionFactory();

            _factory.HostName = "localhost";
            using (var connection = _factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {

                    channel.QueueDeclare(
                        queue: "SearchQueue",
                        durable: true,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null
                    );
                    consumer = new EventingBasicConsumer(channel);

                    consumer.Received += SendResponse;

                    channel.BasicConsume(queue: "SearchQueue",
                        autoAck: true,
                        consumer: consumer);
                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();

                }
            }

        }

        static void SendResponse(object sender, BasicDeliverEventArgs ea)
        {
            var factory = new ConnectionFactory();
            factory.HostName ="localhost";

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(
                        queue: "ResultQ",
                        durable: true,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null
                    );
                    var message = Encoding.UTF8.GetString(ea.Body);
                    var body = Encoding.UTF8.GetBytes("rseult" + message);
                    // read from database
                    channel.BasicPublish(exchange: "",
                        routingKey: "ResultQ",
                        body: body,
                        basicProperties: null);

                }
            }

        }
    }
}
