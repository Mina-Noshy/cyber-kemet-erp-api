using Kemet.ERP.Abstraction.Identity;
using Kemet.ERP.Contracts.Identity;
using Kemet.ERP.Contracts.Response;
using Kemet.ERP.Domain.Entities.Identity;
using Kemet.ERP.Domain.IRepositories.Identity;
using Mapster;

namespace Kemet.ERP.Services.Identity
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAuthRepository _authRepository;
        public AccountService(IAccountRepository accountRepository, IAuthRepository authRepository)
            => (_accountRepository, _authRepository) = (accountRepository, authRepository);



        public async Task<ApiResponse> CreateUserAsync(CreateUserDto request, CancellationToken cancellationToken = default)
        {
            var entity =
                request.Adapt<AppUser>();

            var user =
                await _accountRepository.CreateUserAsync(entity, request.Password, cancellationToken);

            if (user is null)
                return new ApiResponse(false, "Failed to create the user. Please check your input and try again later");

            await SendConfirmationEmailAsync(request.Email);

            return new ApiResponse(true, "The user has been created successfully, Please check your email inbox");
        }

        public async Task<ApiResponse> GetUsersAsync(int skip, int take, CancellationToken cancellationToken = default)
        {
            var lst =
                await _accountRepository.GetUsersAsync(skip, take, cancellationToken);

            var lstDto =
                new List<AppUserDto>();

            foreach (var item in lst)
            {
                var userDro =
                    item.Adapt<AppUserDto>();

                userDro.Roles =
                    (List<string>)await _authRepository.GetUserRolesAsync(item);

                lstDto.Add(userDro);
            }

            return new ApiResponse(true, lstDto);
        }

        public async Task<ApiResponse> GetUserByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity =
                await _accountRepository.GetUserByIdAsync(id, cancellationToken);

            if (entity is null)
                return new ApiResponse(false, $"Account with ID '{id}' was not found.");

            var entityDto =
                entity.Adapt<AppUserDto>();

            return new ApiResponse(true, entityDto);
        }

        public async Task<ApiResponse> ConfirmEmailAsync(string userId, string token, CancellationToken cancellationToken = default)
        {
            var user =
                await _accountRepository.ConfirmEmailAsync(userId, token, cancellationToken);

            if (user is null)
                return new ApiResponse(false, "We couldn't find an account associated with the provided email address. Please ensure you've entered the correct email address.");

            return new ApiResponse(true, "Email confirmed successfully. You can now log in to your account.");
        }

        public async Task<ApiResponse> SendConfirmationEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            var user =
                await _accountRepository.SendConfirmationEmailAsync(email, cancellationToken);

            if (user is null)
                return new ApiResponse(false, $"We couldn't find an account associated with the provided email address '{email}'.");

            return new ApiResponse(true, "Confirmation email has been successfully dispatched, Please check your inbox");
        }
    }
}
