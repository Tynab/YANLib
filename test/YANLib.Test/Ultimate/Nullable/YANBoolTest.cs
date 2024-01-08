using static Xunit.Assert;

namespace YANLib.Test.Ultimate.Nullable;

public sealed class YANBoolTest
{
    [Fact]
    public void ToBools_NullEnumerable_ReturnsEmpty()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = YANLib.Ultimate.Nullable.YANBool.ToBools(input);

        // Assert
        Empty(result);
    }

    [Fact]
    public void ToBools_EmptyEnumerable_ReturnsEmpty()
    {
        // Arrange
        IEnumerable<object?> input = new List<object?>();

        // Act
        var result = YANLib.Ultimate.Nullable.YANBool.ToBools(input);

        // Assert
        Empty(result);
    }

    [Fact]
    public void ToBools_ValidEnumerableWithNullDefault_ReturnsConvertedNullableBools()
    {
        // Arrange
        IEnumerable<object?> input = new List<object?> { "true", 0, "false" };

        // Act
        var result = YANLib.Ultimate.Nullable.YANBool.ToBools(input, null);

        // Assert
        Equal(new bool?[] { true, false, false }, result);
    }

    [Fact]
    public void ToBools_InvalidEnumerableWithNonNullDefault_ReturnsDefaultValues()
    {
        // Arrange
        IEnumerable<object?> input = new List<object?> { "invalid", null };

        // Act
        var result = YANLib.Ultimate.Nullable.YANBool.ToBools(input, true);

        // Assert
        Equal([true, false], result!);
    }

    [Fact]
    public void ToBools_CollectionWithMixedValidInvalidValues_ReturnsExpectedNullableBools()
    {
        // Arrange
        ICollection<object?> input = new List<object?> { "true", "invalid", null };

        // Act
        var result = YANLib.Ultimate.Nullable.YANBool.ToBools(input, false);

        // Assert
        Equal([true, false, false], result!);
    }

    [Fact]
    public void ToBools_ArrayWithMixedValidInvalidValues_ReturnsExpectedNullableBools()
    {
        // Arrange
        object?[] input = ["false", "invalid", null];

        // Act
        var result = YANLib.Ultimate.Nullable.YANBool.ToBools(input, true);

        // Assert
        Equal([false, true, false], result!);
    }
}
