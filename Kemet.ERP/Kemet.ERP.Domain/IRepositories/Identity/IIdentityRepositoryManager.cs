using Kemet.ERP.Domain.IRepositories.Shared;

namespace Kemet.ERP.Domain.IRepositories.Identity
{
    public interface IIdentityRepositoryManager : ISharedRepository
    {
        IAuthRepository AuthRepository { get; }
        IAccountRepository AccountRepository { get; }
    }
}
