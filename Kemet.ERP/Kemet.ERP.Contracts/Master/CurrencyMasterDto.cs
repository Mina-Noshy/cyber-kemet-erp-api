using Kemet.ERP.Contracts.Shared;

namespace Kemet.ERP.Contracts.Master
{
    public class CurrencyMasterDto : IDto
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string? Name { get; set; }
        public string? Symbol { get; set; }
        public string? Country { get; set; }
        public decimal ExchangeRate { get; set; }
        public bool IsActive { get; set; }
    }
}
