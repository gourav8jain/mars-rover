using System;
using MarsRoverApp.WebApi.Implementation.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace MarsRoverApp.WebApi.Implementation.Caching
{
    public class RoverCaching : IRoverCaching
    {
        private readonly IMemoryCache _memoryCache;

        public RoverCaching(IMemoryCache memoryCache)
        {
            this._memoryCache = memoryCache;
        }

        public bool IsItemExists(object item)
        {
            return _memoryCache.TryGetValue(item, out object itemValue);
        }

        public void SetItem(object key, object value)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(30));

            _memoryCache.Set(key, value, cacheEntryOptions);
            _memoryCache.Get(key);
        }

        public object GetItem(object key)
        {
           return _memoryCache.Get(key);
        }

        public void Remove(object key)
        {
            _memoryCache.Remove(key);
        }
    }
}
