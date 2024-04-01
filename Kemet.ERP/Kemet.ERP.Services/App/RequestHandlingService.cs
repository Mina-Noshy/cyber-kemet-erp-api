using Kemet.ERP.Abstraction.App;
using Kemet.ERP.Domain.IRepositories.App;

namespace Kemet.ERP.Services.App
{
    internal class RequestHandlingService : IRequestHandlingService
    {
        private readonly IAppRepositoryManager _repositoryManager;

        public RequestHandlingService(IAppRepositoryManager repositoryManager)
            => _repositoryManager = repositoryManager;

        public string GetDbName()
            => _repositoryManager.RequestHandlingRepository.GetDbName();

        public string GetLang()
            => _repositoryManager.RequestHandlingRepository.GetLang();

        public string GetUserId()
            => _repositoryManager.RequestHandlingRepository.GetUserId();

        public string GetUserIP()
            => _repositoryManager.RequestHandlingRepository.GetUserIP();

    }
}
