﻿using Kemet.ERP.Contracts.Shared;

namespace Kemet.ERP.Contracts.HR.Master
{
    public class EmploymentStatusMasterDto : IDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}