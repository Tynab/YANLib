using System.Globalization;
using YANLib.Unmanaged;

namespace YANLib.Tests.Library.Unmanaged;

public partial class YANDateTimeTest
{
    #region GetWeekOfYear
    [Fact]
    public void GetWeekOfYear_Generic_NullInput_ReturnsDefault()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.GetWeekOfYear<int>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void GetWeekOfYear_Generic_ValidDate_ReturnsCorrectWeekNumber()
    {
        // Arrange
        object input = new DateTime(2023, 1, 15);
        var expected = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(input.Parse<DateTime>(), CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);

        // Act
        var result = input.GetWeekOfYear<int>();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetWeekOfYear_Generic_StringDate_ReturnsCorrectWeekNumber()
    {
        // Arrange
        object input = "2023-01-15";
        var expected = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(input.Parse<DateTime>(), CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);

        // Act
        var result = input.GetWeekOfYear<int>();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetWeekOfYear_Generic_InvalidString_ReturnsDefault()
    {
        // Arrange
        object input = "not a date";

        // Act
        var result = input.GetWeekOfYear<int>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void GetWeekOfYear_Generic_ReturnsDifferentNumericTypes()
    {
        // Arrange
        object input = new DateTime(2023, 1, 15);
        var expected = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(input.Parse<DateTime>(), CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);

        // Act
        var resultInt = input.GetWeekOfYear<int>();
        var resultLong = input.GetWeekOfYear<long>();
        var resultDouble = input.GetWeekOfYear<double>();

        // Assert
        Assert.Equal(expected, resultInt);
        Assert.Equal(expected, resultLong);
        Assert.Equal(expected, resultDouble);
    }
    #endregion

    #region GetWeekOfYears
    [Fact]
    public void GetWeekOfYears_Generic_NullInput_ReturnsNull()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.GetWeekOfYears<int>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetWeekOfYears_Generic_EmptyInput_ReturnsNull()
    {
        // Arrange
        IEnumerable<object> input = [];

        // Act
        var result = input.GetWeekOfYears<int>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetWeekOfYears_Generic_ValidDates_ReturnsCorrectWeekNumbers()
    {
        // Arrange
        var date1 = new DateTime(2023, 1, 1);
        var date2 = new DateTime(2023, 1, 15);
        var date3 = new DateTime(2023, 12, 31);
        var input = new List<object> { date1, date2, date3 };
        var expected = new List<int>
        {
            CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date1, CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek),
            CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date2, CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek),
            CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date3, CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek)
        };

        // Act
        var result = input.GetWeekOfYears<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetWeekOfYears_Generic_StringDates_ReturnsCorrectWeekNumbers()
    {
        // Arrange
        var input = new List<object>
        {
            "2023-01-01",
            "2023-01-15",
            "2023-12-31"
        };

        var expected = new List<int>
        {
            CultureInfo.CurrentCulture.Calendar.GetWeekOfYear("2023-01-01".Parse<DateTime>(), CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek),
            CultureInfo.CurrentCulture.Calendar.GetWeekOfYear("2023-01-15".Parse<DateTime>(), CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek),
            CultureInfo.CurrentCulture.Calendar.GetWeekOfYear("2023-12-31".Parse<DateTime>(), CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek)
        };

        // Act
        var result = input.GetWeekOfYears<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetWeekOfYears_Generic_MixedValidAndInvalidInputs_HandlesInvalidInputsCorrectly()
    {
        // Arrange
        var date = new DateTime(2023, 1, 15);
        var input = new List<object?> { date, null, "not a date", "2023-12-31" };
        var expected = new List<int?>
        {
            CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date, CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek),
            default,
            default,
            CultureInfo.CurrentCulture.Calendar.GetWeekOfYear("2023-12-31".Parse<DateTime>(), CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek)
        };

        // Act
        var result = input.GetWeekOfYears<int?>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetWeekOfYears_Generic_Params_NullInput_ReturnsNull()
    {
        // Arrange
        object[]? input = null;

        // Act
        var result = YANDateTime.GetWeekOfYears<int>(input);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetWeekOfYears_Generic_Params_EmptyInput_ReturnsNull()
    {
        // Arrange
        object[] input = [];

        // Act
        var result = YANDateTime.GetWeekOfYears<int>(input);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetWeekOfYears_Generic_Params_ValidDates_ReturnsCorrectWeekNumbers()
    {
        // Arrange
        var date1 = new DateTime(2023, 1, 1);
        var date2 = new DateTime(2023, 1, 15);
        var date3 = new DateTime(2023, 12, 31);
        var expected = new List<int?>
        {
            CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date1, CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek),
            CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date2, CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek),
            CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date3, CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek)
        };

        // Act
        var result = YANDateTime.GetWeekOfYears<int?>(date1, date2, date3);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetWeekOfYears_Generic_Params_StringDates_ReturnsCorrectWeekNumbers()
    {
        // Arrange
        var expected = new List<int?>
        {
            CultureInfo.CurrentCulture.Calendar.GetWeekOfYear("2023-01-01".Parse<DateTime>(), CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek),
            CultureInfo.CurrentCulture.Calendar.GetWeekOfYear("2023-01-15".Parse<DateTime>(), CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek),
            CultureInfo.CurrentCulture.Calendar.GetWeekOfYear("2023-12-31".Parse<DateTime>(), CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek)
        };

        // Act
        var result = YANDateTime.GetWeekOfYears<int?>("2023-01-01", "2023-01-15", "2023-12-31");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetWeekOfYears_Generic_ReturnsDifferentNumericTypes()
    {
        // Arrange
        var date = new DateTime(2023, 1, 15);
        var input = new List<object> { date };
        var expected = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date, CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);

        // Act
        var resultInt = input.GetWeekOfYears<int>();
        var resultLong = input.GetWeekOfYears<long>();
        var resultDouble = input.GetWeekOfYears<double>();

        // Assert
        Assert.NotNull(resultInt);
        Assert.NotNull(resultLong);
        Assert.NotNull(resultDouble);
        Assert.Equal(expected, resultInt.First());
        Assert.Equal(expected, resultLong.First());
        Assert.Equal(expected, resultDouble.First());
    }
    #endregion

    #region TotalMonth
    [Fact]
    public void TotalMonth_Generic_BothInputsNull_ReturnsDefault()
    {
        // Arrange
        object? input1 = null;
        object? input2 = null;

        // Act
        var result = YANDateTime.TotalMonth<int>(input1, input2);

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void TotalMonth_Generic_FirstInputNull_ReturnsDefault()
    {
        // Arrange
        object? input1 = null;
        object input2 = new DateTime(2023, 6, 15);

        // Act
        var result = YANDateTime.TotalMonth<int>(input1, input2);

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void TotalMonth_Generic_SecondInputNull_ReturnsDefault()
    {
        // Arrange
        object input1 = new DateTime(2023, 6, 15);
        object? input2 = null;

        // Act
        var result = YANDateTime.TotalMonth<int>(input1, input2);

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void TotalMonth_Generic_SameDate_ReturnsZero()
    {
        // Arrange
        var date = new DateTime(2023, 6, 15);
        object input1 = date;
        object input2 = date;

        // Act
        var result = YANDateTime.TotalMonth<int>(input1, input2);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void TotalMonth_Generic_OneMonthDifference_ReturnsOne()
    {
        // Arrange
        object input1 = new DateTime(2023, 6, 15);
        object input2 = new DateTime(2023, 7, 15);

        // Act
        var result = YANDateTime.TotalMonth<int>(input1, input2);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void TotalMonth_Generic_OneYearDifference_ReturnsTwelve()
    {
        // Arrange
        object input1 = new DateTime(2022, 6, 15);
        object input2 = new DateTime(2023, 6, 15);

        // Act
        var result = YANDateTime.TotalMonth<int>(input1, input2);

        // Assert
        Assert.Equal(12, result);
    }

    [Fact]
    public void TotalMonth_Generic_NegativeMonthDifference_ReturnsAbsoluteValue()
    {
        // Arrange
        object input1 = new DateTime(2023, 7, 15);
        object input2 = new DateTime(2023, 6, 15);

        // Act
        var result = YANDateTime.TotalMonth<int>(input1, input2);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void TotalMonth_Generic_PartialMonthDifference_ReturnsTruncatedValue()
    {
        // Arrange
        object input1 = new DateTime(2023, 6, 1);
        object input2 = new DateTime(2023, 7, 15);

        // Act
        var result = YANDateTime.TotalMonth<int>(input1, input2);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void TotalMonth_Generic_StringDates_ParsesAndCalculatesMonths()
    {
        // Arrange
        object input1 = "2022-06-15";
        object input2 = "2023-06-15";

        // Act
        var result = YANDateTime.TotalMonth<int>(input1, input2);

        // Assert
        Assert.Equal(12, result);
    }

    [Fact]
    public void TotalMonth_Generic_InvalidStringDates_ReturnsDefault()
    {
        // Arrange
        object input1 = "not a date";
        object input2 = "2023-06-15";

        // Act
        var result = YANDateTime.TotalMonth<int>(input1, input2);

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void TotalMonth_Generic_ReturnsDifferentNumericTypes()
    {
        // Arrange
        object input1 = new DateTime(2022, 6, 15);
        object input2 = new DateTime(2023, 6, 15);
        var expected = 12;

        // Act
        var resultInt = YANDateTime.TotalMonth<int>(input1, input2);
        var resultLong = YANDateTime.TotalMonth<long>(input1, input2);
        var resultDouble = YANDateTime.TotalMonth<double>(input1, input2);

        // Assert
        Assert.Equal(expected, resultInt);
        Assert.Equal(expected, resultLong);
        Assert.Equal(expected, resultDouble);
    }
    #endregion
}
