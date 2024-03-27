using Kemet.ERP.Contracts.Common;

namespace Kemet.ERP.Contracts.HR.Identity
{
    public class GetTokenDto : IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
