using Kemet.ERP.Domain.Entities.HR.Identity;
using Kemet.ERP.Domain.IRepositories.IEntity.HR.Identity;
using Kemet.ERP.Persistence.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Kemet.ERP.Persistence.Repositories.Entity.HR.Identity
{
    internal class AccountRepository : IAccountRepository
    {
        private readonly UserManager<AppUser> _userManager;
        public AccountRepository(UserManager<AppUser> userManager)
            => _userManager = userManager;





        public async Task<AppUser?> CreateUserAsync(AppUser user, string password, CancellationToken cancellationToken = default)
            => await ConfigureAndCreateUser(user, password, cancellationToken);

        public async Task<IEnumerable<AppUser>> GetUsersAsync(int skip, int take, CancellationToken cancellationToken = default)
            => await _userManager.Users.OrderBy(x => x.FirstName).Skip(skip).Take(take).ToListAsync();

        public async Task<AppUser?> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default)
            => await _userManager.FindByEmailAsync(email);

        public async Task<AppUser?> GetUserByIdAsync(string id, CancellationToken cancellationToken = default)
            => await _userManager.FindByIdAsync(id);

        public async Task<AppUser?> GetUserByNameAsync(string name, CancellationToken cancellationToken = default)
            => await _userManager.FindByNameAsync(name);

        public async Task<AppUser?> GetUserByTokenAsync(string token, CancellationToken cancellationToken = default)
            => await _userManager.Users.SingleOrDefaultAsync(x => x.RefreshTokens.Any(t => t.Token == token));




        private async Task<AppUser?> ConfigureAndCreateUser(AppUser user, string password, CancellationToken cancellationToken = default)
        {
            user.Id = Guid.NewGuid().ToString();
            user.PasswordHash = DbContextUtilities.HashPassword(user, password);
            user.NormalizedEmail = user.Email?.ToUpper();
            user.NormalizedUserName = user.UserName?.ToUpper();
            user.SecurityStamp = Guid.NewGuid().ToString();

            var result = await _userManager.CreateAsync(user);

            return result.Succeeded ? user : null;
        }
    }
}
