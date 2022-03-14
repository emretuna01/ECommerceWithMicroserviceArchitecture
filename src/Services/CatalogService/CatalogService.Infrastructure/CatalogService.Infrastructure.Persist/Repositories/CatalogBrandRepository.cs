using CatalogService.Core.Application.Interfaces.Repositories;
using CatalogService.Core.Domain.Entities;
using CatalogService.Infrastructure.Persist.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Infrastructure.Persist.Repositories
{
    public class CatalogBrandRepository : Repository<CatalogBrand>, ICatalogBrandRepository
    {
        public CatalogBrandRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
