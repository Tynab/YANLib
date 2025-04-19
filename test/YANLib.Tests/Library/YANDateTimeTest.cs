namespace YANLib.Tests.Library;

public partial class YANDateTimeTest
{
    #region ChangeTimeZone
    [Fact]
    public void ChangeTimeZone_ValidDiff_AddsHours()
    {
        // Arrange
        object dt = new DateTime(2024, 1, 1, 0, 0, 0);

        // Act
        var changed = dt.ChangeTimeZone(0, 7);

        // Assert
        Assert.Equal(new DateTime(2024, 1, 1, 7, 0, 0), changed);
    }

    [Fact]
    public void ChangeTimeZone_List_ValidData_UpdatesListInPlace()
    {
        // Arrange
        var list = new List<object?> { new DateTime(2024, 2, 2, 12, 0, 0), new DateTime(2024, 2, 2, 14, 0, 0) };

        // Act
        list.ChangeTimeZone(0, 2);

        // Assert
        Assert.Equal(14, ((DateTime)list[0]!).Hour);
        Assert.Equal(16, ((DateTime)list[1]!).Hour);
    }

    [Fact]
    public void ChangeTimeZones_IEnumerable_ValidData_ReturnsConverted()
    {
        // Arrange
        IEnumerable<object?> list = [new DateTime(2024, 1, 1, 3, 0, 0), new DateTime(2024, 1, 1, 10, 0, 0)];

        // Act
        var result = list.ChangeTimeZones(7, 0);

        // Assert
        Assert.NotNull(result);

        var arr = result.ToArray();

        Assert.Equal(2, arr.Length);
        Assert.Equal(20, arr[0].Hour);
        Assert.Equal(3, arr[1].Hour);
    }

    [Fact]
    public void ChangeTimeZones_Params_ValidData_ReturnsConverted()
    {
        // Arrange
        var list = new object?[] { new DateTime(2024, 1, 1, 0, 0, 0), new DateTime(2024, 1, 1, 5, 0, 0) };

        // Act
        var result = YANDateTime.ChangeTimeZones(list, 0, 7);

        // Assert
        Assert.NotNull(result);

        var arr = result.ToArray();

        Assert.Equal(2, arr.Length);
        Assert.Equal(7, arr[0].Hour);
        Assert.Equal(12, arr[1].Hour);
    }
    #endregion
}
