using Kemet.ERP.Abstraction.Identity;
using Kemet.ERP.Contracts.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Kemet.ERP.Presentation.Controllers.Identity
{
    public class AuthController : BaseIdentityController
    {
        private readonly IAuthService _service;
        public AuthController(IAuthService service)
            => _service = service;





        [HttpPost("get-token")]
        public async Task<IActionResult> GetTokenAsync(GetTokenDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.GetTokenAsync(request, cancellationToken));

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshTokenAsync(TokenDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.RefreshTokenAsync(request, cancellationToken));

        [HttpPost("revoke-token")]
        public async Task<IActionResult> RevokeTokenAsync(TokenDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.RevokeTokenAsync(request, cancellationToken));

        [HttpPost("add-user-role")]
        public async Task<IActionResult> AddUserRoleAsync(UserToRoleDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.AddUserRoleAsync(request, cancellationToken));

        [HttpPost("remove-user-role")]
        public async Task<IActionResult> RemoveUserRoleAsync(UserToRoleDto request, CancellationToken cancellationToken)
            => FormatHttpResponse(await _service.RemoveUserRoleAsync(request, cancellationToken));

    }
}
