using Kemet.ERP.Abstraction.Identity;
using Kemet.ERP.Contracts.Identity;
using Kemet.ERP.Contracts.Response;
using Kemet.ERP.Domain.Entities.Identity;
using Kemet.ERP.Domain.Exceptions;
using Kemet.ERP.Domain.IRepositories;
using Mapster;

namespace Kemet.ERP.Services.Identity
{
    internal class PageMasterService : IPageMasterService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PageMasterService(IUnitOfWork unitOfWork)
                => _unitOfWork = unitOfWork;



        public async Task<ApiResponse> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var lst =
                await _unitOfWork.Repository().GetAllAsync<PageMaster>(null, null, null, cancellationToken, "GetMenu.GetModule");

            var lstDto =
                lst.Select(x => new PageMasterListingDto
                {
                    Id = x.Id,
                    MenuId = x.MenuId,
                    Name = x.Name,
                    Icon = x.Icon,
                    Label = x.Label,
                    Url = x.Url,
                    MenuName = x.GetMenu?.Name,
                    ModuleId = x.GetMenu?.ModuleId,
                    ModuleName = x.GetMenu?.GetModule?.Name
                });

            return new ApiResponse(true, lstDto);
        }

        public async Task<ApiResponse> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity =
                await _unitOfWork.Repository().GetByIdAsync<PageMaster>(id, cancellationToken, "GetMenu.GetModule");

            if (entity is null)
                throw new EntityNotFoundException<PageMaster>(id);

            var entityDto =
                new PageMasterListingDto
                {
                    Id = entity.Id,
                    MenuId = entity.MenuId,
                    Name = entity.Name,
                    Icon = entity.Icon,
                    Label = entity.Label,
                    Url = entity.Url,
                    MenuName = entity.GetMenu?.Name,
                    ModuleId = entity.GetMenu?.ModuleId,
                    ModuleName = entity.GetMenu?.GetModule?.Name
                };

            return new ApiResponse(true, entityDto);
        }

        public async Task<ApiResponse> CreateAsync(PageMasterDto request, CancellationToken cancellationToken = default)
        {
            var entity =
                request.Adapt<PageMaster>();

            _unitOfWork.Repository().Add(entity);

            var effectedRows =
                await _unitOfWork.CommitAsync(cancellationToken);

            if (effectedRows > 0)
                return new ApiResponse(true, ApiMessage.SuccessfulCreate);

            return new ApiResponse(false, ApiMessage.FailedCreate);
        }

        public async Task<ApiResponse> UpdateAsync(long id, PageMasterDto request, CancellationToken cancellationToken = default)
        {
            if (id != request.Id)
                return new ApiResponse(false, ApiMessage.EntityIdMismatch);

            var entity =
                request.Adapt<PageMaster>();

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
                await _unitOfWork.Repository().GetByIdAsync<PageMaster>(id, cancellationToken);

            if (entity is null)
                throw new EntityNotFoundException<PageMaster>(id);

            _unitOfWork.Repository().Remove(entity);

            var effectedRows =
                await _unitOfWork.CommitAsync(cancellationToken);

            if (effectedRows > 0)
                return new ApiResponse(true, ApiMessage.SuccessfulDelete);

            return new ApiResponse(false, ApiMessage.FailedDelete);
        }

        public async Task<ApiResponse> GetAllByMenuIdAsync(long menuId, CancellationToken cancellationToken = default)
        {
            var lst =
                await _unitOfWork.Repository().FindAsync<PageMaster>(x =>
                x.MenuId == menuId,
                null, null, null,
                cancellationToken,
                "GetMenu.GetModule");

            var lstDto =
                lst.Select(x => new PageMasterListingDto
                {
                    Id = x.Id,
                    MenuId = x.MenuId,
                    Name = x.Name,
                    Icon = x.Icon,
                    Label = x.Label,
                    Url = x.Url,
                    MenuName = x.GetMenu?.Name,
                    ModuleId = x.GetMenu?.ModuleId,
                    ModuleName = x.GetMenu?.GetModule?.Name
                });

            return new ApiResponse(true, lstDto);
        }

        public async Task<ApiResponse> GetLightAsync(long menuId, CancellationToken cancellationToken = default)
        {
            var lst =
                await _unitOfWork.Repository().GetDynamicAsync<PageMaster>(
                x => x.MenuId == menuId,
                x => new { x.Id, x.Name },
                x => x.OrderBy(x => x.Name),
                cancellationToken);

            return new ApiResponse(true, lst);
        }
    }
}
