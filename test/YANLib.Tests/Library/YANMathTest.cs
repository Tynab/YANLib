using System.Linq;
using System;

namespace YANLib.Tests.Library;

public partial class YANMathTest
{
    #region Min

    [Fact]
    public void Min_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<int?>? input = null;

        // Act
        var result = input.Min();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Min_EmptyCollection_ReturnsNull()
    {
        // Arrange
        var input = Array.Empty<int?>();

        // Act
        var result = input.Min();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Min_IntCollection_ReturnsMinValue()
    {
        // Arrange
        var input = new int?[] { 5, 2, 8, 1, 9 };

        // Act
        var result = input.Min();

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void Min_DoubleCollection_ReturnsMinValue()
    {
        // Arrange
        var input = new double?[] { 5.5, 2.2, 8.8, 1.1, 9.9 };

        // Act
        var result = input.Min();

        // Assert
        Assert.Equal(1.1, result);
    }

    [Fact]
    public void Min_MixedCollection_ReturnsMinValue()
    {
        // Arrange
        var input = new object?[] { 5, 2.2, "8", 1, "9.9" };

        // Act
        var result = input.Min<double>();

        // Assert
        Assert.Equal(1.0, result);
    }

    [Fact]
    public void Min_CollectionWithNulls_IgnoresNulls()
    {
        // Arrange
        var input = new int?[] { 5, null, 8, 1, null };

        // Act
        var result = input.Min();

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void Min_ParamsOverload_ReturnsMinValue()
    {
        // Act
        var result = YANMath.Min(5, 2, 8, 1, 9);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void Min_ParamsWithNulls_IgnoresNulls()
    {
        // Act
        var result = YANMath.Min<int?>(5, null, 8, 1, null);

        // Assert
        Assert.Equal(1, result);
    }

    #endregion

    #region Max

    [Fact]
    public void Max_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<int?>? input = null;

        // Act
        var result = input.Max();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Max_EmptyCollection_ReturnsNull()
    {
        // Arrange
        var input = Array.Empty<int?>();

        // Act
        var result = input.Max();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Max_IntCollection_ReturnsMaxValue()
    {
        // Arrange
        var input = new int?[] { 5, 2, 8, 1, 9 };

        // Act
        var result = input.Max();

        // Assert
        Assert.Equal(9, result);
    }

    [Fact]
    public void Max_DoubleCollection_ReturnsMaxValue()
    {
        // Arrange
        var input = new double?[] { 5.5, 2.2, 8.8, 1.1, 9.9 };

        // Act
        var result = input.Max();

        // Assert
        Assert.Equal(9.9, result);
    }

    [Fact]
    public void Max_MixedCollection_ReturnsMaxValue()
    {
        // Arrange
        var input = new object?[] { 5, 2.2, "8", 1, "9.9" };

        // Act
        var result = input.Max<double>();

        // Assert
        Assert.Equal(9.9, result);
    }

    [Fact]
    public void Max_CollectionWithNulls_IgnoresNulls()
    {
        // Arrange
        var input = new int?[] { 5, null, 8, 1, null };

        // Act
        var result = input.Max();

        // Assert
        Assert.Equal(8, result);
    }

    [Fact]
    public void Max_ParamsOverload_ReturnsMaxValue()
    {
        // Act
        var result = YANMath.Max(5, 2, 8, 1, 9);

        // Assert
        Assert.Equal(9, result);
    }

    [Fact]
    public void Max_ParamsWithNulls_IgnoresNulls()
    {
        // Act
        var result = YANMath.Max<int?>(5, null, 8, 1, null);

        // Assert
        Assert.Equal(8, result);
    }

    #endregion

    #region Average

    [Fact]
    public void Average_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<int?>? input = null;

        // Act
        var result = input.Average();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Average_EmptyCollection_ReturnsNull()
    {
        // Arrange
        var input = Array.Empty<int?>();

        // Act
        var result = input.Average();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Average_IntCollection_ReturnsAverage()
    {
        // Arrange
        var input = new int?[] { 2, 4, 6, 8, 10 };

        // Act
        var result = input.Average();

        // Assert
        Assert.Equal(6, result);
    }

    [Fact]
    public void Average_DoubleCollection_ReturnsAverage()
    {
        // Arrange
        var input = new double?[] { 1.5, 2.5, 3.5, 4.5, 5.5 };

        // Act
        var result = input.Average();

        // Assert
        Assert.Equal(3.5, result);
    }

    [Fact]
    public void Average_MixedCollection_ReturnsAverage()
    {
        // Arrange
        var input = new object?[] { 1, 2.5, "3", 4.5, "5" };

        // Act
        var result = input.Average<double>();

        // Assert
        Assert.Equal(3.2, result);
    }

    [Fact]
    public void Average_CollectionWithNulls_IgnoresNulls()
    {
        // Arrange
        var input = new int?[] { 2, null, 6, 8, null };

        // Act
        var result = input.Average();

        // Assert
        Assert.Equal(5, result);
    }

    [Fact]
    public void Average_ParamsOverload_ReturnsAverage()
    {
        // Act
        var result = YANMath.Average<double>(2, 4, 6, 8, 10);

        // Assert
        Assert.Equal(6.0, result);
    }

    [Fact]
    public void Average_ParamsWithNulls_IgnoresNulls()
    {
        // Act
        var result = YANMath.Average<double>(2, null, 6, 8, null);

        // Assert
        Assert.Equal(5.333333333333333, result, 15);
    }

    [Fact]
    public void Average_IntToInt_ReturnsRoundedAverage()
    {
        // Arrange
        var input = new int?[] { 1, 2, 3, 4, 5 };

        // Act
        var result = input.Average();

        // Assert
        Assert.Equal(3, result);
    }

    #endregion

    #region Sum

    [Fact]
    public void Sum_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<int?>? input = null;

        // Act
        var result = input.Sum();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Sum_EmptyCollection_ReturnsNull()
    {
        // Arrange
        var input = Array.Empty<int?>();

        // Act
        var result = input.Sum();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Sum_IntCollection_ReturnsSum()
    {
        // Arrange
        var input = new int?[] { 1, 2, 3, 4, 5 };

        // Act
        var result = input.Sum();

        // Assert
        Assert.Equal(15, result);
    }

    [Fact]
    public void Sum_DoubleCollection_ReturnsSum()
    {
        // Arrange
        var input = new double?[] { 1.1, 2.2, 3.3, 4.4, 5.5 };

        // Act
        var result = input.Sum();

        // Assert
        Assert.Equal(16.5, result);
    }

    [Fact]
    public void Sum_MixedCollection_ReturnsSum()
    {
        // Arrange
        var input = new object?[] { 1, 2.2, "3", 4.4, "5" };

        // Act
        var result = input.Sum<double>();

        // Assert
        Assert.Equal(15.6, result);
    }

    [Fact]
    public void Sum_CollectionWithNulls_TreatsNullsAsZero()
    {
        // Arrange
        var input = new int?[] { 1, null, 3, 4, null };

        // Act
        var result = input.Sum();

        // Assert
        Assert.Equal(8, result);
    }

    [Fact]
    public void Sum_ParamsOverload_ReturnsSum()
    {
        // Act
        var result = YANMath.Sum(1, 2, 3, 4, 5);

        // Assert
        Assert.Equal(15, result);
    }

    [Fact]
    public void Sum_ParamsWithNulls_TreatsNullsAsZero()
    {
        // Act
        var result = YANMath.Sum<int>(1, null, 3, 4, null);

        // Assert
        Assert.Equal(8, result);
    }

    #endregion

    #region Truncate

    [Fact]
    public void Truncate_NullInput_ReturnsNull()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Truncate();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Truncate_PositiveDouble_RemovesFractionalPart()
    {
        // Arrange
        var input = 3.75;

        // Act
        var result = input.Truncate();

        // Assert
        Assert.Equal(3.0, result);
    }

    [Fact]
    public void Truncate_NegativeDouble_RemovesFractionalPart()
    {
        // Arrange
        var input = -3.75;

        // Act
        var result = input.Truncate();

        // Assert
        Assert.Equal(-3.0, result);
    }

    [Fact]
    public void Truncate_IntegerValue_ReturnsSameValue()
    {
        // Arrange
        var input = 5.0;

        // Act
        var result = input.Truncate();

        // Assert
        Assert.Equal(5.0, result);
    }

    [Fact]
    public void Truncate_StringInput_ConvertsAndTruncates()
    {
        // Arrange
        var input = "3.75";

        // Act
        var result = input.Truncate<double>();

        // Assert
        Assert.Equal(3.0, result);
    }

    [Fact]
    public void Truncate_DoubleToInt_TruncatesAndConverts()
    {
        // Arrange
        var input = 3.75;

        // Act
        var result = input.Truncate<int>();

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void Truncates_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<double?>? input = null;

        // Act
        var result = input.Truncates();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Truncates_EmptyCollection_ReturnsEmptyCollection()
    {
        // Arrange
        var input = Array.Empty<double?>();

        // Act
        var result = input.Truncates();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result!);
    }

    [Fact]
    public void Truncates_DoubleCollection_TruncatesAllValues()
    {
        // Arrange
        var input = new double?[] { 1.1, 2.7, 3.5, 4.9, 5.0 };

        // Act
        var result = input.Truncates()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal([1.0, 2.0, 3.0, 4.0, 5.0], result);
    }

    [Fact]
    public void Truncates_CollectionWithNulls_PreservesNulls()
    {
        // Arrange
        var input = new double?[] { 1.1, null, 3.5, null, 5.0 };

        // Act
        var result = input.Truncates()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal([1.0, null, 3.0, null, 5.0], result);
    }

    [Fact]
    public void Truncates_ParamsOverload_TruncatesAllValues()
    {
        // Arrange
        var expected = new double[] { 1.0, 2.0, 3.0, 4.0, 5.0 };

        // Act
        var result = YANMath.Truncates(1.1, 2.7, 3.5, 4.9, 5.0)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    #endregion

    #region Ceiling

    [Fact]
    public void Ceiling_NullInput_ReturnsNull()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Ceiling();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Ceiling_PositiveDouble_RoundsUp()
    {
        // Arrange
        var input = 3.1;

        // Act
        var result = input.Ceiling();

        // Assert
        Assert.Equal(4.0, result);
    }

    [Fact]
    public void Ceiling_NegativeDouble_RoundsUp()
    {
        // Arrange
        var input = -3.1;

        // Act
        var result = input.Ceiling();

        // Assert
        Assert.Equal(-3.0, result);
    }

    [Fact]
    public void Ceiling_IntegerValue_ReturnsSameValue()
    {
        // Arrange
        var input = 5.0;

        // Act
        var result = input.Ceiling();

        // Assert
        Assert.Equal(5.0, result);
    }

    [Fact]
    public void Ceiling_StringInput_ConvertsAndCeils()
    {
        // Arrange
        var input = "3.1";

        // Act
        var result = input.Ceiling<double>();

        // Assert
        Assert.Equal(4.0, result);
    }

    [Fact]
    public void Ceiling_DoubleToInt_CeilsAndConverts()
    {
        // Arrange
        var input = 3.1;

        // Act
        var result = input.Ceiling<int>();

        // Assert
        Assert.Equal(4, result);
    }

    [Fact]
    public void Ceilings_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<double?>? input = null;

        // Act
        var result = input.Ceilings();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Ceilings_EmptyCollection_ReturnsEmptyCollection()
    {
        // Arrange
        var input = Array.Empty<double?>();

        // Act
        var result = input.Ceilings();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result!);
    }

    [Fact]
    public void Ceilings_DoubleCollection_CeilsAllValues()
    {
        // Arrange
        var input = new double?[] { 1.1, 2.7, 3.0, 4.9, 5.0 };

        // Act
        var result = input.Ceilings()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal([2.0, 3.0, 3.0, 5.0, 5.0], result);
    }

    [Fact]
    public void Ceilings_CollectionWithNulls_PreservesNulls()
    {
        // Arrange
        var input = new double?[] { 1.1, null, 3.0, null, 5.0 };

        // Act
        var result = input.Ceilings()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal([2.0, null, 3.0, null, 5.0], result);
    }

    [Fact]
    public void Ceilings_ParamsOverload_CeilsAllValues()
    {
        // Arrange
        var expected = new double[] { 2.0, 3.0, 3.0, 5.0, 5.0 };

        // Act
        var result = YANMath.Ceilings(1.1, 2.7, 3.0, 4.9, 5.0)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    #endregion

    #region Floor

    [Fact]
    public void Floor_NullInput_ReturnsNull()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Floor();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Floor_PositiveDouble_RoundsDown()
    {
        // Arrange
        var input = 3.9;

        // Act
        var result = input.Floor();

        // Assert
        Assert.Equal(3.0, result);
    }

    [Fact]
    public void Floor_NegativeDouble_RoundsDown()
    {
        // Arrange
        var input = -3.1;

        // Act
        var result = input.Floor();

        // Assert
        Assert.Equal(-4.0, result);
    }

    [Fact]
    public void Floor_IntegerValue_ReturnsSameValue()
    {
        // Arrange
        var input = 5.0;

        // Act
        var result = input.Floor();

        // Assert
        Assert.Equal(5.0, result);
    }

    [Fact]
    public void Floor_StringInput_ConvertsAndFloors()
    {
        // Arrange
        var input = "3.9";

        // Act
        var result = input.Floor<double>();

        // Assert
        Assert.Equal(3.0, result);
    }

    [Fact]
    public void Floor_DoubleToInt_FloorsAndConverts()
    {
        // Arrange
        var input = 3.9;

        // Act
        var result = input.Floor<int>();

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void Floors_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<double?>? input = null;

        // Act
        var result = input.Floors();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Floors_EmptyCollection_ReturnsEmptyCollection()
    {
        // Arrange
        var input = Array.Empty<double?>();

        // Act
        var result = input.Floors();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result!);
    }

    [Fact]
    public void Floors_DoubleCollection_FloorsAllValues()
    {
        // Arrange
        var input = new double?[] { 1.1, 2.7, 3.0, 4.9, 5.0 };

        // Act
        var result = input.Floors()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal([1.0, 2.0, 3.0, 4.0, 5.0], result);
    }

    [Fact]
    public void Floors_CollectionWithNulls_PreservesNulls()
    {
        // Arrange
        var input = new double?[] { 1.1, null, 3.0, null, 5.0 };

        // Act
        var result = input.Floors()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal([1.0, null, 3.0, null, 5.0], result);
    }

    [Fact]
    public void Floors_ParamsOverload_FloorsAllValues()
    {
        // Arrange
        var expected = new double[] { 1.0, 2.0, 3.0, 4.0, 5.0 };

        // Act
        var result = YANMath.Floors(1.1, 2.7, 3.0, 4.9, 5.0)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    #endregion
    //TODO
    #region Round

    [Fact]
    public void Round_NullInput_ReturnsNull()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Round<double?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Round_PositiveDoubleNoDigits_RoundsToNearestInteger()
    {
        // Arrange
        double input = 3.4;

        // Act
        var result = input.Round<double>();

        // Assert
        Assert.Equal(3.0, result);
    }

    [Fact]
    public void Round_PositiveDoubleWithDigits_RoundsToSpecifiedDigits()
    {
        // Arrange
        double input = 3.45678;
        int digits = 2;

        // Act
        var result = input.Round<double>(digits);

        // Assert
        Assert.Equal(3.46, result);
    }

    [Fact]
    public void Round_NegativeDoubleNoDigits_RoundsToNearestInteger()
    {
        // Arrange
        double input = -3.6;

        // Act
        var result = input.Round<double>();

        // Assert
        Assert.Equal(-4.0, result);
    }

    [Fact]
    public void Round_NegativeDoubleWithDigits_RoundsToSpecifiedDigits()
    {
        // Arrange
        double input = -3.45678;
        int digits = 2;

        // Act
        var result = input.Round<double>(digits);

        // Assert
        Assert.Equal(-3.46, result);
    }

    [Fact]
    public void Round_StringInput_ConvertsAndRounds()
    {
        // Arrange
        string input = "3.45678";
        int digits = 2;

        // Act
        var result = input.Round<double>(digits);

        // Assert
        Assert.Equal(3.46, result);
    }

    [Fact]
    public void Round_DoubleToInt_RoundsAndConverts()
    {
        // Arrange
        double input = 3.6;

        // Act
        var result = input.Round<int>();

        // Assert
        Assert.Equal(4, result);
    }

    [Fact]
    public void Round_NullDigits_UsesDefaultRounding()
    {
        // Arrange
        double input = 3.6;
        object? digits = null;

        // Act
        var result = input.Round<double>(digits);

        // Assert
        Assert.Equal(4.0, result);
    }

    [Fact]
    public void Rounds_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<double?>? input = null;

        // Act
        var result = input.Rounds<double?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Rounds_EmptyCollection_ReturnsEmptyCollection()
    {
        // Arrange
        var input = Array.Empty<double?>();

        // Act
        var result = input.Rounds<double?>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result!);
    }

    [Fact]
    public void Rounds_DoubleCollection_RoundsAllValues()
    {
        // Arrange
        var input = new double?[] { 1.4, 2.6, 3.5, 4.5, 5.0 };

        // Act
        var result = input.Rounds<double>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new double[] { 1.0, 3.0, 4.0, 4.0, 5.0 }, result);
    }

    [Fact]
    public void Rounds_DoubleCollectionWithDigits_RoundsAllValuesToSpecifiedDigits()
    {
        // Arrange
        var input = new double?[] { 1.44, 2.66, 3.55, 4.45, 5.00 };
        int digits = 1;

        // Act
        var result = input.Rounds<double>(digits)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new double[] { 1.4, 2.7, 3.6, 4.5, 5.0 }, result);
    }

    [Fact]
    public void Rounds_CollectionWithNulls_PreservesNulls()
    {
        // Arrange
        var input = new double?[] { 1.4, null, 3.5, null, 5.0 };

        // Act
        var result = input.Rounds<double?>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new double?[] { 1.0, null, 4.0, null, 5.0 }, result);
    }

    [Fact]
    public void Rounds_ParamsOverload_RoundsAllValues()
    {
        // Act
        var result = YANMath.Rounds<double>(1.4, 2.6, 3.5, 4.5, 5.0)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new double[] { 1.0, 3.0, 4.0, 4.0, 5.0 }, result);
    }

    #endregion

    #region Sqrt

    [Fact]
    public void Sqrt_NullInput_ReturnsNull()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Sqrt<double?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Sqrt_PositiveNumber_ReturnsSquareRoot()
    {
        // Arrange
        double input = 16.0;

        // Act
        var result = input.Sqrt<double>();

        // Assert
        Assert.Equal(4.0, result);
    }

    [Fact]
    public void Sqrt_Zero_ReturnsZero()
    {
        // Arrange
        double input = 0.0;

        // Act
        var result = input.Sqrt<double>();

        // Assert
        Assert.Equal(0.0, result);
    }

    [Fact]
    public void Sqrt_StringInput_ConvertsAndCalculates()
    {
        // Arrange
        string input = "16";

        // Act
        var result = input.Sqrt<double>();

        // Assert
        Assert.Equal(4.0, result);
    }

    [Fact]
    public void Sqrt_DoubleToInt_CalculatesAndConverts()
    {
        // Arrange
        double input = 16.0;

        // Act
        var result = input.Sqrt<int>();

        // Assert
        Assert.Equal(4, result);
    }

    [Fact]
    public void Sqrts_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<double?>? input = null;

        // Act
        var result = input.Sqrts<double?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Sqrts_EmptyCollection_ReturnsEmptyCollection()
    {
        // Arrange
        var input = Array.Empty<double?>();

        // Act
        var result = input.Sqrts<double?>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result!);
    }

    [Fact]
    public void Sqrts_DoubleCollection_CalculatesAllValues()
    {
        // Arrange
        var input = new double?[] { 4.0, 9.0, 16.0, 25.0, 36.0 };

        // Act
        var result = input.Sqrts<double>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new double[] { 2.0, 3.0, 4.0, 5.0, 6.0 }, result);
    }

    [Fact]
    public void Sqrts_CollectionWithNulls_PreservesNulls()
    {
        // Arrange
        var input = new double?[] { 4.0, null, 16.0, null, 36.0 };

        // Act
        var result = input.Sqrts<double?>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new double?[] { 2.0, null, 4.0, null, 6.0 }, result);
    }

    [Fact]
    public void Sqrts_ParamsOverload_CalculatesAllValues()
    {
        // Act
        var result = YANMath.Sqrts<double>(4.0, 9.0, 16.0, 25.0, 36.0)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new double[] { 2.0, 3.0, 4.0, 5.0, 6.0 }, result);
    }

