using Kemet.ERP.Domain.Entities.HR;
using Kemet.ERP.Domain.IRepositories.IEntity.HR;
using Kemet.ERP.Persistence.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Kemet.ERP.Persistence.Repositories.Entity.HR
{
    internal class AccountRepository : IAccountRepository
    {
        private readonly UserManager<AppUser> _userManager;
        public AccountRepository(UserManager<AppUser> userManager)
            => _userManager = userManager;



        public async Task<AppUser?> CreateAsync(AppUser user, string password, CancellationToken cancellationToken = default)
        {
            user.PasswordHash = DbContextUtilities.HashPassword(user, password);
            user.NormalizedEmail = user.Email?.ToUpper();
            user.NormalizedUserName = user.UserName?.ToUpper();
            user.SecurityStamp = Guid.NewGuid().ToString();

            var result = await _userManager.CreateAsync(user);

            return result.Succeeded ? user : null;
        }

        public async Task<IEnumerable<AppUser>> GetAllAsync(int skip, int take, CancellationToken cancellationToken = default)
            => await _userManager.Users.Skip(skip).Take(take).ToListAsync();

        public async Task<AppUser?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
            => await _userManager.FindByEmailAsync(email);

        public async Task<AppUser?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
            => await _userManager.FindByIdAsync(id);

        public async Task<AppUser?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
            => await _userManager.FindByNameAsync(name);
    }
}
