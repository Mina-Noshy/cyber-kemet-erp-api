using Kemet.ERP.Abstraction.Identity;
using Kemet.ERP.Contracts.Identity;
using Kemet.ERP.Contracts.Response;
using Kemet.ERP.Domain.Entities.Identity;
using Kemet.ERP.Domain.Exceptions;
using Kemet.ERP.Domain.IRepositories;
using Mapster;

namespace Kemet.ERP.Services.Identity
{
    internal class MenuMasterService : IMenuMasterService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MenuMasterService(IUnitOfWork unitOfWork)
                => _unitOfWork = unitOfWork;



        public async Task<ApiResponse> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var lst =
                await _unitOfWork.Repository().GetAllAsync<MenuMaster>(null, null, null, cancellationToken, "GetModule");

            var lstDto =
                lst.Select(x => new MenuMasterListingDto
                {
                    Id = x.Id,
                    ModuleId = x.ModuleId,
                    Name = x.Name,
                    Icon = x.Icon,
                    Label = x.Label,
                    ModuleName = x.GetModule?.Name
                });

            return new ApiResponse(true, lstDto);
        }

        public async Task<ApiResponse> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity =
                await _unitOfWork.Repository().GetByIdAsync<MenuMaster>(id, cancellationToken, "GetModule");

            if (entity is null)
                throw new EntityNotFoundException<MenuMaster>(id);

            var entityDto =
                new MenuMasterListingDto
                {
                    Id = entity.Id,
                    ModuleId = entity.ModuleId,
                    Name = entity.Name,
                    Icon = entity.Icon,
                    Label = entity.Label,
                    ModuleName = entity.GetModule?.Name
                };

            return new ApiResponse(true, entityDto);
        }

        public async Task<ApiResponse> CreateAsync(MenuMasterDto request, CancellationToken cancellationToken = default)
        {
            var entity =
                request.Adapt<MenuMaster>();

            _unitOfWork.Repository().Add(entity);

            var effectedRows =
                await _unitOfWork.CommitAsync(cancellationToken);

            if (effectedRows > 0)
                return new ApiResponse(true, ApiMessage.SuccessfulCreate);

            return new ApiResponse(false, ApiMessage.FailedCreate);
        }

        public async Task<ApiResponse> UpdateAsync(long id, MenuMasterDto request, CancellationToken cancellationToken = default)
        {
            if (id != request.Id)
                return new ApiResponse(false, ApiMessage.EntityIdMismatch);

            var entity =
                request.Adapt<MenuMaster>();

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
                await _unitOfWork.Repository().GetByIdAsync<MenuMaster>(id, cancellationToken);

            if (entity is null)
                throw new EntityNotFoundException<MenuMaster>(id);

            _unitOfWork.Repository().Remove(entity);

            var effectedRows =
                await _unitOfWork.CommitAsync(cancellationToken);

            if (effectedRows > 0)
                return new ApiResponse(true, ApiMessage.SuccessfulDelete);

            return new ApiResponse(false, ApiMessage.FailedDelete);
        }

        public async Task<ApiResponse> GetAllByModuleIdAsync(long moduleId, CancellationToken cancellationToken = default)
        {
            var lst =
                await _unitOfWork.Repository().FindAsync<MenuMaster>(x =>
                x.ModuleId == moduleId,
                null, null, null,
                cancellationToken,
                "GetModule");

            var lstDto =
                lst.Select(x => new MenuMasterListingDto
                {
                    Id = x.Id,
                    ModuleId = x.ModuleId,
                    Name = x.Name,
                    Icon = x.Icon,
                    Label = x.Label,
                    ModuleName = x.GetModule?.Name
                });

            return new ApiResponse(true, lstDto);
        }

        public async Task<ApiResponse> GetLightAsync(long moduleId, CancellationToken cancellationToken = default)
        {
            var lst =
                await _unitOfWork.Repository().GetDynamicAsync<MenuMaster>(
                x => x.ModuleId == moduleId,
                x => new { x.Id, x.Name },
                x => x.OrderBy(x => x.Name),
                cancellationToken);

            return new ApiResponse(true, lst);
        }
    }
}
