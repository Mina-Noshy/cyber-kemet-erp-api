using System.ComponentModel.DataAnnotations.Schema;
using Kemet.ERP.Domain.Entities.Common;

namespace Kemet.ERP.Domain.Entities.HR.Permission
{
    public class PageMaster : TEntity
    {
        public long MenuId { get; set; }
        public string EnName { get; set; }
        public string ArName { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }

        [ForeignKey(nameof(MenuId))]
        public virtual MenuMaster? GetMenu { get; set; }
    }
}
