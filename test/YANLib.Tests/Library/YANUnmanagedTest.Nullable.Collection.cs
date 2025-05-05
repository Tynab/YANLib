using System.Collections;

namespace YANLib.Tests.Library;

public partial class YANUnmanagedTest
{
    #region Parses

    [Fact]
    public void Parses_NullEnumerable_ReturnsNull_NullableCollection()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Parses<int?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Parses_EmptyEnumerable_ReturnsNull_NullableCollection()
    {
        // Arrange
        var input = Array.Empty<object?>();

        // Act
        var result = input.Parses<int?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Parses_ValidIntInputs_ReturnsIntValues_NullableCollection()
    {
        // Arrange
        var input = new object?[] { "123", "456", "789" };
        var expected = new int?[] { 123, 456, 789 };

        // Act
        var result = input.Parses<int?>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Parses_MixedValidAndInvalidInputs_ReturnsNullForInvalid_NullableCollection()
    {
        // Arrange
        var input = new object?[] { "123", "not a number", "789" };
        var expected = new int?[] { 123, null, 789 };

        // Act
        var result = input.Parses<int?>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Parses_NullValues_ReturnsNullValues_NullableCollection()
    {
        // Arrange
        var input = new object?[] { "123", null, "789" };
        var expected = new int?[] { 123, null, 789 };

        // Act
        var result = input.Parses<int?>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Parses_DateTimeInputs_ReturnsDateTimeValues_NullableCollection()
    {
        // Arrange
        var input = new object?[] { "2023-06-15", "2023-07-20", "2023-12-25" };
        var expected = new DateTime?[] { new DateTime(2023, 6, 15), new DateTime(2023, 7, 20), new DateTime(2023, 12, 25) };

        // Act
        var result = input.Parses<DateTime?>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Parses_EnumInputs_ReturnsEnumValues_NullableCollection()
    {
        // Arrange
        var input = new object?[] { "Monday", "Tuesday", "Wednesday" };
        var expected = new DayOfWeek?[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday };

        // Act
        var result = input.Parses<DayOfWeek?>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Parses_ParamsOverload_ReturnsValues_NullableCollection()
    {
        // Act
        var result = YANUnmanaged.Parses<int?>("123", "456", "789")?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal([123, 456, 789], result);
    }

    [Fact]
    public void Parses_IEnumerableOverload_ReturnsValues_NullableCollection()
    {
        // Arrange
        ArrayList input = ["123", "456", "789"];
        var expected = new int?[] { 123, 456, 789 };

        // Act
        var result = input.Parses<int?>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Parses_NullIEnumerable_ReturnsNull_NullableCollection()
    {
        // Arrange
        ArrayList? input = null;

        // Act
        var result = input.Parses<int?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Parses_BoolInputs_ReturnsBoolValues_NullableCollection()
    {
        // Arrange
        var input = new object?[] { "true", "false", "true" };
        var expected = new bool?[] { true, false, true };

        // Act
        var result = input.Parses<bool?>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Parses_GuidInputs_ReturnsGuidValues_NullableCollection()
    {
        // Arrange
        var guid1 = Guid.NewGuid();
        var guid2 = Guid.NewGuid();
        var input = new object?[] { guid1.ToString(), guid2.ToString() };
        var expected = new Guid?[] { guid1, guid2 };

        // Act
        var result = input.Parses<Guid?>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Parses_MixedTypes_HandlesEachAppropriately_NullableCollection()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var input = new object?[]
        {
            "123",
            "true",
            "2023-06-15",
            "Monday",
            guid.ToString(),
            "not valid",
            null
        };

        // Act
        var intResults = input.Parses<int?>()?.ToArray();
        var boolResults = input.Parses<bool?>()?.ToArray();
        var dateResults = input.Parses<DateTime?>()?.ToArray();
        var enumResults = input.Parses<DayOfWeek?>()?.ToArray();
        var guidResults = input.Parses<Guid?>()?.ToArray();

        // Assert
        Assert.NotNull(intResults);
        Assert.Equal([123, null, null, null, null, null, null], intResults);

        Assert.NotNull(boolResults);
        Assert.Equal([null, true, null, null, null, null, null], boolResults);

        Assert.NotNull(dateResults);
        Assert.Equal([null, null, new DateTime(2023, 6, 15), null, null, null, null], dateResults);

        Assert.NotNull(enumResults);
        Assert.Equal([(DayOfWeek)123, null, null, DayOfWeek.Monday, null, null, null], enumResults);

        Assert.NotNull(guidResults);
        Assert.Equal([null, null, null, null, guid, null, null], guidResults);
    }

    [Fact]
    public void Parses_DateTimeWithFormat_UsesFormat_NullableCollection()
    {
        // Arrange
        var input = new object?[] { "15/06/2023", "20/07/2023", "25/12/2023" };

        // Act
        var result = input.Parses<DateTime?>()?.ToArray();

        // Assert
        Assert.NotNull(result);

        Assert.All(result, item => Assert.Null(item));
    }

    [Fact]
    public void Parses_InvalidDateTimeFormat_ReturnsNullValues_NullableCollection()
    {
        // Arrange
        var input = new object?[] { "2023/13/45", "invalid date", "2023-02-30" };
        var expected = new DateTime?[] { null, null, null };

        // Act
        var result = input.Parses<DateTime?>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Parses_IEnumerableWithInvalidValues_ReturnsNullsForInvalid_NullableCollection()
    {
        // Arrange
        ArrayList input = ["123", "not a number", "789"];
        var expected = new int?[] { 123, null, 789 };

        // Act
        var result = input.Parses<int?>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    #endregion
}
