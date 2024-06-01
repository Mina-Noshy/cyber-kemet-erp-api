using Kemet.ERP.Contracts.Shared;

namespace Kemet.ERP.Contracts.Identity
{
    public class RoleDetailsDto : IDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string? ConcurrencyStamp { get; set; }

        public List<RoleModuleTreeDto>? Modules { get; set; }
    }

    public class RoleModuleTreeDto : IDto
    {
        public string Module { get; set; }
        public List<RoleMenuTreeDto> Menus { get; set; }
    }

    public class RoleMenuTreeDto : IDto
    {
        public string Menu { get; set; }
        public List<RolePageTreeDto> Pages { get; set; }
    }

    public class RolePageTreeDto : IDto
    {
        public long Id { get; set; }
        public string Page { get; set; }

        public bool Create { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
        public bool Export { get; set; }
    }
}
