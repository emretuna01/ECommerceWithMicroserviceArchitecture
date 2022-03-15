using CartService.Core.Application.Interfaces.Enums;
using CartService.Core.Application.Interfaces.Services;
using CartService.Infrastructure.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CartService.Infrastructure.Persistance.Services
{
    public class RedisCacheService : ICacheService
    {
        private readonly RedisContext _redisContext;
        public RedisCacheService(RedisContext redisContext)
        {
            _redisContext = redisContext;
        }

        public async Task<T> Get<T>(string cacheKey,T value)
        {
            var isExist = await _redisContext.GetDb().StringGetAsync(cacheKey);

            if (!string.IsNullOrEmpty(isExist))
                return JsonSerializer.Deserialize<T>(isExist);
            
            return default(T);
        }

        public async Task<bool> Remove(string cacheKey)
        {
            return await _redisContext.GetDb().KeyDeleteAsync(cacheKey);
        }

        public async Task<bool> Set<T>(string cacheKey, T value)
        {
             return await _redisContext.GetDb().StringSetAsync(cacheKey, JsonSerializer.Serialize(value), TimeSpan.FromMinutes((int)RedisTtlTime.Minutes30));

        }
    }
}
