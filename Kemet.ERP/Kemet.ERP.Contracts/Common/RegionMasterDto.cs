using Kemet.ERP.Contracts.Shared;

namespace Kemet.ERP.Contracts.Common
{
    public class RegionMasterDto : IDto
    {
        public long? Id { get; set; }
        public long CountryId { get; set; }
        public string EnName { get; set; }
        public string ArName { get; set; }
    }
}
