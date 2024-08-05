using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using YANLib.Core;
using YANLib.DbContext;
using YANLib.Dtos;
using YANLib.Entities;
using static System.DateTime;

namespace YANLib.Repositories;

public class DeveloperRepository(
    ILogger<DeveloperRepository> logger,
    IDbContextProvider<IYANLibDbContext> dbContextProvider,
    IYANLibDbContext dbContext
) : EfCoreRepository<IYANLibDbContext, Developer, Guid>(dbContextProvider), IDeveloperRepository
{
    private readonly ILogger<DeveloperRepository> _logger = logger;
    private readonly IYANLibDbContext _dbContext = dbContext;

    public async ValueTask<Developer> Modify(DeveloperDto dto)
    {
        try
        {
            return await _dbContext.Developers.Where(x => x.Id == dto.Id && x.IsDeleted == false).ExecuteUpdateAsync(s => s
                .SetProperty(x => x.Name, x => dto.Name.IsNull() ? dto.Name : x.Name)
                .SetProperty(x => x.Phone, x => dto.Phone.IsNull() ? dto.Phone : x.Phone)
                .SetProperty(x => x.IdCard, x => dto.IdCard.IsNull() ? dto.IdCard : x.IdCard)
                .SetProperty(x => x.DeveloperTypeCode, x => dto.DeveloperTypeCode ?? x.DeveloperTypeCode)
                .SetProperty(x => x.UpdatedBy, dto.UpdatedBy)
                .SetProperty(x => x.UpdatedAt, UtcNow)
                .SetProperty(x => x.IsActive, x => dto.IsActive ?? x.IsActive)
                .SetProperty(x => x.IsDeleted, x => dto.IsDeleted ?? x.IsDeleted)
            ) > 0 ? await _dbContext.SaveChangesAsync() > 0 ? await _dbContext.Developers.FindAsync(dto.Id) : default : default;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "ModifyDeveloperRepository-Exception: {DTO}", dto.Serialize());

            throw;
        }
    }

    public async ValueTask<Developer> Adjust(Developer entity)
    {
        try
        {
            var rslt = await _dbContext.Developers.AddAsync(entity);

            return await _dbContext.Developers.Where(x => x.IdCard == entity.IdCard && x.Version == entity.Version - 1 && x.IsDeleted == false).ExecuteUpdateAsync(s => s
                .SetProperty(x => x.UpdatedBy, entity.UpdatedBy)
                .SetProperty(x => x.UpdatedAt, UtcNow)
                .SetProperty(x => x.IsDeleted, true)
            ) > 0 ? await _dbContext.SaveChangesAsync() > 0 ? rslt.Entity : default : default;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "AdjustDeveloperRepository-Exception: {Entity}", entity.Serialize());

            throw;
        }
    }
}
