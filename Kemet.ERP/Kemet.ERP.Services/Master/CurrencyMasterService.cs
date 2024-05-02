using Kemet.ERP.Abstraction.Master;
using Kemet.ERP.Contracts.Master;
using Kemet.ERP.Contracts.Response;
using Kemet.ERP.Domain.Entities.Master;
using Kemet.ERP.Domain.Exceptions;
using Kemet.ERP.Domain.IRepositories;
using Mapster;

namespace Kemet.ERP.Services.Master
{
    internal class CurrencyMasterService : ICurrencyMasterService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CurrencyMasterService(IUnitOfWork unitOfWork)
                => _unitOfWork = unitOfWork;



        public async Task<ApiResponse> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var lst =
                await _unitOfWork.Repository().GetAllAsync<CurrencyMaster>(null, null, null, cancellationToken);

            var lstDto =
                lst.Adapt<IEnumerable<CurrencyMasterDto>>();

            return new ApiResponse(true, lstDto);
        }

        public async Task<ApiResponse> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity =
                await _unitOfWork.Repository().GetByIdAsync<CurrencyMaster>(id, cancellationToken);

            if (entity is null)
                throw new EntityNotFoundException<CurrencyMaster>(id);

            var entityDto =
                entity.Adapt<CurrencyMasterDto>();

            return new ApiResponse(true, entityDto);
        }

        public async Task<ApiResponse> GetLightAsync(CancellationToken cancellationToken = default)
        {
            var lst =
                await _unitOfWork.Repository().GetDynamicAsync<CurrencyMaster>(null,
                x => new { x.Code, x.Name },
                x => x.OrderBy(x => x.Code),
                cancellationToken);

            return new ApiResponse(true, lst);
        }

        public async Task<ApiResponse> CreateAsync(CurrencyMasterDto request, CancellationToken cancellationToken = default)
        {
            var entity =
                request.Adapt<CurrencyMaster>();

            _unitOfWork.Repository().Add(entity);

            var effectedRows =
                await _unitOfWork.CommitAsync(cancellationToken);

            if (effectedRows > 0)
                return new ApiResponse(true, ApiMessage.SuccessfulCreate);

            return new ApiResponse(false, ApiMessage.FailedCreate);
        }

        public async Task<ApiResponse> UpdateAsync(long id, CurrencyMasterDto request, CancellationToken cancellationToken = default)
        {
            if (id != request.Id)
                return new ApiResponse(false, ApiMessage.EntityIdMismatch);

            var entity =
                request.Adapt<CurrencyMaster>();

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
                await _unitOfWork.Repository().GetByIdAsync<CurrencyMaster>(id, cancellationToken);

            if (entity is null)
                throw new EntityNotFoundException<CurrencyMaster>(id);

            _unitOfWork.Repository().Remove(entity);

            var effectedRows =
                await _unitOfWork.CommitAsync(cancellationToken);

            if (effectedRows > 0)
                return new ApiResponse(true, ApiMessage.SuccessfulDelete);

            return new ApiResponse(false, ApiMessage.FailedDelete);
        }

    }
}
