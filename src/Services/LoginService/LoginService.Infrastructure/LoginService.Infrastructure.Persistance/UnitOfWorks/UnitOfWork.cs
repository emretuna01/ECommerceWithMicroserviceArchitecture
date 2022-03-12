using LoginService.Core.Application.Interfaces.Repositories;
using LoginService.Core.Application.Interfaces.UnitOfWorks;
using LoginService.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginService.Infrastructure.Persistance.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _appDbContext;


        public UnitOfWork(AppDbContext appDbContext, IUserRepository userRepository)
        {
            _appDbContext = appDbContext;
            UserRepository = userRepository;
        }

        public IUserRepository UserRepository { get; }

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

    }
}
