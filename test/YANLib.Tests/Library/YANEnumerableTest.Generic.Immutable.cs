using System.Collections;

namespace YANLib.Tests.Library;

public partial class YANEnumerableTest
{
    #region ToImmutableArray

    [Fact]
    public void ToImmutableArray_NullInput_ReturnsEmptyImmutableArray_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.ToImmutableArray<int>();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void ToImmutableArray_EmptyInput_ReturnsEmptyImmutableArray_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?> input = [];

        // Act
        var result = input.ToImmutableArray<int>();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void ToImmutableArray_ValidInput_ReturnsTypedImmutableArray_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?> input = ["1", "2", "3"];

        // Act
        var result = input.ToImmutableArray<int>();

        // Assert
        Assert.NotEmpty(result);
        Assert.Equal(3, result.Length);
        Assert.Equal(1, result[0]);
        Assert.Equal(2, result[1]);
        Assert.Equal(3, result[2]);
    }

    [Fact]
    public void ToImmutableArray_MixedTypes_ParsesCorrectly_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?> input = ["1", 2, "3.5"];

        // Act
        var result = input.ToImmutableArray<int>();

        // Assert
        Assert.NotEmpty(result);
        Assert.Equal(3, result.Length);
        Assert.Equal(1, result[0]);
        Assert.Equal(2, result[1]);
        Assert.Equal(3, result[2]);
    }

    [Fact]
    public void ToImmutableArray_DuplicateValues_RemovesDuplicates_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?> input = ["1", "1", 1, "2"];

        // Act
        var result = input.ToImmutableArray<int>();

        // Assert
        Assert.NotEmpty(result);
        Assert.Equal(4, result.Length);
        Assert.Equal(1, result[0]);
        Assert.Equal(1, result[1]);
        Assert.Equal(1, result[2]);
        Assert.Equal(2, result[3]);
    }

    [Fact]
    public void ToImmutableArray_NullValues_HandlesNullsCorrectly_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?> input = ["1", null, "3"];

        // Act
        var result = input.ToImmutableArray<string>();

        // Assert
        Assert.NotEmpty(result);
        Assert.Equal(3, result.Length);
        Assert.Equal("1", result[0]);
        Assert.Null(result[1]);
        Assert.Equal("3", result[2]);
    }

    [Fact]
    public void ToImmutableArray_ParamsOverload_ReturnsTypedImmutableArray_ImmutableEnumerable()
    {
        // Act
        var result = YANEnumerable.ToImmutableArray<int>("1", 2, "3.5");

        // Assert
        Assert.NotEmpty(result);
        Assert.Equal(3, result.Length);
        Assert.Equal(1, result[0]);
        Assert.Equal(2, result[1]);
        Assert.Equal(3, result[2]);
    }

    [Fact]
    public void ToImmutableArray_NullParamsArray_ReturnsEmptyImmutableArray_ImmutableEnumerable()
    {
        // Act
        var result = YANEnumerable.ToImmutableArray<int>(null);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void ToImmutableArray_EmptyParamsArray_ReturnsEmptyImmutableArray_ImmutableEnumerable()
    {
        // Act
        var result = YANEnumerable.ToImmutableArray<int>();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void ToImmutableArray_NonGenericCollection_ReturnsTypedImmutableArray_ImmutableEnumerable()
    {
        // Arrange
        ArrayList input = ["1", 2, "3.5"];

        // Act
        var result = input.ToImmutableArray<int>();

        // Assert
        Assert.NotEmpty(result);
        Assert.Equal(3, result.Length);
        Assert.Equal(1, result[0]);
        Assert.Equal(2, result[1]);
        Assert.Equal(3, result[2]);
    }

    [Fact]
    public void ToImmutableArray_NullNonGenericCollection_ReturnsEmptyImmutableArray_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable? input = null;

        // Act
        var result = input.ToImmutableArray<int>();

        // Assert
        Assert.Empty(result);
    }

    #endregion

    #region ToImmutableList

    [Fact]
    public void ToImmutableList_NullInput_ReturnsEmptyImmutableList_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.ToImmutableList<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void ToImmutableList_EmptyInput_ReturnsEmptyImmutableList_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?> input = [];

        // Act
        var result = input.ToImmutableList<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void ToImmutableList_ValidInput_ReturnsTypedImmutableList_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?> input = ["1", "2", "3"];

        // Act
        var result = input.ToImmutableList<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count);
        Assert.Equal(1, result[0]);
        Assert.Equal(2, result[1]);
        Assert.Equal(3, result[2]);
    }

    [Fact]
    public void ToImmutableList_MixedTypes_ParsesCorrectly_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?> input = ["1", 2, "3.5"];

        // Act
        var result = input.ToImmutableList<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count);
        Assert.Equal(1, result[0]);
        Assert.Equal(2, result[1]);
        Assert.Equal(3, result[2]);
    }

    [Fact]
    public void ToImmutableList_DuplicateValues_RemovesDuplicates_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?> input = ["1", "1", 1, "2"];

        // Act
        var result = input.ToImmutableList<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(4, result.Count);
        Assert.Equal(1, result[0]);
        Assert.Equal(1, result[1]);
        Assert.Equal(1, result[2]);
        Assert.Equal(2, result[3]);
    }

    [Fact]
    public void ToImmutableList_NullValues_HandlesNullsCorrectly_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?> input = ["1", null, "3"];

        // Act
        var result = input.ToImmutableList<string>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count);
        Assert.Equal("1", result[0]);
        Assert.Null(result[1]);
        Assert.Equal("3", result[2]);
    }

    [Fact]
    public void ToImmutableList_ParamsOverload_ReturnsTypedImmutableList_ImmutableEnumerable()
    {
        // Act
        var result = YANEnumerable.ToImmutableList<int>("1", 2, "3.5");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count);
        Assert.Equal(1, result[0]);
        Assert.Equal(2, result[1]);
        Assert.Equal(3, result[2]);
    }

    [Fact]
    public void ToImmutableList_NullParamsArray_ReturnsEmptyImmutableList_ImmutableEnumerable()
    {
        // Act
        var result = YANEnumerable.ToImmutableList<int>(null);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void ToImmutableList_EmptyParamsArray_ReturnsEmptyImmutableList_ImmutableEnumerable()
    {
        // Act
        var result = YANEnumerable.ToImmutableList<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void ToImmutableList_NonGenericCollection_ReturnsTypedImmutableList_ImmutableEnumerable()
    {
        // Arrange
        ArrayList input = ["1", 2, "3.5"];

        // Act
        var result = input.ToImmutableList<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count);
        Assert.Equal(1, result[0]);
        Assert.Equal(2, result[1]);
        Assert.Equal(3, result[2]);
    }

    [Fact]
    public void ToImmutableList_NullNonGenericCollection_ReturnsEmptyImmutableList_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable? input = null;

        // Act
        var result = input.ToImmutableList<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    #endregion

    #region ToImmutableHashSet

    [Fact]
    public void ToImmutableHashSet_NullInput_ReturnsEmptyImmutableHashSet_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.ToImmutableHashSet<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void ToImmutableHashSet_EmptyInput_ReturnsEmptyImmutableHashSet_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?> input = [];

        // Act
        var result = input.ToImmutableHashSet<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void ToImmutableHashSet_ValidInput_ReturnsTypedImmutableHashSet_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?> input = ["1", "2", "3"];

        // Act
        var result = input.ToImmutableHashSet<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count);
        Assert.Contains(1, result);
        Assert.Contains(2, result);
        Assert.Contains(3, result);
    }

    [Fact]
    public void ToImmutableHashSet_MixedTypes_ParsesCorrectly_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?> input = ["1", 2, "3.5"];

        // Act
        var result = input.ToImmutableHashSet<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count);
        Assert.Contains(1, result);
        Assert.Contains(2, result);
        Assert.Contains(3, result);
    }

    [Fact]
    public void ToImmutableHashSet_DuplicateValues_RemovesDuplicates_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?> input = ["1", "1", 1, "2"];

        // Act
        var result = input.ToImmutableHashSet<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Contains(1, result);
        Assert.Contains(2, result);
    }

    [Fact]
    public void ToImmutableHashSet_NullValues_HandlesNullsCorrectly_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?> input = ["1", null, "3"];

        // Act
        var result = input.ToImmutableHashSet<string?>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count);
        Assert.Contains("1", result);
        Assert.Contains(null, result);
        Assert.Contains("3", result);
    }

    [Fact]
    public void ToImmutableHashSet_ParamsOverload_ReturnsTypedImmutableHashSet_ImmutableEnumerable()
    {
        // Act
        var result = YANEnumerable.ToImmutableHashSet<int>("1", 2, "3.5");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count);
        Assert.Contains(1, result);
        Assert.Contains(2, result);
        Assert.Contains(3, result);
    }

    [Fact]
    public void ToImmutableHashSet_NullParamsArray_ReturnsEmptyImmutableHashSet_ImmutableEnumerable()
    {
        // Act
        var result = YANEnumerable.ToImmutableHashSet<int>(null);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void ToImmutableHashSet_EmptyParamsArray_ReturnsEmptyImmutableHashSet_ImmutableEnumerable()
    {
        // Act
        var result = YANEnumerable.ToImmutableHashSet<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void ToImmutableHashSet_NonGenericCollection_ReturnsTypedImmutableHashSet_ImmutableEnumerable()
    {
        // Arrange
        ArrayList input = ["1", 2, "3.5"];

        // Act
        var result = input.ToImmutableHashSet<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count);
        Assert.Contains(1, result);
        Assert.Contains(2, result);
        Assert.Contains(3, result);
    }

    [Fact]
    public void ToImmutableHashSet_NullNonGenericCollection_ReturnsEmptyImmutableHashSet_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable? input = null;

        // Act
        var result = input.ToImmutableHashSet<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    #endregion

    #region ToImmutableDictionary

    [Fact]
    public void ToImmutableDictionary_NullInput_ReturnsEmptyImmutableDictionary_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.ToImmutableDictionary<TestItem, int, string?, int, string?>(item => item.Id, item => item.Name);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void ToImmutableDictionary_EmptyInput_ReturnsEmptyImmutableDictionary_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?> input = [];

        // Act
        var result = input.ToImmutableDictionary<TestItem, int, string?, int, string?>(item => item.Id, item => item.Name);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void ToImmutableDictionary_ValidInput_ReturnsTypedImmutableDictionary_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?> input =
        [
            new TestItem { Id = 1, Name = "Item1" },
            new TestItem { Id = 2, Name = "Item2" },
            new TestItem { Id = 3, Name = "Item3" }
        ];

        // Act
        var result = input.ToImmutableDictionary<TestItem, int, string?, int, string?>(item => item.Id, item => item.Name);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count);
        Assert.Equal("Item1", result[1]);
        Assert.Equal("Item2", result[2]);
        Assert.Equal("Item3", result[3]);
    }

    [Fact]
    public void ToImmutableDictionary_MixedTypes_ParsesCorrectly_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?> input =
        [
            new TestItem { Id = 1, Name = "Item1" },
            new TestItem { Id = 2, Name = null },
            "Not a test item"
        ];

        // Act
        var result = input.ToImmutableDictionary<TestItem, int, string?, int, string?>(item => item.Id, item => item.Name);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Equal("Item1", result[1]);
        Assert.Null(result[2]);
    }

    [Fact]
    public void ToImmutableDictionary_NullValues_HandlesNullsCorrectly_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?> input =
        [
            new TestItem { Id = 1, Name = "Item1" },
            new TestItem { Id = 2, Name = null },
            null
        ];

        // Act
        var result = input.ToImmutableDictionary<TestItem, int, string?, int, string?>(item => item.Id, item => item.Name);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Equal("Item1", result[1]);
        Assert.Null(result[2]);
    }

    #endregion

    #region ToImmutableStack

    [Fact]
    public void ToImmutableStack_NullInput_ReturnsEmptyImmutableStack_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.ToImmutableStack<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void ToImmutableStack_EmptyInput_ReturnsEmptyImmutableStack_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?> input = [];

        // Act
        var result = input.ToImmutableStack<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void ToImmutableStack_ValidInput_ReturnsTypedImmutableStack_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?> input = ["1", "2", "3"];

        // Act
        var result = input.ToImmutableStack<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count());

        var popped = result.Peek();
        Assert.Equal(3, popped);

        var remaining = result.Pop();
        popped = remaining.Peek();
        Assert.Equal(2, popped);

        remaining = remaining.Pop();
        popped = remaining.Peek();
        Assert.Equal(1, popped);
    }

    [Fact]
    public void ToImmutableStack_MixedTypes_ParsesCorrectly_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?> input = ["1", 2, "3.5"];

        // Act
        var result = input.ToImmutableStack<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count());

        var popped = result.Peek();
        Assert.Equal(3, popped);

        var remaining = result.Pop();
        popped = remaining.Peek();
        Assert.Equal(2, popped);

        remaining = remaining.Pop();
        popped = remaining.Peek();
        Assert.Equal(1, popped);
    }

    [Fact]
    public void ToImmutableStack_DuplicateValues_RemovesDuplicates_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?> input = ["1", "1", 1, "2"];

        // Act
        var result = input.ToImmutableStack<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(4, result.Count());

        var popped = result.Peek();
        Assert.Equal(2, popped);

        var remaining = result.Pop();
        popped = remaining.Peek();
        Assert.Equal(1, popped);
    }

    [Fact]
    public void ToImmutableStack_NullValues_HandlesNullsCorrectly_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?> input = ["1", null, "3"];

        // Act
        var result = input.ToImmutableStack<string>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count());

        var popped = result.Peek();
        Assert.Equal("3", popped);

        var remaining = result.Pop();
        popped = remaining.Peek();
        Assert.Null(popped);

        remaining = remaining.Pop();
        popped = remaining.Peek();
        Assert.Equal("1", popped);
    }

    [Fact]
    public void ToImmutableStack_ParamsOverload_ReturnsTypedImmutableStack_ImmutableEnumerable()
    {
        // Act
        var result = YANEnumerable.ToImmutableStack<int>("1", 2, "3.5");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count());

        var popped = result.Peek();
        Assert.Equal(3, popped);
    }

    [Fact]
    public void ToImmutableStack_NullParamsArray_ReturnsEmptyImmutableStack_ImmutableEnumerable()
    {
        // Act
        var result = YANEnumerable.ToImmutableStack<int>(null);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void ToImmutableStack_EmptyParamsArray_ReturnsEmptyImmutableStack_ImmutableEnumerable()
    {
        // Act
        var result = YANEnumerable.ToImmutableStack<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void ToImmutableStack_NonGenericCollection_ReturnsTypedImmutableStack_ImmutableEnumerable()
    {
        // Arrange
        ArrayList input = ["1", 2, "3.5"];

        // Act
        var result = input.ToImmutableStack<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count());

        var popped = result.Peek();
        Assert.Equal(3, popped);
    }

    [Fact]
    public void ToImmutableStack_NullNonGenericCollection_ReturnsEmptyImmutableStack_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable? input = null;

        // Act
        var result = input.ToImmutableStack<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    #endregion

    #region ToImmutableQueue

    [Fact]
    public void ToImmutableQueue_NullInput_ReturnsEmptyImmutableQueue_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.ToImmutableQueue<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void ToImmutableQueue_EmptyInput_ReturnsEmptyImmutableQueue_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?> input = [];

        // Act
        var result = input.ToImmutableQueue<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void ToImmutableQueue_ValidInput_ReturnsTypedImmutableQueue_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?> input = ["1", "2", "3"];

        // Act
        var result = input.ToImmutableQueue<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count());

        var dequeued = result.Peek();
        Assert.Equal(1, dequeued);

        var remaining = result.Dequeue();
        dequeued = remaining.Peek();
        Assert.Equal(2, dequeued);

        remaining = remaining.Dequeue();
        dequeued = remaining.Peek();
        Assert.Equal(3, dequeued);
    }

    [Fact]
    public void ToImmutableQueue_MixedTypes_ParsesCorrectly_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?> input = ["1", 2, "3.5"];

        // Act
        var result = input.ToImmutableQueue<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count());

        var dequeued = result.Peek();
        Assert.Equal(1, dequeued);

        var remaining = result.Dequeue();
        dequeued = remaining.Peek();
        Assert.Equal(2, dequeued);

        remaining = remaining.Dequeue();
        dequeued = remaining.Peek();
        Assert.Equal(3, dequeued);
    }

    [Fact]
    public void ToImmutableQueue_DuplicateValues_RemovesDuplicates_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?> input = ["1", "1", 1, "2"];

        // Act
        var result = input.ToImmutableQueue<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(4, result.Count());

        var dequeued = result.Peek();
        Assert.Equal(1, dequeued);

        var remaining = result.Dequeue();
        dequeued = remaining.Peek();
        Assert.Equal(1, dequeued);
    }

    [Fact]
    public void ToImmutableQueue_NullValues_HandlesNullsCorrectly_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?> input = ["1", null, "3"];

        // Act
        var result = input.ToImmutableQueue<string>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count());

        var dequeued = result.Peek();
        Assert.Equal("1", dequeued);

        var remaining = result.Dequeue();
        dequeued = remaining.Peek();
        Assert.Null(dequeued);

        remaining = remaining.Dequeue();
        dequeued = remaining.Peek();
        Assert.Equal("3", dequeued);
    }

    [Fact]
    public void ToImmutableQueue_ParamsOverload_ReturnsTypedImmutableQueue_ImmutableEnumerable()
    {
        // Act
        var result = YANEnumerable.ToImmutableQueue<int>("1", 2, "3.5");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count());

        var dequeued = result.Peek();
        Assert.Equal(1, dequeued);
    }

    [Fact]
    public void ToImmutableQueue_NullParamsArray_ReturnsEmptyImmutableQueue_ImmutableEnumerable()
    {
        // Act
        var result = YANEnumerable.ToImmutableQueue<int>(null);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void ToImmutableQueue_EmptyParamsArray_ReturnsEmptyImmutableQueue_ImmutableEnumerable()
    {
        // Act
        var result = YANEnumerable.ToImmutableQueue<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void ToImmutableQueue_NonGenericCollection_ReturnsTypedImmutableQueue_ImmutableEnumerable()
    {
        // Arrange
        ArrayList input = ["1", 2, "3.5"];

        // Act
        var result = input.ToImmutableQueue<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count());

        var dequeued = result.Peek();
        Assert.Equal(1, dequeued);
    }

    [Fact]
    public void ToImmutableQueue_NullNonGenericCollection_ReturnsEmptyImmutableQueue_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable? input = null;

        // Act
        var result = input.ToImmutableQueue<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    #endregion

    #region ToImmutableSortedSet

    [Fact]
    public void ToImmutableSortedSet_NullInput_ReturnsEmptyImmutableSortedSet_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.ToImmutableSortedSet<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void ToImmutableSortedSet_EmptyInput_ReturnsEmptyImmutableSortedSet_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?> input = [];

        // Act
        var result = input.ToImmutableSortedSet<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void ToImmutableSortedSet_ValidInput_ReturnsTypedImmutableSortedSet_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?> input = ["3", "1", "2"];

        // Act
        var result = input.ToImmutableSortedSet<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count);
        Assert.Equal([1, 2, 3], [.. result]);
    }

    [Fact]
    public void ToImmutableSortedSet_MixedTypes_ParsesCorrectly_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?> input = ["3.5", 1, "2"];

        // Act
        var result = input.ToImmutableSortedSet<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count);
        Assert.Equal([1, 2, 3], [.. result]);
    }

    [Fact]
    public void ToImmutableSortedSet_NullValues_HandlesNullsCorrectly_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?> input = ["3.5", null, "2"];

        // Act
        var result = input.ToImmutableSortedSet<string?>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count);

        Assert.Collection(result, Assert.Null, item => Assert.Equal("2", item), item => Assert.Equal("3.5", item));

        var expected = new string?[] { null, "2", "3.5" };
        Assert.True(expected.SequenceEqual(result));
    }

    [Fact]
    public void ToImmutableSortedSet_DuplicateValues_RemovesDuplicates_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?> input = ["1", "1", 1, "2"];

        // Act
        var result = input.ToImmutableSortedSet<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Equal([1, 2], [.. result]);
    }

    [Fact]
    public void ToImmutableSortedSet_ParamsOverload_ReturnsTypedImmutableSortedSet_ImmutableEnumerable()
    {
        // Act
        var result = YANEnumerable.ToImmutableSortedSet<int>("3", 1, "2");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count);
        Assert.Equal([1, 2, 3], [.. result]);
    }

    [Fact]
    public void ToImmutableSortedSet_NullParamsArray_ReturnsEmptyImmutableSortedSet_ImmutableEnumerable()
    {
        // Act
        var result = YANEnumerable.ToImmutableSortedSet<int>(null);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void ToImmutableSortedSet_EmptyParamsArray_ReturnsEmptyImmutableSortedSet_ImmutableEnumerable()
    {
        // Act
        var result = YANEnumerable.ToImmutableSortedSet<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void ToImmutableSortedSet_NonGenericCollection_ReturnsTypedImmutableSortedSet_ImmutableEnumerable()
    {
        // Arrange
        ArrayList input = ["3", 1, "2"];

        // Act
        var result = input.ToImmutableSortedSet<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count);
        Assert.Equal([1, 2, 3], [.. result]);
    }

    [Fact]
    public void ToImmutableSortedSet_NullNonGenericCollection_ReturnsEmptyImmutableSortedSet_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable? input = null;

        // Act
        var result = input.ToImmutableSortedSet<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    #endregion

    #region ToImmutableSortedDictionary

    [Fact]
    public void ToImmutableSortedDictionary_NullInput_ReturnsEmptyImmutableSortedDictionary_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.ToImmutableSortedDictionary<TestItem, int, string?, int, string?>(item => item.Id, item => item.Name);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void ToImmutableSortedDictionary_EmptyInput_ReturnsEmptyImmutableSortedDictionary_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?> input = [];

        // Act
        var result = input.ToImmutableSortedDictionary<TestItem, int, string?, int, string?>(item => item.Id, item => item.Name);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void ToImmutableSortedDictionary_ValidInput_ReturnsTypedImmutableSortedDictionary_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?> input =
        [
            new TestItem { Id = 3, Name = "Item3" },
            new TestItem { Id = 1, Name = "Item1" },
            new TestItem { Id = 2, Name = "Item2" }
        ];

        // Act
        var result = input.ToImmutableSortedDictionary<TestItem, int, string?, int, string?>(item => item.Id, item => item.Name);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count);
        Assert.Equal("Item1", result[1]);
        Assert.Equal("Item2", result[2]);
        Assert.Equal("Item3", result[3]);
        Assert.Equal([1, 2, 3], [.. result.Keys]);
    }

    [Fact]
    public void ToImmutableSortedDictionary_MixedTypes_ParsesCorrectly_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?> input =
        [
            new TestItem { Id = 3, Name = "Item3" },
            new TestItem { Id = 1, Name = null },
            "Not a test item"
        ];

        // Act
        var result = input.ToImmutableSortedDictionary<TestItem, int, string?, int, string?>(item => item.Id, item => item.Name);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Null(result[1]);
        Assert.Equal("Item3", result[3]);
        Assert.Equal([1, 3], [.. result.Keys]);
    }

    [Fact]
    public void ToImmutableSortedDictionary_NullValues_HandlesNullsCorrectly_ImmutableEnumerable()
    {
        // Arrange
        IEnumerable<object?> input =
        [
            new TestItem { Id = 3, Name = "Item3" },
            new TestItem { Id = 1, Name = null },
            null
        ];

        // Act
        var result = input.ToImmutableSortedDictionary<TestItem, int, string?, int, string?>(item => item.Id, item => item.Name);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Null(result[1]);
        Assert.Equal("Item3", result[3]);
        Assert.Equal([1, 3], [.. result.Keys]);
    }

    #endregion
}
