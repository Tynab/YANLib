using System.Globalization;
using YANLib.Unmanaged;

namespace YANLib.Tests.Library.Unmanaged;

public partial class YANDateTimeTest
{
    #region GetWeekOfYear
    [Fact]
    public void GetWeekOfYear_NullInput_ReturnsZero()
    {
        // Arrange
        DateTime? input = null;

        // Act
        var result = input.GetWeekOfYear();

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void GetWeekOfYear_ValidDate_ReturnsCorrectWeekNumber()
    {
        // Arrange
        var input = new DateTime(2023, 1, 15);
        var expected = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(input, CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);

        // Act
        var result = input.GetWeekOfYear();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetWeekOfYear_FirstDayOfYear_ReturnsWeekOne()
    {
        // Arrange
        var input = new DateTime(2023, 1, 1);
        var expected = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(input, CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);

        // Act
        var result = input.GetWeekOfYear();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetWeekOfYear_LastDayOfYear_ReturnsLastWeek()
    {
        // Arrange
        var input = new DateTime(2023, 12, 31);
        var expected = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(input, CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);

        // Act
        var result = input.GetWeekOfYear();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetWeekOfYear_StringInput_ParsesAndReturnsWeekNumber()
    {
        // Arrange
        var input = "2023-01-15";
        var expected = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(input.Parse<DateTime>(), CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);

        // Act
        var result = input.GetWeekOfYear();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetWeekOfYear_InvalidStringInput_ReturnsZero()
    {
        // Arrange
        var input = "not a date";

        // Act
        var result = input.GetWeekOfYear();

        // Assert
        Assert.Equal(0, result);
    }
    #endregion

    #region GetWeekOfYears
    [Fact]
    public void GetWeekOfYears_NullInput_ReturnsNull()
    {
        // Arrange
        IEnumerable<DateTime>? input = null;

        // Act
        var result = input.GetWeekOfYears();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetWeekOfYears_EmptyInput_ReturnsNull()
    {
        // Arrange
        IEnumerable<DateTime> input = [];

        // Act
        var result = input.GetWeekOfYears();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetWeekOfYears_ValidDates_ReturnsCorrectWeekNumbers()
    {
        // Arrange
        var input = new List<DateTime>
        {
            new(2023, 1, 1),
            new(2023, 1, 15),
            new(2023, 12, 31)
        };

        var expected = input.Select(date => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date, CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek)).ToList();

        // Act
        var result = input.GetWeekOfYears();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetWeekOfYears_MixedValidAndNullDates_HandlesNullsCorrectly()
    {
        // Arrange
        var input = new List<DateTime?>
        {
            new DateTime(2023, 1, 1),
            null,
            new DateTime(2023, 12, 31)
        };

        var expected = input.Select(date => date.HasValue
            ? CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date.Value, CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek)
            : 0).ToList();

        // Act
        var result = input.GetWeekOfYears();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetWeekOfYears_StringDates_ParsesAndReturnsWeekNumbers()
    {
        // Arrange
        var input = new List<string>
        {
            "2023-01-01",
            "2023-01-15",
            "2023-12-31"
        };

        var expected = input.Select(dateStr => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(dateStr.Parse<DateTime>(), CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek)).ToList();

        // Act
        var result = input.GetWeekOfYears();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetWeekOfYears_Params_NullInput_ReturnsNull()
    {
        // Arrange
        DateTime[]? input = null;

        // Act
        var result = YANDateTime.GetWeekOfYears(input);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetWeekOfYears_Params_EmptyInput_ReturnsNull()
    {
        // Arrange
        object[] input = [];

        // Act
        var result = YANDateTime.GetWeekOfYears(input);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetWeekOfYears_Params_ValidDates_ReturnsCorrectWeekNumbers()
    {
        // Arrange
        var date1 = new DateTime(2023, 1, 1);
        var date2 = new DateTime(2023, 1, 15);
        var date3 = new DateTime(2023, 12, 31);
        var expected = new[]
        {
            CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date1, CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek),
            CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date2, CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek),
            CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date3, CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek)
        };

        // Act
        var result = YANDateTime.GetWeekOfYears(date1, date2, date3);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }
    #endregion

    #region TotalMonth
    [Fact]
    public void TotalMonth_BothInputsNull_ReturnsZero()
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
    public void TotalMonth_FirstInputNull_ReturnsZero()
    {
        // Arrange
        DateTime? input1 = null;
        DateTime? input2 = new DateTime(2023, 6, 15);

        // Act
        var result = YANDateTime.TotalMonth(input1, input2);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void TotalMonth_SecondInputNull_ReturnsZero()
    {
        // Arrange
        DateTime? input1 = new DateTime(2023, 6, 15);
        DateTime? input2 = null;

        // Act
        var result = YANDateTime.TotalMonth(input1, input2);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void TotalMonth_SameDate_ReturnsZero()
    {
        // Arrange
        var date = new DateTime(2023, 6, 15);

        // Act
        var result = YANDateTime.TotalMonth(date, date);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void TotalMonth_OneMonthDifference_ReturnsOne()
    {
        // Arrange
        var date1 = new DateTime(2023, 6, 15);
        var date2 = new DateTime(2023, 7, 15);

        // Act
        var result = YANDateTime.TotalMonth(date1, date2);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void TotalMonth_OneYearDifference_ReturnsTwelve()
    {
        // Arrange
        var date1 = new DateTime(2022, 6, 15);
        var date2 = new DateTime(2023, 6, 15);

        // Act
        var result = YANDateTime.TotalMonth(date1, date2);

        // Assert
        Assert.Equal(12, result);
    }

    [Fact]
    public void TotalMonth_NegativeMonthDifference_ReturnsAbsoluteValue()
    {
        // Arrange
        var date1 = new DateTime(2023, 7, 15);
        var date2 = new DateTime(2023, 6, 15);

        // Act
        var result = YANDateTime.TotalMonth(date1, date2);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void TotalMonth_PartialMonthDifference_ReturnsTruncatedValue()
    {
        // Arrange
        var date1 = new DateTime(2023, 6, 1);
        var date2 = new DateTime(2023, 7, 15);

        // Act
        var result = YANDateTime.TotalMonth(date1, date2);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void TotalMonth_StringDates_ParsesAndCalculatesMonths()
    {
        // Arrange
        var date1 = "2022-06-15";
        var date2 = "2023-06-15";

        // Act
        var result = YANDateTime.TotalMonth(date1, date2);

        // Assert
        Assert.Equal(12, result);
    }

    [Fact]
    public void TotalMonth_InvalidStringDates_ReturnsZero()
    {
        // Arrange
        var date1 = "not a date";
        var date2 = "2023-06-15";

        // Act
        var result = YANDateTime.TotalMonth(date1, date2);

        // Assert
        Assert.Equal(0, result);
    }
    #endregion

    #region ChangeTimeZone
    [Fact]
    public void ChangeTimeZone_DateTime_NoTimeZoneSpecified_ReturnsSameDateTime()
    {
        // Arrange
        var input = new DateTime(2023, 6, 15, 12, 0, 0);

        // Act
        var result = input.ChangeTimeZone();

        // Assert
        Assert.Equal(input, result);
    }

    [Fact]
    public void ChangeTimeZone_DateTime_SameTimeZones_ReturnsSameDateTime()
    {
        // Arrange
        var input = new DateTime(2023, 6, 15, 12, 0, 0);
        var tzSrc = 7;
        var tzDst = 7;

        // Act
        var result = input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal(input, result);
    }

    [Fact]
    public void ChangeTimeZone_DateTime_PositiveTimeZoneDifference_AddsHours()
    {
        // Arrange
        var input = new DateTime(2023, 6, 15, 12, 0, 0);
        var tzSrc = 0;
        var tzDst = 7;

        // Act
        var result = input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal(input.AddHours(7), result);
    }

    [Fact]
    public void ChangeTimeZone_DateTime_NegativeTimeZoneDifference_SubtractsHours()
    {
        // Arrange
        var input = new DateTime(2023, 6, 15, 12, 0, 0);
        var tzSrc = 7;
        var tzDst = 0;

        // Act
        var result = input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal(input.AddHours(-7), result);
    }

    [Fact]
    public void ChangeTimeZone_DateTime_StringTimeZones_ParsesAndConvertsCorrectly()
    {
        // Arrange
        var input = new DateTime(2023, 6, 15, 12, 0, 0);
        var tzSrc = "0";
        var tzDst = "7";

        // Act
        var result = input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal(input.AddHours(7), result);
    }

    [Fact]
    public void ChangeTimeZone_DateTime_NegativeResultExceedsMinValue_ReturnsSameDateTime()
    {
        // Arrange
        var input = DateTime.MinValue.AddHours(5);
        var tzSrc = 0;
        var tzDst = -7;

        // Act
        var result = input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal(input, result);
    }

    [Fact]
    public void ChangeTimeZone_DateTime_PositiveResultExceedsMaxValue_ReturnsSameDateTime()
    {
        // Arrange
        var input = DateTime.MaxValue.AddHours(-5);
        var tzSrc = 0;
        var tzDst = 7;

        // Act
        var result = input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal(input, result);
    }

    [Fact]
    public void ChangeTimeZone_DateTimeList_NullInput_DoesNotThrow()
    {
        // Arrange
        List<DateTime>? input = null;

        // Act
        var exception = Record.Exception(() => input.ChangeTimeZone());

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void ChangeTimeZone_DateTimeList_EmptyInput_DoesNotThrow()
    {
        // Arrange
        var input = new List<DateTime>();

        // Act
        var exception = Record.Exception(() => input.ChangeTimeZone());

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void ChangeTimeZone_DateTimeList_ValidInput_UpdatesAllItems()
    {
        // Arrange
        var date1 = new DateTime(2023, 6, 15, 12, 0, 0);
        var date2 = new DateTime(2023, 6, 16, 12, 0, 0);
        var input = new List<DateTime> { date1, date2 };
        var tzSrc = 0;
        var tzDst = 7;
        var expected1 = date1.AddHours(7);
        var expected2 = date2.AddHours(7);

        // Act
        input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal(expected1, input[0]);
        Assert.Equal(expected2, input[1]);
    }
    #endregion

    #region ChangeTimeZones
    [Fact]
    public void ChangeTimeZones_DateTimeEnumerable_NullInput_ReturnsNull()
    {
        // Arrange
        IEnumerable<DateTime>? input = null;

        // Act
        var result = input.ChangeTimeZones();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ChangeTimeZones_DateTimeEnumerable_EmptyInput_ReturnsNull()
    {
        // Arrange
        IEnumerable<DateTime> input = [];

        // Act
        var result = input.ChangeTimeZones();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ChangeTimeZones_DateTimeEnumerable_ValidInput_ReturnsConvertedDates()
    {
        // Arrange
        var date1 = new DateTime(2023, 6, 15, 12, 0, 0);
        var date2 = new DateTime(2023, 6, 16, 12, 0, 0);
        var input = new List<DateTime> { date1, date2 };
        var tzSrc = 0;
        var tzDst = 7;
        var expected = new[]
        {
            date1.AddHours(7),
            date2.AddHours(7)
        };

        // Act
        var result = input.ChangeTimeZones(tzSrc, tzDst);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ChangeTimeZones_DateTimeEnumerable_LargeCollection_ProcessesAllItems()
    {
        // Arrange
        var baseDate = new DateTime(2023, 1, 1);
        var input = Enumerable.Range(0, 1001).Select(i => baseDate.AddDays(i)).ToList();
        var tzSrc = 0;
        var tzDst = 7;

        // Act
        var result = input.ChangeTimeZones(tzSrc, tzDst);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1001, result.Count());
        Assert.All(result, date => Assert.Equal(7, date.Hour));
    }
    #endregion
}
