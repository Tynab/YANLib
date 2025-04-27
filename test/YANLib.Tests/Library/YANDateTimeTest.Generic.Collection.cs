namespace YANLib.Tests.Library;

public partial class YANDateTimeTest
{
    #region GetWeekOfYears

    [Fact]
    public void GetWeekOfYears_NullEnumerable_ReturnsNull_GenericCollection()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.GetWeekOfYears<int>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetWeekOfYears_EmptyEnumerable_ReturnsNull_GenericCollection()
    {
        // Arrange
        var input = Array.Empty<object?>();

        // Act
        var result = input.GetWeekOfYears<int>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetWeekOfYears_DateTimeObjects_ReturnsCorrectWeeks_GenericCollection()
    {
        // Arrange
        var input = new object?[]
        {
            new DateTime(2023, 1, 1),
            new DateTime(2023, 6, 15),
            new DateTime(2023, 12, 31)
        };

        // Act
        var result = input.GetWeekOfYears<int>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Length);
        Assert.Equal(1, result[0]);
        Assert.Equal(24, result[1]);
        Assert.Equal(53, result[2]);
    }

    [Fact]
    public void GetWeekOfYears_StringDates_ConvertsAndReturnsWeeks_GenericCollection()
    {
        // Arrange
        var input = new object?[]
        {
            "2023-01-01",
            "2023-06-15",
            "2023-12-31"
        };

        // Act
        var result = input.GetWeekOfYears<int>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Length);
        Assert.Equal(1, result[0]);
        Assert.Equal(24, result[1]);
        Assert.Equal(53, result[2]);
    }

    [Fact]
    public void GetWeekOfYears_MixedTypes_HandlesConversion_GenericCollection()
    {
        // Arrange
        var input = new object?[]
        {
            new DateTime(2023, 1, 1),
            "2023-06-15",
            1672444800000
        };

        // Act
        var result = input.GetWeekOfYears<int>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Length);
        Assert.Equal(1, result[0]);
        Assert.Equal(24, result[1]);
    }

    [Fact]
    public void GetWeekOfYears_WithNulls_HandlesNullValues_GenericCollection()
    {
        // Arrange
        var input = new object?[]
        {
            new DateTime(2023, 1, 1),
            null,
            new DateTime(2023, 12, 31)
        };

        // Act
        var result = input.GetWeekOfYears<int?>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Length);
        Assert.Equal(1, result[0]);
        Assert.Null(result[1]);
        Assert.Equal(53, result[2]);
    }

    [Fact]
    public void GetWeekOfYears_InvalidObjects_HandlesGracefully_GenericCollection()
    {
        // Arrange
        var input = new object?[]
        {
            new DateTime(2023, 1, 1),
            "not a date",
            new()
        };

        // Act
        var result = input.GetWeekOfYears<int?>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Length);
        Assert.Equal(1, result[0]);
        Assert.Null(result[1]);
        Assert.Null(result[2]);
    }

    [Fact]
    public void GetWeekOfYears_ParamsOverload_ReturnsCorrectWeeks_GenericCollection()
    {
        // Act
        var result = YANDateTime.GetWeekOfYears<int>(new DateTime(2023, 1, 1), new DateTime(2023, 6, 15), new DateTime(2023, 12, 31))?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Length);
        Assert.Equal(1, result[0]);
        Assert.Equal(24, result[1]);
        Assert.Equal(53, result[2]);
    }

    [Fact]
    public void GetWeekOfYears_ReturnTypeString_ConvertsToString_GenericCollection()
    {
        // Arrange
        var input = new object?[]
        {
            new DateTime(2023, 1, 1),
            new DateTime(2023, 6, 15)
        };

        // Act
        var result = input.GetWeekOfYears<string>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Length);
        Assert.Equal("1", result[0]);
        Assert.Equal("24", result[1]);
    }

    #endregion
}
