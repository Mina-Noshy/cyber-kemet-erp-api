using Kemet.ERP.Domain.Entities.Identity;
using Kemet.ERP.Domain.IRepositories.Identity;
using Kemet.ERP.Domain.IRepositories.Shared;
using Kemet.ERP.Persistence.Contexts;
using Kemet.ERP.Persistence.Repositories.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;

namespace Kemet.ERP.Persistence.Repositories.Identity
{
    public class IdentityRepositoryManager : IIdentityRepositoryManager
    {
        private readonly Lazy<IAuthRepository> _lazyAuthRepository;
        private readonly Lazy<IAccountRepository> _lazyAccountRepository;



        private readonly Lazy<IDapperRepository> _lazyDapperRepository;
        private readonly Lazy<IMemoryCacheRepository> _lazyMemoryCacheRepository;
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

        public IdentityRepositoryManager(RepositoryDbContext dbContext,
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IMemoryCache memoryCache)
        {
            _lazyAuthRepository = new Lazy<IAuthRepository>(() => new AuthRepository(dbContext, userManager, roleManager));
            _lazyAccountRepository = new Lazy<IAccountRepository>(() => new AccountRepository(userManager));


            _lazyDapperRepository = new Lazy<IDapperRepository>(() => new DapperRepository(dbContext));
            _lazyMemoryCacheRepository = new Lazy<IMemoryCacheRepository>(() => new MemoryCacheRepository(memoryCache));
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));

        }

        public IAuthRepository AuthRepository => _lazyAuthRepository.Value;
        public IAccountRepository AccountRepository => _lazyAccountRepository.Value;

        public IDapperRepository DapperRepository => _lazyDapperRepository.Value;
        public IMemoryCacheRepository MemoryCacheRepository => _lazyMemoryCacheRepository.Value;
        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;

    }
}
