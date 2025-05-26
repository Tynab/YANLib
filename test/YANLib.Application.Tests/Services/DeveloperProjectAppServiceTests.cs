using Shouldly;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;
using YANLib.Entities;
using YANLib.Requests.v1.Create;
using YANLib.Requests.v1.Update;
using YANLib.Services.v1;

namespace YANLib.Services;

public abstract class DeveloperProjectAppServiceTests<TStartupModule> : YANLibApplicationTestBase<TStartupModule> where TStartupModule : IAbpModule
{
    private readonly IDeveloperProjectService _service;
    private readonly IRepository<DeveloperType, long> _developerTypeRepository;
    private readonly IRepository<Developer, Guid> _developerRepository;
    private readonly IRepository<Project, string> _projectRepository;

    protected DeveloperProjectAppServiceTests()
    {
        _service = GetRequiredService<IDeveloperProjectService>();
        _developerTypeRepository = GetRequiredService<IRepository<DeveloperType, long>>();
        _developerRepository = GetRequiredService<IRepository<Developer, Guid>>();
        _projectRepository = GetRequiredService<IRepository<Project, string>>();
    }

    [Fact]
    public async Task Should_Create_DeveloperProject()
    {
        // Arrange
        var developer = await CreateTestDeveloper();
        var project = await CreateTestProject();

        var request = new DeveloperProjectCreateRequest
        {
            DeveloperId = developer.Id,
            ProjectId = project.Id,
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        // Act
        var result = await _service.CreateAsync(request);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldNotBe(Guid.Empty);
        result.DeveloperId.ShouldBe(request.DeveloperId);
        result.ProjectId.ShouldBe(request.ProjectId);
    }

    [Fact]
    public async Task Should_Get_All_DeveloperProjects()
    {
        // Arrange
        var developer = await CreateTestDeveloper();
        var project = await CreateTestProject();

        var request = new DeveloperProjectCreateRequest
        {
            DeveloperId = developer.Id,
            ProjectId = project.Id,
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        _ = await _service.CreateAsync(request);

        // Act
        var result = await _service.GetListAsync(new());

        // Assert
        _ = result.ShouldNotBeNull();
        result.TotalCount.ShouldBeGreaterThan(0);
        result.Items.ShouldNotBeEmpty();
    }

    [Fact]
    public async Task Should_Get_DeveloperProject_By_Id()
    {
        // Arrange
        var developer = await CreateTestDeveloper();
        var project = await CreateTestProject();

        var request = new DeveloperProjectCreateRequest
        {
            DeveloperId = developer.Id,
            ProjectId = project.Id,
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        var created = await _service.CreateAsync(request);

        // Act
        var result = await _service.GetAsync(created.Id);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldBe(created.Id);
        result.DeveloperId.ShouldBe(request.DeveloperId);
        result.ProjectId.ShouldBe(request.ProjectId);
    }

    [Fact]
    public async Task Should_Update_DeveloperProject()
    {
        // Arrange
        var developer = await CreateTestDeveloper();
        var project = await CreateTestProject();

        var createRequest = new DeveloperProjectCreateRequest
        {
            DeveloperId = developer.Id,
            ProjectId = project.Id,
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        var created = await _service.CreateAsync(createRequest);

        var updateRequest = new DeveloperProjectUpdateRequest
        {
            DeveloperId = developer.Id,
            ProjectId = project.Id,
            CreatedBy = createRequest.CreatedBy,
            CreatedAt = createRequest.CreatedAt,
            UpdatedBy = Guid.NewGuid(),
            UpdatedAt = DateTime.UtcNow,
            IsActive = false,
            IsDeleted = false
        };

        // Act
        var result = await _service.UpdateAsync(created.Id, updateRequest);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldBe(created.Id);
        result.IsActive.ShouldBe(updateRequest.IsActive);
    }

    [Fact]
    public async Task Should_Delete_DeveloperProject()
    {
        // Arrange
        var developer = await CreateTestDeveloper();
        var project = await CreateTestProject();

        var request = new DeveloperProjectCreateRequest
        {
            DeveloperId = developer.Id,
            ProjectId = project.Id,
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        var created = await _service.CreateAsync(request);

        // Act
        await _service.DeleteAsync(created.Id);

        // Assert
        _ = await Assert.ThrowsAsync<EntityNotFoundException>(async () => await _service.GetAsync(created.Id));
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
