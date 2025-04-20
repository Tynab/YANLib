using YANLib.Unmanaged;

namespace YANLib.Tests.Library.Unmanaged;

public partial class YANDateTimeTest
{
    #region ChangeTimeZone
    [Fact]
    public void ChangeTimeZone_Nullable_NullInput_ReturnsNull()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.ChangeTimeZone();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ChangeTimeZone_Nullable_ValidDate_NoTimeZoneSpecified_ReturnsSameDateTime()
    {
        // Arrange
        object input = new DateTime(2023, 6, 15, 12, 0, 0);

        // Act
        var result = input.ChangeTimeZone();

        // Assert
        Assert.Equal(input, result);
    }

    [Fact]
    public void ChangeTimeZone_Nullable_ValidDate_SameTimeZones_ReturnsSameDateTime()
    {
        // Arrange
        object input = new DateTime(2023, 6, 15, 12, 0, 0);
        var tzSrc = 7;
        var tzDst = 7;

        // Act
        var result = input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal(input, result);
    }

    [Fact]
    public void ChangeTimeZone_Nullable_ValidDate_PositiveTimeZoneDifference_AddsHours()
    {
        // Arrange
        var date = new DateTime(2023, 6, 15, 12, 0, 0);
        object input = date;
        var tzSrc = 0;
        var tzDst = 7;

        // Act
        var result = input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal(date.AddHours(7), result);
    }

    [Fact]
    public void ChangeTimeZone_Nullable_ValidDate_NegativeTimeZoneDifference_SubtractsHours()
    {
        // Arrange
        var date = new DateTime(2023, 6, 15, 12, 0, 0);
        object input = date;
        var tzSrc = 7;
        var tzDst = 0;

        // Act
        var result = input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal(date.AddHours(-7), result);
    }

    [Fact]
    public void ChangeTimeZone_Nullable_StringDate_ParsesAndConvertsCorrectly()
    {
        // Arrange
        object input = "2023-06-15 12:00:00";
        var tzSrc = 0;
        var tzDst = 7;

        // Act
        var result = input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal(DateTime.Parse((string)input).AddHours(7), result);
    }

