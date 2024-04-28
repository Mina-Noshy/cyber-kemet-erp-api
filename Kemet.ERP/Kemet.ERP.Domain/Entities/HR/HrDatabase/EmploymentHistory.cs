using Kemet.ERP.Domain.Entities.Shared;

namespace Kemet.ERP.Domain.Entities.HR.HrDatabase
{
    public class EmploymentHistory : TEntity
    {
        public long EmployeeId { get; set; }
        public string EmployerName { get; set; }
        public string JobTitle { get; set; }
        public string Location { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public string Responsibilities { get; set; }
        public string? ReasonForLeaving { get; set; }

        public decimal? Salary { get; set; }
    }
}
