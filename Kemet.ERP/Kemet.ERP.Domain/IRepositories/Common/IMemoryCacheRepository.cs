using Kemet.ERP.Shared.Constants;

namespace Kemet.ERP.Domain.IRepositories.Common
{
    public interface IMemoryCacheRepository
    {
        T? Get<T>(CacheServiceKeys key);
        void Set<T>(CacheServiceKeys key, T value, TimeSpan expiration);
        void Remove(CacheServiceKeys key);
    }
}
