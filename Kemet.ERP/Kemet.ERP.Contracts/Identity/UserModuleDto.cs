using Kemet.ERP.Contracts.Shared;

namespace Kemet.ERP.Contracts.Identity
{
    public class UserModuleDto : IDto
    {
        public string Module { get; set; }
        public string? Label { get; set; }
        public string? Icon { get; set; }
        public List<UserMenuDto>? Menus { get; set; }
    }

    public class UserMenuDto : IDto
    {
        public string Menu { get; set; }
        public string? Label { get; set; }
        public string? Icon { get; set; }
        public List<UserPageDto>? Pages { get; set; }
    }

    public class UserPageDto : IDto
    {
        public string Page { get; set; }
        public string Url { get; set; }
        public string? Label { get; set; }
        public string? Icon { get; set; }

        public bool Create { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
        public bool Export { get; set; }
    }
}
