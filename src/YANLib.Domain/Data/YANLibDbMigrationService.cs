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
    IDeveloperCertificateRepository developerCertificateRepository,
    ICertificateRepository certificateRepository
) : ITransientDependency
{
    private readonly IEnumerable<IYANLibDbSchemaMigrator> _dbSchemaMigrators = dbSchemaMigrators;
    private readonly IDeveloperTypeRepository _developerTypeRepository = developerTypeRepository;
    private readonly IDeveloperRepository _developerRepository = developerRepository;
    private readonly IDeveloperCertificateRepository _developerCertificateRepository = developerCertificateRepository;
    private readonly ICertificateRepository _certificateRepository = certificateRepository;

    public ILogger<YANLibDbMigrationService> Logger { get; set; } = NullLogger<YANLibDbMigrationService>.Instance;

    public async ValueTask MigrateAsync()
    {
        await MigrateDatabaseSchemaAsync();
        await SeedAsync();
    }

    private async ValueTask MigrateDatabaseSchemaAsync()
    {
        foreach (var migrator in _dbSchemaMigrators)
        {
            await migrator.MigrateAsync();
        }
    }

    private async ValueTask SeedAsync()
    {
        var createdBy = NewGuid();

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

        if (await _developerRepository.GetCountAsync() > 0)
        {
            await _developerRepository.DeleteManyAsync(await _developerRepository.GetListAsync());

            Logger.LogInformation("Developers deleted");
        }

        var fe = await _developerRepository.InsertAsync(new()
        {
            Name = "Nguyễn Văn A",
            DeveloperTypeId = feType.Id,
            CreatedBy = createdBy,
            CreatedAt = Now,
            IsActive = true,
            IsDeleted = false
        });

        Logger.LogInformation("Developer {Developer} created", fe.Name);

        var be = await _developerRepository.InsertAsync(new()
        {
            Name = "Trần Thị B",
            DeveloperTypeId = beType.Id,
            CreatedBy = createdBy,
            CreatedAt = Now,
            IsActive = true,
            IsDeleted = false
        });

        Logger.LogInformation("Developer {Developer} created", be.Name);

        var fs = await _developerRepository.InsertAsync(new()
        {
            Name = "Lê Văn C",
            DeveloperTypeId = fsType.Id,
            CreatedBy = createdBy,
            CreatedAt = Now,
            IsActive = true,
            IsDeleted = false
        });

        Logger.LogInformation("Developer {Developer} created", fs.Name);

        if (await _certificateRepository.GetCountAsync() > 0)
        {
            await _certificateRepository.DeleteManyAsync(await _certificateRepository.GetListAsync());

            Logger.LogInformation("Certificates deleted");
        }

        var java = await _certificateRepository.InsertAsync(new()
        {
            Name = "Java",
            GPA = 8.5,
            Description = "This certificate demonstrates proficiency in Java programming and OOP concepts.",
            CreatedBy = createdBy,
            CreatedAt = Now,
            IsActive = true,
            IsDeleted = false
        });

        Logger.LogInformation("Certificate {Certificate} created", java.Name);

        var python = await _certificateRepository.InsertAsync(new()
        {
            Name = "Python",
            GPA = 8.0,
            Description = "This certificate validates expertise in Python programming, data analysis, and scripting.",
            CreatedBy = createdBy,
            CreatedAt = Now,
            IsActive = true,
            IsDeleted = false
        });

        Logger.LogInformation("Certificate {Certificate} created", python.Name);

        var csharp = await _certificateRepository.InsertAsync(new()
        {
            Name = "C#",
            GPA = 9.0,
            Description = "This certificate proves skills in C# development for web and desktop applications.",
            CreatedBy = createdBy,
            CreatedAt = Now,
            IsActive = true,
            IsDeleted = false
        });

        Logger.LogInformation("Certificate {Certificate} created", csharp.Name);

        if (await _developerCertificateRepository.GetCountAsync() > 0)
        {
            await _developerCertificateRepository.DeleteManyAsync(await _developerCertificateRepository.GetListAsync());

            Logger.LogInformation("Developer certificates deleted");
        }

        await _developerCertificateRepository.InsertManyAsync(
        [
            new()
            {
                DeveloperId = be.Id,
                CertificateId = java.Id,
                CreatedBy = createdBy,
                CreatedAt = Now,
                IsActive = true,
                IsDeleted = false
            },
            new()
            {
                DeveloperId = be.Id,
                CertificateId = csharp.Id,
                CreatedBy = createdBy,
                CreatedAt = Now,
                IsActive = true,
                IsDeleted = false
            },
            new()
            {
                DeveloperId = fs.Id,
                CertificateId = python.Id,
                CreatedBy = createdBy,
                CreatedAt = Now,
                IsActive = true,
                IsDeleted = false
            },
        ]);

        Logger.LogInformation("Developer certificates created");
    }
}
