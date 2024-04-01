using Kemet.ERP.Abstraction.Shared;

namespace Kemet.ERP.Abstraction.Identity
{
    public interface IIdentityServiceManager : ISharedService
    {
        IAccountService AccountService { get; }
        IAuthService AuthService { get; }
    }
}
