namespace YANLib.Tests.Library;

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
    public void GetWeekOfYear_FirstDayOfYear_ReturnsWeekOne()
    {
        // Arrange
        var input = new DateTime(2023, 1, 1);

        // Act
        var result = input.GetWeekOfYear();

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void GetWeekOfYear_MiddleOfYear_ReturnsCorrectWeek()
    {
        // Arrange
        var input = new DateTime(2023, 6, 15);

        // Act
        var result = input.GetWeekOfYear();

        // Assert
        Assert.Equal(24, result);
    }

    [Fact]
    public void GetWeekOfYear_LastDayOfYear_ReturnsLastWeek()
    {
        // Arrange
        var input = new DateTime(2023, 12, 31);

        // Act
        var result = input.GetWeekOfYear();

        // Assert
        Assert.Equal(53, result);
    }

    [Fact]
    public void GetWeekOfYear_LeapYear_CalculatesCorrectly()
    {
        // Arrange
        var input = new DateTime(2024, 2, 29);

        // Act
        var result = input.GetWeekOfYear();

        // Assert
        Assert.Equal(9, result);
    }

    [Fact]
    public void GetWeekOfYear_CustomDateObject_ReturnsCorrectWeek()
    {
        // Arrange
        var container = new TestDateContainer { Date = new DateTime(2023, 6, 15) };

        // Act
        var result = container.Date.GetWeekOfYear();

        // Assert
        Assert.Equal(24, result);
    }

    #endregion

    #region TotalMonth

    [Fact]
    public void TotalMonth_BothNull_ReturnsZero()
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
    public void TotalMonth_OneNull_ReturnsZero()
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
        var input1 = new DateTime(2023, 6, 15);
        var input2 = new DateTime(2023, 6, 15);

        // Act
        var result = YANDateTime.TotalMonth(input1, input2);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void TotalMonth_OneYearDifference_Returns12()
    {
        // Arrange
        var input1 = new DateTime(2023, 6, 15);
        var input2 = new DateTime(2022, 6, 15);

        // Act
        var result = YANDateTime.TotalMonth(input1, input2);

        // Assert
        Assert.Equal(12, result);
    }

    [Fact]
    public void TotalMonth_SixMonthDifference_Returns6()
    {
        // Arrange
        var input1 = new DateTime(2023, 6, 15);
        var input2 = new DateTime(2023, 12, 15);

        // Act
        var result = YANDateTime.TotalMonth(input1, input2);

        // Assert
        Assert.Equal(6, result);
    }

    [Fact]
    public void TotalMonth_NegativeDifference_ReturnsAbsoluteValue()
    {
        // Arrange
        var input1 = new DateTime(2022, 1, 15);
        var input2 = new DateTime(2023, 7, 15);

        // Act
        var result = YANDateTime.TotalMonth(input1, input2);

        // Assert
        Assert.Equal(18, result);
    }

    [Fact]
    public void TotalMonth_ComplexDifference_CalculatesCorrectly()
    {
        // Arrange
        var input1 = new DateTime(2023, 8, 15);
        var input2 = new DateTime(2021, 3, 10);

        // Act
        var result = YANDateTime.TotalMonth(input1, input2);

        // Assert
        Assert.Equal(29, result);
    }

    [Fact]
    public void TotalMonth_DifferentDaysSameMonthYear_ReturnsZero()
    {
        // Arrange
        var input1 = new DateTime(2023, 6, 5);
        var input2 = new DateTime(2023, 6, 25);

        // Act
        var result = YANDateTime.TotalMonth(input1, input2);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void TotalMonth_CustomDateObjects_CalculatesCorrectly()
    {
        // Arrange
        var container1 = new TestDateContainer { Date = new DateTime(2023, 6, 15) };
        var container2 = new TestDateContainer { Date = new DateTime(2022, 6, 15) };

        // Act
        var result = YANDateTime.TotalMonth(container1.Date, container2.Date);

        // Assert
        Assert.Equal(12, result);
    }

    #endregion

    #region ChangeTimeZone

    [Fact]
    public void ChangeTimeZone_PositiveOffset_AddsHours()
    {
        // Arrange
        var input = new DateTime(2023, 6, 15, 10, 0, 0);
        var expected = new DateTime(2023, 6, 15, 13, 0, 0);

        // Act
        var result = input.ChangeTimeZone(0, 3);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ChangeTimeZone_NegativeOffset_SubtractsHours()
    {
        // Arrange
        var input = new DateTime(2023, 6, 15, 10, 0, 0);
        var expected = new DateTime(2023, 6, 15, 7, 0, 0);

        // Act
        var result = input.ChangeTimeZone(0, -3);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ChangeTimeZone_SameTimeZones_ReturnsSameDateTime()
    {
        // Arrange
        var input = new DateTime(2023, 6, 15, 10, 0, 0);

        // Act
        var result = input.ChangeTimeZone(2, 2);

        // Assert
        Assert.Equal(input, result);
    }

    [Fact]
    public void ChangeTimeZone_NullTimeZones_UsesDefaultValues()
    {
        // Arrange
        var input = new DateTime(2023, 6, 15, 10, 0, 0);

        // Act
        var result = input.ChangeTimeZone();

        // Assert
        Assert.Equal(input, result);
    }

    [Fact]
    public void ChangeTimeZone_NearMinValue_HandlesEdgeCase()
    {
        // Arrange
        var input = DateTime.MinValue.AddHours(2);

        // Act
        var result = input.ChangeTimeZone(0, -3);

        // Assert
        Assert.Equal(input, result);
    }

    [Fact]
    public void ChangeTimeZone_NearMaxValue_HandlesEdgeCase()
    {
        // Arrange
        var input = DateTime.MaxValue.AddHours(-2);

        // Act
        var result = input.ChangeTimeZone(0, 3);

        // Assert
        Assert.Equal(input, result);
    }

    [Fact]
    public void ChangeTimeZone_StringTimeZones_ConvertsAndApplies()
    {
        // Arrange
        var input = new DateTime(2023, 6, 15, 10, 0, 0);
        var expected = new DateTime(2023, 6, 15, 13, 0, 0);

        // Act
        var result = input.ChangeTimeZone("0", "3");

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ChangeTimeZone_DecimalTimeZones_ConvertsAndApplies()
    {
        // Arrange
        var input = new DateTime(2023, 6, 15, 10, 0, 0);
        var expected = new DateTime(2023, 6, 15, 13, 30, 0);

        // Act
        var result = input.ChangeTimeZone(0, 3.5m);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ChangeTimeZone_InvalidTimeZones_UsesDefaultValues()
    {
        // Arrange
        var input = new DateTime(2023, 6, 15, 10, 0, 0);

        // Act
        var result = input.ChangeTimeZone("invalid", "timezone");

        // Assert
        Assert.Equal(input, result);
    }

    [Fact]
    public void ChangeTimeZone_CustomObjectTimeZones_ConvertsAndApplies()
    {
        // Arrange
        var input = new DateTime(2023, 6, 15, 10, 0, 0);
        var expected = new DateTime(2023, 6, 15, 12, 0, 0);
        var tzSrc = 0;
        var tzDst = 2;

        // Act
        var result = input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal(expected, result);
    }

    #endregion

    private class TestDateContainer
    {
        public DateTime Date { get; set; }

        public override string ToString() => Date.ToString();
    }
}
