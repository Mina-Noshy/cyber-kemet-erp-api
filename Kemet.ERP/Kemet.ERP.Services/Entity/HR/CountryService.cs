using Kemet.ERP.Abstraction.IEntity.HR;
using Kemet.ERP.Contracts;
using Kemet.ERP.Contracts.HR;
using Kemet.ERP.Contracts.HttpResponse;
using Kemet.ERP.Domain.Entities.HR;
using Kemet.ERP.Domain.Exceptions;
using Kemet.ERP.Domain.IRepositories;
using Kemet.ERP.Shared.Constants;
using Mapster;

namespace Kemet.ERP.Services.Entity.HR
{
    internal class CountryService : ICountryService
    {
        private readonly IHRRepositoryManager _hrRepositoryManager;
        public CountryService(IHRRepositoryManager hrRepositoryManager)
            => _hrRepositoryManager = hrRepositoryManager;




        public async Task<ApiResponse> GetAllAsync(PaginationDto request, CancellationToken cancellationToken = default)
        {
            var lst = _hrRepositoryManager.MemoryCacheRepository.Get<IEnumerable<Country>>(CacheServiceKeys.CountryList);

            if (lst is null)
                lst = await SetCountryCache(cancellationToken);

            var lstDto = lst
                .Skip(request.Skip)
                .Take(request.Take)
                .Adapt<IEnumerable<CountryDto>>();

            return new ApiResponse(true, lstDto);
        }

        public async Task<ApiResponse> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await _hrRepositoryManager.CountryRepository.GetByIdAsync(id, cancellationToken);

            if (entity is null)
            {
                throw new EntityNotFoundException<Country>(id);
            }

            var entityDto = entity.Adapt<CountryDto>();

            return new ApiResponse(true, entityDto);
        }

        private async Task<IEnumerable<Country>> SetCountryCache(CancellationToken cancellationToken)
        {
            var lst = await _hrRepositoryManager.CountryRepository.GetAllAsync(0, 1000, cancellationToken);
            _hrRepositoryManager.MemoryCacheRepository.Set(CacheServiceKeys.CountryList, lst, TimeSpan.FromDays(1));
            return lst;
        }
    }
}
