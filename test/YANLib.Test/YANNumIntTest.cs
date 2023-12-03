using static Xunit.Assert;

namespace YANLib.Test;

public sealed class YANNumIntTest
{
    [Fact]
    public void ToInt_NullInput_ReturnsDefault()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.ToInt();

        // Assert
        Equal(default, result);
    }

    [Fact]
    public void ToInt_NumInput_ReturnsIntValue()
    {
        // Arrange
        object input = 10.1;

        // Act
        var result = input.ToInt();

        // Assert
        Equal(10, result);
    }

    [Fact]
    public void ToInt_ValidInput_ReturnsIntValue()
    {
        // Arrange
        object input = "10.1";

        // Act
        var result = input.ToInt();

        // Assert
        Equal(10, result);
    }

    [Fact]
    public void ToInt_InvalidInput_ReturnsDefault()
    {
        // Arrange
        object input = "invalid";

        // Act
        var result = input.ToInt();

        // Assert
        Equal(default, result);
    }
}
