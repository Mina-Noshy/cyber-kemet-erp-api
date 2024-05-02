using Kemet.ERP.Abstraction.Identity;
using Kemet.ERP.Contracts.Identity;
using Kemet.ERP.Contracts.Response;
using Kemet.ERP.Domain.Entities.Identity;
using Kemet.ERP.Domain.Exceptions;
using Kemet.ERP.Domain.IRepositories;
using Mapster;

namespace Kemet.ERP.Services.Identity
{
    internal class ModuleMasterService : IModuleMasterService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ModuleMasterService(IUnitOfWork unitOfWork)
                => _unitOfWork = unitOfWork;



        public async Task<ApiResponse> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var lst =
                await _unitOfWork.Repository().GetAllAsync<ModuleMaster>(null, null, null, cancellationToken);

            var lstDto =
                lst.Adapt<IEnumerable<ModuleMasterDto>>();

            return new ApiResponse(true, lstDto);
        }

        public async Task<ApiResponse> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity =
                await _unitOfWork.Repository().GetByIdAsync<ModuleMaster>(id, cancellationToken);

            if (entity is null)
                throw new EntityNotFoundException<ModuleMaster>(id);

            var entityDto =
                entity.Adapt<ModuleMasterDto>();

            return new ApiResponse(true, entityDto);
        }

        public async Task<ApiResponse> CreateAsync(ModuleMasterDto request, CancellationToken cancellationToken = default)
        {
            var entity =
                request.Adapt<ModuleMaster>();

            _unitOfWork.Repository().Add(entity);

            var effectedRows =
                await _unitOfWork.CommitAsync(cancellationToken);

            if (effectedRows > 0)
                return new ApiResponse(true, ApiMessage.SuccessfulCreate);

            return new ApiResponse(false, ApiMessage.FailedCreate);
        }

        public async Task<ApiResponse> UpdateAsync(long id, ModuleMasterDto request, CancellationToken cancellationToken = default)
        {
            if (id != request.Id)
                return new ApiResponse(false, ApiMessage.EntityIdMismatch);

            var entity =
                request.Adapt<ModuleMaster>();

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
                await _unitOfWork.Repository().GetByIdAsync<ModuleMaster>(id, cancellationToken);

            if (entity is null)
                throw new EntityNotFoundException<ModuleMaster>(id);

            _unitOfWork.Repository().Remove(entity);

            var effectedRows =
                await _unitOfWork.CommitAsync(cancellationToken);

            if (effectedRows > 0)
                return new ApiResponse(true, ApiMessage.SuccessfulDelete);

            return new ApiResponse(false, ApiMessage.FailedDelete);
        }

        public async Task<ApiResponse> GetLightAsync(CancellationToken cancellationToken = default)
        {
            var lst =
                await _unitOfWork.Repository().GetDynamicAsync<ModuleMaster>(
                null,
                x => new { x.Id, x.Name },
                x => x.OrderBy(x => x.Name),
                cancellationToken);

            return new ApiResponse(true, lst);
        }
    }
}
