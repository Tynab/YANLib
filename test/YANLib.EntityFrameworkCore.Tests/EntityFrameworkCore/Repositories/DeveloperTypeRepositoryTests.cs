using Shouldly;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
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
        var result = await _repository.InsertAsync(entity, true);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldNotBe(0);
        result.Name.ShouldBe(entity.Name);
    }

    [Fact]
    public async Task Should_Get_All_DeveloperTypes()
    {
        // Arrange
        var entity = new DeveloperType
        {
            Name = "Test Developer Type",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow
        };

        _ = await _repository.InsertAsync(entity, true);

        // Act
        var result = await _repository.GetListAsync();

        // Assert
        _ = result.ShouldNotBeNull();
        result.Count.ShouldBeGreaterThan(0);
    }

    [Fact]
    public async Task Should_Get_DeveloperType_By_Id()
    {
        // Arrange
        var entity = new DeveloperType
        {
            Name = "Test Developer Type",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow
        };

        var created = await _repository.InsertAsync(entity, true);

        // Act
        var result = await _repository.GetAsync(created.Id);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldBe(created.Id);
        result.Name.ShouldBe(created.Name);
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

        var created = await _repository.InsertAsync(entity, true);

        created.Name = "Updated Test Developer Type";
        created.UpdatedBy = Guid.NewGuid();
        created.UpdatedAt = DateTime.UtcNow;

        // Act
        var updated = await _repository.UpdateAsync(created, true);
        var result = await _repository.GetAsync(created.Id);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldBe(created.Id);
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

        var created = await _repository.InsertAsync(entity, true);

        // Act
        await _repository.DeleteAsync(created.Id);

        // Assert
        _ = await Assert.ThrowsAsync<EntityNotFoundException>(async () => await _repository.GetAsync(created.Id));
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

        var created = await _repository.InsertAsync(entity, true);

        var dto = new DeveloperTypeDto
        {
            Id = created.Id,
            Name = "Modified Developer Type",
            UpdatedBy = Guid.NewGuid()
        };

        // Act
        var modified = await _repository.ModifyAsync(dto);
        var result = await _repository.GetAsync(created.Id);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldBe(created.Id);
        result.Name.ShouldBe(modified!.Name);
    }
}
