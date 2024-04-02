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
        public AccountService(IAccountRepository accountRepository)
            => _accountRepository = accountRepository;



        public async Task<ApiResponse> CreateUserAsync(CreateUserDto request, CancellationToken cancellationToken = default)
        {
            var entity =
                request.Adapt<AppUser>();

            var user =
                await _accountRepository.CreateUserAsync(entity, request.Password, cancellationToken);

            if (user is null)
                return new ApiResponse(false, "Failed to create the user. Please check your input and try again later");

            return new ApiResponse(true, "The user has been created successfully");
        }

        public async Task<ApiResponse> GetUsersAsync(int skip, int take, CancellationToken cancellationToken = default)
        {
            var lst =
                await _accountRepository.GetUsersAsync(skip, take, cancellationToken);

            var lstDto =
                lst.Adapt<IEnumerable<AppUserDto>>();

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

    }
}
