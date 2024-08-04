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

public class DeveloperTypeRepository(
    ILogger<DeveloperTypeRepository> logger,
    IDbContextProvider<IYANLibDbContext> dbContextProvider,
    IYANLibDbContext dbContext
) : EfCoreRepository<IYANLibDbContext, DeveloperType, Guid>(dbContextProvider), IDeveloperTypeRepository
{
    private readonly ILogger<DeveloperTypeRepository> _logger = logger;
    private readonly IYANLibDbContext _dbContext = dbContext;

    public async ValueTask<DeveloperType> Modify(DeveloperTypeDto dto)
    {
        try
        {
            return await _dbContext.DeveloperTypes.Where(x => x.Id == dto.Id).ExecuteUpdateAsync(s => s
                .SetProperty(x => x.Name, x => dto.Name.IsNull() ? dto.Name : x.Name)
                .SetProperty(x => x.UpdatedBy, dto.UpdatedBy)
                .SetProperty(x => x.UpdatedAt, UtcNow)
                .SetProperty(x => x.IsActive, x => dto.IsActive ?? x.IsActive)
                .SetProperty(x => x.IsDeleted, x => dto.IsDeleted ?? x.IsDeleted)
            ) > 0 ? await _dbContext.SaveChangesAsync() > 0 ? await _dbContext.DeveloperTypes.AsNoTracking().SingleOrDefaultAsync(x => x.Id == dto.Id) : default : default;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "ModifyDeveloperTypeRepository-Exception: {DTO}", dto.Serialize());

            throw;
        }
    }
}
