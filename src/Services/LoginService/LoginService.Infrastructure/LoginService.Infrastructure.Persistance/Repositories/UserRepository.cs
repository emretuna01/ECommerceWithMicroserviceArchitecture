using LoginService.Core.Application.Interfaces.Repositories;
using LoginService.Core.Domain.Entities;
using LoginService.Infrastructure.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LoginService.Infrastructure.Persistance.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
     
    }
}
