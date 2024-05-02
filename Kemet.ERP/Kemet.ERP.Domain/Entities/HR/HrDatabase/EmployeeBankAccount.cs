using Kemet.ERP.Domain.Entities.Shared;

namespace Kemet.ERP.Domain.Entities.HR.HrDatabase
{
    public class EmployeeBankAccount : TEntity
    {
        public long EmployeeId { get; set; }
        public long BankId { get; set; }

        public string BankAccountNumber { get; set; }
        public string? BankAccountIBAN { get; set; }
        public string? CardNumber { get; set; }
    }
}
