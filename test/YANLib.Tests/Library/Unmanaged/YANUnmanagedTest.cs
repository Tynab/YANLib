using YANLib.Unmanaged;

namespace YANLib.Tests.Library.Unmanaged;

public partial class YANUnmanagedTest
{
    #region Basic Types

    [Fact]
    public void Parse_Unmanaged_NullToInt_ReturnsDefault()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Parse<int>();

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Parse_Unmanaged_NullToIntWithDefault_ReturnsDefault()
    {
        // Arrange
        object? input = null;
        object defaultValue = 42;

        // Act
        var result = input.Parse<int>(defaultValue);

        // Assert
        Assert.Equal(42, result);
    }

    [Fact]
    public void Parse_Unmanaged_StringToInt_ReturnsInt()
    {
        // Arrange
        object input = "123";

        // Act
        var result = input.Parse<int>();

        // Assert
        Assert.Equal(123, result);
    }

    [Fact]
    public void Parse_Unmanaged_InvalidStringToInt_ReturnsDefault()
    {
        // Arrange
        object input = "abc";

        // Act
        var result = input.Parse<int>();

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Parse_Unmanaged_InvalidStringToIntWithDefault_ReturnsDefault()
    {
        // Arrange
        object input = "abc";
        object defaultValue = 42;

        // Act
        var result = input.Parse<int>(defaultValue);

        // Assert
        Assert.Equal(42, result);
    }

    [Fact]
    public void Parse_Unmanaged_DoubleToInt_ReturnsInt()
    {
        // Arrange
        object input = 123.45;

        // Act
        var result = input.Parse<int>();

        // Assert
        Assert.Equal(123, result);
    }

    [Fact]
    public void Parse_Unmanaged_StringToDouble_ReturnsDouble()
    {
        // Arrange
        object input = "123.45";

        // Act
        var result = input.Parse<double>();

        // Assert
        Assert.Equal(123.45, result);
    }

    [Fact]
    public void Parse_Unmanaged_InvalidStringToDouble_ReturnsDefault()
    {
        // Arrange
        object input = "abc";

        // Act
        var result = input.Parse<double>();

        // Assert
        Assert.Equal(0.0, result);
    }

    [Fact]
    public void Parse_Unmanaged_StringToFloat_ReturnsFloat()
    {
        // Arrange
        object input = "123.45";

        // Act
        var result = input.Parse<float>();

        // Assert
        Assert.Equal(123.45f, result);
    }

    [Fact]
    public void Parse_Unmanaged_StringToBool_ReturnsBool()
    {
        // Arrange
        object input = "true";

        // Act
        var result = input.Parse<bool>();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Parse_Unmanaged_InvalidStringToBool_ReturnsDefault()
    {
        // Arrange
        object input = "abc";

        // Act
        var result = input.Parse<bool>();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Parse_Unmanaged_StringToChar_ReturnsChar()
    {
        // Arrange
        object input = "A";

        // Act
        var result = input.Parse<char>();

        // Assert
        Assert.Equal('A', result);
    }

    [Fact]
    public void Parse_Unmanaged_LongStringToChar_ReturnsDefault()
    {
        // Arrange
        object input = "ABC";

        // Act
        var result = input.Parse<char>();

        // Assert
        Assert.Equal(default, result);
    }

    #endregion

    #region DateTime

    [Fact]
    public void Parse_Unmanaged_StringToDateTime_ReturnsDateTime()
    {
        // Arrange
        object input = "2023-01-15";

        // Act
        var result = input.Parse<DateTime>();

        // Assert
        Assert.Equal(new DateTime(2023, 1, 15), result);
    }

    [Fact]
    public void Parse_Unmanaged_InvalidStringToDateTime_ReturnsDefault()
    {
        // Arrange
        object input = "not a date";

        // Act
        var result = input.Parse<DateTime>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Parse_Unmanaged_StringToDateTimeWithFormat_ReturnsDateTime()
    {
        // Arrange
        object input = "15/01/2023";
        string[] format = ["dd/MM/yyyy"];

        // Act
        var result = input.Parse<DateTime>(null, format);

        // Assert
        Assert.Equal(new DateTime(2023, 1, 15), result);
    }

    [Fact]
    public void Parse_Unmanaged_StringToDateTimeWithMultipleFormats_ReturnsDateTime()
    {
        // Arrange
        object input = "15/01/2023";
        string[] format = ["yyyy-MM-dd", "dd/MM/yyyy"];

        // Act
        var result = input.Parse<DateTime>(null, format);

        // Assert
        Assert.Equal(new DateTime(2023, 1, 15), result);
    }

    [Fact]
    public void Parse_Unmanaged_InvalidStringToDateTimeWithDefault_ReturnsDefault()
    {
        // Arrange
        object input = "not a date";
        object defaultValue = new DateTime(2000, 1, 1);

        // Act
        var result = input.Parse<DateTime>(defaultValue);

        // Assert
        Assert.Equal(new DateTime(2000, 1, 1), result);
    }

    #endregion

    #region Enum

    private enum TestEnum
    {
        None = 0,
        First = 1,
        Second = 2
    }

    [Fact]
    public void Parse_Unmanaged_StringToEnum_ReturnsEnum()
    {
        // Arrange
        object input = "First";

        // Act
        var result = input.Parse<TestEnum>();

        // Assert
        Assert.Equal(TestEnum.First, result);
    }

    [Fact]
    public void Parse_Unmanaged_StringToEnumIgnoreCase_ReturnsEnum()
    {
        // Arrange
        object input = "first";

        // Act
        var result = input.Parse<TestEnum>();

        // Assert
        Assert.Equal(TestEnum.First, result);
    }

    [Fact]
    public void Parse_Unmanaged_NumberToEnum_ReturnsEnum()
    {
        // Arrange
        object input = 2;

        // Act
        var result = input.Parse<TestEnum>();

        // Assert
        Assert.Equal(TestEnum.Second, result);
    }

    [Fact]
    public void Parse_Unmanaged_InvalidStringToEnum_ReturnsDefault()
    {
        // Arrange
        object input = "NotAnEnum";

        // Act
        var result = input.Parse<TestEnum>();

        // Assert
        Assert.Equal(TestEnum.None, result);
    }

    [Fact]
    public void Parse_Unmanaged_InvalidStringToEnumWithDefault_ReturnsDefault()
    {
        // Arrange
        object input = "NotAnEnum";
        object defaultValue = TestEnum.Second;

        // Act
        var result = input.Parse<TestEnum>(defaultValue);

        // Assert
        Assert.Equal(TestEnum.Second, result);
    }

    #endregion

    #region Collection

    [Fact]
    public void Parses_Unmanaged_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Parses<int>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Parses_Unmanaged_EmptyCollection_ReturnsNull()
    {
        // Arrange
        var input = Array.Empty<object?>();

        // Act
        var result = input.Parses<int>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Parses_Unmanaged_StringsToInts_ReturnsInts()
    {
        // Arrange
        var input = new object?[] { "123", "456", "789" };
        var expected = new[] { 123, 456, 789 };

        // Act
        var result = input.Parses<int>();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Parses_Unmanaged_MixedToInts_ReturnsInts()
    {
        // Arrange
        var input = new object?[] { "123", 456, "789" };
        var expected = new[] { 123, 456, 789 };

        // Act
        var result = input.Parses<int>();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Parses_Unmanaged_MixedWithInvalidToInts_ReturnsIntsWithDefaults()
    {
        // Arrange
        var input = new object?[] { "123", "abc", "789" };
        var expected = new[] { 123, 0, 789 };

        // Act
        var result = input.Parses<int>();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Parses_Unmanaged_MixedWithInvalidToIntsWithDefault_ReturnsIntsWithDefaults()
    {
        // Arrange
        var input = new object?[] { "123", "abc", "789" };
        object defaultValue = 42;

        // Act
        var result = input.Parses<int>(defaultValue);

        // Assert
        Assert.Equal([123, 42, 789], result);
    }

    [Fact]
    public void Parses_Unmanaged_MixedWithNullToInts_ReturnsIntsWithDefaults()
    {
        // Arrange
        var input = new object?[] { "123", null, "789" };
        var expected = new[] { 123, 0, 789 };

        // Act
        var result = input.Parses<int>();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Parses_Unmanaged_MixedWithNullToIntsWithDefault_ReturnsIntsWithDefaults()
    {
        // Arrange
        var input = new object?[] { "123", null, "789" };
        object defaultValue = 42;

        // Act
        var result = input.Parses<int>(defaultValue);

        // Assert
        Assert.Equal([123, 42, 789], result);
    }

    [Fact]
    public void Parses_Unmanaged_StringsToDoubles_ReturnsDoubles()
    {
        // Arrange
        var input = new object?[] { "123.45", "456.78", "789.01" };
        var expected = new[] { 123.45, 456.78, 789.01 };

        // Act
        var result = input.Parses<double>();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Parses_Unmanaged_StringsToDateTimes_ReturnsDateTimes()
    {
        // Arrange
        var input = new object?[] { "2023-01-15", "2023-02-20", "2023-03-25" };

        // Act
        var result = input.Parses<DateTime>();

        // Assert
        Assert.Equal(new[]
        {
            new DateTime(2023, 1, 15),
            new DateTime(2023, 2, 20),
            new DateTime(2023, 3, 25)
        }, result);
    }

    [Fact]
    public void Parses_Unmanaged_StringsToDateTimesWithFormat_ReturnsDateTimes()
    {
        // Arrange
        var input = new object?[] { "15/01/2023", "20/02/2023", "25/03/2023" };
        string[] format = ["dd/MM/yyyy"];

        // Act
        var result = input.Parses<DateTime>(null, format);

        // Assert
        Assert.Equal([new DateTime(2023, 1, 15), new DateTime(2023, 2, 20), new DateTime(2023, 3, 25)], result);
    }

    [Fact]
    public void Parses_Unmanaged_StringsToEnums_ReturnsEnums()
    {
        // Arrange
        var input = new object?[] { "None", "First", "Second" };

        // Act
        var result = input.Parses<TestEnum>();

        // Assert
        Assert.Equal(new[]
        {
            TestEnum.None,
            TestEnum.First,
            TestEnum.Second
        }, result);
    }

    [Fact]
    public void Parses_Unmanaged_MixedToEnums_ReturnsEnums()
    {
        // Arrange
        var input = new object?[] { "None", 1, "Second" };

        // Act
        var result = input.Parses<TestEnum>();

        // Assert
        Assert.Equal(new[]
        {
            TestEnum.None,
            TestEnum.First,
            TestEnum.Second
        }, result);
    }

    [Fact]
    public void Parses_Unmanaged_MixedWithInvalidToEnums_ReturnsEnumsWithDefaults()
    {
        // Arrange
        var input = new object?[] { "None", "NotAnEnum", "Second" };

        // Act
        var result = input.Parses<TestEnum>();

        // Assert
        Assert.Equal(new[]
        {
            TestEnum.None,
            TestEnum.None,
            TestEnum.Second
        }, result);
    }

    [Fact]
    public void Parses_Unmanaged_MixedWithInvalidToEnumsWithDefault_ReturnsEnumsWithDefaults()
    {
        // Arrange
        var input = new object?[] { "None", "NotAnEnum", "Second" };
        object defaultValue = TestEnum.First;

        // Act
        var result = input.Parses<TestEnum>(defaultValue);

        // Assert
        Assert.Equal([TestEnum.None, TestEnum.First, TestEnum.Second], result);
    }

    #endregion

    #region Params

    [Fact]
    public void Parse_Unmanaged_StringToDateTimeWithParamsFormat_ReturnsDateTime()
    {
        // Arrange
        object input = "15/01/2023";

        // Act
        var result = input.Parse<DateTime>(null, "dd/MM/yyyy");

        // Assert
        Assert.Equal(new DateTime(2023, 1, 15), result);
    }

    [Fact]
    public void Parse_Unmanaged_StringToDateTimeWithMultipleParamsFormats_ReturnsDateTime()
    {
        // Arrange
        object input = "15/01/2023";

        // Act
        var result = input.Parse<DateTime>(null, "yyyy-MM-dd", "dd/MM/yyyy");

        // Assert
        Assert.Equal(new DateTime(2023, 1, 15), result);
    }

    [Fact]
    public void Parses_Unmanaged_StringsToDateTimesWithParamsFormat_ReturnsDateTimes()
    {
        // Arrange
        var input = new object?[] { "15/01/2023", "20/02/2023", "25/03/2023" };

        // Act
        var result = input.Parses<DateTime>(null, "dd/MM/yyyy");

        // Assert
        Assert.Equal([new DateTime(2023, 1, 15), new DateTime(2023, 2, 20), new DateTime(2023, 3, 25)], result);
    }

    [Fact]
    public void Parses_Unmanaged_StringsToDateTimesWithMultipleParamsFormats_ReturnsDateTimes()
    {
        // Arrange
        var input = new object?[] { "15/01/2023", "2023-02-20", "25/03/2023" };

        // Act
        var result = input.Parses<DateTime>(null, "yyyy-MM-dd", "dd/MM/yyyy");

        // Assert
        Assert.Equal([new DateTime(2023, 1, 15), new DateTime(2023, 2, 20), new DateTime(2023, 3, 25)], result);
    }

    #endregion

    #region Edge Cases

    [Fact]
    public void Parse_Unmanaged_MaxValueToInt_ReturnsMaxValue()
    {
        // Arrange
        object input = int.MaxValue;

        // Act
        var result = input.Parse<int>();

        // Assert
        Assert.Equal(int.MaxValue, result);
    }

    [Fact]
    public void Parse_Unmanaged_MinValueToInt_ReturnsMinValue()
    {
        // Arrange
        object input = int.MinValue;

        // Act
        var result = input.Parse<int>();

        // Assert
        Assert.Equal(int.MinValue, result);
    }

    [Fact]
    public void Parse_Unmanaged_OverflowToInt_ReturnsDefault()
    {
        // Arrange
        object input = long.MaxValue;

        // Act
        var result = input.Parse<int>();

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Parse_Unmanaged_OverflowToIntWithDefault_ReturnsDefault()
    {
        // Arrange
        object input = long.MaxValue;
        object defaultValue = 42;

        // Act
        var result = input.Parse<int>(defaultValue);

        // Assert
        Assert.Equal(42, result);
    }

    [Fact]
    public void Parse_Unmanaged_EmptyStringToInt_ReturnsDefault()
    {
        // Arrange
        object input = "";

        // Act
        var result = input.Parse<int>();

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Parse_Unmanaged_WhitespaceToInt_ReturnsDefault()
    {
        // Arrange
        object input = "   ";

        // Act
        var result = input.Parse<int>();

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Parse_Unmanaged_DefaultValueAsWrongType_ReturnsTypeDefault()
    {
        // Arrange
        object input = "abc";
        object defaultValue = "not a number";

        // Act
        var result = input.Parse<int>(defaultValue);

        // Assert
        Assert.Equal(0, result);
    }

    #endregion
}
