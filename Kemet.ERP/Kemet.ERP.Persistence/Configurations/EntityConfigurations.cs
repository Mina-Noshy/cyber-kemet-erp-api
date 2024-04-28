using Kemet.ERP.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kemet.ERP.Persistence.Configurations
{
    internal static class DbContextUtilities
    {
        internal static string userId = Guid.NewGuid().ToString();
        internal static string userRoleId = Guid.NewGuid().ToString();
        internal static string hrAdminRoleId = Guid.NewGuid().ToString();

        internal static string HashPassword(AppUser user, string password)
        {
            var passwordHasher = new PasswordHasher<AppUser>();
            return passwordHasher.HashPassword(user, password);
        }
    }

    internal sealed class IdentityRoleConfigurations : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> entity)
        {
            var roles = new List<IdentityRole>()
            {
                new IdentityRole
                {
                    Id = DbContextUtilities.userRoleId,
                    Name = "User",
                    NormalizedName = "User".ToUpper()
                },
                new IdentityRole
                {
                    Id = DbContextUtilities.hrAdminRoleId,
                    Name = "HR Admin",
                    NormalizedName = "HR Admin".ToUpper()
                }
            };

            entity.HasData(roles);
        }
    }

    internal sealed class AppUserConfigurations : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> entity)
        {
            var user = new AppUser
            {
                Id = DbContextUtilities.userId,
                FirstName = "Cyber",
                LastName = "Kemet",

                UserName = "cyber-kemet",
                NormalizedUserName = "cyber-kemet".ToUpper(),

                Email = "info@cyberkemet.com",
                NormalizedEmail = "info@cyberkemet.com".ToUpper(),
                EmailConfirmed = true,

                PhoneNumber = "01111257052",
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            user.PasswordHash = DbContextUtilities.HashPassword(user, "kemet");

            entity.HasData(user);
        }
    }

    internal sealed class IdentityUserRoleConfigurations : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> entity)
        {
            var userRole = new IdentityUserRole<string>
            {
                UserId = DbContextUtilities.userId,
                RoleId = DbContextUtilities.hrAdminRoleId
            };

            entity.HasData(userRole);
        }
    }

}
