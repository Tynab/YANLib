namespace YANLib.Tests.Library;

public partial class YANMathTest
{
    #region Min

    [Fact]
    public void Min_NullCollection_ReturnsDefault_MathGeneric()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        int? result = input.Min<int>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Min_EmptyCollection_ReturnsDefault_MathGeneric()
    {
        // Arrange
        var input = new List<object?>();

        // Act
        int? result = input.Min<int>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Min_CollectionWithValues_ReturnsMinValue_MathGeneric()
    {
        // Arrange
        var input = new List<object?> { 5, 2, 8, 1, 9 };

        // Act
        int? result = input.Min<int>();

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void Min_CollectionWithNullValues_IgnoresNullValues_MathGeneric()
    {
        // Arrange
        var input = new List<object?> { 5, null, 8, 1, null };

        // Act
        int? result = input.Min<int>();

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void Min_CollectionWithMixedTypes_ConvertsTypes_MathGeneric()
    {
        // Arrange
        var input = new List<object?> { 5, 2.5, "8", 1, "9" };

        // Act
        int? result = input.Min<int>();

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void Min_ParamsOverload_ReturnsMinValue_MathGeneric()
    {
        // Act
        int? result = YANMath.Min(5, 2, 8, 1, 9);

        // Assert
        Assert.Equal(1, result);
    }

    #endregion

    #region Max

    [Fact]
    public void Max_NullCollection_ReturnsDefault_MathGeneric()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        int? result = input.Max<int>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Max_EmptyCollection_ReturnsDefault_MathGeneric()
    {
        // Arrange
        var input = new List<object?>();

        // Act
        int? result = input.Max<int>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Max_CollectionWithValues_ReturnsMaxValue_MathGeneric()
    {
        // Arrange
        var input = new List<object?> { 5, 2, 8, 1, 9 };

        // Act
        int? result = input.Max<int>();

        // Assert
        Assert.Equal(9, result);
    }

    [Fact]
    public void Max_CollectionWithNullValues_IgnoresNullValues_MathGeneric()
    {
        // Arrange
        var input = new List<object?> { 5, null, 8, 1, null };

        // Act
        int? result = input.Max<int>();

        // Assert
        Assert.Equal(8, result);
    }

    [Fact]
    public void Max_CollectionWithMixedTypes_ConvertsTypes_MathGeneric()
    {
        // Arrange
        var input = new List<object?> { 5, 2.5, "8", 1, "9" };

        // Act
        int? result = input.Max<int>();

        // Assert
        Assert.Equal(9, result);
    }

    [Fact]
    public void Max_ParamsOverload_ReturnsMaxValue_MathGeneric()
    {
        // Act
        int? result = YANMath.Max(5, 2, 8, 1, 9);

        // Assert
        Assert.Equal(9, result);
    }

    #endregion

    #region Average

    [Fact]
    public void Average_NullCollection_ReturnsDefault_MathGeneric()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        double? result = input.Average<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Average_EmptyCollection_ReturnsDefault_MathGeneric()
    {
        // Arrange
        var input = new List<object?>();

        // Act
        double? result = input.Average<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Average_CollectionWithValues_ReturnsAverage_MathGeneric()
    {
        // Arrange
        var input = new List<object?> { 2, 4, 6, 8, 10 };

        // Act
        double? result = input.Average<double>();

        // Assert
        Assert.Equal(6.0, result);
    }

    [Fact]
    public void Average_CollectionWithNullValues_IgnoresNullValues_MathGeneric()
    {
        // Arrange
        var input = new List<object?> { 2, null, 6, 8, null };

        // Act
        double? result = input.Average<double>();

        // Assert
        Assert.Equal(5.333333333333333, result.Value, 15);
    }

    [Fact]
    public void Average_CollectionWithMixedTypes_ConvertsTypes_MathGeneric()
    {
        // Arrange
        var input = new List<object?> { 2, 4.5, "6", 8, "10" };

        // Act
        double? result = input.Average<double>();

        // Assert
        Assert.Equal(6.1, result);
    }

    [Fact]
    public void Average_ParamsOverload_ReturnsAverage_MathGeneric()
    {
        // Act
        double? result = YANMath.Average<double>(2, 4, 6, 8, 10);

        // Assert
        Assert.Equal(6.0, result);
    }

    #endregion

    #region Sum

    [Fact]
    public void Sum_NullCollection_ReturnsDefault_MathGeneric()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        int? result = input.Sum<int>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Sum_EmptyCollection_ReturnsDefault_MathGeneric()
    {
        // Arrange
        var input = new List<object?>();

        // Act
        int? result = input.Sum<int>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Sum_CollectionWithValues_ReturnsSum_MathGeneric()
    {
        // Arrange
        var input = new List<object?> { 2, 4, 6, 8, 10 };

        // Act
        int? result = input.Sum<int>();

        // Assert
        Assert.Equal(30, result);
    }

    [Fact]
    public void Sum_CollectionWithNullValues_IgnoresNullValues_MathGeneric()
    {
        // Arrange
        var input = new List<object?> { 2, null, 6, 8, null };

        // Act
        int? result = input.Sum<int>();

        // Assert
        Assert.Equal(16, result);
    }

    [Fact]
    public void Sum_CollectionWithMixedTypes_ConvertsTypes_MathGeneric()
    {
        // Arrange
        var input = new List<object?> { 2, 4.5, "6", 8, "10" };

        // Act
        int? result = input.Sum<int>();

        // Assert
        Assert.Equal(30, result);
    }

    [Fact]
    public void Sum_ParamsOverload_ReturnsSum_MathGeneric()
    {
        // Act
        int? result = YANMath.Sum(2, 4, 6, 8, 10);

        // Assert
        Assert.Equal(30, result);
    }

    #endregion

    #region Truncate

    [Fact]
    public void Truncate_NullValue_ReturnsDefault_MathGeneric()
    {
        // Arrange
        object? input = null;

        // Act
        double? result = input.Truncate<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Truncate_PositiveDecimal_ReturnsTruncatedValue_MathGeneric()
    {
        // Arrange
        object? input = 3.75;

        // Act
        double? result = input.Truncate<double>();

        // Assert
        Assert.Equal(3.0, result);
    }

    [Fact]
    public void Truncate_NegativeDecimal_ReturnsTruncatedValue_MathGeneric()
    {
        // Arrange
        object? input = -3.75;

        // Act
        double? result = input.Truncate<double>();

        // Assert
        Assert.Equal(-3.0, result);
    }

    [Fact]
    public void Truncate_StringValue_ConvertsAndTruncates_MathGeneric()
    {
        // Arrange
        object? input = "3.75";

        // Act
        double? result = input.Truncate<double>();

        // Assert
        Assert.Equal(3.0, result);
    }

    #endregion

    #region Ceiling

    [Fact]
    public void Ceiling_NullValue_ReturnsDefault_MathGeneric()
    {
        // Arrange
        object? input = null;

        // Act
        double? result = input.Ceiling<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Ceiling_PositiveDecimal_ReturnsCeilingValue_MathGeneric()
    {
        // Arrange
        object? input = 3.75;

        // Act
        double? result = input.Ceiling<double>();

        // Assert
        Assert.Equal(4.0, result);
    }

    [Fact]
    public void Ceiling_NegativeDecimal_ReturnsCeilingValue_MathGeneric()
    {
        // Arrange
        object? input = -3.75;

        // Act
        double? result = input.Ceiling<double>();

        // Assert
        Assert.Equal(-3.0, result);
    }

    [Fact]
    public void Ceiling_StringValue_ConvertsAndCeils_MathGeneric()
    {
        // Arrange
        object? input = "3.75";

        // Act
        double? result = input.Ceiling<double>();

        // Assert
        Assert.Equal(4.0, result);
    }

    #endregion

    #region Floor

    [Fact]
    public void Floor_NullValue_ReturnsDefault_MathGeneric()
    {
        // Arrange
        object? input = null;

        // Act
        double? result = input.Floor<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Floor_PositiveDecimal_ReturnsFloorValue_MathGeneric()
    {
        // Arrange
        object? input = 3.75;

        // Act
        double? result = input.Floor<double>();

        // Assert
        Assert.Equal(3.0, result);
    }

    [Fact]
    public void Floor_NegativeDecimal_ReturnsFloorValue_MathGeneric()
    {
        // Arrange
        object? input = -3.75;

        // Act
        double? result = input.Floor<double>();

        // Assert
        Assert.Equal(-4.0, result);
    }

    [Fact]
    public void Floor_StringValue_ConvertsAndFloors_MathGeneric()
    {
        // Arrange
        object? input = "3.75";

        // Act
        double? result = input.Floor<double>();

        // Assert
        Assert.Equal(3.0, result);
    }

    #endregion

    #region Round

    [Fact]
    public void Round_NullValue_ReturnsDefault_MathGeneric()
    {
        // Arrange
        object? input = null;

        // Act
        double? result = input.Round<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Round_PositiveDecimalNoDigits_ReturnsRoundedValue_MathGeneric()
    {
        // Arrange
        object? input = 3.75;

        // Act
        double? result = input.Round<double>();

        // Assert
        Assert.Equal(4.0, result);
    }

    [Fact]
    public void Round_NegativeDecimalNoDigits_ReturnsRoundedValue_MathGeneric()
    {
        // Arrange
        object? input = -3.75;

        // Act
        double? result = input.Round<double>();

        // Assert
        Assert.Equal(-4.0, result);
    }

    [Fact]
    public void Round_PositiveDecimalWithDigits_ReturnsRoundedValue_MathGeneric()
    {
        // Arrange
        object? input = 3.14159;

        // Act
        double? result = input.Round<double>(2);

        // Assert
        Assert.Equal(3.14, result);
    }

    [Fact]
    public void Round_WithMidpointRoundingToEven_ReturnsRoundedValue_MathGeneric()
    {
        // Arrange
        object? input = 2.5;

        // Act
        double? result = input.Round<double>(0, MidpointRounding.ToEven);

        // Assert
        Assert.Equal(2.0, result);
    }

    [Fact]
    public void Round_StringValue_ConvertsAndRounds_MathGeneric()
    {
        // Arrange
        object? input = "3.75";

        // Act
        double? result = input.Round<double>();

        // Assert
        Assert.Equal(4.0, result);
    }

    #endregion

    #region Sqrt

    [Fact]
    public void Sqrt_NullValue_ReturnsDefault_MathGeneric()
    {
        // Arrange
        object? input = null;

        // Act
        double? result = input.Sqrt<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Sqrt_PositiveValue_ReturnsSqrtValue_MathGeneric()
    {
        // Arrange
        object? input = 16.0;

        // Act
        double? result = input.Sqrt<double>();

        // Assert
        Assert.Equal(4.0, result);
    }

    [Fact]
    public void Sqrt_ZeroValue_ReturnsZero_MathGeneric()
    {
        // Arrange
        object? input = 0.0;

        // Act
        double? result = input.Sqrt<double>();

        // Assert
        Assert.Equal(0.0, result);
    }

    [Fact]
    public void Sqrt_StringValue_ConvertsAndCalculatesSqrt_MathGeneric()
    {
        // Arrange
        object? input = "16.0";

        // Act
        double? result = input.Sqrt<double>();

        // Assert
        Assert.Equal(4.0, result);
    }

    #endregion

    #region Pow

    [Fact]
    public void Pow_NullValue_ReturnsDefault_MathGeneric()
    {
        // Arrange
        object? input = null;

        // Act
        double? result = input.Pow<double>(2);

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Pow_NullPower_ReturnsDefault_MathGeneric()
    {
        // Arrange
        object? input = 2.0;

        // Act
        double? result = input.Pow<double>(null);

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Pow_PositiveValueAndPower_ReturnsPowValue_MathGeneric()
    {
        // Arrange
        object? input = 2.0;

        // Act
        double? result = input.Pow<double>(3);

        // Assert
        Assert.Equal(8.0, result);
    }

    [Fact]
    public void Pow_StringValueAndPower_ConvertsAndCalculatesPow_MathGeneric()
    {
        // Arrange
        object? input = "2.0";

        // Act
        double? result = input.Pow<double>(3);

        // Assert
        Assert.Equal(8.0, result);
    }

    #endregion

    #region Abs

    [Fact]
    public void Abs_NullValue_ReturnsDefault_MathGeneric()
    {
        // Arrange
        object? input = null;

        // Act
        double? result = input.Abs<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Abs_PositiveValue_ReturnsSameValue_MathGeneric()
    {
        // Arrange
        object? input = 5.0;

        // Act
        double? result = input.Abs<double>();

        // Assert
        Assert.Equal(5.0, result);
    }

    [Fact]
    public void Abs_NegativeValue_ReturnsPositiveValue_MathGeneric()
    {
        // Arrange
        object? input = -5.0;

        // Act
        double? result = input.Abs<double>();

        // Assert
        Assert.Equal(5.0, result);
    }

    [Fact]
    public void Abs_StringValue_ConvertsAndCalculatesAbs_MathGeneric()
    {
        // Arrange
        object? input = "-5.0";

        // Act
        double? result = input.Abs<double>();

        // Assert
        Assert.Equal(5.0, result);
    }

    #endregion

    #region Log

    [Fact]
    public void Log_NullValue_ReturnsDefault_MathGeneric()
    {
        // Arrange
        object? input = null;

        // Act
        double? result = input.Log<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Log_PositiveValueNoBase_ReturnsNaturalLog_MathGeneric()
    {
        // Arrange
        object? input = Math.E;

        // Act
        double? result = input.Log<double>();

        // Assert
        Assert.Equal(1.0, result);
    }

    [Fact]
    public void Log_PositiveValueWithBase_ReturnsLogWithBase_MathGeneric()
    {
        // Arrange
        object? input = 100.0;

        // Act
        double? result = input.Log<double>(10);

        // Assert
        Assert.Equal(2.0, result);
    }

    [Fact]
    public void Log_StringValue_ConvertsAndCalculatesLog_MathGeneric()
    {
        // Arrange
        object? input = "100.0";

        // Act
        double? result = input.Log<double>(10);

        // Assert
        Assert.Equal(2.0, result);
    }

    #endregion

    #region Log10

    [Fact]
    public void Log10_NullValue_ReturnsDefault_MathGeneric()
    {
        // Arrange
        object? input = null;

        // Act
        double? result = input.Log10<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Log10_PositiveValue_ReturnsLog10Value_MathGeneric()
    {
        // Arrange
        object? input = 100.0;

        // Act
        double? result = input.Log10<double>();

        // Assert
        Assert.Equal(2.0, result);
    }

    [Fact]
    public void Log10_StringValue_ConvertsAndCalculatesLog10_MathGeneric()
    {
        // Arrange
        object? input = "100.0";

        // Act
        double? result = input.Log10<double>();

        // Assert
        Assert.Equal(2.0, result);
    }

    #endregion

    #region Log2

    [Fact]
    public void Log2_NullValue_ReturnsDefault_MathGeneric()
    {
        // Arrange
        object? input = null;

        // Act
        double? result = input.Log2<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Log2_PositiveValue_ReturnsLog2Value_MathGeneric()
    {
        // Arrange
        object? input = 8.0;

        // Act
        double? result = input.Log2<double>();

        // Assert
        Assert.Equal(3.0, result);
    }

    [Fact]
    public void Log2_StringValue_ConvertsAndCalculatesLog2_MathGeneric()
    {
        // Arrange
        object? input = "8.0";

        // Act
        double? result = input.Log2<double>();

        // Assert
        Assert.Equal(3.0, result);
    }

    #endregion
}
