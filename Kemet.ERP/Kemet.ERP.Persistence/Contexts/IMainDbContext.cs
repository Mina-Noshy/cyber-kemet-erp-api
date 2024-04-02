using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Kemet.ERP.Persistence.Contexts
{
    public interface IMainDbContext : IDisposable
    {
        DatabaseFacade Database { get; }
        EntityEntry Entry(object entity);
        DbSet<T> Set<T>() where T : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
