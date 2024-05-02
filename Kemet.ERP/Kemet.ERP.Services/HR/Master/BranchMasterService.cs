using Kemet.ERP.Abstraction.HR.Master;
using Kemet.ERP.Contracts.HR.Master;
using Kemet.ERP.Contracts.Response;
using Kemet.ERP.Domain.Entities.HR.Master;
using Kemet.ERP.Domain.Entities.Master;
using Kemet.ERP.Domain.Exceptions;
using Kemet.ERP.Domain.IRepositories;
using Mapster;

namespace Kemet.ERP.Services.HR.Master
{
    internal class BranchMasterService : IBranchMasterService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BranchMasterService(IUnitOfWork unitOfWork)
                => _unitOfWork = unitOfWork;



        public async Task<ApiResponse> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var lst =
                await _unitOfWork.Repository().GetAllAsync<BranchMaster>(null, null, null, cancellationToken, "GetCompany");

            var lstDto =
                lst.Select(x => new BranchMasterListingDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    PhoneNumber = x.PhoneNumber,
                    Address = x.Address,
                    City = x.City,
                    CompanyId = x.CompanyId,
                    Country = x.Country,
                    Description = x.Description,
                    Email = x.Email,
                    EmployeeCount = x.EmployeeCount,
                    Established = x.Established,
                    FaxNumber = x.FaxNumber,
                    Manager = x.Manager,
                    Notes = x.Notes,
                    IsActive = x.IsActive,
                    CompanyName = x.GetCompany?.Name,
                });

            return new ApiResponse(true, lstDto);
        }

        public async Task<ApiResponse> GetAllByCompanyIdAsync(long companyId, CancellationToken cancellationToken = default)
        {
            var lst =
                await _unitOfWork.Repository().FindAsync<BranchMaster>(x =>
                x.CompanyId == companyId,
                null, null, null,
                cancellationToken,
                "GetCompany");

            var lstDto =
                lst.Select(x => new BranchMasterListingDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    PhoneNumber = x.PhoneNumber,
                    Address = x.Address,
                    City = x.City,
                    CompanyId = x.CompanyId,
                    Country = x.Country,
                    Description = x.Description,
                    Email = x.Email,
                    EmployeeCount = x.EmployeeCount,
                    Established = x.Established,
                    FaxNumber = x.FaxNumber,
                    Manager = x.Manager,
                    Notes = x.Notes,
                    IsActive = x.IsActive,
                    CompanyName = x.GetCompany?.Name,
                });

            return new ApiResponse(true, lstDto);
        }

        public async Task<ApiResponse> GetLightAsync(long companyId, CancellationToken cancellationToken = default)
        {
            var lst =
                await _unitOfWork.Repository().GetDynamicAsync<CityMaster>(
                x => x.CountryId == companyId,
                x => new { x.Id, x.Name },
                x => x.OrderBy(x => x.Name),
                cancellationToken);

            return new ApiResponse(true, lst);
        }

        public async Task<ApiResponse> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity =
                await _unitOfWork.Repository().GetByIdAsync<BranchMaster>(id, cancellationToken, "GetCompany");

            if (entity is null)
                throw new EntityNotFoundException<BranchMaster>(id);

            var entityDto =
                new BranchMasterListingDto()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    PhoneNumber = entity.PhoneNumber,
                    Address = entity.Address,
                    City = entity.City,
                    CompanyId = entity.CompanyId,
                    Country = entity.Country,
                    Description = entity.Description,
                    Email = entity.Email,
                    EmployeeCount = entity.EmployeeCount,
                    Established = entity.Established,
                    FaxNumber = entity.FaxNumber,
                    Manager = entity.Manager,
                    Notes = entity.Notes,
                    IsActive = entity.IsActive,
                    CompanyName = entity.GetCompany?.Name,
                };

            return new ApiResponse(true, entityDto);
        }

        public async Task<ApiResponse> CreateAsync(BranchMasterDto request, CancellationToken cancellationToken = default)
        {
            var entity =
                request.Adapt<BranchMaster>();

            _unitOfWork.Repository().Add(entity);

            var effectedRows =
                await _unitOfWork.CommitAsync(cancellationToken);

            if (effectedRows > 0)
                return new ApiResponse(true, ApiMessage.SuccessfulCreate);

            return new ApiResponse(false, ApiMessage.FailedCreate);
        }

        public async Task<ApiResponse> UpdateAsync(long id, BranchMasterDto request, CancellationToken cancellationToken = default)
        {
            if (id != request.Id)
                return new ApiResponse(false, ApiMessage.EntityIdMismatch);

            var entity =
                request.Adapt<BranchMaster>();

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
                await _unitOfWork.Repository().GetByIdAsync<BranchMaster>(id, cancellationToken);

            if (entity is null)
                throw new EntityNotFoundException<BranchMaster>(id);

            _unitOfWork.Repository().Remove(entity);

            var effectedRows =
                await _unitOfWork.CommitAsync(cancellationToken);

            if (effectedRows > 0)
                return new ApiResponse(true, ApiMessage.SuccessfulDelete);

            return new ApiResponse(false, ApiMessage.FailedDelete);
        }

    }
}
