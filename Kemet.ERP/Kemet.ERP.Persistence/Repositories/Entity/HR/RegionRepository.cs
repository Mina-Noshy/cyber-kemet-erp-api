﻿using Kemet.ERP.Domain.Entities.HR;
using Kemet.ERP.Domain.IRepositories.IEntity.HR;
using Kemet.ERP.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Kemet.ERP.Persistence.Repositories.Entity.HR
{
    internal class RegionRepository : IRegionRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public RegionRepository(RepositoryDbContext dbContext)
            => _dbContext = dbContext;


        public async Task<IEnumerable<Region>> GetAllAsync(int skip, int take, CancellationToken cancellationToken = default)
            => await _dbContext.Regions.OrderBy(x => x.EnName).Skip(skip).Take(take).ToListAsync(cancellationToken);

        public async Task<IEnumerable<Region>> GetAllAsync(long countryId, CancellationToken cancellationToken = default)
            => await _dbContext.Regions
            .Where(x => x.CountryId == countryId)
            .OrderBy(x => x.EnName)
            .ToListAsync(cancellationToken);

        public async Task<Region?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
            => await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    }
}
