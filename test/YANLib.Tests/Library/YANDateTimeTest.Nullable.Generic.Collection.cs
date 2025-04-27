namespace YANLib.Tests.Library;

public partial class YANDateTimeTest
{
    #region ChangeTimeZones

    [Fact]
    public void ChangeTimeZones_NullEnumerable_ReturnsNull_NullableGenericCollection()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.ChangeTimeZones(0, 1);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ChangeTimeZones_EmptyEnumerable_ReturnsNull_NullableGenericCollection()
    {
        // Arrange
        var input = Array.Empty<string?>();

        // Act
        var result = input.ChangeTimeZones(0, 1);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ChangeTimeZones_DateTimeCollection_ChangesAllTimeZones_NullableGenericCollection()
    {
        // Arrange
        var input = new DateTime?[]
        {
            new DateTime(2023, 1, 1, 10, 0, 0),
            new DateTime(2023, 6, 15, 12, 0, 0),
            new DateTime(2023, 12, 31, 14, 0, 0)
        };

        var expected = new DateTime?[]
        {
            new DateTime(2023, 1, 1, 13, 0, 0),
            new DateTime(2023, 6, 15, 15, 0, 0),
            new DateTime(2023, 12, 31, 17, 0, 0)
        };

        // Act
        var result = input.ChangeTimeZones(0, 3)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ChangeTimeZones_StringDateCollection_ChangesAllTimeZones_NullableGenericCollection()
    {
        // Arrange
        var input = new string?[]
        {
            "2023-01-01 10:00:00",
            "2023-06-15 12:00:00",
            "2023-12-31 14:00:00"
        };

        var expected = new DateTime?[]
        {
            new DateTime(2023, 1, 1, 13, 0, 0),
            new DateTime(2023, 6, 15, 15, 0, 0),
            new DateTime(2023, 12, 31, 17, 0, 0)
        };

        // Act
        var result = input.ChangeTimeZones(0, 3)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ChangeTimeZones_MixedNullValues_PreservesNulls_NullableGenericCollection()
    {
        // Arrange
        var input = new DateTime?[]
        {
            new DateTime(2023, 1, 1, 10, 0, 0),
            null,
            new DateTime(2023, 12, 31, 14, 0, 0)
        };

        var expected = new DateTime?[]
        {
            new DateTime(2023, 1, 1, 12, 0, 0),
            null,
            new DateTime(2023, 12, 31, 16, 0, 0)
        };

        // Act
        var result = input.ChangeTimeZones(0, 2)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ChangeTimeZones_InvalidStringDates_HandlesGracefully_NullableGenericCollection()
    {
        // Arrange
        var input = new string?[]
        {
            "2023-01-01 10:00:00",
            "not a date",
            "2023-12-31 14:00:00"
        };

        var expected = new DateTime?[]
        {
            new DateTime(2023, 1, 1, 12, 0, 0),
            null,
            new DateTime(2023, 12, 31, 16, 0, 0)
        };

        // Act
        var result = input.ChangeTimeZones(0, 2)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ChangeTimeZones_CustomType_HandlesConversion_NullableGenericCollection()
    {
        // Arrange
        var input = new TestDateContainer[]
        {
            new() { Date = new DateTime(2023, 1, 1, 10, 0, 0) },
            new() { Date = new DateTime(2023, 6, 15, 12, 0, 0) }
        };

        var expected = new DateTime?[]
        {
            new DateTime(2023, 1, 1, 12, 0, 0),
            new DateTime(2023, 6, 15, 14, 0, 0)
        };

        // Act
        var result = input.ChangeTimeZones(0, 2)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ChangeTimeZones_SameTimeZones_ReturnsSameValues_NullableGenericCollection()
    {
        // Arrange
        var input = new DateTime?[]
        {
            new DateTime(2023, 1, 1, 10, 0, 0),
            new DateTime(2023, 6, 15, 12, 0, 0)
        };

        var expected = new DateTime?[]
        {
            new DateTime(2023, 1, 1, 10, 0, 0),
            new DateTime(2023, 6, 15, 12, 0, 0)
        };

        // Act
        var result = input.ChangeTimeZones(1, 1)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ChangeTimeZones_NegativeOffset_SubtractsHours_NullableGenericCollection()
    {
        // Arrange
        var input = new DateTime?[]
        {
            new DateTime(2023, 1, 1, 10, 0, 0),
            new DateTime(2023, 6, 15, 12, 0, 0)
        };

        var expected = new DateTime?[]
        {
            new DateTime(2023, 1, 1, 7, 0, 0),
            new DateTime(2023, 6, 15, 9, 0, 0)
        };

        // Act
        var result = input.ChangeTimeZones(0, -3)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ChangeTimeZones_StringTimeZones_ConvertsAndApplies_NullableGenericCollection()
    {
        // Arrange
        var input = new DateTime?[]
        {
            new DateTime(2023, 1, 1, 10, 0, 0),
            new DateTime(2023, 6, 15, 12, 0, 0)
        };

        var expected = new DateTime?[]
        {
            new DateTime(2023, 1, 1, 13, 0, 0),
            new DateTime(2023, 6, 15, 15, 0, 0)
        };

        // Act
        var result = input.ChangeTimeZones("0", "3")?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    #endregion
}
