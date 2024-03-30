﻿using Kemet.ERP.Domain.Entities.Common;

namespace Kemet.ERP.Domain.Entities.HR.Common
{
    public class Country : TEntity
    {
        public string EnName { get; set; }
        public string ArName { get; set; }
        public string ShortName { get; set; }
        public int PhoneCode { get; set; }
    }
}
