using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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

        public IList<RedisKey> GetAllKeys(string pattenstring)
        {
            var keys = this.redisConnections.GetServer("localhost", 6379).Keys(pattern: pattenstring);
            return keys.ToList();
        }

        public IList<EndPoint> GetEndPoints()
        {
            return this.redisConnections.GetEndPoints().ToList();
        }

        public void DeleteKey(string key)
        {
            IDatabase db = this.redisConnections.GetDatabase();
            var redisObject = db.StringGet(key);
            if (redisObject.HasValue)
                db.KeyDelete(key);
        }
    }
}
