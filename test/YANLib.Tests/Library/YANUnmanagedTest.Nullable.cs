namespace YANLib.Tests.Library;

public partial class YANUnmanagedTest
{
    #region Parse

    [Fact]
    public void Parse_NullInput_ReturnsNull_Nullable()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Parse<int?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Parse_ValidIntInput_ReturnsIntValue_Nullable()
    {
        // Arrange
        object input = "123";

        // Act
        var result = input.Parse<int?>();

        // Assert
        _ = Assert.NotNull(result);
        Assert.Equal(123, result);
    }

    [Fact]
    public void Parse_InvalidInput_ReturnsNull_Nullable()
    {
        // Arrange
        object input = "not a number";

        // Act
        var result = input.Parse<int?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Parse_ValidDateTimeInput_ReturnsDateTime_Nullable()
    {
        // Arrange
        object input = "2023-06-15";
        var expected = new DateTime(2023, 6, 15);

        // Act
        var result = input.Parse<DateTime?>();

        // Assert
        _ = Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Parse_InvalidDateTimeInput_ReturnsNull_Nullable()
    {
        // Arrange
        object input = "not a date";

        // Act
        var result = input.Parse<DateTime?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Parse_EnumInput_ReturnsEnumValue_Nullable()
    {
        // Arrange
        object input = "Tuesday";

        // Act
        var result = input.Parse<DayOfWeek?>();

        // Assert
        _ = Assert.NotNull(result);
        Assert.Equal(DayOfWeek.Tuesday, result);
    }

    [Fact]
    public void Parse_EnumInputCaseInsensitive_ReturnsEnumValue_Nullable()
    {
        // Arrange
        object input = "tuesday";

        // Act
        var result = input.Parse<DayOfWeek?>();

        // Assert
        _ = Assert.NotNull(result);
        Assert.Equal(DayOfWeek.Tuesday, result);
    }

    [Fact]
    public void Parse_InvalidEnumInput_ReturnsNull_Nullable()
    {
        // Arrange
        object input = "NotADay";

        // Act
        var result = input.Parse<DayOfWeek?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Parse_BoolInput_ReturnsBoolValue_Nullable()
    {
        // Arrange
        object input = "true";

        // Act
        var result = input.Parse<bool?>();

        // Assert
        _ = Assert.NotNull(result);
        Assert.True(result);
    }

    [Fact]
    public void Parse_CharInput_ReturnsCharValue_Nullable()
    {
        // Arrange
        object input = "A";

        // Act
        var result = input.Parse<char?>();

        // Assert
        _ = Assert.NotNull(result);
        Assert.Equal('A', result);
    }

    [Fact]
    public void Parse_GuidInput_ReturnsGuidValue_Nullable()
    {
        // Arrange
        var guid = Guid.NewGuid();
        object input = guid.ToString();

        // Act
        var result = input.Parse<Guid?>();

        // Assert
        _ = Assert.NotNull(result);
        Assert.Equal(guid, result);
    }

    [Fact]
    public void Parse_InvalidGuidInput_ReturnsNull_Nullable()
    {
        // Arrange
        object input = "not a guid";

        // Act
        var result = input.Parse<Guid?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Parse_EmptyString_ReturnsNull_Nullable()
    {
        // Arrange
        object input = "";

        // Act
        var result = input.Parse<int?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Parse_WhitespaceString_ReturnsNull_Nullable()
    {
        // Arrange
        object input = "   ";

        // Act
        var result = input.Parse<int?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Parse_ValidDoubleInput_ReturnsDoubleValue_Nullable()
    {
        // Arrange
        object input = "123.45";

        // Act
        var result = input.Parse<double?>();

        // Assert
        _ = Assert.NotNull(result);
        Assert.Equal(123.45, result);
    }

    [Fact]
    public void Parse_DateTimeWithFormat_UsesFormat_Nullable()
    {
        // Arrange
        object input = "2023/06/15";
        var expected = new DateTime(2023, 6, 15);

        // Act
        var result = input.Parse<DateTime?>();

        // Assert
        _ = Assert.NotNull(result);
        Assert.Equal(expected.Date, result.Value.Date);
    }

    [Fact]
    public void Parse_InvalidDateTimeFormat_ReturnsNull_Nullable()
    {
        // Arrange
        object input = "2023/13/45";

        // Act
        var result = input.Parse<DateTime?>();

        // Assert
        Assert.Null(result);
    }

    #endregion
}
