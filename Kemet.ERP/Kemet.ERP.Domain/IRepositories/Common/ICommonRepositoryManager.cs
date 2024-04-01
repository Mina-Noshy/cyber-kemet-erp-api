using Kemet.ERP.Domain.IRepositories.Shared;

namespace Kemet.ERP.Domain.IRepositories.Common
{
    public interface ICommonRepositoryManager : ISharedRepository
    {
        ICountryMasterRepository CountryMasterRepository { get; }
        IRegionMasterRepository RegionMasterRepository { get; }
    }
}
