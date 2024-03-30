using Kemet.ERP.Domain.Entities.HR.Identity;
using Kemet.ERP.Domain.IRepositories;
using Kemet.ERP.Domain.IRepositories.Common;
using Kemet.ERP.Domain.IRepositories.HR.Common;
using Kemet.ERP.Domain.IRepositories.HR.Identity;
using Kemet.ERP.Persistence.Contexts;
using Kemet.ERP.Persistence.Repositories.Common;
using Kemet.ERP.Persistence.Repositories.HR.Common;
using Kemet.ERP.Persistence.Repositories.HR.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;

namespace Kemet.ERP.Persistence.Repositories
{
    public sealed class HRRepositoryManager : IHRRepositoryManager
    {
        // Entites
        private readonly Lazy<ICountryRepository> _lazyCountryRepository;
        private readonly Lazy<IRegionRepository> _lazyRegionRepository;
        private readonly Lazy<IAuthRepository> _lazyAuthRepository;
        private readonly Lazy<IAccountRepository> _lazyAccountRepository;



        // Shared
        private readonly Lazy<IDapperRepository> _lazyDapperRepository;
        private readonly Lazy<IRequestHandlingRepository> _lazyRequestHandlingRepository;
        private readonly Lazy<IMemoryCacheRepository> _lazyMemoryCacheRepository;
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

        public HRRepositoryManager(RepositoryDbContext dbContext,
            IHttpContextAccessor httpContextAccessor,
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IMemoryCache memoryCache)
        {
            // Entites
            _lazyCountryRepository = new Lazy<ICountryRepository>(() => new CountryRepository(dbContext));
            _lazyRegionRepository = new Lazy<IRegionRepository>(() => new RegionRepository(dbContext));
            _lazyAuthRepository = new Lazy<IAuthRepository>(() => new AuthRepository(dbContext, userManager, roleManager));
            _lazyAccountRepository = new Lazy<IAccountRepository>(() => new AccountRepository(userManager));



            // Shared
            _lazyDapperRepository = new Lazy<IDapperRepository>(() => new DapperRepository(dbContext));
            _lazyRequestHandlingRepository = new Lazy<IRequestHandlingRepository>(() => new RequestHandlingRepository(httpContextAccessor));
            _lazyMemoryCacheRepository = new Lazy<IMemoryCacheRepository>(() => new MemoryCacheRepository(memoryCache));
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
        }


        // Entites
        public ICountryRepository CountryRepository => _lazyCountryRepository.Value;
        public IRegionRepository RegionRepository => _lazyRegionRepository.Value;
        public IAuthRepository AuthRepository => _lazyAuthRepository.Value;
        public IAccountRepository AccountRepository => _lazyAccountRepository.Value;



        // Shared
        public IDapperRepository DapperRepository => _lazyDapperRepository.Value;
        public IRequestHandlingRepository RequestHandlingRepository => _lazyRequestHandlingRepository.Value;
        public IMemoryCacheRepository MemoryCacheRepository => _lazyMemoryCacheRepository.Value;
        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
    }
}
