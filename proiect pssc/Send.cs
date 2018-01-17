using Newtonsoft.Json;
using proiect_pssc.Evenimente;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_pssc
{
    public class Send
    {
        public void TrimiteMesaj(string mesaj)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "ParcAuto", durable: false, exclusive: false, autoDelete: false, arguments: null);

                string message = mesaj;
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "", routingKey: "ParcAuto", basicProperties: null, body: body);
           
            }
           
        }
    }
}
