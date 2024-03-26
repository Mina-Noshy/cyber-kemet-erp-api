using Kemet.ERP.Domain.IRepositories.IEntity.HR;
using Kemet.ERP.Domain.IRepositories.IShared;

namespace Kemet.ERP.Domain.IRepositories
{
    public interface IHRRepositoryManager
    {
        // Entities
        ICountryRepository CountryRepository { get; }
        IRegionRepository RegionRepository { get; }
        IAuthRepository AuthRepository { get; }
        IAccountRepository AccountRepository { get; }


        // Shared
        IDapperRepository DapperRepository { get; }
        IRequestHandlingRepository RequestHandlingRepository { get; }
        IMemoryCacheRepository MemoryCacheRepository { get; }
        IUnitOfWork UnitOfWork { get; }
    }
}
