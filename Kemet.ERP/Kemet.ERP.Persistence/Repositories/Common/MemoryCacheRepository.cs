using Kemet.ERP.Domain.IRepositories.Common;
using Kemet.ERP.Shared.Constants;
using Microsoft.Extensions.Caching.Memory;

namespace Kemet.ERP.Persistence.Repositories.Common
{
    internal class MemoryCacheRepository : IMemoryCacheRepository
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCacheRepository(IMemoryCache memoryCache)
            => _memoryCache = memoryCache;


        public T? Get<T>(CacheServiceKeys key)
            => _memoryCache.Get<T>(key.ToString());

        public void Set<T>(CacheServiceKeys key, T value, TimeSpan expiration)
            => _memoryCache.Set(key.ToString(), value, expiration);

        public void Remove(CacheServiceKeys key)
            => _memoryCache.Remove(key.ToString());
    }
}
