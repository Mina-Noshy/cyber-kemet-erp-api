using Kemet.ERP.Contracts.Shared;

namespace Kemet.ERP.Contracts.Master
{
    public class CityMasterDto : IDto
    {
        public long? Id { get; set; }
        public long CountryId { get; set; }
        public string Name { get; set; }
    }
}
