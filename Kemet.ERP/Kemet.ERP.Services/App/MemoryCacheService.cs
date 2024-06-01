using Kemet.ERP.Abstraction.App;
using Kemet.ERP.Domain.IRepositories.App;

namespace Kemet.ERP.Services.App
{
    public class MemoryCacheService : IMemoryCacheService
    {
        private readonly IMemoryCacheRepository _repository;
        public MemoryCacheService(IMemoryCacheRepository repository)
            => _repository = repository;



        public T? Get<T>(string key)
            => _repository.Get<T>(key);

        public void Set<T>(string key, T value, TimeSpan expiration)
            => _repository.Set(key, value, expiration);

        public void Remove(string key)
            => _repository.Remove(key);
    }
}
