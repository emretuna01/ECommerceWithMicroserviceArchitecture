using LoginService.Core.Application.Configurations;
using LoginService.Core.Application.Interfaces.Dtos;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LoginService.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
            serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());
            serviceCollection.AddScoped<TokenDto>();
        }
        public static void AddAplicationJwtConfigService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtConfiguration>(option => configuration.GetSection("JwtConfiguration").Bind(option));
        }
    }
}
