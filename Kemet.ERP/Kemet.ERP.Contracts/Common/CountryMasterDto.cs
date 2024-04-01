using Kemet.ERP.Contracts.Shared;

namespace Kemet.ERP.Contracts.Common
{
    public class CountryMasterDto : IDto
    {
        public long Id { get; set; }
        public string EnName { get; set; }
        public string ArName { get; set; }
        public string ShortName { get; set; }
        public int PhoneCode { get; set; }
    }
}
