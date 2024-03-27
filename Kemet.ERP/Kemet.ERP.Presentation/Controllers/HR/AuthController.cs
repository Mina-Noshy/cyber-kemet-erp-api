using Kemet.ERP.Abstraction;
using Kemet.ERP.Contracts.HR;
using Kemet.ERP.Presentation.Controllers.Routing;
using Microsoft.AspNetCore.Mvc;

namespace Kemet.ERP.Presentation.Controllers.HR
{
    //[ApiKeyAuth]
    public class AuthController : BaseHRController
    {
        private readonly IHRServiceManager _hrServiceManager;
        public AuthController(IHRServiceManager hrServiceManager)
            => _hrServiceManager = hrServiceManager;





        [HttpGet("get-roles")]
        public async Task<IActionResult> GetRolesAsync(CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.AuthService.GetRolesAsync(cancellationToken));

        [HttpGet("get-role/{id}")]
        public async Task<IActionResult> GetRoleByIdAsync(string id, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.AuthService.GetRoleByIdAsync(id, cancellationToken));

        [HttpPost("get-token")]
        public async Task<IActionResult> GetTokenAsync(GetTokenDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.AuthService.GetTokenAsync(request, cancellationToken));

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshTokenAsync(TokenDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.AuthService.RefreshTokenAsync(request, cancellationToken));

        [HttpPost("revoke-token")]
        public async Task<IActionResult> RevokeTokenAsync(TokenDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.AuthService.RevokeTokenAsync(request, cancellationToken));

        [HttpPost("add-user-role")]
        public async Task<IActionResult> AddUserRoleAsync(UserToRoleDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.AuthService.AddUserRoleAsync(request, cancellationToken));

        [HttpPost("remove-user-role")]
        public async Task<IActionResult> RemoveUserRoleAsync(UserToRoleDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.AuthService.RemoveUserRoleAsync(request, cancellationToken));

        [HttpPost("create-role")]
        public async Task<IActionResult> CreateRoleAsync(RoleCommandDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _hrServiceManager.AuthService.CreateRoleAsync(request.Role, cancellationToken));

        [HttpDelete("delete-role")]
        public async Task<IActionResult> DeleteRoleAsync(RoleCommandDto request, CancellationToken cancellationToken)
           => FormatHttpResponse(await _hrServiceManager.AuthService.DeleteRoleAsync(request.Role, cancellationToken));
    }
}
