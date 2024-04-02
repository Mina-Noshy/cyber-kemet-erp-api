using Kemet.ERP.Abstraction.Common;
using Kemet.ERP.Contracts.Common;
using Kemet.ERP.Contracts.Response;
using Kemet.ERP.Domain.Entities.Common;
using Kemet.ERP.Domain.Exceptions;
using Kemet.ERP.Domain.IRepositories;
using Mapster;

namespace Kemet.ERP.Services.Common
{
    public class RegionMasterService : IRegionMasterService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegionMasterService(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;



        public async Task<ApiResponse> GetAllByCountryIdAsync(long countryId, CancellationToken cancellationToken = default)
        {
            var lst =
                await _unitOfWork.Repository().FindAsync<RegionMaster>(x =>
                x.CountryId == countryId,
                null, null, null,
                cancellationToken);

            var lstDto =
                lst.Adapt<IEnumerable<RegionMasterDto>>();

            return new ApiResponse(true, lstDto);
        }

        public async Task<ApiResponse> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var lst =
                await _unitOfWork.Repository().GetAllAsync<RegionMaster>(null, null, null, cancellationToken);

            var lstDto =
                lst.Adapt<IEnumerable<RegionMasterDto>>();

            return new ApiResponse(true, lstDto);
        }

        public async Task<ApiResponse> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity =
                await _unitOfWork.Repository().GetByIdAsync<RegionMaster>(id, cancellationToken);

            if (entity is null)
                throw new EntityNotFoundException<RegionMaster>(id);

            var entityDto =
                entity.Adapt<RegionMasterDto>();

            return new ApiResponse(true, entityDto);
        }


        public async Task<ApiResponse> CreateAsync(RegionMasterDto request, CancellationToken cancellationToken = default)
        {
            var entity =
                request.Adapt<RegionMaster>();

            _unitOfWork.Repository().Add<RegionMaster>(entity);

            var effectedRows =
                await _unitOfWork.CommitAsync(cancellationToken);

            if (effectedRows > 0)
                return new ApiResponse(true, ApiMessage.SuccessfulCreate);

            return new ApiResponse(false, ApiMessage.FailedCreate);
        }

        public async Task<ApiResponse> UpdateAsync(RegionMasterDto request, CancellationToken cancellationToken = default)
        {
            var entity =
                request.Adapt<RegionMaster>();

            _unitOfWork.Repository().Update<RegionMaster>(entity);

            var effectedRows =
                await _unitOfWork.CommitAsync(cancellationToken);

            if (effectedRows > 0)
                return new ApiResponse(true, ApiMessage.SuccessfulUpdate);

            return new ApiResponse(false, ApiMessage.FailedUpdate);
        }

        public async Task<ApiResponse> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity =
                await _unitOfWork.Repository().GetByIdAsync<RegionMaster>(id, cancellationToken);

            if (entity is null)
                throw new EntityNotFoundException<RegionMaster>(id);

            _unitOfWork.Repository().Remove<RegionMaster>(entity);

            var effectedRows =
                await _unitOfWork.CommitAsync(cancellationToken);

            if (effectedRows > 0)
                return new ApiResponse(true, ApiMessage.SuccessfulDelete);

            return new ApiResponse(false, ApiMessage.FailedDelete);
        }

    }
}
