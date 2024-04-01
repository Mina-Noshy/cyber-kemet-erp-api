using Kemet.ERP.Domain.IRepositories.App;
using Microsoft.AspNetCore.Http;

namespace Kemet.ERP.Persistence.Repositories.App
{
    public class AppRepositoryManager : IAppRepositoryManager
    {
        private readonly Lazy<IRequestHandlingRepository> _lazyRequestHandlingRepository;

        public AppRepositoryManager(IHttpContextAccessor httpContextAccessor)
        {
            _lazyRequestHandlingRepository = new Lazy<IRequestHandlingRepository>(() => new RequestHandlingRepository(httpContextAccessor));
        }
        public IRequestHandlingRepository RequestHandlingRepository => _lazyRequestHandlingRepository.Value;

    }
}
