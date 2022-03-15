using CartService.Infrastructure.Persistance.Context;
using CartService.Infrastructure.Persistance.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartService.Infrastructure.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceService(this IServiceCollection services)
        {
            services.AddSingleton<RedisContext>();
            services.AddSingleton<RedisCacheService>();
        }
    }
}
