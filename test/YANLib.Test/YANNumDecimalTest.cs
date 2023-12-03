using static Xunit.Assert;

namespace YANLib.Test;

public sealed class YANNumDecimalTest
{
    [Fact]
    public void ToDecimal_NullInput_ReturnsDefault()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.ToDecimal();

        // Assert
        Equal(default, result);
    }

    [Fact]
    public void ToDecimal_NumInput_ReturnsDecimalValue()
    {
        // Arrange
        object input = 10.1;

        // Act
        var result = input.ToDecimal();

        // Assert
        Equal(10.1m, result);
    }

    [Fact]
    public void ToDecimal_ValidInput_ReturnsDecimalValue()
    {
        // Arrange
        object input = "10.1";

        // Act
        var result = input.ToDecimal();

        // Assert
        Equal(10.1m, result);
    }

    [Fact]
    public void ToDecimal_InvalidInput_ReturnsDefault()
    {
        // Arrange
        object input = "invalid";

        // Act
        var result = input.ToDecimal();

        // Assert
        Equal(default, result);
    }
}
