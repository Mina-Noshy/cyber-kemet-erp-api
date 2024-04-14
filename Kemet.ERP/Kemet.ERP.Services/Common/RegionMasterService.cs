using Kemet.ERP.Abstraction.Common;
using Kemet.ERP.Contracts.Common;
using Kemet.ERP.Contracts.Response;
using Kemet.ERP.Domain.Entities.Common;
using Kemet.ERP.Domain.Exceptions;
using Kemet.ERP.Domain.IRepositories;
using Kemet.ERP.Domain.IRepositories.App;
using Mapster;

namespace Kemet.ERP.Services.Common
{
    public class RegionMasterService : IRegionMasterService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRequestHandlingRepository _request;

        public RegionMasterService(IUnitOfWork unitOfWork, IRequestHandlingRepository request)
            => (_unitOfWork, _request) = (unitOfWork, request);



        public async Task<ApiResponse> GetAllByCountryIdAsync(long countryId, CancellationToken cancellationToken = default)
        {
            var lst =
                await _unitOfWork.Repository().FindAsync<RegionMaster>(x =>
                x.CountryId == countryId,
                null, null, null,
                cancellationToken,
                "GetCountry");

            var lstDto =
                lst.Select(x => new RegionMasterListingDto
                {
                    Id = x.Id,
                    CountryId = x.CountryId,
                    ArName = x.ArName,
                    EnName = x.EnName,
                    CountryArName = x.GetCountry?.ArName,
                    CountryEnName = x.GetCountry?.EnName
                });

            return new ApiResponse(true, lstDto);
        }

        public async Task<ApiResponse> GetLightAsync(long countryId, CancellationToken cancellationToken = default)
        {
            string lang = _request.GetLang();

            var lst =
                await _unitOfWork.Repository().GetDynamicAsync<RegionMaster>(x =>
                new { Id = x.Id, Name = (lang == "ar") ? x.ArName : x.EnName },
                x => x.CountryId == countryId,
                x => x.OrderBy(x => (lang == "ar") ? x.ArName : x.EnName),
                cancellationToken);

            return new ApiResponse(true, lst);
        }

        public async Task<ApiResponse> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var lst =
                await _unitOfWork.Repository().GetAllAsync<RegionMaster>(null, null, null, cancellationToken, "GetCountry");

            var lstDto =
                lst.Select(x => new RegionMasterListingDto
                {
                    Id = x.Id,
                    CountryId = x.CountryId,
                    ArName = x.ArName,
                    EnName = x.EnName,
                    CountryArName = x.GetCountry?.ArName,
                    CountryEnName = x.GetCountry?.EnName
                });

            return new ApiResponse(true, lstDto);
        }

        public async Task<ApiResponse> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity =
                await _unitOfWork.Repository().GetByIdAsync<RegionMaster>(id, cancellationToken, "GetCountry");

            if (entity is null)
                throw new EntityNotFoundException<RegionMaster>(id);

            var entityDto =
                new RegionMasterListingDto
                {
                    Id = entity.Id,
                    CountryId = entity.CountryId,
                    ArName = entity.ArName,
                    EnName = entity.EnName,
                    CountryArName = entity.GetCountry?.ArName,
                    CountryEnName = entity.GetCountry?.EnName
                };

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
