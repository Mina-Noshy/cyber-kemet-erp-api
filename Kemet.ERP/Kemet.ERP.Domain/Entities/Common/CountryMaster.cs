using Kemet.ERP.Domain.Entities.Shared;

namespace Kemet.ERP.Domain.Entities.Common
{
    public class CountryMaster : TEntity
    {
        public string EnName { get; set; }
        public string ArName { get; set; }
        public string ShortName { get; set; }
        public int PhoneCode { get; set; }
    }
}
