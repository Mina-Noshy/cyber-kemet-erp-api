using Kemet.ERP.Abstraction.IEntity.HR;
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




        public async Task<ApiResponse> GetAllAsync(int skip, int take, CancellationToken cancellationToken = default)
        {
            var lst =
                _hrRepositoryManager.MemoryCacheRepository.Get<IEnumerable<Country>>(CacheServiceKeys.CountryList);

            if (lst is null)
                lst = await SetCountryCache(cancellationToken);

            var lstDto =
                lst.Adapt<IEnumerable<CountryDto>>();

            lstDto =
                lstDto.Skip(skip).Take(take);

            return new ApiResponse(true, lstDto);
        }

        public async Task<ApiResponse> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity =
                await _hrRepositoryManager.CountryRepository.GetByIdAsync(id, cancellationToken);

            if (entity is null)
                throw new EntityNotFoundException<Country>(id);

            var entityDto =
                entity.Adapt<CountryDto>();

            return new ApiResponse(true, entityDto);
        }


        public async Task<ApiResponse> CreateAsync(CountryDto request, CancellationToken cancellationToken = default)
        {
            var entity =
                request.Adapt<Country>();

            _hrRepositoryManager.CountryRepository.Create(entity);

            var effectedRows =
                await _hrRepositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            if (effectedRows > 0)
                return new ApiResponse(true, ApiMessage.SuccessfulCreate);

            return new ApiResponse(false, ApiMessage.FailedCreate);
        }

        public async Task<ApiResponse> UpdateAsync(CountryDto request, CancellationToken cancellationToken = default)
        {
            var entity =
                request.Adapt<Country>();

            _hrRepositoryManager.CountryRepository.Update(entity);

            var effectedRows =
                await _hrRepositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            if (effectedRows > 0)
                return new ApiResponse(true, ApiMessage.SuccessfulUpdate);

            return new ApiResponse(false, ApiMessage.FailedUpdate);
        }

        public async Task<ApiResponse> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity =
                await _hrRepositoryManager.CountryRepository.GetByIdAsync(id, cancellationToken);

            if (entity is null)
                throw new EntityNotFoundException<Country>(id);

            _hrRepositoryManager.CountryRepository.Delete(entity);

            var effectedRows =
                await _hrRepositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            if (effectedRows > 0)
                return new ApiResponse(true, ApiMessage.SuccessfulDelete);

            return new ApiResponse(false, ApiMessage.FailedDelete);
        }

        private async Task<IEnumerable<Country>> SetCountryCache(CancellationToken cancellationToken)
        {
            var lst =
                await _hrRepositoryManager.CountryRepository.GetAllAsync(0, 1000, cancellationToken);

            _hrRepositoryManager.MemoryCacheRepository.Set(CacheServiceKeys.CountryList, lst, TimeSpan.FromHours(1));

            return lst;
        }
    }
}
