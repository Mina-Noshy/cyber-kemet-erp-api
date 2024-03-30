using Kemet.ERP.Abstraction.Common;
using Kemet.ERP.Domain.IRepositories;

namespace Kemet.ERP.Services.Common
{
    internal class RequestHandlingService : IRequestHandlingService
    {
        private readonly IHRRepositoryManager _repositoryManager;

        public RequestHandlingService(IHRRepositoryManager repositoryManager)
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
