using Kemet.ERP.Domain.Entities.Shared;

namespace Kemet.ERP.Domain.Entities.Master
{
    public class CurrencyMaster : TEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
