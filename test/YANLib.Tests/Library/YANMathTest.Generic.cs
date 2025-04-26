//using YANLib.Unmanaged;

//namespace YANLib.Tests.Library;

//public partial class YANMathTest
//{
//    #region Min

//    [Fact]
//    public void Min_NullCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        IEnumerable<object?>? input = null;

//        // Act
//        var result = input.Min<int?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Min_EmptyCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        var input = Array.Empty<object?>();

//        // Act
//        var result = input.Min<int?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Min_IntCollection_ReturnsMinValue_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 5, 2, 8, 1, 9 };

//        // Act
//        var result = input.Min<int>();

//        // Assert
//        Assert.Equal(1, result);
//    }

//    [Fact]
//    public void Min_DoubleCollection_ReturnsMinValue_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 5.5, 2.2, 8.8, 1.1, 9.9 };

//        // Act
//        var result = input.Min<double>();

//        // Assert
//        Assert.Equal(1.1, result);
//    }

//    [Fact]
//    public void Min_MixedCollection_ReturnsMinValue_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 5, 2.2, "8", 1, "9.9" };

//        // Act
//        var result = input.Min<double>();

//        // Assert
//        Assert.Equal(1.0, result);
//    }

//    [Fact]
//    public void Min_CollectionWithNulls_IgnoresNulls_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 5, null, 8, 1, null };

//        // Act
//        var result = input.Min<int>();

//        // Assert
//        Assert.Equal(1, result);
//    }

//    [Fact]
//    public void Min_ParamsOverload_ReturnsMinValue_Generic()
//    {
//        // Act
//        var result = YANMath.Min(5, 2, 8, 1, 9);

//        // Assert
//        Assert.Equal(1, result);
//    }

//    [Fact]
//    public void Min_ParamsWithNulls_IgnoresNulls_Generic()
//    {
//        // Act
//        var result = YANMath.Min<int?>(5, null, 8, 1, null);

//        // Assert
//        Assert.Equal(1, result);
//    }

//    [Fact]
//    public void Min_StringValues_ConvertsAndReturnsMinValue_Generic()
//    {
//        // Arrange
//        var input = new object?[] { "5", "2", "8", "1", "9" };

//        // Act
//        var result = input.Min<int>();

//        // Assert
//        Assert.Equal(1, result);
//    }

//    #endregion

//    #region Max

//    [Fact]
//    public void Max_NullCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        IEnumerable<object?>? input = null;

//        // Act
//        var result = input.Max<int?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Max_EmptyCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        var input = Array.Empty<object?>();

//        // Act
//        var result = input.Max<int?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Max_IntCollection_ReturnsMaxValue_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 5, 2, 8, 1, 9 };

//        // Act
//        var result = input.Max<int>();

//        // Assert
//        Assert.Equal(9, result);
//    }

//    [Fact]
//    public void Max_DoubleCollection_ReturnsMaxValue_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 5.5, 2.2, 8.8, 1.1, 9.9 };

//        // Act
//        var result = input.Max<double>();

//        // Assert
//        Assert.Equal(9.9, result);
//    }

//    [Fact]
//    public void Max_MixedCollection_ReturnsMaxValue_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 5, 2.2, "8", 1, "9.9" };

//        // Act
//        var result = input.Max<double>();

//        // Assert
//        Assert.Equal(9.9, result);
//    }

//    [Fact]
//    public void Max_CollectionWithNulls_IgnoresNulls_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 5, null, 8, 1, null };

//        // Act
//        var result = input.Max<int>();

//        // Assert
//        Assert.Equal(8, result);
//    }

//    [Fact]
//    public void Max_ParamsOverload_ReturnsMaxValue_Generic()
//    {
//        // Act
//        var result = YANMath.Max(5, 2, 8, 1, 9);

//        // Assert
//        Assert.Equal(9, result);
//    }

//    [Fact]
//    public void Max_ParamsWithNulls_IgnoresNulls_Generic()
//    {
//        // Act
//        var result = YANMath.Max<int?>(5, null, 8, 1, null);

//        // Assert
//        Assert.Equal(8, result);
//    }

//    [Fact]
//    public void Max_StringValues_ConvertsAndReturnsMaxValue_Generic()
//    {
//        // Arrange
//        var input = new object?[] { "5", "2", "8", "1", "9" };

//        // Act
//        var result = input.Max<int>();

//        // Assert
//        Assert.Equal(9, result);
//    }

//    #endregion

//    #region Average

//    [Fact]
//    public void Average_NullCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        IEnumerable<object?>? input = null;

//        // Act
//        var result = input.Average<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Average_EmptyCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        var input = Array.Empty<object?>();

//        // Act
//        var result = input.Average<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Average_IntCollection_ReturnsAverage_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 2, 4, 6, 8, 10 };

//        // Act
//        var result = input.Average<double>();

//        // Assert
//        Assert.Equal(6.0, result);
//    }

//    [Fact]
//    public void Average_DoubleCollection_ReturnsAverage_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 1.5, 2.5, 3.5, 4.5, 5.5 };

//        // Act
//        var result = input.Average<double>();

//        // Assert
//        Assert.Equal(3.5, result);
//    }

//    [Fact]
//    public void Average_MixedCollection_ReturnsAverage_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 1, 2.5, "3", 4.5, "5" };

//        // Act
//        var result = input.Average<double>();

//        // Assert
//        Assert.Equal(3.2, result);
//    }

//    [Fact]
//    public void Average_CollectionWithNulls_IgnoresNulls_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 2, null, 6, 8, null };

//        // Act
//        var result = input.Average<double>();

//        // Assert
//        Assert.Equal(5.333333333333333, result, 15);
//    }

//    [Fact]
//    public void Average_ParamsOverload_ReturnsAverage_Generic()
//    {
//        // Act
//        var result = YANMath.Average<double>(2, 4, 6, 8, 10);

//        // Assert
//        Assert.Equal(6.0, result);
//    }

//    [Fact]
//    public void Average_ParamsWithNulls_IgnoresNulls_Generic()
//    {
//        // Act
//        var result = YANMath.Average<double>(2, null, 6, 8, null);

//        // Assert
//        Assert.Equal(5.333333333333333, result, 15);
//    }

//    [Fact]
//    public void Average_IntToInt_ReturnsRoundedAverage_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 1, 2, 3, 4, 5 };

//        // Act
//        var result = input.Average<int>();

//        // Assert
//        Assert.Equal(3, result);
//    }

//    [Fact]
//    public void Average_StringValues_ConvertsAndReturnsAverage_Generic()
//    {
//        // Arrange
//        var input = new object?[] { "1", "2", "3", "4", "5" };

//        // Act
//        var result = input.Average<double>();

//        // Assert
//        Assert.Equal(3.0, result);
//    }

//    #endregion

//    #region Sum

//    [Fact]
//    public void Sum_NullCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        IEnumerable<object?>? input = null;

//        // Act
//        var result = input.Sum<int?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Sum_EmptyCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        var input = Array.Empty<object?>();

//        // Act
//        var result = input.Sum<int?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Sum_IntCollection_ReturnsSum_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 1, 2, 3, 4, 5 };

//        // Act
//        var result = input.Sum<int>();

//        // Assert
//        Assert.Equal(15, result);
//    }

//    [Fact]
//    public void Sum_DoubleCollection_ReturnsSum_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 1.1, 2.2, 3.3, 4.4, 5.5 };

//        // Act
//        var result = input.Sum<double>();

//        // Assert
//        Assert.Equal(16.5, result);
//    }

//    [Fact]
//    public void Sum_MixedCollection_ReturnsSum_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 1, 2.2, "3", 4.4, "5" };

//        // Act
//        var result = input.Sum<double>();

//        // Assert
//        Assert.Equal(15.6, result.Round(1));
//    }

//    [Fact]
//    public void Sum_CollectionWithNulls_TreatsNullsAsZero_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 1, null, 3, 4, null };

//        // Act
//        var result = input.Sum<int>();

//        // Assert
//        Assert.Equal(8, result);
//    }

//    [Fact]
//    public void Sum_ParamsOverload_ReturnsSum_Generic()
//    {
//        // Act
//        var result = YANMath.Sum(1, 2, 3, 4, 5);

//        // Assert
//        Assert.Equal(15, result);
//    }

//    [Fact]
//    public void Sum_ParamsWithNulls_TreatsNullsAsZero_Generic()
//    {
//        // Act
//        var result = YANMath.Sum<int>(1, null, 3, 4, null);

//        // Assert
//        Assert.Equal(8, result);
//    }

//    [Fact]
//    public void Sum_StringValues_ConvertsAndReturnsSum_Generic()
//    {
//        // Arrange
//        var input = new object?[] { "1", "2", "3", "4", "5" };

//        // Act
//        var result = input.Sum<int>();

//        // Assert
//        Assert.Equal(15, result);
//    }

//    #endregion

//    #region Truncate

//    [Fact]
//    public void Truncate_NullInput_ReturnsNull_Generic()
//    {
//        // Arrange
//        object? input = null;

//        // Act
//        var result = input.Truncate<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Truncate_PositiveDouble_RemovesFractionalPart_Generic()
//    {
//        // Arrange
//        object input = 3.75;

//        // Act
//        var result = input.Truncate<double>();

//        // Assert
//        Assert.Equal(3.0, result);
//    }

//    [Fact]
//    public void Truncate_NegativeDouble_RemovesFractionalPart_Generic()
//    {
//        // Arrange
//        object input = -3.75;

