namespace Kemet.ERP.Domain.IRepositories.App
{
    public interface IMemoryCacheRepository
    {
        T? Get<T>(string key);
        void Set<T>(string key, T value, TimeSpan expiration);
        void Remove(string key);
    }
}
