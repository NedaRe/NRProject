using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace UI.Messaging
{
    public class Receiver
    {
        private EventingBasicConsumer consumer;

        public Receiver()
        {
            var _factory = new ConnectionFactory();
            string message;
            _factory.HostName = Common.Host;
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

                    consumer.Received += (model, ea) =>
                    {
                         message = Encoding.UTF8.GetString(ea.Body);
                    };
                    channel.BasicConsume(queue: "SearchQueue",
                        autoAck: true,
                        consumer: consumer);
                System.Threading.Thread.Sleep(5000);
                }
            }



        }

        public object Test
        {
            get { return consumer; }
        }

        //public string Message
        //{
        //    get { return Recieve(); }
        //}
        //public async Task<string> Recieve()
        //{
        //    string message = null;

        //    var _factory = new ConnectionFactory();

        //    _factory.HostName = Common.Host;
        //    using (var connection = _factory.CreateConnection())
        //    {
        //        using (var channel = connection.CreateModel())
        //        {

        //            channel.QueueDeclare(
        //                queue: "SearchQueue",
        //                durable: true,
        //                exclusive: false,
        //                autoDelete: false,
        //                arguments: null
        //            );
        //            var consumr = new EventingBasicConsumer(channel);

        //            consumr.Received += (model, ea) =>
        //            {
        //                message = Encoding.UTF8.GetString(ea.Body);
        //             //   return await message;
        //            };
        //            channel.BasicConsume(queue: "SearchQueue",
        //                autoAck: true,
        //                consumer: consumr);

        //        }
        //    }

        //    return message;

        //}

    }
}
