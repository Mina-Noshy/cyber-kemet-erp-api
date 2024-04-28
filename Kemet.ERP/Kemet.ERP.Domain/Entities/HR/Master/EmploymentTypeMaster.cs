using Kemet.ERP.Domain.Entities.Shared;

namespace Kemet.ERP.Domain.Entities.HR.Master
{
    public class EmploymentTypeMaster : TEntity
    {
        // Type of employment (e.g., Full-time, Part-time, Contract, Temporary, Permanent, Internship)
        public string Name { get; set; }
    }
}
