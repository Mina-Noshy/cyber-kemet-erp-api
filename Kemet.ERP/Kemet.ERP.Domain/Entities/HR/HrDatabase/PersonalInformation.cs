using Kemet.ERP.Domain.Entities.Shared;

namespace Kemet.ERP.Domain.Entities.HR.HrDatabase
{
    public class PersonalInformation : TEntity
    {
        public long EmployeeId { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string MaritalStatus { get; set; }
        public string? SocialSecurityNumber { get; set; }
        public int Dependents { get; set; }
        public string? Ethnicity { get; set; }
        public string? Disabilities { get; set; }
        public string? LanguagesSpoken { get; set; }
        public string? BloodGroup { get; set; }
    }
}
