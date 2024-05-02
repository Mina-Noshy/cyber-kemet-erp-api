using Kemet.ERP.Contracts.Shared;

namespace Kemet.ERP.Contracts.Identity
{
    public class RolePageMasterDto : IDto
    {
        public long Id { get; set; }

        public string RoleId { get; set; }
        public long PageId { get; set; }

        public bool Create { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
        public bool Export { get; set; }
    }
}
