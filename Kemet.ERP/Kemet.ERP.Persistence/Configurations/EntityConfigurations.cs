using Kemet.ERP.Domain.Entities.Common;
using Kemet.ERP.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kemet.ERP.Persistence.Configurations
{
    internal static class DbContextUtilities
    {
        internal static string HashPassword(AppUser user, string password)
        {
            var passwordHasher = new PasswordHasher<AppUser>();
            return passwordHasher.HashPassword(user, password);
        }
    }

    internal sealed class AppUserConfigurations : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> entity)
        {
            var user = new AppUser
            {
                Id = Guid.NewGuid().ToString(),
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

    internal sealed class CountryConfigurations : IEntityTypeConfiguration<CountryMaster>
    {
        public void Configure(EntityTypeBuilder<CountryMaster> entity)
        {
            entity
                .Ignore(x => x.CreatedBy)
                .Ignore(x => x.CreatedOn);
        }

    }

    internal sealed class RegionConfigurations : IEntityTypeConfiguration<RegionMaster>
    {
        public void Configure(EntityTypeBuilder<RegionMaster> entity)
        {
            entity
                .Ignore(x => x.CreatedBy)
                .Ignore(x => x.CreatedOn);
        }

    }
}
