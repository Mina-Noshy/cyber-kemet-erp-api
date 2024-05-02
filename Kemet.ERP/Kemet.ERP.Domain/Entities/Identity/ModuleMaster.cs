using Kemet.ERP.Domain.Entities.Shared;

namespace Kemet.ERP.Domain.Entities.Identity
{
    public class ModuleMaster : TEntity
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public string Icon { get; set; }
    }
}
