using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using YANLib.Domains;

namespace YANLib;

public class YANLibTestDataSeedContributor(IDeveloperTypeRepository developerTypeRepository, IProjectRepository projectRepository) : IDataSeedContributor, ITransientDependency
{
    private readonly IDeveloperTypeRepository _developerTypeRepository = developerTypeRepository;
    private readonly IProjectRepository _projectRepository = projectRepository;
    private static readonly object _lockObject = new();
    private static bool _seeded = false;

    public async Task SeedAsync(DataSeedContext context)
    {
        if (_seeded)
        {
            return;
        }

        lock (_lockObject)
        {
            if (_seeded)
            {
                return;
            }

            _seeded = true;
        }

        await SeedDeveloperTypeAsync();
        await SeedProjectsAsync();
    }

    public async Task SeedDeveloperTypeAsync()
    {
        try
        {
            if ((await _developerTypeRepository.GetListAsync()).Count.IsNotDefault())
            {
                return;
            }

            var createdBy = Guid.NewGuid();

            _ = await _developerTypeRepository.InsertAsync(new()
            {
                Name = "Front-End",
                CreatedBy = createdBy,
                CreatedAt = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            }, true);

            _ = await _developerTypeRepository.InsertAsync(new()
            {
                Name = "Back-End",
                CreatedBy = createdBy,
                CreatedAt = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            }, true);

            _ = await _developerTypeRepository.InsertAsync(new()
            {
                Name = "Full-Stack",
                CreatedBy = createdBy,
                CreatedAt = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            }, true);
        }
        catch (DbUpdateException) { }
    }

    public async Task SeedProjectsAsync()
    {
        try
        {
            if ((await _projectRepository.GetListAsync()).Count.IsNotDefault())
            {
                return;
            }

            var createdBy = Guid.NewGuid();

            _ = await _projectRepository.InsertAsync(new()
            {
                Name = "Seed Project 1",
                Description = "Seed Project Description 1",
                CreatedBy = createdBy,
                CreatedAt = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            }, true);

            _ = await _projectRepository.InsertAsync(new()
            {
                Name = "Seed Project 2",
                Description = "Seed Project Description 2",
                CreatedBy = createdBy,
                CreatedAt = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            }, true);

            _ = await _projectRepository.InsertAsync(new()
            {
                Name = "Seed Project 3",
                Description = "Seed Project Description 3",
                CreatedBy = createdBy,
                CreatedAt = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            }, true);
        }
        catch (DbUpdateException) { }
    }
}
