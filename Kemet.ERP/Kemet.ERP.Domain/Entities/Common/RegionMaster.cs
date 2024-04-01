using Kemet.ERP.Domain.Entities.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kemet.ERP.Domain.Entities.Common
{
    public class RegionMaster : TEntity
    {
        public long CountryId { get; set; }
        public string EnName { get; set; }
        public string ArName { get; set; }


        [ForeignKey(nameof(CountryId))]
        public virtual CountryMaster GetCountry { get; set; }
    }
}
