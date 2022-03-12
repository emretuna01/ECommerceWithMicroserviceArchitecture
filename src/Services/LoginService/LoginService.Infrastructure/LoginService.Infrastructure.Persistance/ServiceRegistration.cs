using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginService.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace LoginService.Infrastructure.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceService(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("PostgreSql"));
        }
    }
}
