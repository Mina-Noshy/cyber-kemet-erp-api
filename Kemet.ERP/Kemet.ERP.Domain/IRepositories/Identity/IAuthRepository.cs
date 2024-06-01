using Kemet.ERP.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Kemet.ERP.Domain.IRepositories.Identity
{
    public interface IAuthRepository
    {
        // Roles part
        Task<IEnumerable<IdentityRole>> GetRolesAsync(CancellationToken cancellationToken = default);
        Task<IdentityRole?> GetRoleByIdAsync(string id, CancellationToken cancellationToken = default);
        Task<IdentityRole?> GetRoleByNameAsync(string name, CancellationToken cancellationToken = default);
        Task<IdentityResult> CreateRoleAsync(IdentityRole role, CancellationToken cancellationToken = default);
        Task<IdentityResult> UpdateRoleAsync(IdentityRole role, CancellationToken cancellationToken = default);
        Task<IdentityResult> DeleteRoleAsync(string id, CancellationToken cancellationToken = default);


        // Auth part
        Task<IdentityResult> AddUserRoleAsync(AppUser user, string role, CancellationToken cancellationToken = default);
        Task<IdentityResult> RemoveUserRoleAsync(AppUser user, string role, CancellationToken cancellationToken = default);
        Task<bool> CheckPasswordAsync(AppUser user, string password, CancellationToken cancellationToken = default);
        Task<IEnumerable<string>> GetUserRolesAsync(AppUser user, CancellationToken cancellationToken = default);
        void UpdateUser(AppUser user);

        Task<int> CommitAsync(CancellationToken cancellationToken);
    }
}
