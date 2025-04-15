using YANLib.Unmanaged;

namespace YANLib.Tests.Library.Unmanaged;

public partial class YANUnmanagedTest
{
    #region bool
    [Theory]
    [InlineData("true", true)]
    [InlineData("false", false)]
    public void Parse_Bool_ValidString_ReturnsExpectedValue(string input, bool? expected)
    {
        // Arrange
        object? val = input;

        // Act
        var actual = val.Parse<bool>();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_Bool_InvalidString_ReturnsDefault()
    {
        // Arrange
        object? input = "invalid";
        var expected = default(bool);

        // Act
        var actual = input.Parse<bool>();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_Bool_InvalidString_WithDefaultValue_ReturnsDefaultValue()
    {
        // Arrange
        object? input = "invalid";
        object? defaultValue = true;
        var expected = true;

        // Act
        var actual = input.Parse<bool>(defaultValue);

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion

    #region Numeric types
    [Theory]
    [InlineData("0", 0)]
    [InlineData("1.2", 0)]
    [InlineData("3", 3)]
    [InlineData("-4", -4)]
    public void Parse_Int_ValidString_ReturnsExpectedValue(string input, int expected)
    {
        // Arrange
        object? val = input;

        // Act
        var actual = val.Parse<int>();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_Int_InvalidString_ReturnsDefault()
    {
        // Arrange
        object? input = "invalid";
        var expected = default(int);

        // Act
        var actual = input.Parse<int>();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_Int_InvalidString_WithDefaultValue_ReturnsDefaultValue()
    {
        // Arrange
        object? input = "invalid";
        object? defaultValue = 999;
        var expected = 999;

        // Act
        var actual = input.Parse<int>(defaultValue);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("0", 0.0)]
    [InlineData("1", 1.0)]
    [InlineData("2.34", 2.34)]
    [InlineData("-5.67", -5.67)]
    public void Parse_Double_ValidString_ReturnsExpectedValue(string input, double expected)
    {
        // Arrange
        object? val = input;

        // Act
        var actual = val.Parse<double>();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_Double_InvalidString_ReturnsDefault()
    {
        // Arrange
        object? input = "invalid";
        var expected = default(double);

        // Act
        var actual = input.Parse<double>();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_Double_InvalidString_WithDefaultValue_ReturnsDefaultValue()
    {
        // Arrange
        object? input = "invalid";
        object? defaultValue = 9.99;
        var expected = 9.99;

        // Act
        var actual = input.Parse<double>(defaultValue);

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion

    #region string
    [Fact]
    public void Parse_String_ValidString_ReturnsExpectedValue()
    {
        // Arrange
        object? input = 1;
        var expected = "1";

        // Act
        var actual = input.Parse<string>();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_String_InvalidString_ReturnsDefault()
    {
        // Arrange
        object? input = null;
        string expected = default!;

        // Act
        var actual = input.Parse<string>();

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion

    #region DateTime
    [Fact]
    public void Parse_DateTime_ValidString_ReturnsExpectedValue()
    {
        // Arrange
        object? input = "2023-01-01 13:45:59";
        var expected = new DateTime(2023, 1, 1, 13, 45, 59);

        // Act
        var actual = input.Parse<DateTime>();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_DateTime_InvalidString_ReturnsDefault()
    {
        // Arrange
        object? input = "invalid";
        var expected = default(DateTime);

        // Act
        var actual = input.Parse<DateTime>();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_DateTime_InvalidString_WithDefaultValue_ReturnsDefaultValue()
    {
        // Arrange
        object? input = "invalid";
        object? defaultValue = "2021-12-12";
        var expected = new DateTime(2021, 12, 12);

        // Act
        var actual = input.Parse<DateTime>(defaultValue);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_DateTime_ValidString_WithMultipleFormat_ReturnsCorrectValue()
    {
        // Arrange
        object? input = "12-01-2023 18:00:00";
        var expected = new DateTime(2023, 1, 12, 18, 0, 0);

        // Act
        var actual = input.Parse<DateTime>(format: "dd-MM-yyyy HH:mm:ss");

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_DateTime_ValidString_WithMultipleFormats_ReturnsCorrectValue()
    {
        // Arrange
        object? input = "12/01/2023 18:00:00";
        var expected = new DateTime(2023, 1, 12, 18, 0, 0);
        IEnumerable<string?> format = ["dd-MM-yyyy HH:mm:ss", "dd/MM/yyyy HH:mm:ss"];

        // Act
        var actual = input.Parse<DateTime>(format: format);

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion

    #region Guid
    [Fact]
    public void Parse_Guid_ValidString_ReturnsExpectedValue()
    {
        // Arrange
        object? input = "da03fa84-8172-4ad1-8284-fa89ef52d0de";
        var expected = new Guid("da03fa84-8172-4ad1-8284-fa89ef52d0de");

        // Act
        var actual = input.Parse<Guid>();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_Guid_InvalidString_ReturnsDefault()
    {
        // Arrange
        object? input = "invalid";
        var expected = default(Guid);

        // Act
        var actual = input.Parse<Guid>();

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion

    #region Enum
    [Theory]
    [InlineData("ValueA", TestEnum.ValueA)]
    [InlineData("valueb", TestEnum.ValueB)]
    [InlineData("VALUEC", TestEnum.ValueC)]
    public void Parse_Enum_ValidString_ReturnsExpectedValue(string input, TestEnum expected)
    {
        // Arrange
        object val = input;

        // Act
        var actual = val.Parse<TestEnum>();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_Enum_InvalidString_ReturnsDefault()
    {
        // Arrange
        object? input = "invalid";
        var expected = default(TestEnum);

        // Act
        var actual = input.Parse<TestEnum>();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_Enum_InvalidString_WithDefaultValue_ReturnsDefaultValue()
    {
        // Arrange
        object? input = "invalid";
        object? defaultValue = TestEnum.ValueB;
        var expected = TestEnum.ValueB;

        // Act
        var actual = input.Parse<TestEnum>(defaultValue);

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion

    #region Collections
    [Fact]
    public void Parses_Bool_Enumerable_ValidValues_ReturnsExpectedCollection()
    {
        // Arrange
        var input = new object?[] { "true", "false", 0, 1 };
        var expected = new List<bool> { true, false, false, true };

        // Act
        var actual = input.Parses<bool>();

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parses_Bool_Enumerable_WithInvalidValue_ReturnsDefaultForThatValue()
    {
        // Arrange
        var input = new object?[] { "true", "false", "invalid", 0, 1 };
        var expected = new List<bool> { true, false, default, false, true };

        // Act
        var actual = input.Parses<bool>();

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parses_Params_Bool_ValidValues_ReturnsExpectedCollection()
    {
        // Arrange
        var expected = new List<bool> { true, false, true, false };

        // Act
        var actual = YANUnmanaged.Parses<bool>(1, 0, "true", "false");

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parses_Params_Bool_WithInvalidValue_ReturnsDefaultForThatValue()
    {
        // Arrange
        var expected = new List<bool> { true, false, default, true, false };

        // Act
        var actual = YANUnmanaged.Parses<bool>(1, 0, "invalid", "true", "false");

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parses_Int_Enumerable_ValidValues_ReturnsExpectedCollection()
    {
        // Arrange
        var input = new object?[] { "1", "-2", 0, 4.5, 6.6 };
        var expected = new List<int> { 1, -2, 0, 4, 7 };

        // Act
        var actual = input.Parses<int>();

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parses_Int_Enumerable_WithInvalidValue_ReturnsDefaultForThatValue()
    {
        // Arrange
        var input = new object?[] { "1", "-2", "0.0", "invalid", -4.5, -6.6 };
        var expected = new List<int> { 1, -2, default, default, -4, -7 };

        // Act
        var actual = input.Parses<int>();

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parses_Params_Int_ValidValues_ReturnsExpectedCollection()
    {
        // Arrange
        var expected = new List<int> { 1, 0, -2 };

        // Act
        var actual = YANUnmanaged.Parses<int>(1, false, "-2");

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parses_Params_Int_WithInvalidValue_ReturnsDefaultForThatValue()
    {
        // Arrange
        var expected = new List<int> { -1, default, 1 };

        // Act
        var actual = YANUnmanaged.Parses<int>(-1.2, "invalid", true);

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parses_Double_Enumerable_ValidValues_ReturnsExpectedCollection()
    {
        // Arrange
        var input = new object?[] { "1.23", "-4", 0, 5 };
        var expected = new List<double> { 1.23, -4.0, 0.0, 5.0 };

        // Act
        var actual = input.Parses<double>();

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parses_Double_Enumerable_WithInvalidValue_ReturnsDefaultForThatValue()
    {
        // Arrange
        var input = new object?[] { "1.23", "-4", "0", "invalid", -5 };
        var expected = new List<double> { 1.23, -4.0, 0.0, default, -5.0 };

        // Act
        var actual = input.Parses<double>();

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parses_Params_Double_ValidValues_ReturnsExpectedCollection()
    {
        // Arrange
        var expected = new List<double> { -1.0, 0.0, 2.34 };

        // Act
        var actual = YANUnmanaged.Parses<double>(-1, false, "2.34");

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parses_Params_Double_WithInvalidValue_ReturnsDefaultForThatValue()
    {
        // Arrange
        var expected = new List<double> { 3.0, default, -2.71828 };

        // Act
        var actual = YANUnmanaged.Parses<double>("3", "invalid", "-2.71828");

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_String_Enumerable_ValidValues_ReturnsExpectedCollection()
    {
        // Arrange
        var input = new object?[] { 1, "2", -3 };
        var expected = new List<string> { "1", "2", "-3" };

        // Act
        var actual = input.Parses<string>();

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parses_Params_String_ValidValues_ReturnsExpectedCollection()
    {
        // Arrange
        var expected = new List<string> { "1", "world" };

        // Act
        var actual = YANUnmanaged.Parses<string>(1, "world");

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parses_DateTime_Enumerable_ValidValues_ReturnsExpectedCollection()
    {
        // Arrange
        var input = new object?[] { "2023-01-01 13:45:59", "2023-03-03 15:47:01" };
        var expected = new List<DateTime> { new(2023, 1, 1, 13, 45, 59), new(2023, 3, 3, 15, 47, 1) };

        // Act
        var actual = input.Parses<DateTime>();

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parses_DateTime_Enumerable_WithInvalidValue_ReturnsDefaultForThatValue()
    {
        // Arrange
        var input = new object?[] { "2023-01-01 13:45:59", "invalid" };
        var expected = new List<DateTime> { new(2023, 1, 1, 13, 45, 59), default };

        // Act
        var actual = input.Parses<DateTime>();

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parses_Params_DateTime_ValidValues_ReturnsExpectedCollection()
    {
        // Arrange
        var expected = new List<DateTime> { new(2023, 1, 1), new(2023, 2, 2) };

        // Act
        var actual = YANUnmanaged.Parses<DateTime>("2023-01-01", "2023-02-02");

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parses_Params_DateTime_WithInvalidValue_ReturnsDefaultForThatValue()
    {
        // Arrange
        var expected = new List<DateTime> { new(2023, 1, 1), default };

        // Act
        var actual = YANUnmanaged.Parses<DateTime>("2023-01-01", "invalid");

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_Guid_Enumerable_ValidValues_ReturnsExpectedCollection()
    {
        // Arrange
        var guid1 = new Guid("da03fa84-8172-4ad1-8284-fa89ef52d0de");
        var guid2 = new Guid("83af426c-dab9-4a58-8784-8f4ac109e988");
        var input = new object?[] { guid1.ToString(), guid2.ToString() };
        var expected = new List<Guid> { guid1, guid2 };

        // Act
        var actual = input.Parses<Guid>();

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_Guid_Enumerable_WithInvalidValue_ReturnsDefaultForThatValue()
    {
        // Arrange
        var guid1 = new Guid("da03fa84-8172-4ad1-8284-fa89ef52d0de");
        var guid2 = default(Guid);
        var input = new object?[] { guid1.ToString(), "invalid" };
        var expected = new List<Guid> { guid1, guid2 };

        // Act
        var actual = input.Parses<Guid>();

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parses_Params_Guid_ValidValues_ReturnsExpectedCollection()
    {
        // Arrange
        var expected = new List<Guid> { new("da03fa84-8172-4ad1-8284-fa89ef52d0de"), new("83af426c-dab9-4a58-8784-8f4ac109e988") };

        // Act
        var actual = YANUnmanaged.Parses<Guid>("da03fa84-8172-4ad1-8284-fa89ef52d0de", "83af426c-dab9-4a58-8784-8f4ac109e988");

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parses_Params_Guid_WithInvalidValue_ReturnsDefaultForThatValue()
    {
        // Arrange
        var expected = new List<Guid> { new("da03fa84-8172-4ad1-8284-fa89ef52d0de"), default };

        // Act
        var actual = YANUnmanaged.Parses<Guid>("da03fa84-8172-4ad1-8284-fa89ef52d0de", "invalid");

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parses_Enum_Enumerable_ValidValues_ReturnsExpectedCollection()
    {
        // Arrange
        var input = new object?[] { "ValueA", "valueB", "VALUEC" };
        var expected = new List<TestEnum> { TestEnum.ValueA, TestEnum.ValueB, TestEnum.ValueC };

        // Act
        var actual = input.Parses<TestEnum>();

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parses_Enum_Enumerable_WithInvalidValue_ReturnsDefaultForThatValue()
    {
        // Arrange
        var input = new object?[] { "ValueA", "invalid", "VALUEC" };
        var expected = new List<TestEnum> { TestEnum.ValueA, default, TestEnum.ValueC };

        // Act
        var actual = input.Parses<TestEnum>();

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parses_Params_Enum_ValidValues_ReturnsExpectedCollection()
    {
        // Arrange
        var expected = new List<TestEnum> { TestEnum.ValueA, TestEnum.ValueB };

        // Act
        var actual = YANUnmanaged.Parses<TestEnum>("ValueA", "valueB");

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parses_Params_Enum_WithInvalidValue_ReturnsDefaultForThatValue()
    {
        // Arrange
        var expected = new List<TestEnum> { TestEnum.ValueA, default };

        // Act
        var actual = YANUnmanaged.Parses<TestEnum>("ValueA", "invalid");

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }
    #endregion
}

public enum TestEnum
{
    ValueA,
    ValueB,
    ValueC
}
