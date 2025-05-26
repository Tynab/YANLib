using Shouldly;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;
using YANLib.Entities;

namespace YANLib.Domain;

public abstract class DeveloperProjectDomainTests<TStartupModule> : YANLibDomainTestBase<TStartupModule> where TStartupModule : IAbpModule
{
    private readonly IRepository<DeveloperProject, Guid> _repository;
    private readonly IRepository<DeveloperType, long> _developerTypeRepository;
    private readonly IRepository<Developer, Guid> _developerRepository;
    private readonly IRepository<Project, string> _projectRepository;

    protected DeveloperProjectDomainTests()
    {
        _repository = GetRequiredService<IRepository<DeveloperProject, Guid>>();
        _developerTypeRepository = GetRequiredService<IRepository<DeveloperType, long>>();
        _developerRepository = GetRequiredService<IRepository<Developer, Guid>>();
        _projectRepository = GetRequiredService<IRepository<Project, string>>();
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
        var result = await _repository.InsertAsync(entity, true);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldNotBe(Guid.Empty);
        result.DeveloperId.ShouldBe(developer.Id);
        result.ProjectId.ShouldBe(project.Id);
    }

    [Fact]
    public async Task Should_Get_DeveloperProjects_By_Developer()
    {
        // Arrange
        var developer = await CreateTestDeveloper();
        var project1 = await CreateTestProject();
        var project2 = await CreateTestProject();

        var entity1 = new DeveloperProject
        {
            DeveloperId = developer.Id,
            ProjectId = project1.Id,
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow
        };

        var entity2 = new DeveloperProject
        {
            DeveloperId = developer.Id,
            ProjectId = project2.Id,
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow
        };

        _ = await _repository.InsertAsync(entity1, true);
        _ = await _repository.InsertAsync(entity2, true);

        // Act
        var result = await _repository.GetListAsync(x => x.DeveloperId == developer.Id);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Count.ShouldBeGreaterThanOrEqualTo(2);
        result.ShouldContain(x => x.ProjectId == project1.Id);
        result.ShouldContain(x => x.ProjectId == project2.Id);
    }

    [Fact]
    public async Task Should_Get_DeveloperProjects_By_Project()
    {
        // Arrange
        var developer1 = await CreateTestDeveloper();
        var developer2 = await CreateTestDeveloper();
        var project = await CreateTestProject();

        var entity1 = new DeveloperProject
        {
            DeveloperId = developer1.Id,
            ProjectId = project.Id,
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow
        };

        var entity2 = new DeveloperProject
        {
            DeveloperId = developer2.Id,
            ProjectId = project.Id,
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow
        };

        _ = await _repository.InsertAsync(entity1, true);
        _ = await _repository.InsertAsync(entity2, true);

        // Act
        var result = await _repository.GetListAsync(x => x.ProjectId == project.Id);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Count.ShouldBeGreaterThanOrEqualTo(2);
        result.ShouldContain(x => x.DeveloperId == developer1.Id);
        result.ShouldContain(x => x.DeveloperId == developer2.Id);
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
        var updated = await _repository.UpdateAsync(inserted, true);
        var result = await _repository.GetAsync(inserted.Id);

        // Assert
        _ = updated.ShouldNotBeNull();
        result.Id.ShouldBe(inserted.Id);
        updated.IsActive.ShouldBe(updated.IsActive);
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
        _ = await Assert.ThrowsAsync<EntityNotFoundException>(async () => await _repository.GetAsync(inserted.Id));
    }

    private async Task<Developer> CreateTestDeveloper() => await _developerRepository.InsertAsync(new Developer
    {
        Name = "Test Developer",
        Phone = "1234567890",
        IdCard = "ID123456789",
        DeveloperTypeCode = (await CreateTestDeveloperType()).Id,
        CreatedBy = Guid.NewGuid(),
        CreatedAt = DateTime.UtcNow
    }, true);

    private async Task<Project> CreateTestProject() => await _projectRepository.InsertAsync(new Project
    {
        Name = "Test Project",
        Description = "Test Project Description",
        CreatedBy = Guid.NewGuid(),
        CreatedAt = DateTime.UtcNow,
    }, true);

    private async Task<DeveloperType> CreateTestDeveloperType() => await _developerTypeRepository.InsertAsync(new DeveloperType
    {
        Name = "Test Developer Type",
        CreatedBy = Guid.NewGuid(),
        CreatedAt = DateTime.UtcNow
    }, true);
}
