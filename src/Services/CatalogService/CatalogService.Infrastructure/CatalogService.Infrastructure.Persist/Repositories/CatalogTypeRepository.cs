using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogService.Core.Application.Interfaces.Repositories;
using CatalogService.Core.Domain.Entities;
using CatalogService.Infrastructure.Persist.Context;


namespace CatalogService.Infrastructure.Persist.Repositories
{
    public class CatalogTypeRepository : Repository<CatalogType>, ICatalogTypeRepository
    {
        public CatalogTypeRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
