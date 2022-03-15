using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartService.Infrastructure.Persistance.Context
{
    public class RedisContext
    {
        private ConnectionMultiplexer _connectionMultiplexer;

        public RedisContext(ConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }

        public IDatabase GetDb(int db = 1) => _connectionMultiplexer.GetDatabase(db);
    }
}
