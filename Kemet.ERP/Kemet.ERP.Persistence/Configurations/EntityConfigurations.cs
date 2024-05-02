using Kemet.ERP.Domain.Entities.Identity;
using Kemet.ERP.Domain.Entities.Master;
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

    internal sealed class GenderMasterConfigurations : IEntityTypeConfiguration<GenderMaster>
    {
        public void Configure(EntityTypeBuilder<GenderMaster> entity)
        {
            var roles = new List<GenderMaster>()
            {
                new GenderMaster
                {
                    Id = 1,
                    Name = "Male"
                },
                new GenderMaster
                {
                    Id = 2,
                    Name = "Female"
                },
                new GenderMaster
                {
                    Id = 3,
                    Name = "Other"
                }
            };

            entity.HasData(roles);
        }
    }

    internal sealed class MaritalStatusMasterConfigurations : IEntityTypeConfiguration<MaritalStatusMaster>
    {
        public void Configure(EntityTypeBuilder<MaritalStatusMaster> entity)
        {
            var roles = new List<MaritalStatusMaster>()
            {
                new MaritalStatusMaster
                {
                    Id = 1,
                    Name = "Single"
                },
                new MaritalStatusMaster
                {
                    Id = 2,
                    Name = "Engaged"
                },
                new MaritalStatusMaster
                {
                    Id = 3,
                    Name = "Married"
                },
                new MaritalStatusMaster
                {
                    Id = 4,
                    Name = "Divorced"
                },
                new MaritalStatusMaster
                {
                    Id = 5,
                    Name = "Widowed"
                }
            };

            entity.HasData(roles);
        }
    }

    internal sealed class NationalityMasterConfigurations : IEntityTypeConfiguration<NationalityMaster>
    {
        public void Configure(EntityTypeBuilder<NationalityMaster> entity)
        {
            var roles = new List<NationalityMaster>()
            {
                new NationalityMaster {
                    Id = 1,
                    Name = "Egyptian"
                },
                new NationalityMaster {
                    Id = 2,
                    Name = "Iranian"
                },
                new NationalityMaster {
                    Id = 3,
                    Name = "Turkish"
                },
                new NationalityMaster {
                    Id = 4,
                    Name = "Lebanese"
                },
                new NationalityMaster {
                    Id = 5,
                    Name = "Syrian"
                },
                new NationalityMaster {
                    Id = 6,
                    Name = "Jordanian"
                },
                new NationalityMaster {
                    Id = 7,
                    Name = "Palestinian"
                },
                new NationalityMaster {
                    Id = 8,
                    Name = "Iraqi"
                },
                new NationalityMaster {
                    Id = 9,
                    Name = "Saudi"
                },
                new NationalityMaster {
                    Id = 10,
                    Name = "Yemeni"
                },
                new NationalityMaster {
                    Id = 11,
                    Name = "Emirati"
                },
                new NationalityMaster {
                    Id = 12,
                    Name = "Qatari"
                },
                new NationalityMaster {
                    Id = 13,
                    Name = "Kuwaiti"
                },
                new NationalityMaster {
                    Id = 14,
                    Name = "Bahraini"
                },
                new NationalityMaster {
                    Id = 15,
                    Name = "Omani"
                },
                new NationalityMaster {
                    Id = 16,
                    Name = "Moroccan"
                },
                new NationalityMaster {
                    Id = 17,
                    Name = "Tunisian"
                },
                new NationalityMaster {
                    Id = 18,
                    Name = "Algerian"
                },
                new NationalityMaster {
                    Id = 19,
                    Name = "Libyan"
                }
            };

            entity.HasData(roles);
        }
    }

    internal sealed class CurrencyMasterConfigurations : IEntityTypeConfiguration<CurrencyMaster>
    {
        public void Configure(EntityTypeBuilder<CurrencyMaster> entity)
        {
            var roles = new List<CurrencyMaster>()
            {
                new CurrencyMaster
                {
                    Id = 1,
                    Code = "EGP",
                    Name = "Egyptian Pound",
                    Symbol = "£",
                    Country = "Egypt",
                    ExchangeRate = 1,
                    IsActive = true
                },

                new CurrencyMaster
                {
                    Id = 2,
                    Code = "SAR",
                    Name = "Saudi Riyal",
                    Symbol = "ر.س",
                    Country = "Saudi Arabia",
                    ExchangeRate = 1,
                    IsActive = true
                },

                new CurrencyMaster
                {
                    Id = 3,
                    Code = "AED",
                    Name = "United Arab Emirates Dirham",
                    Symbol = "د.إ",
                    Country = "United Arab Emirates",
                    ExchangeRate = 1,
                    IsActive = true
                },

                new CurrencyMaster
                {
                    Id = 4,
                    Code = "QAR",
                    Name = "Qatari Riyal",
                    Symbol = "ر.ق",
                    Country = "Qatar",
                    ExchangeRate = 1,
                    IsActive = true
                },

                new CurrencyMaster
                {
                    Id = 5,
                    Code = "BHD",
                    Name = "Bahraini Dinar",
                    Symbol = "د.ب",
                    Country = "Bahrain",
                    ExchangeRate = 1,
                    IsActive = true
                },

                new CurrencyMaster
                {
                    Id = 6,
                    Code = "OMR",
                    Name = "Omani Rial",
                    Symbol = "ر.ع",
                    Country = "Oman",
                    ExchangeRate = 1,
                    IsActive = true
                },

                new CurrencyMaster
                {
                    Id = 7,
                    Code = "KWD",
                    Name = "Kuwaiti Dinar",
                    Symbol = "د.ك",
                    Country = "Kuwait",
                    ExchangeRate = 1,
                    IsActive = true
                },

                new CurrencyMaster
                {
                    Id = 8,
                    Code = "BGN",
                    Name = "Bulgarian Lev",
                    Symbol = "лв",
                    Country = "Bulgaria",
                    ExchangeRate = 1,
                    IsActive = true
                },

                new CurrencyMaster
                {
                    Id = 9,
                    Code = "HRK",
                    Name = "Croatian Kuna",
                    Symbol = "kn",
                    Country = "Croatia",
                    ExchangeRate = 1,
                    IsActive = true
                },

                new CurrencyMaster
                {
                    Id = 10,
                    Code = "CZK",
                    Name = "Czech Koruna",
                    Symbol = "Kč",
                    Country = "Czech Republic",
                    ExchangeRate = 1,
                    IsActive = true
                },

                new CurrencyMaster
                {
                    Id = 11,
                    Code = "DKK",
                    Name = "Danish Krone",
                    Symbol = "kr",
                    Country = "Denmark",
                    ExchangeRate = 1,
                    IsActive = true
                },

                new CurrencyMaster
                {
                    Id = 12,
                    Code = "EUR",
                    Name = "Euro",
                    Symbol = "€",
                    Country = "European Union",
                    ExchangeRate = 1,
                    IsActive = true
                },

                new CurrencyMaster
                {
                    Id = 13,
                    Code = "GBP",
                    Name = "Pound Sterling",
                    Symbol = "£",
                    Country = "United Kingdom",
                    ExchangeRate = 1,
                    IsActive = true
                },

                new CurrencyMaster
                {
                    Id = 14,
                    Code = "HUF",
                    Name = "Hungarian Forint",
                    Symbol = "Ft",
                    Country = "Hungary",
                    ExchangeRate = 1,
                    IsActive = true
                },

                new CurrencyMaster
                {
                    Id = 15,
                    Code = "ISK",
                    Name = "Icelandic Króna",
                    Symbol = "kr",
                    Country = "Iceland",
                    ExchangeRate = 1,
                    IsActive = true
                },

                new CurrencyMaster
                {
                    Id = 16,
                    Code = "JPY",
                    Name = "Japanese Yen",
                    Symbol = "¥",
                    Country = "Japan",
                    ExchangeRate = 1,
                    IsActive = true
                },

                new CurrencyMaster
                {
                    Id = 17,
                    Code = "NOK",
                    Name = "Norwegian Krone",
                    Symbol = "kr",
                    Country = "Norway",
                    ExchangeRate = 1,
                    IsActive = true
                },

                new CurrencyMaster
                {
                    Id = 18,
                    Code = "PLN",
                    Name = "Polish Złoty",
                    Symbol = "zł",
                    Country = "Poland",
                    ExchangeRate = 1,
                    IsActive = true
                },

                new CurrencyMaster
                {
                    Id = 19,
                    Code = "RON",
                    Name = "Romanian Leu",
                    Symbol = "lei",
                    Country = "Romania",
                    ExchangeRate = 1,
                    IsActive = true
                },

                new CurrencyMaster
                {
                    Id = 20,
                    Code = "SEK",
                    Name = "Swedish Krona",
                    Symbol = "kr",
                    Country = "Sweden",
                    ExchangeRate = 1,
                    IsActive = true
                },

                new CurrencyMaster
                {
                    Id = 21,
                    Code = "USD",
                    Name = "United States Dollar",
                    Symbol = "$",
                    Country = "United States",
                    ExchangeRate = 1,
                    IsActive = true
                },
            };

            entity.HasData(roles);
        }
    }

}
