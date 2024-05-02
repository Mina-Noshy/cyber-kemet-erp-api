using Kemet.ERP.Contracts.Shared;

namespace Kemet.ERP.Contracts.Identity
{
    public class RolePageMasterListingDto : IDto
    {
        public long Id { get; set; }

        public string RoleId { get; set; }
        public string RoleName { get; set; }

        public long PageId { get; set; }
        public string PageName { get; set; }

        public bool Create { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
        public bool Export { get; set; }
    }
}
