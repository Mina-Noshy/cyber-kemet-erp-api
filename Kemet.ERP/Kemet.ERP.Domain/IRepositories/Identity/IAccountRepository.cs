using Kemet.ERP.Domain.Entities.Identity;

namespace Kemet.ERP.Domain.IRepositories.Identity
{
    public interface IAccountRepository
    {
        Task<IEnumerable<AppUser>> GetUsersAsync(int skip, int take, CancellationToken cancellationToken = default);
        Task<AppUser?> GetUserByIdAsync(string id, CancellationToken cancellationToken = default);
        Task<AppUser?> GetUserByNameAsync(string name, CancellationToken cancellationToken = default);
        Task<AppUser?> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default);
        Task<AppUser?> GetUserByTokenAsync(string email, CancellationToken cancellationToken = default);
        Task<AppUser?> CreateUserAsync(AppUser user, string password, CancellationToken cancellationToken = default);
    }
}
