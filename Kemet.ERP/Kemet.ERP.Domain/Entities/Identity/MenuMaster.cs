using Kemet.ERP.Domain.Entities.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kemet.ERP.Domain.Entities.Identity
{
    public class MenuMaster : TEntity
    {
        public long ModuleId { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Icon { get; set; }

        [ForeignKey(nameof(ModuleId))]
        public virtual ModuleMaster? GetModule { get; set; }
    }
}
