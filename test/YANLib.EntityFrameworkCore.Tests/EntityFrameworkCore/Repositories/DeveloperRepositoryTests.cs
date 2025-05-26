using Shouldly;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Xunit;
using YANLib.Dtos;
using YANLib.Entities;
using YANLib.Repositories;

namespace YANLib.EntityFrameworkCore.Repositories;

[Collection(YANLibTestConsts.CollectionDefinitionName)]
public class DeveloperRepositoryTests : YANLibEntityFrameworkCoreTestBase
{
    private readonly IDeveloperRepository _repository;
    private readonly IRepository<DeveloperType, long> _developerTypeRepository;

    public DeveloperRepositoryTests()
    {
        _repository = GetRequiredService<IDeveloperRepository>();
        _developerTypeRepository = GetRequiredService<IRepository<DeveloperType, long>>();
    }

    [Fact]
    public async Task Should_Insert_Developer()
    {
        // Arrange
        var developerType = await CreateTestDeveloperType();

        var name = "Test Insert Developer";
        var phone = "1234567890";
        var idCard = "ID123456789";

        // Act
        var result = await _repository.InsertAsync(new Developer
        {
            Name = name,
            Phone = phone,
            IdCard = idCard,
            DeveloperTypeCode = developerType.Id
        }, true);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldNotBe(Guid.Empty);
        result.Name.ShouldBe(name);
        result.Phone.ShouldBe(phone);
        result.IdCard.ShouldBe(idCard);
        result.DeveloperTypeCode.ShouldBe(developerType.Id);

        var inserted = await _repository.GetAsync(result.Id);
        _ = inserted.ShouldNotBeNull();
        inserted.Name.ShouldBe(name);
        inserted.Phone.ShouldBe(phone);
        inserted.IdCard.ShouldBe(idCard);
    }

    [Fact]
    public async Task Should_Get_All_Developers()
    {
        // Arrange
        await AddTestDevelopers();

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
        var request = await AddTestDeveloper("Test Get Developer");

        // Act
        var result = await _repository.GetAsync(request.Id);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldBe(request.Id);
        result.Name.ShouldBe(request.Name);
        result.Phone.ShouldBe(request.Phone);
        result.IdCard.ShouldBe(request.IdCard);
    }

    [Fact]
    public async Task Should_Update_Developer()
    {
        // Arrange
        var request = await AddTestDeveloper("Test Update Developer");
        var updatedName = "Updated Developer";
        var updatedPhone = "0987654321";

        request.Name = updatedName;
        request.Phone = updatedPhone;

        // Act
        _ = await _repository.UpdateAsync(request, true);

        // Assert
        var updated = await _repository.GetAsync(request.Id);

        _ = updated.ShouldNotBeNull();
        updated.Id.ShouldBe(request.Id);
        updated.Name.ShouldBe(updatedName);
        updated.Phone.ShouldBe(updatedPhone);
    }

    [Fact]
    public async Task Should_Delete_Developer()
    {
        // Arrange
        var request = await AddTestDeveloper("Test Delete Developer");

        // Act
        await _repository.DeleteAsync(request.Id);

        // Assert
        _ = await Assert.ThrowsAsync<EntityNotFoundException>(async () => await _repository.GetAsync(request.Id));
    }

    [Fact]
    public async Task Should_Modify_Developer_Using_ModifyAsync()
    {
        // Arrange
        var request = await AddTestDeveloper("Test ModifyAsync Developer");
        var updatedName = "Modified Developer";
        var updatedPhone = "5555555555";
        var updatedBy = Guid.NewGuid();

        var dto = new DeveloperDto
        {
            Id = request.Id,
            Name = updatedName,
            Phone = updatedPhone,
            IdCard = request.IdCard,
            DeveloperTypeCode = request.DeveloperTypeCode,
            UpdatedBy = updatedBy,
            IsActive = true
        };

        // Act
        var result = await _repository.ModifyAsync(dto);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldBe(request.Id);
        result.Name.ShouldBe(updatedName);
        result.Phone.ShouldBe(updatedPhone);
        result.UpdatedBy.ShouldBe(updatedBy);

        var modified = await _repository.GetAsync(request.Id);
        _ = modified.ShouldNotBeNull();
        modified.Name.ShouldBe(updatedName);
        modified.Phone.ShouldBe(updatedPhone);
        modified.UpdatedBy.ShouldBe(updatedBy);
    }

