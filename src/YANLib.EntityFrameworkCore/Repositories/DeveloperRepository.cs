using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using YANLib.Entities;
using YANLib.EntityFrameworkCore.DbContext.Implements;
using static System.DateTime;
using static YANLib.YANLibDomainErrorCodes;

namespace YANLib.Repositories;

public sealed class DeveloperRepository : EfCoreRepository<YANLibDbContext, Developer, string>, IDeveloperRepository
{
    #region Fields
    private readonly ILogger<DeveloperRepository> _logger;
    #endregion

    #region Constructors
    public DeveloperRepository(ILogger<DeveloperRepository> logger, IDbContextProvider<YANLibDbContext> dbContextProvider) : base(dbContextProvider) => _logger = logger;
    #endregion

    #region Implements
    public async ValueTask<Developer> Adjust(Developer entity)
    {
        try
        {
            var dbContext = await GetDbContextAsync();
            var mdls = await dbContext.Developers.AsNoTracking().Where(x => x.IdCard == entity.IdCard).ToArrayAsync();

            if (mdls.IsEmptyOrNull())
            {
                throw new BusinessException(NOT_FOUND_DEV).WithData("IdCard", entity.IdCard);
            }

            dbContext.Developers.UpdateRange(mdls.Select(x =>
            {
                x.IsActive = false;
                x.ModifiedDate = Now;

                return x;
            }));

            entity.IsActive = true;
            entity.Version++;
            entity.CreatedDate = Now;

            var rslt = (await dbContext.Developers.AddAsync(entity)).Entity;

            return await dbContext.SaveChangesAsync() > 0 ? rslt : throw new BusinessException(INTERNAL_SERVER_ERROR);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "AdjustDeveloperRepository-Exception: {Entity}", entity.CamelSerialize());
            throw;
        }
    }
    #endregion
}
