using Kemet.ERP.Contracts.Shared;

namespace Kemet.ERP.Contracts.HR.Master
{
    public class DepartmentMasterDto : IDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}