//        // Act
//        var result = input.Truncate<double>();

//        // Assert
//        Assert.Equal(-3.0, result);
//    }

//    [Fact]
//    public void Truncate_IntegerValue_ReturnsSameValue_Generic()
//    {
//        // Arrange
//        object input = 5.0;

//        // Act
//        var result = input.Truncate<double>();

//        // Assert
//        Assert.Equal(5.0, result);
//    }

//    [Fact]
//    public void Truncate_StringInput_ConvertsAndTruncates_Generic()
//    {
//        // Arrange
//        object input = "3.75";

//        // Act
//        var result = input.Truncate<double>();

//        // Assert
//        Assert.Equal(3.0, result);
//    }

//    [Fact]
//    public void Truncate_DoubleToInt_TruncatesAndConverts_Generic()
//    {
//        // Arrange
//        object input = 3.75;

//        // Act
//        var result = input.Truncate<int>();

//        // Assert
//        Assert.Equal(3, result);
//    }

//    [Fact]
//    public void Truncates_NullCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        IEnumerable<object?>? input = null;

//        // Act
//        var result = input.Truncates<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Truncates_EmptyCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        var input = Array.Empty<object?>();

//        // Act
//        var result = input.Truncates<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Truncates_DoubleCollection_TruncatesAllValues_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 1.1, 2.7, 3.5, 4.9, 5.0 };
//        var expected = new double[] { 1.0, 2.0, 3.0, 4.0, 5.0 };

//        // Act
//        var result = input.Truncates<double>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(expected, result);
//    }

//    [Fact]
//    public void Truncates_CollectionWithNulls_PreservesNulls_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 1.1, null, 3.5, null, 5.0 };

//        // Act
//        var result = input.Truncates<double?>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal([1.0, null, 3.0, null, 5.0], result);
//    }

//    [Fact]
//    public void Truncates_ParamsOverload_TruncatesAllValues_Generic()
//    {
//        // Arrange
//        var expected = new double[] { 1.0, 2.0, 3.0, 4.0, 5.0 };

//        // Act
//        var result = YANMath.Truncates(1.1, 2.7, 3.5, 4.9, 5.0)?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(expected, result);
//    }

//    [Fact]
//    public void Truncates_StringValues_ConvertsAndTruncates_Generic()
//    {
//        // Arrange
//        var input = new object?[] { "1.1", "2.7", "3.5", "4.9", "5.0" };
//        var expected = new double[] { 1.0, 2.0, 3.0, 4.0, 5.0 };

//        // Act
//        var result = input.Truncates<double>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(expected, result);
//    }

//    #endregion

//    #region Ceiling

//    [Fact]
//    public void Ceiling_NullInput_ReturnsNull_Generic()
//    {
//        // Arrange
//        object? input = null;

//        // Act
//        var result = input.Ceiling<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Ceiling_PositiveDouble_ReturnsCeiling_Generic()
//    {
//        // Arrange
//        object input = 3.4;

//        // Act
//        var result = input.Ceiling<double>();

//        // Assert
//        Assert.Equal(4.0, result);
//    }

//    [Fact]
//    public void Ceiling_NegativeDouble_ReturnsCeiling_Generic()
//    {
//        // Arrange
//        object input = -3.4;

//        // Act
//        var result = input.Ceiling<double>();

//        // Assert
//        Assert.Equal(-3.0, result);
//    }

//    [Fact]
//    public void Ceiling_IntegerValue_ReturnsSameValue_Generic()
//    {
//        // Arrange
//        object input = 5.0;

//        // Act
//        var result = input.Ceiling<double>();

//        // Assert
//        Assert.Equal(5.0, result);
//    }

//    [Fact]
//    public void Ceiling_StringInput_ConvertsAndReturnsCeiling_Generic()
//    {
//        // Arrange
//        object input = "3.4";

//        // Act
//        var result = input.Ceiling<double>();

//        // Assert
//        Assert.Equal(4.0, result);
//    }

//    [Fact]
//    public void Ceiling_DoubleToInt_CeilsAndConverts_Generic()
//    {
//        // Arrange
//        object input = 3.4;

//        // Act
//        var result = input.Ceiling<int>();

//        // Assert
//        Assert.Equal(4, result);
//    }

//    [Fact]
//    public void Ceilings_NullCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        IEnumerable<object?>? input = null;

//        // Act
//        var result = input.Ceilings<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Ceilings_EmptyCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        var input = Array.Empty<object?>();

//        // Act
//        var result = input.Ceilings<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Ceilings_DoubleCollection_CeilsAllValues_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 1.1, 2.7, 3.5, 4.9, 5.0 };

//        // Act
//        var result = input.Ceilings<double>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(new double[] { 2.0, 3.0, 4.0, 5.0, 5.0 }, result);
//    }

//    [Fact]
//    public void Ceilings_CollectionWithNulls_PreservesNulls_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 1.1, null, 3.5, null, 5.0 };

//        // Act
//        var result = input.Ceilings<double?>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(new double?[] { 2.0, null, 4.0, null, 5.0 }, result);
//    }

//    [Fact]
//    public void Ceilings_ParamsOverload_CeilsAllValues_Generic()
//    {
//        // Act
//        var result = YANMath.Ceilings<double>(1.1, 2.7, 3.5, 4.9, 5.0)?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(new double[] { 2.0, 3.0, 4.0, 5.0, 5.0 }, result);
//    }

//    [Fact]
//    public void Ceilings_StringValues_ConvertsAndCeils_Generic()
//    {
//        // Arrange
//        var input = new object?[] { "1.1", "2.7", "3.5", "4.9", "5.0" };

//        // Act
//        var result = input.Ceilings<double>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(new double[] { 2.0, 3.0, 4.0, 5.0, 5.0 }, result);
//    }

//    #endregion

//    #region Floor

//    [Fact]
//    public void Floor_NullInput_ReturnsNull_Generic()
//    {
//        // Arrange
//        object? input = null;

//        // Act
//        var result = input.Floor<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Floor_PositiveDouble_ReturnsFloor_Generic()
//    {
//        // Arrange
//        object input = 3.7;

//        // Act
//        var result = input.Floor<double>();

//        // Assert
//        Assert.Equal(3.0, result);
//    }

//    [Fact]
//    public void Floor_NegativeDouble_ReturnsFloor_Generic()
//    {
//        // Arrange
//        object input = -3.7;

//        // Act
//        var result = input.Floor<double>();

//        // Assert
//        Assert.Equal(-4.0, result);
//    }

//    [Fact]
//    public void Floor_IntegerValue_ReturnsSameValue_Generic()
//    {
//        // Arrange
//        object input = 5.0;

//        // Act
//        var result = input.Floor<double>();

//        // Assert
//        Assert.Equal(5.0, result);
//    }

//    [Fact]
//    public void Floor_StringInput_ConvertsAndReturnsFloor_Generic()
//    {
//        // Arrange
//        object input = "3.7";

//        // Act
//        var result = input.Floor<double>();

//        // Assert
//        Assert.Equal(3.0, result);
//    }

//    [Fact]
//    public void Floor_DoubleToInt_FloorsAndConverts_Generic()
//    {
//        // Arrange
//        object input = 3.7;

//        // Act
//        var result = input.Floor<int>();

//        // Assert
//        Assert.Equal(3, result);
//    }

//    [Fact]
//    public void Floors_NullCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        IEnumerable<object?>? input = null;

//        // Act
//        var result = input.Floors<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Floors_EmptyCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        var input = Array.Empty<object?>();

//        // Act
//        var result = input.Floors<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Floors_DoubleCollection_FloorsAllValues_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 1.1, 2.7, 3.5, 4.9, 5.0 };

//        // Act
//        var result = input.Floors<double>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(new double[] { 1.0, 2.0, 3.0, 4.0, 5.0 }, result);
//    }

//    [Fact]
//    public void Floors_CollectionWithNulls_PreservesNulls_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 1.1, null, 3.5, null, 5.0 };

//        // Act
//        var result = input.Floors<double?>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(new double?[] { 1.0, null, 3.0, null, 5.0 }, result);
//    }

//    [Fact]
//    public void Floors_ParamsOverload_FloorsAllValues_Generic()
//    {
//        // Act
//        var result = YANMath.Floors<double>(1.1, 2.7, 3.5, 4.9, 5.0)?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(new double[] { 1.0, 2.0, 3.0, 4.0, 5.0 }, result);
//    }

//    [Fact]
//    public void Floors_StringValues_ConvertsAndFloors_Generic()
//    {
//        // Arrange
//        var input = new object?[] { "1.1", "2.7", "3.5", "4.9", "5.0" };

//        // Act
//        var result = input.Floors<double>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(new double[] { 1.0, 2.0, 3.0, 4.0, 5.0 }, result);
//    }

//    #endregion

//    #region Round

//    [Fact]
//    public void Round_NullInput_ReturnsNull_Generic()
//    {
//        // Arrange
//        object? input = null;

//        // Act
//        var result = input.Round<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Round_PositiveDoubleNoDigits_RoundsToNearestInteger_Generic()
//    {
//        // Arrange
//        object input = 3.4;

//        // Act
//        var result = input.Round<double>();

//        // Assert
//        Assert.Equal(3.0, result);
//    }

//    [Fact]
//    public void Round_PositiveDoubleWithDigits_RoundsToSpecifiedDigits_Generic()
//    {
//        // Arrange
//        object input = 3.45678;
//        object digits = 2;

