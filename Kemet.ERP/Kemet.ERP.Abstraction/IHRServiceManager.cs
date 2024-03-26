using Kemet.ERP.Abstraction.IEntity.HR;
using Kemet.ERP.Abstraction.IShared;

namespace Kemet.ERP.Abstraction
{
    public interface IHRServiceManager
    {
        // Entities
        ICountryService CountryService { get; }
        IRegionService RegionService { get; }
        IAccountService AccountService { get; }
        IAuthService AuthService { get; }


        // Shared
        IRequestHandlingService RequestHandlingService { get; }
        IMemoryCacheService MemoryCacheService { get; }
    }
}
