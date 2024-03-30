using Kemet.ERP.Abstraction.HR.Common;
using Kemet.ERP.Contracts.HR.Common;
using Kemet.ERP.Contracts.Response;
using Kemet.ERP.Domain.Entities.HR.Common;
using Kemet.ERP.Domain.Exceptions;
using Kemet.ERP.Domain.IRepositories;
using Mapster;

namespace Kemet.ERP.Services.HR.Common
{
    internal class RegionService : IRegionService
    {
        private readonly IHRRepositoryManager _hrRepositoryManager;
        public RegionService(IHRRepositoryManager hrRepositoryManager)
            => _hrRepositoryManager = hrRepositoryManager;



        public async Task<ApiResponse> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var lst =
                await _hrRepositoryManager.RegionRepository.GetAllAsync(cancellationToken);

            var lstDto =
                lst.Adapt<IEnumerable<RegionDto>>();

            return new ApiResponse(true, lstDto);
        }

        public async Task<ApiResponse> GetAllByCountryIdAsync(long countryId, CancellationToken cancellationToken = default)
        {
            var lst =
                await _hrRepositoryManager.RegionRepository.GetAllByCountryIdAsync(countryId, cancellationToken);

            var lstDto =
                lst.Adapt<IEnumerable<RegionDto>>();

            return new ApiResponse(true, lstDto);
        }

        public async Task<ApiResponse> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity =
                await _hrRepositoryManager.RegionRepository.GetByIdAsync(id, cancellationToken);

            if (entity is null)
                throw new EntityNotFoundException<Region>(id);

            var entityDto =
                entity.Adapt<RegionDto>();

            return new ApiResponse(true, entityDto);
        }

        public async Task<ApiResponse> CreateAsync(RegionDto request, CancellationToken cancellationToken = default)
        {
            var entity =
                request.Adapt<Region>();

            _hrRepositoryManager.RegionRepository.Create(entity);

            var effectedRows =
                await _hrRepositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            if (effectedRows > 0)
                return new ApiResponse(true, ApiMessage.SuccessfulCreate);

            return new ApiResponse(false, ApiMessage.FailedCreate);
        }

        public async Task<ApiResponse> UpdateAsync(RegionDto request, CancellationToken cancellationToken = default)
        {
            var entity =
                request.Adapt<Region>();

            _hrRepositoryManager.RegionRepository.Update(entity);

            var effectedRows =
                await _hrRepositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            if (effectedRows > 0)
                return new ApiResponse(true, ApiMessage.SuccessfulUpdate);

            return new ApiResponse(false, ApiMessage.FailedUpdate);
        }

        public async Task<ApiResponse> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity =
                await _hrRepositoryManager.RegionRepository.GetByIdAsync(id, cancellationToken);

            if (entity is null)
                throw new EntityNotFoundException<Region>(id);

            _hrRepositoryManager.RegionRepository.Delete(entity);

            var effectedRows =
                await _hrRepositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            if (effectedRows > 0)
                return new ApiResponse(true, ApiMessage.SuccessfulDelete);

            return new ApiResponse(false, ApiMessage.FailedDelete);
        }
    }
}
