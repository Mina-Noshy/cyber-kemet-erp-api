using Kemet.ERP.Domain.Entities.Shared;

namespace Kemet.ERP.Domain.Entities.HR.Master
{
    public class JobTitleMaster : TEntity
    {
        public long DepartmentId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal SalaryRange { get; set; }
        public string Qualifications { get; set; }
        public string Experience { get; set; }
    }
}
