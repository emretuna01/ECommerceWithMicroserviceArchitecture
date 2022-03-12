﻿using LoginService.Core.Application.Interfaces.Repositories;
using LoginService.Core.Domain.Common;
using LoginService.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LoginService.Infrastructure.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {        
        private DbSet<T> _entity;

        public Repository(AppDbContext appDbContext)
        {
            _entity = appDbContext.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _entity.AddAsync(entity);
        }

        public async Task AddListAsync(List<T> entities)
        {
            await _entity.AddRangeAsync(entities);
        }
        public void UpdateAsync(T entity)
        {
            _entity.Update(entity);
        }

        public void DeleteAsync(T entity)
        {
            _entity.Remove(entity);
        }

        public void DeleteListAsync(List<T> entities)
        {
            _entity.RemoveRange(entities);
        }

        public async Task<List<T>> GetListAsync()
        {
            return await _entity.ToListAsync();
        }

        public async Task<T> GetWhereAsync(Expression<Func<T, bool>> expression)
        {
            return await _entity.Where(expression).FirstOrDefaultAsync();
        }

        public async Task<T> GetWhereByIdAsync(T entity)
        {
            return await _entity.FindAsync(entity);
        }

        public async Task<List<T>> GetListWhereAsync(Expression<Func<T, bool>> expression)
        {
            return await _entity.Where(expression).ToListAsync();
        }
    }
}
