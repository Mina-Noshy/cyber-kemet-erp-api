using Kemet.ERP.Abstraction.Identity;
using Kemet.ERP.Contracts.Identity;
using Kemet.ERP.Contracts.Response;
using Kemet.ERP.Domain.Entities.Identity;
using Kemet.ERP.Domain.IRepositories;
using Kemet.ERP.Domain.IRepositories.Identity;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace Kemet.ERP.Services.Identity
{
    public class RoleMasterService : IRoleMasterService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RoleMasterService(IAuthRepository authRepository, IUnitOfWork unitOfWork)
            => (_authRepository, _unitOfWork) = (authRepository, unitOfWork);


        public async Task<ApiResponse> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var lst =
                await _authRepository.GetRolesAsync(cancellationToken);

            var lstDto =
                lst.Adapt<IEnumerable<RoleListingDto>>();

            return new ApiResponse(true, lstDto);
        }

        public async Task<ApiResponse> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var entity =
                await _authRepository.GetRoleByIdAsync(id, cancellationToken);

            if (entity is null)
                return new ApiResponse(false, $"Role with ID '{id}' was not found.");

            var entityDto =
                entity.Adapt<RoleDetailsDto>();

            var pages = await _unitOfWork.Repository().FindAsync<PageMaster>(
                x => x.GetRolePages.Any(s => s.RoleId == id),
                null, null, null, cancellationToken,
                "GetRolePages.GetPage.GetMenu.GetModule");

            var tree = pages
            .GroupBy(rp => rp.GetRolePages?.FirstOrDefault()?.GetPage?.GetMenu?.GetModule?.Name)
            .Select(group => new RoleModuleTreeDto
            {
                Module = group.Key,
                Menus = group
                    .GroupBy(rp => new { rp.MenuId, rp.GetRolePages?.FirstOrDefault()?.GetPage?.GetMenu?.Name })
                    .Select(menuGroup => new RoleMenuTreeDto
                    {
                        Menu = menuGroup.Key.Name,
                        Pages = menuGroup
                            .Select(rp => new RolePageTreeDto
                            {
                                Id = rp.Id,
                                Page = rp.Name,
                                Create = rp.GetRolePages?.FirstOrDefault()?.Create ?? false,
                                Update = rp.GetRolePages?.FirstOrDefault()?.Update ?? false,
                                Delete = rp.GetRolePages?.FirstOrDefault()?.Delete ?? false,
                                Export = rp.GetRolePages?.FirstOrDefault()?.Export ?? false
                            }).ToList()
                    }).ToList()
            }).ToList();



            entityDto.Modules = tree;

            return new ApiResponse(true, entityDto);
        }

        public async Task<ApiResponse> CreateAsync(RoleDto request, CancellationToken cancellationToken = default)
        {
            var existsEntity =
                await _authRepository.GetRoleByNameAsync(request.Name, cancellationToken);

            if (existsEntity != null)
                return new ApiResponse(false, $"Role with name '{request.Name}' already exist.");

            var roleEntity = new IdentityRole()
            {
                Id = request.Id,
                Name = request.Name,
                NormalizedName = request.Name.ToUpper(),
                ConcurrencyStamp = request.ConcurrencyStamp
            };

            var result =
                await _authRepository.CreateRoleAsync(roleEntity, cancellationToken);

            if (result.Succeeded)
            {
                var lstNewRolePages = request.Pages
                    .Where(x => x.Create || x.Create || x.Delete || x.Export)
                    .Select(x =>
                new RolePageMaster()
                {
                    Id = 0,
                    RoleId = roleEntity.Id,
                    PageId = x.PageId,
                    Create = x.Create,
                    Update = x.Update,
                    Delete = x.Delete,
                    Export = x.Export
                });

                await _unitOfWork.Repository().AddRangeAsync(lstNewRolePages);
                var effectedRows = await _unitOfWork.CommitAsync(cancellationToken);

                if (effectedRows > 0)
                    return new ApiResponse(true, ApiMessage.SuccessfulCreate);
                else
                    await _authRepository.DeleteRoleAsync(roleEntity.Id, cancellationToken);
            }

            return new ApiResponse(false, ApiMessage.FailedCreate);
        }

        public async Task<ApiResponse> UpdateAsync(string id, RoleDto request, CancellationToken cancellationToken = default)
        {
            var roleEntity =
                await _authRepository.GetRoleByIdAsync(id, cancellationToken);

            if (roleEntity is null)
                return new ApiResponse(false, $"Role with id '{id}' was not found.");

            roleEntity.Name = request.Name;
            roleEntity.NormalizedName = request.Name.ToUpper();
            roleEntity.ConcurrencyStamp = request.ConcurrencyStamp;

            var result =
                await _authRepository.UpdateRoleAsync(roleEntity, cancellationToken);


            if (result.Succeeded)
            {
                await _unitOfWork.BeginTransactionAsync(cancellationToken);

                var lstOldRolePages = await _unitOfWork.Repository().FindAsync<RolePageMaster>(
                    x => x.RoleId == request.Id,
                    null, null, null,
                    cancellationToken);

                _unitOfWork.Repository().RemoveRange(lstOldRolePages);
                var effectedRows = await _unitOfWork.CommitAsync(cancellationToken);


                if (effectedRows > 0)
                {
                    var lstNewRolePages = request.Pages
                    .Where(x => x.Create || x.Create || x.Delete || x.Export)
                    .Select(x =>
                    new RolePageMaster()
                    {
                        Id = 0,
                        RoleId = roleEntity.Id,
                        PageId = x.PageId,
                        Create = x.Create,
                        Update = x.Update,
                        Delete = x.Delete,
                        Export = x.Export
                    });

                    await _unitOfWork.Repository().AddRangeAsync(lstNewRolePages);
                    effectedRows = await _unitOfWork.CommitAsync(cancellationToken);

                    if (effectedRows > 0)
                    {
                        await _unitOfWork.CommitTransactionAsync(cancellationToken);
                        return new ApiResponse(true, ApiMessage.SuccessfulUpdate);
                    }
                    else
                    {
                        await _unitOfWork.RollbackTransactionAsync(cancellationToken);

                        await _authRepository.DeleteRoleAsync(roleEntity.Id, cancellationToken);
                    }
                }
                else
                {
                    await _unitOfWork.RollbackTransactionAsync(cancellationToken);

                    await _authRepository.DeleteRoleAsync(roleEntity.Id, cancellationToken);
                }
            }


            return new ApiResponse(false, ApiMessage.FailedUpdate);
        }

        public async Task<ApiResponse> DeleteAsync(string id, CancellationToken cancellationToken = default)
        {
            var roleEntity =
                await _authRepository.GetRoleByIdAsync(id, cancellationToken);

            if (roleEntity is null)
                return new ApiResponse(false, $"Role with id '{id}' was not found.");

            var result =
                await _authRepository.DeleteRoleAsync(id, cancellationToken);

            if (result.Succeeded)
                return new ApiResponse(true, ApiMessage.SuccessfulDelete);

            return new ApiResponse(false, ApiMessage.FailedDelete);
        }

        public async Task<ApiResponse> GetLightAsync(CancellationToken cancellationToken = default)
        {
            var roles =
                await _authRepository.GetRolesAsync(cancellationToken);

            var lst = roles.Select(x => new { x.Id, x.Name });

            return new ApiResponse(true, lst);
        }

    }
}
