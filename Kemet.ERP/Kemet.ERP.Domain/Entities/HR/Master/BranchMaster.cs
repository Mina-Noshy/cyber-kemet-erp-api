﻿using Kemet.ERP.Domain.Entities.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kemet.ERP.Domain.Entities.HR.Master
{
    public class BranchMaster : TEntity
    {
        public long CompanyId { get; set; }

        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string? Description { get; set; }
        public string? PhoneNumber { get; set; }
        public string? FaxNumber { get; set; }
        public string? Email { get; set; }
        public string? Manager { get; set; }
        public DateTime? Established { get; set; }
        public int? EmployeeCount { get; set; }
        public string? Notes { get; set; }

        public bool IsActive { get; set; }


        [ForeignKey(nameof(CompanyId))]
        public virtual CompanyMaster? GetCompany { get; set; }
    }
}
