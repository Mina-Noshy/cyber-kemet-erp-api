using Kemet.ERP.Contracts.Shared;

namespace Kemet.ERP.Contracts.Master
{
    public class BankMasterDto : IDto
    {
        public long Id { get; set; }
        public string BankName { get; set; }
        public string? BankCode { get; set; }
        public string RoutingNumber { get; set; }
        public string Branch { get; set; }
        public string? SwiftCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string? Address { get; set; }
    }
}
