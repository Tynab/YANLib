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
        var result = input.ChangeTimeZone(0, 5);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ChangeTimeZone_Nullable_DateTimeInput_ChangesTimeZone()
    {
        // Arrange
        object input = new DateTime(2023, 7, 15, 12, 0, 0);
        var tzSrc = 0;
        var tzDst = 5;

        // Act
        var result = input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal(new DateTime(2023, 7, 15, 17, 0, 0), result);
    }

    [Fact]
    public void ChangeTimeZone_Nullable_StringDateInput_ChangesTimeZone()
    {
        // Arrange
        object input = "2023-07-15 12:00:00";
        var tzSrc = 0;
        var tzDst = 5;

        // Act
        var result = input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal(new DateTime(2023, 7, 15, 17, 0, 0), result);
    }

    [Fact]
    public void ChangeTimeZone_Nullable_InvalidStringInput_ReturnsNull()
    {
        // Arrange
        object input = "not a date";
        var tzSrc = 0;
        var tzDst = 5;

        // Act
        var result = input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ChangeTimeZone_Nullable_IntInput_ReturnsNull()
    {
        // Arrange
        object input = 12345;
        var tzSrc = 0;
        var tzDst = 5;

        // Act
        var result = input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ChangeTimeZone_Nullable_SameTimeZone_ReturnsSameDateTime()
    {
        // Arrange
        object input = new DateTime(2023, 7, 15, 12, 0, 0);
        var tzSrc = 0;
        var tzDst = 0;

        // Act
        var result = input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal(new DateTime(2023, 7, 15, 12, 0, 0), result);
    }

    [Fact]
    public void ChangeTimeZone_Nullable_PositiveOffset_AddsHours()
    {
        // Arrange
        object input = new DateTime(2023, 7, 15, 12, 0, 0);
        var tzSrc = 0;
        var tzDst = 5;

        // Act
        var result = input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal(new DateTime(2023, 7, 15, 17, 0, 0), result);
    }

    [Fact]
    public void ChangeTimeZone_Nullable_NegativeOffset_SubtractsHours()
    {
        // Arrange
        object input = new DateTime(2023, 7, 15, 12, 0, 0);
        var tzSrc = 0;
        var tzDst = -5;

        // Act
        var result = input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal(new DateTime(2023, 7, 15, 7, 0, 0), result);
    }

    [Fact]
    public void ChangeTimeZone_Nullable_StringTimeZones_ChangesTime()
    {
        // Arrange
        object input = new DateTime(2023, 7, 15, 12, 0, 0);
        var tzSrc = "0";
        var tzDst = "5";

        // Act
        var result = input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal(new DateTime(2023, 7, 15, 17, 0, 0), result);
    }

    [Fact]
    public void ChangeTimeZone_Nullable_NearMinValue_HandlesUnderflow()
    {
        // Arrange
        object input = DateTime.MinValue.AddHours(2);
        var tzSrc = 0;
        var tzDst = -3;

        // Act
        var result = input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal(DateTime.MinValue.AddHours(2), result);
    }

    [Fact]
    public void ChangeTimeZone_Nullable_NearMaxValue_HandlesOverflow()
    {
        // Arrange
        object input = DateTime.MaxValue.AddHours(-2);
        var tzSrc = 0;
        var tzDst = 3;

        // Act
        var result = input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal(DateTime.MaxValue.AddHours(-2), result);
    }

    [Fact]
    public void ChangeTimeZone_Nullable_NullTimeZones_UsesDefaultValues()
    {
        // Arrange
        object input = new DateTime(2023, 7, 15, 12, 0, 0);

        // Act
        var result = input.ChangeTimeZone();

        // Assert
        Assert.Equal(new DateTime(2023, 7, 15, 12, 0, 0), result);
    }

    #endregion

    #region ChangeTimeZone List

    [Fact]
    public void ChangeTimeZone_Nullable_NullList_DoesNotThrow()
    {
        // Arrange
        List<object?>? input = null;

        // Act
        var exception = Record.Exception(() => input.ChangeTimeZone(0, 5));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void ChangeTimeZone_Nullable_EmptyList_DoesNotThrow()
    {
        // Arrange
        var input = new List<object?>();

        // Act
        var exception = Record.Exception(() => input.ChangeTimeZone(0, 5));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void ChangeTimeZone_Nullable_ObjectList_ChangesAllTimes()
    {
        // Arrange
        var input = new List<object?>
        {
            new DateTime(2023, 7, 15, 12, 0, 0),
            "2023-07-16 12:00:00",
            new DateTime(2023, 7, 17, 12, 0, 0)
        };

        var tzSrc = 0;
        var tzDst = 5;

        // Act
        input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal([new DateTime(2023, 7, 15, 17, 0, 0), new DateTime(2023, 7, 16, 17, 0, 0), new DateTime(2023, 7, 17, 17, 0, 0)], input);
    }

    [Fact]
    public void ChangeTimeZone_Nullable_MixedObjectList_ChangesValidTimes()
    {
        // Arrange
        var input = new List<object?>
        {
            new DateTime(2023, 7, 15, 12, 0, 0),
            "not a date",
            new DateTime(2023, 7, 17, 12, 0, 0)
        };

        var tzSrc = 0;
        var tzDst = 5;

        // Act
        input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal(new DateTime(2023, 7, 15, 17, 0, 0), input[0]);
        Assert.Null(input[1]);
        Assert.Equal(new DateTime(2023, 7, 17, 17, 0, 0), input[2]);
    }

    [Fact]
    public void ChangeTimeZone_Nullable_ListWithNulls_HandlesNulls()
    {
        // Arrange
        var input = new List<object?>
        {
            new DateTime(2023, 7, 15, 12, 0, 0),
            null,
            new DateTime(2023, 7, 17, 12, 0, 0)
        };

        var tzSrc = 0;
        var tzDst = 5;

        // Act
        input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal(new DateTime(2023, 7, 15, 17, 0, 0), input[0]);
        Assert.Null(input[1]);
        Assert.Equal(new DateTime(2023, 7, 17, 17, 0, 0), input[2]);
    }

    #endregion

    #region ChangeTimeZones

    [Fact]
    public void ChangeTimeZones_Nullable_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.ChangeTimeZones(0, 5);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ChangeTimeZones_Nullable_EmptyCollection_ReturnsNull()
    {
        // Arrange
        var input = Array.Empty<object?>();

        // Act
        var result = input.ChangeTimeZones(0, 5);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ChangeTimeZones_Nullable_ObjectCollection_ChangesAllTimes()
    {
        // Arrange
        var input = new object?[]
        {
            new DateTime(2023, 7, 15, 12, 0, 0),
            "2023-07-16 12:00:00",
            new DateTime(2023, 7, 17, 12, 0, 0)
        };

        var tzSrc = 0;
        var tzDst = 5;

        // Act
        var result = input.ChangeTimeZones(tzSrc, tzDst);

        // Assert
        Assert.Equal([new(2023, 7, 15, 17, 0, 0), new(2023, 7, 16, 17, 0, 0), new(2023, 7, 17, 17, 0, 0)], result);
    }

    [Fact]
    public void ChangeTimeZones_Nullable_MixedObjectCollection_ChangesValidTimes()
    {
        // Arrange
        var input = new object?[]
        {
            new DateTime(2023, 7, 15, 12, 0, 0),
            "not a date",
            new DateTime(2023, 7, 17, 12, 0, 0)
        };

        var tzSrc = 0;
        var tzDst = 5;

        // Act
        var result = input.ChangeTimeZones(tzSrc, tzDst)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Length);
        Assert.Equal(new DateTime(2023, 7, 15, 17, 0, 0), result[0]);
        Assert.Null(result[1]);
        Assert.Equal(new DateTime(2023, 7, 17, 17, 0, 0), result[2]);
    }

    [Fact]
    public void ChangeTimeZones_Nullable_CollectionWithNulls_HandlesNulls()
    {
        // Arrange
        var input = new object?[]
        {
            new DateTime(2023, 7, 15, 12, 0, 0),
            null,
            new DateTime(2023, 7, 17, 12, 0, 0)
        };

        var tzSrc = 0;
        var tzDst = 5;

        // Act
        var result = input.ChangeTimeZones(tzSrc, tzDst)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Length);
        Assert.Equal(new DateTime(2023, 7, 15, 17, 0, 0), result[0]);
        Assert.Null(result[1]);
        Assert.Equal(new DateTime(2023, 7, 17, 17, 0, 0), result[2]);
    }

    [Fact]
    public void ChangeTimeZones_Nullable_StringTimeZones_ChangesAllTimes()
    {
        // Arrange
        var input = new object?[]
        {
            new DateTime(2023, 7, 15, 12, 0, 0),
            "2023-07-16 12:00:00",
            new DateTime(2023, 7, 17, 12, 0, 0)
        };

        var tzSrc = "0";
        var tzDst = "5";

        // Act
        var result = input.ChangeTimeZones(tzSrc, tzDst);

        // Assert
        Assert.Equal([new(2023, 7, 15, 17, 0, 0), new(2023, 7, 16, 17, 0, 0), new(2023, 7, 17, 17, 0, 0)], result);
    }

    #endregion

    #region Edge Cases

    [Fact]
    public void ChangeTimeZone_Nullable_ExactlyMinValue_ReturnsMinValue()
    {
        // Arrange
        object input = DateTime.MinValue;
        var tzSrc = 0;
        var tzDst = -5;

        // Act
        var result = input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal(DateTime.MinValue, result);
    }

    [Fact]
    public void ChangeTimeZone_Nullable_ExactlyMaxValue_ReturnsMaxValue()
    {
        // Arrange
        object input = DateTime.MaxValue;
        var tzSrc = 0;
        var tzDst = 5;

        // Act
        var result = input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal(DateTime.MaxValue, result);
    }

    [Fact]
    public void ChangeTimeZone_Nullable_DBNull_ReturnsNull()
    {
        // Arrange
        object input = DBNull.Value;
        var tzSrc = 0;
        var tzDst = 5;

        // Act
        var result = input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ChangeTimeZone_Nullable_EmptyString_ReturnsNull()
    {
        // Arrange
        object input = "";
        var tzSrc = 0;
        var tzDst = 5;

        // Act
        var result = input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ChangeTimeZone_Nullable_WhitespaceString_ReturnsNull()
    {
        // Arrange
        object input = "   ";
        var tzSrc = 0;
        var tzDst = 5;

        // Act
        var result = input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ChangeTimeZones_Nullable_AllInvalidInputs_ReturnsAllNulls()
    {
        // Arrange
        var input = new object?[]
        {
            "not a date",
            null,
            "also not a date"
        };

        var tzSrc = 0;
        var tzDst = 5;

        // Act
        var result = input.ChangeTimeZones(tzSrc, tzDst)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Length);
        Assert.Null(result[0]);
        Assert.Null(result[1]);
        Assert.Null(result[2]);
    }

    [Fact]
    public void ChangeTimeZone_Nullable_InvalidTimeZones_UsesDefaultValues()
    {
        // Arrange
        object input = new DateTime(2023, 7, 15, 12, 0, 0);
        object tzSrc = "not a number";
        object tzDst = "also not a number";

        // Act
        var result = input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal(new DateTime(2023, 7, 15, 12, 0, 0), result);
    }

    #endregion

    #region Special Types

    [Fact]
    public void ChangeTimeZone_Nullable_DateTimeOffset_ExtractsDateTime()
    {
        // Arrange
        object input = new DateTimeOffset(2023, 7, 15, 12, 0, 0, TimeSpan.Zero);
        var tzSrc = 0;
        var tzDst = 5;

        // Act
        var result = input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal(new DateTime(2023, 7, 16, 0, 0, 0), result);
    }

    [Fact]
    public void ChangeTimeZone_Nullable_DateTimeOffsetString_ChangesTimeZone()
    {
        // Arrange
        object input = "2023-07-15T12:00:00+00:00";
        var tzSrc = 0;
        var tzDst = 5;

        // Act
        var result = input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal(new DateTime(2023, 7, 16, 0, 0, 0), result);
    }

    [Fact]
    public void ChangeTimeZone_Nullable_CustomFormattedDateString_ChangesTimeZone()
    {
        // Arrange
        object input = "2023/07/15 12:00:00";
        var tzSrc = 0;
        var tzDst = 5;

        // Act
        var result = input.ChangeTimeZone(tzSrc, tzDst);

        // Assert
        Assert.Equal(new DateTime(2023, 7, 15, 17, 0, 0), result);
    }

    #endregion
}
