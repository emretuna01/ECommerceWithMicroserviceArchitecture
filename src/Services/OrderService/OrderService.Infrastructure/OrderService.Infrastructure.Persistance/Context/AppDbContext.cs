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
                    Username = "admin",
                    Password = "admin"
                },
                new User()
                {
                    ObjectId = Guid.NewGuid(),
                    Email = "emretuna@outlook.com",
                    Firstname = "emre",
                    Username = "emre",
                    Password = "emre"

                }
                );

            modelBuilder.Entity<CatalogBrand>().HasData(
                new CatalogBrand() { Brand = "1.STATE", ObjectId = Guid.NewGuid() },
                new CatalogBrand() { Brand = "1017 ALYX 9SM", ObjectId = Guid.NewGuid() },
                new CatalogBrand() { Brand = "108 STITCHES", ObjectId = Guid.NewGuid() },
                new CatalogBrand() { Brand = "11 Honoré", ObjectId = Guid.NewGuid() },
                new CatalogBrand() { Brand = "111SKIN", ObjectId = Guid.NewGuid() },
                new CatalogBrand() { Brand = "1822 Denim", ObjectId = Guid.NewGuid() },
                new CatalogBrand() { Brand = "19 Cooper", ObjectId = Guid.NewGuid() },
                new CatalogBrand() { Brand = "1901", ObjectId = Guid.NewGuid() },
                new CatalogBrand() { Brand = "2 MONCLER 1952", ObjectId = Guid.NewGuid() }
                );

            modelBuilder.Entity<CatalogType>().HasData(
                new CatalogType() { ObjectId = Guid.NewGuid(), Type = "Automotive" },
                new CatalogType() { ObjectId = Guid.NewGuid(), Type = "Baby" },
                new CatalogType() { ObjectId = Guid.NewGuid(), Type = "Books" },
                new CatalogType() { ObjectId = Guid.NewGuid(), Type = "Computers" },
                new CatalogType() { ObjectId = Guid.NewGuid(), Type = "Electronics" },
                new CatalogType() { ObjectId = Guid.NewGuid(), Type = "Men's Fashion" }
                );

            modelBuilder.Entity<CatalogItem>().HasData(
                    new CatalogItem()
                    {
                        ObjectId = Guid.NewGuid(),
                        Description = "Books",
                        Name = "The Quarter Storm",
                        AvailableStock = 500
                    },
                    new CatalogItem()
                    {
                        ObjectId = Guid.NewGuid(),
                        Description = "Books",
                        Name = "A Train to Moscow",
                        AvailableStock = 1500
                    },
                    new CatalogItem()
                    {
                        ObjectId = Guid.NewGuid(),
                        Description = "Books",
                        Name = "Like Me",
                        AvailableStock = 2500
                    }, new CatalogItem()
                    {
                        ObjectId = Guid.NewGuid(),
                        Description = "Books",
                        Name = "North to Paradise",
                        AvailableStock = 5100
                    }, new CatalogItem()
                    {
                        ObjectId = Guid.NewGuid(),
                        Description = "Books",
                        Name = "The Fallen Stones",
                        AvailableStock = 499
                    }
                );


        }

    }
}
