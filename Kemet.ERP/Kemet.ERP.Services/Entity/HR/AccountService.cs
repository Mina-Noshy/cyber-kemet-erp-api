using Kemet.ERP.Abstraction.IEntity.HR;
using Kemet.ERP.Contracts;
using Kemet.ERP.Contracts.HR;
using Kemet.ERP.Contracts.HttpResponse;
using Kemet.ERP.Domain.Entities.HR;
using Kemet.ERP.Domain.IRepositories;
using Mapster;

namespace Kemet.ERP.Services.Entity.HR
{
    internal class AccountService : IAccountService
    {
        private readonly IHRRepositoryManager _hrRepositoryManager;
        public AccountService(IHRRepositoryManager hrRepositoryManager)
            => _hrRepositoryManager = hrRepositoryManager;



        public async Task<ApiResponse> CreateAsync(CreateUserDto request, CancellationToken cancellationToken = default)
        {
            var entity = request.Adapt<AppUser>();

            var user = await _hrRepositoryManager.AccountRepository.CreateAsync(entity, request.Password);

            if (user is null)
                return new ApiResponse(false, "Failed to create the account. Please check your input and try again later");

            return new ApiResponse(true, "The account has been created successfully");
        }

        public async Task<ApiResponse> GetAllAsync(PaginationDto request, CancellationToken cancellationToken = default)
        {
            var lst = await _hrRepositoryManager.AccountRepository.GetAllAsync(request.Skip, request.Take, cancellationToken);

            var lstDto = lst.Adapt<IEnumerable<UserInfoDto>>();

            return new ApiResponse(true, lstDto);
        }

        public async Task<ApiResponse> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            var entity = await _hrRepositoryManager.AccountRepository.GetByEmailAsync(email, cancellationToken);

            if (entity is null)
            {
                return new ApiResponse(false, $"Account with email '{email}' not found.");
            }

            var entityDto = entity.Adapt<AppUserDto>();

            return new ApiResponse(true, entityDto);
        }

        public async Task<ApiResponse> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity = await _hrRepositoryManager.AccountRepository.GetByIdAsync(id, cancellationToken);

            if (entity is null)
            {
                return new ApiResponse(false, $"Account with id '{id}' not found.");
            }

            var entityDto = entity.Adapt<AppUserDto>();

            return new ApiResponse(true, entityDto);
        }

        public async Task<ApiResponse> GetByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            var entity = await _hrRepositoryManager.AccountRepository.GetByNameAsync(name, cancellationToken);

            if (entity is null)
            {
                return new ApiResponse(false, $"Account with name '{name}' not found.");
            }

            var entityDto = entity.Adapt<AppUserDto>();

            return new ApiResponse(true, entityDto);
        }
    }
}
