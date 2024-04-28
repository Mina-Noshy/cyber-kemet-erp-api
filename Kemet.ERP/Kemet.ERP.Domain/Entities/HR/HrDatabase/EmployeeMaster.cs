using Kemet.ERP.Domain.Entities.Shared;

namespace Kemet.ERP.Domain.Entities.HR.HrDatabase
{
    public class EmployeeMaster : TEntity
    {
        /*
         * Employment type => EmploymentType entity
         * Employment status => EmploymentStatus entity
         */

        public long DepartmentId { get; set; }
        public long JobTitleId { get; set; }
        public long ManagerId { get; set; }
        public long CompanyId { get; set; }

        public string Title { get; set; } // Mr, Mrs, Ms
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePicture { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfHire { get; set; }


        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string ApartmentSuite { get; set; }
        public string ZipCode { get; set; }

    }
}
