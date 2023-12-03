using static Xunit.Assert;

namespace YANLib.Test;

public sealed class YANBoolTest
{
    [Fact]
    public void ToBool_NullInput_ReturnsDefault()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.ToBool();

        // Assert
        Equal(default, result);
    }

    [Fact]
    public void ToBool_NumInput_ReturnsBoolValue()
    {
        // Arrange
        object input = 1;

        // Act
        var result = input.ToBool();

        // Assert
        True(result);
    }

    [Fact]
    public void ToBool_ValidInput_ReturnsBoolValue()
    {
        // Arrange
        object input = "true";

        // Act
        var result = input.ToBool();

        // Assert
        True(result);
    }

    [Fact]
    public void ToBool_InvalidInput_ReturnsDefault()
    {
        // Arrange
        object input = "invalid";

        // Act
        var result = input.ToBool();

        // Assert
        Equal(default, result);
    }
}
