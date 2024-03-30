using Kemet.ERP.Abstraction.Common;
using Kemet.ERP.Domain.IRepositories;
using Kemet.ERP.Shared.Constants;

namespace Kemet.ERP.Services.Common
{
    internal class MemoryCacheService : IMemoryCacheService
    {
        private readonly IHRRepositoryManager _repositoryManager;

        public MemoryCacheService(IHRRepositoryManager repositoryManager)
            => _repositoryManager = repositoryManager;


        public T? Get<T>(CacheServiceKeys key)
            => _repositoryManager.MemoryCacheRepository.Get<T>(key);

        public void Set<T>(CacheServiceKeys key, T value, TimeSpan expiration)
            => _repositoryManager.MemoryCacheRepository.Set(key, value, expiration);

        public void Remove(CacheServiceKeys key)
            => _repositoryManager.MemoryCacheRepository.Remove(key);
    }
}
