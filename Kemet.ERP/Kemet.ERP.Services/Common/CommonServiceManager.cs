using Kemet.ERP.Abstraction.Common;
using Kemet.ERP.Abstraction.Shared;
using Kemet.ERP.Domain.IRepositories.Common;
using Kemet.ERP.Services.Shared;

namespace Kemet.ERP.Services.Common
{
    public class CommonServiceManager : ICommonServiceManager
    {
        private readonly Lazy<ICountryMasterService> _lazyCountryMasterService;
        private readonly Lazy<IRegionMasterService> _lazyRegionMasterService;

        private readonly Lazy<IMemoryCacheService> _lazyMemoryCacheService;
        public CommonServiceManager(ICommonRepositoryManager repositoryManager)
        {
            _lazyCountryMasterService = new Lazy<ICountryMasterService>(() => new CountryMasterService(repositoryManager));
            _lazyRegionMasterService = new Lazy<IRegionMasterService>(() => new RegionMasterService(repositoryManager));

            _lazyMemoryCacheService = new Lazy<IMemoryCacheService>(() => new MemoryCacheService(repositoryManager));
        }

        public ICountryMasterService CountryMasterService => _lazyCountryMasterService.Value;
        public IRegionMasterService RegionMasterService => _lazyRegionMasterService.Value;

        public IMemoryCacheService MemoryCacheService => _lazyMemoryCacheService.Value;
    }
}
