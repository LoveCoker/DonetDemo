using System;
using DotNet.Infrastructure.Interface;
using Microsoft.Extensions.Caching.Memory;

namespace DotNet.Infrastructure.Helper.Cache
{
    public class HttpRuntimeCachedWriter : ICacheWriter
    {
        private readonly IMemoryCache _cache;

        public HttpRuntimeCachedWriter(IMemoryCache cache)
        {
            _cache = cache;
        }
        public void Set(string key, object value, System.DateTime exp)
        {
            if (_cache.Get(key) != null)
            {
                _cache.Remove(key);
            }
            _cache.Set(key, value, TimeSpan.Zero);
        }

        public void Set(string key, object value)
        {
            if (_cache.Get(key) != null)
            {
                _cache.Remove(key);
            }
            _cache.Set(key, value, DateTime.Now.AddMinutes(20));
        }

        public object Get(string key)
        {
            return _cache.Get(key);
        }
        
        public void Remove(string key)
        {
            _cache.Remove(key);
        }
    }

}