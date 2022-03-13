using CartService.Core.Domain.Entities;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CartService.Infrastructure.Extensions.ExtensionModules.RabbitMqModule
{
    public class RabbitMqBaseModule
    {

        private readonly IConnection _connection;
        private readonly IModel _channel;


        //public RabbitMqBaseModule(IConfiguration configuration)
        public RabbitMqBaseModule()
        {
            ConnectionFactory connectionFactory= new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
                VirtualHost = "/",
                AutomaticRecoveryEnabled = true                
            }; 
            //connectionFactory.Uri = new Uri(configuration["RabbitMqConfiguration:ConnectionString"]);
            //connectionFactory.Uri = new Uri("localhost");
            _connection =connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public void SendMessage(CustomerCart customerCart)
        {
            _channel.ExchangeDeclare("direct_CustomerCart", type: ExchangeType.Direct);
            byte[] message=Encoding.UTF8.GetBytes(JsonSerializer.Serialize(customerCart));


            IBasicProperties properties = _channel.CreateBasicProperties();
            properties.Persistent = true;

            _channel.BasicPublish(exchange: "direct_CustomerCart", routingKey: "default", basicProperties: properties, body: message);


        }
    }
}
