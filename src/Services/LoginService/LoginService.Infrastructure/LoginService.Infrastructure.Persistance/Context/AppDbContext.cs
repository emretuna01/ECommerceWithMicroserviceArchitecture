using LoginService.Core.Application.Interfaces.Context;
using LoginService.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginService.Infrastructure.Persistance.Context
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
        public DbSet<User> Users { get; set; }

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
