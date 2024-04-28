namespace Kemet.ERP.Domain.Entities.Shared
{
    public class TEntity : IEntity
    {
        public long Id { get; set; } = 0;
        public bool? IsDeleted { get; set; } = false;
    }
}