//        // Act
//        var result = input.Round<double>(digits);

//        // Assert
//        Assert.Equal(3.46, result);
//    }

//    [Fact]
//    public void Round_NegativeDoubleNoDigits_RoundsToNearestInteger_Generic()
//    {
//        // Arrange
//        object input = -3.6;

//        // Act
//        var result = input.Round<double>();

//        // Assert
//        Assert.Equal(-4.0, result);
//    }

//    [Fact]
//    public void Round_NegativeDoubleWithDigits_RoundsToSpecifiedDigits_Generic()
//    {
//        // Arrange
//        object input = -3.45678;
//        object digits = 2;

//        // Act
//        var result = input.Round<double>(digits);

//        // Assert
//        Assert.Equal(-3.46, result);
//    }

//    [Fact]
//    public void Round_StringInput_ConvertsAndRounds_Generic()
//    {
//        // Arrange
//        object input = "3.45678";
//        object digits = 2;

//        // Act
//        var result = input.Round<double>(digits);

//        // Assert
//        Assert.Equal(3.46, result);
//    }

//    [Fact]
//    public void Round_DoubleToInt_RoundsAndConverts_Generic()
//    {
//        // Arrange
//        object input = 3.6;

//        // Act
//        var result = input.Round<int>();

//        // Assert
//        Assert.Equal(4, result);
//    }

//    [Fact]
//    public void Round_NullDigits_UsesDefaultRounding_Generic()
//    {
//        // Arrange
//        object input = 3.6;
//        object? digits = null;

//        // Act
//        var result = input.Round<double>(digits);

//        // Assert
//        Assert.Equal(4.0, result);
//    }

//    [Fact]
//    public void Round_WithMidpointRoundingToEven_RoundsCorrectly_Generic()
//    {
//        // Arrange
//        object input = 2.5;

//        // Act
//        var result = input.Round<double>(null, MidpointRounding.ToEven);

//        // Assert
//        Assert.Equal(2.0, result);
//    }

//    [Fact]
//    public void Round_WithMidpointRoundingAwayFromZero_RoundsCorrectly_Generic()
//    {
//        // Arrange
//        object input = 2.5;

//        // Act
//        var result = input.Round<double>(null, MidpointRounding.AwayFromZero);

//        // Assert
//        Assert.Equal(3.0, result);
//    }

//    [Fact]
//    public void Round_WithMidpointRoundingToZero_RoundsCorrectly_Generic()
//    {
//        // Arrange
//        object input = 2.5;

//        // Act
//        var result = input.Round<double>(null, MidpointRounding.ToZero);

//        // Assert
//        Assert.Equal(2.0, result);
//    }

//    [Fact]
//    public void Round_WithMidpointRoundingToNegativeInfinity_RoundsCorrectly_Generic()
//    {
//        // Arrange
//        object input = 2.5;

//        // Act
//        var result = input.Round<double>(null, MidpointRounding.ToNegativeInfinity);

//        // Assert
//        Assert.Equal(2.0, result);
//    }

//    [Fact]
//    public void Round_WithMidpointRoundingToPositiveInfinity_RoundsCorrectly_Generic()
//    {
//        // Arrange
//        object input = 2.5;

//        // Act
//        var result = input.Round<double>(null, MidpointRounding.ToPositiveInfinity);

//        // Assert
//        Assert.Equal(3.0, result);
//    }

//    [Fact]
//    public void Round_NegativeValueWithMidpointRoundingToEven_RoundsCorrectly_Generic()
//    {
//        // Arrange
//        object input = -2.5;

//        // Act
//        var result = input.Round<double>(null, MidpointRounding.ToEven);

//        // Assert
//        Assert.Equal(-2.0, result);
//    }

//    [Fact]
//    public void Round_NegativeValueWithMidpointRoundingAwayFromZero_RoundsCorrectly_Generic()
//    {
//        // Arrange
//        object input = -2.5;

//        // Act
//        var result = input.Round<double>(null, MidpointRounding.AwayFromZero);

//        // Assert
//        Assert.Equal(-3.0, result);
//    }

//    [Fact]
//    public void Round_WithDigitsAndMidpointRounding_RoundsCorrectly_Generic()
//    {
//        // Arrange
//        object input = 3.125;
//        object digits = 2;

//        // Act
//        var result = input.Round<double>(digits, MidpointRounding.ToEven);

//        // Assert
//        Assert.Equal(3.12, result);
//    }

//    [Fact]
//    public void Rounds_NullCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        IEnumerable<object?>? input = null;

//        // Act
//        var result = input.Rounds<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Rounds_EmptyCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        var input = Array.Empty<object?>();

//        // Act
//        var result = input.Rounds<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Rounds_DoubleCollection_RoundsAllValues_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 1.4, 2.6, 3.5, 4.5, 5.0 };
//        var expected = new double[] { 1.0, 3.0, 4.0, 5.0, 5.0 };

//        // Act
//        var result = input.Rounds<double>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(expected, result);
//    }

//    [Fact]
//    public void Rounds_DoubleCollectionWithDigits_RoundsAllValuesToSpecifiedDigits_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 1.44, 2.66, 3.55, 4.45, 5.00 };
//        object digits = 1;
//        var expected = new double[] { 1.4, 2.7, 3.6, 4.5, 5.0 };

//        // Act
//        var result = input.Rounds<double>(digits)?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(expected, result);
//    }

//    [Fact]
//    public void Rounds_CollectionWithNulls_PreservesNulls_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 1.4, null, 3.5, null, 5.0 };

//        // Act
//        var result = input.Rounds<double?>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal([1.0, null, 4.0, null, 5.0], result);
//    }

//    [Fact]
//    public void Rounds_ParamsOverload_RoundsAllValues_Generic()
//    {
//        // Arrange
//        var expected = new double[] { 1.0, 3.0, 4.0, 5.0, 5.0 };

//        // Act
//        var result = YANMath.Rounds(1.4, 2.6, 3.5, 4.5, 5.0)?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(expected, result);
//    }

//    [Fact]
//    public void Rounds_WithMidpointRoundingToEven_RoundsAllValuesCorrectly_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 1.5, 2.5, 3.5, 4.5, 5.5 };
//        var expected = new double[] { 2.0, 2.0, 4.0, 4.0, 6.0 };

//        // Act
//        var result = input.Rounds<double>(null, MidpointRounding.ToEven)?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(expected, result);
//    }

//    [Fact]
//    public void Rounds_WithMidpointRoundingAwayFromZero_RoundsAllValuesCorrectly_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 1.5, 2.5, 3.5, 4.5, 5.5 };
//        var expected = new double[] { 2.0, 3.0, 4.0, 5.0, 6.0 };

//        // Act
//        var result = input.Rounds<double>(null, MidpointRounding.AwayFromZero)?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(expected, result);
//    }

//    [Fact]
//    public void Rounds_WithDigitsAndMidpointRounding_RoundsAllValuesCorrectly_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 1.125, 2.125, 3.125, 4.125, 5.125 };
//        object digits = 2;
//        var expected = new double[] { 1.12, 2.12, 3.12, 4.12, 5.12 };

//        // Act
//        var result = input.Rounds<double>(digits, MidpointRounding.ToEven)?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(expected, result);
//    }

//    [Fact]
//    public void Rounds_NegativeValuesWithMidpointRounding_RoundsAllValuesCorrectly_Generic()
//    {
//        // Arrange
//        var input = new object?[] { -1.5, -2.5, -3.5, -4.5, -5.5 };

//        // Act
//        var result = input.Rounds<double>(null, MidpointRounding.ToEven)?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(new double[] { -2.0, -2.0, -4.0, -4.0, -6.0 }, result);
//    }

//    [Fact]
//    public void Rounds_StringValues_ConvertsAndRounds_Generic()
//    {
//        // Arrange
//        var input = new object?[] { "1.4", "2.6", "3.5", "4.5", "5.0" };
//        var expected = new double[] { 1.0, 3.0, 4.0, 5.0, 5.0 };

//        // Act
//        var result = input.Rounds<double>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(expected, result);
//    }

//    #endregion

//    #region Sqrt

//    [Fact]
//    public void Sqrt_NullInput_ReturnsNull_Generic()
//    {
//        // Arrange
//        object? input = null;

//        // Act
//        var result = input.Sqrt<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Sqrt_PositiveNumber_ReturnsSquareRoot_Generic()
//    {
//        // Arrange
//        object input = 16.0;

//        // Act
//        var result = input.Sqrt<double>();

//        // Assert
//        Assert.Equal(4.0, result);
//    }

//    [Fact]
//    public void Sqrt_Zero_ReturnsZero_Generic()
//    {
//        // Arrange
//        object input = 0.0;

//        // Act
//        var result = input.Sqrt<double>();

//        // Assert
//        Assert.Equal(0.0, result);
//    }

//    [Fact]
//    public void Sqrt_StringInput_ConvertsAndCalculates_Generic()
//    {
//        // Arrange
//        object input = "16";

//        // Act
//        var result = input.Sqrt<double>();

//        // Assert
//        Assert.Equal(4.0, result);
//    }

//    [Fact]
//    public void Sqrt_DoubleToInt_CalculatesAndConverts_Generic()
//    {
//        // Arrange
//        object input = 16.0;

//        // Act
//        var result = input.Sqrt<int>();

//        // Assert
//        Assert.Equal(4, result);
//    }

//    [Fact]
//    public void Sqrts_NullCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        IEnumerable<object?>? input = null;

