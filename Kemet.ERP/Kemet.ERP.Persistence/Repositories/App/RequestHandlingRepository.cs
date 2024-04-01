using Kemet.ERP.Domain.IRepositories.App;
using Kemet.ERP.Shared.Constants;
using Microsoft.AspNetCore.Http;

namespace Kemet.ERP.Persistence.Repositories.App
{
    internal class RequestHandlingRepository : IRequestHandlingRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RequestHandlingRepository(IHttpContextAccessor httpContextAccessor)
            => _httpContextAccessor = httpContextAccessor;

        public string GetDbName()
            => _httpContextAccessor.HttpContext.Items[HttpContextKeys.DB].ToString() ?? string.Empty;

        public string GetLang()
            => _httpContextAccessor.HttpContext.Items[HttpContextKeys.LANG].ToString() ?? string.Empty;

        public string GetUserId()
            => _httpContextAccessor.HttpContext.Items[HttpContextKeys.USER_ID].ToString() ?? string.Empty;

        public string GetUserIP()
            => _httpContextAccessor.HttpContext.Items[HttpContextKeys.USER_IP].ToString() ?? string.Empty;

    }
}
