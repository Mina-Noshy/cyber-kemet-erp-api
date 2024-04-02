using Kemet.ERP.Abstraction.App;
using Kemet.ERP.Domain.IRepositories.App;

namespace Kemet.ERP.Services.App
{
    public class RequestHandlingService : IRequestHandlingService
    {
        private readonly IRequestHandlingRepository _repository;

        public RequestHandlingService(IRequestHandlingRepository repository)
            => _repository = repository;

        public string GetDbName()
            => _repository.GetDbName();

        public string GetLang()
            => _repository.GetLang();

        public string GetUserId()
            => _repository.GetUserId();

        public string GetUserIP()
            => _repository.GetUserIP();

    }
}
