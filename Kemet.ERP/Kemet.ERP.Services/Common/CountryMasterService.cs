using Kemet.ERP.Abstraction.Common;
using Kemet.ERP.Contracts.Common;
using Kemet.ERP.Contracts.Response;
using Kemet.ERP.Domain.Entities.Common;
using Kemet.ERP.Domain.Exceptions;
using Kemet.ERP.Domain.IRepositories;
using Kemet.ERP.Domain.IRepositories.App;
using Kemet.ERP.Shared.Constants;
using Mapster;

namespace Kemet.ERP.Services.Common
{
    public class CountryMasterService : ICountryMasterService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCacheRepository _cacheRepository;

        public CountryMasterService(IUnitOfWork unitOfWork, IMemoryCacheRepository cacheRepository)
            => (_unitOfWork, _cacheRepository) = (unitOfWork, cacheRepository);



        public async Task<ApiResponse> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var lst =
                _cacheRepository.Get<IEnumerable<CountryMaster>>(CacheServiceKeys.CountryList);

            if (lst is null)
                lst = await SetCountryCache(cancellationToken);

            var lstDto =
                lst.Adapt<IEnumerable<CountryMasterDto>>();

            return new ApiResponse(true, lstDto);
        }

        public async Task<ApiResponse> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity =
                await _unitOfWork.Repository().GetByIdAsync<CountryMaster>(id, cancellationToken);

            if (entity is null)
                throw new EntityNotFoundException<CountryMaster>(id);

            var entityDto =
                entity.Adapt<CountryMasterDto>();

            return new ApiResponse(true, entityDto);
        }


        public async Task<ApiResponse> CreateAsync(CountryMasterDto request, CancellationToken cancellationToken = default)
        {
            var entity =
                request.Adapt<CountryMaster>();

            _unitOfWork.Repository().Add<CountryMaster>(entity);

            var effectedRows =
                await _unitOfWork.CommitAsync(cancellationToken);

            if (effectedRows > 0)
                return new ApiResponse(true, ApiMessage.SuccessfulCreate);

            return new ApiResponse(false, ApiMessage.FailedCreate);
        }

        public async Task<ApiResponse> UpdateAsync(CountryMasterDto request, CancellationToken cancellationToken = default)
        {
            var entity =
                request.Adapt<CountryMaster>();

            _unitOfWork.Repository().Update<CountryMaster>(entity);

            var effectedRows =
                await _unitOfWork.CommitAsync(cancellationToken);

            if (effectedRows > 0)
                return new ApiResponse(true, ApiMessage.SuccessfulUpdate);

            return new ApiResponse(false, ApiMessage.FailedUpdate);
        }

        public async Task<ApiResponse> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity =
                await _unitOfWork.Repository().GetByIdAsync<CountryMaster>(id, cancellationToken);

            if (entity is null)
                throw new EntityNotFoundException<CountryMaster>(id);

            _unitOfWork.Repository().Remove<CountryMaster>(entity);

            var effectedRows =
                await _unitOfWork.CommitAsync(cancellationToken);

            if (effectedRows > 0)
                return new ApiResponse(true, ApiMessage.SuccessfulDelete);

            return new ApiResponse(false, ApiMessage.FailedDelete);
        }

        private async Task<IEnumerable<CountryMaster>> SetCountryCache(CancellationToken cancellationToken)
        {
            var lst =
                await _unitOfWork.Repository().GetAllAsync<CountryMaster>(cancellationToken);

            _cacheRepository.Set(CacheServiceKeys.CountryList, lst, TimeSpan.FromHours(1));

            return lst;
        }

    }
}
