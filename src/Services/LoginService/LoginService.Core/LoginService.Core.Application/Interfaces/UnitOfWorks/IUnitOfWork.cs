using LoginService.Core.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginService.Core.Application.Interfaces.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        public IUserRepository UserRepository { get; }
        public Task<IDbContextTransaction> BeginTransactionAsync();
        public void CommitTransactionAsync();
        public void RollbackTransactionAsync();
        public void SaveTransactionAsync();

    }
}
