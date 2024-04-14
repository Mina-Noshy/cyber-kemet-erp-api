using Kemet.ERP.Contracts.Shared;

namespace Kemet.ERP.Contracts.Common
{
    public class RegionMasterListingDto : IDto
    {
        public long? Id { get; set; }
        public long CountryId { get; set; }
        public string EnName { get; set; }
        public string ArName { get; set; }
        public string CountryEnName { get; set; }
        public string CountryArName { get; set; }
    }
}