//        // Act
//        var result = input.Sqrts<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Sqrts_EmptyCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        var input = Array.Empty<object?>();

//        // Act
//        var result = input.Sqrts<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Sqrts_DoubleCollection_CalculatesAllValues_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 4.0, 9.0, 16.0, 25.0, 36.0 };
//        var expected = new double[] { 2.0, 3.0, 4.0, 5.0, 6.0 };

//        // Act
//        var result = input.Sqrts<double>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(expected, result);
//    }

//    [Fact]
//    public void Sqrts_CollectionWithNulls_PreservesNulls_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 4.0, null, 16.0, null, 36.0 };

//        // Act
//        var result = input.Sqrts<double?>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal([2.0, null, 4.0, null, 6.0], result);
//    }

//    [Fact]
//    public void Sqrts_ParamsOverload_CalculatesAllValues_Generic()
//    {
//        // Arrange
//        var expected = new double[] { 2.0, 3.0, 4.0, 5.0, 6.0 };

//        // Act
//        var result = YANMath.Sqrts(4.0, 9.0, 16.0, 25.0, 36.0)?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(expected, result);
//    }

//    [Fact]
//    public void Sqrts_StringValues_ConvertsAndCalculates_Generic()
//    {
//        // Arrange
//        var input = new object?[] { "4", "9", "16", "25", "36" };
//        var expected = new double[] { 2.0, 3.0, 4.0, 5.0, 6.0 };

//        // Act
//        var result = input.Sqrts<double>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(expected, result);
//    }

//    #endregion

//    #region Pow

//    [Fact]
//    public void Pow_NullInput_ReturnsNull_Generic()
//    {
//        // Arrange
//        object? input = null;
//        object power = 2.0;

//        // Act
//        var result = input.Pow<double?>(power);

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Pow_NullPower_ReturnsNull_Generic()
//    {
//        // Arrange
//        object input = 2.0;
//        object? power = null;

//        // Act
//        var result = input.Pow<double?>(power);

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Pow_PositiveNumberSquared_ReturnsCorrectValue_Generic()
//    {
//        // Arrange
//        object input = 3.0;
//        object power = 2.0;

//        // Act
//        var result = input.Pow<double>(power);

//        // Assert
//        Assert.Equal(9.0, result);
//    }

//    [Fact]
//    public void Pow_PositiveNumberCubed_ReturnsCorrectValue_Generic()
//    {
//        // Arrange
//        object input = 3.0;
//        object power = 3.0;

//        // Act
//        var result = input.Pow<double>(power);

//        // Assert
//        Assert.Equal(27.0, result);
//    }

//    [Fact]
//    public void Pow_NegativeNumberEvenPower_ReturnsPositiveValue_Generic()
//    {
//        // Arrange
//        object input = -3.0;
//        object power = 2.0;

//        // Act
//        var result = input.Pow<double>(power);

//        // Assert
//        Assert.Equal(9.0, result);
//    }

//    [Fact]
//    public void Pow_NegativeNumberOddPower_ReturnsNegativeValue_Generic()
//    {
//        // Arrange
//        object input = -3.0;
//        object power = 3.0;

//        // Act
//        var result = input.Pow<double>(power);

//        // Assert
//        Assert.Equal(-27.0, result);
//    }

//    [Fact]
//    public void Pow_StringInput_ConvertsAndCalculates_Generic()
//    {
//        // Arrange
//        object input = "3";
//        object power = 2.0;

//        // Act
//        var result = input.Pow<double>(power);

//        // Assert
//        Assert.Equal(9.0, result);
//    }

//    [Fact]
//    public void Pow_StringPower_ConvertsAndCalculates_Generic()
//    {
//        // Arrange
//        object input = 3.0;
//        object power = "2";

//        // Act
//        var result = input.Pow<double>(power);

//        // Assert
//        Assert.Equal(9.0, result);
//    }

//    [Fact]
//    public void Pow_DoubleToInt_CalculatesAndConverts_Generic()
//    {
//        // Arrange
//        object input = 3.0;
//        object power = 2.0;

//        // Act
//        var result = input.Pow<int>(power);

//        // Assert
//        Assert.Equal(9, result);
//    }

//    [Fact]
//    public void Pows_NullCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        IEnumerable<object?>? input = null;
//        object power = 2.0;

//        // Act
//        var result = input.Pows<double?>(power);

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Pows_EmptyCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        var input = Array.Empty<object?>();
//        object power = 2.0;

//        // Act
//        var result = input.Pows<double?>(power);

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Pows_DoubleCollection_CalculatesAllValues_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 1.0, 2.0, 3.0, 4.0, 5.0 };
//        object power = 2.0;
//        var expected = new double[] { 1.0, 4.0, 9.0, 16.0, 25.0 };

//        // Act
//        var result = input.Pows<double>(power)?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(expected, result);
//    }

//    [Fact]
//    public void Pows_CollectionWithNulls_PreservesNulls_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 1.0, null, 3.0, null, 5.0 };
//        object power = 2.0;

//        // Act
//        var result = input.Pows<double?>(power)?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal([1.0, null, 9.0, null, 25.0], result);
//    }

//    [Fact]
//    public void Pows_StringValues_ConvertsAndCalculates_Generic()
//    {
//        // Arrange
//        var input = new object?[] { "1", "2", "3", "4", "5" };
//        object power = 2.0;
//        var expected = new double[] { 1.0, 4.0, 9.0, 16.0, 25.0 };

//        // Act
//        var result = input.Pows<double>(power)?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(expected, result);
//    }

//    #endregion

//    #region Abs

//    [Fact]
//    public void Abs_NullInput_ReturnsNull_Generic()
//    {
//        // Arrange
//        object? input = null;

//        // Act
//        var result = input.Abs<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Abs_PositiveNumber_ReturnsSameValue_Generic()
//    {
//        // Arrange
//        object input = 5.0;

//        // Act
//        var result = input.Abs<double>();

//        // Assert
//        Assert.Equal(5.0, result);
//    }

//    [Fact]
//    public void Abs_NegativeNumber_ReturnsPositiveValue_Generic()
//    {
//        // Arrange
//        object input = -5.0;

//        // Act
//        var result = input.Abs<double>();

//        // Assert
//        Assert.Equal(5.0, result);
//    }

//    [Fact]
//    public void Abs_Zero_ReturnsZero_Generic()
//    {
//        // Arrange
//        object input = 0.0;

//        // Act
//        var result = input.Abs<double>();

//        // Assert
//        Assert.Equal(0.0, result);
//    }

//    [Fact]
//    public void Abs_StringInput_ConvertsAndCalculates_Generic()
//    {
//        // Arrange
//        object input = "-5";

//        // Act
//        var result = input.Abs<double>();

//        // Assert
//        Assert.Equal(5.0, result);
//    }

//    [Fact]
//    public void Abs_DoubleToInt_CalculatesAndConverts_Generic()
//    {
//        // Arrange
//        object input = -5.0;

//        // Act
//        var result = input.Abs<int>();

//        // Assert
//        Assert.Equal(5, result);
//    }

//    [Fact]
//    public void Abss_NullCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        IEnumerable<object?>? input = null;

//        // Act
//        var result = input.Abss<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Abss_EmptyCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        var input = Array.Empty<object?>();

//        // Act
//        var result = input.Abss<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Abss_DoubleCollection_CalculatesAllValues_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 1.0, -2.0, 3.0, -4.0, 5.0 };

//        // Act
//        var result = input.Abss<double>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(new double[] { 1.0, 2.0, 3.0, 4.0, 5.0 }, result);
//    }

//    [Fact]
//    public void Abss_CollectionWithNulls_PreservesNulls_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 1.0, null, -3.0, null, 5.0 };

//        // Act
//        var result = input.Abss<double?>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(new double?[] { 1.0, null, 3.0, null, 5.0 }, result);
//    }

//    [Fact]
//    public void Abss_ParamsOverload_CalculatesAllValues_Generic()
//    {
//        // Act
//        var result = YANMath.Abss<double>(1.0, -2.0, 3.0, -4.0, 5.0)?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(new double[] { 1.0, 2.0, 3.0, 4.0, 5.0 }, result);
//    }

//    [Fact]
//    public void Abss_StringValues_ConvertsAndCalculates_Generic()
//    {
//        // Arrange
//        var input = new object?[] { "1", "-2", "3", "-4", "5" };

//        // Act
//        var result = input.Abss<double>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(new double[] { 1.0, 2.0, 3.0, 4.0, 5.0 }, result);
//    }

//    #endregion

//    #region Log

//    [Fact]
//    public void Log_NullInput_ReturnsNull_Generic()
//    {
//        // Arrange
//        object? input = null;

//        // Act
//        var result = input.Log<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Log_PositiveNumber_ReturnsNaturalLog_Generic()
//    {
//        // Arrange
//        object input = Math.E;

//        // Act
//        var result = input.Log<double>();

//        // Assert
//        Assert.Equal(1.0, result);
//    }

//    [Fact]
//    public void Log_One_ReturnsZero_Generic()
//    {
//        // Arrange
//        object input = 1.0;

//        // Act
//        var result = input.Log<double>();

//        // Assert
//        Assert.Equal(0.0, result);
//    }

//    [Fact]
//    public void Log_WithBase_ReturnsLogWithSpecifiedBase_Generic()
//    {
//        // Arrange
//        object input = 100.0;
//        object logBase = 10.0;

