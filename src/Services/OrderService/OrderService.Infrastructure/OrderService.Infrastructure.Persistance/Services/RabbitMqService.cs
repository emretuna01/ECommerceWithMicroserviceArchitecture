using Microsoft.EntityFrameworkCore;
using OrderService.Core.Application.Interfaces.UnitOfWorks;
using OrderService.Core.Domain.Entities;
using OrderService.Infrastructure.Persistance.Context;
using OrderService.Infrastructure.Persistance.Repositories.UnitOfWorks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrderService.Infrastructure.Persistance.Services
{
    public class RabbitMqService
    {
        private readonly RabbitMqContext _rabbitMqContext;
        private readonly IModel _channel;
        private IUnitOfWork _unitOfWork;

        public RabbitMqService(RabbitMqContext rabbitMqContext, IUnitOfWork unitOfWork)
        {
            _rabbitMqContext = rabbitMqContext;
            _channel = _rabbitMqContext.Channel;
            _unitOfWork = unitOfWork;
        }

        public async Task RabbitMqListener(string exchange = "direct_CustomerCart", string routingKey = "default")
        {
            _channel.ExchangeDeclare(exchange, type: ExchangeType.Direct);
            string queueName = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queue: queueName, exchange: exchange, routingKey: routingKey);
            _channel.BasicQos(0, 1, false);

            EventingBasicConsumer consumer = new EventingBasicConsumer(_channel);
            _channel.BasicConsume(queueName, false, consumer);

            CustomerCart customerCart = null;
            consumer.Received += async (sender, e) =>
            {
                  _channel.BasicAck(e.DeliveryTag, false);
                  customerCart = JsonSerializer.Deserialize<CustomerCart>(Encoding.UTF8.GetString(e.Body.ToArray()));
                  await _unitOfWork.CustomerCartRepository.AddAsync(customerCart);
            };



        }
    }


}
