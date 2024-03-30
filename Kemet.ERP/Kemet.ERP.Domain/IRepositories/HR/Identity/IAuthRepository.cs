using Kemet.ERP.Domain.Entities.HR.Identity;
using Microsoft.AspNetCore.Identity;

namespace Kemet.ERP.Domain.IRepositories.HR.Identity
{
    public interface IAuthRepository
    {
        Task<IEnumerable<IdentityRole>> GetRolesAsync(CancellationToken cancellationToken = default);
        Task<IdentityRole?> GetRoleByIdAsync(string id, CancellationToken cancellationToken = default);
        Task<IdentityRole?> GetRoleByNameAsync(string name, CancellationToken cancellationToken = default);

        Task<IdentityResult> CreateRoleAsync(string role, CancellationToken cancellationToken = default);
        Task<IdentityResult> DeleteRoleAsync(string role, CancellationToken cancellationToken = default);

        Task<IdentityResult> AddUserRoleAsync(AppUser user, string role, CancellationToken cancellationToken = default);
        Task<IdentityResult> RemoveUserRoleAsync(AppUser user, string role, CancellationToken cancellationToken = default);


        Task<bool> CheckPasswordAsync(AppUser user, string password, CancellationToken cancellationToken = default);
        Task<IEnumerable<string>> GetUserRolesAsync(AppUser user, CancellationToken cancellationToken = default);
        void UpdateUser(AppUser user);
    }
}
