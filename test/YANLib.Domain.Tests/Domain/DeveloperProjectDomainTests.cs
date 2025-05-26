using Shouldly;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;
using YANLib.Entities;
using YANLib.Repositories;

namespace YANLib.Domain;

public abstract class DeveloperProjectDomainTests<TStartupModule> : YANLibDomainTestBase<TStartupModule> where TStartupModule : IAbpModule
{
    private readonly IDeveloperProjectRepository _developerProjectRepository;
    private readonly IRepository<DeveloperType, long> _developerTypeRepository;
    private readonly IRepository<Developer, Guid> _developerRepository;
    private readonly IRepository<Project, string> _projectRepository;

    protected DeveloperProjectDomainTests()
    {
        _developerProjectRepository = GetRequiredService<IDeveloperProjectRepository>();
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

        var developerProject = new DeveloperProject
        {
            DeveloperId = developer.Id,
            ProjectId = project.Id
        };

        // Act
        var result = await _developerProjectRepository.InsertAsync(developerProject, true);

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

        var developerProject1 = new DeveloperProject
        {
            DeveloperId = developer.Id,
            ProjectId = project1.Id
        };

        var developerProject2 = new DeveloperProject
        {
            DeveloperId = developer.Id,
            ProjectId = project2.Id
        };

        _ = await _developerProjectRepository.InsertAsync(developerProject1, true);
        _ = await _developerProjectRepository.InsertAsync(developerProject2, true);

        // Act
        var result = await _developerProjectRepository.GetListAsync(x => x.DeveloperId == developer.Id);

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

        var developerProject1 = new DeveloperProject
        {
            DeveloperId = developer1.Id,
            ProjectId = project.Id
        };

        var developerProject2 = new DeveloperProject
        {
            DeveloperId = developer2.Id,
            ProjectId = project.Id
        };

        _ = await _developerProjectRepository.InsertAsync(developerProject1, true);
        _ = await _developerProjectRepository.InsertAsync(developerProject2, true);

        // Act
        var result = await _developerProjectRepository.GetListAsync(x => x.ProjectId == project.Id);

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

        var developerProject = new DeveloperProject
        {
            DeveloperId = developer.Id,
            ProjectId = project.Id
        };

        var created = await _developerProjectRepository.InsertAsync(developerProject, true);

        // Act
        created.IsActive = false;

        var result = await _developerProjectRepository.UpdateAsync(created, true);

        // Assert
        _ = result.ShouldNotBeNull();
        result.IsActive.ShouldBe(false);
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

        var created = await _developerProjectRepository.InsertAsync(developerProject, true);

        // Act
        await _developerProjectRepository.DeleteAsync(created.Id, true);

        // Assert
        var result = await _developerProjectRepository.FindAsync(created.Id);

        result.ShouldBeNull();
    }

    private async Task<Developer> CreateTestDeveloper() => await _developerRepository.InsertAsync(new Developer
    {
        DeveloperTypeCode = (await CreateTestDeveloperType()).Id
    }, true);

    private async Task<Project> CreateTestProject() => await _projectRepository.InsertAsync(new Project(), true);

    private async Task<DeveloperType> CreateTestDeveloperType() => await _developerTypeRepository.InsertAsync(new DeveloperType(), true);
}
