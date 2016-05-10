using CoffeeStore.Domain.Cache;
using CoffeeStore.Models;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CoffeeStore.Controllers.api
{
    public class ShppingCartRedisController : ApiController
    {
        private ICache redisCache;

        public ShppingCartRedisController(ICache redisCache)
        {
            this.redisCache = redisCache;
        }

        [HttpPost]
        public void PostShppingCartRedis(UserDTO user)
        {
            if (user.userName != null)
            {
                redisCache.Set<UserDTO>(user.userName, user);
            }
        }

        [HttpGet]
        public UserDTO GetShppingCartRedis(string username)
        {
            IList<string> lists = GetAllKeys();
            if (lists.ToList().Exists(x => x.Equals(username)))
            {
                UserDTO user = redisCache.Get<UserDTO>(username);
                return user;
            }
            return null;

        }

        [HttpGet]
        public IList<string> GetAllKeys()
        {
            IList<RedisKey> lists = redisCache.GetAllKeys("*");
            IList<string> result = new List<string>();
            lists.ToList().ForEach(x =>
            {
                result.Add(x.ToString());
            });
            return result;
        }

    }
}
