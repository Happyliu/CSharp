using Newtonsoft.Json;
using StackExchange.Redis;

namespace CoffeeStore.Domain.Cache
{
    public class RedisCache : ICache
    {
        private readonly ConnectionMultiplexer redisConnections;

        public RedisCache()
        {
            this.redisConnections = ConnectionMultiplexer.Connect("localhost");
        }

        public void Set<T>(string key, T objectToCache) where T : class
        {
            IDatabase db = this.redisConnections.GetDatabase();
            db.StringSet(key, JsonConvert.SerializeObject(objectToCache));
        }

        public T Get<T>(string key) where T : class
        {
            IDatabase db = this.redisConnections.GetDatabase();
            var redisObject = db.StringGet(key);
            if (redisObject.HasValue)
            {
                return JsonConvert.DeserializeObject<T>(redisObject);
            }
            else
            {
                return (T)null;
            }
        }
    }
}
