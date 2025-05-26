using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace YANLib.Entities;

public class ProjectTests
{
    [Fact]
    public void Should_Create_Project_With_Default_Id()
    {
        // Act
        var project = new Project();

        // Assert
        _ = project.ShouldNotBeNull();
        project.Id.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void Should_Create_Project_With_Properties()
    {
        // Arrange
        var name = "Test Project";
        var description = "Test Project Description";
        var createdBy = Guid.NewGuid();
        var createdAt = DateTime.UtcNow;
        var isActive = true;
        var isDeleted = false;

        // Act
        var project = new Project
        {
            Name = name,
            Description = description,
            CreatedBy = createdBy,
            CreatedAt = createdAt,
            IsActive = isActive,
            IsDeleted = isDeleted
        };

        // Assert
        _ = project.ShouldNotBeNull();
        project.Id.ShouldNotBeNullOrWhiteSpace();
        project.Name.ShouldBe(name);
        project.Description.ShouldBe(description);
        project.CreatedBy.ShouldBe(createdBy);
        project.CreatedAt.ShouldBe(createdAt);
        project.IsActive.ShouldBe(isActive);
        project.IsDeleted.ShouldBe(isDeleted);
    }

    [Fact]
    public async Task Should_Create_Projects_Different_Ids_For_Different_Instances()
    {
        // Act
        var project1 = new Project();

        await Task.Delay(1);

        var project2 = new Project();

        // Assert
        project1.Id.ShouldNotBe(project2.Id);
    }

    [Fact]
    public void Should_Set_And_Get_Project_Properties()
    {
        // Arrange
        var project = new Project();
        var name = "Updated Test Project";
        var description = "Updated Test Project Description";
        var updatedBy = Guid.NewGuid();
        var updatedAt = DateTime.UtcNow;

        // Act
        project.Name = name;
        project.Description = description;
        project.UpdatedBy = updatedBy;
        project.UpdatedAt = updatedAt;

        // Assert
        project.Name.ShouldBe(name);
        project.Description.ShouldBe(description);
        project.UpdatedBy.ShouldBe(updatedBy);
        project.UpdatedAt.ShouldBe(updatedAt);
    }

    [Fact]
    public void Should_Have_Project_Default_Values()
    {
        // Act
        var project = new Project();

        // Assert
        project.IsActive.ShouldBeTrue();
        project.IsDeleted.ShouldBeFalse();
        project.UpdatedBy.ShouldBeNull();
        project.UpdatedAt.ShouldBeNull();
    }
}
