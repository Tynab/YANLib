using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace YANLib.Entities;

public class DeveloperTypeTests
{
    [Fact]
    public void Should_Create_DeveloperType_With_Default_Id()
    {
        // Act
        var developerType = new DeveloperType();

        // Assert
        _ = developerType.ShouldNotBeNull();
        developerType.Id.ShouldNotBe(0);
    }

    [Fact]
    public void Should_Create_DeveloperType_With_Properties()
    {
        // Arrange
        var name = "Test Developer Type";
        var createdBy = Guid.NewGuid();
        var createdAt = DateTime.UtcNow;
        var isActive = true;
        var isDeleted = false;

        // Act
        var developerType = new DeveloperType
        {
            Name = name,
            CreatedBy = createdBy,
            CreatedAt = createdAt,
            IsActive = isActive,
            IsDeleted = isDeleted
        };

        // Assert
        _ = developerType.ShouldNotBeNull();
        developerType.Id.ShouldNotBe(0);
        developerType.Name.ShouldBe(name);
        developerType.CreatedBy.ShouldBe(createdBy);
        developerType.CreatedAt.ShouldBe(createdAt);
        developerType.IsActive.ShouldBe(isActive);
        developerType.IsDeleted.ShouldBe(isDeleted);
    }

    [Fact]
    public async Task Should_Create_DeveloperTypes_Different_Ids_For_Different_Instances()
    {
        // Act
        var developerType1 = new DeveloperType();

        await Task.Delay(1);

        var developerType2 = new DeveloperType();

        // Assert
        developerType1.Id.ShouldNotBe(developerType2.Id);
    }

    [Fact]
    public void Should_Set_And_Get_DeveloperType_Properties()
    {
        // Arrange
        var developerType = new DeveloperType();
        var name = "Updated Test Developer Type";
        var updatedBy = Guid.NewGuid();
        var updatedAt = DateTime.UtcNow;

        // Act
        developerType.Name = name;
        developerType.UpdatedBy = updatedBy;
        developerType.UpdatedAt = updatedAt;

        // Assert
        developerType.Name.ShouldBe(name);
        developerType.UpdatedBy.ShouldBe(updatedBy);
        developerType.UpdatedAt.ShouldBe(updatedAt);
    }

    [Fact]
    public void Should_Have_DeveloperType_Default_Values()
    {
        // Act
        var developerType = new DeveloperType();

        // Assert
        developerType.IsActive.ShouldBeTrue();
        developerType.IsDeleted.ShouldBeFalse();
        developerType.UpdatedBy.ShouldBeNull();
        developerType.UpdatedAt.ShouldBeNull();
    }
}
