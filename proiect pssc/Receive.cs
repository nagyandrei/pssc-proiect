
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace proiect_pssc
{
    public class Receive
    {
        public string PrimesteMesaj()
        {
            string message = "";
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "ParcAuto", durable: false, exclusive: false, autoDelete: false, arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                     message = Encoding.UTF8.GetString(body);
               
                };
                channel.BasicConsume(queue: "ParcAuto", autoAck: false, consumer: consumer);

            }
            return message;
        }
    }
}
