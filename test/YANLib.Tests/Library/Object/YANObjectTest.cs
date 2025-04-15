using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using YANLib.Object;
using YANLib.Unmanaged;

namespace YANLib.Tests.Library.Object;

public partial class YANObjectTest
{
    #region GetItemCount
    [Fact]
    public void GetItemCount_WithNullCollection_ReturnsZero()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.GetCount();

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void GetItemCount_WithEmptyCollection_ReturnsZero()
    {
        // Arrange
        IEnumerable<object?> input = [];

        // Act
        var result = input.GetCount();

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void GetItemCount_WithGenericCollection_ReturnsCorrectCount()
    {
        // Arrange
        ICollection<object?> input = ["item1", "item2", "item3"];

        // Act
        var result = input.GetCount();

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void GetItemCount_WithNonGenericCollection_ReturnsCorrectCount()
    {
        // Arrange
        ArrayList input = ["item1", "item2", "item3"];

        // Act
        var result = input.GetCount();

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void GetItemCount_WithReadOnlyCollection_ReturnsCorrectCount()
    {
        // Arrange
        IReadOnlyCollection<object?> input = new List<object?> { "item1", "item2", "item3" }.AsReadOnly();

        // Act
        var result = input.GetCount();

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void GetItemCount_WithArray_ReturnsCorrectCount()
    {
        // Arrange
        object?[] input = ["item1", "item2", "item3"];

        // Act
        var result = input.GetCount();

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void GetItemCount_WithImmutableList_ReturnsCorrectCount()
    {
        // Arrange
        IImmutableList<object?> input = ImmutableList.Create<object?>("item1", "item2", "item3");

        // Act
        var result = input.GetCount();

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void GetItemCount_WithImmutableQueue_ReturnsCorrectCount()
    {
        // Arrange
        IImmutableQueue<object?> input = ImmutableQueue.Create<object?>("item1", "item2", "item3");

        // Act
        var result = input.GetCount();

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void GetItemCount_WithImmutableStack_ReturnsCorrectCount()
    {
        // Arrange
        IImmutableStack<object?> input = ImmutableStack.Create<object?>("item1", "item2", "item3");

        // Act
        var result = input.GetCount();

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void GetItemCount_WithImmutableSet_ReturnsCorrectCount()
    {
        // Arrange
        IImmutableSet<object?> input = ImmutableHashSet.Create<object?>("item1", "item2", "item3");

        // Act
        var result = input.GetCount();

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void GetItemCount_WithImmutableDictionary_ReturnsCorrectCount()
    {
        // Arrange
        IImmutableDictionary<object, object?> input = ImmutableDictionary.Create<object, object?>().Add("key1", "value1").Add("key2", "value2").Add("key3", "value3");

        // Act
        var result = input.GetCount();

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void GetItemCount_WithConcurrentBag_ReturnsCorrectCount()
    {
        // Arrange
        ConcurrentBag<object?> input = new(["item1", "item2", "item3"]);

        // Act
        var result = input.GetCount();

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void GetItemCount_WithConcurrentQueue_ReturnsCorrectCount()
    {
        // Arrange
        ConcurrentQueue<object?> input = new(["item1", "item2", "item3"]);

        // Act
        var result = input.GetCount();

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void GetItemCount_WithConcurrentStack_ReturnsCorrectCount()
    {
        // Arrange
        ConcurrentStack<object?> input = new(["item1", "item2", "item3"]);

        // Act
        var result = input.GetCount();

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void GetItemCount_WithConcurrentDictionary_ReturnsCorrectCount()
    {
        // Arrange
        ConcurrentDictionary<object, object?> input = new();
        _ = input.TryAdd("key1", "value1");
        _ = input.TryAdd("key2", "value2");
        _ = input.TryAdd("key3", "value3");

        // Act
        var result = input.GetCount();

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void GetItemCount_WithBlockingCollection_ReturnsCorrectCount()
    {
        // Arrange
        BlockingCollection<object?> input = [.. new ConcurrentQueue<object?>(["item1", "item2", "item3"])];

        // Act
        var result = input.GetCount();

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void GetItemCount_WithEnumerable_ReturnsCorrectCount()
    {
        // Arrange
        var input = Enumerable.Range(1, 5).Select(i => (object?)i);

        // Act
        var result = input.GetCount();

        // Assert
        Assert.Equal(5, result);
    }
    #endregion

    #region IsDefault
    [Fact]
    public void IsDefault_WithNullObject_ReturnsTrue()
    {
        // Arrange
        object? input = default;

        // Act
        var result = input is null || input.IsDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsDefault_WithNonNullObject_ReturnsFalse()
    {
        // Arrange
        var input = new object();

        // Act
        var result = input.IsDefault();

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNotDefault
    [Fact]
    public void IsNotDefault_WithNullObject_ReturnsFalse()
    {
        // Arrange
        object? input = default;

        // Act
        var result = input is not null && !input.IsNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotDefault_WithNonNullObject_ReturnsTrue()
    {
        // Arrange
        var input = new object();

        // Act
        var result = input.IsNotDefault();

        // Assert
        Assert.True(result);
    }
    #endregion

    #region IsNull
    [Fact]
    public void IsNull_WithNullObject_ReturnsTrue()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.IsNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNull_WithNonNullObject_ReturnsFalse()
    {
        // Arrange
        var input = new object();

        // Act
        var result = input.IsNull();

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNotNull
    [Fact]
    public void IsNotNull_WithNullObject_ReturnsFalse()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.IsNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNull_WithNonNullObject_ReturnsTrue()
    {
        // Arrange
        var input = new object();

        // Act
        var result = input.IsNotNull();

        // Assert
        Assert.True(result);
    }
    #endregion

    #region IsNullEmpty
    [Fact]
    public void IsNullEmpty_WithNullIEnumerable_ReturnsTrue()
    {
        // Arrange
        IEnumerable<int>? input = null;

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullEmpty_WithEmptyIEnumerable_ReturnsTrue()
    {
        // Arrange
        IEnumerable<int> input = [];

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullEmpty_WithNonEmptyIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<int> input = [1, 2];

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNotNullEmpty
    [Fact]
    public void IsNotNullEmpty_WithNullIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<int>? input = null;

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullEmpty_WithEmptyIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<int> input = [];

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullEmpty_WithNonEmptyIEnumerable_ReturnsTrue()
    {
        // Arrange
        IEnumerable<int> input = [1, 2];

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.True(result);
    }
    #endregion

    #region AllNull
    [Fact]
    public void AllNull_WithNullIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object>? input = null;

        // Act
        var result = input.AllNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNull_WithEmptyIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object> input = [];

        // Act
        var result = input.AllNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNull_WithAllNullIEnumerable_ReturnsTrue()
    {
        // Arrange
        IEnumerable<object?> input = [null, null];

        // Act
        var result = input.AllNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNull_WithNonNullIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object?> input = [new object(), null];

        // Act
        var result = input.AllNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNull_WithNullParams_ReturnsFalse()
    {
        // Arrange
        object[]? input = null;

        // Act
        var result = YANObject.AllNull(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNull_WithEmptyParams_ReturnsFalse()
    {
        // Arrange
        object[] input = [];

        // Act
        var result = YANObject.AllNull(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNull_WithAllNullParams_ReturnsTrue()
    {
        // Act
        var result = YANObject.AllNull<object>(null, null);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNull_WithNonNullParams_ReturnsFalse()
    {
        // Act
        var result = YANObject.AllNull(null, new object());

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllNullEmpty
    [Fact]
    public void AllNullEmpty_WithNullIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object>? input = null;

        // Act
        var result = input.AllNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_WithEmptyIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object> input = [];

        // Act
        var result = input.AllNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_WithAllNullAndDefaultProperties_ReturnsTrue()
    {
        // Arrange
        var obj = new
        {
            Value = default(string)
        };

        IEnumerable<object?> input = [null, obj];

        // Act
        var result = input.AllNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNullEmpty_WithNonNullAndEmptyProperties_ReturnsFalse()
    {
        // Arrange
        var obj = new
        {
            Value = "Test"
        };

        IEnumerable<object?> input = [null, obj];

        // Act
        var result = input.AllNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_WithNullParams_ReturnsFalse()
    {
        // Arrange
        object[]? input = null;

        // Act
        var result = input.AllNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_WithEmptyParams_ReturnsFalse()
    {
        // Arrange
        object[] input = [];

        // Act
        var result = input.AllNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_WithAllNullAndDefaultParams_ReturnsTrue()
    {
        // Act
        var obj = new
        {
            Value = default(string)
        };

        var result = YANObject.AllNullEmpty<object>(null, obj);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNullEmpty_WithNonNullAndNonDefaultParams_ReturnsFalse()
    {
        // Act
        var obj = new
        {
            Value = "Test"
        };

        var result = YANObject.AllNullEmpty<object>(null, obj);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNull
    [Fact]
    public void AnyNull_WithNullIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object>? input = null;

        // Act
        var result = input.AnyNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNull_WithEmptyIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object> input = [];

        // Act
        var result = input.AnyNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNull_WithAtLeastOneNullElementInIEnumerable_ReturnsTrue()
    {
        // Arrange
        IEnumerable<object?> input = [null, new object()];

        // Act
        var result = input.AnyNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNull_WithAllNonNullElementsInIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object> input = [new object(), new object()];

        // Act
        var result = input.AnyNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNull_WithNullParams_ReturnsFalse()
    {
        // Arrange
        object[]? input = null;

        // Act
        var result = YANObject.AnyNull(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNull_WithEmptyParams_ReturnsFalse()
    {
        // Arrange
        object[] input = [];

        // Act
        var result = YANObject.AnyNull(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNull_WithAtLeastOneNullParams_ReturnsTrue()
    {
        // Act
        var result = YANObject.AnyNull(null, new object());

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNull_WithAllNonNullParams_ReturnsFalse()
    {
        // Act
        var result = YANObject.AnyNull(new object(), new object());

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNullEmpty
    [Fact]
    public void AnyNullEmpty_WithNullIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object>? input = null;

        // Act
        var result = input.AnyNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullEmpty_WithEmptyIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object> input = [];

        // Act
        var result = input.AnyNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullEmpty_WithAtLeastOneNullElementInIEnumerable_ReturnsTrue()
    {
        // Arrange
        IEnumerable<object?> input = [null, new object()];

        // Act
        var result = input.AnyNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullEmpty_WithAtLeastOneElementWithDefaultPropertiesInIEnumerable_ReturnsTrue()
    {
        // Arrange
        var obj = new
        {
            Value = default(string)
        };

        IEnumerable<object> input = [new object(), obj];

        // Act
        var result = input.AnyNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullEmpty_WithAllElementsNonNullAndNonDefaultInIEnumerable_ReturnsFalse()
    {
        // Arrange
        var obj1 = new
        {
            Value = "Test 1"
        };

        var obj2 = new
        {
            Value = "Test 2"
        };

        IEnumerable<object> input = [obj1, obj2];

        // Act
        var result = input.AnyNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullEmpty_WithNullParams_ReturnsFalse()
    {
        // Arrange
        object[]? input = null;

        // Act
        var result = YANObject.AnyNullEmpty(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullEmpty_WithEmptyParams_ReturnsFalse()
    {
        // Arrange
        object[] input = [];

        // Act
        var result = YANObject.AnyNullEmpty(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullEmpty_WithAtLeastOneNullParams_ReturnsTrue()
    {
        // Act
        var result = YANObject.AnyNullEmpty(null, new object());

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullEmpty_WithAtLeastOneElementWithDefaultPropertiesInParams_ReturnsTrue()
    {
        // Arrange
        var obj = new
        {
            Value = default(string)
        };

        // Act
        var result = YANObject.AnyNullEmpty(new object(), obj);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullEmpty_WithAllElementsNonNullAndNonDefaultParams_ReturnsFalse()
    {
        // Arrange
        var obj1 = new
        {
            Value = "Test 1"
        };

        var obj2 = new
        {
            Value = "Test 2"
        };

        // Act
        var result = YANObject.AnyNullEmpty(obj1, obj2);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllNotNull
    [Fact]
    public void AllNotNull_WithNullIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object>? input = null;

        // Act
        var result = input.AllNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNull_WithEmptyIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object> input = [];

        // Act
        var result = input.AllNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNull_WithAllNonNullElementsInIEnumerable_ReturnsTrue()
    {
        // Arrange
        IEnumerable<object> input = [new object(), new object()];

        // Act
        var result = input.AllNotNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNull_WithAtLeastOneNullElementInIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object?> input = [null, new object()];

        // Act
        var result = input.AllNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNull_WithNullParams_ReturnsFalse()
    {
        // Arrange
        object[]? input = null;

        // Act
        var result = YANObject.AllNotNull(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNull_WithEmptyParams_ReturnsFalse()
    {
        // Arrange
        object[] input = [];

        // Act
        var result = YANObject.AllNotNull(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNull_WithAllNonNullParams_ReturnsTrue()
    {
        // Act
        var result = YANObject.AllNotNull(new object(), new object());

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNull_WithAtLeastOneNullParams_ReturnsFalse()
    {
        // Act
        var result = YANObject.AllNotNull(null, new object());

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllNotNullEmpty
    [Fact]
    public void AllNotNullEmpty_WithNullIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object>? input = null;

        // Act
        var result = input.AllNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullEmpty_WithEmptyIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object> input = [];

        // Act
        var result = input.AllNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullEmpty_WithAllNonNullAndNonDefaultElementsInIEnumerable_ReturnsTrue()
    {
        // Arrange
        var obj1 = new
        {
            Value = "Test 1"
        };

        var obj2 = new
        {
            Value = "Test 2"
        };

        IEnumerable<object> input = [obj1, obj2];

        // Act
        var result = input.AllNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNullEmpty_WithAtLeastOneNullElementInIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object?> input = [null, new object()];

        // Act
        var result = input.AllNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullEmpty_WithAtLeastOneElementWithDefaultPropertiesInIEnumerable_ReturnsFalse()
    {
        // Arrange
        var obj = new
        {
            Value = default(string)
        };

        IEnumerable<object> input = [new object(), obj];

        // Act
        var result = input.AllNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullEmpty_WithNullParams_ReturnsFalse()
    {
        // Arrange
        object[]? input = null;

        // Act
        var result = YANObject.AllNotNullEmpty(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullEmpty_WithEmptyParams_ReturnsFalse()
    {
        // Arrange
        object[] input = [];

        // Act
        var result = YANObject.AllNotNullEmpty(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullEmpty_WithAllNonNullAndNonDefaultParams_ReturnsTrue()
    {
        // Arrange
        var obj1 = new
        {
            Value = "Test 1"
        };

        var obj2 = new
        {
            Value = "Test 2"
        };

        // Act
        var result = YANObject.AllNotNullEmpty(obj1, obj2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNullEmpty_WithAtLeastOneNullParams_ReturnsFalse()
    {
        // Act
        var result = YANObject.AllNotNullEmpty(null, new object());

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullEmpty_WithAtLeastOneElementWithDefaultPropertiesInParams_ReturnsFalse()
    {
        // Arrange
        var obj = new
        {
            Value = default(string)
        };

        // Act
        var result = YANObject.AllNotNullEmpty(new object(), obj);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotNull
    [Fact]
    public void AnyNotNull_WithNullIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object>? input = null;

        // Act
        var result = input.AnyNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNull_WithEmptyIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object> input = [];

        // Act
        var result = input.AnyNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNull_WithAllNullElementsInIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object?> input = [null, null];

        // Act
        var result = input.AnyNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNull_WithAtLeastOneNonNullElementInIEnumerable_ReturnsTrue()
    {
        // Arrange
        IEnumerable<object?> input = [null, new object()];

        // Act
        var result = input.AnyNotNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNull_Params_WithNullInput_ReturnsFalse()
    {
        // Arrange
        object?[]? input = null;

        // Act
        var result = YANObject.AnyNotNull(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNull_Params_WithEmptyInput_ReturnsFalse()
    {
        // Arrange
        object?[] input = [];

        // Act
        var result = YANObject.AnyNotNull(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNull_Params_WithAllNullElements_ReturnsFalse()
    {
        // Arrange
        object?[] input = [null, null];

        // Act
        var result = YANObject.AnyNotNull(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNull_Params_WithAtLeastOneNonNullElement_ReturnsTrue()
    {
        // Arrange
        object?[] input = [null, new object()];

        // Act
        var result = YANObject.AnyNotNull(input);

        // Assert
        Assert.True(result);
    }
    #endregion

    #region AnyNotNullEmpty
    [Fact]
    public void AnyNotNullEmpty_WithNullIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object>? input = null;

        // Act
        var result = input.AnyNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNullEmpty_WithEmptyIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object> input = [];

        // Act
        var result = input.AnyNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNullEmpty_WithAllNullElementsInIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object?> input = [null, null];

        // Act
        var result = input.AnyNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNullEmpty_WithAtLeastOneNonNullElementInIEnumerable_ReturnsTrue()
    {
        // Arrange
        IEnumerable<object?> input = [null, new object()];

        // Act
        var result = input.AnyNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNullEmpty_WithAtLeastOneElementWithDefaultPropertiesInIEnumerable_ReturnsTrue()
    {
        // Arrange
        var obj = new
        {
            Value = default(string)
        };

        IEnumerable<object?> input = [null, obj];

        // Act
        var result = input.AnyNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNullEmpty_WithNullParams_ReturnsFalse()
    {
        // Arrange
        object[]? input = null;

        // Act
        var result = YANObject.AnyNotNullEmpty(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNullEmpty_WithEmptyParams_ReturnsFalse()
    {
        // Arrange
        object[] input = [];

        // Act
        var result = YANObject.AnyNotNullEmpty(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNullEmpty_WithAllNullParams_ReturnsFalse()
    {
        // Act
        var result = YANObject.AnyNotNullEmpty<object>(null, null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNullEmpty_WithAtLeastOneNonNullParams_ReturnsTrue()
    {
        // Act
        var result = YANObject.AnyNotNullEmpty(null, new object());

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNullEmpty_WithAtLeastOneElementWithDefaultPropertiesInParams_ReturnsTrue()
    {
        // Arrange
        var obj = new
        {
            Value = default(string)
        };

        // Act
        var result = YANObject.AnyNotNullEmpty(null, obj);

        // Assert
        Assert.True(result);
    }
    #endregion

    #region ChangeTimeZoneAllProperty
    [Fact]
    public void ChangeTimeZoneAllProperty_WithNullInput_ReturnsNull()
    {
        // Arrange
        TestTimeZoneClass? input = null;

        // Act
        var result = input.ChangeTimeZoneAllProperty(new object(), new object());

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_WithDateTimeProperty_UpdatesDateTime()
    {
        // Arrange
        var originalDate = new DateTime(2020, 1, 1, 12, 0, 0);
        var tzSrc = 0;
        var tzDst = "7";
        var input = new TestTimeZoneClass
        {
            Date = originalDate,
            Name = "Test"
        };

        // Act
        var result = input.ChangeTimeZoneAllProperty(tzSrc, tzDst);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(originalDate.AddHours(Math.Abs(tzDst.Parse<double>() - tzSrc)), result.Date);
        Assert.Equal("Test", result.Name);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_WithNestedObject_UpdatesNestedDateTime()
    {
        // Arrange
        var originalDate = new DateTime(2020, 1, 1, 12, 0, 0);
        var tzSrc = 0;
        var tzDst = "7";
        var nested = new TestTimeZoneClass
        {
            Date = originalDate,
            Name = "Nested"
        };

        var input = new TestTimeZoneClass
        {
            Date = originalDate,
            Name = "Parent",
            Nested = nested
        };

        // Act
        var result = input.ChangeTimeZoneAllProperty(tzSrc, tzDst);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(originalDate.AddHours(Math.Abs(tzDst.Parse<double>() - tzSrc)), result.Date);
        Assert.NotNull(result.Nested);
        Assert.Equal(originalDate.AddHours(Math.Abs(tzDst.Parse<double>() - tzSrc)), result.Nested.Date);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_WithListProperty_UpdatesDateTimeInListItems()
    {
        // Arrange
        var originalDate = new DateTime(2020, 1, 1, 12, 0, 0);
        var tzSrc = 0;
        var tzDst = "7";
        var item1 = new TestTimeZoneClass
        {
            Date = originalDate,
            Name = "Item 1"
        };

        var item2 = new TestTimeZoneClass
        {
            Date = originalDate,
            Name = "Item 2"
        };

        var input = new TestTimeZoneClass
        {
            Date = originalDate,
            Name = "Parent",
            List = [item1, item2]
        };

        // Act
        var result = input.ChangeTimeZoneAllProperty(tzSrc, tzDst);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(originalDate.AddHours(Math.Abs(tzDst.Parse<double>() - tzSrc)), result.Date);
        Assert.NotNull(result.List);

        foreach (var item in result.List)
        {
            Assert.Equal(originalDate.AddHours(Math.Abs(tzDst.Parse<double>() - tzSrc)), item.Date);
        }
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_WithNullTimeZoneParameters_DoesNotChangeDateTime()
    {
        // Arrange
        var originalDate = new DateTime(2020, 1, 1, 12, 0, 0);
        var input = new TestTimeZoneClass
        {
            Date = originalDate,
            Name = "Test"
        };

        // Act
        var result = input.ChangeTimeZoneAllProperty();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(originalDate, result.Date);
    }
    #endregion

    #region ChangeTimeZoneAllProperties
    [Fact]
    public void ChangeTimeZoneAllProperties_WithNullIEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<TestTimeZoneClass>? input = null;

        // Act
        var result = input.ChangeTimeZoneAllProperties(new object(), new object());

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ChangeTimeZoneAllProperties_WithEmptyIEnumerable_ReturnsEmpty()
    {
        // Arrange
        IEnumerable<TestTimeZoneClass> input = [];

        // Act
        var result = input.ChangeTimeZoneAllProperties(new object(), new object());

        // Assert
        Assert.Empty(result!);
    }

    [Fact]
    public void ChangeTimeZoneAllProperties_WithValidIEnumerable_UpdatesDateTime()
    {
        // Arrange
        var originalDate = new DateTime(2020, 1, 1, 12, 0, 0);
        var tzSrc = 0;
        var tzDst = "7";
        var obj1 = new TestTimeZoneClass
        {
            Date = originalDate,
            Name = "Test 1"
        };

        var obj2 = new TestTimeZoneClass
        {
            Date = originalDate,
            Name = "Test 2"
        };

        IEnumerable<TestTimeZoneClass> input = [obj1, obj2];

        // Act
        var result = input.ChangeTimeZoneAllProperties(tzSrc, tzDst);

        // Assert
        Assert.NotNull(result);

        foreach (var item in result)
        {
            Assert.Equal(originalDate.AddHours(Math.Abs(tzDst.Parse<double>() - tzSrc)), item!.Date);
        }
    }
    #endregion

    #region Copy
    [Fact]
    public void Copy_WithNullInput_ReturnsNull()
    {
        // Arrange
        TestCopyClass? input = null;

        // Act
        var result = input.Copy();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Copy_WithNonNullInput_ReturnsCopyWithSameProperties()
    {
        // Arrange
        var input = new TestCopyClass
        {
            Number = 1,
            Text = "Hello"
        };

        // Act
        var result = input.Copy();

        // Assert
        Assert.NotNull(result);
        Assert.NotSame(input, result);
        Assert.Equal(input.Number, result.Number);
        Assert.Equal(input.Text, result.Text);
    }
    #endregion
}

public class TestCopyClass
{
    public int Number { get; set; }

    public string? Text { get; set; }
}

public class TestTimeZoneClass
{
    public DateTime Date { get; set; }

    public string? Name { get; set; }

    public TestTimeZoneClass? Nested { get; set; }

    public List<TestTimeZoneClass>? List { get; set; }
}