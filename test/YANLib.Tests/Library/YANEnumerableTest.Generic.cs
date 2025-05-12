namespace YANLib.Tests.Library;

public partial class YANEnumerableTest
{
    #region ToArray

    [Fact]
    public void ToArray_NullInput_ReturnsEmptyArray_Enumerable()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.ToArray<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void ToArray_EmptyInput_ReturnsEmptyArray_Enumerable()
    {
        // Arrange
        IEnumerable<object?> input = [];

        // Act
        var result = input.ToArray<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void ToArray_ValidInput_ReturnsTypedArray_Enumerable()
    {
        // Arrange
        IEnumerable<object?> input = ["1", "2", "3"];

        // Act
        var result = input.ToArray<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Length);
        Assert.Equal(1, result[0]);
        Assert.Equal(2, result[1]);
        Assert.Equal(3, result[2]);
    }

    [Fact]
    public void ToArray_MixedTypes_ParsesCorrectly_Enumerable()
    {
        // Arrange
        IEnumerable<object?> input = ["1", 2, "3.5"];

        // Act
        var result = input.ToArray<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Length);
        Assert.Equal(1, result[0]);
        Assert.Equal(2, result[1]);
        Assert.Equal(3, result[2]);
    }

    [Fact]
    public void ToArray_DuplicateValues_RemovesDuplicates_Enumerable()
    {
        // Arrange
        IEnumerable<object?> input = ["1", "1", 1, "2"];

        // Act
        var result = input.ToArray<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(4, result.Length);
        Assert.Equal(1, result[0]);
        Assert.Equal(1, result[1]);
        Assert.Equal(1, result[2]);
        Assert.Equal(2, result[3]);
    }

    [Fact]
    public void ToArray_NullValues_HandlesNullsCorrectly_Enumerable()
    {
        // Arrange
        IEnumerable<object?> input = ["1", null, "3"];

        // Act
        var result = input.ToArray<string>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Length);
        Assert.Equal("1", result[0]);
        Assert.Null(result[1]);
        Assert.Equal("3", result[2]);
    }

    [Fact]
    public void ToArray_ParamsOverload_ReturnsTypedArray_Enumerable()
    {
        // Act
        var result = YANEnumerable.ToArray<int>("1", 2, "3.5");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Length);
        Assert.Equal(1, result[0]);
        Assert.Equal(2, result[1]);
        Assert.Equal(3, result[2]);
    }

    [Fact]
    public void ToArray_NullParamsArray_ReturnsEmptyArray_Enumerable()
    {
        // Act
        var result = YANEnumerable.ToArray<int>(null);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void ToArray_EmptyParamsArray_ReturnsEmptyArray_Enumerable()
    {
        // Act
        var result = YANEnumerable.ToArray<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void ToArray_NonGenericCollection_ReturnsTypedArray_Enumerable()
    {
        // Arrange
        System.Collections.ArrayList input = ["1", 2, "3.5"];

        // Act
        var result = input.ToArray<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Length);
        Assert.Equal(1, result[0]);
        Assert.Equal(2, result[1]);
        Assert.Equal(3, result[2]);
    }

    [Fact]
    public void ToArray_NullNonGenericCollection_ReturnsEmptyArray_Enumerable()
    {
        // Arrange
        System.Collections.IEnumerable? input = null;

        // Act
        var result = input.ToArray<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    #endregion

    #region ToList

    [Fact]
    public void ToList_NullInput_ReturnsEmptyList_Enumerable()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.ToList<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void ToList_EmptyInput_ReturnsEmptyList_Enumerable()
    {
        // Arrange
        IEnumerable<object?> input = [];

        // Act
        var result = input.ToList<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void ToList_ValidInput_ReturnsTypedList_Enumerable()
    {
        // Arrange
        IEnumerable<object?> input = ["1", "2", "3"];

        // Act
        var result = input.ToList<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count);
        Assert.Equal(1, result[0]);
        Assert.Equal(2, result[1]);
        Assert.Equal(3, result[2]);
    }

    [Fact]
    public void ToList_MixedTypes_ParsesCorrectly_Enumerable()
    {
        // Arrange
        IEnumerable<object?> input = ["1", 2, "3.5"];

        // Act
        var result = input.ToList<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count);
        Assert.Equal(1, result[0]);
        Assert.Equal(2, result[1]);
        Assert.Equal(3, result[2]);
    }

    [Fact]
    public void ToList_DuplicateValues_RemovesDuplicates_Enumerable()
    {
        // Arrange
        IEnumerable<object?> input = ["1", "1", 1, "2"];

        // Act
        var result = input.ToList<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(4, result.Count);
        Assert.Equal(1, result[0]);
        Assert.Equal(1, result[1]);
        Assert.Equal(1, result[2]);
        Assert.Equal(2, result[3]);
    }

    [Fact]
    public void ToList_NullValues_HandlesNullsCorrectly_Enumerable()
    {
        // Arrange
        IEnumerable<object?> input = ["1", null, "3"];

        // Act
        var result = input.ToList<string>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count);
        Assert.Equal("1", result[0]);
        Assert.Null(result[1]);
        Assert.Equal("3", result[2]);
    }

    [Fact]
    public void ToList_ParamsOverload_ReturnsTypedList_Enumerable()
    {
        // Act
        var result = YANEnumerable.ToList<int>("1", 2, "3.5");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count);
        Assert.Equal(1, result[0]);
        Assert.Equal(2, result[1]);
        Assert.Equal(3, result[2]);
    }

    [Fact]
    public void ToList_NullParamsArray_ReturnsEmptyList_Enumerable()
    {
        // Act
        var result = YANEnumerable.ToList<int>(null);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void ToList_EmptyParamsArray_ReturnsEmptyList_Enumerable()
    {
        // Act
        var result = YANEnumerable.ToList<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void ToList_NonGenericCollection_ReturnsTypedList_Enumerable()
    {
        // Arrange
        System.Collections.ArrayList input = ["1", 2, "3.5"];

        // Act
        var result = input.ToList<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count);
        Assert.Equal(1, result[0]);
        Assert.Equal(2, result[1]);
        Assert.Equal(3, result[2]);
    }

    [Fact]
    public void ToList_NullNonGenericCollection_ReturnsEmptyList_Enumerable()
    {
        // Arrange
        System.Collections.IEnumerable? input = null;

        // Act
        var result = input.ToList<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    #endregion

    #region ToHashSet

    [Fact]
    public void ToHashSet_NullInput_ReturnsEmptyHashSet_Enumerable()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.ToHashSet<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void ToHashSet_EmptyInput_ReturnsEmptyHashSet_Enumerable()
    {
        // Arrange
        IEnumerable<object?> input = [];

        // Act
        var result = input.ToHashSet<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void ToHashSet_ValidInput_ReturnsTypedHashSet_Enumerable()
    {
        // Arrange
        IEnumerable<object?> input = ["1", "2", "3"];

        // Act
        var result = input.ToHashSet<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count);
        Assert.Contains(1, result);
        Assert.Contains(2, result);
        Assert.Contains(3, result);
    }

    [Fact]
    public void ToHashSet_MixedTypes_ParsesCorrectly_Enumerable()
    {
        // Arrange
        IEnumerable<object?> input = ["1", 2, "3.5"];

        // Act
        var result = input.ToHashSet<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count);
        Assert.Contains(1, result);
        Assert.Contains(2, result);
        Assert.Contains(3, result);
    }

    [Fact]
    public void ToHashSet_DuplicateValues_RemovesDuplicates_Enumerable()
    {
        // Arrange
        IEnumerable<object?> input = ["1", "1", 1, "2"];

        // Act
        var result = input.ToHashSet<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Contains(1, result);
        Assert.Contains(2, result);
    }

    [Fact]
    public void ToHashSet_NullValues_HandlesNullsCorrectly_Enumerable()
    {
        // Arrange
        IEnumerable<object?> input = ["1", null, "3"];

        // Act
        var result = input.ToHashSet<string?>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count);
        Assert.Contains("1", result);
        Assert.Contains(null, result);
        Assert.Contains("3", result);
    }

    [Fact]
    public void ToHashSet_ParamsOverload_ReturnsTypedHashSet_Enumerable()
    {
        // Act
        var result = YANEnumerable.ToHashSet<int>("1", 2, "3.5");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count);
        Assert.Contains(1, result);
        Assert.Contains(2, result);
        Assert.Contains(3, result);
    }

    [Fact]
    public void ToHashSet_NullParamsArray_ReturnsEmptyHashSet_Enumerable()
    {
        // Act
        var result = YANEnumerable.ToHashSet<int>(null);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void ToHashSet_EmptyParamsArray_ReturnsEmptyHashSet_Enumerable()
    {
        // Act
        var result = YANEnumerable.ToHashSet<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void ToHashSet_NonGenericCollection_ReturnsTypedHashSet_Enumerable()
    {
        // Arrange
        System.Collections.ArrayList input = ["1", 2, "3.5"];

        // Act
        var result = input.ToHashSet<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count);
        Assert.Contains(1, result);
        Assert.Contains(2, result);
        Assert.Contains(3, result);
    }

    [Fact]
    public void ToHashSet_NullNonGenericCollection_ReturnsEmptyHashSet_Enumerable()
    {
        // Arrange
        System.Collections.IEnumerable? input = null;

        // Act
        var result = input.ToHashSet<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    #endregion

    #region ToDictionary

    [Fact]
    public void ToDictionary_NullInput_ReturnsEmptyDictionary_Enumerable()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.ToDictionary<TestItem, int, string?, int, string?>(item => item.Id, item => item.Name);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void ToDictionary_EmptyInput_ReturnsEmptyDictionary_Enumerable()
    {
        // Arrange
        IEnumerable<object?> input = [];

        // Act
        var result = input.ToDictionary<TestItem, int, string?, int, string?>(item => item.Id, item => item.Name);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void ToDictionary_ValidInput_ReturnsTypedDictionary_Enumerable()
    {
        // Arrange
        IEnumerable<object?> input =
        [
            new TestItem { Id = 1, Name = "Item1" },
            new TestItem { Id = 2, Name = "Item2" },
            new TestItem { Id = 3, Name = "Item3" }
        ];

        // Act
        var result = input.ToDictionary<TestItem, int, string?, int, string?>(item => item.Id, item => item.Name);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count);
        Assert.Equal("Item1", result[1]);
        Assert.Equal("Item2", result[2]);
        Assert.Equal("Item3", result[3]);
    }

    [Fact]
    public void ToDictionary_MixedTypes_ParsesCorrectly_Enumerable()
    {
        // Arrange
        IEnumerable<object?> input =
        [
            new TestItem { Id = 1, Name = "Item1" },
            new TestItem { Id = 2, Name = null },
            "Not a test item"
        ];

        // Act
        var result = input.ToDictionary<TestItem, int, string?, int, string?>(item => item.Id, item => item.Name);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Equal("Item1", result[1]);
        Assert.Null(result[2]);
    }

    [Fact]
    public void ToDictionary_NullValues_HandlesNullsCorrectly_Enumerable()
    {
        // Arrange
        IEnumerable<object?> input =
        [
            new TestItem { Id = 1, Name = "Item1" },
            new TestItem { Id = 2, Name = null },
            null
        ];

        // Act
        var result = input.ToDictionary<TestItem, int, string?, int, string?>(item => item.Id, item => item.Name);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Equal("Item1", result[1]);
        Assert.Null(result[2]);
    }

    #endregion

    #region ToLookup

    [Fact]
    public void ToLookup_NullInput_ReturnsEmptyLookup_Enumerable()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.ToLookup<TestItem, int, string?, int, string?>(item => item.Id, item => item.Name);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void ToLookup_EmptyInput_ReturnsEmptyLookup_Enumerable()
    {
        // Arrange
        IEnumerable<object?> input = [];

        // Act
        var result = input.ToLookup<TestItem, int, string?, int, string?>(item => item.Id, item => item.Name);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void ToLookup_ValidInput_ReturnsTypedLookup_Enumerable()
    {
        // Arrange
        IEnumerable<object?> input =
        [
            new TestItem { Id = 1, Name = "Item1" },
            new TestItem { Id = 1, Name = "Item1-Duplicate" },
            new TestItem { Id = 2, Name = "Item2" },
            new TestItem { Id = 3, Name = "Item3" }
        ];

        // Act
        var result = input.ToLookup<TestItem, int, string?, int, string?>(item => item.Id, item => item.Name);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count);

        var group1 = result[1].ToList();
        Assert.Equal(2, group1.Count);
        Assert.Contains("Item1", group1);
        Assert.Contains("Item1-Duplicate", group1);

        var group2 = result[2].ToList();
        _ = Assert.Single(group2);
        Assert.Equal("Item2", group2[0]);

        var group3 = result[3].ToList();
        _ = Assert.Single(group3);
        Assert.Equal("Item3", group3[0]);
    }

    [Fact]
    public void ToLookup_MixedTypes_ParsesCorrectly_Enumerable()
    {
        // Arrange
        IEnumerable<object?> input =
        [
            new TestItem { Id = 1, Name = "Item1" },
            new TestItem { Id = 2, Name = null },
            "Not a test item"
        ];

        // Act
        var result = input.ToLookup<TestItem, int, string?, int, string?>(item => item.Id, item => item.Name);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);

        var group1 = result[1].ToList();
        _ = Assert.Single(group1);
        Assert.Equal("Item1", group1[0]);

        var group2 = result[2].ToList();
        _ = Assert.Single(group2);
        Assert.Null(group2[0]);
    }

    [Fact]
    public void ToLookup_NullValues_HandlesNullsCorrectly_Enumerable()
    {
        // Arrange
        IEnumerable<object?> input =
        [
            new TestItem { Id = 1, Name = "Item1" },
            new TestItem { Id = 2, Name = null },
            null
        ];

        // Act
        var result = input.ToLookup<TestItem, int, string?, int, string?>(item => item.Id, item => item.Name);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);

        var group1 = result[1].ToList();
        _ = Assert.Single(group1);
        Assert.Equal("Item1", group1[0]);

        var group2 = result[2].ToList();
        _ = Assert.Single(group2);
        Assert.Null(group2[0]);
    }

    #endregion

    private class TestItem
    {
        public int Id { get; set; }

        public string? Name { get; set; }
    }
}
