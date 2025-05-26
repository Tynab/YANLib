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

    protected DeveloperTypeAppServiceTests() => _service = GetRequiredService<IDeveloperTypeService>();

    [Fact]
    public async Task Should_Create_DeveloperType()
    {
        // Arrange
        var request = new DeveloperTypeCreateRequest
        {
            Name = "Test Developer Type",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        // Act
        var result = await _service.CreateAsync(request);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldNotBe(0);
        result.Name.ShouldBe(request.Name);
    }

    [Fact]
    public async Task Should_Get_All_DeveloperTypes()
    {
        // Arrange
        var request = new DeveloperTypeCreateRequest
        {
            Name = "Test Developer Type",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        _ = await _service.CreateAsync(request);

        // Act
        var result = await _service.GetListAsync(new());

        // Assert
        _ = result.ShouldNotBeNull();
        result.TotalCount.ShouldBeGreaterThan(0);
        result.Items.ShouldNotBeEmpty();
    }

    [Fact]
    public async Task Should_Get_DeveloperType_By_Id()
    {
        // Arrange
        var request = new DeveloperTypeCreateRequest
        {
            Name = "Test Developer Type",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        var created = await _service.CreateAsync(request);

        // Act
        var result = await _service.GetAsync(created.Id);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldBe(created.Id);
        result.Name.ShouldBe(created.Name);
    }

    [Fact]
    public async Task Should_Update_DeveloperType()
    {
        // Arrange
        var createRequest = new DeveloperTypeCreateRequest
        {
            Name = "Test Developer Type",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        var created = await _service.CreateAsync(createRequest);

        var updateRequest = new DeveloperTypeUpdateRequest
        {
            Name = "Updated Test Developer Type",
            CreatedBy = created.CreatedBy,
            CreatedAt = created.CreatedAt,
            UpdatedBy = Guid.NewGuid(),
            UpdatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        // Act
        var result = await _service.UpdateAsync(created.Id, updateRequest);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldBe(created.Id);
        result.Name.ShouldBe(updateRequest.Name);
    }

    [Fact]
    public async Task Should_Delete_DeveloperType()
    {
        // Arrange
        var request = new DeveloperTypeCreateRequest
        {
            Name = "Test Developer Type",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        var created = await _service.CreateAsync(request);

        // Act
        await _service.DeleteAsync(created.Id);

        // Assert
        _ = await Assert.ThrowsAsync<EntityNotFoundException>(async () => await _service.GetAsync(created.Id));
    }
}
