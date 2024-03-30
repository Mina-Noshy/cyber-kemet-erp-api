using Kemet.ERP.Abstraction.HR.Identity;
using Kemet.ERP.Contracts.HR.Identity;
using Kemet.ERP.Contracts.Response;
using Kemet.ERP.Domain.Entities.HR.Identity;
using Kemet.ERP.Domain.IRepositories;
using Mapster;

namespace Kemet.ERP.Services.HR.Identity
{
    internal class AccountService : IAccountService
    {
        private readonly IHRRepositoryManager _hrRepositoryManager;
        public AccountService(IHRRepositoryManager hrRepositoryManager)
            => _hrRepositoryManager = hrRepositoryManager;



        public async Task<ApiResponse> CreateUserAsync(CreateUserDto request, CancellationToken cancellationToken = default)
        {
            var entity =
                request.Adapt<AppUser>();

            var user =
                await _hrRepositoryManager.AccountRepository.CreateUserAsync(entity, request.Password, cancellationToken);

            if (user is null)
                return new ApiResponse(false, "Failed to create the user. Please check your input and try again later");

            return new ApiResponse(true, "The user has been created successfully");
        }

        public async Task<ApiResponse> GetUsersAsync(int skip, int take, CancellationToken cancellationToken = default)
        {
            var lst =
                await _hrRepositoryManager.AccountRepository.GetUsersAsync(skip, take, cancellationToken);

            var lstDto =
                lst.Adapt<IEnumerable<AppUserDto>>();

            return new ApiResponse(true, lstDto);
        }

        public async Task<ApiResponse> GetUserByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity =
                await _hrRepositoryManager.AccountRepository.GetUserByIdAsync(id, cancellationToken);

            if (entity is null)
                return new ApiResponse(false, $"Account with ID '{id}' was not found.");

            var entityDto =
                entity.Adapt<AppUserDto>();

            return new ApiResponse(true, entityDto);
        }

    }
}
