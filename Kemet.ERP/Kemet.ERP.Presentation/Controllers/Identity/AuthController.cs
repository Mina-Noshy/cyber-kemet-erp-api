using Kemet.ERP.Abstraction.Identity;
using Kemet.ERP.Contracts.Identity;
using Kemet.ERP.Presentation.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Kemet.ERP.Presentation.Controllers.Identity
{
    [ApiKeyAuth]
    public class AuthController : BaseIdentityController
    {
        private readonly IIdentityServiceManager _serviceManager;
        public AuthController(IIdentityServiceManager serviceManager)
            => _serviceManager = serviceManager;





        [HttpGet("get-roles")]
        public async Task<IActionResult> GetRolesAsync(CancellationToken cancellationToken)
            => FormatHttpResponse(await _serviceManager.AuthService.GetRolesAsync(cancellationToken));

        [HttpGet("get-role/{id}")]
        public async Task<IActionResult> GetRoleByIdAsync(string id, CancellationToken cancellationToken)
            => FormatHttpResponse(await _serviceManager.AuthService.GetRoleByIdAsync(id, cancellationToken));

        [HttpPost("get-token")]
        public async Task<IActionResult> GetTokenAsync(GetTokenDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _serviceManager.AuthService.GetTokenAsync(request, cancellationToken));

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshTokenAsync(TokenDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _serviceManager.AuthService.RefreshTokenAsync(request, cancellationToken));

        [HttpPost("revoke-token")]
        public async Task<IActionResult> RevokeTokenAsync(TokenDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _serviceManager.AuthService.RevokeTokenAsync(request, cancellationToken));

        [HttpPost("add-user-role")]
        public async Task<IActionResult> AddUserRoleAsync(UserToRoleDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _serviceManager.AuthService.AddUserRoleAsync(request, cancellationToken));

        [HttpPost("remove-user-role")]
        public async Task<IActionResult> RemoveUserRoleAsync(UserToRoleDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _serviceManager.AuthService.RemoveUserRoleAsync(request, cancellationToken));

        [HttpPost("create-role")]
        public async Task<IActionResult> CreateRoleAsync(RoleCommandDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _serviceManager.AuthService.CreateRoleAsync(request.Role, cancellationToken));

        [HttpDelete("delete-role")]
        public async Task<IActionResult> DeleteRoleAsync(RoleCommandDto request, CancellationToken cancellationToken)
           => FormatHttpResponse(await _serviceManager.AuthService.DeleteRoleAsync(request.Role, cancellationToken));
    }
}
