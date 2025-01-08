using YANLib.Unmanaged;

namespace YANLib.Tests.Library.Unmanaged;

public class YANUnmanagedNullableTest
{
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
        object? input = "invalid-guid";
        var expected = default(Guid);

        // Act
        var actual = input.Parse<Guid>();

        // Assert
        Assert.Equal(expected, actual);
    }

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
        object? input = "invalid-guid";
        Guid? expected = default;

        // Act
        var actual = input.Parse<Guid?>();

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion

    #region numeric types
    [Fact]
    public void Parse_NullableInt_ValidString_ReturnsExpectedValue()
    {
        // Arrange
        object? input = "123";
        int? expected = 123;

        // Act
        var actual = input.Parse<int?>();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_NullableInt_InvalidString_ReturnsDefault()
    {
        // Arrange
        object? input = "abc";
        int? expected = default;

        // Act
        var actual = input.Parse<int?>();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_NullableDouble_ValidString_ReturnsExpectedValue()
    {
        // Arrange
        object? input = "3.14";
        double? expected = 3.14;

        // Act
        var actual = input.Parse<double?>();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_NullableDouble_InvalidString_ReturnsDefault()
    {
        // Arrange
        object? input = "xyz";
        double? expected = default;

        // Act
        var actual = input.Parse<double?>();

        // Assert
        Assert.Equal(expected, actual);
    }
    #endregion

    #region collections
    [Fact]
    public void Parse_String_Enumerable_ValidValues_ReturnsExpectedCollection()
    {
        // Arrange
        var input = new object?[]
        {
            1,
            "2",
            -3
        };

        var expected = new List<string>
        {
            "1",
            "2",
            "-3"
        };

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
        var expected = new List<string>
        {
            "1",
            "world"
        };

        // Act
        var actual = YANUnmanaged.Parses<string>(1, "world");

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_NullableString_Enumerable_ValidValues_ReturnsExpectedCollection()
    {
        // Arrange
        var input = new object?[]
        {
            1,
            "2",
            3
        };

        var expected = new List<string?>
        {
            "1",
            "2",
            "3"
        };

        // Act
        var actual = input.Parses<string?>();

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_NullableString_Enumerable_WithInvalidValue_ReturnsDefaultForThatValue()
    {
        // Arrange
        var input = new object?[]
        {
            1,
            null,
            "3"
        };

        var expected = new List<string?>
        {
            "1",
            default,
            "3"
        };

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
        var expected = new List<string?>
        {
            "1",
            "world"
        };

        // Act
        var actual = YANUnmanaged.Parses<string?>(1, "world");

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parses_Params_NullableString_WithInvalidValue_ReturnsDefaultForThatValue()
    {
        // Arrange
        var expected = new List<string?>
        {
            "-1.23",
            default,
            "world"
        };

        // Act
        var actual = YANUnmanaged.Parses<string?>(-1.23, null, "world");

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_NullableDateTime_Enumerable_ValidValues_ReturnsExpectedCollection()
    {
        // Arrange
        var input = new object?[]
        {
            "2023-01-01 13:45:59",
            "2023-02-02 14:46:00",
            "2023-03-03 15:47:01"
        };

        var expected = new List<DateTime?>
        {
            new DateTime(2023, 1, 1, 13, 45, 59),
            new DateTime(2023, 2, 2, 14, 46, 0),
            new DateTime(2023, 3, 3, 15, 47, 1)
        };

        // Act
        var actual = input.Parses<DateTime?>();

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_NullableDateTime_Enumerable_WithInvalidValue_ReturnsDefaultForThatValue()
    {
        // Arrange
        var input = new object?[]
        {
            "2023-01-01 13:45:59",
            "invalid",
            "2023-03-03 15:47:01"
        };

        var expected = new List<DateTime?>
        {
            new DateTime(2023, 1, 1, 13, 45, 59),
            default,
            new DateTime(2023, 3, 3, 15, 47, 1)
        };

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
        var expected = new List<DateTime?>
        {
            new DateTime(2023, 1, 1),
            new DateTime(2023, 2, 2)
        };

        // Act
        var actual = YANUnmanaged.Parses<DateTime?>("2023-01-01", "2023-02-02");

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parses_Params_NullableDateTime_WithInvalidValue_ReturnsDefaultForThatValue()
    {
        // Arrange
        var expected = new List<DateTime?>
        {
            new DateTime(2023, 1, 1),
            default,
            new DateTime(2023, 2, 2)
        };

        // Act
        var actual = YANUnmanaged.Parses<DateTime?>("2023-01-01", "invalid-date", "2023-02-02");

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
        var input = new object?[]
        {
            "da03fa84-8172-4ad1-8284-fa89ef52d0de",
            "83af426c-dab9-4a58-8784-8f4ac109e988"
        };

        var expected = new List<Guid?>
        {
            guid1,
            guid2
        };

        // Act
        var actual = input.Parses<Guid?>();

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
        var input = new object?[]
        {
            "da03fa84-8172-4ad1-8284-fa89ef52d0de",
            "invalid-guid"
        };

        var expected = new List<Guid>
        {
            guid1,
            guid2
        };

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
        var expected = new List<Guid>
        {
            new("da03fa84-8172-4ad1-8284-fa89ef52d0de"),
            new("83af426c-dab9-4a58-8784-8f4ac109e988")
        };

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
        var expected = new List<Guid>
        {
            new("da03fa84-8172-4ad1-8284-fa89ef52d0de"),
            default
        };

        // Act
        var actual = YANUnmanaged.Parses<Guid>("da03fa84-8172-4ad1-8284-fa89ef52d0de", "invalid-guid");

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_NullableGuid_Enumerable_ValidValues_ReturnsExpectedCollection()
    {
        // Arrange
        var g1 = new Guid("da03fa84-8172-4ad1-8284-fa89ef52d0de");
        var g2 = new Guid("83af426c-dab9-4a58-8784-8f4ac109e988");
        var input = new object?[]
        {
            g1.ToString(),
            g2.ToString()
        };

        var expected = new List<Guid?>
        {
            g1,
            g2
        };

        // Act
        var actual = input.Parses<Guid?>();

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_NullableGuid_Enumerable_WithInvalidValue_ReturnsDefaultForThatValue()
    {
        // Arrange
        var g1 = new Guid("da03fa84-8172-4ad1-8284-fa89ef52d0de");
        var input = new object?[]
        {
            g1.ToString(),
            "invalid-guid"
        };

        var expected = new List<Guid?>
        {
            g1,
            default
        };

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
        var expected = new List<Guid?>
        {
            new Guid("da03fa84-8172-4ad1-8284-fa89ef52d0de"),
            new Guid("83af426c-dab9-4a58-8784-8f4ac109e988")
        };

        // Act
        var actual = YANUnmanaged.Parses<Guid?>("da03fa84-8172-4ad1-8284-fa89ef52d0de", "83af426c-dab9-4a58-8784-8f4ac109e988");

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parses_Params_NullableGuid_WithInvalidValue_ReturnsDefaultForThatValue()
    {
        // Arrange
        var expected = new List<Guid?>
        {
            new Guid("da03fa84-8172-4ad1-8284-fa89ef52d0de"),
            default
        };

        // Act
        var actual = YANUnmanaged.Parses<Guid?>("da03fa84-8172-4ad1-8284-fa89ef52d0de", "invalid-guid");

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_NullableInt_Enumerable_ValidValues_ReturnsExpectedCollection()
    {
        // Arrange
        var input = new object?[]
        {
            "1",
            "2",
            "3"
        };

        var expected = new List<int?>
        {
            1,
            2,
            3
        };

        // Act
        var actual = input.Parses<int?>();

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_NullableInt_Enumerable_WithInvalidValue_ReturnsDefaultForThatValue()
    {
        // Arrange
        var input = new object?[]
        {
            "1",
            "invalid",
            "3"
        };

        var expected = new List<int?>
        {
            1,
            default,
            3
        };

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
        var expected = new List<int?>
        {
            1,
            0,
            -2
        };

        // Act
        var actual = YANUnmanaged.Parses<int?>(1, 0, "-2");

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parses_Params_NullableInt_WithInvalidValue_ReturnsDefaultForThatValue()
    {
        // Arrange
        var expected = new List<int?>
        {
            1,
            default,
            -3
        };

        // Act
        var actual = YANUnmanaged.Parses<int?>(1.2, "invalid", "-3");

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_NullableDouble_Enumerable_ValidValues_ReturnsExpectedCollection()
    {
        // Arrange
        var input = new object?[]
        {
            "3.14",
            "2.71828",
            "0",
            "-5.67"
        };

        var expected = new List<double?>
        {
            3.14,
            2.71828,
            0.0,
            -5.67
        };

        // Act
        var actual = input.Parses<double?>();

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parse_NullableDouble_Enumerable_WithInvalidValue_ReturnsDefaultForThatValue()
    {
        // Arrange
        var input = new object?[]
        {
            "3.14",
            "abc",
            "2.71828"
        };

        var expected = new List<double?>
        {
            3.14,
            default,
            2.71828
        };

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
        var expected = new List<double?>
        {
            -1.0,
            0.0,
            2.34
        };

        // Act
        var actual = YANUnmanaged.Parses<double?>(-1, 0, "2.34");

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Parses_Params_NullableDouble_WithInvalidValue_ReturnsDefaultForThatValue()
    {
        // Arrange
        var expected = new List<double?>
        {
            -3.14,
            default,
            2.71828
        };

        // Act
        var actual = YANUnmanaged.Parses<double?>("-3.14", "abc", "2.71828");

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
    }
    #endregion
}
