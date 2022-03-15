using CartService.Infrastructure.Extensions.ExtensionModules.RabbitMqModule;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartService.Infrastructure.Persistance.Context
{
    public class RabbitMqContext
    {
        private readonly RabbitMqConfiguration _rabbitMqConfiguration;
        private readonly ConnectionFactory connectionFactory;        

        public RabbitMqContext(IOptions<RabbitMqConfiguration> rabbitMqConfiguration)
        {
            _rabbitMqConfiguration = rabbitMqConfiguration.Value;
            connectionFactory = new ConnectionFactory()
            {
                HostName = _rabbitMqConfiguration.HostName,
                UserName = _rabbitMqConfiguration.UserName,
                Password = _rabbitMqConfiguration.Password,
                VirtualHost = _rabbitMqConfiguration.VirtualHost,
                AutomaticRecoveryEnabled = _rabbitMqConfiguration.AutomaticRecoveryEnabled
            };

        }

        public  IModel AddRabbitMqConfiguration()
        {
            return connectionFactory.CreateConnection().CreateModel();
        }

    }
}
