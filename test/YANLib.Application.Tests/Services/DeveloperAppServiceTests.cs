using Shouldly;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;
using YANLib.Entities;
using YANLib.Requests.v1.Create;
using YANLib.Requests.v1.Update;
using YANLib.Services.v1;

namespace YANLib.Services;

public abstract class DeveloperAppServiceTests<TStartupModule> : YANLibApplicationTestBase<TStartupModule> where TStartupModule : IAbpModule
{
    private readonly IDeveloperService _service;
    private readonly IRepository<DeveloperType, long> _developerTypeRepository;

    protected DeveloperAppServiceTests()
    {
        _service = GetRequiredService<IDeveloperService>();
        _developerTypeRepository = GetRequiredService<IRepository<DeveloperType, long>>();
    }

    [Fact]
    public async Task Should_Create_Developer()
    {
        // Arrange
        var developerType = await CreateTestDeveloperType();

        var request = new DeveloperCreateRequest
        {
            Name = "Test Developer",
            Phone = "1234567890",
            IdCard = "ID123456789",
            DeveloperTypeCode = developerType.Id,
            RawVersion = 1,
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        // Act
        var result = await _service.CreateAsync(request);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldNotBe(Guid.Empty);
        result.Name.ShouldBe(request.Name);
        result.Phone.ShouldBe(request.Phone);
        result.IdCard.ShouldBe(request.IdCard);
    }

    [Fact]
    public async Task Should_Get_All_Developers()
    {
        // Arrange
        var developerType = await CreateTestDeveloperType();

        var request = new DeveloperCreateRequest
        {
            Name = "Test Developer",
            Phone = "1234567890",
            IdCard = "ID123456789",
            DeveloperTypeCode = developerType.Id,
            RawVersion = 1,
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
    public async Task Should_Get_Developer_By_Id()
    {
        // Arrange
        var developerType = await CreateTestDeveloperType();

        var request = new DeveloperCreateRequest
        {
            Name = "Test Developer",
            Phone = "1234567890",
            IdCard = "ID123456789",
            DeveloperTypeCode = developerType.Id,
            RawVersion = 1,
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
        result.Phone.ShouldBe(created.Phone);
        result.IdCard.ShouldBe(created.IdCard);
    }

    [Fact]
    public async Task Should_Update_Developer()
    {
        // Arrange
        var developerType = await CreateTestDeveloperType();

        var createRequest = new DeveloperCreateRequest
        {
            Name = "Test Developer",
            Phone = "1234567890",
            IdCard = "ID123456789",
            DeveloperTypeCode = developerType.Id,
            RawVersion = 1,
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        var created = await _service.CreateAsync(createRequest);

        var updateRequest = new DeveloperUpdateRequest
        {
            Name = "Updated Test Developer",
            Phone = "0987654321",
            IdCard = "ID987654321",
            DeveloperTypeCode = developerType.Id,
            RawVersion = 2,
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
        result.Phone.ShouldBe(updateRequest.Phone);
        result.IdCard.ShouldBe(updateRequest.IdCard);
    }

    [Fact]
    public async Task Should_Delete_Developer()
    {
        // Arrange
        var developerType = await CreateTestDeveloperType();

        var request = new DeveloperCreateRequest
        {
            Name = "Test Developer",
            Phone = "1234567890",
            IdCard = "ID123456789",
            DeveloperTypeCode = developerType.Id,
            RawVersion = 1,
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

    private async Task<DeveloperType> CreateTestDeveloperType() => await _developerTypeRepository.InsertAsync(new DeveloperType
    {
        Name = "Test Developer Type",
        CreatedBy = Guid.NewGuid(),
        CreatedAt = DateTime.UtcNow,
        IsActive = true,
        IsDeleted = false
    }, true);
}
