using Kemet.ERP.Domain.Common.Utilities;
using Kemet.ERP.Domain.Entities.Identity;
using Kemet.ERP.Domain.IRepositories.Identity;
using Kemet.ERP.Persistence.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.Encodings.Web;

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

            if (user is null)
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

            // add user to default role
            if (result.Succeeded)
                result = await _userManager.AddToRoleAsync(user, "User");

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
                BuildConfirmationCallbackUrl(user.Id, token);

            var appName =
                ConfigurationHelper.GetProfile("AppName");

            var subject =
                $"{appName}: Confirm your email";

            StringBuilder emailTemplateBuilder = new StringBuilder();
            emailTemplateBuilder.AppendLine(@"<!DOCTYPE html>");
            emailTemplateBuilder.AppendLine(@"<html lang=""en"">");
            emailTemplateBuilder.AppendLine(@"<head>");
            emailTemplateBuilder.AppendLine(@"<style>");
            emailTemplateBuilder.AppendLine(@"body {");
            emailTemplateBuilder.AppendLine(@"font-family: Arial, sans-serif;");
            emailTemplateBuilder.AppendLine(@"margin: 0;");
            emailTemplateBuilder.AppendLine(@"padding: 0;");
            emailTemplateBuilder.AppendLine(@"}");
            emailTemplateBuilder.AppendLine(@".container {");
            emailTemplateBuilder.AppendLine(@"max-width: 600px;");
            emailTemplateBuilder.AppendLine(@"margin: 20px auto;");
            emailTemplateBuilder.AppendLine(@"padding: 20px;");
            emailTemplateBuilder.AppendLine(@"text-align: center;");
            emailTemplateBuilder.AppendLine(@"}");
            emailTemplateBuilder.AppendLine(@".button {");
            emailTemplateBuilder.AppendLine(@"display: inline-block;");
            emailTemplateBuilder.AppendLine(@"padding: 10px 20px;");
            emailTemplateBuilder.AppendLine(@"background-color: #007bff;");
            emailTemplateBuilder.AppendLine(@"color: #fff;");
            emailTemplateBuilder.AppendLine(@"text-decoration: none;");
            emailTemplateBuilder.AppendLine(@"border-radius: 5px;}");
            emailTemplateBuilder.AppendLine(@"</style>");
            emailTemplateBuilder.AppendLine(@"</head>");
            emailTemplateBuilder.AppendLine(@"<body>");
            emailTemplateBuilder.AppendLine(@"<div class=""container"">");
            emailTemplateBuilder.AppendLine($@"<h1>Confirm Your Email with {appName}</h1>");
            emailTemplateBuilder.AppendLine(@"<p>Please click the button below to confirm your email address.</p>");
            emailTemplateBuilder.AppendLine($@"<a href=""{confirmationUrl}"" class=""button"">Confirm Email</a>");
            emailTemplateBuilder.AppendLine(@"</div>");
            emailTemplateBuilder.AppendLine(@"</body>");
            emailTemplateBuilder.AppendLine(@"</html>");

            string body = emailTemplateBuilder.ToString();

            var isSent =
                EmailHelper.Send(email, subject, body, true);

            return
                isSent ? user : null;
        }
        private string BuildConfirmationCallbackUrl(string userId, string token)
        {
            var baseUrl = ConfigurationHelper.GetURL("Api");
            var controllerUrl = "/api/identity/accounts/confirm-email";

            var encodedToken = UrlEncoder.Default.Encode(token);

            return $"{baseUrl}{controllerUrl}?userId={userId}&token={encodedToken}";
        }
    }
}
