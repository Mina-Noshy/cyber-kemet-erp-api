using Kemet.ERP.Contracts.Shared;

namespace Kemet.ERP.Contracts.Identity
{
    public class UserToRoleDto : IDto
    {
        public string UserId { get; set; }
        public string Role { get; set; }
    }
}
