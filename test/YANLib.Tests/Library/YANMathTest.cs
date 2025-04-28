namespace YANLib.Tests.Library;

public partial class YANMathTest
{
    #region Min

    [Fact]
    public void Min_NullCollection_ReturnsDefault_Math()
    {
        // Arrange
        IEnumerable<int?>? input = null;

        // Act
        var result = input.Min<int>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Min_EmptyCollection_ReturnsDefault_Math()
    {
        // Arrange
        var input = new List<int?>();

        // Act
        var result = input.Min<int>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Min_CollectionWithValues_ReturnsMinValue_Math()
    {
        // Arrange
        var input = new List<int?> { 5, 2, 8, 1, 9 };

        // Act
        int? result = input.Min<int>();

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void Min_CollectionWithNullValues_IgnoresNullValues_Math()
    {
        // Arrange
        var input = new List<int?> { 5, null, 8, 1, null };

        // Act
        int? result = input.Min<int>();

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void Min_ParamsOverload_ReturnsMinValue_Math()
    {
        // Act
        int? result = YANMath.Min(5, 2, 8, 1, 9);

        // Assert
        Assert.Equal(1, result);
    }

    #endregion

    #region Max

    [Fact]
    public void Max_NullCollection_ReturnsDefault_Math()
    {
        // Arrange
        IEnumerable<int?>? input = null;

        // Act
        var result = input.Max<int>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Max_EmptyCollection_ReturnsDefault_Math()
    {
        // Arrange
        var input = new List<int?>();

        // Act
        var result = input.Max<int>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Max_CollectionWithValues_ReturnsMaxValue_Math()
    {
        // Arrange
        var input = new List<int?> { 5, 2, 8, 1, 9 };

        // Act
        int? result = input.Max<int>();

        // Assert
        Assert.Equal(9, result);
    }

    [Fact]
    public void Max_CollectionWithNullValues_IgnoresNullValues_Math()
    {
        // Arrange
        var input = new List<int?> { 5, null, 8, 1, null };

        // Act
        int? result = input.Max<int>();

        // Assert
        Assert.Equal(8, result);
    }

    [Fact]
    public void Max_ParamsOverload_ReturnsMaxValue_Math()
    {
        // Act
        int? result = YANMath.Max(5, 2, 8, 1, 9);

        // Assert
        Assert.Equal(9, result);
    }

    #endregion

    #region Average

    [Fact]
    public void Average_NullCollection_ReturnsDefault_Math()
    {
        // Arrange
        IEnumerable<int?>? input = null;

        // Act
        var result = input.Average<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Average_EmptyCollection_ReturnsDefault_Math()
    {
        // Arrange
        var input = new List<int?>();

        // Act
        var result = input.Average<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Average_CollectionWithValues_ReturnsAverage_Math()
    {
        // Arrange
        var input = new List<int?> { 2, 4, 6, 8, 10 };

        // Act
        double? result = input.Average<double>();

        // Assert
        Assert.Equal(6.0, result);
    }

    [Fact]
    public void Average_CollectionWithNullValues_IgnoresNullValues_Math()
    {
        // Arrange
        var input = new List<int?> { 2, null, 6, 8, null };

        // Act
        double? result = input.Average<double>();

        // Assert
        Assert.Equal(5.333333333333333, result.Value, 15);
    }

    [Fact]
    public void Average_ParamsOverload_ReturnsAverage_Math()
    {
        // Act
        double? result = YANMath.Average<double>(2, 4, 6, 8, 10);

        // Assert
        Assert.Equal(6.0, result);
    }

    #endregion

    #region Sum

    [Fact]
    public void Sum_NullCollection_ReturnsDefault_Math()
    {
        // Arrange
        IEnumerable<int?>? input = null;

        // Act
        var result = input.Sum<int>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Sum_EmptyCollection_ReturnsDefault_Math()
    {
        // Arrange
        var input = new List<int?>();

        // Act
        var result = input.Sum<int>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Sum_CollectionWithValues_ReturnsSum_Math()
    {
        // Arrange
        var input = new List<int?> { 2, 4, 6, 8, 10 };

        // Act
        int? result = input.Sum<int>();

        // Assert
        Assert.Equal(30, result);
    }

    [Fact]
    public void Sum_CollectionWithNullValues_IgnoresNullValues_Math()
    {
        // Arrange
        var input = new List<int?> { 2, null, 6, 8, null };

        // Act
        int? result = input.Sum<int>();

        // Assert
        Assert.Equal(16, result);
    }

    [Fact]
    public void Sum_ParamsOverload_ReturnsSum_Math()
    {
        // Act
        int? result = YANMath.Sum(2, 4, 6, 8, 10);

        // Assert
        Assert.Equal(30, result);
    }

    #endregion

    #region Truncate

    [Fact]
    public void Truncate_NullValue_ReturnsDefault_Math()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Truncate<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Truncate_PositiveDecimal_ReturnsTruncatedValue_Math()
    {
        // Arrange
        double? input = 3.75;

        // Act
        double? result = input.Truncate<double>();

        // Assert
        Assert.Equal(3.0, result);
    }

    [Fact]
    public void Truncate_NegativeDecimal_ReturnsTruncatedValue_Math()
    {
        // Arrange
        double? input = -3.75;

        // Act
        double? result = input.Truncate<double>();

        // Assert
        Assert.Equal(-3.0, result);
    }

    #endregion

    #region Ceiling

    [Fact]
    public void Ceiling_NullValue_ReturnsDefault_Math()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Ceiling<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Ceiling_PositiveDecimal_ReturnsCeilingValue_Math()
    {
        // Arrange
        double? input = 3.75;

        // Act
        double? result = input.Ceiling<double>();

        // Assert
        Assert.Equal(4.0, result);
    }

    [Fact]
    public void Ceiling_NegativeDecimal_ReturnsCeilingValue_Math()
    {
        // Arrange
        double? input = -3.75;

        // Act
        double? result = input.Ceiling<double>();

        // Assert
        Assert.Equal(-3.0, result);
    }

    #endregion

    #region Floor

    [Fact]
    public void Floor_NullValue_ReturnsDefault_Math()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Floor<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Floor_PositiveDecimal_ReturnsFloorValue_Math()
    {
        // Arrange
        double? input = 3.75;

        // Act
        double? result = input.Floor<double>();

        // Assert
        Assert.Equal(3.0, result);
    }

    [Fact]
    public void Floor_NegativeDecimal_ReturnsFloorValue_Math()
    {
        // Arrange
        double? input = -3.75;

        // Act
        double? result = input.Floor<double>();

        // Assert
        Assert.Equal(-4.0, result);
    }

    #endregion

    #region Round

    [Fact]
    public void Round_NullValue_ReturnsDefault_Math()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Round<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Round_PositiveDecimalNoDigits_ReturnsRoundedValue_Math()
    {
        // Arrange
        double? input = 3.75;

        // Act
        double? result = input.Round<double>();

        // Assert
        Assert.Equal(4.0, result);
    }

    [Fact]
    public void Round_NegativeDecimalNoDigits_ReturnsRoundedValue_Math()
    {
        // Arrange
        double? input = -3.75;

        // Act
        double? result = input.Round<double>();

        // Assert
        Assert.Equal(-4.0, result);
    }

    [Fact]
    public void Round_PositiveDecimalWithDigits_ReturnsRoundedValue_Math()
    {
        // Arrange
        double? input = 3.14159;

        // Act
        double? result = input.Round<double>(2);

        // Assert
        Assert.Equal(3.14, result);
    }

    [Fact]
    public void Round_WithMidpointRoundingToEven_ReturnsRoundedValue_Math()
    {
        // Arrange
        double? input = 2.5;

        // Act
        double? result = input.Round<double>(0, MidpointRounding.ToEven);

        // Assert
        Assert.Equal(2.0, result);
    }

    #endregion

    #region Sqrt

    [Fact]
    public void Sqrt_NullValue_ReturnsDefault_Math()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Sqrt<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Sqrt_PositiveValue_ReturnsSqrtValue_Math()
    {
        // Arrange
        double? input = 16.0;

        // Act
        double? result = input.Sqrt<double>();

        // Assert
        Assert.Equal(4.0, result);
    }

    [Fact]
    public void Sqrt_ZeroValue_ReturnsZero_Math()
    {
        // Arrange
        double? input = 0.0;

        // Act
        double? result = input.Sqrt<double>();

        // Assert
        Assert.Equal(0.0, result);
    }

    #endregion

    #region Pow

    [Fact]
    public void Pow_NullValue_ReturnsDefault_Math()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Pow<double>(2);

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Pow_NullPower_ReturnsDefault_Math()
    {
        // Arrange
        double? input = 2.0;

        // Act
        var result = input.Pow<double>(null);

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Pow_PositiveValueAndPower_ReturnsPowValue_Math()
    {
        // Arrange
        double? input = 2.0;

        // Act
        double? result = input.Pow<double>(3);

        // Assert
        Assert.Equal(8.0, result);
    }

    [Fact]
    public void Pow_ZeroValuePositivePower_ReturnsZero_Math()
    {
        // Arrange
        double? input = 0.0;

        // Act
        double? result = input.Pow<double>(3);

        // Assert
        Assert.Equal(0.0, result);
    }

    #endregion

    #region Abs

    [Fact]
    public void Abs_NullValue_ReturnsDefault_Math()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Abs<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Abs_PositiveValue_ReturnsSameValue_Math()
    {
        // Arrange
        double? input = 5.0;

        // Act
        double? result = input.Abs<double>();

        // Assert
        Assert.Equal(5.0, result);
    }

    [Fact]
    public void Abs_NegativeValue_ReturnsPositiveValue_Math()
    {
        // Arrange
        double? input = -5.0;

        // Act
        double? result = input.Abs<double>();

        // Assert
        Assert.Equal(5.0, result);
    }

    [Fact]
    public void Abs_ZeroValue_ReturnsZero_Math()
    {
        // Arrange
        double? input = 0.0;

        // Act
        double? result = input.Abs<double>();

        // Assert
        Assert.Equal(0.0, result);
    }

    #endregion

    #region Log

    [Fact]
    public void Log_NullValue_ReturnsDefault_Math()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Log<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Log_PositiveValueNoBase_ReturnsNaturalLog_Math()
    {
        // Arrange
        double? input = Math.E;

        // Act
        double? result = input.Log<double>();

        // Assert
        Assert.Equal(1.0, result);
    }

    [Fact]
    public void Log_PositiveValueWithBase_ReturnsLogWithBase_Math()
    {
        // Arrange
        double? input = 100.0;

        // Act
        double? result = input.Log<double>(10);

        // Assert
        Assert.Equal(2.0, result);
    }

    #endregion

    #region Log10

    [Fact]
    public void Log10_NullValue_ReturnsDefault_Math()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Log10<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Log10_PositiveValue_ReturnsLog10Value_Math()
    {
        // Arrange
        double? input = 100.0;

        // Act
        double? result = input.Log10<double>();

        // Assert
        Assert.Equal(2.0, result);
    }

    #endregion

    #region Log2

    [Fact]
    public void Log2_NullValue_ReturnsDefault_Math()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Log2<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Log2_PositiveValue_ReturnsLog2Value_Math()
    {
        // Arrange
        double? input = 8.0;

        // Act
        double? result = input.Log2<double>();

        // Assert
        Assert.Equal(3.0, result);
    }

    #endregion

    #region Sin

    [Fact]
    public void Sin_NullValue_ReturnsDefault_Math()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Sin<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Sin_ZeroValue_ReturnsZero_Math()
    {
        // Arrange
        double? input = 0.0;

        // Act
        double? result = input.Sin<double>();

        // Assert
        Assert.Equal(0.0, result);
    }

    [Fact]
    public void Sin_PiHalfValue_ReturnsOne_Math()
    {
        // Arrange
        double? input = Math.PI / 2;

        // Act
        double? result = input.Sin<double>();

        // Assert
        Assert.Equal(1.0, result.Value, 15);
    }

    #endregion

    #region Cos

    [Fact]
    public void Cos_NullValue_ReturnsDefault_Math()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Cos<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Cos_ZeroValue_ReturnsOne_Math()
    {
        // Arrange
        double? input = 0.0;

        // Act
        double? result = input.Cos<double>();

        // Assert
        Assert.Equal(1.0, result);
    }

    [Fact]
    public void Cos_PiValue_ReturnsMinusOne_Math()
    {
        // Arrange
        double? input = Math.PI;

        // Act
        double? result = input.Cos<double>();

        // Assert
        Assert.Equal(-1.0, result.Value, 15);
    }

    #endregion

    #region Tan

    [Fact]
    public void Tan_NullValue_ReturnsDefault_Math()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Tan<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Tan_ZeroValue_ReturnsZero_Math()
    {
        // Arrange
        double? input = 0.0;

        // Act
        double? result = input.Tan<double>();

        // Assert
        Assert.Equal(0.0, result);
    }

    [Fact]
    public void Tan_PiQuarterValue_ReturnsOne_Math()
    {
        // Arrange
        double? input = Math.PI / 4;

        // Act
        double? result = input.Tan<double>();

        // Assert
        Assert.Equal(1.0, result.Value, 15);
    }

    #endregion

    #region Asin

    [Fact]
    public void Asin_NullValue_ReturnsDefault_Math()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Asin<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Asin_ZeroValue_ReturnsZero_Math()
    {
        // Arrange
        double? input = 0.0;

        // Act
        double? result = input.Asin<double>();

        // Assert
        Assert.Equal(0.0, result);
    }

    [Fact]
    public void Asin_OneValue_ReturnsPiHalf_Math()
    {
        // Arrange
        double? input = 1.0;

        // Act
        double? result = input.Asin<double>();

        // Assert
        Assert.Equal(Math.PI / 2, result);
    }

    #endregion

    #region Acos

    [Fact]
    public void Acos_NullValue_ReturnsDefault_Math()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Acos<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Acos_OneValue_ReturnsZero_Math()
    {
        // Arrange
        double? input = 1.0;

        // Act
        double? result = input.Acos<double>();

        // Assert
        Assert.Equal(0.0, result);
    }

    [Fact]
    public void Acos_MinusOneValue_ReturnsPi_Math()
    {
        // Arrange
        double? input = -1.0;

        // Act
        double? result = input.Acos<double>();

        // Assert
        Assert.Equal(Math.PI, result);
    }

    #endregion

    #region Atan

    [Fact]
    public void Atan_NullValue_ReturnsDefault_Math()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Atan<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Atan_ZeroValue_ReturnsZero_Math()
    {
        // Arrange
        double? input = 0.0;

        // Act
        double? result = input.Atan<double>();

        // Assert
        Assert.Equal(0.0, result);
    }

    [Fact]
    public void Atan_OneValue_ReturnsPiQuarter_Math()
    {
        // Arrange
        double? input = 1.0;

        // Act
        double? result = input.Atan<double>();

        // Assert
        Assert.Equal(Math.PI / 4, result);
    }

    #endregion

    #region Cbrt

    [Fact]
    public void Cbrt_NullValue_ReturnsDefault_Math()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Cbrt<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Cbrt_PositiveValue_ReturnsCubeRoot_Math()
    {
        // Arrange
        double? input = 27.0;

        // Act
        double? result = input.Cbrt<double>();

        // Assert
        Assert.Equal(3.0, result);
    }

    [Fact]
    public void Cbrt_NegativeValue_ReturnsNegativeCubeRoot_Math()
    {
        // Arrange
        double? input = -27.0;

        // Act
        double? result = input.Cbrt<double>();

        // Assert
        Assert.Equal(-3.0, result);
    }

    #endregion

    #region Exp

    [Fact]
    public void Exp_NullValue_ReturnsDefault_Math()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Exp<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Exp_ZeroValue_ReturnsOne_Math()
    {
        // Arrange
        double? input = 0.0;

        // Act
        double? result = input.Exp<double>();

        // Assert
        Assert.Equal(1.0, result);
    }

    [Fact]
    public void Exp_OneValue_ReturnsE_Math()
    {
        // Arrange
        double? input = 1.0;

        // Act
        double? result = input.Exp<double>();

        // Assert
        Assert.Equal(Math.E, result);
    }

    #endregion

    #region Exp2

    [Fact]
    public void Exp2_NullValue_ReturnsDefault_Math()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Exp2<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Exp2_ZeroValue_ReturnsOne_Math()
    {
        // Arrange
        double? input = 0.0;

        // Act
        double? result = input.Exp2<double>();

        // Assert
        Assert.Equal(1.0, result);
    }

    [Fact]
    public void Exp2_PositiveValue_ReturnsPowerOfTwo_Math()
    {
        // Arrange
        double? input = 3.0;

        // Act
        double? result = input.Exp2<double>();

        // Assert
        Assert.Equal(8.0, result);
    }

    #endregion

    #region ILogB

    [Fact]
    public void ILogB_NullValue_ReturnsDefault_Math()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.ILogB<int>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void ILogB_PowerOfTwo_ReturnsExponent_Math()
    {
        // Arrange
        double? input = 8.0;

        // Act
        int? result = input.ILogB<int>();

        // Assert
        Assert.Equal(3, result);
    }

    #endregion
}
