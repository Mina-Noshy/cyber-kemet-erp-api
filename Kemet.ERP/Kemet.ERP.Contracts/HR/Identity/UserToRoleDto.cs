using Kemet.ERP.Contracts.Common;

namespace Kemet.ERP.Contracts.HR.Identity
{
    public class UserToRoleDto : IDto
    {
        public string UserId { get; set; }
        public string Role { get; set; }
    }
}
