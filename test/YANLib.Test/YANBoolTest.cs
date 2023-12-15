using static Xunit.Assert;
using static YANLib.YANBool;

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

    [Fact]
    public void ToBool_NullInputWithDefault_ReturnsDefaultValue()
    {
        // Arrange
        object? input = "invalid";
        object defaultValue = true;

        // Act
        var result = input.ToBool(defaultValue);

        // Assert
        True(result);
    }

    [Fact]
    public void ToBool_EnumerableInput_ReturnsBools()
    {
        // Arrange
        IEnumerable<object?> input = new object?[] { 1, "true", null };

        // Act
        var result = input.ToBools();

        // Assert
        Equal([true, true, false], result!);
    }

    [Fact]
    public void ToBool_EnumerableInputWithDefault_ReturnsBools()
    {
        // Arrange
        IEnumerable<object?> input = new object?[] { 1, "invalid", null };
        object defaultValue = true;

        // Act
        var result = input.ToBools(defaultValue);

        // Assert
        Equal([true, true, false], result!);
    }

    [Fact]
    public void GenerateRandomBool_ReturnsBool()
    {
        // Act
        var result = GenerateRandomBool();

        // Assert
        _ = IsType<bool>(result);
    }

    [Fact]
    public void GenerateRandomBools_WithSize_ReturnsBoolArray()
    {
        // Arrange
        var size = 5;

        // Act
        var result = GenerateRandomBools(size);

        // Assert
        Equal(5, result.Count());
        All(result, x => IsType<bool>(x));
    }
}
