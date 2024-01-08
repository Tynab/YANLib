using static Xunit.Assert;

namespace YANLib.Test.Nullable;

public sealed class YANBoolTest
{
    [Fact]
    public void ToBool_NullInputWithNoDefault_ReturnsConvertedBool()
    {
        // Arrange
        object? input = null;

        // Act
        var result = YANLib.Nullable.YANBool.ToBool(input);

        // Assert
        Equal(false, result);
    }

    [Fact]
    public void ToBool_NullInputWithDefault_ReturnsConvertedBool()
    {
        // Arrange
        object? input = null;
        object? defaultValue = true;

        // Act
        var result = YANLib.Nullable.YANBool.ToBool(input, defaultValue);

        // Assert
        Equal(false, result);
    }

    [Fact]
    public void ToBool_ValidInput_ReturnsConvertedBool()
    {
        // Arrange
        object? input = "true";

        // Act
        var result = YANLib.Nullable.YANBool.ToBool(input);

        // Assert
        Equal(true, result);
    }

    [Fact]
    public void ToBool_InvalidInputWithNoDefault_ReturnsNull()
    {
        // Arrange
        object? input = "invalid";

        // Act
        var result = YANLib.Nullable.YANBool.ToBool(input);

        // Assert
        Null(result);
    }

    [Fact]
    public void ToBool_InvalidInputWithDefault_ReturnsConvertedDefault()
    {
        // Arrange
        object? input = "invalid";
        object? defaultValue = false;

        // Act
        var result = YANLib.Nullable.YANBool.ToBool(input, defaultValue);

        // Assert
        Equal(false, result);
    }

    [Fact]
    public void ToBool_InvalidInputWithInvalidDefault_ReturnsNull()
    {
        // Arrange
        object? input = "invalid";
        object? defaultValue = "invalid";

        // Act
        var result = YANLib.Nullable.YANBool.ToBool(input, defaultValue);

        // Assert
        Null(result);
    }
}
