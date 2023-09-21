using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YANLib.Entities;
using YANLib.EntityFrameworkCore.DbContext;
using static System.DateTime;

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

    public async ValueTask<Developer> Insert(Developer entity)
    {
        try
        {
            entity.IsActive = true;
            entity.Version = 1;
            entity.CreatedDate = Now;
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
            _logger.LogError(ex, "InsertDeveloperRepository-Exception: {Entity}", entity.CamelSerialize());
            throw;
        }
    }

    public async ValueTask<Developer> Adjust(Developer entity)
    {
        try
        {
            if (await _dbContext.Developers.Where(x => x.IdCard == entity.IdCard).ExecuteUpdateAsync(s => s
                .SetProperty(x => x.IsActive, false)
                .SetProperty(x => x.ModifiedDate, Now)) > 0)
            {
                entity.IsActive = true;
                entity.Version++;
                entity.CreatedDate = Now;
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
            _logger.LogError(ex, "AdjustDeveloperRepository-Exception: {Entity}", entity.CamelSerialize());
            throw;
        }
    }
    #endregion
}
