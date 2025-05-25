using Shouldly;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Modularity;
using Xunit;
using YANLib.Entities;
using YANLib.Repositories;

namespace YANLib.Domain;

public abstract class DeveloperDomainTests<TStartupModule> : YANLibDomainTestBase<TStartupModule> where TStartupModule : IAbpModule
{
    private readonly IDeveloperRepository _repository;

    protected DeveloperDomainTests() => _repository = GetRequiredService<IDeveloperRepository>();

    [Fact]
    public async Task Should_Create_Developer()
    {
        // Arrange
        var developer = new Developer
        {
            Name = "Domain Test Developer",
            Phone = "1234567890",
            IdCard = "ID123456789",
            DeveloperTypeCode = 1,
            RawVersion = 1,
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        // Act
        var result = await _repository.InsertAsync(developer, true);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldNotBe(Guid.Empty);
        result.Name.ShouldBe(developer.Name);
        result.Phone.ShouldBe(developer.Phone);
        result.IdCard.ShouldBe(developer.IdCard);
    }

    [Fact]
    public async Task Should_Get_All_Developers()
    {
        // Arrange
        var developer = new Developer
        {
            Name = "Domain Test Developer for GetList",
            Phone = "1234567890",
            IdCard = "ID123456789",
            DeveloperTypeCode = 1,
            RawVersion = 1,
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        _ = await _repository.InsertAsync(developer, true);

        // Act
        var result = await _repository.GetListAsync();

        // Assert
        _ = result.ShouldNotBeNull();
        result.Count.ShouldBeGreaterThan(0);
    }

    [Fact]
    public async Task Should_Get_Developer_By_Id()
    {
        // Arrange
        var developer = new Developer
        {
            Name = "Domain Test Get Developer",
            Phone = "1234567890",
            IdCard = "ID123456789",
            DeveloperTypeCode = 1,
            RawVersion = 1,
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        var created = await _repository.InsertAsync(developer, true);

        // Act
        var result = await _repository.GetAsync(created.Id);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldBe(created.Id);
        result.Name.ShouldBe(created.Name);
        result.Phone.ShouldBe(created.Phone);
        result.IdCard.ShouldBe(created.IdCard);
    }

    [Fact]
    public async Task Should_Update_Developer()
    {
        // Arrange
        var developer = new Developer
        {
            Name = "Domain Test Update Developer",
            Phone = "1234567890",
            IdCard = "ID123456789",
            DeveloperTypeCode = 1,
            RawVersion = 1,
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        var created = await _repository.InsertAsync(developer, true);

        created.Name = "Updated Domain Test Developer";
        created.Phone = "0987654321";
        created.UpdatedBy = Guid.NewGuid();
        created.UpdatedAt = DateTime.UtcNow;

        // Act
        _ = await _repository.UpdateAsync(created, true);

        var updated = await _repository.GetAsync(created.Id);

        // Assert
        _ = updated.ShouldNotBeNull();
        updated.Id.ShouldBe(created.Id);
        updated.Name.ShouldBe("Updated Domain Test Developer");
        updated.Phone.ShouldBe("0987654321");
        updated.UpdatedBy.ShouldBe(created.UpdatedBy);
    }

    [Fact]
    public async Task Should_Delete_Developer()
    {
        // Arrange
        var developer = new Developer
        {
            Name = "Domain Test Delete Developer",
            Phone = "1234567890",
            IdCard = "ID123456789",
            DeveloperTypeCode = 1,
            RawVersion = 1,
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        var created = await _repository.InsertAsync(developer, true);

        // Act
        await _repository.DeleteAsync(created.Id);

        // Assert
        _ = await Assert.ThrowsAsync<EntityNotFoundException>(async () => await _repository.GetAsync(created.Id));
    }
}
