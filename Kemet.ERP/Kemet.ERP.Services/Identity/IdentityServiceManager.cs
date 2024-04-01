using Kemet.ERP.Abstraction.Identity;
using Kemet.ERP.Abstraction.Shared;
using Kemet.ERP.Domain.IRepositories.Identity;
using Kemet.ERP.Services.Shared;

namespace Kemet.ERP.Services.Identity
{
    public class IdentityServiceManager : IIdentityServiceManager
    {
        private readonly Lazy<IAccountService> _lazyAccountService;
        private readonly Lazy<IAuthService> _lazyAuthService;
        private readonly Lazy<IMemoryCacheService> _lazyMemoryCacheService;

        public IdentityServiceManager(IIdentityRepositoryManager repositoryManager)
        {
            _lazyAccountService = new Lazy<IAccountService>(() => new AccountService(repositoryManager));
            _lazyAuthService = new Lazy<IAuthService>(() => new AuthService(repositoryManager));
            _lazyMemoryCacheService = new Lazy<IMemoryCacheService>(() => new MemoryCacheService(repositoryManager));
        }

        public IAccountService AccountService => _lazyAccountService.Value;
        public IAuthService AuthService => _lazyAuthService.Value;
        public IMemoryCacheService MemoryCacheService => _lazyMemoryCacheService.Value;

    }
}
