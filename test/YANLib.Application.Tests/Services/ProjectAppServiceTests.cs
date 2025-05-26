using Shouldly;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Modularity;
using Xunit;
using YANLib.Requests.v1.Create;
using YANLib.Requests.v1.Update;
using YANLib.Services.v1;

namespace YANLib.Services;

public abstract class ProjectAppServiceTests<TStartupModule> : YANLibApplicationTestBase<TStartupModule> where TStartupModule : IAbpModule
{
    private readonly IProjectService _service;

    protected ProjectAppServiceTests() => _service = GetRequiredService<IProjectService>();

    [Fact]
    public async Task Should_Create_Project()
    {
        // Arrange
        var request = new ProjectCreateRequest
        {
            Name = "Test Project",
            Description = "Test Project Description",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        // Act
        var result = await _service.CreateAsync(request);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldNotBeNullOrWhiteSpace();
        result.Name.ShouldBe(request.Name);
        result.Description.ShouldBe(request.Description);
    }

    [Fact]
    public async Task Should_Get_All_Projects()
    {
        // Arrange
        var request = new ProjectCreateRequest
        {
            Name = "Test Project",
            Description = "Test Project Description",
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
    public async Task Should_Get_Project_By_Id()
    {
        // Arrange
        var request = new ProjectCreateRequest
        {
            Name = "Test Project",
            Description = "Test Project Description",
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
        result.Name.ShouldBe(request.Name);
        result.Description.ShouldBe(request.Description);
    }

    [Fact]
    public async Task Should_Update_Project()
    {
        // Arrange
        var createRequest = new ProjectCreateRequest
        {
            Name = "Test Project",
            Description = "Test Project Description",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        var created = await _service.CreateAsync(createRequest);

        var updateRequest = new ProjectUpdateRequest
        {
            Name = "Updated Test Project",
            Description = "Updated Test Project Description",
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
        result.Description.ShouldBe(updateRequest.Description);
    }

    [Fact]
    public async Task Should_Delete_Project()
    {
        // Arrange
        var request = new ProjectCreateRequest
        {
            Name = "Test Project",
            Description = "Test Project Description",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.Now,
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
