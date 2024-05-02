using Kemet.ERP.Domain.Entities.Shared;

namespace Kemet.ERP.Domain.Entities.HR.HrDatabase
{
    public class EmployeeContactInformation : TEntity
    {
        public long EmployeeId { get; set; }
        public string ContactType { get; set; }
        public string ContactDetails { get; set; }
    }
}
