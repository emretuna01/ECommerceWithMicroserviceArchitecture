using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartService.Infrastructure.Extensions.ExtensionModules
{
    public static class RedisRegistration
    {
        public static ConnectionMultiplexer AddRedisConfiguration(this IServiceProvider serviceCollection,IConfiguration configuration)
        {
            ConfigurationOptions redisConfigure = ConfigurationOptions.Parse(configuration["RedisConfiguration:ConnectionString"],true);
            redisConfigure.ResolveDns = true;

            return ConnectionMultiplexer.Connect(redisConfigure);

        }
    }
}
