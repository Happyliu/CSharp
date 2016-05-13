using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.Domain.Cache
{
    public interface ICache
    {
        void Set<T>(string key, T ObjectToCache) where T : class;
        T Get<T>(string key) where T : class;
        IList<RedisKey> GetAllKeys(string patten);
        IList<EndPoint> GetEndPoints();
        void DeleteKey(string key);
    }
}
