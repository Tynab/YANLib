namespace YANLib.Tests.Library;

public partial class YANUnmanagedTest
{
    #region Parse

    [Fact]
    public void Parse_NullInput_ReturnsDefaultValue()
    {
        // Arrange
        object? input = null;
        var defaultValue = 42;

        // Act
        var result = input.Parse<int>(defaultValue);

        // Assert
        Assert.Equal(defaultValue, result);
    }

    [Fact]
    public void Parse_ValidIntInput_ReturnsIntValue()
    {
        // Arrange
        object input = "123";

        // Act
        var result = input.Parse<int>();

        // Assert
        Assert.Equal(123, result);
    }

    [Fact]
    public void Parse_ValidDoubleInput_ReturnsDoubleValue()
    {
        // Arrange
        object input = "123.45";

        // Act
        var result = input.Parse<double>();

        // Assert
        Assert.Equal(123.45, result);
    }

    [Fact]
    public void Parse_InvalidInput_ReturnsDefaultValue()
    {
        // Arrange
        object input = "not a number";
        var defaultValue = 42;

        // Act
        var result = input.Parse<int>(defaultValue);

        // Assert
        Assert.Equal(defaultValue, result);
    }

    [Fact]
    public void Parse_ValidDateTimeInput_ReturnsDateTime()
    {
        // Arrange
        object input = "2023-06-15";
        var expected = new DateTime(2023, 6, 15);

        // Act
        var result = input.Parse<DateTime>();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Parse_DateTimeWithFormat_UsesFormat()
    {
        // Arrange
        object input = "15/06/2023";
        var expected = new DateTime(2023, 6, 15);
        string[] format = ["dd/MM/yyyy"];

        // Act
        var result = input.Parse<DateTime>(null, format);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Parse_EnumInput_ReturnsEnumValue()
    {
        // Arrange
        object input = "Tuesday";

        // Act
        var result = input.Parse<DayOfWeek>();

        // Assert
        Assert.Equal(DayOfWeek.Tuesday, result);
    }

    [Fact]
    public void Parse_EnumInputCaseInsensitive_ReturnsEnumValue()
    {
        // Arrange
        object input = "tuesday";

        // Act
        var result = input.Parse<DayOfWeek>();

        // Assert
        Assert.Equal(DayOfWeek.Tuesday, result);
    }

    [Fact]
    public void Parse_InvalidEnumInput_ReturnsDefaultValue()
    {
        // Arrange
        object input = "NotADay";
        var defaultValue = DayOfWeek.Friday;

        // Act
        var result = input.Parse<DayOfWeek>(defaultValue);

        // Assert
        Assert.Equal(defaultValue, result);
    }

    [Fact]
    public void Parse_BoolInput_ReturnsBoolValue()
    {
        // Arrange
        object input = "true";

        // Act
        var result = input.Parse<bool>();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Parse_CharInput_ReturnsCharValue()
    {
        // Arrange
        object input = "A";

        // Act
        var result = input.Parse<char>();

        // Assert
        Assert.Equal('A', result);
    }

    [Fact]
    public void Parse_GuidInput_ReturnsGuidValue()
    {
        // Arrange
        var guid = Guid.NewGuid();
        object input = guid.ToString();

        // Act
        var result = input.Parse<Guid>();

        // Assert
        Assert.Equal(guid, result);
    }

    [Fact]
    public void Parse_ParamsFormatOverload_UsesFormat()
    {
        // Arrange
        object input = "15/06/2023";
        var expected = new DateTime(2023, 6, 15);

        // Act
        var result = input.Parse<DateTime>(null, "dd/MM/yyyy");

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Parse_InvalidGuidInput_ReturnsDefaultValue()
    {
        // Arrange
        object input = "not a guid";
        var defaultValue = Guid.NewGuid();

        // Act
        var result = input.Parse<Guid>(defaultValue);

        // Assert
        Assert.Equal(defaultValue, result);
    }

    [Fact]
    public void Parse_EmptyString_ReturnsDefaultValue()
    {
        // Arrange
        object input = "";
        var defaultValue = 42;

        // Act
        var result = input.Parse<int>(defaultValue);

        // Assert
        Assert.Equal(defaultValue, result);
    }

    [Fact]
    public void Parse_WhitespaceString_ReturnsDefaultValue()
    {
        // Arrange
        object input = "   ";
        var defaultValue = 42;

        // Act
        var result = input.Parse<int>(defaultValue);

        // Assert
        Assert.Equal(defaultValue, result);
    }

    #endregion
}
