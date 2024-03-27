using System.ComponentModel.DataAnnotations.Schema;

namespace Kemet.ERP.Domain.Entities.HR.Common
{
    public class Region : TEntity
    {
        public long CountryId { get; set; }
        public string EnName { get; set; }
        public string ArName { get; set; }


        [ForeignKey(nameof(CountryId))]
        public virtual Country GetCountry { get; set; }
    }
}
