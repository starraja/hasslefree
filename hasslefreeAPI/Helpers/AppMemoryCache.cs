using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections;
using System.Collections.Generic;

namespace hasslefreeAPI.Helpers
{
    /// <summary>
    /// To manage the Cache object for the application
    /// </summary>
    public class AppMemoryCache : IAppMemoryCache
    {
        public static MemoryCache Cache { get; set; }
        /// <summary>
        /// Method to configure cache in memory
        /// </summary>
        private  void ConfigureMyMemoryCache()
        {
            if(Cache == null)
            { 
                Cache = new MemoryCache(new MemoryCacheOptions
                {
                    SizeLimit = 1024
                });
            }
        }
        /// <summary>
        /// Method to remove item from cache
        /// </summary>
        /// <param name="KeyName"></param>
        public void RemoveFromCache(string KeyName)
        {
            if(Cache != null) Cache.Remove(KeyName);
        }

        /// <summary>
        /// Method to add data to cache
        /// </summary>
        /// <param name="KeyName"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public object AddToCache(string KeyName, object obj)
        {
            object cacheEntry;
            if (Cache == null) ConfigureMyMemoryCache();
            if (!Cache.TryGetValue(KeyName, out cacheEntry))
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Set cache entry size by extension method.
                    .SetSize(1)
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(10));

                // Save data in cache.
                Cache.Set(KeyName, obj, cacheEntryOptions);
            }
            return cacheEntry;
        }
        /// <summary>
        /// Retrieve the data from Cache
        /// </summary>
        /// <param name="KeyName"></param>
        /// <returns></returns>
        public object GetItemFromCache(string KeyName)
        {
            object cacheEntry=null;
            if (Cache == null) return cacheEntry;
            if (Cache.TryGetValue(KeyName, out cacheEntry))
            {
                return cacheEntry;
            }
            else
                return cacheEntry;
        }
       
        /// <summary>
        /// Retrieve string data from cache
        /// </summary>
        /// <param name="KeyName"></param>
        /// <returns></returns>
        public string GetStringFromCache(string KeyName)
        {
            return (string)GetItemFromCache(KeyName);
        }
    }
}