using Kemet.ERP.Abstraction.IEntity.HR;
using Kemet.ERP.Contracts;
using Kemet.ERP.Contracts.HR;
using Kemet.ERP.Contracts.HttpResponse;
using Kemet.ERP.Domain.Entities.HR;
using Kemet.ERP.Domain.Exceptions;
using Kemet.ERP.Domain.IRepositories;
using Mapster;

namespace Kemet.ERP.Services.Entity.HR
{
    internal class RegionService : IRegionService
    {
        private readonly IHRRepositoryManager _hrRepositoryManager;
        public RegionService(IHRRepositoryManager hrRepositoryManager)
            => _hrRepositoryManager = hrRepositoryManager;



        public async Task<ApiResponse> GetAllAsync(PaginationDto request, CancellationToken cancellationToken = default)
        {
            var lst = await _hrRepositoryManager.RegionRepository.GetAllAsync(request.Skip, request.Take, cancellationToken);

            var lstDto = lst.Adapt<IEnumerable<RegionDto>>();

            return new ApiResponse(true, lstDto);
        }

        public async Task<ApiResponse> GetAllAsync(long countryId, CancellationToken cancellationToken = default)
        {
            var lst = await _hrRepositoryManager.RegionRepository.GetAllAsync(countryId, cancellationToken);

            var lstDto = lst.Adapt<IEnumerable<RegionDto>>();

            return new ApiResponse(true, lstDto);
        }

        public async Task<ApiResponse> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await _hrRepositoryManager.RegionRepository.GetByIdAsync(id, cancellationToken);

            if (entity is null)
            {
                throw new EntityNotFoundException<Region>(id);
            }

            var entityDto = entity.Adapt<RegionDto>();

            return new ApiResponse(true, entityDto);
        }
    }
}
