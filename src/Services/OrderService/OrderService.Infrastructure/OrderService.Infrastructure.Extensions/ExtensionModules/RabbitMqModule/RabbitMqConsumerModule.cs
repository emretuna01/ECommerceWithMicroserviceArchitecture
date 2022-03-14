using OrderService.Core.Domain.Entities;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrderService.Infrastructure.Extensions.ExtensionModules.RabbitMqModule
{
    public class RabbitMqConsumerModule
    {

        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMqConsumerModule()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
                VirtualHost = "/",
                AutomaticRecoveryEnabled = true
            };
            //connectionFactory.Uri = new Uri(configuration["RabbitMqConfiguration:ConnectionString"]);
            //connectionFactory.Uri = new Uri("localhost");
            _connection = connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public void RabbitMqListener()
        {
            _channel.ExchangeDeclare("direct_CustomerCart", type: ExchangeType.Direct);
            string queueName = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queue: queueName, exchange: "direct_CustomerCart", routingKey: "default");
            _channel.BasicQos(0, 1, false);

            EventingBasicConsumer consumer = new EventingBasicConsumer(_channel);
            _channel.BasicConsume(queueName,false, consumer);

            StringBuilder stringBuilder = new StringBuilder();
            consumer.Received += (sender, e) =>
            {
                stringBuilder = stringBuilder.Append(Encoding.UTF8.GetString(e.Body.ToArray()));
                Console.WriteLine(stringBuilder.ToString());
                _channel.BasicAck(e.DeliveryTag, false);
            };


        }
    }
}
