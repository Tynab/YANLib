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
        var name = "Test Insert Developer Type";
        var createdBy = Guid.NewGuid();

        // Act
        var result = await _repository.InsertAsync(new DeveloperType
        {
            Name = name,
            CreatedBy = createdBy,
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        }, true);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldNotBe(0);
        result.Name.ShouldBe(name);
        result.CreatedBy.ShouldBe(createdBy);

        var inserted = await _repository.GetAsync(result.Id);
        _ = inserted.ShouldNotBeNull();
        inserted.Name.ShouldBe(name);
        inserted.CreatedBy.ShouldBe(createdBy);
    }

    [Fact]
    public async Task Should_Get_All_DeveloperTypes()
    {
        // Arrange
        await AddTestDeveloperTypes();

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
        var request = await AddTestDeveloperType("Test Get Developer Type");

        // Act
        var result = await _repository.GetAsync(request.Id);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldBe(request.Id);
        result.Name.ShouldBe(request.Name);
    }

    [Fact]
    public async Task Should_Update_DeveloperType()
    {
        // Arrange
        var request = await AddTestDeveloperType("Test Update Developer Type");
        var updatedName = "Updated Developer Type";

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
        updated.UpdatedBy.ShouldBe(request.UpdatedBy);
    }

    [Fact]
    public async Task Should_Delete_DeveloperType()
    {
        // Arrange
        var request = await AddTestDeveloperType("Test Delete Developer Type");

        // Act
        await _repository.DeleteAsync(request.Id);

        // Assert
        _ = await Assert.ThrowsAsync<EntityNotFoundException>(async () => await _repository.GetAsync(request.Id));
    }

    [Fact]
    public async Task Should_Modify_DeveloperType_Using_ModifyAsync()
    {
        // Arrange
        var request = await AddTestDeveloperType("Test ModifyAsync Developer Type");
        var updatedName = "Modified Developer Type";
        var updatedBy = Guid.NewGuid();

        var dto = new DeveloperTypeDto
        {
            Id = request.Id,
            Name = updatedName,
            UpdatedBy = updatedBy,
            IsActive = true
        };

        // Act
        var result = await _repository.ModifyAsync(dto);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldBe(request.Id);
        result.Name.ShouldBe(updatedName);
        result.UpdatedBy.ShouldBe(updatedBy);

        var modified = await _repository.GetAsync(request.Id);
        _ = modified.ShouldNotBeNull();
        modified.Name.ShouldBe(updatedName);
        modified.UpdatedBy.ShouldBe(updatedBy);
    }

    [Fact]
    public async Task Should_Filter_DeveloperTypes_By_IsDeleted()
    {
        // Arrange
        _ = await AddTestDeveloperType("Active Type", isDeleted: false);
        _ = await AddTestDeveloperType("Deleted Type", isDeleted: true);

        // Act
        var active = await _repository.GetListAsync(x => !x.IsDeleted);
        var deleted = await _repository.GetListAsync(x => x.IsDeleted);

        // Assert
        active.ShouldContain(x => x.Name == "Active Type");
        active.ShouldNotContain(x => x.Name == "Deleted Type");
        deleted.ShouldContain(x => x.Name == "Deleted Type");
        deleted.ShouldNotContain(x => x.Name == "Active Type");
    }

    [Fact]
    public async Task Should_Filter_DeveloperTypes_By_IsActive()
    {
        // Arrange
        _ = await AddTestDeveloperType("Active Type", isActive: true);
        _ = await AddTestDeveloperType("Inactive Type", isActive: false);

        // Act
        var active = await _repository.GetListAsync(x => x.IsActive);
        var inactive = await _repository.GetListAsync(x => !x.IsActive);

        // Assert
        active.ShouldContain(x => x.Name == "Active Type");
        active.ShouldNotContain(x => x.Name == "Inactive Type");
        inactive.ShouldContain(x => x.Name == "Inactive Type");
        inactive.ShouldNotContain(x => x.Name == "Active Type");
    }

    private async Task<DeveloperType> AddTestDeveloperType(string name, bool isActive = true, bool isDeleted = false) => await _repository.InsertAsync(new DeveloperType
    {
        Name = name,
        CreatedBy = Guid.NewGuid(),
        CreatedAt = DateTime.UtcNow,
        IsActive = isActive,
        IsDeleted = isDeleted
    }, true);

    private async Task AddTestDeveloperTypes()
    {
        _ = await AddTestDeveloperType("Frontend Developer");
        _ = await AddTestDeveloperType("Backend Developer");
        _ = await AddTestDeveloperType("Full Stack Developer");
    }
}
