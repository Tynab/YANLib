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

    [Fact]
    public void Min_CollectionWithMixedTypes_ConvertsTypes_Math()
    {
        // Arrange
        var input = new List<int?> { 5, 2, 8, 1, 9 };

        // Act
        int? result = input.Min<int>();

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void Min_AllNullCollection_ReturnsDefault_Math()
    {
        // Arrange
        var input = new List<int?> { null, null };

        // Act
        var result = input.Min<int>();

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Min_AllNullNullableCollection_ReturnsNull_Math()
    {
        // Arrange
        IEnumerable<int?> input = [null, null];

        // Act
        var result = YANMath.Min<int?>(input);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Min_DoubleWithNaN_ReturnsNaN_Math()
    {
        // Act
        var result = YANMath.Min(1.0, double.NaN, -1.0);

        // Assert
        Assert.True(double.IsNaN(result));
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

    [Fact]
    public void Max_CollectionWithMixedTypes_ConvertsTypes_Math()
    {
        // Arrange
        var input = new List<int?> { 5, 2, 8, 1, 9 };

        // Act
        int? result = input.Max<int>();

        // Assert
        Assert.Equal(9, result);
    }

    [Fact]
    public void Max_AllNullCollection_ReturnsDefault_Math()
    {
        // Arrange
        var input = new List<int?> { null, null };

        // Act
        var result = input.Max<int>();

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Max_DoubleWithNaN_IgnoresNaN_Math()
    {
        // Act
        var result = YANMath.Max(double.NaN, 1.0, -1.0);

        // Assert
        Assert.Equal(1.0, result);
    }

    [Fact]
    public void Max_DateTimes_KeepMillisecondsAndKind_Math()
    {
        // Arrange
        var earlier = new DateTime(2024, 1, 1, 10, 0, 0, 123, DateTimeKind.Utc);
        var later = new DateTime(2024, 1, 1, 10, 0, 0, 456, DateTimeKind.Utc);

        // Act
        var max = YANMath.Max(earlier, later);
        var min = YANMath.Min(later, earlier);

        // Assert
        Assert.Equal(later, max);
        Assert.Equal(DateTimeKind.Utc, max.Kind);
        Assert.Equal(earlier, min);
        Assert.Equal(DateTimeKind.Utc, min.Kind);
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

    [Fact]
    public void Average_CollectionWithMixedTypes_ConvertsTypes_Math()
    {
        // Arrange
        var input = new List<int?> { 2, 4, 6, 8, 10 };

        // Act
        double? result = input.Average<double>();

        // Assert
        Assert.Equal(6.0, result);
    }

    [Fact]
    public void Average_AllNullCollection_ReturnsDefault_Math()
    {
        // Arrange
        var input = new List<int?> { null, null };

        // Act
        var result = input.Average<int>();

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Average_AllNullNullableCollection_ReturnsNull_Math()
    {
        // Arrange
        var input = new List<int?> { null };

        // Act
        var result = input.Average<int?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Average_Int_RoundsHalfToEven_Math()
    {
        // Act
        var twoAndThree = YANMath.Average(2, 3);
        var oneAndTwo = YANMath.Average(1, 2);

        // Assert
        Assert.Equal(2, twoAndThree);
        Assert.Equal(2, oneAndTwo);
    }

    [Fact]
    public void Average_Decimal_KeepsAllDigits_Math()
    {
        // Act
        var result = YANMath.Average(1m, 0m, 0m);

        // Assert
        Assert.Equal(1m / 3m, result);
    }

    [Fact]
    public void Average_DoubleNegativeZero_KeepsSign_Math()
    {
        // Act
        var result = YANMath.Average(-0.0);

        // Assert
        Assert.True(double.IsNegative(result));
    }

    [Fact]
    public void Average_LazySequences_MatchArrays_Math()
    {
        // Arrange
        var ints = Enumerable.Range(1, 1_000).Select(static x => x * 3);
        IEnumerable<long> longs = new HashSet<long> { 9007199254740993, 9007199254740995 };
        var doubles = Enumerable.Range(1, 100).Select(static x => x / 7.0);
        var decimals = Enumerable.Range(1, 100).Select(static x => x / 7m);
        var negativeZero = new[] { -0.0 }.Select(static x => x);

        // Act & Assert
        Assert.Equal(YANMath.Average(ints.ToArray()), YANMath.Average<int>(ints));
        Assert.Equal(9007199254740994L, YANMath.Average<long>(longs));
        Assert.Equal(YANMath.Average(doubles.ToArray()), YANMath.Average<double>(doubles));
        Assert.Equal(YANMath.Average(decimals.ToArray()), YANMath.Average<decimal>(decimals));
        Assert.True(double.IsNegative(YANMath.Average<double>(negativeZero)));
    }

    [Fact]
    public void Average_SequenceEmptyOnSecondEnumeration_ReturnsDefault_Math()
    {
        // Act
        var intResult = YANMath.Average<int>(new OneShot<int>(5, 1, 3));
        var decimalResult = YANMath.Average<decimal>(new OneShot<decimal>(1m));
        var doubleResult = YANMath.Average<double>(new OneShot<double>(1.0));

        // Assert
        Assert.Equal(0, intResult);
        Assert.Equal(0m, decimalResult);
        Assert.Equal(0.0, doubleResult);
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

    [Fact]
    public void Sum_CollectionWithMixedTypes_ConvertsTypes_Math()
    {
        // Arrange
        var input = new List<int?> { 2, 4, 6, 8, 10 };

        // Act
        int? result = input.Sum<int>();

        // Assert
        Assert.Equal(30, result);
    }

    [Fact]
    public void Sum_LongAboveTwoToThe53_IsExact_Math()
    {
        // Act
        var result = YANMath.Sum(new long[] { 9007199254740993, 0 });

        // Assert
        Assert.Equal(9007199254740993, result);
    }

    [Fact]
    public void Sum_LongNearMaxValue_IsExact_Math()
    {
        // Act
        var result = YANMath.Sum(long.MaxValue, long.MaxValue, long.MinValue);

        // Assert
        Assert.Equal(long.MaxValue - 1, result);
    }

    [Fact]
    public void Sum_Decimal_HasNoTrailingZeros_Math()
    {
        // Act
        var result = YANMath.Sum(1.10m, 2.20m);

        // Assert
        Assert.Equal("3.3", result.ToString(System.Globalization.CultureInfo.InvariantCulture));
    }

    [Fact]
    public void Sum_DecimalOverflow_FallsBackToDouble_Math()
    {
        // Act
        var result = YANMath.Sum(decimal.MaxValue, decimal.MaxValue, decimal.MinValue);

        // Assert
        Assert.Equal(0m, result);
    }

    [Fact]
    public void Sum_IntOverflow_ReturnsDefault_Math()
    {
        // Act
        var result = YANMath.Sum(Enumerable.Range(0, 100_000).ToArray());
        var nullableResult = YANMath.Sum<int?>(int.MaxValue, 1);

        // Assert
        Assert.Equal(0, result);
        Assert.Null(nullableResult);
    }

    [Fact]
    public void Sum_Float_IsComputedInDouble_Math()
    {
        // Act
        var result = YANMath.Sum(0.1f, 0.2f, 0.3f);

        // Assert
        Assert.Equal((float)((double)0.1f + 0.2f + 0.3f), result);
    }

    [Fact]
    public void Sum_LazySequences_MatchArrays_Math()
    {
        // Arrange
        var ints = Enumerable.Range(1, 1_000).Select(static x => x * 3);
        IEnumerable<long> longs = new HashSet<long> { 9007199254740993, 1, 2 };
        var doubles = Enumerable.Range(1, 100).Select(static x => x / 7.0);
        var decimals = Enumerable.Range(1, 100).Select(static x => x / 7m);
        var decimalOverflow = new[] { decimal.MaxValue, decimal.MaxValue, decimal.MinValue }.Select(static x => x);

        // Act & Assert
        Assert.Equal(YANMath.Sum(ints.ToArray()), YANMath.Sum<int>(ints));
        Assert.Equal(9007199254740996L, YANMath.Sum<long>(longs));
        Assert.Equal(YANMath.Sum(doubles.ToArray()), YANMath.Sum<double>(doubles));
        Assert.Equal(YANMath.Sum(decimals.ToArray()), YANMath.Sum<decimal>(decimals));
        Assert.Equal(0, YANMath.Sum<int>(Enumerable.Range(0, 100_000)));
        Assert.Equal(0m, YANMath.Sum<decimal>(decimalOverflow));
    }

    [Fact]
    public void Sum_ListSubclassWithOwnEnumerator_FollowsTheEnumerator_Math()
    {
        // Arrange
        IEnumerable<int> input = new FilteredList { 5, -100, 3 };

        // Act
        var sum = YANMath.Sum<int>(input);
        var average = YANMath.Average<int>(input);
        var min = YANMath.Min<int>(input);

        // Assert
        Assert.Equal(8, sum);
        Assert.Equal(4, average);
        Assert.Equal(3, min);
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

    [Fact]
    public void Truncate_StringValue_ConvertsAndTruncates_Math()
    {
        // Arrange
        var input = "3.75";

        // Act
        double? result = input.Truncate<double>();

        // Assert
        Assert.Equal(3.0, result);
    }

    [Fact]
    public void Truncate_LongAboveTwoToThe53_IsExact_Math()
    {
        // Act
        var result = 9007199254740993L.Truncate();

        // Assert
        Assert.Equal(9007199254740993L, result);
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

    [Fact]
    public void Ceiling_StringValue_ConvertsAndCeils_Math()
    {
        // Arrange
        var input = "3.75";

        // Act
        double? result = input.Ceiling<double>();

        // Assert
        Assert.Equal(4.0, result);
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

    [Fact]
    public void Floor_StringValue_ConvertsAndFloors_Math()
    {
        // Arrange
        var input = "3.75";

        // Act
        double? result = input.Floor<double>();

        // Assert
        Assert.Equal(3.0, result);
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

    [Fact]
    public void Round_StringValue_ConvertsAndRounds_Math()
    {
        // Arrange
        var input = "3.75";

        // Act
        double? result = input.Round<double>();

        // Assert
        Assert.Equal(4.0, result);
    }

    [Fact]
    public void Round_DecimalMidpoint_RoundsTheDecimalValue_Math()
    {
        // Act
        var result = 1.005m.Round(2);

        // Assert
        Assert.Equal(1.01m, result);
    }

    [Fact]
    public void Round_DecimalToPositiveInfinity_KeepsExactValue_Math()
    {
        // Act
        var result = 1.10m.Round(2, MidpointRounding.ToPositiveInfinity);

        // Assert
        Assert.Equal(1.1m, result);
    }

    [Fact]
    public void Round_LongMaxValue_ReturnsInput_Math()
    {
        // Act
        var result = long.MaxValue.Round(2);

        // Assert
        Assert.Equal(long.MaxValue, result);
    }

    [Fact]
    public void Round_NegativeDigits_Throws_Math()
    {
        // Act & Assert
        _ = Assert.Throws<ArgumentOutOfRangeException>(static () => 5m.Round(-1));
        _ = Assert.Throws<ArgumentOutOfRangeException>(static () => 5.Round(-1));
    }

    [Fact]
    public void Round_DoubleMoreThan15Digits_RoundsAsDecimal_Math()
    {
        // Act
        var tiny = 1e-16.Round(20);
        var half = 1.5.Round(16);
        var sum = (0.1 + 0.2).Round(17);
        var cut = (0.1 + 0.2).Round(16);
        var belowDecimalScale = 1e-30.Round(20);
        var seventeenDigits = 30490906.876740474.Round(20);
        var negativeZero = (-0.0).Round(20);

        // Assert
        Assert.Equal(30490906.876740474, seventeenDigits);
        Assert.True(double.IsNegative(negativeZero));
        Assert.Equal(1e-16, tiny);
        Assert.Equal(1.5, half);
        Assert.Equal(0.30000000000000004, sum);
        Assert.Equal(0.3, cut);
        Assert.Equal(0.0, belowDecimalScale);
    }

    [Fact]
    public void Round_DoubleMoreThan15DigitsOutsideDecimalRange_RoundsTo15Digits_Math()
    {
        // Act
        var huge = 1e300.Round(20);
        var notANumber = double.NaN.Round(16);

        // Assert
        Assert.Equal(1e300, huge);
        Assert.True(double.IsNaN(notANumber));
    }

    [Fact]
    public void Round_DecimalAndIntegerMoreThan15Digits_DoNotThrow_Math()
    {
        // Act
        var decimalResult = 1.23456789012345678m.Round(16);
        var cappedResult = 1.23456789012345678m.Round(40);
        var integerResult = 5.Round(20);

        // Assert
        Assert.Equal(1.2345678901234568m, decimalResult);
        Assert.Equal(1.23456789012345678m, cappedResult);
        Assert.Equal(5, integerResult);
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

    [Fact]
    public void Sqrt_StringValue_ConvertsAndCalculatesSqrt_Math()
    {
        // Arrange
        var input = "16.0";

        // Act
        double? result = input.Sqrt<double>();

        // Assert
        Assert.Equal(4.0, result);
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

    [Fact]
    public void Pow_StringValueAndPower_ConvertsAndCalculatesPow_Math()
    {
        // Arrange
        var input = "2.0";

        // Act
        double? result = input.Pow<double>(3);

        // Assert
        Assert.Equal(8.0, result);
    }

    [Fact]
    public void Pow_IntResultOutOfRange_ReturnsZero_Math()
    {
        // Arrange
        var input = 100_000;

        // Act (8.3.3 crashed the process with a stack overflow; overflow semantics are an open decision)
        var result = input.Pow(2);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Pow_LongWholeExponent_IsExact_Math()
    {
        // Act
        var result = 3L.Pow(39);

        // Assert
        Assert.Equal(4052555153018976267L, result);
    }

    [Fact]
    public void Pow_DecimalNegativeExponent_IsExact_Math()
    {
        // Act
        var result = 3m.Pow(-1);

        // Assert
        Assert.Equal(1m / 3m, result);
    }

    [Fact]
    public void Pow_IntOverflow_ReturnsDefault_Math()
    {
        // Act
        var result = 100000.Pow(2);
        var negativeExponent = 2.Pow(-1);

        // Assert
        Assert.Equal(0, result);
        Assert.Equal(0, negativeExponent);
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
    public void Abs_IntMinValue_ReturnsZero_Math()
    {
        // Arrange
        var input = int.MinValue;

        // Act (8.3.3 crashed the process with a stack overflow; overflow semantics are an open decision)
        var result = input.Abs();

        // Assert
        Assert.Equal(0, result);
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

    [Fact]
    public void Abs_StringValue_ConvertsAndCalculatesAbs_Math()
    {
        // Arrange
        var input = "-5.0";

        // Act
        double? result = input.Abs<double>();

        // Assert
        Assert.Equal(5.0, result);
    }

    [Fact]
    public void Abs_LongAboveTwoToThe53_IsExact_Math()
    {
        // Act
        var result = (-9007199254740993L).Abs();

        // Assert
        Assert.Equal(9007199254740993L, result);
    }

    [Fact]
    public void Abs_IntMinValue_ReturnsDefault_Math()
    {
        // Act
        var result = int.MinValue.Abs();
        var nullableResult = ((int?)int.MinValue).Abs();

        // Assert
        Assert.Equal(0, result);
        Assert.Null(nullableResult);
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

    [Fact]
    public void Sin_StringValue_ConvertsAndCalculatesSin_Math()
    {
        // Arrange
        var input = "1.5707963267948966";

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

    [Fact]
    public void Cos_StringValue_ConvertsAndCalculatesCos_Math()
    {
        // Arrange
        var input = "3.141592653589793";

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

    [Fact]
    public void Tan_StringValue_ConvertsAndCalculatesTan_Math()
    {
        // Arrange
        var input = "0.7853981633974483";

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

    [Fact]
    public void Asin_StringValue_ConvertsAndCalculatesAsin_Math()
    {
        // Arrange
        var input = "1.0";

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

    [Fact]
    public void Acos_StringValue_ConvertsAndCalculatesAcos_Math()
    {
        // Arrange
        var input = "-1.0";

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

    [Fact]
    public void Atan_StringValue_ConvertsAndCalculatesAtan_Math()
    {
        // Arrange
        var input = "1.0";

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
        Assert.NotNull(result);
        Assert.Equal(3.0, result.Value, 15);
    }

    [Fact]
    public void Cbrt_NegativeValue_ReturnsNegativeCubeRoot_Math()
    {
        // Arrange
        double? input = -27.0;

        // Act
        double? result = input.Cbrt<double>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(-3.0, result.Value, 15);
    }

    [Fact]
    public void Cbrt_StringValue_ConvertsAndCalculatesCbrt_Math()
    {
        // Arrange
        var input = "27.0";

        // Act
        double? result = input.Cbrt<double>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3.0, result.Value, 15);
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

    [Fact]
    public void Exp_StringValue_ConvertsAndCalculatesExp_Math()
    {
        // Arrange
        var input = "1.0";

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

    [Fact]
    public void Exp2_StringValue_ConvertsAndCalculatesExp2_Math()
    {
        // Arrange
        var input = "3.0";

        // Act
        double? result = input.Exp2<double>();

        // Assert
        Assert.Equal(8.0, result);
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

    [Fact]
    public void Log_StringValue_ConvertsAndCalculatesLog_Math()
    {
        // Arrange
        var input = "100.0";

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

    [Fact]
    public void Log10_StringValue_ConvertsAndCalculatesLog10_Math()
    {
        // Arrange
        var input = "100.0";

        // Act
        double? result = input.Log10<double>();

        // Assert
        Assert.Equal(2.0, result);
    }

    [Fact]
    public void Log10_FractionalValue_ReturnsCorrectValue_Math()
    {
        // Arrange
        double? input = 0.1;

        // Act
        double? result = input.Log10<double>();

        // Assert
        Assert.Equal(-1.0, result);
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

    [Fact]
    public void Log2_StringValue_ConvertsAndCalculatesLog2_Math()
    {
        // Arrange
        var input = "8.0";

        // Act
        double? result = input.Log2<double>();

        // Assert
        Assert.Equal(3.0, result);
    }

    [Fact]
    public void Log2_FractionalValue_ReturnsCorrectValue_Math()
    {
        // Arrange
        double? input = 0.5;

        // Act
        double? result = input.Log2<double>();

        // Assert
        Assert.Equal(-1.0, result);
    }

    [Fact]
    public void Log2_PowerOfTwo_IsExact_Math()
    {
        // Act
        var result = 536870912.0.Log2();

        // Assert
        Assert.Equal(29.0, result);
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

    [Fact]
    public void ILogB_StringValue_ConvertsAndCalculatesILogB_Math()
    {
        // Arrange
        var input = "8.0";

        // Act
        int? result = input.ILogB<int>();

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void ILogB_LargeValue_ReturnsCorrectExponent_Math()
    {
        // Arrange
        double? input = 1024.0;

        // Act
        int? result = input.ILogB<int>();

        // Assert
        Assert.Equal(10, result);
    }

    #endregion

    #region Helpers

    /// <summary>A sequence that yields its items on the first enumeration only, as a consumed stream does.</summary>
    private sealed class OneShot<T>(params T[] items) : IEnumerable<T>
    {
        private bool _enumerated;

        public IEnumerator<T> GetEnumerator()
        {
            var first = !_enumerated;

            _enumerated = true;

            return first ? ((IEnumerable<T>)items).GetEnumerator() : Enumerable.Empty<T>().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }

    /// <summary>A <see cref="List{T}"/> whose own <see cref="IEnumerable{T}"/> implementation skips negative items.</summary>
    private sealed class FilteredList : List<int>, IEnumerable<int>
    {
        IEnumerator<int> IEnumerable<int>.GetEnumerator() => ToArray().Where(static x => x >= 0).GetEnumerator();
    }

    #endregion
}
