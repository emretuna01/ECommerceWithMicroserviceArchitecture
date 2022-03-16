using CartService.Core.Domain.Entities;
using CartService.Infrastructure.Persistance.Context;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CartService.Infrastructure.Persistance.Services
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

        public void SendMessage(CustomerCart customerCart,string exchange="direct_CustomerCart", string routingKey = "default")
        {
            _channel.ExchangeDeclare(exchange, type: ExchangeType.Direct);
            byte[] message = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(customerCart));


            IBasicProperties properties = _channel.CreateBasicProperties();
            properties.Persistent = true;

            _channel.BasicPublish(exchange: exchange, routingKey: routingKey, basicProperties: properties, body: message);
            
        }
    }
}
