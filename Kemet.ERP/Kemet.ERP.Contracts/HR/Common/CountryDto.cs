﻿using Kemet.ERP.Contracts.Common;

namespace Kemet.ERP.Contracts.HR.Common
{
    public class CountryDto : IDto
    {
        public long Id { get; set; }
        public string EnName { get; set; }
        public string ArName { get; set; }
        public string ShortName { get; set; }
        public int PhoneCode { get; set; }
    }
}