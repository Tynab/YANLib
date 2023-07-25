using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using YANLib.EntityFrameworkCore.DbContext;
using YANLib.Models;
using static System.DateTime;
using static YANLib.YANLibDomainErrorCodes;

namespace YANLib.Repositories;

public sealed class DeveloperRepository : IDeveloperRepository
{
    #region Fields
    private readonly ILogger<DeveloperRepository> _logger;
    private readonly IYANLibDbContext _dbContext;
    #endregion

    #region Constructors
    public DeveloperRepository(ILogger<DeveloperRepository> logger, IYANLibDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }
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

    public async ValueTask<Developer> Get(Guid id)
    {
        try
        {
            return await _dbContext.Developers.AsNoTracking().Include(x => x.DeveloperType).FirstOrDefaultAsync(x => x.Id == id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetDeveloperRepository-Exception: {Id}", id);
            throw;
        }
    }

    public async ValueTask<Developer> Insert(Developer entity)
    {
        try
        {
            var devTypeTask = _dbContext.DeveloperTypes.AsNoTracking().FirstOrDefaultAsync(x => x.Code == entity.DeveloperTypeCode);

            entity.IsActive = true;
            entity.Version = 1;
            entity.CreatedDate = Now;
            _ = await _dbContext.Developers.AddAsync(entity);
            entity.DeveloperType = await devTypeTask;

            return await _dbContext.SaveChangesAsync() > 0 ? entity : throw new BusinessException(INTERNAL_SERVER_ERROR);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "InsertDeveloperRepository-Exception: {Entity}", entity.CamelSerialize());
            throw;
        }
    }
    #endregion
}
