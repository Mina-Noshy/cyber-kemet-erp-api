using Kemet.ERP.Domain.IRepositories.Common;
using Kemet.ERP.Domain.IRepositories.Shared;
using Kemet.ERP.Persistence.Contexts;
using Kemet.ERP.Persistence.Repositories.Shared;
using Microsoft.Extensions.Caching.Memory;

namespace Kemet.ERP.Persistence.Repositories.Common
{
    public class CommonRepositoryManager : ICommonRepositoryManager
    {
        private readonly Lazy<ICountryMasterRepository> _lazyCountryMasterRepository;
        private readonly Lazy<IRegionMasterRepository> _lazyRegionMasterRepository;

        private readonly Lazy<IDapperRepository> _lazyDapperRepository;
        private readonly Lazy<IMemoryCacheRepository> _lazyMemoryCacheRepository;
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

        public CommonRepositoryManager(RepositoryDbContext dbContext, IMemoryCache memoryCache)
        {
            _lazyCountryMasterRepository = new Lazy<ICountryMasterRepository>(() => new CountryMasterRepository(dbContext));
            _lazyRegionMasterRepository = new Lazy<IRegionMasterRepository>(() => new RegionMasterRepository(dbContext));

            _lazyDapperRepository = new Lazy<IDapperRepository>(() => new DapperRepository(dbContext));
            _lazyMemoryCacheRepository = new Lazy<IMemoryCacheRepository>(() => new MemoryCacheRepository(memoryCache));
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
        }


        public ICountryMasterRepository CountryMasterRepository => _lazyCountryMasterRepository.Value;
        public IRegionMasterRepository RegionMasterRepository => _lazyRegionMasterRepository.Value;

        public IDapperRepository DapperRepository => _lazyDapperRepository.Value;
        public IMemoryCacheRepository MemoryCacheRepository => _lazyMemoryCacheRepository.Value;
        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;

    }
}
