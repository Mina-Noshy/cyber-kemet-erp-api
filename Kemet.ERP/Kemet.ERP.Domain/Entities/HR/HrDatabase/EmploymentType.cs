using Kemet.ERP.Domain.Entities.Shared;

namespace Kemet.ERP.Domain.Entities.HR.HrDatabase
{
    public class EmploymentType : TEntity
    {
        public long EmployeeId { get; set; }
        public long TypeId { get; set; } // EmploymentTypeMaster

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Comment { get; set; }
    }
}
