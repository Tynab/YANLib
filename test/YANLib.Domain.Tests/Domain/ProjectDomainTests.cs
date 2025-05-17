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
    public async Task Should_Create_Project()
    {
        // Arrange
        var project = new Project
        {
            Name = "Domain Test Project",
            Description = "Domain Test Project Description",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        // Act
        var result = await _repository.InsertAsync(project, true);

        // Assert
        _ = result.Id.ShouldNotBeNull();
        result.Name.ShouldBe(project.Name);
        result.Description.ShouldBe(project.Description);
    }

    [Fact]
    public async Task Should_Get_All_Projects()
    {
        // Arrange
        var project = new Project
        {
            Name = "Domain Test Project for GetList",
            Description = "Domain Test Project Description for GetList",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        _ = await _repository.InsertAsync(project, true);

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
        var request = new Project
        {
            Name = "Domain Test Project for Get",
            Description = "Domain Test Project Description for Get",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        var created = await _repository.InsertAsync(request, true);

        // Act
        var result = await _repository.GetAsync(created.Id);

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
        var project = new Project
        {
            Name = "Domain Test Project for Update",
            Description = "Domain Test Project Description for Update",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        var created = await _repository.InsertAsync(project, true);

        created.Name = "Updated Domain Test Project";
        created.Description = "Updated Domain Test Project Description";
        created.UpdatedBy = Guid.NewGuid();
        created.UpdatedAt = DateTime.UtcNow;

        // Act
        _ = await _repository.UpdateAsync(created, true);

        var updated = await _repository.GetAsync(created.Id);

        // Assert
        _ = updated.ShouldNotBeNull();
        updated.Id.ShouldBe(created.Id);
        updated.Name.ShouldBe("Updated Domain Test Project");
        updated.Description.ShouldBe("Updated Domain Test Project Description");
        updated.UpdatedBy.ShouldBe(created.UpdatedBy);
    }

    [Fact]
    public async Task Should_Delete_Project()
    {
        // Arrange
        var project = new Project
        {
            Name = "Domain Test Project for Delete",
            Description = "Domain Test Project Description for Delete",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        var created = await _repository.InsertAsync(project, true);

        // Act
        await _repository.DeleteAsync(created.Id);

        // Assert
        _ = await Assert.ThrowsAsync<EntityNotFoundException>(async () => await _repository.GetAsync(created.Id));
    }
}
