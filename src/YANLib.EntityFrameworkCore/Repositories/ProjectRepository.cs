﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using YANLib.DbContexts;
using YANLib.Dtos;
using YANLib.Entities;
using static System.DateTime;

namespace YANLib.Repositories;

public class ProjectRepository(
    ILogger<ProjectRepository> logger,
    IDbContextProvider<IYANLibDbContext> dbContextProvider,
    IYANLibDbContext dbContext
) : EfCoreRepository<IYANLibDbContext, Project, string>(dbContextProvider), IProjectRepository
{
    private readonly ILogger<ProjectRepository> _logger = logger;
    private readonly IYANLibDbContext _dbContext = dbContext;

    public async ValueTask<Project?> Modify(ProjectDto dto)
    {
        try
        {
            return await _dbContext.Projects.Where(x => x.Id == dto.Id && x.IsDeleted == false).ExecuteUpdateAsync(s => s
                .SetProperty(x => x.Name, x => dto.Name ?? x.Name)
                .SetProperty(x => x.Description, x => dto.Description ?? x.Description)
                .SetProperty(x => x.UpdatedBy, dto.UpdatedBy)
                .SetProperty(x => x.UpdatedAt, UtcNow)
                .SetProperty(x => x.IsActive, x => dto.IsActive ?? x.IsActive)
                .SetProperty(x => x.IsDeleted, x => dto.IsDeleted ?? x.IsDeleted)
            ) > 0 ? await _dbContext.Projects.FindAsync(dto.Id) : default;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Modify-DeveloperProjectRepository-Exception: {DTO}", dto.Serialize());

            throw;
        }
    }
}
