using LoginService.Core.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using OrderService.Core.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Core.Application.Interfaces.UnitOfWorks
{
    public interface IUnitOfWork 
    {
        public IUserRepository UserRepository { get; }
        public ICatalogBrandRepository CatalogBrandRepository { get; }
        public ICatalogItemRepository CatalogItemRepository { get; }
        public ICatalogTypeRepository CatalogTypeRepository { get; }
        public ICustomerCartRepository CustomerCartRepository { get; }
        public IOrderItemRepository OrderItemRepository { get; }
        public Task<IDbContextTransaction> BeginTransactionAsync();
        public Task CommitTransactionAsync();
        public Task RollbackTransactionAsync();
        public Task<int> SaveChangesAsync();


    }
}
