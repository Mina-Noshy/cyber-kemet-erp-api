using Kemet.ERP.Domain.Entities.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kemet.ERP.Domain.Entities.Identity
{
    public class PageMaster : TEntity
    {
        public long MenuId { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }

        [ForeignKey(nameof(MenuId))]
        public virtual MenuMaster? GetMenu { get; set; }

        public virtual ICollection<RolePageMaster>? GetRolePages { get; set; }
    }
}
