using Kemet.ERP.Abstraction.Common;
using Kemet.ERP.Contracts.Common;
using Kemet.ERP.Contracts.Response;
using Kemet.ERP.Domain.Entities.Common;
using Kemet.ERP.Domain.Exceptions;
using Kemet.ERP.Domain.IRepositories.Common;
using Mapster;

namespace Kemet.ERP.Services.Common
{
    internal class RegionMasterService : IRegionMasterService
    {
        private readonly ICommonRepositoryManager _repositoryManager;
        public RegionMasterService(ICommonRepositoryManager repositoryManager)
            => _repositoryManager = repositoryManager;



        public async Task<ApiResponse> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var lst =
                await _repositoryManager.RegionMasterRepository.GetAllAsync(cancellationToken);

            var lstDto =
                lst.Adapt<IEnumerable<RegionMasterDto>>();

            return new ApiResponse(true, lstDto);
        }

        public async Task<ApiResponse> GetAllByCountryIdAsync(long countryId, CancellationToken cancellationToken = default)
        {
            var lst =
                await _repositoryManager.RegionMasterRepository.GetAllByCountryIdAsync(countryId, cancellationToken);

            var lstDto =
                lst.Adapt<IEnumerable<RegionMasterDto>>();

            return new ApiResponse(true, lstDto);
        }

        public async Task<ApiResponse> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity =
                await _repositoryManager.RegionMasterRepository.GetByIdAsync(id, cancellationToken);

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

            _repositoryManager.RegionMasterRepository.Create(entity);

            var effectedRows =
                await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            if (effectedRows > 0)
                return new ApiResponse(true, ApiMessage.SuccessfulCreate);

            return new ApiResponse(false, ApiMessage.FailedCreate);
        }

        public async Task<ApiResponse> UpdateAsync(RegionMasterDto request, CancellationToken cancellationToken = default)
        {
            var entity =
                request.Adapt<RegionMaster>();

            _repositoryManager.RegionMasterRepository.Update(entity);

            var effectedRows =
                await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            if (effectedRows > 0)
                return new ApiResponse(true, ApiMessage.SuccessfulUpdate);

            return new ApiResponse(false, ApiMessage.FailedUpdate);
        }

        public async Task<ApiResponse> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity =
                await _repositoryManager.RegionMasterRepository.GetByIdAsync(id, cancellationToken);

            if (entity is null)
                throw new EntityNotFoundException<RegionMaster>(id);

            _repositoryManager.RegionMasterRepository.Delete(entity);

            var effectedRows =
                await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            if (effectedRows > 0)
                return new ApiResponse(true, ApiMessage.SuccessfulDelete);

            return new ApiResponse(false, ApiMessage.FailedDelete);
        }
    }
}
