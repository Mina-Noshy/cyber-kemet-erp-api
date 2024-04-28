using Kemet.ERP.Domain.Entities.Shared;

namespace Kemet.ERP.Domain.Entities.HR.HrDatabase
{
    public class TaxInformation : TEntity
    {
        public long EmployeeId { get; set; }

        public decimal Salary { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TaxableIncome { get; private set; }
        public decimal TaxAmount { get; private set; }
        public decimal NetSalary { get; private set; }


        public TaxInformation(long employeeId, decimal salary, decimal taxRate, decimal taxableIncome)
        {
            EmployeeId = employeeId;
            Salary = salary;
            TaxRate = taxRate;
            TaxableIncome = taxableIncome;
            CalculateTaxAmount();
            CalculateNetSalary();
        }


        // Method to calculate tax amount
        private void CalculateTaxAmount()
        {
            TaxAmount = TaxableIncome * (TaxRate / 100);
        }

        // Method to calculate net salary
        private void CalculateNetSalary()
        {
            NetSalary = Salary - TaxAmount;
        }

        // Method to update tax rate
        public void UpdateTaxRate(decimal newTaxRate)
        {
            TaxRate = newTaxRate;
            CalculateTaxAmount();
            CalculateNetSalary();
        }
    }
}
