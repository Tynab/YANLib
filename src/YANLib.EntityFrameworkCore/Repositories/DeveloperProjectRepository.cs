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

    public async Task<DeveloperProject?> ModifyAsync(DeveloperProjectDto dto, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            return await _dbContext.DeveloperProjects.Where(x => x.Id == dto.Id && x.IsDeleted == false).ExecuteUpdateAsync(s => s
                .SetProperty(x => x.UpdatedBy, dto.UpdatedBy)
                .SetProperty(x => x.UpdatedAt, UtcNow)
                .SetProperty(x => x.IsActive, x => dto.IsActive ?? x.IsActive)
                .SetProperty(x => x.IsDeleted, x => dto.IsDeleted ?? x.IsDeleted)
                .SetProperty(x => x.DeveloperId, x => dto.DeveloperId ?? x.DeveloperId)
                .SetProperty(x => x.ProjectId, x => dto.ProjectId ?? x.ProjectId)
            , cancellationToken) > 0 ? await _dbContext.DeveloperProjects.FindAsync([dto.Id, cancellationToken], cancellationToken: cancellationToken) : default;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "ModifyAsync-DeveloperProjectRepository-Exception: {DTO}", dto.Serialize());

            throw;
        }
    }
}
