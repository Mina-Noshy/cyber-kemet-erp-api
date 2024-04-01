using Kemet.ERP.Abstraction.Shared;
using Kemet.ERP.Domain.IRepositories.Shared;
using Kemet.ERP.Shared.Constants;

namespace Kemet.ERP.Services.Shared
{
    internal class MemoryCacheService : IMemoryCacheService
    {
        private readonly ISharedRepository _repositoryManager;

        public MemoryCacheService(ISharedRepository repositoryManager)
            => _repositoryManager = repositoryManager;


        public T? Get<T>(CacheServiceKeys key)
            => _repositoryManager.MemoryCacheRepository.Get<T>(key);

        public void Set<T>(CacheServiceKeys key, T value, TimeSpan expiration)
            => _repositoryManager.MemoryCacheRepository.Set(key, value, expiration);

        public void Remove(CacheServiceKeys key)
            => _repositoryManager.MemoryCacheRepository.Remove(key);
    }
}
