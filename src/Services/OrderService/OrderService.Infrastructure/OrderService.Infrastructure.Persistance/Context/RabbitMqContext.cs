using Microsoft.Extensions.Options;
using OrderService.Infrastructure.Extensions.ExtensionModules.RabbitMqModule;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Infrastructure.Persistance.Context
{
    public class RabbitMqContext
    {

        private readonly RabbitMqConfiguration _rabbitMqConfiguration;
        private readonly ConnectionFactory connectionFactory;

        private readonly IConnection _connection;
        public IModel Channel { get; set; }


        public RabbitMqContext(IOptions<RabbitMqConfiguration> rabbitMqConfiguration)
        {
            _rabbitMqConfiguration = rabbitMqConfiguration.Value;
            connectionFactory = new ConnectionFactory()
            {
                HostName = _rabbitMqConfiguration.Host,
                UserName = _rabbitMqConfiguration.UserName,
                Password = _rabbitMqConfiguration.Password,
                VirtualHost = _rabbitMqConfiguration.VirtualHost,
                AutomaticRecoveryEnabled = _rabbitMqConfiguration.AutomaticRecoveryEnabled
            };
            _connection = connectionFactory.CreateConnection();
            Channel = _connection.CreateModel();

        }
    }
}
