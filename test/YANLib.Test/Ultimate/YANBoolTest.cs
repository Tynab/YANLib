using static Xunit.Assert;
using static YANLib.Ultimate.YANBool;

namespace YANLib.Test.Ultimate;

public sealed class YANBoolTest
{
    [Fact]
    public void ToBools_NullEnumerable_ReturnsEmpty()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = YANLib.Ultimate.YANBool.ToBools(input);

        // Assert
        Empty(result);
    }

    [Fact]
    public void ToBools_EmptyEnumerable_ReturnsEmpty()
    {
        // Arrange
        IEnumerable<object?> input = new List<object?>();

        // Act
        var result = YANLib.Ultimate.YANBool.ToBools(input);

        // Assert
        Empty(result);
    }

    [Fact]
    public void ToBools_ValidEnumerable_ReturnsConvertedBools()
    {
        // Arrange
        IEnumerable<object?> input = new List<object?> { "true", 0, "false" };

        // Act
        var result = YANLib.Ultimate.YANBool.ToBools(input, true);

        // Assert
        Equal([true, false, false], result!);
    }

    [Fact]
    public void ToBools_InvalidEnumerableWithDefault_ReturnsDefaultValues()
    {
        // Arrange
        IEnumerable<object?> input = new List<object?> { "invalid", null };

        // Act
        var result = YANLib.Ultimate.YANBool.ToBools(input, false);

        // Assert
        Equal([false, false], result!);
    }

    [Fact]
    public void GenerateRandomBools_WithPositiveSize_ReturnsCollection()
    {
        // Arrange
        var size = 5;

        // Act
        var result = GenerateRandomBools(size);

        // Assert
        Equal(5, result.Count());
        All(result, x => IsType<bool>(x));
    }

    [Fact]
    public void GenerateRandomBools_WithInvalidSize_ReturnsEmptyCollection()
    {
        // Arrange
        var size = "invalid";

        // Act
        var result = GenerateRandomBools(size);

        // Assert
        Empty(result);
    }

    [Fact]
    public void GenerateRandomBools_WithNegativeSize_ReturnsEmptyCollection()
    {
        // Arrange
        var size = -1;

        // Act
        var result = GenerateRandomBools(size);

        // Assert
        Empty(result);
    }

    [Fact]
    public void GenerateRandomBools_WithNullSize_ReturnsEmptyCollection()
    {
        // Arrange
        object? size = null;

        // Act
        var result = GenerateRandomBools(size);

        // Assert
        Empty(result);
    }
}
