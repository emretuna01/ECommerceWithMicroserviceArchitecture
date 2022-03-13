using CartService.Infrastructure.Extensions.ExtensionModules.RabbitMqModule;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartService.Infrastructure.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddCartServiceExtensions(this IServiceCollection services)
        {
            services.AddSingleton<RabbitMqBaseModule>();
        }
    }
}
