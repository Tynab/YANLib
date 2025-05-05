using System.Collections;

namespace YANLib.Tests.Library;

public partial class YANDateTimeTest
{
    #region GetWeekOfYears

    [Fact]
    public void GetWeekOfYears_NullEnumerable_ReturnsNull_Collection()
    {
        // Arrange
        IEnumerable<DateTime?>? input = null;

        // Act
        var result = input.GetWeekOfYears<int>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetWeekOfYears_EmptyEnumerable_ReturnsNull_Collection()
    {
        // Arrange
        var input = Array.Empty<DateTime?>();

        // Act
        var result = input.GetWeekOfYears<int>();

        // Assert
        Assert.Null(result!);
    }

    [Fact]
    public void GetWeekOfYears_ValidDates_ReturnsCorrectWeeks_Collection()
    {
        // Arrange
        var input = new DateTime?[]
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
    public void GetWeekOfYears_MixedNullValues_IgnoresNulls_Collection()
    {
        // Arrange
        var input = new DateTime?[]
        {
            new DateTime(2023, 1, 1),
            null,
            new DateTime(2023, 12, 31)
        };

        // Act
        var result = input.GetWeekOfYears<int>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Length);
        Assert.Equal(1, result[0]);
        Assert.Equal(0, result[1]);
        Assert.Equal(53, result[2]);
    }

    [Fact]
    public void GetWeekOfYears_ParamsOverload_ReturnsCorrectWeeks_Collection()
    {
        // Arrange & Act
        var result = YANDateTime.GetWeekOfYears<int>(new DateTime(2023, 1, 1), new DateTime(2023, 6, 15), new DateTime(2023, 12, 31))?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Length);
        Assert.Equal(1, result[0]);
        Assert.Equal(24, result[1]);
        Assert.Equal(53, result[2]);
    }

