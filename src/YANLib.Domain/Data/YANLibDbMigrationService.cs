using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using YANLib.Repositories;
using static System.DateTime;
using static System.Guid;

namespace YANLib.Data;

public class YANLibDbMigrationService(
    IEnumerable<IYANLibDbSchemaMigrator> dbSchemaMigrators,
    IDeveloperTypeRepository developerTypeRepository,
    IDeveloperRepository developerRepository,
    IDeveloperProjectRepository developerProjectRepository,
    IProjectRepository projectRepository
) : ITransientDependency
{
    private readonly IEnumerable<IYANLibDbSchemaMigrator> _dbSchemaMigrators = dbSchemaMigrators;
    private readonly IDeveloperTypeRepository _developerTypeRepository = developerTypeRepository;
    private readonly IDeveloperRepository _developerRepository = developerRepository;
    private readonly IDeveloperProjectRepository _developerProjectRepository = developerProjectRepository;
    private readonly IProjectRepository _projectRepository = projectRepository;

    public ILogger<YANLibDbMigrationService> Logger { get; set; } = NullLogger<YANLibDbMigrationService>.Instance;

    public async Task MigrateAsync()
    {
        await MigrateDatabaseSchemaAsync();
        await SeedAsync();
    }

    private async Task MigrateDatabaseSchemaAsync()
    {
        foreach (var migrator in _dbSchemaMigrators)
        {
            await migrator.MigrateAsync();
        }
    }

    private async Task SeedAsync()
    {
        var createdBy = NewGuid();

        #region DeveloperType

        if (await _developerTypeRepository.GetCountAsync() > 0)
        {
            await _developerTypeRepository.DeleteManyAsync(await _developerTypeRepository.GetListAsync());

            Logger.LogInformation("Developer types deleted");
        }

        var feType = await _developerTypeRepository.InsertAsync(new()
        {
            Name = "Front-End",
            CreatedBy = createdBy,
            CreatedAt = Now,
            IsActive = true,
            IsDeleted = false
        });

        Logger.LogInformation("Developer type {DeveloperType} created", feType.Name);

        var beType = await _developerTypeRepository.InsertAsync(new()
        {
            Name = "Back-End",
            CreatedBy = createdBy,
            CreatedAt = Now,
            IsActive = true,
            IsDeleted = false
        });

        Logger.LogInformation("Developer type {DeveloperType} created", beType.Name);

        var fsType = await _developerTypeRepository.InsertAsync(new()
        {
            Name = "Full-Stack",
            CreatedBy = createdBy,
            CreatedAt = Now,
            IsActive = true,
            IsDeleted = false
        });

        Logger.LogInformation("Developer type {DeveloperType} created", fsType.Name);

        #endregion

        #region Developer

        if (await _developerRepository.GetCountAsync() > 0)
        {
            await _developerRepository.DeleteManyAsync(await _developerRepository.GetListAsync());

            Logger.LogInformation("Developers deleted");
        }

        var fe = await _developerRepository.InsertAsync(new()
        {
            Name = "Nguyễn Văn A",
            Phone = "0123456789",
            IdCard = "123456789012",
            DeveloperTypeCode = feType.Id,
            RawVersion = 1,
            CreatedBy = createdBy,
            CreatedAt = Now,
            IsActive = true,
            IsDeleted = false
        });

        Logger.LogInformation("Developer {Developer} created", fe.Name);

        var be = await _developerRepository.InsertAsync(new()
        {
            Name = "Trần Thị B",
            Phone = "0987654321",
            IdCard = "987654321098",
            DeveloperTypeCode = beType.Id,
            RawVersion = 1,
            CreatedBy = createdBy,
            CreatedAt = Now,
            IsActive = true,
            IsDeleted = false
        });

        Logger.LogInformation("Developer {Developer} created", be.Name);

        var fs = await _developerRepository.InsertAsync(new()
        {
            Name = "Lê Văn C",
            Phone = "1234567890",
            IdCard = "012345678901",
            DeveloperTypeCode = fsType.Id,
            RawVersion = 1,
            CreatedBy = createdBy,
            CreatedAt = Now,
            IsActive = true,
            IsDeleted = false
        });

        Logger.LogInformation("Developer {Developer} created", fs.Name);

        #endregion

        #region Project

        if (await _projectRepository.GetCountAsync() > 0)
        {
            await _projectRepository.DeleteManyAsync(await _projectRepository.GetListAsync());

            Logger.LogInformation("Projects deleted");
        }

        var retail = await _projectRepository.InsertAsync(new()
        {
            Name = "Retail Insights",
            Description = "A project to provide customer insights and sales trends in the retail domain.",
            CreatedBy = createdBy,
            CreatedAt = Now,
            IsActive = true,
            IsDeleted = false
        });

        Logger.LogInformation("Project {Project} created", retail.Name);

        var banking = await _projectRepository.InsertAsync(new()
        {
            Name = "Banking Customer Insights",
            Description = "A system to analyze customer behaviors and trends in banking operations.",
            CreatedBy = createdBy,
            CreatedAt = Now,
            IsActive = true,
            IsDeleted = false
        });

        Logger.LogInformation("Project {Project} created", banking.Name);

        var edu = await _projectRepository.InsertAsync(new()
        {
            Name = "Edu Analytics",
            Description = "A platform that tracks educational performance and trends across institutions.",
            CreatedBy = createdBy,
            CreatedAt = Now,
            IsActive = true,
            IsDeleted = false
        });

        Logger.LogInformation("Project {Project} created", edu.Name);

        var blockchain = await _projectRepository.InsertAsync(new()
        {
            Name = "Blockchain Analysis",
            Description = "A project to analyze trends and transactions in blockchain ecosystems.",
            CreatedBy = createdBy,
            CreatedAt = Now,
            IsActive = true,
            IsDeleted = false
        });

        Logger.LogInformation("Project {Project} created", blockchain.Name);

        #endregion

        #region DeveloperProject

        if (await _developerProjectRepository.GetCountAsync() > 0)
        {
            await _developerProjectRepository.DeleteManyAsync(await _developerProjectRepository.GetListAsync());

            Logger.LogInformation("Developer projects deleted");
        }

        await _developerProjectRepository.InsertManyAsync(
        [
            new()
            {
                DeveloperId = be.Id,
                ProjectId = retail.Id,
                CreatedBy = createdBy,
                CreatedAt = Now,
                IsActive = true,
                IsDeleted = false
            },
            new()
            {
                DeveloperId = be.Id,
                ProjectId = edu.Id,
                CreatedBy = createdBy,
                CreatedAt = Now,
                IsActive = true,
                IsDeleted = false
            },
            new()
            {
                DeveloperId = fs.Id,
                ProjectId = banking.Id,
                CreatedBy = createdBy,
                CreatedAt = Now,
                IsActive = true,
                IsDeleted = false
            },
        ]);

        Logger.LogInformation("Developer projects created");

        #endregion
    }
}
