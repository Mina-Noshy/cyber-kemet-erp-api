using Kemet.ERP.Domain.Entities.HR;
using Kemet.ERP.Shared.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Kemet.ERP.Persistence.Contexts
{
    public class RepositoryDbContext : IdentityDbContext<AppUser, IdentityRole, string>
    {
        public IDbConnection Connection => Database.GetDbConnection();

        public RepositoryDbContext(DbContextOptions<RepositoryDbContext> options, IHttpContextAccessor accessor) : base(options)
        {
            // to change the db connection if the request has a db name is the request header
            string newDbName = accessor?.HttpContext?.Items[HttpContextKeys.DB]?.ToString() ?? string.Empty;
            if (!string.IsNullOrEmpty(newDbName))
            {
                string newDbConn = Database?.GetConnectionString()?.Replace(Database.GetDbConnection().Database, newDbName) ?? string.Empty;
                Database?.SetConnectionString(newDbConn);
            }
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
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RepositoryDbContext).Assembly);
        }


        public DbSet<Country> Countries { get; set; }
        public DbSet<Region> Regions { get; set; }

    }
}
