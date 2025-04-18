using YANLib.Unmanaged;

namespace YANLib.Tests.Library.Unmanaged;

public partial class YANUnmanagedTest
{
    #region bool
    [Theory]
    [InlineData("true", true)]
    [InlineData("false", false)]
    public void Parse_NullableBool_ValidString_ReturnsExpectedValue(string input, bool? expected)
    {
        // Arrange
        object? val = input;

        // Act
        var actual = val.Parse<bool?>();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_NullableBool_InvalidString_ReturnsDefault()
    {
        // Arrange
        object? input = "invalid";
        var expected = default(bool?);

        // Act
        var actual = input.Parse<bool?>();

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion

    #region Numeric types
    [Theory]
    [InlineData("0", 0)]
    [InlineData("1.2", default)]
    [InlineData("3", 3)]
    [InlineData("-4", -4)]
    public void Parse_NullableInt_ValidString_ReturnsExpectedValue(string input, int? expected)
    {
        // Arrange
        object? val = input;

        // Act
        var actual = val.Parse<int?>();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_NullableInt_InvalidString_ReturnsDefault()
    {
        // Arrange
        object? input = "invalid";
        int? expected = default;

        // Act
        var actual = input.Parse<int?>();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("0", 0.0)]
    [InlineData("1", 1.0)]
    [InlineData("2.34", 2.34)]
    [InlineData("-5.67", -5.67)]
    public void Parse_NullableDouble_ValidString_ReturnsExpectedValue(string input, double? expected)
    {
        // Arrange
        object? val = input;

        // Act
        var actual = val.Parse<double?>();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_NullableDouble_InvalidString_ReturnsDefault()
    {
        // Arrange
        object? input = "invalid";
        double? expected = default;

        // Act
        var actual = input.Parse<double?>();

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion

    #region string
    [Fact]
    public void Parse_NullableString_ValidString_ReturnsExpectedValue()
    {
        // Arrange
        object? input = 1;
        var expected = "1";

        // Act
        var actual = input.Parse<string?>();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_NullableString_InvalidString_ReturnsDefault()
    {
        // Arrange
        object? input = null;
        string? expected = default;

        // Act
        var actual = input.Parse<string?>();

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion

    #region DateTime
    [Fact]
    public void Parse_NullableDateTime_ValidString_ReturnsExpectedValue()
    {
        // Arrange
        object? input = "2023-01-01 13:45:59";
        DateTime? expected = new DateTime(2023, 1, 1, 13, 45, 59);

        // Act
        var actual = input.Parse<DateTime?>();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_NullableDateTime_InvalidString_ReturnsDefault()
    {
        // Arrange
        object? input = "invalid";
        DateTime? expected = default;

        // Act
        var actual = input.Parse<DateTime?>();

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion

    #region Guid
    [Fact]
    public void Parse_NullableGuid_ValidString_ReturnsExpectedValue()
    {
        // Arrange
        object? input = "a1b2c3d4-e5f6-1234-5678-9abcdef01234";
        Guid? expected = new Guid("a1b2c3d4-e5f6-1234-5678-9abcdef01234");

        // Act
        var actual = input.Parse<Guid?>();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_NullableGuid_InvalidString_ReturnsDefault()
    {
        // Arrange
        object? input = "invalid";
        Guid? expected = default;

        // Act
        var actual = input.Parse<Guid?>();

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion

    #region Collections
    [Fact]
    public void Parse_NullableBool_Enumerable_ValidValues_ReturnsExpectedCollection()
    {
        // Arrange
        var input = new object?[] { "TRUE", "FALSE", 0, 1 };
        var expected = new List<bool?> { true, false, false, true };

        // Act
        var actual = input.Parses<bool?>();

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_NullableBool_Enumerable_InvalidValue_ReturnsDefaultForThatValue()
    {
        // Arrange
        var input = new object?[] { "TRUE", "FALSE", "invalid", 0, 1 };
        var expected = new List<bool?> { true, false, default, false, true };

        // Act
        var actual = input.Parses<bool?>();

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parses_Params_NullableBool_ValidValues_ReturnsExpectedCollection()
    {
        // Arrange
        var expected = new List<bool?> { true, false, true, false };

        // Act
        var actual = YANUnmanaged.Parses<bool?>(1, 0, "TRUE", "FALSE");

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parses_Params_NullableBool_InvalidValue_ReturnsDefaultForThatValue()
    {
        // Arrange
        var expected = new List<bool?> { true, false, default, true, false };

        // Act
        var actual = YANUnmanaged.Parses<bool?>(1, 0, "invalid", "TRUE", "FALSE");

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_NullableInt_Enumerable_ValidValues_ReturnsExpectedCollection()
    {
        // Arrange
        var input = new object?[] { "1", "-2", 0, 4.5, 6.6 };
        var expected = new List<int?> { 1, -2, 0, 4, 7 };

        // Act
        var actual = input.Parses<int?>();

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_NullableInt_Enumerable_InvalidValue_ReturnsDefaultForThatValue()
    {
        // Arrange
        var input = new object?[] { "1", "-2", "0.0", "invalid", -4.5, -6.6 };
        var expected = new List<int?> { 1, -2, default, default, -4, -7 };

        // Act
        var actual = input.Parses<int?>();

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parses_Params_NullableInt_ValidValues_ReturnsExpectedCollection()
    {
        // Arrange
        var expected = new List<int?> { 1, 0, -2 };

        // Act
        var actual = YANUnmanaged.Parses<int?>(1, 0, "-2");

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parses_Params_NullableInt_InvalidValue_ReturnsDefaultForThatValue()
    {
        // Arrange
        var expected = new List<int?> { -1, default, 1 };

        // Act
        var actual = YANUnmanaged.Parses<int?>(-1.2, "invalid", true);

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_NullableDouble_Enumerable_ValidValues_ReturnsExpectedCollection()
    {
        // Arrange
        var input = new object?[] { "1.23", "-4", 0, 5 };
        var expected = new List<double?> { 1.23, -4.0, 0.0, 5.0 };

        // Act
        var actual = input.Parses<double?>();

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_NullableDouble_Enumerable_InvalidValue_ReturnsDefaultForThatValue()
    {
        // Arrange
        var input = new object?[] { "1.23", "-4", "0", "invalid", -5 };
        var expected = new List<double?> { 1.23, -4.0, 0.0, default, -5.0 };

        // Act
        var actual = input.Parses<double?>();

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parses_Params_NullableDouble_ValidValues_ReturnsExpectedCollection()
    {
        // Arrange
        var expected = new List<double?> { -1.0, 0.0, 2.34 };

        // Act
        var actual = YANUnmanaged.Parses<double?>(-1, false, "2.34");

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parses_Params_NullableDouble_InvalidValue_ReturnsDefaultForThatValue()
    {
        // Arrange
        var expected = new List<double?> { 3.0, default, -2.71828 };

        // Act
        var actual = YANUnmanaged.Parses<double?>("3", "invalid", "-2.71828");

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_NullableString_Enumerable_ValidValues_ReturnsExpectedCollection()
    {
        // Arrange
        var input = new object?[] { 1, "2", 3 };
        var expected = new List<string?> { "1", "2", "3" };

        // Act
        var actual = input.Parses<string?>();

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_NullableString_Enumerable_InvalidValue_ReturnsDefaultForThatValue()
    {
        // Arrange
        var input = new object?[] { 1, null, "3" };
        var expected = new List<string?> { "1", default, "3" };

        // Act
        var actual = input.Parses<string?>();

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parses_Params_NullableString_ValidValues_ReturnsExpectedCollection()
    {
        // Arrange
        var expected = new List<string?> { "1", "world" };

        // Act
        var actual = YANUnmanaged.Parses<string?>(1, "world");

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parses_Params_NullableString_InvalidValue_ReturnsDefaultForThatValue()
    {
        // Arrange
        var expected = new List<string?> { "-1.23", default, "world" };

        // Act
        var actual = YANUnmanaged.Parses<string?>(-1.23, default, "world");

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_NullableDateTime_Enumerable_ValidValues_ReturnsExpectedCollection()
    {
        // Arrange
        var input = new object?[] { "2023-01-01 13:45:59", "2023-03-03 15:47:01" };
        var expected = new List<DateTime?> { new DateTime(2023, 1, 1, 13, 45, 59), new DateTime(2023, 3, 3, 15, 47, 1) };

        // Act
        var actual = input.Parses<DateTime?>();

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_NullableDateTime_Enumerable_InvalidValue_ReturnsDefaultForThatValue()
    {
        // Arrange
        var input = new object?[] { "2023-01-01 13:45:59", "invalid" };
        var expected = new List<DateTime?> { new DateTime(2023, 1, 1, 13, 45, 59), default };

        // Act
        var actual = input.Parses<DateTime?>();

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parses_Params_NullableDateTime_ValidValues_ReturnsExpectedCollection()
    {
        // Arrange
        var expected = new List<DateTime?> { new DateTime(2023, 1, 1), new DateTime(2023, 2, 2) };

        // Act
        var actual = YANUnmanaged.Parses<DateTime?>("2023-01-01", "2023-02-02");

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parses_Params_NullableDateTime_InvalidValue_ReturnsDefaultForThatValue()
    {
        // Arrange
        var expected = new List<DateTime?> { new DateTime(2023, 1, 1), default };

        // Act
        var actual = YANUnmanaged.Parses<DateTime?>("2023-01-01", "invalid");

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_NullableGuid_Enumerable_ValidValues_ReturnsExpectedCollection()
    {
        // Arrange
        var guid1 = new Guid("da03fa84-8172-4ad1-8284-fa89ef52d0de");
        var guid2 = new Guid("83af426c-dab9-4a58-8784-8f4ac109e988");
        var input = new object?[] { guid1.ToString(), guid2.ToString() };
        var expected = new List<Guid?> { guid1, guid2 };

        // Act
        var actual = input.Parses<Guid?>();

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_NullableGuid_Enumerable_InvalidValue_ReturnsDefaultForThatValue()
    {
        // Arrange
        var guid1 = new Guid("da03fa84-8172-4ad1-8284-fa89ef52d0de");
        var guid2 = default(Guid?);
        var input = new object?[] { guid1.ToString(), "invalid" };
        var expected = new List<Guid?> { guid1, guid2 };

        // Act
        var actual = input.Parses<Guid?>();

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parses_Params_NullableGuid_ValidValues_ReturnsExpectedCollection()
    {
        // Arrange
        var expected = new List<Guid?> { new Guid("da03fa84-8172-4ad1-8284-fa89ef52d0de"), new Guid("83af426c-dab9-4a58-8784-8f4ac109e988") };

        // Act
        var actual = YANUnmanaged.Parses<Guid?>("da03fa84-8172-4ad1-8284-fa89ef52d0de", "83af426c-dab9-4a58-8784-8f4ac109e988");

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parses_Params_NullableGuid_InvalidValue_ReturnsDefaultForThatValue()
    {
        // Arrange
        var expected = new List<Guid?> { new Guid("da03fa84-8172-4ad1-8284-fa89ef52d0de"), default };

        // Act
        var actual = YANUnmanaged.Parses<Guid?>("da03fa84-8172-4ad1-8284-fa89ef52d0de", "invalid");

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }
    #endregion
}
