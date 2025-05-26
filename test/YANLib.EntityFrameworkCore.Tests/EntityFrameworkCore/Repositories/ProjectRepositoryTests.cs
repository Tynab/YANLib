using Shouldly;
using System;
using System.Threading.Tasks;
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
        var inserted = await _repository.InsertAsync(entity, true);
        var result = await _repository.FindAsync(inserted.Id);

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

        var inserted = await _repository.InsertAsync(entity, true);

        // Act
        var result = await _repository.FindAsync(inserted.Id);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldBe(inserted.Id);
        result.Name.ShouldBe(inserted.Name);
        result.Description.ShouldBe(inserted.Description);
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

        var inserted = await _repository.InsertAsync(entity, true);

        inserted.Name = "Updated Test Project";
        inserted.Description = "Updated Test Project Description";
        inserted.UpdatedBy = Guid.NewGuid();
        inserted.UpdatedAt = DateTime.UtcNow;

        // Act
        var updated = await _repository.UpdateAsync(inserted, true);
        var result = await _repository.FindAsync(inserted.Id);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldBe(inserted.Id);
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

        var inserted = await _repository.InsertAsync(entity, true);

        // Act
        await _repository.DeleteAsync(inserted.Id);

        // Assert
        var result = await _repository.FindAsync(inserted.Id);

        result.ShouldBeNull();
    }

    [Fact]
    public async Task Should_Modify_Project_Using_ModifyAsync()
    {
        // Arrange
        var entity = new Project
        {
            Name = "Test Project",
            Description = "Test Project Description",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow
        };

        var inserted = await _repository.InsertAsync(entity, true);

        var dto = new ProjectDto
        {
            Id = inserted.Id,
            Name = "Modified Test Project Name",
            UpdatedBy = Guid.NewGuid()
        };

        // Act
        var modified = await _repository.ModifyAsync(dto);
        var result = await _repository.FindAsync(inserted.Id);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldBe(inserted.Id);
        result.Name.ShouldBe(modified!.Name);
        result.Description.ShouldBe(inserted.Description);
    }
}
