using Shouldly;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Xunit;
using YANLib.Dtos;
using YANLib.Entities;
using YANLib.Repositories;

namespace YANLib.EntityFrameworkCore.Repositories;

public class ProjectRepositoryTests : YANLibEntityFrameworkCoreTestBase
{
    private readonly IProjectRepository _repository;

    public ProjectRepositoryTests() => _repository = GetRequiredService<IProjectRepository>();

    [Fact]
    public async Task Should_Insert_Project()
    {
        // Arrange
        var entity = new Project
        {
            Name = "Test Project",
            Description = "Test Project Description",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow
        };

        // Act
        var result = await _repository.InsertAsync(entity, true);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldNotBeNullOrWhiteSpace();
        result.Name.ShouldBe(entity.Name);
        result.Description.ShouldBe(entity.Description);
    }

    [Fact]
    public async Task Should_Find_Project_By_Id()
    {
        // Arrange
        var entity = new Project
        {
            Name = "Test Project",
            Description = "Test Project Description",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow
        };

        var created = await _repository.InsertAsync(entity, true);

        // Act
        var result = await _repository.FindAsync(created.Id);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldBe(created.Id);
        result.Name.ShouldBe(created.Name);
        result.Description.ShouldBe(created.Description);
    }

    [Fact]
    public async Task Should_Update_Project()
    {
        // Arrange
        var entity = new Project
        {
            Name = "Test Project",
            Description = "Test Project Description",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow
        };

        var created = await _repository.InsertAsync(entity, true);

        created.Name = "Updated Test Project";
        created.Description = "Updated Test Project Description";
        created.UpdatedBy = Guid.NewGuid();
        created.UpdatedAt = DateTime.UtcNow;

        // Act
        var updated = await _repository.UpdateAsync(created, true);
        var result = await _repository.GetAsync(created.Id);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldBe(created.Id);
        result.Name.ShouldBe(updated.Name);
        result.Description.ShouldBe(updated.Description);
    }

    [Fact]
    public async Task Should_Delete_Project()
    {
        // Arrange
        var entity = new Project
        {
            Name = "Test Project",
            Description = "Test Project Description",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
        };

        var created = await _repository.InsertAsync(entity, true);

        // Act
        await _repository.DeleteAsync(created.Id);

        // Assert
        var result = await _repository.FindAsync(created.Id);

        result.ShouldBeNull();
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
}
