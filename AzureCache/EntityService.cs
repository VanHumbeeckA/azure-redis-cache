using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace AzureCache
{
    public class EntityService
    {
        private readonly LocalStore _localStore;
        private readonly IDatabase _cache;

        public EntityService()
        {
            var connectionString = Environment.GetEnvironmentVariable("REDIS_CACHE", EnvironmentVariableTarget.User);
            var cm = ConnectionMultiplexer.Connect(connectionString);
            _cache = cm.GetDatabase();
            _localStore = LocalStore.GetInstance();
        }


        public async Task<IEntity> GetMyEntityAsync(int id)
        {
            var key = string.Format("StoreWithCache_GetAsync_{0}", id);
            TimeSpan expiration = TimeSpan.FromMinutes(3);
            bool cacheException = false;

            try
            {
                //var cacheItem = cache.GetCacheItem(key);
                RedisValue cacheItem = await _cache.StringGetAsync(key);
                if (cacheItem.HasValue)
                {
                    Console.WriteLine("cache hit! for item with id " + id);
                    // TODO: implement wrapper class for IEntity interface instead of using MyEntity
                    // http://stackoverflow.com/questions/5780888/casting-interfaces-for-deserialization-in-json-net
                    IEntity e = JsonConvert.DeserializeObject<MyEntity>(cacheItem);
                    return e;
                }
            }
            catch (RedisException e)
            {
                Console.WriteLine("Data Cache Exception: ");
                Console.WriteLine(e);
                cacheException = true;
            }

            IEntity entity = _localStore.GetById(id); // await if async
            if (!cacheException)
            {
                try
                {
                    if (entity != null)
                    {
                        Console.WriteLine("writing to cache..");
                        _cache.StringSet(key, JsonConvert.SerializeObject(entity), expiry: expiration);
                    }
                }
                catch (RedisException)
                {
                }
            }

            return entity;
        }
    }
}