//        // Act
//        var result = input.Log<double>(logBase);

//        // Assert
//        Assert.Equal(2.0, result);
//    }

//    [Fact]
//    public void Log_StringInput_ConvertsAndCalculates_Generic()
//    {
//        // Arrange
//        object input = "100";
//        object logBase = 10.0;

//        // Act
//        var result = input.Log<double>(logBase);

//        // Assert
//        Assert.Equal(2.0, result);
//    }

//    [Fact]
//    public void Log_DoubleToInt_CalculatesAndConverts_Generic()
//    {
//        // Arrange
//        object input = 100.0;
//        object logBase = 10.0;

//        // Act
//        var result = input.Log<int>(logBase);

//        // Assert
//        Assert.Equal(2, result);
//    }

//    [Fact]
//    public void Logs_NullCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        IEnumerable<object?>? input = null;

//        // Act
//        var result = input.Logs<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Logs_EmptyCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        var input = Array.Empty<object?>();

//        // Act
//        var result = input.Logs<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Logs_DoubleCollection_CalculatesAllValues_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 1.0, Math.E, Math.E * Math.E, 100.0 };
//        object logBase = 10.0;

//        // Act
//        var result = input.Logs<double>(logBase)?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(0.0, result![0], 15);
//        Assert.Equal(Math.Log(Math.E, 10.0), result[1], 15);
//        Assert.Equal(Math.Log(Math.E * Math.E, 10.0), result[2], 15);
//        Assert.Equal(2.0, result[3], 15);
//    }

//    [Fact]
//    public void Logs_CollectionWithNulls_PreservesNulls_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 1.0, null, Math.E, null };

//        // Act
//        var result = input.Logs<double?>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(0.0, result![0]);
//        Assert.Null(result[1]);
//        Assert.Equal(1.0, result[2]);
//        Assert.Null(result[3]);
//    }

//    [Fact]
//    public void Logs_ParamsOverload_CalculatesAllValues_Generic()
//    {
//        // Act
//        var result = YANMath.Logs<double>(1.0, Math.E, Math.E * Math.E, 100.0)?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(0.0, result![0], 15);
//        Assert.Equal(1.0, result[1], 15);
//        Assert.Equal(2.0, result[2], 15);
//        Assert.Equal(Math.Log(100.0), result[3], 15);
//    }

//    #endregion

//    #region Log10

//    [Fact]
//    public void Log10_NullInput_ReturnsNull_Generic()
//    {
//        // Arrange
//        object? input = null;

//        // Act
//        var result = input.Log10<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Log10_PositiveNumber_ReturnsLog10_Generic()
//    {
//        // Arrange
//        object input = 100.0;

//        // Act
//        var result = input.Log10<double>();

//        // Assert
//        Assert.Equal(2.0, result);
//    }

//    [Fact]
//    public void Log10_One_ReturnsZero_Generic()
//    {
//        // Arrange
//        object input = 1.0;

//        // Act
//        var result = input.Log10<double>();

//        // Assert
//        Assert.Equal(0.0, result);
//    }

//    [Fact]
//    public void Log10_StringInput_ConvertsAndCalculates_Generic()
//    {
//        // Arrange
//        object input = "100";

//        // Act
//        var result = input.Log10<double>();

//        // Assert
//        Assert.Equal(2.0, result);
//    }

//    [Fact]
//    public void Log10_DoubleToInt_CalculatesAndConverts_Generic()
//    {
//        // Arrange
//        object input = 100.0;

//        // Act
//        var result = input.Log10<int>();

//        // Assert
//        Assert.Equal(2, result);
//    }

//    [Fact]
//    public void Log10s_NullCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        IEnumerable<object?>? input = null;

//        // Act
//        var result = input.Log10s<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Log10s_EmptyCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        var input = Array.Empty<object?>();

//        // Act
//        var result = input.Log10s<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Log10s_DoubleCollection_CalculatesAllValues_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 1.0, 10.0, 100.0, 1000.0 };

//        // Act
//        var result = input.Log10s<double>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(new double[] { 0.0, 1.0, 2.0, 3.0 }, result);
//    }

//    [Fact]
//    public void Log10s_CollectionWithNulls_PreservesNulls_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 1.0, null, 100.0, null };

//        // Act
//        var result = input.Log10s<double?>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(new double?[] { 0.0, null, 2.0, null }, result);
//    }

//    [Fact]
//    public void Log10s_ParamsOverload_CalculatesAllValues_Generic()
//    {
//        // Act
//        var result = YANMath.Log10s<double>(1.0, 10.0, 100.0, 1000.0)?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(new double[] { 0.0, 1.0, 2.0, 3.0 }, result);
//    }

//    #endregion

//    #region Log2

//    [Fact]
//    public void Log2_NullInput_ReturnsNull_Generic()
//    {
//        // Arrange
//        object? input = null;

//        // Act
//        var result = input.Log2<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Log2_PositiveNumber_ReturnsLog2_Generic()
//    {
//        // Arrange
//        object input = 8.0;

//        // Act
//        var result = input.Log2<double>();

//        // Assert
//        Assert.Equal(3.0, result);
//    }

//    [Fact]
//    public void Log2_One_ReturnsZero_Generic()
//    {
//        // Arrange
//        object input = 1.0;

//        // Act
//        var result = input.Log2<double>();

//        // Assert
//        Assert.Equal(0.0, result);
//    }

//    [Fact]
//    public void Log2_StringInput_ConvertsAndCalculates_Generic()
//    {
//        // Arrange
//        object input = "8";

//        // Act
//        var result = input.Log2<double>();

//        // Assert
//        Assert.Equal(3.0, result);
//    }

//    [Fact]
//    public void Log2_DoubleToInt_CalculatesAndConverts_Generic()
//    {
//        // Arrange
//        object input = 8.0;

//        // Act
//        var result = input.Log2<int>();

//        // Assert
//        Assert.Equal(3, result);
//    }

//    [Fact]
//    public void Log2s_NullCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        IEnumerable<object?>? input = null;

//        // Act
//        var result = input.Log2s<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Log2s_EmptyCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        var input = Array.Empty<object?>();

//        // Act
//        var result = input.Log2s<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Log2s_DoubleCollection_CalculatesAllValues_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 1.0, 2.0, 4.0, 8.0 };

//        // Act
//        var result = input.Log2s<double>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(new double[] { 0.0, 1.0, 2.0, 3.0 }, result);
//    }

//    [Fact]
//    public void Log2s_CollectionWithNulls_PreservesNulls_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 1.0, null, 4.0, null };

//        // Act
//        var result = input.Log2s<double?>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(new double?[] { 0.0, null, 2.0, null }, result);
//    }

//    [Fact]
//    public void Log2s_ParamsOverload_CalculatesAllValues_Generic()
//    {
//        // Act
//        var result = YANMath.Log2s<double>(1.0, 2.0, 4.0, 8.0)?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(new double[] { 0.0, 1.0, 2.0, 3.0 }, result);
//    }

//    #endregion

//    #region Sin

//    [Fact]
//    public void Sin_NullInput_ReturnsNull_Generic()
//    {
//        // Arrange
//        object? input = null;

//        // Act
//        var result = input.Sin<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Sin_Zero_ReturnsZero_Generic()
//    {
//        // Arrange
//        object input = 0.0;

//        // Act
//        var result = input.Sin<double>();

//        // Assert
//        Assert.Equal(0.0, result);
//    }

//    [Fact]
//    public void Sin_PiDividedBy2_ReturnsOne_Generic()
//    {
//        // Arrange
//        object input = Math.PI / 2;

//        // Act
//        var result = input.Sin<double>();

//        // Assert
//        Assert.Equal(1.0, result, 15);
//    }

//    [Fact]
//    public void Sin_Pi_ReturnsZero_Generic()
//    {
//        // Arrange
//        object input = Math.PI;

//        // Act
//        var result = input.Sin<double>();

//        // Assert
//        Assert.Equal(0.0, result, 15);
//    }

//    [Fact]
//    public void Sin_StringInput_ConvertsAndCalculates_Generic()
//    {
//        // Arrange
//        object input = "0";

//        // Act
//        var result = input.Sin<double>();

//        // Assert
//        Assert.Equal(0.0, result);
//    }

//    [Fact]
//    public void Sins_NullCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        IEnumerable<object?>? input = null;

//        // Act
//        var result = input.Sins<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Sins_EmptyCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        var input = Array.Empty<object?>();

//        // Act
//        var result = input.Sins<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Sins_DoubleCollection_CalculatesAllValues_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 0.0, Math.PI / 6, Math.PI / 4, Math.PI / 3, Math.PI / 2 };

//        // Act
//        var result = input.Sins<double>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(0.0, result![0], 15);
//        Assert.Equal(0.5, result[1], 15);
//        Assert.Equal(Math.Sin(Math.PI / 4), result[2], 15);
//        Assert.Equal(Math.Sin(Math.PI / 3), result[3], 15);
//        Assert.Equal(1.0, result[4], 15);
//    }

//    [Fact]
//    public void Sins_CollectionWithNulls_PreservesNulls_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 0.0, null, Math.PI / 2, null };

//        // Act
//        var result = input.Sins<double?>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(0.0, result![0], 15);
//        Assert.Null(result[1]);
//        Assert.Equal(1.0, result[2], 15);
//        Assert.Null(result[3]);
//    }

