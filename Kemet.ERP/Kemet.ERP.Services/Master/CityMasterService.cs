using Kemet.ERP.Abstraction.Master;
using Kemet.ERP.Contracts.Master;
using Kemet.ERP.Contracts.Response;
using Kemet.ERP.Domain.Entities.Master;
using Kemet.ERP.Domain.Exceptions;
using Kemet.ERP.Domain.IRepositories;
using Kemet.ERP.Domain.IRepositories.App;
using Mapster;

namespace Kemet.ERP.Services.Master
{
    public class CityMasterService : ICityMasterService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRequestHandlingRepository _request;

        public CityMasterService(IUnitOfWork unitOfWork, IRequestHandlingRepository request)
            => (_unitOfWork, _request) = (unitOfWork, request);



        public async Task<ApiResponse> GetAllByCountryIdAsync(long countryId, CancellationToken cancellationToken = default)
        {
            var lst =
                await _unitOfWork.Repository().FindAsync<CityMaster>(x =>
                x.CountryId == countryId,
                null, null, null,
                cancellationToken,
                "GetCountry");

            var lstDto =
                lst.Select(x => new CityMasterListingDto
                {
                    Id = x.Id,
                    CountryId = x.CountryId,
                    Name = x.Name,
                    CountryName = x.GetCountry?.Name,
                });

            return new ApiResponse(true, lstDto);
        }

        public async Task<ApiResponse> GetLightAsync(long countryId, CancellationToken cancellationToken = default)
        {
            var lst =
                await _unitOfWork.Repository().GetDynamicAsync<CityMaster>(
                x => x.CountryId == countryId,
                x => new { x.Id, Name = x.Name },
                x => x.OrderBy(x => x.Name),
                cancellationToken);

            return new ApiResponse(true, lst);
        }

        public async Task<ApiResponse> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var lst =
                await _unitOfWork.Repository().GetAllAsync<CityMaster>(null, null, null, cancellationToken, "GetCountry");

            var lstDto =
                lst.Select(x => new CityMasterListingDto
                {
                    Id = x.Id,
                    CountryId = x.CountryId,
                    Name = x.Name,
                    CountryName = x.GetCountry?.Name
                });

            return new ApiResponse(true, lstDto);
        }

        public async Task<ApiResponse> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity =
                await _unitOfWork.Repository().GetByIdAsync<CityMaster>(id, cancellationToken, "GetCountry");

            if (entity is null)
                throw new EntityNotFoundException<CityMaster>(id);

            var entityDto =
                new CityMasterListingDto
                {
                    Id = entity.Id,
                    CountryId = entity.CountryId,
                    Name = entity.Name,
                    CountryName = entity.GetCountry?.Name
                };

            return new ApiResponse(true, entityDto);
        }

        public async Task<ApiResponse> CreateAsync(CityMasterDto request, CancellationToken cancellationToken = default)
        {
            var entity =
                request.Adapt<CityMaster>();

            _unitOfWork.Repository().Add(entity);

            var effectedRows =
                await _unitOfWork.CommitAsync(cancellationToken);

            if (effectedRows > 0)
                return new ApiResponse(true, ApiMessage.SuccessfulCreate);

            return new ApiResponse(false, ApiMessage.FailedCreate);
        }

        public async Task<ApiResponse> UpdateAsync(long id, CityMasterDto request, CancellationToken cancellationToken = default)
        {
            if (id != request.Id)
                return new ApiResponse(false, ApiMessage.EntityIdMismatch);

            var entity =
                request.Adapt<CityMaster>();

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
                await _unitOfWork.Repository().GetByIdAsync<CityMaster>(id, cancellationToken);

            if (entity is null)
                throw new EntityNotFoundException<CityMaster>(id);

            _unitOfWork.Repository().Remove(entity);

            var effectedRows =
                await _unitOfWork.CommitAsync(cancellationToken);

            if (effectedRows > 0)
                return new ApiResponse(true, ApiMessage.SuccessfulDelete);

            return new ApiResponse(false, ApiMessage.FailedDelete);
        }

    }
}
