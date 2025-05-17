using Shouldly;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Modularity;
using Xunit;
using YANLib.Domains;
using YANLib.Entities;

namespace YANLib.Domain;

public abstract class DeveloperTypeDomainTests<TStartupModule> : YANLibDomainTestBase<TStartupModule> where TStartupModule : IAbpModule
{
    private readonly IDeveloperTypeRepository _repository;

    protected DeveloperTypeDomainTests() => _repository = GetRequiredService<IDeveloperTypeRepository>();

    [Fact]
    public async Task Should_Create_DeveloperType()
    {
        // Arrange
        var developerType = new DeveloperType
        {
            Name = "Domain Test Developer Type",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        // Act
        var result = await _repository.InsertAsync(developerType, true);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldNotBe(0);
        result.Name.ShouldBe(developerType.Name);
    }

    [Fact]
    public async Task Should_Get_All_DeveloperTypes()
    {
        // Arrange
        var developerType = new DeveloperType
        {
            Name = "Domain Test Developer Type for GetList",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        _ = await _repository.InsertAsync(developerType, true);

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
        var developerType = new DeveloperType
        {
            Name = "Domain Test Get Developer Type",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        var created = await _repository.InsertAsync(developerType, true);

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
        var developerType = new DeveloperType
        {
            Name = "Domain Test Update Developer Type",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        var created = await _repository.InsertAsync(developerType, true);

        created.Name = "Updated Domain Test Developer Type";
        created.UpdatedBy = Guid.NewGuid();
        created.UpdatedAt = DateTime.UtcNow;

        // Act
        _ = await _repository.UpdateAsync(created, true);

        var updated = await _repository.GetAsync(created.Id);

        // Assert
        _ = updated.ShouldNotBeNull();
        updated.Id.ShouldBe(created.Id);
        updated.Name.ShouldBe("Updated Domain Test Developer Type");
        updated.UpdatedBy.ShouldBe(created.UpdatedBy);
    }

    [Fact]
    public async Task Should_Delete_DeveloperType()
    {
        // Arrange
        var developerType = new DeveloperType
        {
            Name = "Domain Test Delete Developer Type",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        var created = await _repository.InsertAsync(developerType, true);

        // Act
        await _repository.DeleteAsync(created.Id);

        // Assert
        _ = await Assert.ThrowsAsync<EntityNotFoundException>(async () => await _repository.GetAsync(created.Id));
    }
}
