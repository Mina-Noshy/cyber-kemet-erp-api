using Kemet.ERP.Contracts.Shared;

namespace Kemet.ERP.Contracts.Identity
{
    public class GetTokenDto : IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
