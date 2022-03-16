using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderService.Core.Application.Interfaces.Repositories;
using OrderService.Core.Application.Interfaces.UnitOfWorks;
using OrderService.Infrastructure.Persistance.Context;
using OrderService.Infrastructure.Persistance.Repositories;
using OrderService.Infrastructure.Persistance.Repositories.UnitOfWorks;
using OrderService.Infrastructure.Persistance.Services;

namespace OrderService.Infrastructure.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceService(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            //DbContext
            serviceCollection.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("PostgreSql")));

            //Repositories
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            serviceCollection.AddScoped<ICatalogBrandRepository, CatalogBrandRepository>();
            serviceCollection.AddScoped<ICatalogItemRepository, CatalogItemRepository>();
            serviceCollection.AddScoped<ICatalogTypeRepository, CatalogTypeRepository>();
            serviceCollection.AddScoped<ICustomerCartRepository, CustomerCartRepository>();
            serviceCollection.AddScoped<IOrderItemRepository, OrderItemRepository>();

            //Unit Of Work
            serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>();

            //RabbitMq
            serviceCollection.AddSingleton<RabbitMqContext>();
            serviceCollection.AddScoped<RabbitMqService>();
        }
    }
}
