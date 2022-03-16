using OrderService.Infrastructure.Persistance.Context;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Infrastructure.Persistance.Services
{
    public class RabbitMqService
    {
        private readonly RabbitMqContext _rabbitMqContext;
        private readonly IModel _channel;
        public RabbitMqService(RabbitMqContext rabbitMqContext)
        {
            _rabbitMqContext = rabbitMqContext;
            _channel = _rabbitMqContext.Channel;
        }

        public void RabbitMqListener(string exchange = "direct_CustomerCart", string routingKey = "default")
        {
            _channel.ExchangeDeclare(exchange, type: ExchangeType.Direct);
            string queueName = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queue: queueName, exchange: exchange, routingKey: routingKey);
            _channel.BasicQos(0, 1, false);

            EventingBasicConsumer consumer = new EventingBasicConsumer(_channel);
            _channel.BasicConsume(queueName, false, consumer);


            consumer.Received += (sender, e) =>
            {
                _channel.BasicAck(e.DeliveryTag, false);
            };


        }
    }
}
