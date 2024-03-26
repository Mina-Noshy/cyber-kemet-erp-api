namespace Kemet.ERP.Domain.Entities
{
    public class TEntity : IEntity
    {
        public long Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
