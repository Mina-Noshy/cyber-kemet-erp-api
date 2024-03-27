using Kemet.ERP.Contracts.Common;

namespace Kemet.ERP.Contracts.HR.Common
{
    public class RegionDto : IDto
    {
        public long? Id { get; set; }
        public long CountryId { get; set; }
        public string EnName { get; set; }
        public string ArName { get; set; }
    }
}
