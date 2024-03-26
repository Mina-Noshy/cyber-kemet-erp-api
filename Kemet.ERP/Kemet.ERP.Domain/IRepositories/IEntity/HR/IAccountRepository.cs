using Kemet.ERP.Domain.Entities.HR;

namespace Kemet.ERP.Domain.IRepositories.IEntity.HR
{
    public interface IAccountRepository
    {
        Task<IEnumerable<AppUser>> GetAllAsync(int skip, int take, CancellationToken cancellationToken = default);
        Task<AppUser?> GetByIdAsync(string id, CancellationToken cancellationToken = default);
        Task<AppUser?> GetByNameAsync(string name, CancellationToken cancellationToken = default);
        Task<AppUser?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
        Task<AppUser?> CreateAsync(AppUser user, string password, CancellationToken cancellationToken = default);
    }
}
