using Kemet.ERP.Abstraction.HR.Master;
using Kemet.ERP.Contracts.HR.Master;
using Kemet.ERP.Contracts.Response;
using Kemet.ERP.Domain.Common.Extensions;
using Kemet.ERP.Domain.Common.Utilities;
using Kemet.ERP.Domain.Entities.HR.Master;
using Kemet.ERP.Domain.Exceptions;
using Kemet.ERP.Domain.IRepositories;
using Mapster;

namespace Kemet.ERP.Services.HR.Master
{
    internal class CompanyMasterService : ICompanyMasterService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyMasterService(IUnitOfWork unitOfWork)
                => _unitOfWork = unitOfWork;



        public async Task<ApiResponse> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var lst =
                await _unitOfWork.Repository().GetAllAsync<CompanyMaster>(null, null, null, cancellationToken);

            foreach (var item in lst)
            {
                string fullPath = Path.Combine(IOHelper.GetCompanyProfilePath(item.Name), item.Logo ?? "");
                item.Logo = IOHelper.GetFullURL(fullPath);
            }

            var lstDto =
                lst.Adapt<IEnumerable<CompanyMasterDto>>();

            return new ApiResponse(true, lstDto);
        }

        public async Task<ApiResponse> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity =
                await _unitOfWork.Repository().GetByIdAsync<CompanyMaster>(id, cancellationToken);

            if (entity is null)
                throw new EntityNotFoundException<CompanyMaster>(id);

            string fullPath = Path.Combine(IOHelper.GetCompanyProfilePath(entity.Name), entity.Logo ?? "");
            entity.Logo = IOHelper.GetFullURL(fullPath);

            var entityDto =
                entity.Adapt<CompanyMasterDto>();

            return new ApiResponse(true, entityDto);
        }

        public async Task<ApiResponse> GetLightAsync(CancellationToken cancellationToken = default)
        {
            var lst =
                await _unitOfWork.Repository().GetDynamicAsync<CompanyMaster>(null,
                x => new { x.Id, x.Name },
                x => x.OrderBy(x => x.Name),
                cancellationToken);

            return new ApiResponse(true, lst);
        }

        public async Task<ApiResponse> CreateAsync(CreateCompanyMasterDto request, CancellationToken cancellationToken = default)
        {
            var entity =
                request.Adapt<CompanyMaster>();

            if (request.Logo != null)
                entity.Logo = await request.Logo.Upload(IOHelper.GetCompanyProfilePath(request.Name));

            _unitOfWork.Repository().Add(entity);

            var effectedRows =
                await _unitOfWork.CommitAsync(cancellationToken);

            if (effectedRows > 0)
                return new ApiResponse(true, ApiMessage.SuccessfulCreate);

            return new ApiResponse(false, ApiMessage.FailedCreate);
        }

        public async Task<ApiResponse> UpdateAsync(long id, CreateCompanyMasterDto request, CancellationToken cancellationToken = default)
        {
            if (id != request.Id)
                return new ApiResponse(false, ApiMessage.EntityIdMismatch);

            var entity =
                request.Adapt<CompanyMaster>();

            string? oldLogo = string.Empty;

            if (request.Logo != null)
            {
                var oldEntity = await _unitOfWork.Repository().GetByIdAsync<CompanyMaster>(id);

                if (oldEntity != null)
                    oldLogo = oldEntity.Logo;

                string newLogo = await request.Logo.Upload(IOHelper.GetCompanyProfilePath(request.Name));

                if (!string.IsNullOrEmpty(newLogo))
                    entity.Logo = newLogo;
            }

            _unitOfWork.Repository().Update(entity);

            var effectedRows =
                await _unitOfWork.CommitAsync(cancellationToken);

            if (effectedRows > 0)
            {
                UploadHelper.Delete(oldLogo, IOHelper.GetCompanyProfilePath(entity.Name));

                return new ApiResponse(true, ApiMessage.SuccessfulUpdate);
            }

            return new ApiResponse(false, ApiMessage.FailedUpdate);
        }

        public async Task<ApiResponse> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity =
                await _unitOfWork.Repository().GetByIdAsync<CompanyMaster>(id, cancellationToken);

            if (entity is null)
                throw new EntityNotFoundException<CompanyMaster>(id);

            string? logo = entity.Logo;

            _unitOfWork.Repository().Remove(entity);

            var effectedRows =
                await _unitOfWork.CommitAsync(cancellationToken);

            if (effectedRows > 0)
            {
                //UploadHelper.Delete(logo, IOHelper.GetCompanyProfilePath(entity.Name));

                return new ApiResponse(true, ApiMessage.SuccessfulDelete);
            }

            return new ApiResponse(false, ApiMessage.FailedDelete);
        }

    }
}
