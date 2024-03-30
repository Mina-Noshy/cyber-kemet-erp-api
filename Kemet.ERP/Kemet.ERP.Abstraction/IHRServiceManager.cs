using Kemet.ERP.Abstraction.Common;
using Kemet.ERP.Abstraction.HR.Common;
using Kemet.ERP.Abstraction.HR.Identity;

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
