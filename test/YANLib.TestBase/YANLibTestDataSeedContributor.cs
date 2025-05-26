using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using YANLib.Repositories;

namespace YANLib;

public class YANLibTestDataSeedContributor(
    IDeveloperTypeRepository developerTypeRepository,
    IDeveloperRepository developerRepository,
    IProjectRepository projectRepository,
    IDeveloperProjectRepository developerProjectRepository
) : IDataSeedContributor, ITransientDependency
{
    private readonly IDeveloperTypeRepository _developerTypeRepository = developerTypeRepository;
    private readonly IDeveloperRepository _developerRepository = developerRepository;
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly IDeveloperProjectRepository _developerProjectRepository = developerProjectRepository;
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
        await SeedDeveloperAsync();
        await SeedProjectAsync();
        await SeedDeveloperProjectAsync();
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

    public async Task SeedDeveloperAsync()
    {
        try
        {
            if ((await _developerRepository.GetListAsync()).Count.IsNotDefault())
            {
                return;
            }

            var developerTypes = await _developerTypeRepository.GetListAsync();

            if (developerTypes.Count == 0)
            {
                await SeedDeveloperTypeAsync();
                developerTypes = await _developerTypeRepository.GetListAsync();
            }

            var firstDeveloperType = developerTypes[0];
            var createdBy = Guid.NewGuid();

            _ = await _developerRepository.InsertAsync(new()
            {
                Name = "John Doe",
                Phone = "1234567890",
                IdCard = "ID123456789",
                DeveloperTypeCode = firstDeveloperType.Id,
                RawVersion = 1,
                CreatedBy = createdBy,
                CreatedAt = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            }, true);

            _ = await _developerRepository.InsertAsync(new()
            {
                Name = "Jane Smith",
                Phone = "0987654321",
                IdCard = "ID987654321",
                DeveloperTypeCode = firstDeveloperType.Id,
                RawVersion = 1,
                CreatedBy = createdBy,
                CreatedAt = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            }, true);

            _ = await _developerRepository.InsertAsync(new()
            {
                Name = "Bob Johnson",
                Phone = "5555555555",
                IdCard = "ID555555555",
                DeveloperTypeCode = firstDeveloperType.Id,
                RawVersion = 1,
                CreatedBy = createdBy,
                CreatedAt = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            }, true);
        }
        catch (DbUpdateException) { }
    }

    public async Task SeedProjectAsync()
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

    public async Task SeedDeveloperProjectAsync()
    {
        try
        {
            if ((await _developerProjectRepository.GetListAsync()).Count.IsNotDefault())
            {
                return;
            }

            var developers = await _developerRepository.GetListAsync();
            var projects = await _projectRepository.GetListAsync();

            if (developers.IsNullEmpty())
            {
                await SeedDeveloperAsync();
                developers = await _developerRepository.GetListAsync();
            }

            if (projects.IsNullEmpty())
            {
                await SeedProjectAsync();
                projects = await _projectRepository.GetListAsync();
            }

            if (developers.IsNullEmpty() || projects.IsNullEmpty())
            {
                return;
            }

            var createdBy = Guid.NewGuid();

            _ = await _developerProjectRepository.InsertAsync(new()
            {
                DeveloperId = developers[0].Id,
                ProjectId = projects[0].Id,
                CreatedBy = createdBy,
                CreatedAt = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            }, true);
        }
        catch (DbUpdateException) { }
    }
}
