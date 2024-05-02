using Kemet.ERP.Domain.Entities.Shared;

namespace Kemet.ERP.Domain.Entities.HR.HrDatabase
{
    public class EmployeeDependent : TEntity
    {
        public long EmployeeId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Relationship { get; set; }
        public bool IsCoveredByInsurance { get; set; }
        public bool IsStudent { get; set; }
        public string? SchoolName { get; set; }
        public string Notes { get; set; }
        public bool IsActive { get; set; }
    }
}
