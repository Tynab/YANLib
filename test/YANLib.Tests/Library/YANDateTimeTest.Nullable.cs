namespace YANLib.Tests.Library;

public partial class YANDateTimeTest
{
    #region ChangeTimeZone

    [Fact]
    public void ChangeTimeZone_NullInput_ReturnsNull_Nullable()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.ChangeTimeZone(0, 1);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ChangeTimeZone_DateTimeObject_ChangesTimeZone_Nullable()
    {
        // Arrange
        object input = new DateTime(2023, 6, 15, 10, 0, 0);
        var expected = new DateTime(2023, 6, 15, 12, 0, 0);

        // Act
        var result = input.ChangeTimeZone(0, 2);

        // Assert
        _ = Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ChangeTimeZone_StringDate_ConvertsAndChangesTimeZone_Nullable()
    {
        // Arrange
        object input = "2023-06-15 10:00:00";
        var expected = new DateTime(2023, 6, 15, 12, 0, 0);

        // Act
        var result = input.ChangeTimeZone(0, 2);

        // Assert
        _ = Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ChangeTimeZone_InvalidObject_ReturnsNull_Nullable()
    {
        // Arrange
        object input = "not a date";

        // Act
        var result = input.ChangeTimeZone(0, 2);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ChangeTimeZone_NegativeOffset_SubtractsHours_Nullable()
    {
        // Arrange
        object input = new DateTime(2023, 6, 15, 10, 0, 0);
        var expected = new DateTime(2023, 6, 15, 7, 0, 0);

        // Act
        var result = input.ChangeTimeZone(0, -3);

        // Assert
        _ = Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ChangeTimeZone_SameTimeZones_ReturnsSameDateTime_Nullable()
    {
        // Arrange
        object input = new DateTime(2023, 6, 15, 10, 0, 0);
        var expected = new DateTime(2023, 6, 15, 10, 0, 0);

        // Act
        var result = input.ChangeTimeZone(2, 2);

        // Assert
        _ = Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ChangeTimeZone_NullTimeZones_UsesDefaultValues_Nullable()
    {
        // Arrange
        object input = new DateTime(2023, 6, 15, 10, 0, 0);
        var expected = new DateTime(2023, 6, 15, 10, 0, 0);

        // Act
        var result = input.ChangeTimeZone();

        // Assert
        _ = Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ChangeTimeZone_StringTimeZones_ConvertsAndApplies_Nullable()
    {
        // Arrange
        object input = new DateTime(2023, 6, 15, 10, 0, 0);
        var expected = new DateTime(2023, 6, 15, 13, 0, 0);

        // Act
        var result = input.ChangeTimeZone("0", "3");

        // Assert
        _ = Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ChangeTimeZone_NearMinValue_HandlesEdgeCase_Nullable()
    {
        // Arrange
        object input = DateTime.MinValue.AddHours(2);

        // Act
        var result = input.ChangeTimeZone(0, -3);

        // Assert
        _ = Assert.NotNull(result);
        Assert.Equal(input, result);
    }

    [Fact]
    public void ChangeTimeZone_NearMaxValue_HandlesEdgeCase_Nullable()
    {
        // Arrange
        object input = DateTime.MaxValue.AddHours(-2);

        // Act
        var result = input.ChangeTimeZone(0, 3);

        // Assert
        _ = Assert.NotNull(result);
        Assert.Equal(input, result);
    }

    #endregion
}
