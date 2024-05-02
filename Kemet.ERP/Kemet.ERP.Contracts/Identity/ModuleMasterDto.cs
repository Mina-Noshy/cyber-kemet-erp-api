using Kemet.ERP.Contracts.Shared;

namespace Kemet.ERP.Contracts.Identity
{
    public class ModuleMasterDto : IDto
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public string Label { get; set; }
        public string Icon { get; set; }
    }
}