    [Fact]
    public void ChangeTimeZone_Nullable_InvalidString_ReturnsNull()
    {
        // Arrange
        object input = "not a date";
        var tzSrc = 0;
        var tzDst = 7;

        // Act
        var result = input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ChangeTimeZone_Nullable_StringTimeZones_ParsesAndConvertsCorrectly()
    {
        // Arrange
        var date = new DateTime(2023, 6, 15, 12, 0, 0);
        object input = date;
        var tzSrc = "0";
        var tzDst = "7";

        // Act
        var result = input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal(date.AddHours(7), result);
    }

    [Fact]
    public void ChangeTimeZone_Nullable_NegativeResultExceedsMinValue_ReturnsSameDateTime()
    {
        // Arrange
        var date = DateTime.MinValue.AddHours(5);
        object input = date;
        var tzSrc = 0;
        var tzDst = -7;

        // Act
        var result = input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal(date, result);
    }

    [Fact]
    public void ChangeTimeZone_Nullable_PositiveResultExceedsMaxValue_ReturnsSameDateTime()
    {
        // Arrange
        var date = DateTime.MaxValue.AddHours(-5);
        object input = date;
        var tzSrc = 0;
        var tzDst = 7;

        // Act
        var result = input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal(date, result);
    }

    [Fact]
    public void ChangeTimeZone_List_Nullable_NullInput_DoesNotThrow()
    {
        // Arrange
        List<object?>? input = null;

        // Act
        var exception = Record.Exception(() => input.ChangeTimeZone());

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void ChangeTimeZone_List_Nullable_EmptyInput_DoesNotThrow()
    {
        // Arrange
        var input = new List<object?>();

        // Act
        var exception = Record.Exception(() => input.ChangeTimeZone());

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void ChangeTimeZone_List_Nullable_ValidInput_UpdatesAllItems()
    {
        // Arrange
        var date1 = new DateTime(2023, 6, 15, 12, 0, 0);
        var date2 = new DateTime(2023, 6, 16, 12, 0, 0);
        var input = new List<object?> { date1, date2 };
        var tzSrc = 0;
        var tzDst = 7;
        var expected1 = date1.AddHours(7);
        var expected2 = date2.AddHours(7);

        // Act
        input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal(expected1, input[0]);
        Assert.Equal(expected2, input[1]);
    }

    [Fact]
    public void ChangeTimeZone_List_Nullable_MixedValidAndNullItems_UpdatesOnlyValidItems()
    {
        // Arrange
        var date = new DateTime(2023, 6, 15, 12, 0, 0);
        var input = new List<object?> { date, null, "not a date" };
        var tzSrc = 0;
        var tzDst = 7;
        var expected = date.AddHours(7);

        // Act
        input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal(expected, input[0]);
        Assert.Null(input[1]);
    }

    [Fact]
    public void ChangeTimeZone_List_Nullable_StringDates_ParsesAndConvertsCorrectly()
    {
        // Arrange
        var dateStr1 = "2023-06-15 12:00:00";
        var dateStr2 = "2023-06-16 12:00:00";
        var input = new List<object?> { dateStr1, dateStr2 };
        var tzSrc = 0;
        var tzDst = 7;
        var expected1 = DateTime.Parse(dateStr1).AddHours(7);
        var expected2 = DateTime.Parse(dateStr2).AddHours(7);

        // Act
        input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal(expected1, input[0]);
        Assert.Equal(expected2, input[1]);
    }
    #endregion

    #region ChangeTimeZones
    [Fact]
    public void ChangeTimeZones_Nullable_NullInput_ReturnsNull()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.ChangeTimeZones();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ChangeTimeZones_Nullable_EmptyInput_ReturnsNull()
    {
        // Arrange
        IEnumerable<object?> input = [];

        // Act
        var result = input.ChangeTimeZones();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ChangeTimeZones_Nullable_ValidInput_ReturnsConvertedDates()
    {
        // Arrange
        var date1 = new DateTime(2023, 6, 15, 12, 0, 0);
        var date2 = new DateTime(2023, 6, 16, 12, 0, 0);
        var input = new List<object?> { date1, date2 };
        var tzSrc = 0;
        var tzDst = 7;
        var expected = new DateTime?[]
        {
            date1.AddHours(7),
            date2.AddHours(7)
        };

        // Act
        var result = input.ChangeTimeZones(tzSrc, tzDst);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ChangeTimeZones_Nullable_MixedValidAndInvalidItems_ReturnsOnlyValidItems()
    {
        // Arrange
        var date = new DateTime(2023, 6, 15, 12, 0, 0);
        var input = new List<object?> { date, null, "not a date" };
        var tzSrc = 0;
        var tzDst = 7;
        var expected = new DateTime?[] { date.AddHours(7), null, null };

        // Act
        var result = input.ChangeTimeZones(tzSrc, tzDst);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ChangeTimeZones_Nullable_StringDates_ParsesAndConvertsCorrectly()
    {
        // Arrange
        var dateStr1 = "2023-06-15 12:00:00";
        var dateStr2 = "2023-06-16 12:00:00";
        var input = new List<object?> { dateStr1, dateStr2 };
        var tzSrc = 0;
        var tzDst = 7;
        var expected = new DateTime?[]
        {
            DateTime.Parse(dateStr1).AddHours(7),
            DateTime.Parse(dateStr2).AddHours(7)
        };

        // Act
        var result = input.ChangeTimeZones(tzSrc, tzDst);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ChangeTimeZones_Nullable_LargeCollection_ProcessesAllItems()
    {
        // Arrange
        var baseDate = new DateTime(2023, 1, 1);
        var input = Enumerable.Range(0, 1001).Select(i => (object?)baseDate.AddDays(i)).ToList();
        var tzSrc = 0;
        var tzDst = 7;

        // Act
        var result = input.ChangeTimeZones(tzSrc, tzDst);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1001, result.Count());
        Assert.All(result, date => Assert.Equal(7, date?.Hour));
    }
    #endregion
}
