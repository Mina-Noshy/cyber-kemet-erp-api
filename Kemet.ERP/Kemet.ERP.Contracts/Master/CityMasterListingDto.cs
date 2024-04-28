using Kemet.ERP.Contracts.Shared;

namespace Kemet.ERP.Contracts.Master
{
    public class CityMasterListingDto : IDto
    {
        public long? Id { get; set; }
        public long CountryId { get; set; }
        public string Name { get; set; }
        public string CountryName { get; set; }
    }
}
