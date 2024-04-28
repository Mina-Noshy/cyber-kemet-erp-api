using Kemet.ERP.Abstraction.Master;
using Kemet.ERP.Contracts.Master;
using Kemet.ERP.Contracts.Response;
using Kemet.ERP.Domain.Entities.Master;
using Kemet.ERP.Domain.Exceptions;
using Kemet.ERP.Domain.IRepositories;
using Kemet.ERP.Domain.IRepositories.App;
using Mapster;

namespace Kemet.ERP.Services.Master
{
    public class CountryMasterService : ICountryMasterService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCacheRepository _cacheRepository;
        private readonly IRequestHandlingRepository _request;

        public CountryMasterService(IUnitOfWork unitOfWork,
            IMemoryCacheRepository cacheRepository,
            IRequestHandlingRepository request)
                => (_unitOfWork, _cacheRepository, _request) = (unitOfWork, cacheRepository, request);



        public async Task<ApiResponse> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var lst =
                await _unitOfWork.Repository().GetAllAsync<CountryMaster>(null, null, null, cancellationToken);

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

        public async Task<ApiResponse> GetLightAsync(CancellationToken cancellationToken = default)
        {
            var lst =
                await _unitOfWork.Repository().GetDynamicAsync<CountryMaster>(null,
                x => new { x.Id, Name = x.Name },
                x => x.OrderBy(x => x.Name),
                cancellationToken);

            return new ApiResponse(true, lst);
        }

        public async Task<ApiResponse> CreateAsync(CountryMasterDto request, CancellationToken cancellationToken = default)
        {
            var entity =
                request.Adapt<CountryMaster>();

            _unitOfWork.Repository().Add(entity);

            var effectedRows =
                await _unitOfWork.CommitAsync(cancellationToken);

            if (effectedRows > 0)
                return new ApiResponse(true, ApiMessage.SuccessfulCreate);

            return new ApiResponse(false, ApiMessage.FailedCreate);
        }

        public async Task<ApiResponse> UpdateAsync(long id, CountryMasterDto request, CancellationToken cancellationToken = default)
        {
            if (id != request.Id)
                return new ApiResponse(false, ApiMessage.EntityIdMismatch);

            var entity =
                request.Adapt<CountryMaster>();

            _unitOfWork.Repository().Update(entity);

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

            _unitOfWork.Repository().Remove(entity);

            var effectedRows =
                await _unitOfWork.CommitAsync(cancellationToken);

            if (effectedRows > 0)
                return new ApiResponse(true, ApiMessage.SuccessfulDelete);

            return new ApiResponse(false, ApiMessage.FailedDelete);
        }

    }
}