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
        var result = input.Min<int>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Min_EmptyCollection_ReturnsDefault_MathGeneric()
    {
        // Arrange
        var input = new List<object?>();

        // Act
        var result = input.Min<int>();

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

    [Fact]
    public void Min_AllNullObjectCollection_ReturnsDefault_MathGeneric()
    {
        // Arrange
        var input = new List<object?> { null, null };

        // Act
        var result = input.Min<int>();

        // Assert
        Assert.Equal(0, result);
    }

    #endregion

    #region Max

    [Fact]
    public void Max_NullCollection_ReturnsDefault_MathGeneric()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Max<int>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Max_EmptyCollection_ReturnsDefault_MathGeneric()
    {
        // Arrange
        var input = new List<object?>();

        // Act
        var result = input.Max<int>();

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

    [Fact]
    public void Max_AllNullObjectParams_ReturnsDefault_MathGeneric()
    {
        // Act
        var result = YANMath.Max<double>(null, null);

        // Assert
        Assert.Equal(0.0, result);
    }

    [Fact]
    public void Max_DateTimeObjects_KeepMillisecondsAndKind_MathGeneric()
    {
        // Arrange
        object earlier = new DateTime(2024, 1, 1, 10, 0, 0, 123, DateTimeKind.Local);
        object later = new DateTime(2024, 1, 1, 10, 0, 0, 456, DateTimeKind.Local);

        // Act
        var max = YANMath.Max<DateTime>(earlier, later);

        // Assert
        Assert.Equal(later, max);
        Assert.Equal(DateTimeKind.Local, max.Kind);
    }

    #endregion

    #region Average

    [Fact]
    public void Average_NullCollection_ReturnsDefault_MathGeneric()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Average<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Average_EmptyCollection_ReturnsDefault_MathGeneric()
    {
        // Arrange
        var input = new List<object?>();

        // Act
        var result = input.Average<double>();

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

    [Fact]
    public void Average_AllNullObjectCollection_ReturnsDefault_MathGeneric()
    {
        // Arrange
        var input = new List<object?> { null, null };

        // Act
        var result = input.Average<decimal>();

        // Assert
        Assert.Equal(0m, result);
    }

    [Fact]
    public void Average_AllNullObjectParams_ReturnsNull_MathGeneric()
    {
        // Act
        var result = YANMath.Average<int?>(null, null);

        // Assert
        Assert.Null(result);
    }

    #endregion

    #region Sum

    [Fact]
    public void Sum_NullCollection_ReturnsDefault_MathGeneric()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Sum<int>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Sum_EmptyCollection_ReturnsDefault_MathGeneric()
    {
        // Arrange
        var input = new List<object?>();

        // Act
        var result = input.Sum<int>();

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

    [Fact]
    public void Sum_LongObjects_AreExact_MathGeneric()
    {
        // Act
        var result = YANMath.Sum<long>(9007199254740993L, 0);

        // Assert
        Assert.Equal(9007199254740993L, result);
    }

    [Fact]
    public void Sum_DecimalTargetFromFloats_UsesShortestDigits_MathGeneric()
    {
        // Act
        var result = YANMath.Sum<decimal>(0.1f, 0.2f);

        // Assert
        Assert.Equal(0.3m, result);
    }

    [Fact]
    public void Sum_UnparsableStrings_CountAsZero_MathGeneric()
    {
        // Act
        var result = YANMath.Sum<int>("5-", "(5)", 2);

        // Assert
        Assert.Equal(2, result);
    }

    [Fact]
    public void Sum_WholeDoubleAndFloat_AreExact_MathGeneric()
    {
        // Act
        var result = YANMath.Sum<long>(Math.Pow(2, 60), 1L);
        var floatResult = YANMath.Sum<int>(123456792f);

        // Assert
        Assert.Equal(1152921504606846977L, result);
        Assert.Equal(123456792, floatResult);
    }

    #endregion

    #region Truncate

    [Fact]
    public void Truncate_NullValue_ReturnsDefault_MathGeneric()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Truncate<double>();

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

    [Fact]
    public void Truncate_WholeDoubleAbove2Pow53_IsExact_MathGeneric()
    {
        // Arrange
        object? input = Math.Pow(2, 60);
        object? unsignedInput = 9223372036854775808.0;

        // Act
        var result = input.Truncate<long>();
        var unsignedResult = unsignedInput.Truncate<ulong>();
        var decimalResult = input.Truncate<decimal>();
        var largeDecimalResult = ((object?)1e23).Truncate<decimal>();

        // Assert
        Assert.Equal(1152921504606846976L, result);
        Assert.Equal(9223372036854775808UL, unsignedResult);
        Assert.Equal(1152921504606846976m, decimalResult);
        Assert.Equal(99999999999999991611392m, largeDecimalResult);
    }

    [Fact]
    public void Truncate_WholeFloatAbove2Pow24_IsExact_MathGeneric()
    {
        // Arrange
        object? input = 123456792f;

        // Act
        var result = input.Truncate<int>();
        var decimalResult = input.Truncate<decimal>();
        var fraction = ((object?)0.1f).Round<decimal>(5);

        // Assert
        Assert.Equal(123456792, result);
        Assert.Equal(123456792m, decimalResult);
        Assert.Equal(0.1m, fraction);
    }

    #endregion

    #region Ceiling

    [Fact]
    public void Ceiling_NullValue_ReturnsDefault_MathGeneric()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Ceiling<double>();

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

    [Fact]
    public void Ceiling_TinyPositiveValue_ReturnsOne_MathGeneric()
    {
        // Act
        var result = ((object?)1e-29).Ceiling<int>();
        var epsilonResult = ((object?)double.Epsilon).Ceiling<int>();
        var decimalResult = ((object?)1e-30).Ceiling<decimal>();
        var stringResult = ((object?)"1e-29").Ceiling<int>();

        // Assert
        Assert.Equal(1, result);
        Assert.Equal(1, epsilonResult);
        Assert.Equal(1m, decimalResult);
        Assert.Equal(1, stringResult);
    }

    #endregion

    #region Floor

    [Fact]
    public void Floor_NullValue_ReturnsDefault_MathGeneric()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Floor<double>();

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

    [Fact]
    public void Floor_TinyNegativeValue_ReturnsMinusOne_MathGeneric()
    {
        // Act
        var result = ((object?)-1e-29).Floor<int>();
        var nullableResult = ((object?)-1e-30).Floor<long?>();
        var stringResult = ((object?)"-1E-30").Floor<int>();

        // Assert
        Assert.Equal(-1, result);
        Assert.Equal(-1L, nullableResult);
        Assert.Equal(-1, stringResult);
    }

    #endregion

    #region Round

    [Fact]
    public void Round_NullValue_ReturnsDefault_MathGeneric()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Round<double>();

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

    [Fact]
    public void Round_DecimalTargetFromDouble_UsesShortestDigits_MathGeneric()
    {
        // Arrange
        object? input = 1.005;

        // Act
        var result = input.Round<decimal>(2);

        // Assert
        Assert.Equal(1.01m, result);
    }

    [Fact]
    public void Round_MoreThan15DigitsObject_DoesNotThrow_MathGeneric()
    {
        // Arrange
        object? input = 1.5;

        // Act
        var doubleResult = input.Round<double>(16);
        var decimalResult = input.Round<decimal>(20);

        // Assert
        Assert.Equal(1.5, doubleResult);
        Assert.Equal(1.5m, decimalResult);
    }

    [Fact]
    public void Round_WholeDoubleAndFloatExtension_IsExact_MathGeneric()
    {
        // Act
        var result = Math.Pow(2, 60).Round<long>();
        var floatResult = 123456792f.Round<int>();

        // Assert
        Assert.Equal(1152921504606846976L, result);
        Assert.Equal(123456792, floatResult);
    }

    [Fact]
    public void Round_TinyValueDirected_KeepsTheStep_MathGeneric()
    {
        // Act
        var up = ((object?)1e-30).Round<decimal>(2, MidpointRounding.ToPositiveInfinity);
        var down = ((object?)-1e-30).Round<int>(null, MidpointRounding.ToNegativeInfinity);
        var toZero = ((object?)1.9999999999999998e-13).Round<decimal>(15, MidpointRounding.ToZero);
        var smallest = ((object?)1e-28).Round<decimal>(28);

        // Assert
        Assert.Equal(0.01m, up);
        Assert.Equal(-1, down);
        Assert.Equal(0.000000000000199m, toZero);
        Assert.Equal(0.0000000000000000000000000001m, smallest);
    }

    [Fact]
    public void Round_FractionalDoubleWithoutDigits_MatchesMathRound_MathGeneric()
    {
        // pin: Round without digits rounds a double in double and converts the whole result exactly, without the text round trip
        // Arrange
        object?[] inputs = [2.5, -2.5, 0.49999999999999994, 2.4999999999999996, -1.5f, 123.45678901234567];
        MidpointRounding[] modes = [MidpointRounding.ToEven, MidpointRounding.AwayFromZero, MidpointRounding.ToZero, MidpointRounding.ToNegativeInfinity, MidpointRounding.ToPositiveInfinity];

        foreach (var input in inputs)
        {
            foreach (var mode in modes)
            {
                // Act
                var expected = Math.Round(Convert.ToDouble(input), mode);
                var result = input.Round<long>(null, mode);
                var decimalResult = input.Round<decimal?>(null, mode);

                // Assert
                Assert.Equal((long)expected, result);
                Assert.Equal((decimal)expected, decimalResult);
            }
        }
    }

    #endregion

    #region Sqrt

    [Fact]
    public void Sqrt_NullValue_ReturnsDefault_MathGeneric()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Sqrt<double>();

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
        var result = input.Pow<double>(2);

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Pow_NullPower_ReturnsDefault_MathGeneric()
    {
        // Arrange
        object? input = 2.0;

        // Act
        var result = input.Pow<double>(null);

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

    [Fact]
    public void Pow_ZeroValuePositivePower_ReturnsZero_MathGeneric()
    {
        // Arrange
        object? input = 0.0;

        // Act
        double? result = input.Pow<double>(3);

        // Assert
        Assert.Equal(0.0, result);
    }

    [Fact]
    public void Pow_DecimalTargetNegativeExponent_IsExact_MathGeneric()
    {
        // Arrange
        object? input = 3;

        // Act
        var result = input.Pow<decimal>(-1);

        // Assert
        Assert.Equal(1m / 3m, result);
    }

    #endregion

    #region Abs

    [Fact]
    public void Abs_NullValue_ReturnsDefault_MathGeneric()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Abs<double>();

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

    [Fact]
    public void Abs_ZeroValue_ReturnsZero_MathGeneric()
    {
        // Arrange
        object? input = 0.0;

        // Act
        double? result = input.Abs<double>();

        // Assert
        Assert.Equal(0.0, result);
    }

    [Fact]
    public void Abs_IntMinValueObject_ReturnsDefault_MathGeneric()
    {
        // Arrange
        object? input = int.MinValue;

        // Act
        var result = input.Abs<int>();
        var nullableResult = input.Abs<int?>();
        var longResult = input.Abs<long>();

        // Assert
        Assert.Equal(0, result);
        Assert.Null(nullableResult);
        Assert.Equal(2147483648L, longResult);
    }

    #endregion

    #region Sin

    [Fact]
    public void Sin_NullValue_ReturnsDefault_MathGeneric()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Sin<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Sin_ZeroValue_ReturnsZero_MathGeneric()
    {
        // Arrange
        object? input = 0.0;

        // Act
        double? result = input.Sin<double>();

        // Assert
        Assert.Equal(0.0, result);
    }

    [Fact]
    public void Sin_PiHalfValue_ReturnsOne_MathGeneric()
    {
        // Arrange
        object? input = Math.PI / 2;

        // Act
        double? result = input.Sin<double>();

        // Assert
        Assert.Equal(1.0, result.Value, 15);
    }

    [Fact]
    public void Sin_StringValue_ConvertsAndCalculatesSin_MathGeneric()
    {
        // Arrange
        object? input = "1.5707963267948966";

        // Act
        double? result = input.Sin<double>();

        // Assert
        Assert.Equal(1.0, result.Value, 15);
    }

    #endregion

    #region Cos

    [Fact]
    public void Cos_NullValue_ReturnsDefault_MathGeneric()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Cos<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Cos_ZeroValue_ReturnsOne_MathGeneric()
    {
        // Arrange
        object? input = 0.0;

        // Act
        double? result = input.Cos<double>();

        // Assert
        Assert.Equal(1.0, result);
    }

    [Fact]
    public void Cos_PiValue_ReturnsMinusOne_MathGeneric()
    {
        // Arrange
        object? input = Math.PI;

        // Act
        double? result = input.Cos<double>();

        // Assert
        Assert.Equal(-1.0, result.Value, 15);
    }

    [Fact]
    public void Cos_StringValue_ConvertsAndCalculatesCos_MathGeneric()
    {
        // Arrange
        object? input = "3.141592653589793";

        // Act
        double? result = input.Cos<double>();

        // Assert
        Assert.Equal(-1.0, result.Value, 15);
    }

    #endregion

    #region Tan

    [Fact]
    public void Tan_NullValue_ReturnsDefault_MathGeneric()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Tan<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Tan_ZeroValue_ReturnsZero_MathGeneric()
    {
        // Arrange
        object? input = 0.0;

        // Act
        double? result = input.Tan<double>();

        // Assert
        Assert.Equal(0.0, result);
    }

    [Fact]
    public void Tan_PiQuarterValue_ReturnsOne_MathGeneric()
    {
        // Arrange
        object? input = Math.PI / 4;

        // Act
        double? result = input.Tan<double>();

        // Assert
        Assert.Equal(1.0, result.Value, 15);
    }

    [Fact]
    public void Tan_StringValue_ConvertsAndCalculatesTan_MathGeneric()
    {
        // Arrange
        object? input = "0.7853981633974483";

        // Act
        double? result = input.Tan<double>();

        // Assert
        Assert.Equal(1.0, result.Value, 15);
    }

    #endregion

    #region Asin

    [Fact]
    public void Asin_NullValue_ReturnsDefault_MathGeneric()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Asin<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Asin_ZeroValue_ReturnsZero_MathGeneric()
    {
        // Arrange
        object? input = 0.0;

        // Act
        double? result = input.Asin<double>();

        // Assert
        Assert.Equal(0.0, result);
    }

    [Fact]
    public void Asin_OneValue_ReturnsPiHalf_MathGeneric()
    {
        // Arrange
        object? input = 1.0;

        // Act
        double? result = input.Asin<double>();

        // Assert
        Assert.Equal(Math.PI / 2, result);
    }

    [Fact]
    public void Asin_StringValue_ConvertsAndCalculatesAsin_MathGeneric()
    {
        // Arrange
        object? input = "1.0";

        // Act
        double? result = input.Asin<double>();

        // Assert
        Assert.Equal(Math.PI / 2, result);
    }

    #endregion

    #region Acos

    [Fact]
    public void Acos_NullValue_ReturnsDefault_MathGeneric()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Acos<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Acos_OneValue_ReturnsZero_MathGeneric()
    {
        // Arrange
        object? input = 1.0;

        // Act
        double? result = input.Acos<double>();

        // Assert
        Assert.Equal(0.0, result);
    }

    [Fact]
    public void Acos_MinusOneValue_ReturnsPi_MathGeneric()
    {
        // Arrange
        object? input = -1.0;

        // Act
        double? result = input.Acos<double>();

        // Assert
        Assert.Equal(Math.PI, result);
    }

    [Fact]
    public void Acos_StringValue_ConvertsAndCalculatesAcos_MathGeneric()
    {
        // Arrange
        object? input = "-1.0";

        // Act
        double? result = input.Acos<double>();

        // Assert
        Assert.Equal(Math.PI, result);
    }

    #endregion

    #region Atan

    [Fact]
    public void Atan_NullValue_ReturnsDefault_MathGeneric()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Atan<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Atan_ZeroValue_ReturnsZero_MathGeneric()
    {
        // Arrange
        object? input = 0.0;

        // Act
        double? result = input.Atan<double>();

        // Assert
        Assert.Equal(0.0, result);
    }

    [Fact]
    public void Atan_OneValue_ReturnsPiQuarter_MathGeneric()
    {
        // Arrange
        object? input = 1.0;

        // Act
        double? result = input.Atan<double>();

        // Assert
        Assert.Equal(Math.PI / 4, result);
    }

    [Fact]
    public void Atan_StringValue_ConvertsAndCalculatesAtan_MathGeneric()
    {
        // Arrange
        object? input = "1.0";

        // Act
        double? result = input.Atan<double>();

        // Assert
        Assert.Equal(Math.PI / 4, result);
    }

    #endregion

    #region Cbrt

    [Fact]
    public void Cbrt_NullValue_ReturnsDefault_MathGeneric()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Cbrt<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Cbrt_PositiveValue_ReturnsCubeRoot_MathGeneric()
    {
        // Arrange
        object? input = 27.0;

        // Act
        double? result = input.Cbrt<double>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3.0, result.Value, 15);
    }

    [Fact]
    public void Cbrt_NegativeValue_ReturnsNegativeCubeRoot_MathGeneric()
    {
        // Arrange
        object? input = -27.0;

        // Act
        double? result = input.Cbrt<double>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(-3.0, result.Value, 15);
    }

    [Fact]
    public void Cbrt_StringValue_ConvertsAndCalculatesCbrt_MathGeneric()
    {
        // Arrange
        object? input = "27.0";

        // Act
        double? result = input.Cbrt<double>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3.0, result.Value, 15);
    }

    #endregion

    #region Exp

    [Fact]
    public void Exp_NullValue_ReturnsDefault_MathGeneric()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Exp<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Exp_ZeroValue_ReturnsOne_MathGeneric()
    {
        // Arrange
        object? input = 0.0;

        // Act
        double? result = input.Exp<double>();

        // Assert
        Assert.Equal(1.0, result);
    }

    [Fact]
    public void Exp_OneValue_ReturnsE_MathGeneric()
    {
        // Arrange
        object? input = 1.0;

        // Act
        double? result = input.Exp<double>();

        // Assert
        Assert.Equal(Math.E, result);
    }

    [Fact]
    public void Exp_StringValue_ConvertsAndCalculatesExp_MathGeneric()
    {
        // Arrange
        object? input = "1.0";

        // Act
        double? result = input.Exp<double>();

        // Assert
        Assert.Equal(Math.E, result);
    }

    #endregion

    #region Exp2

    [Fact]
    public void Exp2_NullValue_ReturnsDefault_MathGeneric()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Exp2<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Exp2_ZeroValue_ReturnsOne_MathGeneric()
    {
        // Arrange
        object? input = 0.0;

        // Act
        double? result = input.Exp2<double>();

        // Assert
        Assert.Equal(1.0, result);
    }

    [Fact]
    public void Exp2_PositiveValue_ReturnsPowerOfTwo_MathGeneric()
    {
        // Arrange
        object? input = 3.0;

        // Act
        double? result = input.Exp2<double>();

        // Assert
        Assert.Equal(8.0, result);
    }

    [Fact]
    public void Exp2_StringValue_ConvertsAndCalculatesExp2_MathGeneric()
    {
        // Arrange
        object? input = "3.0";

        // Act
        double? result = input.Exp2<double>();

        // Assert
        Assert.Equal(8.0, result);
    }

    #endregion

    #region Log

    [Fact]
    public void Log_NullValue_ReturnsDefault_MathGeneric()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Log<double>();

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
        var result = input.Log10<double>();

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

    [Fact]
    public void Log10_FractionalValue_ReturnsCorrectValue_MathGeneric()
    {
        // Arrange
        object? input = 0.1;

        // Act
        double? result = input.Log10<double>();

        // Assert
        Assert.Equal(-1.0, result);
    }

    #endregion

    #region Log2

    [Fact]
    public void Log2_NullValue_ReturnsDefault_MathGeneric()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Log2<double>();

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

    [Fact]
    public void Log2_FractionalValue_ReturnsCorrectValue_MathGeneric()
    {
        // Arrange
        object? input = 0.5;

        // Act
        double? result = input.Log2<double>();

        // Assert
        Assert.Equal(-1.0, result);
    }

    [Fact]
    public void Log2_PowerOfTwoObject_IsExact_MathGeneric()
    {
        // Arrange
        object? input = 2147483648L;

        // Act
        var result = input.Log2<double>();

        // Assert
        Assert.Equal(31.0, result);
    }

    #endregion

    #region ILogB

    [Fact]
    public void ILogB_NullValue_ReturnsDefault_MathGeneric()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.ILogB<int>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void ILogB_PowerOfTwo_ReturnsExponent_MathGeneric()
    {
        // Arrange
        object? input = 8.0;

        // Act
        int? result = input.ILogB<int>();

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void ILogB_StringValue_ConvertsAndCalculatesILogB_MathGeneric()
    {
        // Arrange
        object? input = "8.0";

        // Act
        int? result = input.ILogB<int>();

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void ILogB_LargeValue_ReturnsCorrectExponent_MathGeneric()
    {
        // Arrange
        object? input = 1024.0;

        // Act
        int? result = input.ILogB<int>();

        // Assert
        Assert.Equal(10, result);
    }

    #endregion
}
