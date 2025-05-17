using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using YANLib.DbContexts;
using YANLib.Dtos;
using YANLib.Entities;
using static Microsoft.EntityFrameworkCore.EntityState;
using static System.DateTime;

namespace YANLib.Domains;

public class DeveloperRepository(
    ILogger<DeveloperRepository> logger,
    IDbContextProvider<IYANLibDbContext> dbContextProvider,
    IYANLibDbContext dbContext
) : EfCoreRepository<IYANLibDbContext, Developer, Guid>(dbContextProvider), IDeveloperRepository
{
    private readonly ILogger<DeveloperRepository> _logger = logger;
    private readonly IYANLibDbContext _dbContext = dbContext;

    public async Task<Developer?> ModifyAsync(DeveloperDto dto, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            return await _dbContext.Developers.Where(x => x.Id == dto.Id && x.IsDeleted == false).ExecuteUpdateAsync(s => s
                .SetProperty(x => x.UpdatedBy, dto.UpdatedBy)
                .SetProperty(x => x.UpdatedAt, UtcNow)
                .SetProperty(x => x.IsActive, x => dto.IsActive ?? x.IsActive)
                .SetProperty(x => x.IsDeleted, x => dto.IsDeleted ?? x.IsDeleted)
                .SetProperty(x => x.Name, x => dto.Name ?? x.Name)
                .SetProperty(x => x.Phone, x => dto.Phone ?? x.Phone)
                .SetProperty(x => x.IdCard, x => dto.IdCard ?? x.IdCard)
                .SetProperty(x => x.DeveloperTypeCode, x => dto.DeveloperTypeCode ?? x.DeveloperTypeCode)
            , cancellationToken) > 0 ? await _dbContext.Developers.FindAsync([dto.Id, cancellationToken], cancellationToken) : default;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "ModifyAsync-DeveloperRepository-Exception: {DTO}", dto.Serialize());

            throw;
        }
    }

    public async Task<Developer?> AdjustAsync(Developer entity, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var latestEntity = await _dbContext.Developers.SingleOrDefaultAsync(x => x.IdCard == entity.IdCard && x.IsDeleted == false, cancellationToken);

            if (latestEntity.IsNull())
            {
                throw new EntityNotFoundException(typeof(Developer), entity.IdCard);
            }

            latestEntity.UpdatedBy = entity.UpdatedBy;
            latestEntity.UpdatedAt = UtcNow;
            latestEntity.IsDeleted = true;

            var updatedEntity = _dbContext.Update(latestEntity);

            if (updatedEntity.State is not Modified)
            {
                throw new Exception("Failed to update the latest entity.");
            }

            var result = await _dbContext.Developers.AddAsync(new Developer
            {
                Name = entity.Name ?? latestEntity.Name,
                Phone = entity.Phone ?? latestEntity.Phone,
                IdCard = entity.IdCard ?? latestEntity.IdCard,
                DeveloperTypeCode = entity.DeveloperTypeCode.IsNotDefault() ? entity.DeveloperTypeCode : latestEntity.DeveloperTypeCode,
                Version = latestEntity.Version + 1,
                CreatedBy = latestEntity.CreatedBy,
                CreatedAt = latestEntity.CreatedAt,
                UpdatedBy = entity.UpdatedBy,
                UpdatedAt = UtcNow,
                IsActive = entity.IsActive,
                IsDeleted = entity.IsDeleted,
            }, cancellationToken);

            return result.State is not Added ? throw new Exception("Failed to add the new entity.") : await _dbContext.SaveChangesAsync(cancellationToken) <= 0 ? throw new Exception("Failed to save changes.") : result.Entity;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "AdjustAsync-DeveloperRepository-Exception: {Entity}", entity.Serialize());

            throw;
        }
    }
}
