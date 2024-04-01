using Kemet.ERP.Abstraction.Shared;

namespace Kemet.ERP.Abstraction.Common
{
    public interface ICommonServiceManager : ISharedService
    {
        ICountryMasterService CountryMasterService { get; }
        IRegionMasterService RegionMasterService { get; }
    }
}
