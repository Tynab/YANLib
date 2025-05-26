using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;
using YANLib.Dtos;
using YANLib.Entities;
using YANLib.Repositories;

namespace YANLib.EntityFrameworkCore.Repositories;

[Collection(YANLibTestConsts.CollectionDefinitionName)]
public class DeveloperRepositoryTests : YANLibEntityFrameworkCoreTestBase
{
    private readonly IDeveloperRepository _repository;
    private readonly IDeveloperTypeRepository _developerTypeRepository;

    public DeveloperRepositoryTests()
    {
        _repository = GetRequiredService<IDeveloperRepository>();
        _developerTypeRepository = GetRequiredService<IDeveloperTypeRepository>();
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
        var inserted = await _repository.InsertAsync(entity, true);
        var result = await _repository.FindAsync(inserted.Id);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldNotBe(Guid.Empty);
        result.Name.ShouldBe(entity.Name);
        result.Phone.ShouldBe(entity.Phone);
        result.IdCard.ShouldBe(entity.IdCard);
        result.DeveloperTypeCode.ShouldBe(entity.DeveloperTypeCode);
    }

    [Fact]
    public async Task Should_Find_Developer_By_Id()
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
        var result = await _repository.FindAsync(inserted.Id);

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
        var result = await _repository.FindAsync(inserted.Id);

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
        var result = await _repository.FindAsync(inserted.Id);

        result.ShouldBeNull();
    }

    [Fact]
    public async Task Should_Modify_Developer_Using_ModifyAsync()
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

        var dto = new DeveloperDto
        {
            Id = inserted.Id,
            Name = "Modified Test Developer",
            UpdatedBy = Guid.NewGuid()
        };

        // Act
        var modified = await _repository.ModifyAsync(dto);
        var result = await _repository.FindAsync(inserted.Id);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldBe(inserted.Id);
        result.Name.ShouldBe(modified!.Name);
        result.Phone.ShouldBe(inserted.Phone);
        result.IdCard.ShouldBe(inserted.IdCard);
        result.DeveloperTypeCode.ShouldBe(inserted.DeveloperTypeCode);
    }

    [Fact]
    public async Task Should_Adjust_Developer_Using_AdjustAsync()
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

        var adjustedEntity = new Developer
        {
            Name = "Adjusted Test Developer",
            Phone = "1234567890",
            IdCard = "ID123456789",
            DeveloperTypeCode = developerType.Id,
            CreatedBy = entity.CreatedBy,
            CreatedAt = entity.CreatedAt,
            UpdatedBy = Guid.NewGuid(),
            UpdatedAt = DateTime.UtcNow
        };

        // Act
        var adjusted = await _repository.AdjustAsync(adjustedEntity);
        var result = await _repository.FindAsync(x => x.IdCard == inserted.IdCard && !x.IsDeleted);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldNotBe(Guid.Empty);
        result.Name.ShouldBe(adjusted!.Name);
        result.Phone.ShouldBe(inserted.Phone);
        result.DeveloperTypeCode.ShouldBe(inserted.DeveloperTypeCode);
        result.RawVersion.ShouldBe(2);
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
