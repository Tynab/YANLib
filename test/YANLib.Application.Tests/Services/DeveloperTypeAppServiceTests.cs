using Shouldly;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Modularity;
using Xunit;
using YANLib.Requests.v1.Create;
using YANLib.Requests.v1.Update;
using YANLib.Services.v1;

namespace YANLib.Services;

public abstract class DeveloperTypeAppServiceTests<TStartupModule> : YANLibApplicationTestBase<TStartupModule> where TStartupModule : IAbpModule
{
    private readonly IDeveloperTypeService _service;

    public DeveloperTypeAppServiceTests() => _service = GetRequiredService<IDeveloperTypeService>();

    [Fact]
    public async Task Should_Get_All_DeveloperTypes()
    {
        // Act
        var result = await _service.GetListAsync(new PagedAndSortedResultRequestDto
        {
            MaxResultCount = 10
        });

        // Assert
        _ = result.ShouldNotBeNull();
        result.TotalCount.ShouldBeGreaterThan(0);
        result.Items.ShouldNotBeEmpty();
    }

    [Fact]
    public async Task Should_Get_DeveloperType_By_Id()
    {
        // Arrange
        var developerTypes = await _service.GetListAsync(new PagedAndSortedResultRequestDto
        {
            MaxResultCount = 1
        });

        var firstDeveloperType = developerTypes.Items[0];

        // Act
        var result = await _service.GetAsync(firstDeveloperType.Id);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldBe(firstDeveloperType.Id);
        result.Name.ShouldBe(firstDeveloperType.Name);
    }

    [Fact]
    public async Task Should_Create_DeveloperType()
    {
        // Arrange
        var newDeveloperType = new DeveloperTypeCreateRequest
        {
            Name = "Test Developer Type",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        // Act
        var result = await _service.CreateAsync(newDeveloperType);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldNotBe(0);
        result.Name.ShouldBe(newDeveloperType.Name);

        var retrievedType = await _service.GetAsync(result.Id);
        _ = retrievedType.ShouldNotBeNull();
        retrievedType.Name.ShouldBe(newDeveloperType.Name);
    }

    [Fact]
    public async Task Should_Update_DeveloperType()
    {
        // Arrange
        var newDeveloperType = new DeveloperTypeCreateRequest
        {
            Name = "Developer Type To Update",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        var created = await _service.CreateAsync(newDeveloperType);

        var updateData = new DeveloperTypeUpdateRequest
        {
            Name = "Updated Developer Type",
            CreatedBy = created.CreatedBy,
            CreatedAt = created.CreatedAt,
            UpdatedBy = Guid.NewGuid(),
            UpdatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        // Act
        var result = await _service.UpdateAsync(created.Id, updateData);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldBe(created.Id);
        result.Name.ShouldBe(updateData.Name);

        var retrievedType = await _service.GetAsync(created.Id);
        _ = retrievedType.ShouldNotBeNull();
        retrievedType.Name.ShouldBe(updateData.Name);
    }

    [Fact]
    public async Task Should_Delete_DeveloperType()
    {
        // Arrange
        var newDeveloperType = new DeveloperTypeCreateRequest
        {
            Name = "Developer Type To Delete",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        var created = await _service.CreateAsync(newDeveloperType);

        // Act
        await _service.DeleteAsync(created.Id);

        // Assert
        _ = await Assert.ThrowsAsync<EntityNotFoundException>(async () => await _service.GetAsync(created.Id));
    }
}
