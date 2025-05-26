using Shouldly;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;
using YANLib.Entities;

namespace YANLib.Domain;

public abstract class DeveloperTypeDomainTests<TStartupModule> : YANLibDomainTestBase<TStartupModule> where TStartupModule : IAbpModule
{
    private readonly IRepository<DeveloperType, long> _repository;

    protected DeveloperTypeDomainTests() => _repository = GetRequiredService<IRepository<DeveloperType, long>>();

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

        var inserted = await _repository.InsertAsync(entity, true);

        // Act
        var result = await _repository.GetAsync(inserted.Id);

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
        var result = await _repository.GetAsync(inserted.Id);

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
        _ = await Assert.ThrowsAsync<EntityNotFoundException>(async () => await _repository.GetAsync(inserted.Id));
    }
}
