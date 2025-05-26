using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace YANLib.Entities;

public class DeveloperTests
{
    [Fact]
    public void Should_Create_Developer_With_Default_Id()
    {
        // Act
        var developer = new Developer();

        // Assert
        _ = developer.ShouldNotBeNull();
        developer.Id.ShouldNotBe(Guid.Empty);
    }

    [Fact]
    public void Should_Create_Developer_With_Properties()
    {
        var developerType = new DeveloperType
        {
            Name = "Test Developer Type",
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        // Arrange
        var name = "Test Developer";
        var phone = "1234567890";
        var idCard = "ID123456789";
        var developerTypeCode = developerType.Id;
        var rawVersion = 1;
        var createdBy = Guid.NewGuid();
        var createdAt = DateTime.UtcNow;
        var isActive = true;
        var isDeleted = false;

        // Act
        var developer = new Developer
        {
            Name = name,
            Phone = phone,
            IdCard = idCard,
            DeveloperTypeCode = developerTypeCode,
            RawVersion = rawVersion,
            CreatedBy = createdBy,
            CreatedAt = createdAt,
            IsActive = isActive,
            IsDeleted = isDeleted
        };

        // Assert
        _ = developerType.ShouldNotBeNull();
        developer.Id.ShouldNotBe(Guid.Empty);
        developer.Name.ShouldBe(name);
        developer.Phone.ShouldBe(phone);
        developer.IdCard.ShouldBe(idCard);
        developer.DeveloperTypeCode.ShouldBe(developerTypeCode);
        developer.RawVersion.ShouldBe(rawVersion);
        developer.CreatedBy.ShouldBe(createdBy);
        developer.CreatedAt.ShouldBe(createdAt);
        developer.IsActive.ShouldBe(isActive);
        developer.IsDeleted.ShouldBe(isDeleted);
    }

    [Fact]
    public async Task Should_Create_Developers_Different_Ids_For_Different_Instances()
    {
        // Act
        var developer1 = new Developer();

        await Task.Delay(1);

        var developer2 = new Developer();

        // Assert
        developer1.Id.ShouldNotBe(developer2.Id);
    }

    [Fact]
    public void Should_Set_And_Get_Developer_Properties()
    {
        // Arrange
        var developer = new Developer();
        var name = "Updated Test Developer";
        var phone = "0987654321";
        var idCard = "ID987654321";
        var updatedBy = Guid.NewGuid();
        var updatedAt = DateTime.UtcNow;

        // Act
        developer.Name = name;
        developer.Phone = phone;
        developer.IdCard = idCard;
        developer.UpdatedBy = updatedBy;
        developer.UpdatedAt = updatedAt;

        // Assert
        developer.Name.ShouldBe(name);
        developer.Phone.ShouldBe(phone);
        developer.IdCard.ShouldBe(idCard);
        developer.UpdatedBy.ShouldBe(updatedBy);
        developer.UpdatedAt.ShouldBe(updatedAt);
    }

    [Fact]
    public void Should_Have_Developer_Default_Values()
    {
        // Act
        var developer = new Developer();

        // Assert
        developer.IsActive.ShouldBeTrue();
        developer.IsDeleted.ShouldBeFalse();
        developer.RawVersion.ShouldBe(1);
        developer.UpdatedBy.ShouldBeNull();
        developer.UpdatedAt.ShouldBeNull();
    }
}
