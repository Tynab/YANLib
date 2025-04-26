namespace YANLib.Tests.Library.Unmanaged;

public partial class YANDateTimeTest
{
    #region GetWeekOfYear

    [Fact]
    public void GetWeekOfYear_DateTime_NullInput_ReturnsZero()
    {
        // Arrange
        DateTime? input = null;

        // Act
        var result = input.GetWeekOfYear();

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void GetWeekOfYear_DateTime_FirstDayOfYear_ReturnsOne()
    {
        // Arrange
        var input = new DateTime(2023, 1, 1);

        // Act
        var result = input.GetWeekOfYear();

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void GetWeekOfYear_DateTime_LastDayOfYear_Returns52or53()
    {
        // Arrange
        var input = new DateTime(2023, 12, 31);

        // Act
        var result = input.GetWeekOfYear();

        // Assert
        Assert.True(result is 52 or 53);
    }

    [Fact]
    public void GetWeekOfYear_DateTime_MiddleOfYear_ReturnsCorrectWeek()
    {
        // Arrange
        var input = new DateTime(2023, 7, 15);

        // Act
        var result = input.GetWeekOfYear();

        // Assert
        Assert.Equal(28, result);
    }

    [Fact]
    public void GetWeekOfYear_DateTime_StringInput_ReturnsWeekNumber()
    {
        // Arrange
        var input = "2023-07-15";

        // Act
        var result = input.GetWeekOfYear();

        // Assert
        Assert.Equal(28, result);
    }

    [Fact]
    public void GetWeekOfYear_DateTime_InvalidStringInput_ReturnsZero()
    {
        // Arrange
        var input = "not a date";

        // Act
        var result = input.GetWeekOfYear();

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void GetWeekOfYear_DateTime_IntInput_ReturnsZero()
    {
        // Arrange
        var input = 12345;

        // Act
        var result = input.GetWeekOfYear();

        // Assert
        Assert.Equal(0, result);
    }

    #endregion

    #region GetWeekOfYears

    [Fact]
    public void GetWeekOfYears_DateTime_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<DateTime?>? input = null;

        // Act
        var result = input.GetWeekOfYears();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetWeekOfYears_DateTime_EmptyCollection_ReturnsNull()
    {
        // Arrange
        var input = Array.Empty<DateTime?>();

        // Act
        var result = input.GetWeekOfYears();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetWeekOfYears_DateTime_DateCollection_ReturnsWeekNumbers()
    {
        // Arrange
        var input = new DateTime?[]
        {
            new (2023, 1, 1),
            new (2023, 7, 15),
            new (2023, 12, 31)
        };

        // Act
        var result = input.GetWeekOfYears();

        // Assert
        Assert.Equal([1, 28, 53], result);
    }

    [Fact]
    public void GetWeekOfYears_DateTime_MixedCollection_ReturnsWeekNumbers()
    {
        // Arrange
        var input = new DateTime?[]
        {
            new (2023, 1, 1),
            null,
            new (2023, 12, 31)
        };

        // Act
        var result = input.GetWeekOfYears();

        // Assert
        Assert.Equal([1, 0, 53], result);
    }

    [Fact]
    public void GetWeekOfYears_DateTime_StringCollection_ReturnsWeekNumbers()
    {
        // Arrange
        var input = new string?[] { "2023-01-01", "2023-07-15", "2023-12-31" };

        // Act
        var result = input.GetWeekOfYears();

        // Assert
        Assert.Equal([1, 28, 53], result);
    }

    [Fact]
    public void GetWeekOfYears_DateTime_MixedStringCollection_ReturnsWeekNumbers()
    {
        // Arrange
        var input = new string?[] { "2023-01-01", "not a date", "2023-12-31" };

        // Act
        var result = input.GetWeekOfYears();

        // Assert
        Assert.Equal([1, 0, 53], result);
    }

    [Fact]
    public void GetWeekOfYears_DateTime_ParamsDateTimes_ReturnsWeekNumbers()
    {
        // Act
        var result = YANDateTime.GetWeekOfYears(new DateTime(2023, 1, 1), new(2023, 7, 15), new(2023, 12, 31));

        // Assert
        Assert.Equal([1, 28, 53], result);
    }

    [Fact]
    public void GetWeekOfYears_DateTime_ParamsMixed_ReturnsWeekNumbers()
    {
        // Act
        var result = YANDateTime.GetWeekOfYears(new(2023, 1, 1), (DateTime?)null, new(2023, 12, 31));

        // Assert
        Assert.Equal([1, 0, 53], result);
    }

    [Fact]
    public void GetWeekOfYears_DateTime_ParamsStrings_ReturnsWeekNumbers()
    {
        // Act
        var result = YANDateTime.GetWeekOfYears("2023-01-01", "2023-07-15", "2023-12-31");

        // Assert
        Assert.Equal([1, 28, 53], result);
    }

    #endregion

    #region TotalMonth

    [Fact]
    public void TotalMonth_DateTime_BothNull_ReturnsZero()
    {
        // Arrange
        DateTime? input1 = null;
        DateTime? input2 = null;

        // Act
        var result = YANDateTime.TotalMonth(input1, input2);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void TotalMonth_DateTime_FirstNull_ReturnsZero()
    {
        // Arrange
        DateTime? input1 = null;
        DateTime? input2 = new DateTime(2023, 7, 15);

        // Act
        var result = YANDateTime.TotalMonth(input1, input2);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void TotalMonth_DateTime_SecondNull_ReturnsZero()
    {
        // Arrange
        DateTime? input1 = new DateTime(2023, 7, 15);
        DateTime? input2 = null;

        // Act
        var result = YANDateTime.TotalMonth(input1, input2);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void TotalMonth_DateTime_SameDate_ReturnsZero()
    {
        // Arrange
        var input1 = new DateTime(2023, 7, 15);
        var input2 = new DateTime(2023, 7, 15);

        // Act
        var result = YANDateTime.TotalMonth(input1, input2);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void TotalMonth_DateTime_OneMonthDifference_ReturnsOne()
    {
        // Arrange
        var input1 = new DateTime(2023, 7, 15);
        var input2 = new DateTime(2023, 8, 15);

        // Act
        var result = YANDateTime.TotalMonth(input1, input2);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void TotalMonth_DateTime_OneYearDifference_Returns12()
    {
        // Arrange
        var input1 = new DateTime(2022, 7, 15);
        var input2 = new DateTime(2023, 7, 15);

        // Act
        var result = YANDateTime.TotalMonth(input1, input2);

        // Assert
        Assert.Equal(12, result);
    }

    [Fact]
    public void TotalMonth_DateTime_NegativeMonthDifference_ReturnsNegative()
    {
        // Arrange
        var input1 = new DateTime(2023, 8, 15);
        var input2 = new DateTime(2023, 7, 15);

        // Act
        var result = YANDateTime.TotalMonth(input1, input2);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void TotalMonth_DateTime_ComplexDifference_ReturnsCorrectMonths()
    {
        // Arrange
        var input1 = new DateTime(2022, 3, 15);
        var input2 = new DateTime(2023, 9, 20);

        // Act
        var result = YANDateTime.TotalMonth(input1, input2);

        // Assert
        Assert.Equal(18, result);
    }

    [Fact]
    public void TotalMonth_DateTime_StringDates_ReturnsMonthDifference()
    {
        // Arrange
        var input1 = "2022-03-15";
        var input2 = "2023-09-20";

        // Act
        var result = YANDateTime.TotalMonth(input1, input2);

        // Assert
        Assert.Equal(18, result);
    }

    [Fact]
    public void TotalMonth_DateTime_InvalidStringDates_ReturnsZero()
    {
        // Arrange
        var input1 = "not a date";
        var input2 = "2023-09-20";

        // Act
        var result = YANDateTime.TotalMonth(input1, input2);

        // Assert
        Assert.Equal(0, result);
    }

    #endregion

    #region ChangeTimeZone

    [Fact]
    public void ChangeTimeZone_DateTime_SameTimeZone_ReturnsSameDateTime()
    {
        // Arrange
        var input = new DateTime(2023, 7, 15, 12, 0, 0);
        var tzSrc = 0;
        var tzDst = 0;

        // Act
        var result = input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal(input, result);
    }

    [Fact]
    public void ChangeTimeZone_DateTime_PositiveOffset_AddsHours()
    {
        // Arrange
        var input = new DateTime(2023, 7, 15, 12, 0, 0);
        var tzSrc = 0;
        var tzDst = 5;

        // Act
        var result = input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal(new DateTime(2023, 7, 15, 17, 0, 0), result);
    }

    [Fact]
    public void ChangeTimeZone_DateTime_NegativeOffset_SubtractsHours()
    {
        // Arrange
        var input = new DateTime(2023, 7, 15, 12, 0, 0);
        var tzSrc = 0;
        var tzDst = -5;

        // Act
        var result = input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal(new DateTime(2023, 7, 15, 7, 0, 0), result);
    }

    [Fact]
    public void ChangeTimeZone_DateTime_StringTimeZones_ChangesTime()
    {
        // Arrange
        var input = new DateTime(2023, 7, 15, 12, 0, 0);
        var tzSrc = "0";
        var tzDst = "5";

        // Act
        var result = input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal(new DateTime(2023, 7, 15, 17, 0, 0), result);
    }

    [Fact]
    public void ChangeTimeZone_DateTime_NearMinValue_HandlesUnderflow()
    {
        // Arrange
        var input = DateTime.MinValue.AddHours(2);
        var tzSrc = 0;
        var tzDst = -3;

        // Act
        var result = input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal(input, result);
    }

    [Fact]
    public void ChangeTimeZone_DateTime_NearMaxValue_HandlesOverflow()
    {
        // Arrange
        var input = DateTime.MaxValue.AddHours(-2);
        var tzSrc = 0;
        var tzDst = 3;

        // Act
        var result = input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal(input, result);
    }

    [Fact]
    public void ChangeTimeZone_DateTime_NullTimeZones_UsesDefaultValues()
    {
        // Arrange
        var input = new DateTime(2023, 7, 15, 12, 0, 0);

        // Act
        var result = input.ChangeTimeZone();

        // Assert
        Assert.Equal(input, result);
    }

    #endregion

    #region ChangeTimeZone List

    [Fact]
    public void ChangeTimeZone_DateTime_NullList_DoesNotThrow()
    {
        // Arrange
        List<DateTime>? input = null;

        // Act
        var exception = Record.Exception(() => input.ChangeTimeZone(0, 5));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void ChangeTimeZone_DateTime_EmptyList_DoesNotThrow()
    {
        // Arrange
        var input = new List<DateTime>();

        // Act
        var exception = Record.Exception(() => input.ChangeTimeZone(0, 5));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void ChangeTimeZone_DateTime_DateTimeList_ChangesAllTimes()
    {
        // Arrange
        var input = new List<DateTime>
        {
            new(2023, 7, 15, 12, 0, 0),
            new(2023, 7, 16, 12, 0, 0),
            new(2023, 7, 17, 12, 0, 0)
        };

        var tzSrc = 0;
        var tzDst = 5;

        // Act
        input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal([new(2023, 7, 15, 17, 0, 0), new(2023, 7, 16, 17, 0, 0), new(2023, 7, 17, 17, 0, 0)], input);
    }

    #endregion

    #region ChangeTimeZones

    [Fact]
    public void ChangeTimeZones_DateTime_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<DateTime>? input = null;

        // Act
        var result = input.ChangeTimeZones(0, 5);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ChangeTimeZones_DateTime_EmptyCollection_ReturnsEmpty()
    {
        // Arrange
        var input = Array.Empty<DateTime>();

        // Act
        var result = input.ChangeTimeZones(0, 5);

        // Assert
        Assert.Empty(result!);
    }

    [Fact]
    public void ChangeTimeZones_DateTime_DateTimeCollection_ChangesAllTimes()
    {
        // Arrange
        var input = new[]
        {
            new DateTime(2023, 7, 15, 12, 0, 0),
            new (2023, 7, 16, 12, 0, 0),
            new (2023, 7, 17, 12, 0, 0)
        };

        var tzSrc = 0;
        var tzDst = 5;

        // Act
        var result = input.ChangeTimeZones(tzSrc, tzDst);

        // Assert
        Assert.Equal([new(2023, 7, 15, 17, 0, 0), new(2023, 7, 16, 17, 0, 0), new(2023, 7, 17, 17, 0, 0)], result);
    }

    [Fact]
    public void ChangeTimeZones_DateTime_StringTimeZones_ChangesAllTimes()
    {
        // Arrange
        var input = new[]
        {
            new DateTime(2023, 7, 15, 12, 0, 0),
            new (2023, 7, 16, 12, 0, 0),
            new (2023, 7, 17, 12, 0, 0)
        };

        var tzSrc = "0";
        var tzDst = "5";

        // Act
        var result = input.ChangeTimeZones(tzSrc, tzDst);

        // Assert
        Assert.Equal([new(2023, 7, 15, 17, 0, 0), new(2023, 7, 16, 17, 0, 0), new(2023, 7, 17, 17, 0, 0)], result);
    }

    #endregion

    #region Edge Cases

    [Fact]
    public void GetWeekOfYear_DateTime_MinValue_ReturnsWeekNumber()
    {
        // Arrange
        var input = DateTime.MinValue;

        // Act
        var result = input.GetWeekOfYear();

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void GetWeekOfYear_DateTime_MaxValue_ReturnsWeekNumber()
    {
        // Arrange
        var input = DateTime.MaxValue;

        // Act
        var result = input.GetWeekOfYear();

        // Assert
        Assert.True(result is 52 or 53);
    }

    [Fact]
    public void TotalMonth_DateTime_MinMaxValues_ReturnsLargeNumber()
    {
        // Arrange
        var input1 = DateTime.MinValue;
        var input2 = DateTime.MaxValue;

        // Act
        var result = YANDateTime.TotalMonth(input1, input2);

        // Assert
        Assert.Equal(119987, result);
    }

    [Fact]
    public void TotalMonth_DateTime_MaxMinValues_ReturnsNegativeLargeNumber()
    {
        // Arrange
        var input1 = DateTime.MaxValue;
        var input2 = DateTime.MinValue;

        // Act
        var result = YANDateTime.TotalMonth(input1, input2);

        // Assert
        Assert.Equal(119987, result);
    }

    [Fact]
    public void ChangeTimeZone_DateTime_ExactlyMinValue_ReturnsMinValue()
    {
        // Arrange
        var input = DateTime.MinValue;
        var tzSrc = 0;
        var tzDst = -5;

        // Act
        var result = input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal(input, result);
    }

    [Fact]
    public void ChangeTimeZone_DateTime_ExactlyMaxValue_ReturnsMaxValue()
    {
        // Arrange
        var input = DateTime.MaxValue;
        var tzSrc = 0;
        var tzDst = 5;

        // Act
        var result = input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal(input, result);
    }

    #endregion
}
