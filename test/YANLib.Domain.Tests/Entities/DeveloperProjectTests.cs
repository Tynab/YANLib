using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace YANLib.Entities;

public class DeveloperProjectTests
{
    [Fact]
    public void Should_Create_DeveloperProject_With_Default_Id()
    {
        var developerType = new DeveloperType
        {
            Name = "Test Developer Type",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        var developer = new Developer
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

        var project = new Project
        {
            Name = "Test Project",
            Description = "Test Project Description",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        // Act
        var developerProject = new DeveloperProject
        {
            DeveloperId = developer.Id,
            ProjectId = project.Id
        };

        // Assert
        _ = developerProject.ShouldNotBeNull();
        developerProject.Id.ShouldNotBe(Guid.Empty);
    }

    [Fact]
    public void Should_Create_DeveloperProject_With_Properties()
    {
        var developerType = new DeveloperType
        {
            Name = "Test Developer Type",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        var developer = new Developer
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

        var project = new Project
        {
            Name = "Test Project",
            Description = "Test Project Description",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        // Arrange
        var developerId = developer.Id;
        var projectId = project.Id;
        var createdBy = Guid.NewGuid();
        var createdAt = DateTime.UtcNow;
        var isActive = true;
        var isDeleted = false;

        // Act
        var developerProject = new DeveloperProject
        {
            DeveloperId = developerId,
            ProjectId = projectId,
            CreatedBy = createdBy,
            CreatedAt = createdAt,
            IsActive = isActive,
            IsDeleted = isDeleted
        };
        // Assert
        _ = developerProject.ShouldNotBeNull();
        developerProject.Id.ShouldNotBe(Guid.Empty);
        developerProject.DeveloperId.ShouldBe(developerId);
        developerProject.ProjectId.ShouldBe(projectId);
        developerProject.CreatedBy.ShouldBe(createdBy);
        developerProject.CreatedAt.ShouldBe(createdAt);
        developerProject.IsActive.ShouldBe(isActive);
        developerProject.IsDeleted.ShouldBe(isDeleted);
    }

    [Fact]
    public async Task Should_Create_DeveloperProjects_Different_Ids_For_Different_Instances()
    {
        var developerType = new DeveloperType
        {
            Name = "Test Developer Type",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        var developer = new Developer
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

        var project = new Project
        {
            Name = "Test Project",
            Description = "Test Project Description",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        // Act
        var developerProject1 = new DeveloperProject
        {
            DeveloperId = developer.Id,
            ProjectId = project.Id
        };

        await Task.Delay(1);

        var developerProject2 = new DeveloperProject
        {
            DeveloperId = developer.Id,
            ProjectId = project.Id
        };

        // Assert
        developerProject1.Id.ShouldNotBe(developerProject2.Id);
    }

    [Fact]
    public void Should_Set_And_Get_DeveloperProject_Properties()
    {
        var developerType = new DeveloperType
        {
            Name = "Test Developer Type",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        var developer = new Developer
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

        var project = new Project
        {
            Name = "Test Project",
            Description = "Test Project Description",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        // Arrange
        var developerId = developer.Id;
        var projectId = project.Id;
        var updatedBy = Guid.NewGuid();
        var updatedAt = DateTime.UtcNow;

        // Act
        var developerProject = new DeveloperProject
        {
            DeveloperId = developerId,
            ProjectId = projectId,
            UpdatedBy = updatedBy,
            UpdatedAt = updatedAt,
            IsActive = false
        };

        // Assert
        developerProject.UpdatedBy.ShouldBe(updatedBy);
        developerProject.UpdatedAt.ShouldBe(updatedAt);
        developerProject.IsActive.ShouldBeFalse();
    }

    [Fact]
    public void Should_Have_DeveloperProject_Default_Values()
    {
        var developerType = new DeveloperType
        {
            Name = "Test Developer Type",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        var developer = new Developer
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

        var project = new Project
        {
            Name = "Test Project",
            Description = "Test Project Description",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        // Arrange
        var developerProject = new DeveloperProject
        {
            DeveloperId = developer.Id,
            ProjectId = project.Id
        };

        // Assert
        developerProject.IsActive.ShouldBeTrue();
        developerProject.IsDeleted.ShouldBeFalse();
        developerProject.UpdatedBy.ShouldBeNull();
        developerProject.UpdatedAt.ShouldBeNull();
    }
}
