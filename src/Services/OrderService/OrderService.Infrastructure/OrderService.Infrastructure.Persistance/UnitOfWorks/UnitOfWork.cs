using Microsoft.EntityFrameworkCore.Storage;
using OrderService.Core.Application.Interfaces.Repositories;
using OrderService.Core.Application.Interfaces.UnitOfWorks;
using OrderService.Infrastructure.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Infrastructure.Persistance.Repositories.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _appDbContext;


        public UnitOfWork(AppDbContext appDbContext, 
            IUserRepository userRepository,
            ICatalogBrandRepository catalogBrandRepository,
            ICatalogItemRepository catalogItemRepository,
            ICatalogTypeRepository catalogTypeRepository,
            ICustomerCartRepository customerCartRepository,
            IOrderItemRepository orderItemRepository)
        {
            _appDbContext = appDbContext;
            UserRepository = userRepository;
            CatalogBrandRepository = catalogBrandRepository;
            CatalogItemRepository = catalogItemRepository;
            CustomerCartRepository = customerCartRepository;
            OrderItemRepository = orderItemRepository;
            CatalogTypeRepository= catalogTypeRepository;
        }

        public IUserRepository UserRepository { get; }

        public ICatalogBrandRepository CatalogBrandRepository { get; }

        public ICatalogItemRepository CatalogItemRepository { get; }

        public ICatalogTypeRepository CatalogTypeRepository { get; }

        public ICustomerCartRepository CustomerCartRepository { get; }

        public IOrderItemRepository OrderItemRepository { get; }

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
