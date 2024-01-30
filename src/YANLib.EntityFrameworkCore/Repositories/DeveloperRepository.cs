using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YANLib.Core;
using YANLib.Entities;
using YANLib.EntityFrameworkCore.DbContext;
using static System.DateTime;

namespace YANLib.Repositories;

public sealed class DeveloperRepository(ILogger<DeveloperRepository> logger, IYANLibDbContext dbContext) : IDeveloperRepository
{
    private readonly ILogger<DeveloperRepository> _logger = logger;
    private readonly IYANLibDbContext _dbContext = dbContext;

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
                entity.DeveloperType = await _dbContext.DeveloperTypes.SingleOrDefaultAsync(x => x.Id == entity.DeveloperTypeCode);

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
            var entities = await _dbContext.Developers.Where(x => x.IdCard == entity.IdCard && x.IsActive == true).ToListAsync();

            if (entities.IsNotNull())
            {
                entities.ForEach(x =>
                {
                    x.IsActive = false;
                    x.UpdatedAt = Now;
                });

                _dbContext.Developers.UpdateRange(entities);
                entity.IsActive = true;
                entity.Version++;
                entity.CreatedAt = Now;
                _ = await _dbContext.Developers.AddAsync(entity);

                if (await _dbContext.SaveChangesAsync() > 0)
                {
                    entity.DeveloperType = await _dbContext.DeveloperTypes.SingleOrDefaultAsync(x => x.Id == entity.DeveloperTypeCode);

                    return entity;
                }
            }

            return default;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "AdjustDeveloperRepository-Exception: {Entity}", entity.Serialize());
            throw;
        }
    }
}
