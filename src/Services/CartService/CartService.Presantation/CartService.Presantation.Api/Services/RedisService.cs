using StackExchange.Redis;

namespace CartService.Presantation.Api.Services
{
    public class RedisService
    {
        private ConnectionMultiplexer _connectionMultiplexer;

        public RedisService(ConnectionMultiplexer connectionMultiplexer)
        {          
            _connectionMultiplexer = connectionMultiplexer;
        }

        public IDatabase GetDb(int db = 1) => _connectionMultiplexer.GetDatabase(db);
    }
}
