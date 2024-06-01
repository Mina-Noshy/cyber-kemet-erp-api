﻿using Kemet.ERP.Contracts.Shared;
using Microsoft.AspNetCore.Http;

namespace Kemet.ERP.Contracts.HR.Master
{
    public class CompanyMasterDto : IDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public string? RegistrationNumber { get; set; }

        public string? ZipCode { get; set; }
        public string? Industry { get; set; }
        public string? Sector { get; set; }
        public string? Description { get; set; }
        public string? Website { get; set; }
        public IFormFile? Logo { get; set; }
        public string PhoneNumber { get; set; }
        public string? FaxNumber { get; set; }
        public string Email { get; set; }
        public string? CEO { get; set; }
        public DateTime? Founded { get; set; }
        public int? EmployeeCount { get; set; }
        public string? Headquarters { get; set; }
        public string? IndustryType { get; set; } // e.g. Public, Private, Non-Profit, etc.
        public string? Type { get; set; } // e.g. Corporation, Partnership, Sole Proprietorship, etc.
        public string? Status { get; set; } // e.g. Active, Inactive, Bankrupt, etc.
        public string? Notes { get; set; } // Additional notes about the company

        public bool IsActive { get; set; }
    }
}
