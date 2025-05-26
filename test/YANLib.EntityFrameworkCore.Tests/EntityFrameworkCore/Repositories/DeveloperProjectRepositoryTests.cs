using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;
using YANLib.Dtos;
using YANLib.Entities;
using YANLib.Repositories;

namespace YANLib.EntityFrameworkCore.Repositories;

[Collection(YANLibTestConsts.CollectionDefinitionName)]
public class DeveloperProjectRepositoryTests : YANLibEntityFrameworkCoreTestBase
{
    private readonly IDeveloperProjectRepository _repository;
    private readonly IDeveloperTypeRepository _developerTypeRepository;
    private readonly IDeveloperRepository _developerRepository;
    private readonly IProjectRepository _projectRepository;

    public DeveloperProjectRepositoryTests()
    {
        _repository = GetRequiredService<IDeveloperProjectRepository>();
        _developerTypeRepository = GetRequiredService<IDeveloperTypeRepository>();
        _developerRepository = GetRequiredService<IDeveloperRepository>();
        _projectRepository = GetRequiredService<IProjectRepository>();
    }

    [Fact]
    public async Task Should_Insert_DeveloperProject()
    {
        // Arrange
        var developer = await CreateTestDeveloper();
        var project = await CreateTestProject();

        var entity = new DeveloperProject
        {
            DeveloperId = developer.Id,
            ProjectId = project.Id,
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow
        };

        // Act
        var inserted = await _repository.InsertAsync(entity, true);
        var result = await _repository.FindAsync(inserted.Id);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldNotBe(Guid.Empty);
        result.DeveloperId.ShouldBe(developer.Id);
        result.ProjectId.ShouldBe(project.Id);
    }

    [Fact]
    public async Task Should_Update_DeveloperProject()
    {
        // Arrange
        var developer = await CreateTestDeveloper();
        var project = await CreateTestProject();

        var entity = new DeveloperProject
        {
            DeveloperId = developer.Id,
            ProjectId = project.Id,
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow
        };

        var inserted = await _repository.InsertAsync(entity, true);

        inserted.IsActive = false;
        inserted.UpdatedBy = Guid.NewGuid();
        inserted.UpdatedAt = DateTime.UtcNow;

        // Act
        _ = await _repository.UpdateAsync(inserted, true);

        var result = await _repository.FindAsync(inserted.Id);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldBe(inserted.Id);
        result.IsActive.ShouldBeFalse();
    }

    [Fact]
    public async Task Should_Delete_DeveloperProject()
    {
        // Arrange
        var developer = await CreateTestDeveloper();
        var project = await CreateTestProject();

        var entity = new DeveloperProject
        {
            DeveloperId = developer.Id,
            ProjectId = project.Id,
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow
        };

        var inserted = await _repository.InsertAsync(entity, true);

        // Act
        await _repository.DeleteAsync(inserted.Id, true);

        // Assert
        var result = await _repository.FindAsync(inserted.Id);

        result.ShouldBeNull();
    }

    [Fact]
    public async Task Should_Modify_DeveloperProject()
    {
        // Arrange
        var developer = await CreateTestDeveloper();
        var project = await CreateTestProject();

        var entity = new DeveloperProject
        {
            DeveloperId = developer.Id,
            ProjectId = project.Id,
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow
        };

        var inserted = await _repository.InsertAsync(entity, true);

        var dto = new DeveloperProjectDto
        {
            Id = inserted.Id,
            IsActive = false,
            UpdatedBy = Guid.NewGuid()
        };

        // Act
        _ = await _repository.ModifyAsync(dto);

        var result = await _repository.FindAsync(inserted.Id);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldBe(inserted.Id);
        result.IsActive.ShouldBeFalse();
    }

    private async Task<Developer> CreateTestDeveloper() => await _developerRepository.InsertAsync(new Developer
    {
        Name = "Test Developer",
        Phone = "1234567890",
        IdCard = "ID123456789",
        DeveloperTypeCode = (await CreateTestDeveloperType()).Id,
        RawVersion = 1,
        CreatedBy = Guid.NewGuid(),
        CreatedAt = DateTime.UtcNow,
        IsActive = true,
        IsDeleted = false
    }, true);

    private async Task<Project> CreateTestProject() => await _projectRepository.InsertAsync(new Project
    {
        Name = "Test Project",
        Description = "Test Project Description",
        CreatedBy = Guid.NewGuid(),
        CreatedAt = DateTime.Now,
        IsActive = true,
        IsDeleted = false
    }, true);

    private async Task<DeveloperType> CreateTestDeveloperType() => await _developerTypeRepository.InsertAsync(new DeveloperType
    {
        Name = "Test Developer Type",
        CreatedBy = Guid.NewGuid(),
        CreatedAt = DateTime.UtcNow,
        IsActive = true,
        IsDeleted = false
    }, true);
}
