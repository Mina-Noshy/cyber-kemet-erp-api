using Kemet.ERP.Contracts.Shared;

namespace Kemet.ERP.Contracts.Identity
{
    public class PageMasterListingDto : IDto
    {
        public long Id { get; set; }

        public long? ModuleId { get; set; }
        public string? ModuleName { get; set; }

        public long MenuId { get; set; }
        public string MenuName { get; set; }

        public string Name { get; set; }
        public string Label { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
    }
}
