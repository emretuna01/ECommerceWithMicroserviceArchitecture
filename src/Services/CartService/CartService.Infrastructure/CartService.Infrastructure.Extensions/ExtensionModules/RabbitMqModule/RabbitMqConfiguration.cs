using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartService.Infrastructure.Extensions.ExtensionModules.RabbitMqModule
{
    public class RabbitMqConfiguration
    {
        public string Host { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string VirtualHost { get; set; }
        public bool AutomaticRecoveryEnabled { get; set; }

    }
}
