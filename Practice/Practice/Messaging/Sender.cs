using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ;
using RabbitMQ.Client;

namespace UI.Messaging
{
    public class Sender
    {
        public void Send(string query)
        {

            var factory = new ConnectionFactory();
            factory.HostName = Common.Host;

            using (var connection = factory.CreateConnection())
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

                    var body = Encoding.UTF8.GetBytes(query);
                    channel.BasicPublish(exchange: "", 
                        routingKey: "SearchQueue",
                        body: body,
                        basicProperties: null);

                }
            }

        }
    }
}
