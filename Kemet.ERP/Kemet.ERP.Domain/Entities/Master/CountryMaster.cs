using Kemet.ERP.Domain.Entities.Shared;

namespace Kemet.ERP.Domain.Entities.Master
{
    public class CountryMaster : TEntity
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string PhoneCode { get; set; }
    }
}
