using Kemet.ERP.Contracts.Shared;

namespace Kemet.ERP.Contracts.Identity
{
    public class RoleDto : IDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
