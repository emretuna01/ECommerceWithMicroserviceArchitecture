using LoginService.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginService.Core.Application.Interfaces.Context
{
    public interface IDbContext
    {
        DbSet<User> Users { get; set; }
    }
}
