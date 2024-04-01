namespace Kemet.ERP.Domain.IRepositories.Shared
{
    public interface ISharedRepository
    {
        IDapperRepository DapperRepository { get; }
        IMemoryCacheRepository MemoryCacheRepository { get; }
        IUnitOfWork UnitOfWork { get; }
    }
}
