using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using YANLib.Repositories;

namespace YANLib;

public class YANLibTestDataSeedContributor(IDeveloperTypeRepository repository) : IDataSeedContributor, ITransientDependency
{
    private readonly IDeveloperTypeRepository _repository = repository;

    public async Task SeedAsync(DataSeedContext context) => await SeedDeveloperTypeAsync();

    public async Task SeedDeveloperTypeAsync()
    {
        var createdBy = Guid.NewGuid();

        _ = await _repository.InsertAsync(new()
        {
            Name = "Front-End",
            CreatedBy = createdBy,
            CreatedAt = DateTime.Now,
            IsActive = true,
            IsDeleted = false
        });

        _ = await _repository.InsertAsync(new()
        {
            Name = "Back-End",
            CreatedBy = createdBy,
            CreatedAt = DateTime.Now,
            IsActive = true,
            IsDeleted = false
        });

        _ = await _repository.InsertAsync(new()
        {
            Name = "Full-Stack",
            CreatedBy = createdBy,
            CreatedAt = DateTime.Now,
            IsActive = true,
            IsDeleted = false
        });
    }
}
