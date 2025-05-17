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
    public void Parses_TimeSpanInputs_ReturnsTimeSpanValues_NullableCollection()
    {
        // Arrange
        var input = new object?[] { "01:30:45", "02:15:30", "03:45:10" };

        var expected = new TimeSpan?[]
        {
            new TimeSpan(1, 30, 45),
            new TimeSpan(2, 15, 30),
            new TimeSpan(3, 45, 10)
        };

        // Act
        var result = input.Parses<TimeSpan?>()?.ToArray();

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

    [Fact]
    public void Parses_NullLookup_ReturnsEmptyLookup_NullableCollection()
    {
        // Arrange
        ILookup<object?, object?>? input = null;

        // Act
        var result = input.Parses<int, string>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void Parses_EmptyLookup_ReturnsEmptyLookup_NullableCollection()
    {
        // Arrange
        var input = Enumerable.Empty<(object? Key, object? Value)>().ToLookup(static item => item.Key, static item => item.Value);

        // Act
        var result = input.Parses<int, string>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void Parses_BasicLookup_ParsesCorrectly_NullableCollection()
    {
        // Arrange
        var data = new[]
        {
            ("1", "Value1"),
            ("1", "Value2"),
            ("2", "Value3"),
            ("3", "Value4"),
            ("3", "Value5")
        };

        var input = data.ToLookup(static item => (object?)item.Item1, static item => (object?)item.Item2);

        // Act
        var result = input.Parses<int, string>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count);

        var group1 = result[1].ToList();
        Assert.Equal(2, group1.Count);
        Assert.Contains("Value1", group1);
        Assert.Contains("Value2", group1);

        var group2 = result[2].ToList();
        _ = Assert.Single(group2);
        Assert.Equal("Value3", group2[0]);

        var group3 = result[3].ToList();
        Assert.Equal(2, group3.Count);
        Assert.Contains("Value4", group3);
        Assert.Contains("Value5", group3);
    }

    [Fact]
    public void Parses_MixedKeyTypes_ParsesKeysCorrectly_NullableCollection()
    {
        // Arrange
        var data = new (object?, object?)[]
        {
            ("1", "Value1"),
            (1, "Value2"),
            ("2.5", "Value3"),
            (3, "Value4")
        };

        var input = data.ToLookup(static item => item.Item1, static item => item.Item2);

        // Act
        var result = input.Parses<double, string>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count);

        var group1 = result[1].ToList();
        Assert.Equal(2, group1.Count);
        Assert.Contains("Value1", group1);
        Assert.Contains("Value2", group1);

        var group2 = result[2.5].ToList();
        _ = Assert.Single(group2);
        Assert.Equal("Value3", group2[0]);

        var group3 = result[3].ToList();
        _ = Assert.Single(group3);
        Assert.Equal("Value4", group3[0]);
    }

    [Fact]
    public void Parses_MixedValueTypes_ParsesValuesCorrectly_NullableCollection()
    {
        // Arrange
        var data = new (object?, object?)[]
        {
            ("1", "100"),
            ("1", 200),
            ("2", "300.5"),
            ("2", 400)
        };

        var input = data.ToLookup(static item => item.Item1, static item => item.Item2);

        // Act
        var result = input.Parses<int, int>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);

        var group1 = result[1].ToList();
        Assert.Equal(2, group1.Count);
        Assert.Contains(100, group1);
        Assert.Contains(200, group1);

        var group2 = result[2].ToList();
        Assert.Equal(2, group2.Count);
        Assert.Contains(300, group2);
        Assert.Contains(400, group2);
    }

    [Fact]
    public void Parses_NullKeysAndValues_HandlesNullsCorrectly_NullableCollection()
    {
        // Arrange
        var data = new (object?, object?)[]
        {
            (null, "NullKey1"),
            (null, "NullKey2"),
            ("1", null),
            ("2", "NotNull")
        };

        var input = data.ToLookup(static item => item.Item1, static item => item.Item2);

        // Act
        var result = input.Parses<int, string>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count);

        var nullGroup = result[default].ToList();
        Assert.Equal(2, nullGroup.Count);
        Assert.Contains("NullKey1", nullGroup);
        Assert.Contains("NullKey2", nullGroup);

        var group1 = result[1].ToList();
        _ = Assert.Single(group1);
        Assert.Null(group1[0]);

        var group2 = result[2].ToList();
        _ = Assert.Single(group2);
        Assert.Equal("NotNull", group2[0]);
    }

    [Fact]
    public void Parses_InvalidKeyValues_HandlesDefaultValues_NullableCollection()
    {
        // Arrange
        var data = new[]
        {
            ("not a number", "Value1"),
            ("not a number", "Value2"),
            ("2", "Value3")
        };

        var input = data.ToLookup(static item => (object?)item.Item1, static item => (object?)item.Item2);

        // Act
        var result = input.Parses<int, string>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);

        var group0 = result[0].ToList();
        Assert.Equal(2, group0.Count);
        Assert.Contains("Value1", group0);
        Assert.Contains("Value2", group0);

        var group2 = result[2].ToList();
        _ = Assert.Single(group2);
        Assert.Equal("Value3", group2[0]);
    }

    [Fact]
    public void Parses_DateTimeKeys_ParsesKeysCorrectly_NullableCollection()
    {
        // Arrange
        var date1 = new DateTime(2023, 1, 1);
        var date2 = new DateTime(2023, 2, 1);

        var data = new (object?, object?)[]
        {
            ("2023-01-01", "January1"),
            ("2023-01-01", "January2"),
            (date2, "February")
        };

        var input = data.ToLookup(static item => item.Item1, static item => item.Item2);

        // Act
        var result = input.Parses<DateTime, string>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);

        var group1 = result[date1].ToList();
        Assert.Equal(2, group1.Count);
        Assert.Contains("January1", group1);
        Assert.Contains("January2", group1);

        var group2 = result[date2].ToList();
        _ = Assert.Single(group2);
        Assert.Equal("February", group2[0]);
    }

    [Fact]
    public void Parses_EnumValues_ParsesValuesCorrectly_NullableCollection()
    {
        // Arrange
        var data = new (object?, object?)[]
        {
            ("1", "Monday"),
            ("1", DayOfWeek.Monday),
            ("2", "Tuesday"),
            ("2", DayOfWeek.Tuesday)
        };

        var input = data.ToLookup(static item => item.Item1, static item => item.Item2);

        // Act
        var result = input.Parses<int, DayOfWeek>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);

        var group1 = result[1].ToList();
        Assert.Equal(2, group1.Count);
        Assert.All(group1, static item => Assert.Equal(DayOfWeek.Monday, item));

        var group2 = result[2].ToList();
        Assert.Equal(2, group2.Count);
        Assert.All(group2, static item => Assert.Equal(DayOfWeek.Tuesday, item));
    }

    [Fact]
    public void Parses_ComplexTypes_HandlesComplexTypesCorrectly_NullableCollection()
    {
        // Arrange
        var guid1 = Guid.NewGuid();
        var guid2 = Guid.NewGuid();

        var data = new (object?, object?)[]
        {
            ("2023-01-01", guid1.ToString()),
            ("2023-01-01", guid2.ToString()),
            ("2023-02-01", guid1)
        };

        var input = data.ToLookup(static item => item.Item1, static item => item.Item2);

        // Act
        var result = input.Parses<DateTime, Guid>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);

        var group1 = result[new DateTime(2023, 1, 1)].ToList();
        Assert.Equal(2, group1.Count);
        Assert.Contains(guid1, group1);
        Assert.Contains(guid2, group1);

        var group2 = result[new DateTime(2023, 2, 1)].ToList();
        _ = Assert.Single(group2);
        Assert.Equal(guid1, group2[0]);
    }

    [Fact]
    public void Parses_LargeNumberOfGroups_HandlesEfficiently_NullableCollection()
    {
        // Arrange
        var data = Enumerable.Range(1, 100).SelectMany(i => Enumerable.Range(1, 5).Select(j => (i.ToString(), $"Value{i}-{j}")));
        var input = data.ToLookup(item => (object?)item.Item1, item => (object?)item.Item2);

        // Act
        var result = input.Parses<int, string>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(100, result.Count);

        for (var i = 1; i <= 100; i++)
        {
            var group = result[i].ToList();

            Assert.Equal(5, group.Count);

            for (var j = 1; j <= 5; j++)
            {
                Assert.Contains($"Value{i}-{j}", group);
            }
        }
    }

    #endregion
}
