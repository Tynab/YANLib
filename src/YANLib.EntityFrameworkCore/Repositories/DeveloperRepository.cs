using YANLib.EntityFrameworkCore.DbContext;

namespace YANLib.Repositories;

public sealed class DeveloperRepository(ILogger<DeveloperRepository> logger, IYANLibDbContext dbContext) : IDeveloperRepository
{
    #region Fields
    private readonly ILogger<DeveloperRepository> _logger = logger;
    private readonly IYANLibDbContext _dbContext = dbContext;
    #endregion

    #region Implements
    public async ValueTask<IEnumerable<Developer>> GetAll()
    {
        try
        {
            return await _dbContext.Developers.AsNoTracking().Include(x => x.DeveloperType).ToArrayAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetAllDeveloperRepository-Exception");
            throw;
        }
    }

    public async ValueTask<Developer> Create(Developer entity)
    {
        try
        {
            entity.IsActive = true;
            entity.Version = 1;
            entity.CreatedAt = Now;
            _ = await _dbContext.Developers.AddAsync(entity);

            if (await _dbContext.SaveChangesAsync() > 0)
            {
                entity.DeveloperType = await _dbContext.DeveloperTypes.AsNoTracking().SingleOrDefaultAsync(x => x.Id == entity.DeveloperTypeCode);
                return entity;
            }
            else
            {
                return default;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "CreateDeveloperRepository-Exception: {Entity}", entity.Serialize());
            throw;
        }
    }

    public async ValueTask<Developer> Adjust(Developer entity)
    {
        try
        {
            if (await _dbContext.Developers.Where(x => x.IdCard == entity.IdCard).ExecuteUpdateAsync(s => s
                .SetProperty(x => x.IsActive, false)
                .SetProperty(x => x.UpdatedAt, Now)) > 0)
            {
                entity.IsActive = true;
                entity.Version++;
                entity.CreatedAt = Now;
                _ = await _dbContext.Developers.AddAsync(entity);

                if (await _dbContext.SaveChangesAsync() > 0)
                {
                    entity.DeveloperType = await _dbContext.DeveloperTypes.AsNoTracking().SingleOrDefaultAsync(x => x.Id == entity.DeveloperTypeCode);
                    return entity;
                }
                else
                {
                    return default;
                }
            }
            else
            {
                return default;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "AdjustDeveloperRepository-Exception: {Entity}", entity.Serialize());
            throw;
        }
    }
    #endregion
}
