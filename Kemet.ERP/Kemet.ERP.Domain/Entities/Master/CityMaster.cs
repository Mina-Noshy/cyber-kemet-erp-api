using Kemet.ERP.Domain.Entities.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kemet.ERP.Domain.Entities.Master
{
    public class CityMaster : TEntity
    {
        public long CountryId { get; set; }
        public string Name { get; set; }


        [ForeignKey(nameof(CountryId))]
        public virtual CountryMaster GetCountry { get; set; }
    }
}
