using Shouldly;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Xunit;
using YANLib.Dtos;
using YANLib.Repositories;

namespace YANLib.EntityFrameworkCore.Repositories;

[Collection(YANLibTestConsts.CollectionDefinitionName)]
public class DeveloperTypeRepositoryTests : YANLibEntityFrameworkCoreTestBase
{
    private readonly IDeveloperTypeRepository _repository;

    public DeveloperTypeRepositoryTests() => _repository = GetRequiredService<IDeveloperTypeRepository>();

    [Fact]
    public async Task Should_Get_All_DeveloperTypes()
    {
        // Arrange
        await AddTestDeveloperTypes();

        // Act
        var developerTypes = await _repository.GetListAsync();

        // Assert
        _ = developerTypes.ShouldNotBeNull();
        developerTypes.Count.ShouldBeGreaterThan(0);
    }

    [Fact]
    public async Task Should_Get_DeveloperType_By_Id()
    {
        // Arrange
        var developerType = await AddTestDeveloperType("Test Get Developer Type");

        // Act
        var result = await _repository.GetAsync(developerType.Id);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldBe(developerType.Id);
        result.Name.ShouldBe(developerType.Name);
    }

    [Fact]
    public async Task Should_Insert_DeveloperType()
    {
        // Arrange
        var name = "Test Insert Developer Type";
        var createdBy = Guid.NewGuid();

        // Act
        var result = await _repository.InsertAsync(new Entities.DeveloperType
        {
            Name = name,
            CreatedBy = createdBy,
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        });

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldNotBe(0);
        result.Name.ShouldBe(name);
        result.CreatedBy.ShouldBe(createdBy);

        var inserted = await _repository.GetAsync(result.Id);
        _ = inserted.ShouldNotBeNull();
        inserted.Name.ShouldBe(name);
    }

    [Fact]
    public async Task Should_Update_DeveloperType()
    {
        // Arrange
        var developerType = await AddTestDeveloperType("Test Update Developer Type");
        var updatedName = "Updated Developer Type";

        developerType.Name = updatedName;
        developerType.UpdatedBy = Guid.NewGuid();
        developerType.UpdatedAt = DateTime.UtcNow;

        // Act
        _ = await _repository.UpdateAsync(developerType);

        // Assert
        var updated = await _repository.GetAsync(developerType.Id);

        _ = updated.ShouldNotBeNull();
        updated.Id.ShouldBe(developerType.Id);
        updated.Name.ShouldBe(updatedName);
        updated.UpdatedBy.ShouldBe(developerType.UpdatedBy);
    }

    [Fact]
    public async Task Should_Delete_DeveloperType()
    {
        // Arrange
        var developerType = await AddTestDeveloperType("Test Delete Developer Type");

        // Act
        await _repository.DeleteAsync(developerType.Id);

        // Assert
        _ = await Assert.ThrowsAsync<EntityNotFoundException>(async () => await _repository.GetAsync(developerType.Id));
    }

    [Fact]
    public async Task Should_Modify_DeveloperType_Using_ModifyAsync()
    {
        // Arrange
        var developerType = await AddTestDeveloperType("Test ModifyAsync Developer Type");
        var updatedName = "Modified Developer Type";
        var updatedBy = Guid.NewGuid();

        var dto = new DeveloperTypeDto
        {
            Id = developerType.Id,
            Name = updatedName,
            UpdatedBy = updatedBy,
            IsActive = true
        };

        // Act
        var result = await _repository.ModifyAsync(dto);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldBe(developerType.Id);
        result.Name.ShouldBe(updatedName);
        result.UpdatedBy.ShouldBe(updatedBy);

        var modified = await _repository.GetAsync(developerType.Id);
        _ = modified.ShouldNotBeNull();
        modified.Name.ShouldBe(updatedName);
    }

    [Fact]
    public async Task Should_Filter_DeveloperTypes_By_IsDeleted()
    {
        // Arrange
        _ = await AddTestDeveloperType("Active Type", isDeleted: false);
        _ = await AddTestDeveloperType("Deleted Type", isDeleted: true);

        // Act
        var activeTypes = await _repository.GetListAsync(x => !x.IsDeleted);
        var deletedTypes = await _repository.GetListAsync(x => x.IsDeleted);

        // Assert
        activeTypes.ShouldContain(x => x.Name == "Active Type");
        activeTypes.ShouldNotContain(x => x.Name == "Deleted Type");
        deletedTypes.ShouldContain(x => x.Name == "Deleted Type");
        deletedTypes.ShouldNotContain(x => x.Name == "Active Type");
    }

    [Fact]
    public async Task Should_Filter_DeveloperTypes_By_IsActive()
    {
        // Arrange
        _ = await AddTestDeveloperType("Active Type", isActive: true);
        _ = await AddTestDeveloperType("Inactive Type", isActive: false);

        // Act
        var activeTypes = await _repository.GetListAsync(x => x.IsActive);
        var inactiveTypes = await _repository.GetListAsync(x => !x.IsActive);

        // Assert
        activeTypes.ShouldContain(x => x.Name == "Active Type");
        activeTypes.ShouldNotContain(x => x.Name == "Inactive Type");
        inactiveTypes.ShouldContain(x => x.Name == "Inactive Type");
        inactiveTypes.ShouldNotContain(x => x.Name == "Active Type");
    }

    private async Task<Entities.DeveloperType> AddTestDeveloperType(string name, bool isActive = true, bool isDeleted = false) => await _repository.InsertAsync(new Entities.DeveloperType
    {
        Name = name,
        CreatedBy = Guid.NewGuid(),
        CreatedAt = DateTime.UtcNow,
        IsActive = isActive,
        IsDeleted = isDeleted
    });

    private async Task AddTestDeveloperTypes()
    {
        _ = await AddTestDeveloperType("Frontend Developer");
        _ = await AddTestDeveloperType("Backend Developer");
        _ = await AddTestDeveloperType("Full Stack Developer");
    }
}
