using Nest;
using Shouldly;
using System;
using System.Threading.Tasks;
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
    private readonly IDeveloperProjectService _developerProjectService;
    private readonly IRepository<DeveloperType, long> _developerTypeRepository;
    private readonly IRepository<Developer, Guid> _developerRepository;
    private readonly IRepository<Project, string> _projectRepository;

    protected DeveloperProjectAppServiceTests()
    {
        _developerProjectService = GetRequiredService<IDeveloperProjectService>();
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
        var result = await _developerProjectService.CreateAsync(request);

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

        _ = await _developerProjectService.CreateAsync(request);

        // Act
        var result = await _developerProjectService.GetListAsync(new());

        // Assert
        _ = result.ShouldNotBeNull();
        result.Items.ShouldNotBeEmpty();
        result.Items.ShouldContain(x => x.DeveloperId == developer.Id && x.ProjectId == project.Id);
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

        var created = await _developerProjectService.CreateAsync(request);

        // Act
        var result = await _developerProjectService.GetAsync(created.Id);

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

        var created = await _developerProjectService.CreateAsync(createRequest);

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
        var result = await _developerProjectService.UpdateAsync(created.Id, updateRequest);

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

        var created = await _developerProjectService.CreateAsync(request);

        // Act
        await _developerProjectService.DeleteAsync(created.Id);

        // Assert
        var exception = await Should.ThrowAsync<Volo.Abp.Domain.Entities.EntityNotFoundException>(async () => await _developerProjectService.GetAsync(created.Id));
        _ = exception.ShouldNotBeNull();
    }

    private async Task<Developer> CreateTestDeveloper() => await _developerRepository.InsertAsync(new Developer
    {
        DeveloperTypeCode = (await CreateTestDeveloperType()).Id
    }, true);

    private async Task<Project> CreateTestProject() => await _projectRepository.InsertAsync(new Project(), true);

    private async Task<DeveloperType> CreateTestDeveloperType() => await _developerTypeRepository.InsertAsync(new DeveloperType(), true);
}
