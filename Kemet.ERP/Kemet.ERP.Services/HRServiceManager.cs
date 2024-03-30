using Kemet.ERP.Abstraction;
using Kemet.ERP.Abstraction.Common;
using Kemet.ERP.Abstraction.HR.Common;
using Kemet.ERP.Abstraction.HR.Identity;
using Kemet.ERP.Domain.IRepositories;
using Kemet.ERP.Services.Common;
using Kemet.ERP.Services.HR.Common;
using Kemet.ERP.Services.HR.Identity;

namespace Kemet.ERP.Services
{
    public sealed class HRServiceManager : IHRServiceManager
    {
        // Entities
        private readonly Lazy<ICountryService> _lazyCountryService;
        private readonly Lazy<IRegionService> _lazyRegionService;
        private readonly Lazy<IAccountService> _lazyAccountService;
        private readonly Lazy<IAuthService> _lazyAuthService;



        // Shared
        private readonly Lazy<IRequestHandlingService> _lazyRequestHandlingService;
        private readonly Lazy<IMemoryCacheService> _lazyMemoryCacheService;

        public HRServiceManager(IHRRepositoryManager hrRepositoryManager)
        {
            // Entities
            _lazyCountryService = new Lazy<ICountryService>(() => new CountryService(hrRepositoryManager));
            _lazyRegionService = new Lazy<IRegionService>(() => new RegionService(hrRepositoryManager));
            _lazyAccountService = new Lazy<IAccountService>(() => new AccountService(hrRepositoryManager));
            _lazyAuthService = new Lazy<IAuthService>(() => new AuthService(hrRepositoryManager));



            // Shared
            _lazyRequestHandlingService = new Lazy<IRequestHandlingService>(() => new RequestHandlingService(hrRepositoryManager));
            _lazyMemoryCacheService = new Lazy<IMemoryCacheService>(() => new MemoryCacheService(hrRepositoryManager));
        }

        // Entities
        public ICountryService CountryService => _lazyCountryService.Value;
        public IRegionService RegionService => _lazyRegionService.Value;
        public IAccountService AccountService => _lazyAccountService.Value;
        public IAuthService AuthService => _lazyAuthService.Value;


        // Shared
        public IRequestHandlingService RequestHandlingService => _lazyRequestHandlingService.Value;
        public IMemoryCacheService MemoryCacheService => _lazyMemoryCacheService.Value;
    }
}
