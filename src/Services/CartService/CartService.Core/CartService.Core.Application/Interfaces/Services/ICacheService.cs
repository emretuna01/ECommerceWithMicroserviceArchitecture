using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartService.Core.Application.Interfaces.Services
{
    public interface ICacheService
    {
        public Task<T> Get<T>(string cacheKey, T value);
        public Task<bool> Set<T>(string cacheKey, T value);
        public Task<bool> Remove(string cacheKey);
    }
}
