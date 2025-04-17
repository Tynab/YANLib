using System.Globalization;

namespace YANLib.Tests.Library;

public partial class YANDateTimeTest
{
    private static readonly DateTime _dt1 = new(2024, 1, 15);
    private static readonly DateTime _dt2 = new(2023, 8, 5);

    #region GetWeekOfYear
    [Fact]
    public void GetWeekOfYear_ValidDate_ReturnsCorrectWeek()
    {
        // Arrange
        object input = new DateTime(2024, 1, 3);

        // Act
        var result = input.GetWeekOfYear<int>();

        // Assert
        var expected = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear((DateTime)input, CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetWeekOfYears_IEnumerable_ValidDates_ReturnsCorrectWeeks()
    {
        // Arrange
        IEnumerable<object?> input = [new DateTime(2024, 2, 3), new DateTime(2024, 6, 7)];

        // Act
        var result = input.GetWeekOfYears<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public void GetWeekOfYears_Params_ValidDates_ReturnsCorrectWeeks()
    {
        // Arrange
        var input = new object?[] { new DateTime(2024, 1, 3), new DateTime(2024, 5, 5) };

        // Act
        var result = YANDateTime.GetWeekOfYears<int>(input);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }
    #endregion

    #region TotalMonth
    [Fact]
    public void TotalMonth_ValidInputs_ReturnsCorrectDifference()
    {
        // Act
        var result = YANDateTime.TotalMonth<int>(_dt1, _dt2);

        // Assert
        Assert.Equal(5, result);
    }

    [Fact]
    public void TotalMonth_InvalidInput_ReturnsDefault()
    {
        // Act
        var result = YANDateTime.TotalMonth<int>("invalid", _dt2);

        // Assert
        Assert.Null(result);
    }
    #endregion

    #region ChangeTimeZone
    [Fact]
    public void ChangeTimeZone_ValidDiff_AddsHours()
    {
        // Arrange
        object dt = new DateTime(2024, 1, 1, 0, 0, 0);

        // Act
        var changed = dt.ChangeTimeZone(0, 7);

        // Assert
        Assert.Equal(new DateTime(2024, 1, 1, 7, 0, 0), changed);
    }

    [Fact]
    public void ChangeTimeZone_List_ValidData_UpdatesListInPlace()
    {
        // Arrange
        var list = new List<object?> { new DateTime(2024, 2, 2, 12, 0, 0), new DateTime(2024, 2, 2, 14, 0, 0) };

        // Act
        list.ChangeTimeZone(0, 2);

        // Assert
        Assert.Equal(14, ((DateTime)list[0]!).Hour);
        Assert.Equal(16, ((DateTime)list[1]!).Hour);
    }

    [Fact]
    public void ChangeTimeZones_IEnumerable_ValidData_ReturnsConverted()
    {
        // Arrange
        IEnumerable<object?> list = [new DateTime(2024, 1, 1, 3, 0, 0), new DateTime(2024, 1, 1, 10, 0, 0)];

        // Act
        var result = list.ChangeTimeZones(7, 0);

        // Assert
        Assert.NotNull(result);

        var arr = result.ToArray();

        Assert.Equal(2, arr.Length);
        Assert.Equal(20, arr[0].Hour);
        Assert.Equal(3, arr[1].Hour);
    }

    [Fact]
    public void ChangeTimeZones_Params_ValidData_ReturnsConverted()
    {
        // Arrange
        var list = new object?[] { new DateTime(2024, 1, 1, 0, 0, 0), new DateTime(2024, 1, 1, 5, 0, 0) };

        // Act
        var result = YANDateTime.ChangeTimeZones(list, 0, 7);

        // Assert
        Assert.NotNull(result);

        var arr = result.ToArray();

        Assert.Equal(2, arr.Length);
        Assert.Equal(7, arr[0].Hour);
        Assert.Equal(12, arr[1].Hour);
    }
    #endregion
}
