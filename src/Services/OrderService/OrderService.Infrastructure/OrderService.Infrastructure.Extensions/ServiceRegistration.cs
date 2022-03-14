using Microsoft.Extensions.DependencyInjection;
using OrderService.Infrastructure.Extensions.ExtensionModules.RabbitMqModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Infrastructure.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddOrderServiceExtensions(this IServiceCollection services)
        {
            services.AddSingleton<RabbitMqConsumerModule>();
        }
    }
}