    #endregion

    #region Pow

    [Fact]
    public void Pow_NullInput_ReturnsNull()
    {
        // Arrange
        double? input = null;
        double power = 2.0;

        // Act
        var result = input.Pow<double?>(power);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Pow_NullPower_ReturnsNull()
    {
        // Arrange
        double input = 2.0;
        double? power = null;

        // Act
        var result = input.Pow<double?>(power);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Pow_PositiveNumberSquared_ReturnsCorrectValue()
    {
        // Arrange
        double input = 3.0;
        double power = 2.0;

        // Act
        var result = input.Pow<double>(power);

        // Assert
        Assert.Equal(9.0, result);
    }

    [Fact]
    public void Pow_PositiveNumberCubed_ReturnsCorrectValue()
    {
        // Arrange
        double input = 3.0;
        double power = 3.0;

        // Act
        var result = input.Pow<double>(power);

        // Assert
        Assert.Equal(27.0, result);
    }

    [Fact]
    public void Pow_NegativeNumberEvenPower_ReturnsPositiveValue()
    {
        // Arrange
        double input = -3.0;
        double power = 2.0;

        // Act
        var result = input.Pow<double>(power);

        // Assert
        Assert.Equal(9.0, result);
    }

    [Fact]
    public void Pow_NegativeNumberOddPower_ReturnsNegativeValue()
    {
        // Arrange
        double input = -3.0;
        double power = 3.0;

        // Act
        var result = input.Pow<double>(power);

        // Assert
        Assert.Equal(-27.0, result);
    }

    [Fact]
    public void Pow_StringInput_ConvertsAndCalculates()
    {
        // Arrange
        string input = "3";
        double power = 2.0;

        // Act
        var result = input.Pow<double>(power);

        // Assert
        Assert.Equal(9.0, result);
    }

    [Fact]
    public void Pow_StringPower_ConvertsAndCalculates()
    {
        // Arrange
        double input = 3.0;
        string power = "2";

        // Act
        var result = input.Pow<double>(power);

        // Assert
        Assert.Equal(9.0, result);
    }

    [Fact]
    public void Pow_DoubleToInt_CalculatesAndConverts()
    {
        // Arrange
        double input = 3.0;
        double power = 2.0;

        // Act
        var result = input.Pow<int>(power);

        // Assert
        Assert.Equal(9, result);
    }

    [Fact]
    public void Pows_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<double?>? input = null;
        double power = 2.0;

        // Act
        var result = input.Pows<double?>(power);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Pows_EmptyCollection_ReturnsEmptyCollection()
    {
        // Arrange
        var input = Array.Empty<double?>();
        double power = 2.0;

        // Act
        var result = input.Pows<double?>(power);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result!);
    }

    [Fact]
    public void Pows_DoubleCollection_CalculatesAllValues()
    {
        // Arrange
        var input = new double?[] { 1.0, 2.0, 3.0, 4.0, 5.0 };
        double power = 2.0;

        // Act
        var result = input.Pows<double>(power)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new double[] { 1.0, 4.0, 9.0, 16.0, 25.0 }, result);
    }

