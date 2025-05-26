using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;
using YANLib.Dtos;
using YANLib.Entities;
using YANLib.Repositories;

namespace YANLib.EntityFrameworkCore.Repositories;

[Collection(YANLibTestConsts.CollectionDefinitionName)]
public class DeveloperTypeRepositoryTests : YANLibEntityFrameworkCoreTestBase
{
    private readonly IDeveloperTypeRepository _repository;

    public DeveloperTypeRepositoryTests() => _repository = GetRequiredService<IDeveloperTypeRepository>();

    [Fact]
    public async Task Should_Insert_DeveloperType()
    {
        // Arrange
        var entity = new DeveloperType
        {
            Name = "Test Developer Type",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow
        };

        // Act
        var inserted = await _repository.InsertAsync(entity, true);
        var result = await _repository.FindAsync(inserted.Id);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldNotBe(0);
        result.Name.ShouldBe(entity.Name);
    }

    [Fact]
    public async Task Should_Find_DeveloperType_By_Id()
    {
        // Arrange
        var entity = new DeveloperType
        {
            Name = "Test Developer Type",
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
    }

    [Fact]
    public async Task Should_Update_DeveloperType()
    {
        // Arrange
        var entity = new DeveloperType
        {
            Name = "Test Developer Type",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow
        };

        var inserted = await _repository.InsertAsync(entity, true);

        inserted.Name = "Updated Test Developer Type";
        inserted.UpdatedBy = Guid.NewGuid();
        inserted.UpdatedAt = DateTime.UtcNow;

        // Act
        var updated = await _repository.UpdateAsync(inserted, true);
        var result = await _repository.FindAsync(inserted.Id);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldBe(inserted.Id);
        result.Name.ShouldBe(updated.Name);
    }

    [Fact]
    public async Task Should_Delete_DeveloperType()
    {
        // Arrange
        var entity = new DeveloperType
        {
            Name = "Test Developer Type",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        var inserted = await _repository.InsertAsync(entity, true);

        // Act
        await _repository.DeleteAsync(inserted.Id);

        // Assert
        var result = await _repository.FindAsync(inserted.Id);

        result.ShouldBeNull();
    }

    [Fact]
    public async Task Should_Modify_DeveloperType_Using_ModifyAsync()
    {
        // Arrange
        var entity = new DeveloperType
        {
            Name = "Test Developer Type",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow
        };

        var inserted = await _repository.InsertAsync(entity, true);

        var dto = new DeveloperTypeDto
        {
            Id = inserted.Id,
            Name = "Modified Test Developer Type",
            UpdatedBy = Guid.NewGuid()
        };

        // Act
        var modified = await _repository.ModifyAsync(dto);
        var result = await _repository.FindAsync(inserted.Id);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldBe(inserted.Id);
        result.Name.ShouldBe(modified!.Name);
    }
}
