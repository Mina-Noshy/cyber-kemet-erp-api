using Kemet.ERP.Abstraction.HR.Master;
using Kemet.ERP.Contracts.HR.Master;
using Kemet.ERP.Contracts.Response;
using Kemet.ERP.Domain.Entities.HR.Master;
using Kemet.ERP.Domain.Exceptions;
using Kemet.ERP.Domain.IRepositories;
using Mapster;

namespace Kemet.ERP.Services.HR.Master
{
    internal class EmploymentStatusMasterService : IEmploymentStatusMasterService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmploymentStatusMasterService(IUnitOfWork unitOfWork)
                => _unitOfWork = unitOfWork;



        public async Task<ApiResponse> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var lst =
                await _unitOfWork.Repository().GetAllAsync<EmploymentStatusMaster>(null, null, null, cancellationToken);

            var lstDto =
                lst.Adapt<IEnumerable<EmploymentStatusMasterDto>>();

            return new ApiResponse(true, lstDto);
        }

        public async Task<ApiResponse> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity =
                await _unitOfWork.Repository().GetByIdAsync<EmploymentStatusMaster>(id, cancellationToken);

            if (entity is null)
                throw new EntityNotFoundException<EmploymentStatusMaster>(id);

            var entityDto =
                entity.Adapt<EmploymentStatusMasterDto>();

            return new ApiResponse(true, entityDto);
        }

        public async Task<ApiResponse> GetLightAsync(CancellationToken cancellationToken = default)
        {
            var lst =
                await _unitOfWork.Repository().GetDynamicAsync<EmploymentStatusMaster>(null,
                x => new { x.Id, x.Name },
                x => x.OrderBy(x => x.Name),
                cancellationToken);

            return new ApiResponse(true, lst);
        }

        public async Task<ApiResponse> CreateAsync(EmploymentStatusMasterDto request, CancellationToken cancellationToken = default)
        {
            var entity =
                request.Adapt<EmploymentStatusMaster>();

            _unitOfWork.Repository().Add(entity);

            var effectedRows =
                await _unitOfWork.CommitAsync(cancellationToken);

            if (effectedRows > 0)
                return new ApiResponse(true, ApiMessage.SuccessfulCreate);

            return new ApiResponse(false, ApiMessage.FailedCreate);
        }

        public async Task<ApiResponse> UpdateAsync(long id, EmploymentStatusMasterDto request, CancellationToken cancellationToken = default)
        {
            if (id != request.Id)
                return new ApiResponse(false, ApiMessage.EntityIdMismatch);

            var entity =
                request.Adapt<EmploymentStatusMaster>();

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
                await _unitOfWork.Repository().GetByIdAsync<EmploymentStatusMaster>(id, cancellationToken);

            if (entity is null)
                throw new EntityNotFoundException<EmploymentStatusMaster>(id);

            _unitOfWork.Repository().Remove(entity);

            var effectedRows =
                await _unitOfWork.CommitAsync(cancellationToken);

            if (effectedRows > 0)
                return new ApiResponse(true, ApiMessage.SuccessfulDelete);

            return new ApiResponse(false, ApiMessage.FailedDelete);
        }

    }
}
