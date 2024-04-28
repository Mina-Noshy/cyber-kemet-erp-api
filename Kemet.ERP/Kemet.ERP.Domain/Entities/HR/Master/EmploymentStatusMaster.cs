using Kemet.ERP.Domain.Entities.Shared;

namespace Kemet.ERP.Domain.Entities.HR.Master
{
    public class EmploymentStatusMaster : TEntity
    {
        // Current status of employment(e.g., Active, On Leave, Resigned, Terminated, Retired)
        public string Name { get; set; }
    }
}
