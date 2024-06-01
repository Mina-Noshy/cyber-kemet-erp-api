using Kemet.ERP.Domain.Common.Constants;
using Kemet.ERP.Domain.Entities.HR.HrDatabase;
using Kemet.ERP.Domain.Entities.HR.Master;
using Kemet.ERP.Domain.Entities.Identity;
using Kemet.ERP.Domain.Entities.Master;
using Kemet.ERP.Domain.Entities.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Kemet.ERP.Persistence.Contexts
{
    public class MainDbContext : IdentityDbContext<AppUser, IdentityRole, string>, IMainDbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options, IHttpContextAccessor accessor) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            // to change the db connection if the request has a db name in header
            string newDbName = accessor?.HttpContext?.Items[HttpContextKeys.DB]?.ToString() ?? string.Empty;
            if (!string.IsNullOrEmpty(newDbName))
            {
                string newDbConn = Database?.GetConnectionString()?.Replace(Database.GetDbConnection().Database, newDbName) ?? string.Empty;
                Database?.SetConnectionString(newDbConn);
            }
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            foreach (var item in ChangeTracker.Entries<TEntity>().AsEnumerable())
            {
                //Auto Timestamp
                //item.Entity.CreatedOn = DateTime.Now;
            }
            return base.SaveChangesAsync(cancellationToken);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure customizations for Identity tables
            modelBuilder.Entity<AppUser>().ToTable("UserMaster");
            modelBuilder.Entity<IdentityRole>().ToTable("RoleMaster");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoleMaster");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");


            // Apply all entities configuration
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MainDbContext).Assembly);

        }





        #region Identity Module

        public DbSet<ModuleMaster> ModuleMaster { get; set; }
        public DbSet<MenuMaster> MenuMaster { get; set; }
        public DbSet<PageMaster> PageMaster { get; set; }
        public DbSet<RolePageMaster> RolePageMaster { get; set; }

        #endregion


        #region Master Module

        public DbSet<CountryMaster> CountryMaster { get; set; }
        public DbSet<CityMaster> CityMaster { get; set; }
        public DbSet<BankMaster> BankMaster { get; set; }
        public DbSet<CurrencyMaster> CurrencyMaster { get; set; }

        #endregion


        #region HR Module

        // Master
        public DbSet<CompanyMaster> CompanyMaster { get; set; }
        public DbSet<BranchMaster> BranchMaster { get; set; }
        public DbSet<JobTitleMaster> JobTitleMaster { get; set; }
        public DbSet<DepartmentMaster> DepartmentMaster { get; set; }
        public DbSet<EmploymentStatusMaster> EmploymentStatusMaster { get; set; }
        public DbSet<EmploymentTypeMaster> EmploymentTypeMaster { get; set; }

        // HR Database
        public DbSet<EmployeeBankAccount> EmployeeBankAccounts { get; set; }
        public DbSet<EmployeeContactInformation> EmployeeContactInformations { get; set; }
        public DbSet<EmployeeEmergencyContact> EmployeeEmergencyContacts { get; set; }
        public DbSet<EmployeeMaster> EmployeeMaster { get; set; }
        public DbSet<EmploymentHistory> EmploymentHistories { get; set; }
        public DbSet<EmploymentStatus> EmploymentStatuses { get; set; }
        public DbSet<EmploymentType> EmploymentTypes { get; set; }
        public DbSet<EmployeePersonalInformation> EmployeePersonalInformations { get; set; }
        public DbSet<EmployeeTaxProfile> EmployeeTaxProfiles { get; set; }
        public DbSet<EmployeeDependent> EmployeeDependents { get; set; }

        #endregion

    }
}
