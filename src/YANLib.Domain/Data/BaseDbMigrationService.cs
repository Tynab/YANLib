using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Volo.Abp.DependencyInjection;
using YANLib;
using YANLib.Entities;
using YANLib.Enums;
using static System.DateTime;
using static System.Guid;

namespace YANLib.Data;

public class BaseDbMigrationService(IEnumerable<IBaseDbSchemaMigrator> dbSchemaMigrators, IBaseRepository<Sample> sampleRepository) : ITransientDependency
{
    public ILogger<BaseDbMigrationService> Logger { get; set; } = NullLogger<BaseDbMigrationService>.Instance;

    public async Task MigrateAsync()
    {
        await MigrateDatabaseSchemaAsync();
        await SeedAsync();
    }

    private async Task MigrateDatabaseSchemaAsync()
    {
        foreach (var migrator in dbSchemaMigrators)
        {
            await migrator.MigrateAsync();
        }
    }

    private async Task SeedAsync()
    {
        var createdBy = NewGuid();
        var createdAt = UtcNow;

        #region Sample Data

        if (await sampleRepository.GetCountAsync() > 0)
        {
            Logger.LogInformation("Samples already exist. Skipping seeding.");

            return;
        }

        var samples = new List<Sample>
        {
            new()
            {
                Name = "Retail Insights",
                Description = "A project to provide customer insights and sales trends in the retail domain.",
                Type = SampleType.Retail,
                CreatedBy = createdBy,
                CreatedAt = createdAt.AddDays(-1),
                UpdatedBy = createdBy,
                UpdatedAt = createdAt.AddDays(-1),
                IsActive = true,
                IsDeleted = false
            },
            new()
            {
                Name = "Banking Customer Insights",
                Description = "A system to analyze customer behaviors and trends in banking operations.",
                Type = SampleType.Banking,
                CreatedBy = createdBy,
                CreatedAt = createdAt.AddDays(-2),
                UpdatedBy = createdBy,
                UpdatedAt = createdAt.AddDays(-2),
                IsActive = true,
                IsDeleted = false
            },
            new()
            {
                Name = "Edu Analytics",
                Description = "A platform that tracks educational performance and trends across institutions.",
                Type = SampleType.Edu,
                CreatedBy = createdBy,
                CreatedAt = createdAt.AddDays(-2),
                UpdatedBy = createdBy,
                UpdatedAt = createdAt.AddDays(-1),
                IsActive = true,
                IsDeleted = false
            },
            new()
            {
                Name = "Blockchain Analysis",
                Description = "A project to analyze trends and transactions in blockchain ecosystems.",
                Type = SampleType.Blockchain,
                CreatedBy = createdBy,
                CreatedAt = createdAt.AddDays(-3),
                UpdatedBy = createdBy,
                UpdatedAt = createdAt.AddDays(-3),
                IsActive = true,
                IsDeleted = false
            }
        };

        foreach (var sample in samples)
        {
            var entity = await sampleRepository.InsertAsync(sample);

            Logger.LogInformation("Inserted sample: {SampleId} with Id: {SampleId}", sample.Name, entity.Id);
        }

        Logger.LogInformation("Seeded {Count} samples.", samples.Count);

        #endregion
    }
}
