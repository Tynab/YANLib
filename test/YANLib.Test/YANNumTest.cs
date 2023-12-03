using static Xunit.Assert;

namespace YANLib.Test;

public sealed class YANNumTest
{
    [Fact]
    public void Round_NullInput_ReturnsDefault()
    {
        // Arrange
        object? num = null;
        object? d = null;

        // Act
        var result = num.Round(d);

        // Assert
        Equal(default(decimal), result);
    }

    [Fact]
    public void Round_WithoutDInput_ReturnsRoundedValue()
    {
        // Arrange
        object num = 10.12;

        // Act
        var result = num.Round();

        // Assert
        Equal(10.0, result);
    }

    [Fact]
    public void Round_ValidInput_ReturnsRoundedValue()
    {
        // Arrange
        object num = "10.12";
        object d = "1.1";

        // Act
        var result = num.Round(d);

        // Assert
        Equal(10.1m, result);
    }

    [Fact]
    public void Round_InvalidInput_ReturnsDefault()
    {
        // Arrange
        object num = "invalid";
        object d = "string";

        // Act
        var result = num.Round(d);

        // Assert
        Equal(default(decimal), result);
    }
}
