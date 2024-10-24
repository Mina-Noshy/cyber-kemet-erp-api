﻿using Kemet.ERP.Contracts.Shared;

namespace Kemet.ERP.Contracts.Identity
{
    public class PageMasterDto : IDto
    {
        public long Id { get; set; }

        public long MenuId { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
    }
}
