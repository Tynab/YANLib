using Shouldly;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;
using YANLib.Entities;

namespace YANLib.Domain;

public abstract class ProjectDomainTests<TStartupModule> : YANLibDomainTestBase<TStartupModule> where TStartupModule : IAbpModule
{
    private readonly IRepository<Project, string> _repository;

    protected ProjectDomainTests() => _repository = GetRequiredService<IRepository<Project, string>>();

    [Fact]
    public async Task Should_Insert_Project()
    {
        // Arrange
        var entity = new Project
        {
            Name = "Test Project",
            Description = "Test Project Description",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow
        };

        // Act
        var result = await _repository.InsertAsync(entity, true);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldNotBeNullOrWhiteSpace();
        result.Name.ShouldBe(entity.Name);
        result.Description.ShouldBe(entity.Description);
    }

    [Fact]
    public async Task Should_Get_All_Projects()
    {
        // Arrange
        var entity = new Project
        {
            Name = "Test Project",
            Description = "Test Project Description",
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
    public async Task Should_Get_Project_By_Id()
    {
        // Arrange
        var entity = new Project
        {
            Name = "Test Project",
            Description = "Test Project Description",
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
        result.Description.ShouldBe(inserted.Description);
    }

    [Fact]
    public async Task Should_Update_Project()
    {
        // Arrange
        var entity = new Project
        {
            Name = "Test Project",
            Description = "Test Project Description",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow
        };

        var inserted = await _repository.InsertAsync(entity, true);

        inserted.Name = "Updated Test Project";
        inserted.Description = "Updated Test Project Description";
        inserted.UpdatedBy = Guid.NewGuid();
        inserted.UpdatedAt = DateTime.UtcNow;

        // Act
        var updated = await _repository.UpdateAsync(inserted, true);
        var result = await _repository.FindAsync(inserted.Id);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldBe(inserted.Id);
        result.Name.ShouldBe(updated.Name);
        result.Description.ShouldBe(updated.Description);
    }

    [Fact]
    public async Task Should_Delete_Project()
    {
        // Arrange
        var entity = new Project
        {
            Name = "Test Project",
            Description = "Test Project Description",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
        };

        var inserted = await _repository.InsertAsync(entity, true);

        // Act
        await _repository.DeleteAsync(inserted.Id);

        // Assert
        _ = await Assert.ThrowsAsync<EntityNotFoundException>(async () => await _repository.GetAsync(inserted.Id));
    }
}
