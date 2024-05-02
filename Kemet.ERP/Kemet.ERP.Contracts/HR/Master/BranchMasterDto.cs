using Kemet.ERP.Contracts.Shared;

namespace Kemet.ERP.Contracts.HR.Master
{
    public class BranchMasterDto : IDto
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }

        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string? Description { get; set; }
        public string? PhoneNumber { get; set; }
        public string? FaxNumber { get; set; }
        public string? Email { get; set; }
        public string? Manager { get; set; }
        public DateTime? Established { get; set; }
        public int? EmployeeCount { get; set; }
        public string? Notes { get; set; }

        public bool IsActive { get; set; }
    }
}
