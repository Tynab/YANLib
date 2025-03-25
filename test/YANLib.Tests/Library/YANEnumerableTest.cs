using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Immutable;

namespace YANLib.Tests.Library;

public partial class YANEnumerableTest
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

    #region ChunkBySize
    [Fact]
    public void ChunkBySize_WithNullInput_YieldsNoChunks()
    {
        // Arrange
        List<int>? input = null;
        var chunkSize = 2;

        // Act
        var result = input.ChunkBySize(chunkSize).ToList();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void ChunkBySize_WithEmptyInput_YieldsNoChunks()
    {
        // Arrange
        var input = new List<int>();
        var chunkSize = 2;

        // Act
        var result = input.ChunkBySize(chunkSize).ToList();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void ChunkBySize_WithZeroChunkSize_YieldsNoChunks()
    {
        // Arrange
        var input = new List<int> { 1, 2, 3, 4, 5 };
        var chunkSize = 0;

        // Act
        var result = input.ChunkBySize(chunkSize).ToList();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void ChunkBySize_WithInputSmallerThanChunkSize_YieldsOneChunk()
    {
        // Arrange
        var input = new List<int> { 1, 2, 3 };
        var chunkSize = 5;

        // Act
        var result = input.ChunkBySize(chunkSize).ToList();

        // Assert
        _ = Assert.Single(result);
        Assert.Equal(3, result[0].Count);
        Assert.Equal([1, 2, 3], result[0]);
    }

    [Fact]
    public void ChunkBySize_WithInputExactMultipleOfChunkSize_YieldsEqualChunks()
    {
        // Arrange
        var input = new List<int> { 1, 2, 3, 4, 5, 6 };
        var chunkSize = 2;

        // Act
        var result = input.ChunkBySize(chunkSize).ToList();

        // Assert
        Assert.Equal(3, result.Count);
        Assert.Equal([1, 2], result[0]);
        Assert.Equal([3, 4], result[1]);
        Assert.Equal([5, 6], result[2]);
    }

    [Fact]
    public void ChunkBySize_WithInputNotExactMultipleOfChunkSize_YieldsLastChunkSmaller()
    {
        // Arrange
        var input = new List<int> { 1, 2, 3, 4, 5 };
        var chunkSize = 2;

        // Act
        var result = input.ChunkBySize(chunkSize).ToList();

        // Assert
        Assert.Equal(3, result.Count);
        Assert.Equal([1, 2], result[0]);
        Assert.Equal([3, 4], result[1]);
        Assert.Equal([5], result[2]);
    }

    [Fact]
    public void ChunkBySize_WithStringChunkSize_ParsesCorrectly()
    {
        // Arrange
        var input = new List<int> { 1, 2, 3, 4, 5, 6 };
        var chunkSize = "3";

        // Act
        var result = input.ChunkBySize(chunkSize).ToList();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal([1, 2, 3], result[0]);
        Assert.Equal([4, 5, 6], result[1]);
    }
    #endregion

    #region Clean List
    [Fact]
    public void Clean_List_WithNullInput_DoesNothing()
    {
        // Arrange
        List<string?>? input = null;

        // Act
        input.Clean();

        // Assert
        Assert.Null(input);
    }

    [Fact]
    public void Clean_List_WithEmptyInput_DoesNothing()
    {
        // Arrange
        var input = new List<string?>();

        // Act
        input.Clean();

        // Assert
        Assert.Empty(input);
    }

    [Fact]
    public void Clean_List_WithNullElements_RemovesNullElements()
    {
        // Arrange
        var input = new List<string?> { "item1", null, "item2", null, "item3" };

        // Act
        input.Clean();

        // Assert
        Assert.Equal(3, input.Count);
        Assert.Equal(["item1", "item2", "item3"], input);
    }

    [Fact]
    public void Clean_List_WithAllNullElements_RemovesAllElements()
    {
        // Arrange
        var input = new List<string?> { null, null, null };

        // Act
        input.Clean();

        // Assert
        Assert.Empty(input);
    }

    [Fact]
    public void Clean_List_WithValueTypeList_DoesNothing()
    {
        // Arrange
        var input = new List<int> { 1, 2, 3 };

        // Act
        input.Clean();

        // Assert
        Assert.Equal(3, input.Count);
        Assert.Equal([1, 2, 3], input);
    }

    [Fact]
    public void Clean_List_WithNullableValueTypeList_RemovesNullElements()
    {
        // Arrange
        var input = new List<int?> { 1, null, 2, null, 3 };

        // Act
        input.Clean();

        // Assert
        Assert.Equal(3, input.Count);
        Assert.Equal([1, 2, 3], input);
    }
    #endregion

    #region Clean IEnumerable
    [Fact]
    public void Clean_IEnumerable_WithNullInput_ReturnsNull()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.Clean();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Clean_IEnumerable_WithEmptyInput_ReturnsEmpty()
    {
        // Arrange
        IEnumerable<string?> input = [];

        // Act
        var result = input.Clean();

        // Assert
        Assert.Empty(result!);
    }

    [Fact]
    public void Clean_IEnumerable_WithNullElements_RemovesNullElements()
    {
        // Arrange
        IEnumerable<string?> input = ["item1", null, "item2", null, "item3"];

        // Act
        var result = input.Clean()!.ToList();

        // Assert
        Assert.Equal(3, result.Count);
        Assert.Equal(["item1", "item2", "item3"], result);
    }

    [Fact]
    public void Clean_IEnumerable_WithAllNullElements_ReturnsEmpty()
    {
        // Arrange
        IEnumerable<string?> input = [null, null, null];

        // Act
        var result = input.Clean()!.ToList();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void Clean_IEnumerable_WithValueTypeEnumerable_ReturnsOriginal()
    {
        // Arrange
        IEnumerable<int> input = [1, 2, 3];

        // Act
        var result = input.Clean()!.ToList();

        // Assert
        Assert.Equal(3, result.Count);
        Assert.Equal([1, 2, 3], result);
    }

    [Fact]
    public void Clean_IEnumerable_WithNullableValueTypeEnumerable_RemovesNullElements()
    {
        // Arrange
        IEnumerable<int?> input = [1, null, 2, null, 3];

        // Act
        var result = input.Clean()!.ToList();

        // Assert
        Assert.Equal(3, result.Count);
        Assert.Equal(expected: [1, 2, 3], result);
    }
    #endregion

    #region Clean Params
    [Fact]
    public void Clean_Params_WithNullInput_ReturnsNull()
    {
        // Arrange
        string?[]? input = null;

        // Act
        var result = YANEnumerable.Clean(input);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Clean_Params_WithEmptyInput_ReturnsEmpty()
    {
        // Arrange
        string?[] input = [];

        // Act
        var result = YANEnumerable.Clean(input);

        // Assert
        Assert.Empty(result!);
    }

    [Fact]
    public void Clean_Params_WithNullElements_RemovesNullElements()
    {
        // Act
        var result = YANEnumerable.Clean("item1", null, "item2", null, "item3")!.ToList();

        // Assert
        Assert.Equal(3, result.Count);
        Assert.Equal(["item1", "item2", "item3"], result);
    }

    [Fact]
    public void Clean_Params_WithAllNullElements_ReturnsEmpty()
    {
        // Act
        var result = YANEnumerable.Clean<string?>(null, null, null)!.ToList();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void Clean_Params_WithValueTypeParams_ReturnsOriginal()
    {
        // Act
        var result = YANEnumerable.Clean(1, 2, 3)!.ToList();

        // Assert
        Assert.Equal(3, result.Count);
        Assert.Equal([1, 2, 3], result);
    }

    [Fact]
    public void Clean_Params_WithNullableValueTypeParams_RemovesNullElements()
    {
        // Act
        var result = YANEnumerable.Clean<int?>(1, null, 2, null, 3)!.ToList();

        // Assert
        Assert.Equal(3, result.Count);
        Assert.Equal([1, 2, 3], result);
    }
    #endregion

    #region Cleans List
    [Fact]
    public void Cleans_List_WithNullInput_DoesNothing()
    {
        // Arrange
        List<IEnumerable<int>?>? input = null;

        // Act
        input.Cleans();

        // Assert
        Assert.Null(input);
    }

    [Fact]
    public void Cleans_List_WithEmptyInput_DoesNothing()
    {
        // Arrange
        var input = new List<IEnumerable<int>?>();

        // Act
        input.Cleans();

        // Assert
        Assert.Empty(input);
    }

    [Fact]
    public void Cleans_List_WithNullElements_RemovesNullElements()
    {
        // Arrange
        var input = new List<IEnumerable<int>?>
        {
            new List<int> { 1, 2 },
            null,
            new List<int> { 3, 4 }
        };

        // Act
        input.Cleans();

        // Assert
        Assert.Equal(2, input.Count);
        Assert.Equal([1, 2], input[0]);
        Assert.Equal([3, 4], input[1]);
    }

    [Fact]
    public void Cleans_List_WithEmptyElements_RemovesEmptyElements()
    {
        // Arrange
        var input = new List<IEnumerable<int>?>
        {
            new List<int> { 1, 2 },
            new List<int>(),
            new List<int> { 3, 4 }
        };

        // Act
        input.Cleans();

        // Assert
        Assert.Equal(2, input.Count);
        Assert.Equal([1, 2], input[0]);
        Assert.Equal([3, 4], input[1]);
    }

    [Fact]
    public void Cleans_List_WithDeepCleanTrue_CleansNestedCollections()
    {
        // Arrange
        var input = new List<IEnumerable<int?>?>
        {
            new List<int?> { 1, null, 2 },
            null,
            new List<int?> { 3, null, 4 }
        };

        // Act
        input.Cleans(true);

        // Assert
        Assert.Equal(2, input.Count);
        Assert.Equal([1, 2], input[0]);
        Assert.Equal([3, 4], input[1]);
    }

    [Fact]
    public void Cleans_List_WithDeepCleanFalse_OnlyRemovesNullOrEmptyCollections()
    {
        // Arrange
        var input = new List<IEnumerable<int?>?>
        {
            new List<int?> { 1, null, 2 },
            null,
            new List<int?> { 3, null, 4 }
        };

        // Act
        input.Cleans(false);

        // Assert
        Assert.Equal(2, input.Count);
        Assert.Equal([1, null, 2], input[0]);
        Assert.Equal([3, null, 4], input[1]);
    }
    #endregion

    #region Cleans IEnumerable
    [Fact]
    public void Cleans_IEnumerable_WithNullInput_ReturnsNull()
    {
        // Arrange
        IEnumerable<IEnumerable<int>?>? input = null;

        // Act
        var result = input.Cleans();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Cleans_IEnumerable_WithEmptyInput_ReturnsEmpty()
    {
        // Arrange
        IEnumerable<IEnumerable<int>?> input = [];

        // Act
        var result = input.Cleans();

        // Assert
        Assert.Empty(result!);
    }

    [Fact]
    public void Cleans_IEnumerable_WithNullElements_RemovesNullElements()
    {
        // Arrange
        IEnumerable<IEnumerable<int>?> input = [
            [1, 2],
            null,
            [3, 4]
        ];

        // Act
        var result = input.Cleans()!.ToList();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal([1, 2], result[0]);
        Assert.Equal([3, 4], result[1]);
    }

    [Fact]
    public void Cleans_IEnumerable_WithEmptyElements_RemovesEmptyElements()
    {
        // Arrange
        IEnumerable<IEnumerable<int>?> input = [
            [1, 2],
            [],
            [3, 4]
        ];

        // Act
        var result = input.Cleans()!.ToList();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal([1, 2], result[0]);
        Assert.Equal([3, 4], result[1]);
    }

    [Fact]
    public void Cleans_IEnumerable_WithDeepCleanTrue_CleansNestedCollections()
    {
        // Arrange
        IEnumerable<IEnumerable<int?>?> input = [
            [1, null, 2],
            null,
            [3, null, 4]
        ];

        // Act
        var result = input.Cleans(true)!.ToList();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal([1, 2], result[0]);
        Assert.Equal([3, 4], result[1]);
    }

    [Fact]
    public void Cleans_IEnumerable_WithDeepCleanFalse_OnlyRemovesNullOrEmptyCollections()
    {
        // Arrange
        IEnumerable<IEnumerable<int?>?> input = [
            [1, null, 2],
            null,
            [3, null, 4]
        ];

        // Act
        var result = input.Cleans(false)!.ToList();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal([1, null, 2], result[0]);
        Assert.Equal([3, null, 4], result[1]);
    }
    #endregion

    #region Clean string
    [Fact]
    public void Clean_String_IEnumerable_WithNullInput_ReturnsNull()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.Clean();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Clean_String_IEnumerable_WithEmptyInput_ReturnsEmpty()
    {
        // Arrange
        IEnumerable<string?> input = [];

        // Act
        var result = input.Clean();

        // Assert
        Assert.Empty(result!);
    }

    [Fact]
    public void Clean_String_IEnumerable_RemovesNullWhiteSpaceAndEmptyStrings()
    {
        // Arrange
        IEnumerable<string?> input = ["value1", null, "", "  ", "value2"];

        // Act
        var result = input.Clean()!.ToList();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal(["value1", "value2"], result);
    }

    [Fact]
    public void Clean_String_Params_WithNullInput_ReturnsNull()
    {
        // Arrange
        string?[]? input = null;

        // Act
        var result = YANEnumerable.Clean(input);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Clean_String_Params_WithEmptyInput_ReturnsEmpty()
    {
        // Arrange
        string?[] input = [];

        // Act
        var result = YANEnumerable.Clean(input);

        // Assert
        Assert.Empty(result!);
    }

    [Fact]
    public void Clean_String_Params_RemovesNullWhiteSpaceAndEmptyStrings()
    {
        // Act
        var result = YANEnumerable.Clean("value1", null, "", "  ", "value2")!.ToList();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal(["value1", "value2"], result);
    }
    #endregion

    #region Cleans string
    [Fact]
    public void Cleans_String_List_WithNullInput_DoesNothing()
    {
        // Arrange
        List<IEnumerable<string?>?>? input = null;

        // Act
        input.Cleans();

        // Assert
        Assert.Null(input);
    }

    [Fact]
    public void Cleans_String_List_WithEmptyInput_DoesNothing()
    {
        // Arrange
        var input = new List<IEnumerable<string?>?>();

        // Act
        input.Cleans();

        // Assert
        Assert.Empty(input);
    }

    [Fact]
    public void Cleans_String_List_RemovesNullAndEmptyCollections()
    {
        // Arrange
        var input = new List<IEnumerable<string?>?>
        {
            new List<string?> { "value1", "value2" },
            null,
            new List<string?>()
        };

        // Act
        input.Cleans();

        // Assert
        _ = Assert.Single(input);
        Assert.Equal(["value1", "value2"], input[0]);
    }

    [Fact]
    public void Cleans_String_List_WithDeepCleanTrue_CleansNestedCollections()
    {
        // Arrange
        var input = new List<IEnumerable<string?>?>
        {
            new List<string?> { "value1", null, "", "  ", "value2" },
            null,
            new List<string?> { "value3", null, "value4" }
        };

        // Act
        input.Cleans(true);

        // Assert
        Assert.Equal(2, input.Count);
        Assert.Equal(["value1", "value2"], input[0]);
        Assert.Equal(["value3", "value4"], input[1]);
    }

    [Fact]
    public void Cleans_String_List_WithDeepCleanFalse_OnlyRemovesNullOrEmptyCollections()
    {
        // Arrange
        var input = new List<IEnumerable<string?>?>
        {
            new List<string?> { "value1", null, "", "  ", "value2" },
            null,
            new List<string?> { "value3", null, "value4" }
        };

        // Act
        input.Cleans(false);

        // Assert
        Assert.Equal(2, input.Count);
        Assert.Equal(["value1", null, "", "  ", "value2"], input[0]);
        Assert.Equal(["value3", null, "value4"], input[1]);
    }

    [Fact]
    public void Cleans_String_IEnumerable_WithNullInput_ReturnsNull()
    {
        // Arrange
        IEnumerable<IEnumerable<string?>?>? input = null;

        // Act
        var result = input.Cleans();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Cleans_String_IEnumerable_WithEmptyInput_ReturnsEmpty()
    {
        // Arrange
        IEnumerable<IEnumerable<string?>?> input = [];

        // Act
        var result = input.Cleans();

        // Assert
        Assert.Empty(result!);
    }

    [Fact]
    public void Cleans_String_IEnumerable_RemovesNullAndEmptyCollections()
    {
        // Arrange
        IEnumerable<IEnumerable<string?>?> input = [
            ["value1", "value2"],
            null,
            []
        ];

        // Act
        var result = input.Cleans()!.ToList();

        // Assert
        _ = Assert.Single(result);
        Assert.Equal(["value1", "value2"], result[0]);
    }

    [Fact]
    public void Cleans_String_IEnumerable_WithDeepCleanTrue_CleansNestedCollections()
    {
        // Arrange
        IEnumerable<IEnumerable<string?>?> input = [
            ["value1", null, "", "  ", "value2"],
            null,
            ["value3", null, "value4"]
        ];

        // Act
        var result = input.Cleans(true)!.ToList();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal(["value1", "value2"], result[0]);
        Assert.Equal(["value3", "value4"], result[1]);
    }

    [Fact]
    public void Cleans_String_IEnumerable_WithDeepCleanFalse_OnlyRemovesNullOrEmptyCollections()
    {
        // Arrange
        IEnumerable<IEnumerable<string?>?> input = [
            ["value1", null, "", "  ", "value2"],
            null,
            ["value3", null, "value4"]
        ];

        // Act
        var result = input.Cleans(false)!.ToList();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal(["value1", null, "", "  ", "value2"], result[0]);
        Assert.Equal(["value3", null, "value4"], result[1]);
    }
    #endregion
}
