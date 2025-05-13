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

namespace YANLib.Repositories;

public class DeveloperProjectRepository(
    ILogger<DeveloperProjectRepository> logger,
    IDbContextProvider<IYANLibDbContext> dbContextProvider,
    IYANLibDbContext dbContext
) : EfCoreRepository<IYANLibDbContext, DeveloperProject, Guid>(dbContextProvider), IDeveloperProjectRepository
{
    private readonly ILogger<DeveloperProjectRepository> _logger = logger;
    private readonly IYANLibDbContext _dbContext = dbContext;

    public async Task<DeveloperProject?> Modify(DeveloperProjectDto dto, CancellationToken cancellationToken = default)
    {
        try
        {
            return await _dbContext.DeveloperProjects.Where(x => x.Id == dto.Id && x.IsDeleted == false).ExecuteUpdateAsync(s => s
                .SetProperty(x => x.UpdatedBy, dto.UpdatedBy)
                .SetProperty(x => x.UpdatedAt, UtcNow)
                .SetProperty(x => x.IsActive, x => dto.IsActive ?? x.IsActive)
                .SetProperty(x => x.IsDeleted, x => dto.IsDeleted ?? x.IsDeleted)
                .SetProperty(x => x.DeveloperId, dto.DeveloperId)
                .SetProperty(x => x.ProjectId, dto.ProjectId)
            , cancellationToken) > 0 ? await _dbContext.DeveloperProjects.FindAsync([dto.Id, cancellationToken], cancellationToken: cancellationToken) : default;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Modify-DeveloperProjectRepository-Exception: {DTO}", dto.Serialize());

            throw;
        }
    }
}