//    [Fact]
//    public void Sins_ParamsOverload_CalculatesAllValues_Generic()
//    {
//        // Act
//        var result = YANMath.Sins<double>(0.0, Math.PI / 6, Math.PI / 4, Math.PI / 3, Math.PI / 2)?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(0.0, result![0], 15);
//        Assert.Equal(0.5, result[1], 15);
//        Assert.Equal(Math.Sin(Math.PI / 4), result[2], 15);
//        Assert.Equal(Math.Sin(Math.PI / 3), result[3], 15);
//        Assert.Equal(1.0, result[4], 15);
//    }

//    #endregion

//    #region Cos

//    [Fact]
//    public void Cos_NullInput_ReturnsNull_Generic()
//    {
//        // Arrange
//        object? input = null;

//        // Act
//        var result = input.Cos<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Cos_Zero_ReturnsOne_Generic()
//    {
//        // Arrange
//        object input = 0.0;

//        // Act
//        var result = input.Cos<double>();

//        // Assert
//        Assert.Equal(1.0, result);
//    }

//    [Fact]
//    public void Cos_PiDividedBy2_ReturnsZero_Generic()
//    {
//        // Arrange
//        object input = Math.PI / 2;

//        // Act
//        var result = input.Cos<double>();

//        // Assert
//        Assert.Equal(0.0, result, 15);
//    }

//    [Fact]
//    public void Cos_Pi_ReturnsMinusOne_Generic()
//    {
//        // Arrange
//        object input = Math.PI;

//        // Act
//        var result = input.Cos<double>();

//        // Assert
//        Assert.Equal(-1.0, result, 15);
//    }

//    [Fact]
//    public void Cos_StringInput_ConvertsAndCalculates_Generic()
//    {
//        // Arrange
//        object input = "0";

//        // Act
//        var result = input.Cos<double>();

//        // Assert
//        Assert.Equal(1.0, result);
//    }

//    [Fact]
//    public void Coss_NullCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        IEnumerable<object?>? input = null;

//        // Act
//        var result = input.Coss<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Coss_EmptyCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        var input = Array.Empty<object?>();

//        // Act
//        var result = input.Coss<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Coss_DoubleCollection_CalculatesAllValues_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 0.0, Math.PI / 6, Math.PI / 4, Math.PI / 3, Math.PI / 2 };

//        // Act
//        var result = input.Coss<double>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(1.0, result![0], 15);
//        Assert.Equal(Math.Cos(Math.PI / 6), result[1], 15);
//        Assert.Equal(Math.Cos(Math.PI / 4), result[2], 15);
//        Assert.Equal(0.5, result[3], 15);
//        Assert.Equal(0.0, result[4], 15);
//    }

//    [Fact]
//    public void Coss_CollectionWithNulls_PreservesNulls_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 0.0, null, Math.PI / 2, null };

//        // Act
//        var result = input.Coss<double?>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(1.0, result![0], 15);
//        Assert.Null(result[1]);
//        Assert.Equal(0.0, result[2], 15);
//        Assert.Null(result[3]);
//    }

//    [Fact]
//    public void Coss_ParamsOverload_CalculatesAllValues_Generic()
//    {
//        // Act
//        var result = YANMath.Coss<double>(0.0, Math.PI / 6, Math.PI / 4, Math.PI / 3, Math.PI / 2)?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(1.0, result![0], 15);
//        Assert.Equal(Math.Cos(Math.PI / 6), result[1], 15);
//        Assert.Equal(Math.Cos(Math.PI / 4), result[2], 15);
//        Assert.Equal(0.5, result[3], 15);
//        Assert.Equal(0.0, result[4], 15);
//    }

//    #endregion

//    #region Tan

//    [Fact]
//    public void Tan_NullInput_ReturnsNull_Generic()
//    {
//        // Arrange
//        object? input = null;

//        // Act
//        var result = input.Tan<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Tan_Zero_ReturnsZero_Generic()
//    {
//        // Arrange
//        object input = 0.0;

//        // Act
//        var result = input.Tan<double>();

//        // Assert
//        Assert.Equal(0.0, result);
//    }

//    [Fact]
//    public void Tan_PiDividedBy4_ReturnsOne_Generic()
//    {
//        // Arrange
//        object input = Math.PI / 4;

//        // Act
//        var result = input.Tan<double>();

//        // Assert
//        Assert.Equal(1.0, result, 15);
//    }

//    [Fact]
//    public void Tan_StringInput_ConvertsAndCalculates_Generic()
//    {
//        // Arrange
//        object input = "0";

//        // Act
//        var result = input.Tan<double>();

//        // Assert
//        Assert.Equal(0.0, result);
//    }

//    [Fact]
//    public void Tans_NullCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        IEnumerable<object?>? input = null;

//        // Act
//        var result = input.Tans<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Tans_EmptyCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        var input = Array.Empty<object?>();

//        // Act
//        var result = input.Tans<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Tans_DoubleCollection_CalculatesAllValues_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 0.0, Math.PI / 6, Math.PI / 4, Math.PI / 3 };

//        // Act
//        var result = input.Tans<double>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(0.0, result![0], 15);
//        Assert.Equal(Math.Tan(Math.PI / 6), result[1], 15);
//        Assert.Equal(1.0, result[2], 15);
//        Assert.Equal(Math.Tan(Math.PI / 3), result[3], 15);
//    }

//    [Fact]
//    public void Tans_CollectionWithNulls_PreservesNulls_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 0.0, null, Math.PI / 4, null };

//        // Act
//        var result = input.Tans<double?>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(0.0, result![0], 15);
//        Assert.Null(result[1]);
//        Assert.Equal(1.0, result[2], 15);
//        Assert.Null(result[3]);
//    }

//    [Fact]
//    public void Tans_ParamsOverload_CalculatesAllValues_Generic()
//    {
//        // Act
//        var result = YANMath.Tans<double>(0.0, Math.PI / 6, Math.PI / 4, Math.PI / 3)?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(0.0, result![0], 15);
//        Assert.Equal(Math.Tan(Math.PI / 6), result[1], 15);
//        Assert.Equal(1.0, result[2], 15);
//        Assert.Equal(Math.Tan(Math.PI / 3), result[3], 15);
//    }

//    #endregion

//    #region Asin

//    [Fact]
//    public void Asin_NullInput_ReturnsNull_Generic()
//    {
//        // Arrange
//        object? input = null;

//        // Act
//        var result = input.Asin<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Asin_Zero_ReturnsZero_Generic()
//    {
//        // Arrange
//        object input = 0.0;

//        // Act
//        var result = input.Asin<double>();

//        // Assert
//        Assert.Equal(0.0, result);
//    }

//    [Fact]
//    public void Asin_One_ReturnsPiDividedBy2_Generic()
//    {
//        // Arrange
//        object input = 1.0;

//        // Act
//        var result = input.Asin<double>();

//        // Assert
//        Assert.Equal(Math.PI / 2, result, 15);
//    }

//    [Fact]
//    public void Asin_MinusOne_ReturnsMinusPiDividedBy2_Generic()
//    {
//        // Arrange
//        object input = -1.0;

//        // Act
//        var result = input.Asin<double>();

//        // Assert
//        Assert.Equal(-Math.PI / 2, result, 15);
//    }

//    [Fact]
//    public void Asin_StringInput_ConvertsAndCalculates_Generic()
//    {
//        // Arrange
//        object input = "0";

//        // Act
//        var result = input.Asin<double>();

//        // Assert
//        Assert.Equal(0.0, result);
//    }

//    [Fact]
//    public void Asins_NullCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        IEnumerable<object?>? input = null;

//        // Act
//        var result = input.Asins<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Asins_EmptyCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        var input = Array.Empty<object?>();

//        // Act
//        var result = input.Asins<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Asins_DoubleCollection_CalculatesAllValues_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 0.0, 0.5, Math.Sqrt(2) / 2, Math.Sqrt(3) / 2, 1.0 };

//        // Act
//        var result = input.Asins<double>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(0.0, result![0], 15);
//        Assert.Equal(Math.PI / 6, result[1], 15);
//        Assert.Equal(Math.PI / 4, result[2], 15);
//        Assert.Equal(Math.PI / 3, result[3], 15);
//        Assert.Equal(Math.PI / 2, result[4], 15);
//    }

//    [Fact]
//    public void Asins_CollectionWithNulls_PreservesNulls_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 0.0, null, 1.0, null };

//        // Act
//        var result = input.Asins<double?>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(0.0, result![0], 15);
//        Assert.Null(result[1]);
//        Assert.Equal(Math.PI / 2, result[2], 15);
//        Assert.Null(result[3]);
//    }

//    [Fact]
//    public void Asins_ParamsOverload_CalculatesAllValues_Generic()
//    {
//        // Act
//        var result = YANMath.Asins<double>(0.0, 0.5, Math.Sqrt(2) / 2, Math.Sqrt(3) / 2, 1.0)?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(0.0, result![0], 15);
//        Assert.Equal(Math.PI / 6, result[1], 15);
//        Assert.Equal(Math.PI / 4, result[2], 15);
//        Assert.Equal(Math.PI / 3, result[3], 15);
//        Assert.Equal(Math.PI / 2, result[4], 15);
//    }

//    #endregion

//    #region Acos

//    [Fact]
//    public void Acos_NullInput_ReturnsNull_Generic()
//    {
//        // Arrange
//        object? input = null;

//        // Act
//        var result = input.Acos<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Acos_One_ReturnsZero_Generic()
//    {
//        // Arrange
//        object input = 1.0;

