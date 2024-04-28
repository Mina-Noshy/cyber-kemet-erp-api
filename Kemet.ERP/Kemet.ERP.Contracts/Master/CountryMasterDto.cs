using Kemet.ERP.Contracts.Shared;

namespace Kemet.ERP.Contracts.Master
{
    public class CountryMasterDto : IDto
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string PhoneCode { get; set; }
    }
}
