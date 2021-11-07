using System;
using System.Runtime.Caching;

namespace CGeers.Core.NCache
{
    public class CacheProvider : ICacheProvider
    {
        private static Alachisoft.NCache.ObjectCacheProvider.CacheProvider _cache;

        private static Alachisoft.NCache.ObjectCacheProvider.CacheProvider GetCache()
        {
            if (_cache != null) return _cache;

            _cache = new Alachisoft.NCache.ObjectCacheProvider.CacheProvider("default");

            return _cache;
        }

        public void Add(string key, object value)
        {
            var cache = GetCache();
            var policy = new CacheItemPolicy();
            cache.Add(key, value, policy);
        }

        public void Add(string key, object value, TimeSpan timeout)
        {
            var cache = GetCache();
            cache.Add(key, value, DateTime.Now.Add(timeout));
        }

        public object Get(string key)
        {
            var cache = GetCache();
            return cache.Get(key);
        }

        public object this[string key]
        {
            get
            {
                var cache = GetCache();
                return cache[key];
            }
            set
            {
                var cache = GetCache();
                cache[key] = value;
            }
        }

        public bool Remove(string key)
        {
            var cache = GetCache();
            return cache.Remove(key) != null;
        }
    }
}
