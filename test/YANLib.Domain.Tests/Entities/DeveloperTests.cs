using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace YANLib.Entities;

public class DeveloperTests
{
    [Fact]
    public void Should_Create_With_Default_Id()
    {
        // Act
        var developer = new Developer();

        // Assert
        _ = developer.ShouldNotBeNull();
        developer.Id.ShouldNotBe(Guid.Empty);
    }

    [Fact]
    public void Should_Create_With_Properties()
    {
        // Arrange & Act
        var developer = new Developer
        {
            Name = "Test Developer",
            Phone = "1234567890",
            IdCard = "ID123456789",
            DeveloperTypeCode = 1,
            RawVersion = 1,
            CreatedBy = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            IsDeleted = false
        };

        // Assert
        developer.Name.ShouldBe("Test Developer");
        developer.Phone.ShouldBe("1234567890");
        developer.IdCard.ShouldBe("ID123456789");
        developer.DeveloperTypeCode.ShouldBe(1);
        developer.RawVersion.ShouldBe(1);
        developer.IsActive.ShouldBeTrue();
        developer.IsDeleted.ShouldBeFalse();
    }

    [Fact]
    public async Task Should_Create_Different_Ids_For_Different_Instances()
    {
        // Act
        var developer1 = new Developer();

        await Task.Delay(1);

        var developer2 = new Developer();

        // Assert
        developer1.Id.ShouldNotBe(developer2.Id);
    }

    [Fact]
    public void Should_Set_And_Get_Properties()
    {
        // Arrange
        var developer = new Developer();
        var name = "Test Developer";
        var phone = "1234567890";
        var idCard = "ID123456789";
        var createdBy = Guid.NewGuid();
        var createdAt = DateTime.UtcNow;
        var isActive = true;
        var isDeleted = false;

        // Act
        developer.Name = name;
        developer.Phone = phone;
        developer.IdCard = idCard;
        developer.CreatedBy = createdBy;
        developer.CreatedAt = createdAt;
        developer.IsActive = isActive;
        developer.IsDeleted = isDeleted;

        // Assert
        _ = developer.ShouldNotBeNull();
        developer.Name.ShouldBe(name);
        developer.Phone.ShouldBe(phone);
        developer.IdCard.ShouldBe(idCard);
        developer.CreatedBy.ShouldBe(createdBy);
        developer.CreatedAt.ShouldBe(createdAt);
        developer.IsActive.ShouldBe(isActive);
        developer.IsDeleted.ShouldBe(isDeleted);
    }

    [Fact]
    public void Should_Have_Default_Values()
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
