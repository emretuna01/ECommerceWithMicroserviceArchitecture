using LoginService.Core.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LoginService.Core.Application.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        //read
        Task<List<T>> GetListAsync();
        Task<T> GetWhereByIdAsync(T entity);
        Task<T> GetWhereAsync(Expression<Func<T, bool>> expression);
        Task<List<T>> GetListWhereAsync(Expression<Func<T, bool>> expression);

        //others
        Task<EntityState> AddAsync(T entity);
        Task AddListAsync(List<T> entities);
        void UpdateAsync(T entity);
        void DeleteAsync(T entity);
        void DeleteListAsync(List<T> entity);

    }
}
