using System.Collections;

namespace YANLib.Tests.Library;

public partial class YANUnmanagedTest
{
    #region Parses

    [Fact]
    public void Parses_NullEnumerable_ReturnsNull_Collection()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Parses<int>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Parses_EmptyEnumerable_ReturnsNull_Collection()
    {
        // Arrange
        var input = Array.Empty<object?>();

        // Act
        var result = input.Parses<int>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Parses_ValidIntInputs_ReturnsIntValues_Collection()
    {
        // Arrange
        var input = new object?[] { "123", "456", "789" };
        var expected = new int[] { 123, 456, 789 };

        // Act
        var result = input.Parses<int>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Parses_MixedValidAndInvalidInputs_UsesDefaultValue_Collection()
    {
        // Arrange
        var input = new object?[] { "123", "not a number", "789" };
        var expected = new int[] { 123, 42, 789 };
        var defaultValue = 42;

        // Act
        var result = input.Parses<int>(defaultValue)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Parses_NullValues_UsesDefaultValue_Collection()
    {
        // Arrange
        var input = new object?[] { "123", null, "789" };
        var expected = new int[] { 123, 42, 789 };
        var defaultValue = 42;

        // Act
        var result = input.Parses<int>(defaultValue)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Parses_DateTimeWithFormat_UsesFormat_Collection()
    {
        // Arrange
        var input = new object?[] { "15/06/2023", "20/07/2023", "25/12/2023" };

        var expected = new DateTime[]
        {
            new(2023, 6, 15),
            new(2023, 7, 20),
            new(2023, 12, 25)
        };

        string[] format = ["dd/MM/yyyy"];

        // Act
        var result = input.Parses<DateTime>(null, format)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Parses_EnumInputs_ReturnsEnumValues_Collection()
    {
        // Arrange
        var input = new object?[] { "Monday", "Tuesday", "Wednesday" };
        var expected = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday };

        // Act
        var result = input.Parses<DayOfWeek>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Parses_IEnumerableOverload_ReturnsValues_Collection()
    {
        // Arrange
        ArrayList input = ["123", "456", "789"];
        var expected = new int[] { 123, 456, 789 };

        // Act
        var result = input.Parses<int>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Parses_NullIEnumerable_ReturnsNull_Collection()
    {
        // Arrange
        ArrayList? input = null;

        // Act
        var result = input.Parses<int>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Parses_ParamsFormatOverload_UsesFormat_Collection()
    {
        // Arrange
        var input = new object?[] { "15/06/2023", "20/07/2023" };

        var expected = new DateTime[]
        {
            new(2023, 6, 15),
            new(2023, 7, 20)
        };

        // Act
        var result = input.Parses<DateTime>(null, "dd/MM/yyyy")?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Parses_IEnumerableWithParamsFormat_UsesFormat_Collection()
    {
        // Arrange
        ArrayList input = ["15/06/2023", "20/07/2023"];

        var expected = new DateTime[]
        {
            new(2023, 6, 15),
            new(2023, 7, 20)
        };

        // Act
        var result = input.Parses<DateTime>(null, "dd/MM/yyyy")?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Parses_BoolInputs_ReturnsBoolValues_Collection()
    {
        // Arrange
        var input = new object?[] { "true", "false", "true" };
        var expected = new bool[] { true, false, true };

        // Act
        var result = input.Parses<bool>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Parses_GuidInputs_ReturnsGuidValues_Collection()
    {
        // Arrange
        var guid1 = Guid.NewGuid();
        var guid2 = Guid.NewGuid();
        var input = new object?[] { guid1.ToString(), guid2.ToString() };
        var expected = new Guid[] { guid1, guid2 };

        // Act
        var result = input.Parses<Guid>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Parses_ParamsOverload_ReturnsValues_Collection()
    {
        // Act
        var result = YANUnmanaged.Parses<int?>("123", "456", "789").Parses<int>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal([123, 456, 789], result);
    }

    [Fact]
    public void Parses_MixedTypes_HandlesEachAppropriately_Collection()
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

        var defaultValue = 42;

        // Act
        var intResults = input.Parses<int>(defaultValue)?.ToArray();
        var boolResults = input.Parses<bool>(false)?.ToArray();
        var dateResults = input.Parses<DateTime>(new DateTime(2000, 1, 1))?.ToArray();
        var enumResults = input.Parses<DayOfWeek>(DayOfWeek.Friday)?.ToArray();
        var guidResults = input.Parses<Guid>(Guid.Empty)?.ToArray();

        // Assert
        Assert.NotNull(intResults);
        Assert.Equal([123, 42, 42, 42, 42, 42, 42], intResults);

        Assert.NotNull(boolResults);
        Assert.Equal([false, true, false, false, false, false, false], boolResults);

        Assert.NotNull(dateResults);
        var defaultDate = new DateTime(2000, 1, 1);
        Assert.Equal([defaultDate, defaultDate, new DateTime(2023, 6, 15), defaultDate, defaultDate, defaultDate, defaultDate], dateResults);

        Assert.NotNull(enumResults);
        Assert.Equal([(DayOfWeek)123, DayOfWeek.Friday, DayOfWeek.Friday, DayOfWeek.Monday, DayOfWeek.Friday, DayOfWeek.Friday, DayOfWeek.Friday], enumResults);

        Assert.NotNull(guidResults);
        Assert.Equal([Guid.Empty, Guid.Empty, Guid.Empty, Guid.Empty, guid, Guid.Empty, Guid.Empty], guidResults);
    }

    #endregion
}