//        // Act
//        var result = input.Acos<double>();

//        // Assert
//        Assert.Equal(0.0, result, 15);
//    }

//    [Fact]
//    public void Acos_Zero_ReturnsPiDividedBy2_Generic()
//    {
//        // Arrange
//        object input = 0.0;

//        // Act
//        var result = input.Acos<double>();

//        // Assert
//        Assert.Equal(Math.PI / 2, result, 15);
//    }

//    [Fact]
//    public void Acos_MinusOne_ReturnsPi_Generic()
//    {
//        // Arrange
//        object input = -1.0;

//        // Act
//        var result = input.Acos<double>();

//        // Assert
//        Assert.Equal(Math.PI, result, 15);
//    }

//    [Fact]
//    public void Acos_StringInput_ConvertsAndCalculates_Generic()
//    {
//        // Arrange
//        object input = "1";

//        // Act
//        var result = input.Acos<double>();

//        // Assert
//        Assert.Equal(0.0, result, 15);
//    }

//    [Fact]
//    public void ACoss_NullCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        IEnumerable<object?>? input = null;

//        // Act
//        var result = input.ACoss<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void ACoss_EmptyCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        var input = Array.Empty<object?>();

//        // Act
//        var result = input.ACoss<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void ACoss_DoubleCollection_CalculatesAllValues_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 1.0, Math.Sqrt(3) / 2, Math.Sqrt(2) / 2, 0.5, 0.0 };

//        // Act
//        var result = input.Acoss<double>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(0.0, result![0], 15);
//        Assert.Equal(Math.PI / 6, result[1], 15);
//        Assert.Equal(Math.PI / 4, result[2], 15);
//        Assert.Equal(Math.PI / 3, result[3], 15);
//        Assert.Equal(Math.PI / 2, result[4], 15);
//    }

//    [Fact]
//    public void ACoss_CollectionWithNulls_PreservesNulls_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 1.0, null, 0.0, null };

//        // Act
//        var result = input.ACoss<double?>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(0.0, result![0], 15);
//        Assert.Null(result[1]);
//        Assert.Equal(Math.PI / 2, result[2], 15);
//        Assert.Null(result[3]);
//    }

//    [Fact]
//    public void ACoss_ParamsOverload_CalculatesAllValues_Generic()
//    {
//        // Act
//        var result = YANMath.ACoss<double>(1.0, Math.Sqrt(3) / 2, Math.Sqrt(2) / 2, 0.5, 0.0)?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(0.0, result![0], 15);
//        Assert.Equal(Math.PI / 6, result[1], 15);
//        Assert.Equal(Math.PI / 4, result[2], 15);
//        Assert.Equal(Math.PI / 3, result[3], 15);
//        Assert.Equal(Math.PI / 2, result[4], 15);
//    }

//    #endregion

//    #region Atan

//    [Fact]
//    public void Atan_NullInput_ReturnsNull_Generic()
//    {
//        // Arrange
//        object? input = null;

//        // Act
//        var result = input.Atan<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Atan_Zero_ReturnsZero_Generic()
//    {
//        // Arrange
//        object input = 0.0;

//        // Act
//        var result = input.Atan<double>();

//        // Assert
//        Assert.Equal(0.0, result);
//    }

//    [Fact]
//    public void Atan_One_ReturnsPiDividedBy4_Generic()
//    {
//        // Arrange
//        object input = 1.0;

//        // Act
//        var result = input.Atan<double>();

//        // Assert
//        Assert.Equal(Math.PI / 4, result, 15);
//    }

//    [Fact]
//    public void Atan_StringInput_ConvertsAndCalculates_Generic()
//    {
//        // Arrange
//        object input = "0";

//        // Act
//        var result = input.Atan<double>();

//        // Assert
//        Assert.Equal(0.0, result);
//    }

//    [Fact]
//    public void Atans_NullCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        IEnumerable<object?>? input = null;

//        // Act
//        var result = input.Atans<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Atans_EmptyCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        var input = Array.Empty<object?>();

//        // Act
//        var result = input.Atans<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Atans_DoubleCollection_CalculatesAllValues_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 0.0, 1.0, Math.Sqrt(3), double.PositiveInfinity };

//        // Act
//        var result = input.Atans<double>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(0.0, result![0], 15);
//        Assert.Equal(Math.PI / 4, result[1], 15);
//        Assert.Equal(Math.PI / 3, result[2], 15);
//        Assert.Equal(Math.PI / 2, result[3], 15);
//    }

//    [Fact]
//    public void Atans_CollectionWithNulls_PreservesNulls_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 0.0, null, 1.0, null };

//        // Act
//        var result = input.Atans<double?>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(0.0, result![0], 15);
//        Assert.Null(result[1]);
//        Assert.Equal(Math.PI / 4, result[2], 15);
//        Assert.Null(result[3]);
//    }

//    [Fact]
//    public void Atans_ParamsOverload_CalculatesAllValues_Generic()
//    {
//        // Act
//        var result = YANMath.Atans<double>(0.0, 1.0, Math.Sqrt(3), double.PositiveInfinity)?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(0.0, result![0], 15);
//        Assert.Equal(Math.PI / 4, result[1], 15);
//        Assert.Equal(Math.PI / 3, result[2], 15);
//        Assert.Equal(Math.PI / 2, result[3], 15);
//    }

//    #endregion

//    #region Cbrt

//    [Fact]
//    public void Cbrt_NullInput_ReturnsNull_Generic()
//    {
//        // Arrange
//        object? input = null;

//        // Act
//        var result = input.Cbrt<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Cbrt_PositiveNumber_ReturnsCubeRoot_Generic()
//    {
//        // Arrange
//        object input = 27.0;

//        // Act
//        var result = input.Cbrt<double>();

//        // Assert
//        Assert.Equal(3.0, result);
//    }

//    [Fact]
//    public void Cbrt_NegativeNumber_ReturnsNegativeCubeRoot_Generic()
//    {
//        // Arrange
//        object input = -27.0;

//        // Act
//        var result = input.Cbrt<double>();

//        // Assert
//        Assert.Equal(-3.0, result);
//    }

//    [Fact]
//    public void Cbrt_Zero_ReturnsZero_Generic()
//    {
//        // Arrange
//        object input = 0.0;

//        // Act
//        var result = input.Cbrt<double>();

//        // Assert
//        Assert.Equal(0.0, result);
//    }

//    [Fact]
//    public void Cbrt_StringInput_ConvertsAndCalculates_Generic()
//    {
//        // Arrange
//        object input = "27";

//        // Act
//        var result = input.Cbrt<double>();

//        // Assert
//        Assert.Equal(3.0, result);
//    }

//    [Fact]
//    public void Cbrt_DoubleToInt_CalculatesAndConverts_Generic()
//    {
//        // Arrange
//        object input = 27.0;

//        // Act
//        var result = input.Cbrt<int>();

//        // Assert
//        Assert.Equal(3, result);
//    }

//    [Fact]
//    public void Cbrts_NullCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        IEnumerable<object?>? input = null;

//        // Act
//        var result = input.Cbrts<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Cbrts_EmptyCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        var input = Array.Empty<object?>();

//        // Act
//        var result = input.Cbrts<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Cbrts_DoubleCollection_CalculatesAllValues_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 8.0, 27.0, 64.0, 125.0 };

//        // Act
//        var result = input.Cbrts<double>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(new double[] { 2.0, 3.0, 4.0, 5.0 }, result);
//    }

//    [Fact]
//    public void Cbrts_CollectionWithNulls_PreservesNulls_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 8.0, null, 64.0, null };

//        // Act
//        var result = input.Cbrts<double?>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(new double?[] { 2.0, null, 4.0, null }, result);
//    }

//    [Fact]
//    public void Cbrts_ParamsOverload_CalculatesAllValues_Generic()
//    {
//        // Act
//        var result = YANMath.Cbrts<double>(8.0, 27.0, 64.0, 125.0)?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(new double[] { 2.0, 3.0, 4.0, 5.0 }, result);
//    }

//    #endregion

//    #region Exp

//    [Fact]
//    public void Exp_NullInput_ReturnsNull_Generic()
//    {
//        // Arrange
//        object? input = null;

//        // Act
//        var result = input.Exp<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Exp_Zero_ReturnsOne_Generic()
//    {
//        // Arrange
//        object input = 0.0;

//        // Act
//        var result = input.Exp<double>();

//        // Assert
//        Assert.Equal(1.0, result);
//    }

//    [Fact]
//    public void Exp_One_ReturnsE_Generic()
//    {
//        // Arrange
//        object input = 1.0;

//        // Act
//        var result = input.Exp<double>();

//        // Assert
//        Assert.Equal(Math.E, result);
//    }

//    [Fact]
//    public void Exp_StringInput_ConvertsAndCalculates_Generic()
//    {
//        // Arrange
//        object input = "0";

//        // Act
//        var result = input.Exp<double>();

//        // Assert
//        Assert.Equal(1.0, result);
//    }

//    [Fact]
//    public void Exps_NullCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        IEnumerable<object?>? input = null;

//        // Act
//        var result = input.Exps<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Exps_EmptyCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        var input = Array.Empty<object?>();

//        // Act
//        var result = input.Exps<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Exps_DoubleCollection_CalculatesAllValues_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 0.0, 1.0, 2.0, 3.0 };

