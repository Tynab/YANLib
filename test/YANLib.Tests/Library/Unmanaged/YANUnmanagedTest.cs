using YANLib.Unmanaged;

namespace YANLib.Tests.Library.Unmanaged;

public class YANUnmanagedTest
{
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
        object? input = "invalid-string";
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
        object? input = "invalid-string";
        object? defaultValue = "2021-12-12";
        var expected = new DateTime(2021, 12, 12);

        // Act
        var actual = input.Parse<DateTime>(defaultValue);

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
        var actual = input.Parse<DateTime>(null, format);

        // Assert
        Assert.Equal(expected, actual);
    }

    #endregion

    #region numeric types

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
        object? input = "abc";
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
        object? input = "abc";
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
        object? input = "abc";
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
        object? input = "abc";
        object? defaultValue = 9.99;
        var expected = 9.99;

        // Act
        var actual = input.Parse<double>(defaultValue);

        // Assert
        Assert.Equal(expected, actual);
    }

    #endregion

    #region collections

    [Fact]
    public void Parses_DateTime_Enumerable_ValidValues_ReturnsExpectedCollection()
    {
        // Arrange
        var input = new object?[]
        {
            "2023-01-01 13:45:59",
            "2023-02-02 14:46:00",
            "2023-03-03 15:47:01"
        };

        var expected = new List<DateTime>
        {
            new(2023, 1, 1, 13, 45, 59),
            new(2023, 2, 2, 14, 46, 0),
            new(2023, 3, 3, 15, 47, 1)
        };

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
        var input = new object?[]
        {
            "2023-01-01 13:45:59",
            "invalid",
            "2023-03-03 15:47:01"
        };

        var expected = new List<DateTime>
        {
            new(2023, 1, 1, 13, 45, 59),
            default,
            new(2023, 3, 3, 15, 47, 1)
        };

        // Act
        var actual = input.Parses<DateTime>();

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parses_Int_Enumerable_ValidValues_ReturnsExpectedCollection()
    {
        // Arrange
        var input = new object?[]
        {
            "1",
            4.5,
            6.7
        };

        var expected = new List<int>
        {
            1,
            4,
            7
        };

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
        var input = new object?[]
        {
            "-1",
            "invalid",
            -2.3
        };

        var expected = new List<int>
        {
            -1,
            0,
            -2
        };

        // Act
        var actual = input.Parses<int>();

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parses_Double_Enumerable_ValidValues_ReturnsExpectedCollection()
    {
        // Arrange
        var input = new object?[]
        {
            "1.23",
            "0",
            1
        };

        var expected = new List<double>
        {
            1.23,
            0.0,
            1.0
        };

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
        var input = new object?[]
        {
            "-1.23",
            "abc",
            -1
        };

        var expected = new List<double>
        {
            -1.23,
            0.0,
            -1.0
        };

        // Act
        var actual = input.Parses<double>();

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    #endregion
}
