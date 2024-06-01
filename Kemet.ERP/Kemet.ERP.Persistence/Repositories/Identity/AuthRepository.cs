using Kemet.ERP.Domain.Entities.Identity;
using Kemet.ERP.Domain.IRepositories.Identity;
using Kemet.ERP.Persistence.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Kemet.ERP.Persistence.Repositories.Identity
{
    public class AuthRepository : IAuthRepository
    {
        private readonly MainDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AuthRepository(MainDbContext context,
                              UserManager<AppUser> userManager,
                              RoleManager<IdentityRole> roleManager)
            => (_context, _userManager, _roleManager) = (context, userManager, roleManager);


        // Roles section
        public async Task<IEnumerable<IdentityRole>> GetRolesAsync(CancellationToken cancellationToken = default)
            => await _roleManager.Roles.ToListAsync(cancellationToken);

        public async Task<IdentityRole?> GetRoleByIdAsync(string id, CancellationToken cancellationToken = default)
            => await _roleManager.FindByIdAsync(id);

        public async Task<IdentityRole?> GetRoleByNameAsync(string name, CancellationToken cancellationToken = default)
            => await _roleManager.FindByNameAsync(name);

        public async Task<IdentityResult> CreateRoleAsync(IdentityRole role, CancellationToken cancellationToken = default)
            => await _roleManager.CreateAsync(role);

        public async Task<IdentityResult> UpdateRoleAsync(IdentityRole role, CancellationToken cancellationToken = default)
            => await _roleManager.UpdateAsync(role);

        public async Task<IdentityResult> DeleteRoleAsync(string id, CancellationToken cancellationToken = default)
            => await _roleManager.DeleteAsync(await GetRoleByIdAsync(id));






        // Auth section
        public async Task<IdentityResult> AddUserRoleAsync(AppUser user, string role, CancellationToken cancellationToken = default)
            => await _userManager.AddToRoleAsync(user, role);

        public async Task<IdentityResult> RemoveUserRoleAsync(AppUser user, string role, CancellationToken cancellationToken = default)
            => await _userManager.RemoveFromRoleAsync(user, role);

        public async Task<bool> CheckPasswordAsync(AppUser user, string password, CancellationToken cancellationToken = default)
            => await _userManager.CheckPasswordAsync(user, password);

        public async Task<IEnumerable<string>> GetUserRolesAsync(AppUser user, CancellationToken cancellationToken = default)
            => await _userManager.GetRolesAsync(user);

        public void UpdateUser(AppUser user)
            => _context.Update(user);

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
            => await _context.SaveChangesAsync(cancellationToken);

    }
}
