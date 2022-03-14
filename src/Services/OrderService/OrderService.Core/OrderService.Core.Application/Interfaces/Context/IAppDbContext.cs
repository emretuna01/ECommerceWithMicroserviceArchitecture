using Microsoft.EntityFrameworkCore;
using OrderService.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Core.Application.Interfaces.Context
{
    public interface IAppDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<CatalogBrand> CatalogBrands { get; set; }
        DbSet<CatalogItem> CatalogItems { get; set; }
        DbSet<CatalogType> CatalogTypes { get; set; }
        DbSet<CustomerCart> CustomerCarts { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }        
    }
}
