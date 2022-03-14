using Microsoft.EntityFrameworkCore;
using OrderService.Core.Application.Interfaces.Context;
using OrderService.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Infrastructure.Persistance.Context
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<CatalogBrand> CatalogBrands { get; set; }
        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }
        public DbSet<CustomerCart> CustomerCarts { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    ObjectId = Guid.NewGuid(),
                    Email = "admin@outlook.com",
                    Firstname = "admin",
                    Password = "admin"
                },
                new User()
                {
                    ObjectId = Guid.NewGuid(),
                    Email = "emretuna@outlook.com",
                    Firstname = "emre",
                    Password = "emre"

                }
                );
        }

    }
}
