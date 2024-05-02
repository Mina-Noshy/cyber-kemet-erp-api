using Kemet.ERP.Domain.Entities.Shared;

namespace Kemet.ERP.Domain.Entities.HR.HrDatabase
{
    public class EmployeeEmergencyContact : TEntity
    {
        public long EmployeeId { get; set; }

        public string ContactName { get; set; }
        public string Relationship { get; set; }
        public string PhoneNumber { get; set; }
        public string? EmailAddress { get; set; }

        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string? ZipCode { get; set; }
    }
}