    [Fact]
    public void GetWeekOfYears_IEnumerableOverload_ReturnsCorrectWeeks_Collection()
    {
        // Arrange
        ArrayList input = [new DateTime(2023, 1, 1), new DateTime(2023, 6, 15), new DateTime(2023, 12, 31)];

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
    public void GetWeekOfYears_NullIEnumerable_ReturnsNull_Collection()
    {
        // Arrange
        ArrayList? input = null;

        // Act
        var result = input.GetWeekOfYears<int>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetWeekOfYears_ReturnTypeString_ConvertsToString_Collection()
    {
        // Arrange
        var input = new DateTime?[]
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

    [Fact]
    public void GetWeekOfYears_ReturnTypeDouble_ConvertsToDouble_Collection()
    {
        // Arrange
        var input = new DateTime?[]
        {
            new DateTime(2023, 1, 1),
            new DateTime(2023, 6, 15)
        };

        // Act
        var result = input.GetWeekOfYears<double>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Length);
        Assert.Equal(1.0, result[0]);
        Assert.Equal(24.0, result[1]);
    }

    #endregion

    #region ChangeTimeZone

    [Fact]
    public void ChangeTimeZone_NullList_DoesNotThrow_Collection()
    {
        // Arrange
        List<DateTime>? input = null;

        // Act
        var exception = Record.Exception(() => input.ChangeTimeZone(0, 1));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void ChangeTimeZone_EmptyList_DoesNotModify_Collection()
    {
        // Arrange
        var input = new List<DateTime>();

        // Act
        input.ChangeTimeZone(0, 1);

        // Assert
        Assert.Empty(input);
    }

    [Fact]
    public void ChangeTimeZone_ValidList_ChangesAllTimeZones_Collection()
    {
        // Arrange
        var input = new List<DateTime>
        {
            new(2023, 1, 1, 10, 0, 0),
            new(2023, 6, 15, 12, 0, 0),
            new(2023, 12, 31, 14, 0, 0)
        };

        var expected = new List<DateTime>
        {
            new(2023, 1, 1, 12, 0, 0),
            new(2023, 6, 15, 14, 0, 0),
            new(2023, 12, 31, 16, 0, 0)
        };

        // Act
        input.ChangeTimeZone(0, 2);

        // Assert
        Assert.Equal(expected, input);
    }

    [Fact]
    public void ChangeTimeZone_SameTimeZones_DoesNotModify_Collection()
    {
        // Arrange
        var input = new List<DateTime>
        {
            new(2023, 1, 1, 10, 0, 0),
            new(2023, 6, 15, 12, 0, 0)
        };

        var expected = new List<DateTime>
        {
            new(2023, 1, 1, 10, 0, 0),
            new(2023, 6, 15, 12, 0, 0)
        };

        // Act
        input.ChangeTimeZone(2, 2);

        // Assert
        Assert.Equal(expected, input);
    }

    [Fact]
    public void ChangeTimeZone_NegativeOffset_SubtractsHours_Collection()
    {
        // Arrange
        var input = new List<DateTime>
        {
            new(2023, 1, 1, 10, 0, 0),
            new(2023, 6, 15, 12, 0, 0)
        };

        var expected = new List<DateTime>
        {
            new(2023, 1, 1, 8, 0, 0),
            new(2023, 6, 15, 10, 0, 0)
        };

        // Act
        input.ChangeTimeZone(0, -2);

        // Assert
        Assert.Equal(expected, input);
    }

    [Fact]
    public void ChangeTimeZone_StringTimeZones_ConvertsAndApplies_Collection()
    {
        // Arrange
        var input = new List<DateTime>
        {
            new(2023, 1, 1, 10, 0, 0),
            new(2023, 6, 15, 12, 0, 0)
        };

        var expected = new List<DateTime>
        {
            new(2023, 1, 1, 13, 0, 0),
            new(2023, 6, 15, 15, 0, 0)
        };

        // Act
        input.ChangeTimeZone("0", "3");

        // Assert
        Assert.Equal(expected, input);
    }

    #endregion

    #region ChangeTimeZones

    [Fact]
    public void ChangeTimeZones_NullEnumerable_ReturnsNull_Collection()
    {
        // Arrange
        IEnumerable<DateTime>? input = null;

        // Act
        var result = input.ChangeTimeZones(0, 1);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ChangeTimeZones_EmptyEnumerable_ReturnsEmpty_Collection()
    {
        // Arrange
        var input = Array.Empty<DateTime>();

        // Act
        var result = input.ChangeTimeZones(0, 1);

        // Assert
        Assert.Empty(result!);
    }

    [Fact]
    public void ChangeTimeZones_ValidDates_ChangesAllTimeZones_Collection()
    {
        // Arrange
        var input = new DateTime[]
        {
            new(2023, 1, 1, 10, 0, 0),
            new(2023, 6, 15, 12, 0, 0),
            new(2023, 12, 31, 14, 0, 0)
        };

        var expected = new DateTime[]
        {
            new(2023, 1, 1, 13, 0, 0),
            new(2023, 6, 15, 15, 0, 0),
            new(2023, 12, 31, 17, 0, 0)
        };

        // Act
        var result = input.ChangeTimeZones(0, 3)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ChangeTimeZones_SameTimeZones_ReturnsSameValues_Collection()
    {
        // Arrange
        var input = new DateTime[]
        {
            new(2023, 1, 1, 10, 0, 0),
            new(2023, 6, 15, 12, 0, 0)
        };

        // Act
        var result = input.ChangeTimeZones(1, 1)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(input, result);
    }

    [Fact]
    public void ChangeTimeZones_NegativeOffset_SubtractsHours_Collection()
    {
        // Arrange
        var input = new DateTime[]
        {
            new(2023, 1, 1, 10, 0, 0),
            new(2023, 6, 15, 12, 0, 0)
        };

        var expected = new DateTime[]
        {
            new(2023, 1, 1, 7, 0, 0),
            new(2023, 6, 15, 9, 0, 0)
        };

        // Act
        var result = input.ChangeTimeZones(0, -3)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ChangeTimeZones_StringTimeZones_ConvertsAndApplies_Collection()
    {
        // Arrange
        var input = new DateTime[]
        {
            new(2023, 1, 1, 10, 0, 0),
            new(2023, 6, 15, 12, 0, 0)
        };

        var expected = new DateTime[]
        {
            new(2023, 1, 1, 13, 0, 0),
            new(2023, 6, 15, 15, 0, 0)
        };

        // Act
        var result = input.ChangeTimeZones("0", "3")?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ChangeTimeZones_CustomDateObjects_HandlesConversion_Collection()
    {
        // Arrange
        var input = new DateTime[]
        {
            new(2023, 1, 1, 10, 0, 0),
            new(2023, 6, 15, 12, 0, 0)
        };

        var expected = new DateTime[]
        {
            new(2023, 1, 1, 12, 0, 0),
            new(2023, 6, 15, 14, 0, 0)
        };

        // Act
        var result = input.ChangeTimeZones(0, 2)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ChangeTimeZones_DecimalTimeZones_ConvertsAndApplies_Collection()
    {
        // Arrange
        var input = new DateTime[]
        {
            new(2023, 1, 1, 10, 0, 0),
            new(2023, 6, 15, 12, 0, 0)
        };

        var expected = new DateTime[]
        {
            new(2023, 1, 1, 13, 30, 0),
            new(2023, 6, 15, 15, 30, 0)
        };

        // Act
        var result = input.ChangeTimeZones(0, 3.5m)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ChangeTimeZones_InvalidTimeZones_UsesDefaultValues_Collection()
    {
        // Arrange
        var input = new DateTime[]
        {
            new(2023, 1, 1, 10, 0, 0),
            new(2023, 6, 15, 12, 0, 0)
        };

        var expected = new DateTime[]
        {
            new(2023, 1, 1, 10, 0, 0),
            new(2023, 6, 15, 12, 0, 0)
        };

        // Act
        var result = input.ChangeTimeZones("invalid", "timezone")?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ChangeTimeZones_CrossingDaylightSavingTime_AdjustsTimeCorrectly_Collection()
    {
        // Arrange
        var input = new DateTime[]
        {
            new(2023, 3, 25, 10, 0, 0),
            new(2023, 3, 27, 10, 0, 0),
            new(2023, 10, 28, 10, 0, 0),
            new(2023, 10, 30, 10, 0, 0)
        };

        var fromOffset = 0;
        var toOffset = -5;

        // Act
        var result = input.ChangeTimeZones(fromOffset, toOffset)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(4, result.Length);
        Assert.Equal(new DateTime(2023, 3, 25, 5, 0, 0), result[0]);
        Assert.Equal(new DateTime(2023, 3, 27, 5, 0, 0), result[1]);
        Assert.Equal(new DateTime(2023, 10, 28, 5, 0, 0), result[2]);
        Assert.Equal(new DateTime(2023, 10, 30, 5, 0, 0), result[3]);
    }

    #endregion
}
