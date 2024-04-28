using Kemet.ERP.Domain.Entities.Shared;

namespace Kemet.ERP.Domain.Entities.HR.HrDatabase
{
    public class EmploymentStatus : TEntity
    {
        public long EmployeeId { get; set; }
        public long StatusId { get; set; } // EmploymentStatusMaster

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ReasonForChange { get; set; }
    }
}
