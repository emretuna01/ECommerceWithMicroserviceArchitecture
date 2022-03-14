using CatalogService.Core.Application.Interfaces.Repositories;
using CatalogService.Core.Application.Interfaces.UnitOfWorks;
using CatalogService.Infrastructure.Persist.Context;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Infrastructure.Persist.UnitOfWorks
{
 public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _appDbContext;


        public UnitOfWork(AppDbContext appDbContext, 
            ICatalogBrandRepository catalogBrandRepository, 
            ICatalogItemRepository catalogItemRepository, 
            ICatalogTypeRepository catalogTypeRepository)
        {
            _appDbContext = appDbContext;
            CatalogBrandRepository=catalogBrandRepository;
            CatalogItemRepository=catalogItemRepository;
            CatalogTypeRepository=catalogTypeRepository;
        }       

        public ICatalogBrandRepository CatalogBrandRepository { get; }

        public ICatalogItemRepository CatalogItemRepository { get; }

        public ICatalogTypeRepository CatalogTypeRepository { get; }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _appDbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await _appDbContext.Database.CommitTransactionAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            await _appDbContext.Database.RollbackTransactionAsync();
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }

    }
}
