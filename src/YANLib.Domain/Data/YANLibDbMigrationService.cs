using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;
using YANLib.Entities;
using YANLib.Repositories;
using Volo.Abp.Guids;
using static System.DateTime;
using static System.Guid;
using Volo.Abp.Domain.Repositories;

namespace YANLib.Data;

public class YANLibDbMigrationService(
    IEnumerable<IYANLibDbSchemaMigrator> dbSchemaMigrators,
    IDeveloperTypeRepository developerTypeRepository,
    IDeveloperRepository developerRepository
) : ITransientDependency
{
    public ILogger<YANLibDbMigrationService> Logger { get; set; } = NullLogger<YANLibDbMigrationService>.Instance;

    private readonly IEnumerable<IYANLibDbSchemaMigrator> _dbSchemaMigrators = dbSchemaMigrators;
    private readonly IDeveloperTypeRepository _developerTypeRepository = developerTypeRepository;
    private readonly IDeveloperRepository _developerRepository = developerRepository;

    public async ValueTask MigrateAsync()
    {
        //await MigrateDatabaseSchemaAsync();
        await SeedAsync();
    }

    private async ValueTask MigrateDatabaseSchemaAsync()
    {
        foreach (var migrator in _dbSchemaMigrators)
        {
            await migrator.MigrateAsync();
        }
    }

    public async ValueTask SeedAsync()
    {
        if (await _developerTypeRepository.GetCountAsync() > 0 || await _developerRepository.GetCountAsync() > 0)
        {
            return;
        }

        var createdBy = NewGuid();

        var feType = await _developerTypeRepository.InsertAsync(new()
        {
            Name = "Front-End",
            CreatedBy = createdBy,
            CreatedAt = Now,
            IsActive = true,
            IsDeleted = false
        });

        var fe = await _developerRepository.InsertAsync(new()
        {
            Name = "Nguyễn Văn A",
            DeveloperTypeId = feType.Id,
            CreatedBy = createdBy,
            CreatedAt = Now,
            IsActive = true,
            IsDeleted = false
        });

        var beType = await _developerTypeRepository.InsertAsync(new()
        {
            Name = "Back-End",
            CreatedBy = createdBy,
            CreatedAt = Now,
            IsActive = true,
            IsDeleted = false
        });

        var be = await _developerRepository.InsertAsync(new()
        {
            Name = "Trần Thị B",
            DeveloperTypeId = beType.Id,
            CreatedBy = createdBy,
            CreatedAt = Now,
            IsActive = true,
            IsDeleted = false
        });

        var fsType = await _developerTypeRepository.InsertAsync(new()
        {
            Name = "Full-Stack",
            CreatedBy = createdBy,
            CreatedAt = Now,
            IsActive = true,
            IsDeleted = false
        });

        var fs = await _developerRepository.InsertAsync(new()
        {
            Name = "Lê Văn C",
            DeveloperTypeId = fsType.Id,
            CreatedBy = createdBy,
            CreatedAt = Now,
            IsActive = true,
            IsDeleted = false
        });
    }
}
