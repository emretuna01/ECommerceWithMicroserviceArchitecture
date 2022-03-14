using CatalogService.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Core.Application.Interfaces.Context
{
    public interface IAppDbContext
    {
        DbSet<CatalogBrand> CatalogBrands { get; set; }
        DbSet<CatalogItem> CatalogItems { get; set; }
        DbSet<CatalogType> CatalogTypes { get; set; }
    }
}
