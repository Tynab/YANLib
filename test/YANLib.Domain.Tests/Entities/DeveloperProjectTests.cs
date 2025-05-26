using System;
using Shouldly;
using Xunit;
using YANLib.Entities;

namespace YANLib.Entities;

public class DeveloperProjectTests : YANLibDomainTestBase<YANLibDomainTestModule>
{
    [Fact]
    public void Should_Create_DeveloperProject_With_Valid_Data()
    {
        // Arrange
        var id = Guid.NewGuid();
        var developerId = Guid.NewGuid();
        var projectId = Guid.NewGuid();
        var role = "Full Stack Developer";
        var joinDate = DateTime.Now;

        // Act
        var developerProject = new DeveloperProject(id, developerId, projectId, role, joinDate);

        // Assert
        developerProject.Id.ShouldBe(id);
        developerProject.DeveloperId.ShouldBe(developerId);
        developerProject.ProjectId.ShouldBe(projectId);
        developerProject.Role.ShouldBe(role);
        developerProject.JoinDate.ShouldBe(joinDate);
        developerProject.IsActive.ShouldBe(true); // Default value
        developerProject.EndDate.ShouldBeNull();
    }

    [Fact]
    public void Should_Throw_Exception_When_DeveloperId_Is_Empty()
    {
        // Arrange & Act & Assert
        Should.Throw<ArgumentException>(() =>
            new DeveloperProject(Guid.NewGuid(), Guid.Empty, Guid.NewGuid(), "Developer", DateTime.Now)
        );
    }

    [Fact]
    public void Should_Throw_Exception_When_ProjectId_Is_Empty()
    {
        // Arrange & Act & Assert
        Should.Throw<ArgumentException>(() =>
            new DeveloperProject(Guid.NewGuid(), Guid.NewGuid(), Guid.Empty, "Developer", DateTime.Now)
        );
    }

    [Fact]
    public void Should_Throw_Exception_When_Role_Is_Null_Or_Empty()
    {
        // Arrange & Act & Assert
        Should.Throw<ArgumentException>(() =>
            new DeveloperProject(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), null, DateTime.Now)
        );

        Should.Throw<ArgumentException>(() =>
            new DeveloperProject(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), "", DateTime.Now)
        );
    }

    [Fact]
    public void Should_Set_EndDate_When_Deactivating()
    {
        // Arrange
        var developerProject = new DeveloperProject(
            Guid.NewGuid(),
            Guid.NewGuid(),
            Guid.NewGuid(),
            "Developer",
            DateTime.Now
        );

        var endDate = DateTime.Now.AddDays(30);

        // Act
        developerProject.IsActive = false;
        developerProject.EndDate = endDate;

        // Assert
        developerProject.IsActive.ShouldBe(false);
        developerProject.EndDate.ShouldBe(endDate);
    }

    [Fact]
    public void Should_Update_Role()
    {
        // Arrange
        var developerProject = new DeveloperProject(
            Guid.NewGuid(),
            Guid.NewGuid(),
            Guid.NewGuid(),
            "Junior Developer",
            DateTime.Now
        );

        var newRole = "Senior Developer";

        // Act
        developerProject.Role = newRole;

        // Assert
        developerProject.Role.ShouldBe(newRole);
    }
}
