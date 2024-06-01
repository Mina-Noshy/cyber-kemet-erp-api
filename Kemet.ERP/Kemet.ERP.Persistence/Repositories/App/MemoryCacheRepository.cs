using Kemet.ERP.Domain.IRepositories.App;
using Microsoft.Extensions.Caching.Memory;

namespace Kemet.ERP.Persistence.Repositories.App
{
    public class MemoryCacheRepository : IMemoryCacheRepository
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCacheRepository(IMemoryCache memoryCache)
            => _memoryCache = memoryCache;

        public T? Get<T>(string key)
            => _memoryCache.Get<T>(key);

        public void Set<T>(string key, T value, TimeSpan expiration)
            => _memoryCache.Set(key, value, expiration);

        public void Remove(string key)
            => _memoryCache.Remove(key);
    }
}
