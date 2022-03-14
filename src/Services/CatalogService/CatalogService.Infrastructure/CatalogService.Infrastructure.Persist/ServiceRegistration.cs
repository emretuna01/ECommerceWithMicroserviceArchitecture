using CatalogService.Core.Application.Interfaces.Repositories;
using CatalogService.Core.Application.Interfaces.UnitOfWorks;
using CatalogService.Infrastructure.Persist.Context;
using CatalogService.Infrastructure.Persist.Repositories;
using CatalogService.Infrastructure.Persist.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Infrastructure.Persist
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceService(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            //DbContext
            serviceCollection.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("PostgreSql")));

            //Repositories
            serviceCollection.AddScoped<ICatalogBrandRepository, CatalogBrandRepository>();
            serviceCollection.AddScoped<ICatalogItemRepository, CatalogItemRepository>();
            serviceCollection.AddScoped<ICatalogTypeRepository, CatalogTypeRepository>();

            //Unit Of Work
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

        }
    }
}
