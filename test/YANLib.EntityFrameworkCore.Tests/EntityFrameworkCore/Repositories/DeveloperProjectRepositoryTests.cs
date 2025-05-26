using System;
using System.Threading.Tasks;
using Shouldly;
using Volo.Abp.Domain.Repositories;
using Xunit;
using YANLib.Entities;
using YANLib.EntityFrameworkCore;
using YANLib.Repositories;

namespace YANLib.EntityFrameworkCore.Repositories;

[Collection(YANLibTestConsts.CollectionDefinitionName)]
public class DeveloperProjectRepositoryTests : YANLibEntityFrameworkCoreTestBase
{
    private readonly IDeveloperProjectRepository _repository;
    private readonly IRepository<DeveloperType, long> _developerTypeRepository;
    private readonly IRepository<Developer, Guid> _developerRepository;
    private readonly IRepository<Project, string> _projectRepository;

    public DeveloperProjectRepositoryTests()
    {
        _repository = GetRequiredService<IDeveloperProjectRepository>();
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

        var developerProject = new DeveloperProject
        {
            DeveloperId = developer.Id,
            ProjectId = project.Id
        };

        // Act
        var result = await _repository.InsertAsync(developerProject, true);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldNotBe(Guid.Empty);
        result.DeveloperId.ShouldBe(developer.Id);
        result.ProjectId.ShouldBe(project.Id);
    }

    [Fact]
    public async Task Should_Get_DeveloperProjects_By_Developer_Id()
    {
        // Arrange
        var developer = await CreateTestDeveloper();
        var project1 = await CreateTestProject();
        var project2 = await CreateTestProject();
        var developerProject1 = await CreateTestDeveloperProject(developer.Id, project1.Id);
        var developerProject2 = await CreateTestDeveloperProject(developer.Id, project2.Id);

        // Act
        var result = await _repository.GetListAsync(x => x.DeveloperId == developer.Id);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Count.ShouldBeGreaterThanOrEqualTo(2);
        result.ShouldContain(x => x.ProjectId == project1.Id);
        result.ShouldContain(x => x.ProjectId == project2.Id);
    }

    [Fact]
    public async Task Should_Get_DeveloperProjects_By_Project_Id()
    {
        // Arrange
        var developer1 = await CreateTestDeveloper();
        var developer2 = await CreateTestDeveloper();
        var project = await CreateTestProject();
        var developerProject1 = await CreateTestDeveloperProject(developer1.Id, project.Id);
        var developerProject2 = await CreateTestDeveloperProject(developer2.Id, project.Id);

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
        var request = await CreateTestDeveloperProject();

        // Act
        request.IsActive = false;

        _ = await _repository.UpdateAsync(request, true);

        // Assert
        var updated = await _repository.GetAsync(request.Id);

        _ = updated.ShouldNotBeNull();
        updated.IsActive.ShouldBe(false);
    }

    [Fact]
    public async Task Should_Delete_DeveloperProject()
    {
        // Arrange
        var developer = await CreateTestDeveloper();
        var project = await CreateTestProject();

        var developerProject = new DeveloperProject
        {
            DeveloperId = developer.Id,
            ProjectId = project.Id
        };

        var created = await _repository.InsertAsync(developerProject, true);

        // Act
        await _repository.DeleteAsync(created.Id, true);

        // Assert
        var result = await _repository.FindAsync(created.Id);
        result.ShouldBeNull();
    }

    [Fact]
    public async Task Should_Filter_DeveloperProject_By_IsDeleted()
    {
        // Arrange
        var developer = await CreateTestDeveloper();
        var project = await CreateTestProject();

        var active = new DeveloperProject
        {
            DeveloperId = developer.Id,
            ProjectId = project.Id,
            IsDeleted = false
        };

        var deleted = new DeveloperProject
        {
            DeveloperId = developer.Id,
            ProjectId = project.Id,
            IsDeleted = true
        };

        _ = await _repository.InsertAsync(active, true);
        _ = await _repository.InsertAsync(deleted, true);

        // Act
        var result = await _repository.GetListAsync(x => x.IsActive);

        // Assert
        _ = result.ShouldNotBeNull();
        result.ShouldContain(x => x.Id == active.Id);
        result.ShouldNotContain(x => x.Id == deleted.Id);
    }

    [Fact]
    public async Task Should_Filter_DeveloperProjects_By_IsActive()
    {
        // Arrange
        var developer = await CreateTestDeveloper();
        var project = await CreateTestProject();

        var active = new DeveloperProject
        {
            DeveloperId = developer.Id,
            ProjectId = project.Id,
            IsActive = true
        };

        var inactive = new DeveloperProject
        {
            DeveloperId = developer.Id,
            ProjectId = project.Id,
            IsActive = false
        };

        _ = await _repository.InsertAsync(active, true);
        _ = await _repository.InsertAsync(inactive, true);

        // Act
        var result = await _repository.GetListAsync(x => x.IsActive);

        // Assert
        _ = result.ShouldNotBeNull();
        result.ShouldContain(x => x.Id == active.Id);
        result.ShouldNotContain(x => x.Id == inactive.Id);
    }

    private async Task<DeveloperProject> CreateTestDeveloperProject() => await _repository.InsertAsync(new DeveloperProject
    {
        DeveloperId = (await CreateTestDeveloper()).Id,
        ProjectId = (await CreateTestProject()).Id
    }, true);

    private async Task<DeveloperProject> CreateTestDeveloperProject(Guid developerId, string projectId) => await _repository.InsertAsync(new DeveloperProject
    {
        DeveloperId = developerId,
        ProjectId = projectId
    }, true);

    private async Task<Developer> CreateTestDeveloper() => await _developerRepository.InsertAsync(new Developer
    {
        DeveloperTypeCode = (await CreateTestDeveloperType()).Id
    }, true);

    private async Task<Project> CreateTestProject() => await _projectRepository.InsertAsync(new Project(), true);

    private async Task<DeveloperType> CreateTestDeveloperType() => await _developerTypeRepository.InsertAsync(new DeveloperType(), true);
}