//        // Act
//        var result = input.Exps<double>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(1.0, result![0], 15);
//        Assert.Equal(Math.E, result[1], 15);
//        Assert.Equal(Math.Exp(2.0), result[2], 15);
//        Assert.Equal(Math.Exp(3.0), result[3], 15);
//    }

//    [Fact]
//    public void Exps_CollectionWithNulls_PreservesNulls_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 0.0, null, 1.0, null };

//        // Act
//        var result = input.Exps<double?>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(1.0, result![0], 15);
//        Assert.Null(result[1]);
//        Assert.Equal(Math.E, result[2], 15);
//        Assert.Null(result[3]);
//    }

//    [Fact]
//    public void Exps_ParamsOverload_CalculatesAllValues_Generic()
//    {
//        // Act
//        var result = YANMath.Exps<double>(0.0, 1.0, 2.0, 3.0)?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(1.0, result![0], 15);
//        Assert.Equal(Math.E, result[1], 15);
//        Assert.Equal(Math.Exp(2.0), result[2], 15);
//        Assert.Equal(Math.Exp(3.0), result[3], 15);
//    }

//    #endregion

//    #region Exp2

//    [Fact]
//    public void Exp2_NullInput_ReturnsNull_Generic()
//    {
//        // Arrange
//        object? input = null;

//        // Act
//        var result = input.Exp2<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Exp2_Zero_ReturnsOne_Generic()
//    {
//        // Arrange
//        object input = 0.0;

//        // Act
//        var result = input.Exp2<double>();

//        // Assert
//        Assert.Equal(1.0, result);
//    }

//    [Fact]
//    public void Exp2_One_ReturnsTwo_Generic()
//    {
//        // Arrange
//        object input = 1.0;

//        // Act
//        var result = input.Exp2<double>();

//        // Assert
//        Assert.Equal(2.0, result);
//    }

//    [Fact]
//    public void Exp2_StringInput_ConvertsAndCalculates_Generic()
//    {
//        // Arrange
//        object input = "3";

//        // Act
//        var result = input.Exp2<double>();

//        // Assert
//        Assert.Equal(8.0, result);
//    }

//    [Fact]
//    public void Exp2s_NullCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        IEnumerable<object?>? input = null;

//        // Act
//        var result = input.Exp2s<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Exp2s_EmptyCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        var input = Array.Empty<object?>();

//        // Act
//        var result = input.Exp2s<double?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void Exp2s_DoubleCollection_CalculatesAllValues_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 0.0, 1.0, 2.0, 3.0 };

//        // Act
//        var result = input.Exp2s<double>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(new double[] { 1.0, 2.0, 4.0, 8.0 }, result);
//    }

//    [Fact]
//    public void Exp2s_CollectionWithNulls_PreservesNulls_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 0.0, null, 2.0, null };

//        // Act
//        var result = input.Exp2s<double?>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(new double?[] { 1.0, null, 4.0, null }, result);
//    }

//    [Fact]
//    public void Exp2s_ParamsOverload_CalculatesAllValues_Generic()
//    {
//        // Act
//        var result = YANMath.Exp2s<double>(0.0, 1.0, 2.0, 3.0)?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(new double[] { 1.0, 2.0, 4.0, 8.0 }, result);
//    }

//    #endregion

//    #region ILogB

//    [Fact]
//    public void ILogB_NullInput_ReturnsNull_Generic()
//    {
//        // Arrange
//        object? input = null;

//        // Act
//        var result = input.ILogB<int?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void ILogB_PowerOfTwo_ReturnsExponent_Generic()
//    {
//        // Arrange
//        object input = 8.0;

//        // Act
//        var result = input.ILogB<int>();

//        // Assert
//        Assert.Equal(3, result);
//    }

//    [Fact]
//    public void ILogB_One_ReturnsZero_Generic()
//    {
//        // Arrange
//        object input = 1.0;

//        // Act
//        var result = input.ILogB<int>();

//        // Assert
//        Assert.Equal(0, result);
//    }

//    [Fact]
//    public void ILogB_StringInput_ConvertsAndCalculates_Generic()
//    {
//        // Arrange
//        object input = "8";

//        // Act
//        var result = input.ILogB<int>();

//        // Assert
//        Assert.Equal(3, result);
//    }

//    [Fact]
//    public void ILogBs_NullCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        IEnumerable<object?>? input = null;

//        // Act
//        var result = input.ILogBs<int?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void ILogBs_EmptyCollection_ReturnsNull_Generic()
//    {
//        // Arrange
//        var input = Array.Empty<object?>();

//        // Act
//        var result = input.ILogBs<int?>();

//        // Assert
//        Assert.Null(result);
//    }

//    [Fact]
//    public void ILogBs_DoubleCollection_CalculatesAllValues_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 1.0, 2.0, 4.0, 8.0, 16.0 };

//        // Act
//        var result = input.ILogBs<int>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(new int[] { 0, 1, 2, 3, 4 }, result);
//    }

//    [Fact]
//    public void ILogBs_CollectionWithNulls_PreservesNulls_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 1.0, null, 4.0, null, 16.0 };

//        // Act
//        var result = input.ILogBs<int?>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(new int?[] { 0, null, 2, null, 4 }, result);
//    }

//    [Fact]
//    public void ILogBs_ParamsOverload_CalculatesAllValues_Generic()
//    {
//        // Act
//        var result = YANMath.ILogBs<int>(1.0, 2.0, 4.0, 8.0, 16.0)?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(new int[] { 0, 1, 2, 3, 4 }, result);
//    }

//    [Fact]
//    public void ILogBs_StringValues_ConvertsAndCalculates_Generic()
//    {
//        // Arrange
//        var input = new object?[] { "1", "2", "4", "8", "16" };

//        // Act
//        var result = input.ILogBs<int>()?.ToArray();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Equal(new int[] { 0, 1, 2, 3, 4 }, result);
//    }

//    #endregion

//    #region Edge Cases

//    [Fact]
//    public void Sqrt_NegativeNumber_ReturnsNaN_Generic()
//    {
//        // Arrange
//        object input = -4.0;

//        // Act
//        var result = input.Sqrt<double>();

//        // Assert
//        Assert.True(double.IsNaN(result));
//    }

//    [Fact]
//    public void Log_NegativeNumber_ReturnsNaN_Generic()
//    {
//        // Arrange
//        object input = -1.0;

//        // Act
//        var result = input.Log<double>();

//        // Assert
//        Assert.True(double.IsNaN(result));
//    }

//    [Fact]
//    public void Log_Zero_ReturnsNegativeInfinity_Generic()
//    {
//        // Arrange
//        object input = 0.0;

//        // Act
//        var result = input.Log<double>();

//        // Assert
//        Assert.True(double.IsNegativeInfinity(result));
//    }

//    [Fact]
//    public void Asin_GreaterThanOne_ReturnsNaN_Generic()
//    {
//        // Arrange
//        object input = 1.1;

//        // Act
//        var result = input.Asin<double>();

//        // Assert
//        Assert.True(double.IsNaN(result));
//    }

//    [Fact]
//    public void Acos_GreaterThanOne_ReturnsNaN_Generic()
//    {
//        // Arrange
//        object input = 1.1;

//        // Act
//        var result = input.Acos<double>();

//        // Assert
//        Assert.True(double.IsNaN(result));
//    }

//    [Fact]
//    public void Tan_PiDividedBy2_ReturnsVeryLargeNumber_Generic()
//    {
//        // Arrange
//        object input = Math.PI / 2;

//        // Act
//        var result = input.Tan<double>();

//        // Assert
//        Assert.True(Math.Abs(result) > 1e14);
//    }

//    #endregion

//    #region Type Conversion

//    [Fact]
//    public void Min_IntToDecimal_ReturnsDecimal_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 5, 2, 8, 1, 9 };

//        // Act
//        var result = input.Min<decimal>();

//        // Assert
//        Assert.Equal(1m, result);
//        _ = Assert.IsType<decimal>(result);
//    }

//    [Fact]
//    public void Max_IntToFloat_ReturnsFloat_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 5, 2, 8, 1, 9 };

//        // Act
//        var result = input.Max<float>();

//        // Assert
//        Assert.Equal(9f, result);
//        _ = Assert.IsType<float>(result);
//    }

//    [Fact]
//    public void Average_IntToDouble_ReturnsDouble_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 1, 2, 3, 4, 5 };

//        // Act
//        var result = input.Average<double>();

//        // Assert
//        Assert.Equal(3.0, result);
//        _ = Assert.IsType<double>(result);
//    }

//    [Fact]
//    public void Sum_DoubleToLong_ReturnsLong_Generic()
//    {
//        // Arrange
//        var input = new object?[] { 1.1, 2.2, 3.3, 4.4, 5.5 };

//        // Act
//        var result = input.Sum<long>();

//        // Assert
//        Assert.Equal(16L, result);
//        _ = Assert.IsType<long>(result);
//    }

//    [Fact]
//    public void Sqrt_IntToDecimal_ReturnsDecimal_Generic()
//    {
//        // Arrange
//        object input = 16;

//        // Act
//        var result = input.Sqrt<decimal>();

//        // Assert
//        Assert.Equal(4m, result);
//        _ = Assert.IsType<decimal>(result);
//    }

//    [Fact]
//    public void Sin_DoubleToString_ReturnsString_Generic()
//    {
//        // Arrange
//        object input = 0.0;

//        // Act
//        var result = input.Sin<string>();

//        // Assert
//        Assert.Equal("0", result);
//        _ = Assert.IsType<string>(result);
//    }

//    #endregion
//}
