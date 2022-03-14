using CatalogService.Core.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Core.Application.Interfaces.UnitOfWorks
{
    public interface IUnitOfWork 
    {
        public ICatalogBrandRepository CatalogBrandRepository { get; }
        public ICatalogItemRepository CatalogItemRepository { get; }
        public ICatalogTypeRepository CatalogTypeRepository { get; }
        public Task<IDbContextTransaction> BeginTransactionAsync();
        public Task CommitTransactionAsync();
        public Task RollbackTransactionAsync();
        public Task<int> SaveChangesAsync();


    }
}
