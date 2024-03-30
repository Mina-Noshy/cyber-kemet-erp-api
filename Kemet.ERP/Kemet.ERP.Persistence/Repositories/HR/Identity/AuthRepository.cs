using Kemet.ERP.Domain.Entities.HR.Identity;
using Kemet.ERP.Domain.IRepositories.HR.Identity;
using Kemet.ERP.Persistence.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Kemet.ERP.Persistence.Repositories.HR.Identity
{
    internal class AuthRepository : IAuthRepository
    {
        private readonly RepositoryDbContext _dbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AuthRepository(RepositoryDbContext dbContext,
                              UserManager<AppUser> userManager,
                              RoleManager<IdentityRole> roleManager)
            => (_dbContext, _userManager, _roleManager) = (dbContext, userManager, roleManager);



        public async Task<IEnumerable<IdentityRole>> GetRolesAsync(CancellationToken cancellationToken = default)
            => await _roleManager.Roles.ToListAsync(cancellationToken);

        public async Task<IdentityRole?> GetRoleByIdAsync(string id, CancellationToken cancellationToken = default)
            => await _roleManager.FindByIdAsync(id);

        public async Task<IdentityRole?> GetRoleByNameAsync(string name, CancellationToken cancellationToken = default)
            => await _roleManager.FindByNameAsync(name);

        public async Task<IdentityResult> AddUserRoleAsync(AppUser user, string role, CancellationToken cancellationToken = default)
            => await _userManager.AddToRoleAsync(user, role);

        public async Task<IdentityResult> RemoveUserRoleAsync(AppUser user, string role, CancellationToken cancellationToken = default)
            => await _userManager.RemoveFromRoleAsync(user, role);

        public async Task<IdentityResult> CreateRoleAsync(string role, CancellationToken cancellationToken = default)
            => await _roleManager.CreateAsync(new IdentityRole(role));

        public async Task<IdentityResult> DeleteRoleAsync(string role, CancellationToken cancellationToken = default)
            => await _roleManager.DeleteAsync(await GetRoleByNameAsync(role));

        public async Task<bool> CheckPasswordAsync(AppUser user, string password, CancellationToken cancellationToken = default)
            => await _userManager.CheckPasswordAsync(user, password);

        public async Task<IEnumerable<string>> GetUserRolesAsync(AppUser user, CancellationToken cancellationToken = default)
            => await _userManager.GetRolesAsync(user);

        public void UpdateUser(AppUser user)
            => _dbContext.Update(user);

    }
}