    [Fact]
    public async Task Should_Adjust_Developer_Using_AdjustAsync()
    {
        // Arrange
        var request = await AddTestDeveloper("Test AdjustAsync Developer");
        var originalId = request.Id;

        request.Name = "Adjusted Developer";
        request.Phone = "7777777777";
        request.UpdatedBy = Guid.NewGuid();
        request.UpdatedAt = DateTime.UtcNow;

        // Act
        var result = await _repository.AdjustAsync(request);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Name.ShouldBe("Adjusted Developer");
        result.Phone.ShouldBe("7777777777");
        result.RawVersion.ShouldBe(2);
        result.UpdatedBy.ShouldBe(request.UpdatedBy);
        result.IsDeleted.ShouldBeFalse();

        var adjusted = await _repository.GetAsync(originalId);
        _ = adjusted.ShouldNotBeNull();
        adjusted.Id.ShouldBe(originalId);
        adjusted.Name.ShouldBe("Test AdjustAsync Developer");
        adjusted.Phone.ShouldBe("1234567890");
        adjusted.RawVersion.ShouldBe(1);
        adjusted.UpdatedBy.ShouldBe(request.UpdatedBy);
        adjusted.IsDeleted.ShouldBeTrue();
    }

    [Fact]
    public async Task Should_Filter_Developers_By_IsDeleted()
    {
        // Arrange
        _ = await AddTestDeveloper("Active Developer", isDeleted: false);
        _ = await AddTestDeveloper("Deleted Developer", isDeleted: true);

        // Act
        var active = await _repository.GetListAsync(x => !x.IsDeleted);
        var deleted = await _repository.GetListAsync(x => x.IsDeleted);

        // Assert
        active.ShouldContain(x => x.Name == "Active Developer");
        active.ShouldNotContain(x => x.Name == "Deleted Developer");
        deleted.ShouldContain(x => x.Name == "Deleted Developer");
        deleted.ShouldNotContain(x => x.Name == "Active Developer");
    }

    [Fact]
    public async Task Should_Filter_Developers_By_IsActive()
    {
        // Arrange
        _ = await AddTestDeveloper("Active Developer", isActive: true);
        _ = await AddTestDeveloper("Inactive Developer", isActive: false);

        // Act
        var active = await _repository.GetListAsync(x => x.IsActive);
        var inactive = await _repository.GetListAsync(x => !x.IsActive);

        // Assert
        active.ShouldContain(x => x.Name == "Active Developer");
        active.ShouldNotContain(x => x.Name == "Inactive Developer");
        inactive.ShouldContain(x => x.Name == "Inactive Developer");
        inactive.ShouldNotContain(x => x.Name == "Active Developer");
    }

    private async Task<Developer> AddTestDeveloper(string name, bool isActive = true, bool isDeleted = false)
    {
        var developerType = await CreateTestDeveloperType();

        return await _repository.InsertAsync(new Developer
        {
            Name = name,
            Phone = "1234567890",
            IdCard = "ID123456789",
            DeveloperTypeCode = developerType.Id,
            RawVersion = 1,
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = isActive,
            IsDeleted = isDeleted
        }, true);
    }

    private async Task AddTestDevelopers()
    {
        _ = await AddTestDeveloper("Frontend Developer");
        _ = await AddTestDeveloper("Backend Developer");
        _ = await AddTestDeveloper("Full Stack Developer");
    }

    private async Task<DeveloperType> CreateTestDeveloperType()
    {
        var existing = await _developerTypeRepository.FindAsync(x => x.Name == "Test Developer Type");

        return existing.IsNotNull()
            ? existing
            : await _developerTypeRepository.InsertAsync(new DeveloperType
            {
                Name = "Test Developer Type",
                CreatedBy = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                IsDeleted = false
            }, true);
    }
}
