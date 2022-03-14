using OrderService.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Core.Application.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
    }
}
