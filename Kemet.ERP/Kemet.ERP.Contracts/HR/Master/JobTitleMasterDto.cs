using Kemet.ERP.Contracts.Shared;

namespace Kemet.ERP.Contracts.HR.Master
{
    public class JobTitleMasterDto : IDto
    {
        public long Id { get; set; }
        public long DepartmentId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal SalaryRange { get; set; }
        public string Qualifications { get; set; }
        public string Experience { get; set; }
    }
}
