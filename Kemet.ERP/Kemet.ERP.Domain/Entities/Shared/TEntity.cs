namespace Kemet.ERP.Domain.Entities.Shared
{
    public class TEntity : IEntity
    {
        public long Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
