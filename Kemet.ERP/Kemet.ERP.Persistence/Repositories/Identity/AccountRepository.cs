using Kemet.ERP.Domain.Entities.Identity;
using Kemet.ERP.Domain.IRepositories.Identity;
using Kemet.ERP.Persistence.Configurations;
using Kemet.ERP.Shared.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Kemet.ERP.Persistence.Repositories.Identity
{
    public class AccountRepository : IAccountRepository
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

        public async Task<AppUser?> ConfirmEmailAsync(string userId, string token, CancellationToken cancellationToken = default)
            => await ConfirmEmail(userId, token, cancellationToken);

        public async Task<AppUser?> SendConfirmationEmailAsync(string email, CancellationToken cancellationToken = default)
            => await SendConfirmationEmail(email, cancellationToken);



        private async Task<AppUser?> ConfirmEmail(string userId, string token, CancellationToken cancellationToken = default)
        {
            var user =
                await _userManager.FindByIdAsync(userId);

            if (user == null)
                return null;

            var result =
                await _userManager.ConfirmEmailAsync(user, token);

            if (result.Succeeded)
                return user;

            return null;
        }
        private async Task<AppUser?> ConfigureAndCreateUser(AppUser user, string password, CancellationToken cancellationToken = default)
        {
            user.Id =
                Guid.NewGuid().ToString();

            user.PasswordHash =
                DbContextUtilities.HashPassword(user, password);

            user.NormalizedEmail =
                user.Email?.ToUpper();

            user.NormalizedUserName =
                user.UserName?.ToUpper();

            user.SecurityStamp =
                Guid.NewGuid().ToString();

            var result =
                await _userManager.CreateAsync(user);

            await SendConfirmationEmail(user.Email);

            return
                result.Succeeded ? user : null;
        }
        private async Task<AppUser?> SendConfirmationEmail(string email, CancellationToken cancellationToken = default)
        {
            var user =
                await _userManager.FindByEmailAsync(email);

            if (user is null)
                return null;

            var token =
                await _userManager.GenerateEmailConfirmationTokenAsync(user);

            var confirmationUrl =
                ConfigurationHelper.GetURL("Api") + $"/api/identity/account/confirm-email?userId={user.Id}&token={token}";

            var appName =
                ConfigurationHelper.GetProfile("AppName");

            var subject =
                $"{appName}: Confirm your email";

            var body = $@"Thank you for registering. 
Please click the url below to confirm your email address:
{confirmationUrl}

{appName}
";
            var isSent =
                EmailHelper.Send(email, subject, body);

            return
                isSent ? user : null;
        }

    }
}
