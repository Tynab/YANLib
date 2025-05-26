using Shouldly;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;
using YANLib.Entities;
using YANLib.Repositories;

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
    public async Task Should_Create_Developer()
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

        var created = await _repository.InsertAsync(entity, true);

        // Act
        var result = await _repository.GetAsync(created.Id);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldBe(created.Id);
        result.Name.ShouldBe(created.Name);
        result.Phone.ShouldBe(created.Phone);
        result.IdCard.ShouldBe(created.IdCard);
        result.DeveloperTypeCode.ShouldBe(created.DeveloperTypeCode);
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

        var created = await _repository.InsertAsync(entity, true);

        created.Name = "Updated Test Developer";
        created.Phone = "0987654321";
        created.IdCard = "ID987654321";
        created.UpdatedBy = Guid.NewGuid();
        created.UpdatedAt = DateTime.UtcNow;

        // Act
        var updated = await _repository.UpdateAsync(created, true);
        var result = await _repository.GetAsync(created.Id);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldBe(created.Id);
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

        var created = await _repository.InsertAsync(entity, true);

        // Act
        await _repository.DeleteAsync(created.Id);

        // Assert
        _ = await Assert.ThrowsAsync<EntityNotFoundException>(async () => await _repository.GetAsync(created.Id));
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
