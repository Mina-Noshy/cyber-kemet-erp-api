using Kemet.ERP.Contracts.Shared;

namespace Kemet.ERP.Contracts.Identity
{
    public class RoleDto : IDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string? ConcurrencyStamp { get; set; }

        public List<RolePagesItemDto> Pages { get; set; }
    }

    public class RolePagesItemDto
    {
        public long PageId { get; set; }

        public bool Create { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
        public bool Export { get; set; }
    }
}
