using LoginService.Core.Domain.Common;
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
        Task<List<T>> GetListAsync();
        Task<T> GetWhereAsync(Expression<Func<T,bool>> expression);
        Task<T> GetWhereByIdAsync(T entity);
        Task<T> AddAsync(T entity);
        Task<T> AddListAsync(List<T> entities);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<T> DeleteListAsync(T entity);

    }
}
