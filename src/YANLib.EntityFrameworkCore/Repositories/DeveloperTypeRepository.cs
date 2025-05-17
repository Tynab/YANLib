using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using YANLib.DbContexts;
using YANLib.Dtos;
using YANLib.Entities;
using static System.DateTime;

namespace YANLib.Domains;

public class DeveloperTypeRepository(
    ILogger<DeveloperTypeRepository> logger,
    IDbContextProvider<IYANLibDbContext> dbContextProvider,
    IYANLibDbContext dbContext
) : EfCoreRepository<IYANLibDbContext, DeveloperType, long>(dbContextProvider), IDeveloperTypeRepository
{
    private readonly ILogger<DeveloperTypeRepository> _logger = logger;
    private readonly IYANLibDbContext _dbContext = dbContext;

    public async Task<DeveloperType?> ModifyAsync(DeveloperTypeDto dto, CancellationToken cancellationToken = default)
    {
        try
        {
            return await _dbContext.DeveloperTypes.Where(x => x.Id == dto.Id && x.IsDeleted == false).ExecuteUpdateAsync(s => s
                .SetProperty(x => x.UpdatedBy, dto.UpdatedBy)
                .SetProperty(x => x.UpdatedAt, UtcNow)
                .SetProperty(x => x.IsActive, x => dto.IsActive ?? x.IsActive)
                .SetProperty(x => x.IsDeleted, x => dto.IsDeleted ?? x.IsDeleted)
                .SetProperty(x => x.Name, x => dto.Name ?? x.Name)
            , cancellationToken) > 0 ? await _dbContext.DeveloperTypes.FindAsync([dto.Id, cancellationToken], cancellationToken) : default;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "ModifyAsync-DeveloperTypeRepository-Exception: {DTO}", dto.Serialize());

            throw;
        }
    }
}
