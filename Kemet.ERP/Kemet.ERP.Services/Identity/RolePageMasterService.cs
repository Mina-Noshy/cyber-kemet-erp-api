using Kemet.ERP.Abstraction.Identity;
using Kemet.ERP.Contracts.Identity;
using Kemet.ERP.Contracts.Response;
using Kemet.ERP.Domain.Entities.Identity;
using Kemet.ERP.Domain.Exceptions;
using Kemet.ERP.Domain.IRepositories;
using Mapster;

namespace Kemet.ERP.Services.Identity
{
    internal class RolePageMasterService : IRolePageMasterService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RolePageMasterService(IUnitOfWork unitOfWork)
                => _unitOfWork = unitOfWork;



        public async Task<ApiResponse> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var lst =
                await _unitOfWork.Repository().GetAllAsync<RolePageMaster>(
                    null, null, null,
                    cancellationToken,
                    "GetRole", "GetPage");

            var lstDto =
                lst.Select(x => new RolePageMasterListingDto
                {
                    Id = x.Id,
                    RoleId = x.RoleId,
                    PageId = x.PageId,
                    Create = x.Create,
                    Update = x.Update,
                    Delete = x.Delete,
                    Export = x.Export,
                    RoleName = x.GetRole?.Name,
                    PageName = x.GetPage?.Name
                });

            return new ApiResponse(true, lstDto);
        }

        public async Task<ApiResponse> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity =
                await _unitOfWork.Repository().GetByIdAsync<RolePageMaster>(id, cancellationToken, "GetRole", "GetPage");

            if (entity is null)
                throw new EntityNotFoundException<RolePageMaster>(id);

            var entityDto =
               new RolePageMasterListingDto
               {
                   Id = entity.Id,
                   RoleId = entity.RoleId,
                   PageId = entity.PageId,
                   Create = entity.Create,
                   Update = entity.Update,
                   Delete = entity.Delete,
                   Export = entity.Export,
                   RoleName = entity.GetRole?.Name,
                   PageName = entity.GetPage?.Name
               };

            return new ApiResponse(true, entityDto);
        }

        public async Task<ApiResponse> CreateAsync(RolePageMasterDto request, CancellationToken cancellationToken = default)
        {
            var entity =
                request.Adapt<RolePageMaster>();

            _unitOfWork.Repository().Add(entity);

            var effectedRows =
                await _unitOfWork.CommitAsync(cancellationToken);

            if (effectedRows > 0)
                return new ApiResponse(true, ApiMessage.SuccessfulCreate);

            return new ApiResponse(false, ApiMessage.FailedCreate);
        }

        public async Task<ApiResponse> UpdateAsync(long id, RolePageMasterDto request, CancellationToken cancellationToken = default)
        {
            if (id != request.Id)
                return new ApiResponse(false, ApiMessage.EntityIdMismatch);

            var entity =
                request.Adapt<RolePageMaster>();

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
                await _unitOfWork.Repository().GetByIdAsync<RolePageMaster>(id, cancellationToken);

            if (entity is null)
                throw new EntityNotFoundException<RolePageMaster>(id);

            _unitOfWork.Repository().Remove(entity);

            var effectedRows =
                await _unitOfWork.CommitAsync(cancellationToken);

            if (effectedRows > 0)
                return new ApiResponse(true, ApiMessage.SuccessfulDelete);

            return new ApiResponse(false, ApiMessage.FailedDelete);
        }

        public async Task<ApiResponse> GetAllByRoleIdAsync(string roleId, CancellationToken cancellationToken = default)
        {
            var lst =
                await _unitOfWork.Repository().FindAsync<RolePageMaster>(x =>
                x.RoleId == roleId,
                null, null, null,
                cancellationToken,
                "GetRole", "GetPage");

            var lstDto =
                lst.Select(x => new RolePageMasterListingDto
                {
                    Id = x.Id,
                    RoleId = x.RoleId,
                    PageId = x.PageId,
                    Create = x.Create,
                    Update = x.Update,
                    Delete = x.Delete,
                    Export = x.Export,
                    RoleName = x.GetRole?.Name,
                    PageName = x.GetPage?.Name
                });

            return new ApiResponse(true, lstDto);
        }

    }
}
