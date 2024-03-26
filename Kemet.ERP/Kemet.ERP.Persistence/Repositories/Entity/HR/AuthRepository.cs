using Kemet.ERP.Domain.Entities.HR;
using Kemet.ERP.Domain.IRepositories.IEntity.HR;
using Kemet.ERP.Persistence.Contexts;
using Microsoft.AspNetCore.Identity;

namespace Kemet.ERP.Persistence.Repositories.Entity.HR
{
    internal class AuthRepository : IAuthRepository
    {
        private readonly RepositoryDbContext _dbContext;
        private readonly UserManager<AppUser> _userManager;
        public AuthRepository(RepositoryDbContext dbContext, UserManager<AppUser> userManager)
            => (_dbContext, _userManager) = (dbContext, userManager);





        public async Task<bool> CheckPasswordAsync(AppUser user, string password, CancellationToken cancellationToken = default)
            => await _userManager.CheckPasswordAsync(user, password);

        public async Task<IEnumerable<string>> GetRolesAsync(AppUser user, CancellationToken cancellationToken = default)
            => await _userManager.GetRolesAsync(user);

        public void Update(AppUser user)
            => _dbContext.Update(user);

    }
}
