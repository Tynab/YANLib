using Shouldly;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;
using YANLib.Entities;

namespace YANLib.Domain;

public abstract class DeveloperDomainTests<TStartupModule> : YANLibDomainTestBase<TStartupModule> where TStartupModule : IAbpModule
{
    private readonly IRepository<Developer, Guid> _repository;
    private readonly IRepository<DeveloperType, long> _developerTypeRepository;

    protected DeveloperDomainTests()
    {
        _repository = GetRequiredService<IRepository<Developer, Guid>>();
        _developerTypeRepository = GetRequiredService<IRepository<DeveloperType, long>>();
    }

    [Fact]
    public async Task Should_Insert_Developer()
    {
        var developerType = await CreateTestDeveloperType();

        // Arrange
        var entity = new Developer
        {
            Name = "Test Developer",
            Phone = "1234567890",
            IdCard = "ID123456789",
            DeveloperTypeCode = developerType.Id,
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow
        };

        // Act
        var result = await _repository.InsertAsync(entity, true);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldNotBe(Guid.Empty);
        result.Name.ShouldBe(entity.Name);
        result.Phone.ShouldBe(entity.Phone);
        result.IdCard.ShouldBe(entity.IdCard);
        result.DeveloperTypeCode.ShouldBe(entity.DeveloperTypeCode);
    }

    [Fact]
    public async Task Should_Get_All_Developers()
    {
        var developerType = await CreateTestDeveloperType();

        // Arrange
        var entity = new Developer
        {
            Name = "Test Developer",
            Phone = "1234567890",
            IdCard = "ID123456789",
            DeveloperTypeCode = developerType.Id,
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
    public async Task Should_Get_Developer_By_Id()
    {
        var developerType = await CreateTestDeveloperType();

        // Arrange
        var entity = new Developer
        {
            Name = "Test Developer",
            Phone = "1234567890",
            IdCard = "ID123456789",
            DeveloperTypeCode = developerType.Id,
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
        result.Phone.ShouldBe(inserted.Phone);
        result.IdCard.ShouldBe(inserted.IdCard);
        result.DeveloperTypeCode.ShouldBe(inserted.DeveloperTypeCode);
    }

    [Fact]
    public async Task Should_Update_Developer()
    {
        var developerType = await CreateTestDeveloperType();

        // Arrange
        var entity = new Developer
        {
            Name = "Test Developer",
            Phone = "1234567890",
            IdCard = "ID123456789",
            DeveloperTypeCode = developerType.Id,
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow
        };

        var inserted = await _repository.InsertAsync(entity, true);

        inserted.Name = "Updated Test Developer";
        inserted.Phone = "0987654321";
        inserted.IdCard = "ID987654321";
        inserted.UpdatedBy = Guid.NewGuid();
        inserted.UpdatedAt = DateTime.UtcNow;

        // Act
        var updated = await _repository.UpdateAsync(inserted, true);
        var result = await _repository.GetAsync(inserted.Id);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldBe(inserted.Id);
        result.Name.ShouldBe(updated.Name);
        result.Phone.ShouldBe(updated.Phone);
        result.IdCard.ShouldBe(updated.IdCard);
        result.DeveloperTypeCode.ShouldBe(updated.DeveloperTypeCode);
    }

    [Fact]
    public async Task Should_Delete_Developer()
    {
        var developerType = await CreateTestDeveloperType();

        // Arrange
        var entity = new Developer
        {
            Name = "Test Developer",
            Phone = "1234567890",
            IdCard = "ID123456789",
            DeveloperTypeCode = developerType.Id,
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow
        };

        var inserted = await _repository.InsertAsync(entity, true);

        // Act
        await _repository.DeleteAsync(inserted.Id);

        // Assert
        _ = await Assert.ThrowsAsync<EntityNotFoundException>(async () => await _repository.GetAsync(inserted.Id));
    }

    private async Task<DeveloperType> CreateTestDeveloperType() => await _developerTypeRepository.InsertAsync(new DeveloperType
    {
        Name = "Test Developer Type",
        CreatedBy = Guid.NewGuid(),
        CreatedAt = DateTime.UtcNow,
        IsActive = true,
        IsDeleted = false
    }, true);
}
