using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginService.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using LoginService.Core.Application.Interfaces.UnitOfWorks;
using LoginService.Infrastructure.Persistance.UnitOfWorks;
using LoginService.Infrastructure.Persistance.Repositories;
using LoginService.Core.Application.Interfaces.Repositories;

namespace LoginService.Infrastructure.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceService(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            //DbContext
            serviceCollection.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("PostgreSql")));

            //Repositories
            serviceCollection.AddScoped<IUserRepository, UserRepository>();

            //Unit Of Work
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
