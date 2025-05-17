using Shouldly;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Xunit;
using YANLib.Domains;
using YANLib.Dtos;
using YANLib.Entities;

namespace YANLib.EntityFrameworkCore.Repositories;

public class ProjectRepositoryTests : YANLibEntityFrameworkCoreTestBase
{
    private readonly IProjectRepository _repository;

    public ProjectRepositoryTests() => _repository = GetRequiredService<IProjectRepository>();

    [Fact]
    public async Task Should_Insert_Project()
    {
        // Arrange
        var name = "Test Insert Project";
        var description = "Test Insert Project Description";
        var createdBy = Guid.NewGuid();

        // Act
        var result = await _repository.InsertAsync(new Project
        {
            Name = name,
            Description = description,
            CreatedBy = createdBy,
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        }, true);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldNotBeNullOrEmpty();
        result.Name.ShouldBe(name);
        result.Description.ShouldBe(description);
        result.CreatedBy.ShouldBe(createdBy);

        var inserted = await _repository.GetAsync(result.Id);
        _ = inserted.ShouldNotBeNull();
        inserted.Name.ShouldBe(name);
        inserted.Description.ShouldBe(description);
        inserted.CreatedBy.ShouldBe(createdBy);
    }

    [Fact]
    public async Task Should_Get_All_Projects()
    {
        // Arrange
        await AddTestProjects();

        // Act
        var result = await _repository.GetListAsync();

        // Assert
        _ = result.ShouldNotBeNull();
        result.Count.ShouldBeGreaterThan(0);
    }

    [Fact]
    public async Task Should_Get_Project_By_Id()
    {
        // Arrange
        var request = await AddTestProjects("Test Project", "Test Project Description");

        // Act
        var result = await _repository.GetAsync(request.Id);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldBe(request.Id);
        result.Name.ShouldBe(request.Name);
        result.Description.ShouldBe(request.Description);
    }

    [Fact]
    public async Task Should_Update_Project()
    {
        // Arrange
        var request = await AddTestProjects("Test Update Project", "Test Update Project Description");
        var updatedName = "Updated Project Name";

        request.Name = updatedName;
        request.UpdatedBy = Guid.NewGuid();
        request.UpdatedAt = DateTime.UtcNow;

        // Act
        _ = await _repository.UpdateAsync(request, true);

        // Assert
        var updated = await _repository.GetAsync(request.Id);

        _ = updated.ShouldNotBeNull();
        updated.Id.ShouldBe(request.Id);
        updated.Name.ShouldBe(updatedName);
        updated.Description.ShouldBe(request.Description);
        updated.UpdatedBy.ShouldBe(request.UpdatedBy);
    }

    [Fact]
    public async Task Should_Delete_Project()
    {
        // Arrange
        var request = await AddTestProjects("Test Delete Project", "Test Delete Project Description");

        // Act
        await _repository.DeleteAsync(request.Id);

        // Assert
        _ = await Assert.ThrowsAsync<EntityNotFoundException>(async () => await _repository.GetAsync(request.Id));
    }

    [Fact]
    public async Task Should_Modify_Project_Using_ModifyAsync()
    {
        // Arrange
        var request = await AddTestProjects("Test Modify Project", "Test Modify Project Description");
        var updatedName = "Modified Project Name";
        var updatedDescription = "Modified Project Description";
        var updatedBy = Guid.NewGuid();

        var dto = new ProjectDto
        {
            Id = request.Id,
            Name = updatedName,
            Description = updatedDescription,
            UpdatedBy = updatedBy,
            IsActive = true
        };

        // Act
        var result = await _repository.ModifyAsync(dto);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldBe(request.Id);
        result.Name.ShouldBe(updatedName);
        result.Description.ShouldBe(updatedDescription);
        result.UpdatedBy.ShouldBe(updatedBy);

        var modified = await _repository.GetAsync(request.Id);
        _ = modified.ShouldNotBeNull();
        modified.Name.ShouldBe(updatedName);
        modified.Description.ShouldBe(updatedDescription);
        modified.UpdatedBy.ShouldBe(updatedBy);
    }

    [Fact]
    public async Task Should_Filter_Projects_By_IsDeleted()
    {
        // Arrange
        _ = await AddTestProjects("Active Project", "Test Active Project Description", isDeleted: false);
        _ = await AddTestProjects("Deleted Project", "Test Deleted Project Description", isDeleted: true);

        // Act
        var active = await _repository.GetListAsync(x => !x.IsDeleted);
        var deleted = await _repository.GetListAsync(x => x.IsDeleted);

        // Assert
        active.ShouldContain(x => x.Name == "Active Project");
        active.ShouldNotContain(x => x.Name == "Deleted Project");
        deleted.ShouldContain(x => x.Name == "Deleted Project");
        deleted.ShouldNotContain(x => x.Name == "Active Project");
    }

    [Fact]
    public async Task Should_Filter_Projects_By_IsActive()
    {
        // Arrange
        _ = await AddTestProjects("Active Project", "Test Active Project Description", isActive: true);
        _ = await AddTestProjects("Inactive Project", "Test Inactive Project Description", isActive: false);

        // Act
        var active = await _repository.GetListAsync(x => x.IsActive);
        var inactive = await _repository.GetListAsync(x => !x.IsActive);

        // Assert
        active.ShouldContain(x => x.Name == "Active Project");
        active.ShouldNotContain(x => x.Name == "Inactive Project");
        inactive.ShouldContain(x => x.Name == "Inactive Project");
        inactive.ShouldNotContain(x => x.Name == "Active Project");
    }

    private async Task<Project> AddTestProjects(string name, string description, bool isActive = true, bool isDeleted = false) => await _repository.InsertAsync(new Project
    {
        Name = name,
        Description = description,
        CreatedBy = Guid.NewGuid(),
        CreatedAt = DateTime.UtcNow,
        IsActive = isActive,
        IsDeleted = isDeleted
    }, true);

    private async Task AddTestProjects()
    {
        _ = await AddTestProjects("Repository Test Project 1", "Repository Test Project 1 Description");
        _ = await AddTestProjects("Repository Test Project 2", "Repository Test Project 2 Description");
        _ = await AddTestProjects("Repository Test Project 3", "Repository Test Project 3 Description");
    }
}
