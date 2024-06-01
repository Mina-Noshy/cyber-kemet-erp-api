using Kemet.ERP.Contracts.Shared;

namespace Kemet.ERP.Contracts.Identity
{
    public class RoleListingDto : IDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string? ConcurrencyStamp { get; set; }
    }
}
