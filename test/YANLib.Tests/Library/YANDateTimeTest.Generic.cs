using System.Globalization;

namespace YANLib.Tests.Library;

public partial class YANDateTimeTest
{
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
        // Arrange
        var dt1 = new DateTime(2024, 1, 15);
        var dt2 = new DateTime(2023, 8, 5);

        // Act
        var result = YANDateTime.TotalMonth<int>(dt1, dt2);

        // Assert
        Assert.Equal(5, result);
    }

    [Fact]
    public void TotalMonth_InvalidInput_ReturnsDefault()
    {
        // Arrange
        var dt = new DateTime(2023, 8, 5);

        // Act
        var result = YANDateTime.TotalMonth<int>("invalid", dt);

        // Assert
        Assert.Null(result);
    }
    #endregion
}