    [Fact]
    public void Pows_CollectionWithNulls_PreservesNulls()
    {
        // Arrange
        var input = new double?[] { 1.0, null, 3.0, null, 5.0 };
        double power = 2.0;

        // Act
        var result = input.Pows<double?>(power)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new double?[] { 1.0, null, 9.0, null, 25.0 }, result);
    }

    #endregion

    #region Abs

    [Fact]
    public void Abs_NullInput_ReturnsNull()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Abs<double?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Abs_PositiveNumber_ReturnsSameValue()
    {
        // Arrange
        double input = 5.0;

        // Act
        var result = input.Abs<double>();

        // Assert
        Assert.Equal(5.0, result);
    }

    [Fact]
    public void Abs_NegativeNumber_ReturnsPositiveValue()
    {
        // Arrange
        double input = -5.0;

        // Act
        var result = input.Abs<double>();

        // Assert
        Assert.Equal(5.0, result);
    }

    [Fact]
    public void Abs_Zero_ReturnsZero()
    {
        // Arrange
        double input = 0.0;

        // Act
        var result = input.Abs<double>();

        // Assert
        Assert.Equal(0.0, result);
    }

    [Fact]
    public void Abs_StringInput_ConvertsAndCalculates()
    {
        // Arrange
        string input = "-5";

        // Act
        var result = input.Abs<double>();

        // Assert
        Assert.Equal(5.0, result);
    }

    [Fact]
    public void Abs_DoubleToInt_CalculatesAndConverts()
    {
        // Arrange
        double input = -5.0;

        // Act
        var result = input.Abs<int>();

        // Assert
        Assert.Equal(5, result);
    }

    [Fact]
    public void Abss_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<double?>? input = null;

        // Act
        var result = input.Abss<double?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Abss_EmptyCollection_ReturnsEmptyCollection()
    {
        // Arrange
        var input = Array.Empty<double?>();

        // Act
        var result = input.Abss<double?>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result!);
    }

    [Fact]
    public void Abss_DoubleCollection_CalculatesAllValues()
    {
        // Arrange
        var input = new double?[] { 1.0, -2.0, 3.0, -4.0, 5.0 };

        // Act
        var result = input.Abss<double>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new double[] { 1.0, 2.0, 3.0, 4.0, 5.0 }, result);
    }

    [Fact]
    public void Abss_CollectionWithNulls_PreservesNulls()
    {
        // Arrange
        var input = new double?[] { 1.0, null, -3.0, null, 5.0 };

        // Act
        var result = input.Abss<double?>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new double?[] { 1.0, null, 3.0, null, 5.0 }, result);
    }

    [Fact]
    public void Abss_ParamsOverload_CalculatesAllValues()
    {
        // Act
        var result = YANMath.Abss<double>(1.0, -2.0, 3.0, -4.0, 5.0)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new double[] { 1.0, 2.0, 3.0, 4.0, 5.0 }, result);
    }

    #endregion

    #region Log

    [Fact]
    public void Log_NullInput_ReturnsNull()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Log<double?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Log_PositiveNumberNoBase_ReturnsNaturalLog()
    {
        // Arrange
        double input = Math.E; // e

        // Act
        var result = input.Log<double>();

        // Assert
        Assert.Equal(1.0, result, 15);
    }

    [Fact]
    public void Log_PositiveNumberWithBase_ReturnsLogWithSpecifiedBase()
    {
        // Arrange
        double input = 100.0;
        double baseValue = 10.0;

        // Act
        var result = input.Log<double>(baseValue);

        // Assert
        Assert.Equal(2.0, result);
    }

    [Fact]
    public void Log_StringInput_ConvertsAndCalculates()
    {
        // Arrange
        string input = "100";
        double baseValue = 10.0;

        // Act
        var result = input.Log<double>(baseValue);

        // Assert
        Assert.Equal(2.0, result);
    }

    [Fact]
    public void Log_StringBase_ConvertsAndCalculates()
    {
        // Arrange
        double input = 100.0;
        string baseValue = "10";

        // Act
        var result = input.Log<double>(baseValue);

        // Assert
        Assert.Equal(2.0, result);
    }

    [Fact]
    public void Log_DoubleToInt_CalculatesAndConverts()
    {
        // Arrange
        double input = 100.0;
        double baseValue = 10.0;

        // Act
        var result = input.Log<int>(baseValue);

        // Assert
        Assert.Equal(2, result);
    }

    [Fact]
    public void Logs_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<double?>? input = null;
        double baseValue = 10.0;

        // Act
        var result = input.Logs<double?>(baseValue);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Logs_EmptyCollection_ReturnsEmptyCollection()
    {
        // Arrange
        var input = Array.Empty<double?>();
        double baseValue = 10.0;

        // Act
        var result = input.Logs<double?>(baseValue);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result!);
    }

    [Fact]
    public void Logs_DoubleCollection_CalculatesAllValues()
    {
        // Arrange
        var input = new double?[] { 1.0, 10.0, 100.0, 1000.0 };
        double baseValue = 10.0;

        // Act
        var result = input.Logs<double>(baseValue)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new double[] { 0.0, 1.0, 2.0, 3.0 }, result);
    }

    [Fact]
    public void Logs_CollectionWithNulls_PreservesNulls()
    {
        // Arrange
        var input = new double?[] { 1.0, null, 100.0, null };
        double baseValue = 10.0;

        // Act
        var result = input.Logs<double?>(baseValue)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new double?[] { 0.0, null, 2.0, null }, result);
    }

    [Fact]
    public void Logs_ParamsOverload_CalculatesAllValues()
    {
        // Act
        var result = YANMath.Logs<double>(1.0, 10.0, 100.0, 1000.0)?.ToArray();

        // Assert
        Assert.NotNull(result);
        // Default base is e (natural log)
        Assert.Equal(4, result!.Length);
        Assert.Equal(0.0, result[0], 1);
        Assert.Equal(2.302585092994046, result[1], 15);
        Assert.Equal(4.605170185988092, result[2], 15);
        Assert.Equal(6.907755278982137, result[3], 15);
    }

    #endregion

    #region Log10

    [Fact]
    public void Log10_NullInput_ReturnsNull()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Log10<double?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Log10_PositiveNumber_ReturnsBase10Log()
    {
        // Arrange
        double input = 100.0;

        // Act
        var result = input.Log10<double>();

        // Assert
        Assert.Equal(2.0, result);
    }

    [Fact]
    public void Log10_StringInput_ConvertsAndCalculates()
    {
        // Arrange
        string input = "100";

        // Act
        var result = input.Log10<double>();

        // Assert
        Assert.Equal(2.0, result);
    }

    [Fact]
    public void Log10_DoubleToInt_CalculatesAndConverts()
    {
        // Arrange
        double input = 100.0;

        // Act
        var result = input.Log10<int>();

        // Assert
        Assert.Equal(2, result);
    }

    [Fact]
    public void Log10s_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<double?>? input = null;

        // Act
        var result = input.Log10s<double?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Log10s_EmptyCollection_ReturnsEmptyCollection()
    {
        // Arrange
        var input = Array.Empty<double?>();

        // Act
        var result = input.Log10s<double?>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result!);
    }

    [Fact]
    public void Log10s_DoubleCollection_CalculatesAllValues()
    {
        // Arrange
        var input = new double?[] { 1.0, 10.0, 100.0, 1000.0 };

        // Act
        var result = input.Log10s<double>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new double[] { 0.0, 1.0, 2.0, 3.0 }, result);
    }

    [Fact]
    public void Log10s_CollectionWithNulls_PreservesNulls()
    {
        // Arrange
        var input = new double?[] { 1.0, null, 100.0, null };

        // Act
        var result = input.Log10s<double?>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new double?[] { 0.0, null, 2.0, null }, result);
    }

    [Fact]
    public void Log10s_ParamsOverload_CalculatesAllValues()
    {
        // Act
        var result = YANMath.Log10s<double>(1.0, 10.0, 100.0, 1000.0)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new double[] { 0.0, 1.0, 2.0, 3.0 }, result);
    }

    #endregion

    #region Log2

    [Fact]
    public void Log2_NullInput_ReturnsNull()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Log2<double?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Log2_PositiveNumber_ReturnsBase2Log()
    {
        // Arrange
        double input = 8.0;

        // Act
        var result = input.Log2<double>();

        // Assert
        Assert.Equal(3.0, result);
    }

    [Fact]
    public void Log2_StringInput_ConvertsAndCalculates()
    {
        // Arrange
        string input = "8";

        // Act
        var result = input.Log2<double>();

        // Assert
        Assert.Equal(3.0, result);
    }

    [Fact]
    public void Log2_DoubleToInt_CalculatesAndConverts()
    {
        // Arrange
        double input = 8.0;

        // Act
        var result = input.Log2<int>();

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void Log2s_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<double?>? input = null;

        // Act
        var result = input.Log2s<double?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Log2s_EmptyCollection_ReturnsEmptyCollection()
    {
        // Arrange
        var input = Array.Empty<double?>();

        // Act
        var result = input.Log2s<double?>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result!);
    }

    [Fact]
    public void Log2s_DoubleCollection_CalculatesAllValues()
    {
        // Arrange
        var input = new double?[] { 1.0, 2.0, 4.0, 8.0 };

        // Act
        var result = input.Log2s<double>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new double[] { 0.0, 1.0, 2.0, 3.0 }, result);
    }

    [Fact]
    public void Log2s_CollectionWithNulls_PreservesNulls()
    {
        // Arrange
        var input = new double?[] { 1.0, null, 4.0, null };

        // Act
        var result = input.Log2s<double?>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new double?[] { 0.0, null, 2.0, null }, result);
    }

    [Fact]
    public void Log2s_ParamsOverload_CalculatesAllValues()
    {
        // Act
        var result = YANMath.Log2s<double>(1.0, 2.0, 4.0, 8.0)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new double[] { 0.0, 1.0, 2.0, 3.0 }, result);
    }

    #endregion

    #region Sin

    [Fact]
    public void Sin_NullInput_ReturnsNull()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Sin<double?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Sin_Zero_ReturnsZero()
    {
        // Arrange
        double input = 0.0;

        // Act
        var result = input.Sin<double>();

        // Assert
        Assert.Equal(0.0, result);
    }

    [Fact]
    public void Sin_PiDividedBy2_ReturnsOne()
    {
        // Arrange
        double input = Math.PI / 2;

        // Act
        var result = input.Sin<double>();

        // Assert
        Assert.Equal(1.0, result, 15);
    }

    [Fact]
    public void Sin_Pi_ReturnsZero()
    {
        // Arrange
        double input = Math.PI;

        // Act
        var result = input.Sin<double>();

        // Assert
        Assert.Equal(0.0, result, 15);
    }

    [Fact]
    public void Sin_StringInput_ConvertsAndCalculates()
    {
        // Arrange
        string input = (Math.PI / 2).ToString();

        // Act
        var result = input.Sin<double>();

        // Assert
        Assert.Equal(1.0, result, 15);
    }

    [Fact]
    public void Sin_DoubleToInt_CalculatesAndConverts()
    {
        // Arrange
        double input = Math.PI / 2;

        // Act
        var result = input.Sin<int>();

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void Sins_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<double?>? input = null;

        // Act
        var result = input.Sins<double?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Sins_EmptyCollection_ReturnsEmptyCollection()
    {
        // Arrange
        var input = Array.Empty<double?>();

        // Act
        var result = input.Sins<double?>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result!);
    }

    [Fact]
    public void Sins_DoubleCollection_CalculatesAllValues()
    {
        // Arrange
        var input = new double?[] { 0.0, Math.PI / 6, Math.PI / 4, Math.PI / 3, Math.PI / 2 };

        // Act
        var result = input.Sins<double>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(0.0, result![0], 15);
        Assert.Equal(0.5, result[1], 15);
        Assert.Equal(0.7071067811865475, result[2], 15);
        Assert.Equal(0.8660254037844386, result[3], 15);
        Assert.Equal(1.0, result[4], 15);
    }

    [Fact]
    public void Sins_CollectionWithNulls_PreservesNulls()
    {
        // Arrange
        var input = new double?[] { 0.0, null, Math.PI / 4, null, Math.PI / 2 };

        // Act
        var result = input.Sins<double?>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(0.0, result![0], 15);
        Assert.Null(result[1]);
        Assert.Equal(0.7071067811865475, result[2], 15);
        Assert.Null(result[3]);
        Assert.Equal(1.0, result[4], 15);
    }

    [Fact]
    public void Sins_ParamsOverload_CalculatesAllValues()
    {
        // Act
        var result = YANMath.Sins<double>(0.0, Math.PI / 6, Math.PI / 4, Math.PI / 3, Math.PI / 2)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(0.0, result![0], 15);
        Assert.Equal(0.5, result[1], 15);
        Assert.Equal(0.7071067811865475, result[2], 15);
        Assert.Equal(0.8660254037844386, result[3], 15);
        Assert.Equal(1.0, result[4], 15);
    }

    #endregion

    #region Cos

    [Fact]
    public void Cos_NullInput_ReturnsNull()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Cos<double?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Cos_Zero_ReturnsOne()
    {
        // Arrange
        double input = 0.0;

        // Act
        var result = input.Cos<double>();

        // Assert
        Assert.Equal(1.0, result);
    }

    [Fact]
    public void Cos_PiDividedBy2_ReturnsZero()
    {
        // Arrange
        double input = Math.PI / 2;

        // Act
        var result = input.Cos<double>();

        // Assert
        Assert.Equal(0.0, result, 15);
    }

    [Fact]
    public void Cos_Pi_ReturnsMinusOne()
    {
        // Arrange
        double input = Math.PI;

        // Act
        var result = input.Cos<double>();

        // Assert
        Assert.Equal(-1.0, result, 15);
    }

    [Fact]
    public void Cos_StringInput_ConvertsAndCalculates()
    {
        // Arrange
        string input = "0";

        // Act
        var result = input.Cos<double>();

        // Assert
        Assert.Equal(1.0, result);
    }

    [Fact]
    public void Cos_DoubleToInt_CalculatesAndConverts()
    {
        // Arrange
        double input = 0.0;

        // Act
        var result = input.Cos<int>();

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void Coss_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<double?>? input = null;

        // Act
        var result = input.Coss<double?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Coss_EmptyCollection_ReturnsEmptyCollection()
    {
        // Arrange
        var input = Array.Empty<double?>();

        // Act
        var result = input.Coss<double?>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result!);
    }

    [Fact]
    public void Coss_DoubleCollection_CalculatesAllValues()
    {
        // Arrange
        var input = new double?[] { 0.0, Math.PI / 3, Math.PI / 2, Math.PI, Math.PI * 2 };

        // Act
        var result = input.Coss<double>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1.0, result![0], 15);
        Assert.Equal(0.5, result[1], 15);
        Assert.Equal(0.0, result[2], 15);
        Assert.Equal(-1.0, result[3], 15);
        Assert.Equal(1.0, result[4], 15);
    }

    [Fact]
    public void Coss_CollectionWithNulls_PreservesNulls()
    {
        // Arrange
        var input = new double?[] { 0.0, null, Math.PI / 2, null, Math.PI };

        // Act
        var result = input.Coss<double?>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1.0, result![0], 15);
        Assert.Null(result[1]);
        Assert.Equal(0.0, result[2], 15);
        Assert.Null(result[3]);
        Assert.Equal(-1.0, result[4], 15);
    }

    [Fact]
    public void Coss_ParamsOverload_CalculatesAllValues()
    {
        // Act
        var result = YANMath.Coss<double>(0.0, Math.PI / 3, Math.PI / 2, Math.PI, Math.PI * 2)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1.0, result![0], 15);
        Assert.Equal(0.5, result[1], 15);
        Assert.Equal(0.0, result[2], 15);
        Assert.Equal(-1.0, result[3], 15);
        Assert.Equal(1.0, result[4], 15);
    }

    #endregion

    #region Tan

    [Fact]
    public void Tan_NullInput_ReturnsNull()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Tan<double?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Tan_Zero_ReturnsZero()
    {
        // Arrange
        double input = 0.0;

        // Act
        var result = input.Tan<double>();

        // Assert
        Assert.Equal(0.0, result);
    }

    [Fact]
    public void Tan_PiDividedBy4_ReturnsOne()
    {
        // Arrange
        double input = Math.PI / 4;

        // Act
        var result = input.Tan<double>();

        // Assert
        Assert.Equal(1.0, result, 15);
    }

    [Fact]
    public void Tan_StringInput_ConvertsAndCalculates()
    {
        // Arrange
        string input = (Math.PI / 4).ToString();

        // Act
        var result = input.Tan<double>();

        // Assert
        Assert.Equal(1.0, result, 15);
    }

    [Fact]
    public void Tan_DoubleToInt_CalculatesAndConverts()
    {
        // Arrange
        double input = Math.PI / 4;

        // Act
        var result = input.Tan<int>();

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void Tans_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<double?>? input = null;

        // Act
        var result = input.Tans<double?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Tans_EmptyCollection_ReturnsEmptyCollection()
    {
        // Arrange
        var input = Array.Empty<double?>();

        // Act
        var result = input.Tans<double?>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result!);
    }

    [Fact]
    public void Tans_DoubleCollection_CalculatesAllValues()
    {
        // Arrange
        var input = new double?[] { 0.0, Math.PI / 6, Math.PI / 4, Math.PI / 3 };

        // Act
        var result = input.Tans<double>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(0.0, result![0], 15);
        Assert.Equal(0.5773502691896257, result[1], 15);
        Assert.Equal(1.0, result[2], 15);
        Assert.Equal(1.7320508075688767, result[3], 15);
    }

    [Fact]
    public void Tans_CollectionWithNulls_PreservesNulls()
    {
        // Arrange
        var input = new double?[] { 0.0, null, Math.PI / 4, null };

        // Act
        var result = input.Tans<double?>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(0.0, result![0], 15);
        Assert.Null(result[1]);
        Assert.Equal(1.0, result[2], 15);
        Assert.Null(result[3]);
    }

    [Fact]
    public void Tans_ParamsOverload_CalculatesAllValues()
    {
        // Act
        var result = YANMath.Tans<double>(0.0, Math.PI / 6, Math.PI / 4, Math.PI / 3)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(0.0, result![0], 15);
        Assert.Equal(0.5773502691896257, result[1], 15);
        Assert.Equal(1.0, result[2], 15);
        Assert.Equal(1.7320508075688767, result[3], 15);
    }

    #endregion

    #region Asin

    [Fact]
    public void Asin_NullInput_ReturnsNull()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Asin<double?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Asin_Zero_ReturnsZero()
    {
        // Arrange
        double input = 0.0;

        // Act
        var result = input.Asin<double>();

        // Assert
        Assert.Equal(0.0, result);
    }

    [Fact]
    public void Asin_One_ReturnsPiDividedBy2()
    {
        // Arrange
        double input = 1.0;

        // Act
        var result = input.Asin<double>();

        // Assert
        Assert.Equal(Math.PI / 2, result);
    }

    [Fact]
    public void Asin_StringInput_ConvertsAndCalculates()
    {
        // Arrange
        string input = "0";

        // Act
        var result = input.Asin<double>();

        // Assert
        Assert.Equal(0.0, result);
    }

    [Fact]
    public void Asin_DoubleToInt_CalculatesAndConverts()
    {
        // Arrange
        double input = 1.0;

        // Act
        var result = input.Asin<int>();

        // Assert
        Assert.Equal((int)(Math.PI / 2), result);
    }

    [Fact]
    public void Asins_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<double?>? input = null;

        // Act
        var result = input.Asins<double?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Asins_EmptyCollection_ReturnsEmptyCollection()
    {
        // Arrange
        var input = Array.Empty<double?>();

        // Act
        var result = input.Asins<double?>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result!);
    }

    [Fact]
    public void Asins_DoubleCollection_CalculatesAllValues()
    {
        // Arrange
        var input = new double?[] { 0.0, 0.5, 0.7071067811865475, 0.8660254037844386, 1.0 };

        // Act
        var result = input.Asins<double>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(0.0, result![0], 15);
        Assert.Equal(Math.PI / 6, result[1], 15);
        Assert.Equal(Math.PI / 4, result[2], 15);
        Assert.Equal(Math.PI / 3, result[3], 15);
        Assert.Equal(Math.PI / 2, result[4], 15);
    }

    [Fact]
    public void Asins_CollectionWithNulls_PreservesNulls()
    {
        // Arrange
        var input = new double?[] { 0.0, null, 0.7071067811865475, null, 1.0 };

        // Act
        var result = input.Asins<double?>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(0.0, result![0], 15);
        Assert.Null(result[1]);
        Assert.Equal(Math.PI / 4, result[2], 15);
        Assert.Null(result[3]);
        Assert.Equal(Math.PI / 2, result[4], 15);
    }

    [Fact]
    public void Asins_ParamsOverload_CalculatesAllValues()
    {
        // Act
        var result = YANMath.Asins<double>(0.0, 0.5, 0.7071067811865475, 0.8660254037844386, 1.0)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(0.0, result![0], 15);
        Assert.Equal(Math.PI / 6, result[1], 15);
        Assert.Equal(Math.PI / 4, result[2], 15);
        Assert.Equal(Math.PI / 3, result[3], 15);
        Assert.Equal(Math.PI / 2, result[4], 15);
    }

    #endregion

    #region Acos

    [Fact]
    public void Acos_NullInput_ReturnsNull()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Acos<double?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Acos_One_ReturnsZero()
    {
        // Arrange
        double input = 1.0;

        // Act
        var result = input.Acos<double>();

        // Assert
        Assert.Equal(0.0, result);
    }

    [Fact]
    public void Acos_Zero_ReturnsPiDividedBy2()
    {
        // Arrange
        double input = 0.0;

        // Act
        var result = input.Acos<double>();

        // Assert
        Assert.Equal(Math.PI / 2, result);
    }

    [Fact]
    public void Acos_MinusOne_ReturnsPi()
    {
        // Arrange
        double input = -1.0;

        // Act
        var result = input.Acos<double>();

        // Assert
        Assert.Equal(Math.PI, result);
    }

    [Fact]
    public void Acos_StringInput_ConvertsAndCalculates()
    {
        // Arrange
        string input = "1";

        // Act
        var result = input.Acos<double>();

        // Assert
        Assert.Equal(0.0, result);
    }

    [Fact]
    public void Acos_DoubleToInt_CalculatesAndConverts()
    {
        // Arrange
        double input = -1.0;

        // Act
        var result = input.Acos<int>();

        // Assert
        Assert.Equal((int)Math.PI, result);
    }

    [Fact]
    public void Acoss_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<double?>? input = null;

        // Act
        var result = input.Acoss<double?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Acoss_EmptyCollection_ReturnsEmptyCollection()
    {
        // Arrange
        var input = Array.Empty<double?>();

        // Act
        var result = input.Acoss<double?>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result!);
    }

    [Fact]
    public void Acoss_DoubleCollection_CalculatesAllValues()
    {
        // Arrange
        var input = new double?[] { 1.0, 0.5, 0.0, -0.5, -1.0 };

        // Act
        var result = input.Acoss<double>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(0.0, result![0], 15);
        Assert.Equal(Math.PI / 3, result[1], 15);
        Assert.Equal(Math.PI / 2, result[2], 15);
        Assert.Equal(2 * Math.PI / 3, result[3], 15);
        Assert.Equal(Math.PI, result[4], 15);
    }

    [Fact]
    public void Acoss_CollectionWithNulls_PreservesNulls()
    {
        // Arrange
        var input = new double?[] { 1.0, null, 0.0, null, -1.0 };

        // Act
        var result = input.Acoss<double?>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(0.0, result![0], 15);
        Assert.Null(result[1]);
        Assert.Equal(Math.PI / 2, result[2], 15);
        Assert.Null(result[3]);
        Assert.Equal(Math.PI, result[4], 15);
    }

    [Fact]
    public void Acoss_ParamsOverload_CalculatesAllValues()
    {
        // Act
        var result = YANMath.Acoss<double>(1.0, 0.5, 0.0, -0.5, -1.0)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(0.0, result![0], 15);
        Assert.Equal(Math.PI / 3, result[1], 15);
        Assert.Equal(Math.PI / 2, result[2], 15);
        Assert.Equal(2 * Math.PI / 3, result[3], 15);
        Assert.Equal(Math.PI, result[4], 15);
    }

    #endregion

    #region Atan

    [Fact]
    public void Atan_NullInput_ReturnsNull()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Atan<double?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Atan_Zero_ReturnsZero()
    {
        // Arrange
        double input = 0.0;

        // Act
        var result = input.Atan<double>();

        // Assert
        Assert.Equal(0.0, result);
    }

    [Fact]
    public void Atan_One_ReturnsPiDividedBy4()
    {
        // Arrange
        double input = 1.0;

        // Act
        var result = input.Atan<double>();

        // Assert
        Assert.Equal(Math.PI / 4, result);
    }

    [Fact]
    public void Atan_StringInput_ConvertsAndCalculates()
    {
        // Arrange
        string input = "1";

        // Act
        var result = input.Atan<double>();

        // Assert
        Assert.Equal(Math.PI / 4, result);
    }

    [Fact]
    public void Atan_DoubleToInt_CalculatesAndConverts()
    {
        // Arrange
        double input = 1.0;

        // Act
        var result = input.Atan<int>();

        // Assert
        Assert.Equal((int)(Math.PI / 4), result);
    }

    [Fact]
    public void Atans_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<double?>? input = null;

        // Act
        var result = input.Atans<double?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Atans_EmptyCollection_ReturnsEmptyCollection()
    {
        // Arrange
        var input = Array.Empty<double?>();

        // Act
        var result = input.Atans<double?>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result!);
    }

    [Fact]
    public void Atans_DoubleCollection_CalculatesAllValues()
    {
        // Arrange
        var input = new double?[] { 0.0, 0.5773502691896257, 1.0, 1.7320508075688767 };

        // Act
        var result = input.Atans<double>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(0.0, result![0], 15);
        Assert.Equal(Math.PI / 6, result[1], 15);
        Assert.Equal(Math.PI / 4, result[2], 15);
        Assert.Equal(Math.PI / 3, result[3], 15);
    }

    [Fact]
    public void Atans_CollectionWithNulls_PreservesNulls()
    {
        // Arrange
        var input = new double?[] { 0.0, null, 1.0, null };

        // Act
        var result = input.Atans<double?>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(0.0, result![0], 15);
        Assert.Null(result[1]);
        Assert.Equal(Math.PI / 4, result[2], 15);
        Assert.Null(result[3]);
    }

    [Fact]
    public void Atans_ParamsOverload_CalculatesAllValues()
    {
        // Act
        var result = YANMath.Atans<double>(0.0, 0.5773502691896257, 1.0, 1.7320508075688767)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(0.0, result![0], 15);
        Assert.Equal(Math.PI / 6, result[1], 15);
        Assert.Equal(Math.PI / 4, result[2], 15);
        Assert.Equal(Math.PI / 3, result[3], 15);
    }

    #endregion

    #region Cbrt

    [Fact]
    public void Cbrt_NullInput_ReturnsNull()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Cbrt<double?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Cbrt_PositiveNumber_ReturnsCubeRoot()
    {
        // Arrange
        double input = 27.0;

        // Act
        var result = input.Cbrt<double>();

        // Assert
        Assert.Equal(3.0, result);
    }

    [Fact]
    public void Cbrt_NegativeNumber_ReturnsNegativeCubeRoot()
    {
        // Arrange
        double input = -27.0;

        // Act
        var result = input.Cbrt<double>();

        // Assert
        Assert.Equal(-3.0, result);
    }

    [Fact]
    public void Cbrt_Zero_ReturnsZero()
    {
        // Arrange
        double input = 0.0;

        // Act
        var result = input.Cbrt<double>();

        // Assert
        Assert.Equal(0.0, result);
    }

    [Fact]
    public void Cbrt_StringInput_ConvertsAndCalculates()
    {
        // Arrange
        string input = "27";

        // Act
        var result = input.Cbrt<double>();

        // Assert
        Assert.Equal(3.0, result);
    }

    [Fact]
    public void Cbrt_DoubleToInt_CalculatesAndConverts()
    {
        // Arrange
        double input = 27.0;

        // Act
        var result = input.Cbrt<int>();

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void Cbrts_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<double?>? input = null;

        // Act
        var result = input.Cbrts<double?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Cbrts_EmptyCollection_ReturnsEmptyCollection()
    {
        // Arrange
        var input = Array.Empty<double?>();

        // Act
        var result = input.Cbrts<double?>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result!);
    }

    [Fact]
    public void Cbrts_DoubleCollection_CalculatesAllValues()
    {
        // Arrange
        var input = new double?[] { 8.0, 27.0, 64.0, 125.0 };

        // Act
        var result = input.Cbrts<double>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2.0, result![0], 15);
        Assert.Equal(3.0, result[1], 15);
        Assert.Equal(4.0, result[2], 15);
        Assert.Equal(5.0, result[3], 15);
    }

    [Fact]
    public void Cbrts_CollectionWithNulls_PreservesNulls()
    {
        // Arrange
        var input = new double?[] { 8.0, null, 64.0, null };

        // Act
        var result = input.Cbrts<double?>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2.0, result![0], 15);
        Assert.Null(result[1]);
        Assert.Equal(4.0, result[2], 15);
        Assert.Null(result[3]);
    }

    [Fact]
    public void Cbrts_ParamsOverload_CalculatesAllValues()
    {
        // Act
        var result = YANMath.Cbrts<double>(8.0, 27.0, 64.0, 125.0)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2.0, result![0], 15);
        Assert.Equal(3.0, result[1], 15);
        Assert.Equal(4.0, result[2], 15);
        Assert.Equal(5.0, result[3], 15);
    }

    #endregion

    #region Exp

    [Fact]
    public void Exp_NullInput_ReturnsNull()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Exp<double?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Exp_Zero_ReturnsOne()
    {
        // Arrange
        double input = 0.0;

        // Act
        var result = input.Exp<double>();

        // Assert
        Assert.Equal(1.0, result);
    }

    [Fact]
    public void Exp_One_ReturnsE()
    {
        // Arrange
        double input = 1.0;

        // Act
        var result = input.Exp<double>();

        // Assert
        Assert.Equal(Math.E, result);
    }

    [Fact]
    public void Exp_StringInput_ConvertsAndCalculates()
    {
        // Arrange
        string input = "1";

        // Act
        var result = input.Exp<double>();

        // Assert
        Assert.Equal(Math.E, result);
    }

    [Fact]
    public void Exp_DoubleToInt_CalculatesAndConverts()
    {
        // Arrange
        double input = 1.0;

        // Act
        var result = input.Exp<int>();

        // Assert
        Assert.Equal((int)Math.E, result);
    }

    [Fact]
    public void Exps_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<double?>? input = null;

        // Act
        var result = input.Exps<double?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Exps_EmptyCollection_ReturnsEmptyCollection()
    {
        // Arrange
        var input = Array.Empty<double?>();

        // Act
        var result = input.Exps<double?>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result!);
    }

    [Fact]
    public void Exps_DoubleCollection_CalculatesAllValues()
    {
        // Arrange
        var input = new double?[] { 0.0, 1.0, 2.0 };

        // Act
        var result = input.Exps<double>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1.0, result![0], 15);
        Assert.Equal(Math.E, result[1], 15);
        Assert.Equal(Math.E * Math.E, result[2], 15);
    }

    [Fact]
    public void Exps_CollectionWithNulls_PreservesNulls()
    {
        // Arrange
        var input = new double?[] { 0.0, null, 2.0, null };

        // Act
        var result = input.Exps<double?>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1.0, result![0], 15);
        Assert.Null(result[1]);
        Assert.Equal(Math.E * Math.E, result[2], 15);
        Assert.Null(result[3]);
    }

    [Fact]
    public void Exps_ParamsOverload_CalculatesAllValues()
    {
        // Act
        var result = YANMath.Exps<double>(0.0, 1.0, 2.0)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1.0, result![0], 15);
        Assert.Equal(Math.E, result[1], 15);
        Assert.Equal(Math.E * Math.E, result[2], 15);
    }

    #endregion

    #region Exp2

    [Fact]
    public void Exp2_NullInput_ReturnsNull()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Exp2<double?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Exp2_Zero_ReturnsOne()
    {
        // Arrange
        double input = 0.0;

        // Act
        var result = input.Exp2<double>();

        // Assert
        Assert.Equal(1.0, result);
    }

    [Fact]
    public void Exp2_One_ReturnsTwo()
    {
        // Arrange
        double input = 1.0;

        // Act
        var result = input.Exp2<double>();

        // Assert
        Assert.Equal(2.0, result);
    }

    [Fact]
    public void Exp2_Three_ReturnsEight()
    {
        // Arrange
        double input = 3.0;

        // Act
        var result = input.Exp2<double>();

        // Assert
        Assert.Equal(8.0, result);
    }

    [Fact]
    public void Exp2_StringInput_ConvertsAndCalculates()
    {
        // Arrange
        string input = "3";

        // Act
        var result = input.Exp2<double>();

        // Assert
        Assert.Equal(8.0, result);
    }

    [Fact]
    public void Exp2_DoubleToInt_CalculatesAndConverts()
    {
        // Arrange
        double input = 3.0;

        // Act
        var result = input.Exp2<int>();

        // Assert
        Assert.Equal(8, result);
    }

    [Fact]
    public void Exp2s_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<double?>? input = null;

        // Act
        var result = input.Exp2s<double?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Exp2s_EmptyCollection_ReturnsEmptyCollection()
    {
        // Arrange
        var input = Array.Empty<double?>();

        // Act
        var result = input.Exp2s<double?>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result!);
    }

    [Fact]
    public void Exp2s_DoubleCollection_CalculatesAllValues()
    {
        // Arrange
        var input = new double?[] { 0.0, 1.0, 2.0, 3.0, 4.0 };

        // Act
        var result = input.Exp2s<double>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1.0, result![0], 15);
        Assert.Equal(2.0, result[1], 15);
        Assert.Equal(4.0, result[2], 15);
        Assert.Equal(8.0, result[3], 15);
        Assert.Equal(16.0, result[4], 15);
    }

    [Fact]
    public void Exp2s_CollectionWithNulls_PreservesNulls()
    {
        // Arrange
        var input = new double?[] { 0.0, null, 2.0, null, 4.0 };

        // Act
        var result = input.Exp2s<double?>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1.0, result![0], 15);
        Assert.Null(result[1]);
        Assert.Equal(4.0, result[2], 15);
        Assert.Null(result[3]);
        Assert.Equal(16.0, result[4], 15);
    }

    [Fact]
    public void Exp2s_ParamsOverload_CalculatesAllValues()
    {
        // Act
        var result = YANMath.Exp2s<double>(0.0, 1.0, 2.0, 3.0, 4.0)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1.0, result![0], 15);
        Assert.Equal(2.0, result[1], 15);
        Assert.Equal(4.0, result[2], 15);
        Assert.Equal(8.0, result[3], 15);
        Assert.Equal(16.0, result[4], 15);
    }

    #endregion

    #region ILogB

    [Fact]
    public void ILogB_NullInput_ReturnsNull()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.ILogB<int?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ILogB_PositiveNumber_ReturnsExponent()
    {
        // Arrange
        double input = 8.0;

        // Act
        var result = input.ILogB<int>();

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void ILogB_NegativeNumber_ReturnsExponent()
    {
        // Arrange
        double input = -8.0;

        // Act
        var result = input.ILogB<int>();

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void ILogB_Zero_ReturnsMinValue()
    {
        // Arrange
        double input = 0.0;

        // Act
        var result = input.ILogB<int>();

        // Assert
        Assert.Equal(int.MinValue, result);
    }

    [Fact]
    public void ILogB_StringInput_ConvertsAndCalculates()
    {
        // Arrange
        string input = "8";

        // Act
        var result = input.ILogB<int>();

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void ILogB_DoubleToLong_CalculatesAndConverts()
    {
        // Arrange
        double input = 8.0;

        // Act
        var result = input.ILogB<long>();

        // Assert
        Assert.Equal(3L, result);
    }

    [Fact]
    public void ILogBs_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<double?>? input = null;

        // Act
        var result = input.ILogBs<int?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ILogBs_EmptyCollection_ReturnsEmptyCollection()
    {
        // Arrange
        var input = Array.Empty<double?>();

        // Act
        var result = input.ILogBs<int?>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result!);
    }

    [Fact]
    public void ILogBs_DoubleCollection_CalculatesAllValues()
    {
        // Arrange
        var input = new double?[] { 2.0, 4.0, 8.0, 16.0, 32.0 };

        // Act
        var result = input.ILogBs<int>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new int[] { 1, 2, 3, 4, 5 }, result);
    }

    [Fact]
    public void ILogBs_CollectionWithNulls_PreservesNulls()
    {
        // Arrange
        var input = new double?[] { 2.0, null, 8.0, null, 32.0 };

        // Act
        var result = input.ILogBs<int?>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new int?[] { 1, null, 3, null, 5 }, result);
    }

    [Fact]
    public void ILogBs_ParamsOverload_CalculatesAllValues()
    {
        // Act
        var result = YANMath.ILogBs<int>(2.0, 4.0, 8.0, 16.0, 32.0)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new int[] { 1, 2, 3, 4, 5 }, result);
    }

    #endregion

    #region Edge Cases

    [Fact]
    public void Sqrt_NegativeNumber_ReturnsNaN()
    {
        // Arrange
        double input = -4.0;

        // Act
        var result = input.Sqrt<double>();

        // Assert
        Assert.True(double.IsNaN(result));
    }

    [Fact]
    public void Log_NegativeNumber_ReturnsNaN()
    {
        // Arrange
        double input = -1.0;

        // Act
        var result = input.Log<double>();

        // Assert
        Assert.True(double.IsNaN(result));
    }

    [Fact]
    public void Log_Zero_ReturnsNegativeInfinity()
    {
        // Arrange
        double input = 0.0;

        // Act
        var result = input.Log<double>();

        // Assert
        Assert.True(double.IsNegativeInfinity(result));
    }

    [Fact]
    public void Asin_GreaterThanOne_ReturnsNaN()
    {
        // Arrange
        double input = 1.1;

        // Act
        var result = input.Asin<double>();

        // Assert
        Assert.True(double.IsNaN(result));
    }

    [Fact]
    public void Acos_GreaterThanOne_ReturnsNaN()
    {
        // Arrange
        double input = 1.1;

        // Act
        var result = input.Acos<double>();

        // Assert
        Assert.True(double.IsNaN(result));
    }

    [Fact]
    public void Tan_PiDividedBy2_ReturnsVeryLargeNumber()
    {
        // Arrange
        double input = Math.PI / 2;

        // Act
        var result = input.Tan<double>();

        // Assert
        // Due to floating-point precision, this will be a very large number but not infinity
        Assert.True(Math.Abs(result) > 1e14);
    }

    #endregion

    #region Type Conversion

    [Fact]
    public void Min_IntToDecimal_ReturnsDecimal()
    {
        // Arrange
        var input = new int?[] { 5, 2, 8, 1, 9 };

        // Act
        var result = input.Min<decimal>();

        // Assert
        Assert.Equal(1m, result);
        Assert.IsType<decimal>(result);
    }

    [Fact]
    public void Max_IntToFloat_ReturnsFloat()
    {
        // Arrange
        var input = new int?[] { 5, 2, 8, 1, 9 };

        // Act
        var result = input.Max<float>();

        // Assert
        Assert.Equal(9f, result);
        Assert.IsType<float>(result);
    }

    [Fact]
    public void Average_IntToDouble_ReturnsDouble()
    {
        // Arrange
        var input = new int?[] { 1, 2, 3, 4, 5 };

        // Act
        var result = input.Average<double>();

        // Assert
        Assert.Equal(3.0, result);
        Assert.IsType<double>(result);
    }

    [Fact]
    public void Sum_DoubleToLong_ReturnsLong()
    {
        // Arrange
        var input = new double?[] { 1.1, 2.2, 3.3, 4.4, 5.5 };

        // Act
        var result = input.Sum<long>();

        // Assert
        Assert.Equal(16L, result);
        Assert.IsType<long>(result);
    }

    [Fact]
    public void Sqrt_IntToDecimal_ReturnsDecimal()
    {
        // Arrange
        int input = 16;

        // Act
        var result = input.Sqrt<decimal>();

        // Assert
        Assert.Equal(4m, result);
        Assert.IsType<decimal>(result);
    }

    [Fact]
    public void Sin_DoubleToString_ReturnsString()
    {
        // Arrange
        double input = 0.0;

        // Act
        var result = input.Sin<string>();

        // Assert
        Assert.Equal("0", result);
        Assert.IsType<string>(result);
    }

    #endregion
}
