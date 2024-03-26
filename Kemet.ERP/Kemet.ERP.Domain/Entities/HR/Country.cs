namespace Kemet.ERP.Domain.Entities.HR
{
    public class Country : TEntity
    {
        public string EnName { get; set; }
        public string ArName { get; set; }
        public string ShortName { get; set; }
        public int PhoneCode { get; set; }
    }
}
