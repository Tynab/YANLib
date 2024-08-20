﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using YANLib.Core;
using YANLib.DbContexts;
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

    public async ValueTask<DeveloperType?> Modify(DeveloperTypeDto dto)
    {
        try
        {
            return await _dbContext.DeveloperTypes.Where(x => x.Id == dto.Id && x.IsDeleted == false).ExecuteUpdateAsync(s => s
                .SetProperty(x => x.Name, x => dto.Name.IsNull() ? x.Name : dto.Name)
                .SetProperty(x => x.UpdatedBy, dto.UpdatedBy)
                .SetProperty(x => x.UpdatedAt, UtcNow)
                .SetProperty(x => x.IsActive, x => dto.IsActive ?? x.IsActive)
                .SetProperty(x => x.IsDeleted, x => dto.IsDeleted ?? x.IsDeleted)
            ) > 0 ? await _dbContext.DeveloperTypes.FindAsync(dto.Id) : default;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Modify-DeveloperTypeRepository-Exception: {DTO}", dto.Serialize());

            throw;
        }
    }
}
