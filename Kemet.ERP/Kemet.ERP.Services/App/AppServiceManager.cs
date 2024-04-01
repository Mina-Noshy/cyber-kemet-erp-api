using Kemet.ERP.Abstraction.App;
using Kemet.ERP.Domain.IRepositories.App;

namespace Kemet.ERP.Services.App
{
    public class AppServiceManager : IAppServiceManager
    {
        private readonly Lazy<IRequestHandlingService> _lazyRequestHandlingService;

        public AppServiceManager(IAppRepositoryManager repositoryManager)
        {
            _lazyRequestHandlingService = new Lazy<IRequestHandlingService>(() => new RequestHandlingService(repositoryManager));
        }

        public IRequestHandlingService RequestHandlingService => _lazyRequestHandlingService.Value;
    }
}
