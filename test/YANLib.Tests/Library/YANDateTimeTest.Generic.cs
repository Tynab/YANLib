namespace YANLib.Tests.Library;

public partial class YANDateTimeTest
{
    #region GetWeekOfYear

    [Fact]
    public void GetWeekOfYear_NullInput_ReturnsNull_Generic()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.GetWeekOfYear<int?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetWeekOfYear_DateTimeObject_ReturnsCorrectWeek_Generic()
    {
        // Arrange
        object input = new DateTime(2023, 6, 15);

        // Act
        var result = input.GetWeekOfYear<int>();

        // Assert
        Assert.Equal(24, result);
    }

    [Fact]
    public void GetWeekOfYear_StringDate_ConvertsAndReturnsWeek_Generic()
    {
        // Arrange
        object input = "2023-01-01";

        // Act
        var result = input.GetWeekOfYear<int>();

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void GetWeekOfYear_InvalidObject_ReturnsDefault_Generic()
    {
        // Arrange
        object input = "not a date";

        // Act
        var result = input.GetWeekOfYear<int?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetWeekOfYear_ReturnTypeString_ConvertsToString_Generic()
    {
        // Arrange
        object input = new DateTime(2023, 12, 31);

        // Act
        var result = input.GetWeekOfYear<string>();

        // Assert
        Assert.Equal("53", result);
    }

    [Fact]
    public void GetWeekOfYear_ReturnTypeDouble_ConvertsToDouble_Generic()
    {
        // Arrange
        object input = new DateTime(2023, 6, 15);

        // Act
        var result = input.GetWeekOfYear<double>();

        // Assert
        Assert.Equal(24.0, result);
    }

    #endregion

    #region TotalMonth

    [Fact]
    public void TotalMonth_BothNull_ReturnsNull_Generic()
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
    public void TotalMonth_OneNull_ReturnsNull_Generic()
    {
        // Arrange
        object? input1 = new DateTime(2023, 6, 15);
        object? input2 = null;

        // Act
        var result = YANDateTime.TotalMonth<int?>(input1, input2);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void TotalMonth_DateTimeObjects_ReturnsCorrectDifference_Generic()
    {
        // Arrange
        object input1 = new DateTime(2023, 6, 15);
        object input2 = new DateTime(2022, 6, 15);

        // Act
        var result = YANDateTime.TotalMonth<int>(input1, input2);

        // Assert
        Assert.Equal(12, result);
    }

    [Fact]
    public void TotalMonth_StringDates_ConvertsAndCalculates_Generic()
    {
        // Arrange
        object input1 = "2023-06-15";
        object input2 = "2022-06-15";

        // Act
        var result = YANDateTime.TotalMonth<int>(input1, input2);

        // Assert
        Assert.Equal(12, result);
    }

    [Fact]
    public void TotalMonth_MixedTypes_HandlesConversion_Generic()
    {
        // Arrange
        object input1 = new DateTime(2023, 6, 15);
        object input2 = "2022-06-15";

        // Act
        var result = YANDateTime.TotalMonth<int>(input1, input2);

        // Assert
        Assert.Equal(12, result);
    }

    [Fact]
    public void TotalMonth_InvalidObjects_ReturnsNull_Generic()
    {
        // Arrange
        object input1 = "not a date";
        object input2 = new DateTime(2022, 6, 15);

        // Act
        var result = YANDateTime.TotalMonth<int?>(input1, input2);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void TotalMonth_ReturnTypeString_ConvertsToString_Generic()
    {
        // Arrange
        object input1 = new DateTime(2023, 6, 15);
        object input2 = new DateTime(2022, 6, 15);

        // Act
        var result = YANDateTime.TotalMonth<string>(input1, input2);

        // Assert
        Assert.Equal("12", result);
    }

    [Fact]
    public void TotalMonth_ReturnTypeDouble_ConvertsToDouble_Generic()
    {
        // Arrange
        object input1 = new DateTime(2023, 8, 15);
        object input2 = new DateTime(2021, 2, 15);

        // Act
        var result = YANDateTime.TotalMonth<double>(input1, input2);

        // Assert
        Assert.Equal(30.0, result);
    }

    [Fact]
    public void TotalMonth_NegativeDifference_ReturnsAbsoluteValue_Generic()
    {
        // Arrange
        object input1 = new DateTime(2022, 1, 15);
        object input2 = new DateTime(2023, 7, 15);

        // Act
        var result = YANDateTime.TotalMonth<int>(input1, input2);

        // Assert
        Assert.Equal(18, result);
    }

    #endregion
}
