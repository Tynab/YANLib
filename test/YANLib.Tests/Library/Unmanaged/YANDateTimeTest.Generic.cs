namespace YANLib.Tests.Library.Unmanaged;

public partial class YANDateTimeTest
{
    #region GetWeekOfYear

    [Fact]
    public void GetWeekOfYear_Generic_NullInputToInt_ReturnsNull()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.GetWeekOfYear<int?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetWeekOfYear_Generic_DateTimeToInt_ReturnsWeekNumber()
    {
        // Arrange
        object input = new DateTime(2023, 7, 15);

        // Act
        var result = input.GetWeekOfYear<int>();

        // Assert
        Assert.Equal(28, result);
    }

    [Fact]
    public void GetWeekOfYear_Generic_StringDateToInt_ReturnsWeekNumber()
    {
        // Arrange
        object input = "2023-07-15";

        // Act
        var result = input.GetWeekOfYear<int>();

        // Assert
        Assert.Equal(28, result);
    }

    [Fact]
    public void GetWeekOfYear_Generic_InvalidStringToInt_ReturnsZero()
    {
        // Arrange
        object input = "not a date";

        // Act
        var result = input.GetWeekOfYear<int>();

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void GetWeekOfYear_Generic_DateTimeToLong_ReturnsWeekNumber()
    {
        // Arrange
        object input = new DateTime(2023, 7, 15);

        // Act
        var result = input.GetWeekOfYear<long>();

        // Assert
        Assert.Equal(28L, result);
    }

    [Fact]
    public void GetWeekOfYear_Generic_DateTimeToDouble_ReturnsWeekNumber()
    {
        // Arrange
        object input = new DateTime(2023, 7, 15);

        // Act
        var result = input.GetWeekOfYear<double>();

        // Assert
        Assert.Equal(28.0, result);
    }

    [Fact]
    public void GetWeekOfYear_Generic_DateTimeToString_ReturnsWeekNumberAsString()
    {
        // Arrange
        object input = new DateTime(2023, 7, 15);

        // Act
        var result = input.GetWeekOfYear<string>();

        // Assert
        Assert.Equal("28", result);
    }

    [Fact]
    public void GetWeekOfYear_Generic_FirstDayOfYearToInt_ReturnsOne()
    {
        // Arrange
        object input = new DateTime(2023, 1, 1);

        // Act
        var result = input.GetWeekOfYear<int>();

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void GetWeekOfYear_Generic_LastDayOfYearToInt_Returns52or53()
    {
        // Arrange
        object input = new DateTime(2023, 12, 31);

        // Act
        var result = input.GetWeekOfYear<int>();

        // Assert
        Assert.True(result is 52 or 53);
    }

    #endregion

    #region GetWeekOfYears

    [Fact]
    public void GetWeekOfYears_Generic_NullCollectionToInt_ReturnsNull()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.GetWeekOfYears<int>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetWeekOfYears_Generic_EmptyCollectionToInt_ReturnsNull()
    {
        // Arrange
        var input = Array.Empty<object?>();

        // Act
        var result = input.GetWeekOfYears<int>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetWeekOfYears_Generic_DateCollectionToInt_ReturnsWeekNumbers()
    {
        // Arrange
        var input = new object?[]
        {
            new DateTime(2023, 1, 1),
            new DateTime(2023, 7, 15),
            new DateTime(2023, 12, 31)
        };

        var expected = new[] { 1, 28, 53 };

        // Act
        var result = input.GetWeekOfYears<int>();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetWeekOfYears_Generic_MixedCollectionToInt_ReturnsWeekNumbers()
    {
        // Arrange
        var input = new object?[]
        {
            new DateTime(2023, 1, 1),
            null,
            new DateTime(2023, 12, 31)
        };

        // Act
        var result = input.GetWeekOfYears<int?>();

        // Assert
        Assert.Equal([1, null, 53], result);
    }

    [Fact]
    public void GetWeekOfYears_Generic_StringCollectionToInt_ReturnsWeekNumbers()
    {
        // Arrange
        var input = new object?[] { "2023-01-01", "2023-07-15", "2023-12-31" };
        var expected = new[] { 1, 28, 53 };

        // Act
        var result = input.GetWeekOfYears<int>();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetWeekOfYears_Generic_MixedStringCollectionToInt_ReturnsWeekNumbers()
    {
        // Arrange
        var input = new object?[] { "2023-01-01", "not a date", "2023-12-31" };

        // Act
        var result = input.GetWeekOfYears<int?>();

        // Assert
        Assert.Equal([1, null, 53], result);
    }

    [Fact]
    public void GetWeekOfYears_Generic_DateCollectionToLong_ReturnsWeekNumbers()
    {
        // Arrange
        var input = new object?[]
        {
            new DateTime(2023, 1, 1),
            new DateTime(2023, 7, 15),
            new DateTime(2023, 12, 31)
        };

        // Act
        var result = input.GetWeekOfYears<long>();

        // Assert
        Assert.Equal(new long[] { 1, 28, 53 }, result);
    }

    [Fact]
    public void GetWeekOfYears_Generic_DateCollectionToString_ReturnsWeekNumbersAsStrings()
    {
        // Arrange
        var input = new object?[]
        {
            new DateTime(2023, 1, 1),
            new DateTime(2023, 7, 15),
            new DateTime(2023, 12, 31)
        };

        // Act
        var result = input.GetWeekOfYears<string>();

        // Assert
        Assert.Equal(["1", "28", "53"], result);
    }

    [Fact]
    public void GetWeekOfYears_Generic_ParamsDateTimesToInt_ReturnsWeekNumbers()
    {
        // Arrange
        var expected = new[] { 1, 28, 53 };

        // Act
        var result = YANDateTime.GetWeekOfYears<int>(new DateTime(2023, 1, 1), new DateTime(2023, 7, 15), new DateTime(2023, 12, 31));

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetWeekOfYears_Generic_ParamsMixedToInt_ReturnsWeekNumbers()
    {
        // Act
        var result = YANDateTime.GetWeekOfYears<int?>(new DateTime(2023, 1, 1), null, new DateTime(2023, 12, 31));

        // Assert
        Assert.Equal([1, null, 53], result);
    }

    [Fact]
    public void GetWeekOfYears_Generic_ParamsStringsToInt_ReturnsWeekNumbers()
    {
        // Arrange
        var expected = new[] { 1, 28, 53 };

        // Act
        var result = YANDateTime.GetWeekOfYears<int>("2023-01-01", "2023-07-15", "2023-12-31");

        // Assert
        Assert.Equal(expected, result);
    }

    #endregion

    #region TotalMonth

    [Fact]
    public void TotalMonth_Generic_BothNullToInt_ReturnsNull()
    {
        // Arrange
        object? input1 = null;
        object? input2 = null;

        // Act
        var result = YANDateTime.TotalMonth<int?>(input1, input2);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void TotalMonth_Generic_FirstNullToInt_ReturnsNull()
    {
        // Arrange
        object? input1 = null;
        object? input2 = new DateTime(2023, 7, 15);

        // Act
        var result = YANDateTime.TotalMonth<int?>(input1, input2);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void TotalMonth_Generic_SecondNullToInt_ReturnsNull()
    {
        // Arrange
        object? input1 = new DateTime(2023, 7, 15);
        object? input2 = null;

        // Act
        var result = YANDateTime.TotalMonth<int?>(input1, input2);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void TotalMonth_Generic_SameDateToInt_ReturnsZero()
    {
        // Arrange
        object input1 = new DateTime(2023, 7, 15);
        object input2 = new DateTime(2023, 7, 15);

        // Act
        var result = YANDateTime.TotalMonth<int>(input1, input2);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void TotalMonth_Generic_OneMonthDifferenceToInt_ReturnsOne()
    {
        // Arrange
        object input1 = new DateTime(2023, 7, 15);
        object input2 = new DateTime(2023, 8, 15);

        // Act
        var result = YANDateTime.TotalMonth<int>(input1, input2);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void TotalMonth_Generic_OneYearDifferenceToInt_Returns12()
    {
        // Arrange
        object input1 = new DateTime(2022, 7, 15);
        object input2 = new DateTime(2023, 7, 15);

        // Act
        var result = YANDateTime.TotalMonth<int>(input1, input2);

        // Assert
        Assert.Equal(12, result);
    }

    [Fact]
    public void TotalMonth_Generic_NegativeMonthDifferenceToInt_ReturnsPositive()
    {
        // Arrange
        object input1 = new DateTime(2023, 8, 15);
        object input2 = new DateTime(2023, 7, 15);

        // Act
        var result = YANDateTime.TotalMonth<int>(input1, input2);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void TotalMonth_Generic_ComplexDifferenceToInt_ReturnsCorrectMonths()
    {
        // Arrange
        object input1 = new DateTime(2022, 3, 15);
        object input2 = new DateTime(2023, 9, 20);

        // Act
        var result = YANDateTime.TotalMonth<int>(input1, input2);

        // Assert
        Assert.Equal(18, result);
    }

    [Fact]
    public void TotalMonth_Generic_StringDatesToInt_ReturnsMonthDifference()
    {
        // Arrange
        object input1 = "2022-03-15";
        object input2 = "2023-09-20";

        // Act
        var result = YANDateTime.TotalMonth<int>(input1, input2);

        // Assert
        Assert.Equal(18, result);
    }

    [Fact]
    public void TotalMonth_Generic_InvalidStringDatesToInt_ReturnsNull()
    {
        // Arrange
        object input1 = "not a date";
        object input2 = "2023-09-20";

        // Act
        var result = YANDateTime.TotalMonth<int?>(input1, input2);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void TotalMonth_Generic_DateDifferenceToLong_ReturnsLong()
    {
        // Arrange
        object input1 = new DateTime(2022, 3, 15);
        object input2 = new DateTime(2023, 9, 20);

        // Act
        var result = YANDateTime.TotalMonth<long>(input1, input2);

        // Assert
        Assert.Equal(18L, result);
        _ = Assert.IsType<long>(result);
    }

    [Fact]
    public void TotalMonth_Generic_DateDifferenceToDouble_ReturnsDouble()
    {
        // Arrange
        object input1 = new DateTime(2022, 3, 15);
        object input2 = new DateTime(2023, 9, 20);

        // Act
        var result = YANDateTime.TotalMonth<double>(input1, input2);

        // Assert
        Assert.Equal(18.0, result);
        _ = Assert.IsType<double>(result);
    }

    [Fact]
    public void TotalMonth_Generic_DateDifferenceToString_ReturnsString()
    {
        // Arrange
        object input1 = new DateTime(2022, 3, 15);
        object input2 = new DateTime(2023, 9, 20);

        // Act
        var result = YANDateTime.TotalMonth<string>(input1, input2);

        // Assert
        Assert.Equal("18", result);
        _ = Assert.IsType<string>(result);
    }

    #endregion

    #region Edge Cases

    [Fact]
    public void GetWeekOfYear_Generic_MinValueToInt_ReturnsWeekNumber()
    {
        // Arrange
        object input = DateTime.MinValue;

        // Act
        var result = input.GetWeekOfYear<int>();

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void GetWeekOfYear_Generic_MaxValueToInt_ReturnsWeekNumber()
    {
        // Arrange
        object input = DateTime.MaxValue;

        // Act
        var result = input.GetWeekOfYear<int>();

        // Assert
        Assert.True(result is 52 or 53);
    }

    [Fact]
    public void TotalMonth_Generic_MinMaxValuesToInt_ReturnsLargeNumber()
    {
        // Arrange
        object input1 = DateTime.MinValue;
        object input2 = DateTime.MaxValue;

        // Act
        var result = YANDateTime.TotalMonth<int>(input1, input2);

        // Assert
        Assert.Equal(119987, result);
    }

    [Fact]
    public void TotalMonth_Generic_MaxMinValuesToInt_ReturnsSameAsMinMax()
    {
        // Arrange
        object input1 = DateTime.MaxValue;
        object input2 = DateTime.MinValue;

        // Act
        var result = YANDateTime.TotalMonth<int>(input1, input2);

        // Assert
        Assert.Equal(119987, result);
    }

    [Fact]
    public void GetWeekOfYear_Generic_DBNullToInt_ReturnsNull()
    {
        // Arrange
        object input = DBNull.Value;

        // Act
        var result = input.GetWeekOfYear<int?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetWeekOfYear_Generic_EmptyStringToInt_ReturnsNull()
    {
        // Arrange
        object input = "";

        // Act
        var result = input.GetWeekOfYear<int?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetWeekOfYear_Generic_WhitespaceStringToInt_ReturnsNull()
    {
        // Arrange
        object input = "   ";

        // Act
        var result = input.GetWeekOfYear<int?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetWeekOfYears_Generic_AllInvalidInputsToInt_ReturnsAllNulls()
    {
        // Arrange
        var input = new object?[]
        {
            "not a date",
            null,
            "also not a date"
        };

        // Act
        var result = input.GetWeekOfYears<int?>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Length);
        Assert.Null(result[0]);
        Assert.Null(result[1]);
        Assert.Null(result[2]);
    }

    #endregion

    #region Special Types

    [Fact]
    public void GetWeekOfYear_Generic_DateTimeToDecimal_ReturnsDecimal()
    {
        // Arrange
        object input = new DateTime(2023, 7, 15);

        // Act
        var result = input.GetWeekOfYear<decimal>();

        // Assert
        Assert.Equal(28m, result);
        _ = Assert.IsType<decimal>(result);
    }

    [Fact]
    public void GetWeekOfYear_Generic_DateTimeToFloat_ReturnsFloat()
    {
        // Arrange
        object input = new DateTime(2023, 7, 15);

        // Act
        var result = input.GetWeekOfYear<float>();

        // Assert
        Assert.Equal(28f, result);
        _ = Assert.IsType<float>(result);
    }

    [Fact]
    public void GetWeekOfYear_Generic_DateTimeToShort_ReturnsShort()
    {
        // Arrange
        object input = new DateTime(2023, 7, 15);

        // Act
        var result = input.GetWeekOfYear<short>();

        // Assert
        Assert.Equal((short)28, result);
        _ = Assert.IsType<short>(result);
    }

    [Fact]
    public void GetWeekOfYear_Generic_DateTimeToUInt_ReturnsUInt()
    {
        // Arrange
        object input = new DateTime(2023, 7, 15);

        // Act
        var result = input.GetWeekOfYear<uint>();

        // Assert
        Assert.Equal(28u, result);
        _ = Assert.IsType<uint>(result);
    }

    [Fact]
    public void GetWeekOfYear_Generic_DateTimeToChar_ReturnsChar()
    {
        // Arrange
        object input = new DateTime(2023, 1, 5);

        // Act
        var result = input.GetWeekOfYear<char>();

        // Assert
        Assert.Equal('1', result);
        _ = Assert.IsType<char>(result);
    }

    [Fact]
    public void GetWeekOfYear_Generic_DateTimeOffsetToInt_ReturnsWeekNumber()
    {
        // Arrange
        object input = new DateTimeOffset(2023, 7, 15, 0, 0, 0, TimeSpan.Zero);

        // Act
        var result = input.GetWeekOfYear<int>();

        // Assert
        Assert.Equal(28, result);
    }

    [Fact]
    public void GetWeekOfYear_Generic_DateTimeOffsetStringToInt_ReturnsWeekNumber()
    {
        // Arrange
        object input = "2023-07-15T00:00:00+00:00";

        // Act
        var result = input.GetWeekOfYear<int>();

        // Assert
        Assert.Equal(28, result);
    }

    [Fact]
    public void GetWeekOfYear_Generic_CustomFormattedDateStringToInt_ReturnsWeekNumber()
    {
        // Arrange
        object input = "2023/07/15";

        // Act
        var result = input.GetWeekOfYear<int>();

        // Assert
        Assert.Equal(28, result);
    }

    #endregion
}
