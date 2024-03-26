using Kemet.ERP.Domain.Entities.HR;

namespace Kemet.ERP.Domain.IRepositories.IEntity.HR
{
    public interface IAuthRepository
    {
        Task<bool> CheckPasswordAsync(AppUser user, string password, CancellationToken cancellationToken = default);
        Task<IEnumerable<string>> GetRolesAsync(AppUser user, CancellationToken cancellationToken = default);
        void Update(AppUser user);
    }
}
