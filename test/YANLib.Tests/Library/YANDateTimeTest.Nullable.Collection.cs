using System.Collections;

namespace YANLib.Tests.Library;

public partial class YANDateTimeTest
{
    #region ChangeTimeZone

    [Fact]
    public void ChangeTimeZone_NullList_DoesNotThrow_NullableCollection()
    {
        // Arrange
        List<object?>? input = null;

        // Act
        var exception = Record.Exception(() => input.ChangeTimeZone(0, 1));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void ChangeTimeZone_EmptyList_DoesNotModify_NullableCollection()
    {
        // Arrange
        var input = new List<object?>();

        // Act
        input.ChangeTimeZone(0, 1);

        // Assert
        Assert.Empty(input);
    }

    [Fact]
    public void ChangeTimeZone_ValidList_ChangesAllTimeZones_NullableCollection()
    {
        // Arrange
        var input = new List<object?>
        {
            new DateTime(2023, 1, 1, 10, 0, 0),
            "2023-06-15 12:00:00",
            new DateTime(2023, 12, 31, 14, 0, 0)
        };

        var expected = new List<object?>
        {
            new DateTime(2023, 1, 1, 12, 0, 0),
            new DateTime(2023, 6, 15, 14, 0, 0),
            new DateTime(2023, 12, 31, 16, 0, 0)
        };

        // Act
        input.ChangeTimeZone(0, 2);

        // Assert
        Assert.Equal(expected[0], input[0]);
        Assert.Equal(expected[1], input[1]);
        Assert.Equal(expected[2], input[2]);
    }

    [Fact]
    public void ChangeTimeZone_MixedValidAndInvalidObjects_HandlesGracefully_NullableCollection()
    {
        // Arrange
        var input = new List<object?>
        {
            new DateTime(2023, 1, 1, 10, 0, 0),
            "not a date",
            null
        };

        var expected = new List<object?>
        {
            new DateTime(2023, 1, 1, 12, 0, 0),
            null,
            null
        };

        // Act
        input.ChangeTimeZone(0, 2);

        // Assert
        Assert.Equal(expected[0], input[0]);
        Assert.Null(input[1]);
        Assert.Null(input[2]);
    }

    [Fact]
    public void ChangeTimeZone_SameTimeZones_DoesNotModify_NullableCollection()
    {
        // Arrange
        var input = new List<object?>
        {
            new DateTime(2023, 1, 1, 10, 0, 0),
            new DateTime(2023, 6, 15, 12, 0, 0)
        };

        var expected = new List<object?>
        {
            new DateTime(2023, 1, 1, 10, 0, 0),
            new DateTime(2023, 6, 15, 12, 0, 0)
        };

        // Act
        input.ChangeTimeZone(2, 2);

        // Assert
        Assert.Equal(expected[0], input[0]);
        Assert.Equal(expected[1], input[1]);
    }

    [Fact]
    public void ChangeTimeZone_NegativeOffset_SubtractsHours_NullableCollection()
    {
        // Arrange
        var input = new List<object?>
        {
            new DateTime(2023, 1, 1, 10, 0, 0),
            "2023-06-15 12:00:00"
        };

        var expected = new List<object?>
        {
            new DateTime(2023, 1, 1, 8, 0, 0),
            new DateTime(2023, 6, 15, 10, 0, 0)
        };

        // Act
        input.ChangeTimeZone(0, -2);

        // Assert
        Assert.Equal(expected[0], input[0]);
        Assert.Equal(expected[1], input[1]);
    }

    #endregion

    #region ChangeTimeZones

    [Fact]
    public void ChangeTimeZones_NullEnumerable_ReturnsNull_NullableCollection()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.ChangeTimeZones(0, 1);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ChangeTimeZones_EmptyEnumerable_ReturnsNull_NullableCollection()
    {
        // Arrange
        var input = Array.Empty<object?>();

        // Act
        var result = input.ChangeTimeZones(0, 1);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ChangeTimeZones_ValidObjects_ChangesAllTimeZones_NullableCollection()
    {
        // Arrange
        var input = new object?[]
        {
            new DateTime(2023, 1, 1, 10, 0, 0),
            "2023-06-15 12:00:00",
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
    public void ChangeTimeZones_MixedValidAndInvalidObjects_HandlesGracefully_NullableCollection()
    {
        // Arrange
        var input = new object?[]
        {
            new DateTime(2023, 1, 1, 10, 0, 0),
            "not a date",
            null
        };

        var expected = new DateTime?[]
        {
            new DateTime(2023, 1, 1, 12, 0, 0),
            null,
            null
        };

        // Act
        var result = input.ChangeTimeZones(0, 2)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ChangeTimeZones_SameTimeZones_ReturnsSameValues_NullableCollection()
    {
        // Arrange
        var input = new object?[]
        {
            new DateTime(2023, 1, 1, 10, 0, 0),
            "2023-06-15 12:00:00"
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
    public void ChangeTimeZones_IEnumerableOverload_ChangesAllTimeZones_NullableCollection()
    {
        // Arrange
        ArrayList input = [new DateTime(2023, 1, 1, 10, 0, 0), "2023-06-15 12:00:00"];

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
    public void ChangeTimeZones_NullIEnumerable_ReturnsNull_NullableCollection()
    {
        // Arrange
        ArrayList? input = null;

        // Act
        var result = input.ChangeTimeZones(0, 1);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ChangeTimeZones_StringTimeZones_ConvertsAndApplies_NullableCollection()
    {
        // Arrange
        var input = new object?[]
        {
            new DateTime(2023, 1, 1, 10, 0, 0),
            "2023-06-15 12:00:00"
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

    [Fact]
    public void ChangeTimeZones_DecimalTimeZones_ConvertsAndApplies_NullableCollection()
    {
        // Arrange
        var input = new object?[]
        {
            new DateTime(2023, 1, 1, 10, 0, 0),
            "2023-06-15 12:00:00"
        };

        var expected = new DateTime?[]
        {
            new DateTime(2023, 1, 1, 13, 30, 0),
            new DateTime(2023, 6, 15, 15, 30, 0)
        };

        // Act
        var result = input.ChangeTimeZones(0, 3.5m)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ChangeTimeZones_MixedValidAndNullValues_HandlesNullsProperly_NullableCollection()
    {
        // Arrange
        var input = new DateTime?[]
        {
            new DateTime(2023, 6, 15, 10, 30, 0),
            null,
            new DateTime(2023, 12, 25, 15, 45, 0)
        };
        var fromOffset = 0;
        var toOffset = 2;

        // Act
        var result = input.ChangeTimeZones(fromOffset, toOffset)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result!.Length);
        Assert.Equal(new DateTime(2023, 6, 15, 12, 30, 0), result[0]);
        Assert.Null(result[1]);
        Assert.Equal(new DateTime(2023, 12, 25, 17, 45, 0), result[2]);
    }

    #endregion
}
