using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using YANLib.DbContexts;
using static System.DateTime;

namespace YANLib;

public class BaseRepository<TEntity>(
    ILogger<BaseRepository<TEntity>> logger,
    IDbContextProvider<IBaseDbContext> dbContextProvider,
    IBaseDbContext dbContext
) : EfCoreRepository<IBaseDbContext, TEntity, Guid>(dbContextProvider), IBaseRepository<TEntity> where TEntity : BaseEntity
{
    public async Task<bool> SoftDeleteAsync(Guid id, Guid updatedBy, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            return await dbContext.Set<TEntity>().Where(x => x.Id == id && !x.IsDeleted).ExecuteUpdateAsync(s => s
                .SetProperty(x => x.UpdatedBy, updatedBy)
                .SetProperty(x => x.UpdatedAt, UtcNow)
                .SetProperty(x => x.IsActive, false)
                .SetProperty(x => x.IsDeleted, true),
            cancellationToken) > 0;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "SoftDeleteAsync-BaseRepository-Exception: {Id}", id);

            throw;
        }
    }

    public async Task<bool> SoftDeleteManyAsync(Expression<Func<TEntity, bool>> predicate, Guid updatedBy, CancellationToken cancellationToken = default)
    {
        try
        {
            return await dbContext.Set<TEntity>().Where(predicate).Where(x => !x.IsDeleted).ExecuteUpdateAsync(s => s
                .SetProperty(x => x.UpdatedBy, updatedBy)
                .SetProperty(x => x.UpdatedAt, UtcNow)
                .SetProperty(x => x.IsActive, false)
                .SetProperty(x => x.IsDeleted, true),
            cancellationToken) > 0;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "SoftDeleteManyAsync-BaseRepository-Exception");

            throw;
        }
    }
}
