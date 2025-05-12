namespace YANLib.Tests.Library;

public partial class YANRandomTest
{
    #region GenerateRandom

    [Fact]
    public void GenerateRandom_NullObjectCollection_ReturnsDefault_RandomGeneric()
    {
        // Arrange
        IEnumerable<object?>? collection = null;

        // Act
        var result = collection.GenerateRandom<int>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void GenerateRandom_EmptyObjectCollection_ReturnsDefault_RandomGeneric()
    {
        // Arrange
        var collection = Array.Empty<object?>();

        // Act
        var result = collection.GenerateRandom<int>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void GenerateRandom_SingleItemObjectCollection_ReturnsParsedItem_RandomGeneric()
    {
        // Arrange
        var collection = new object?[] { "42" };

        // Act
        var result = collection.GenerateRandom<int>();

        // Assert
        Assert.Equal(42, result);
    }

    [Fact]
    public void GenerateRandom_MultipleItemObjectCollection_ReturnsParsedItemFromCollection_RandomGeneric()
    {
        // Arrange
        var collection = new object?[] { "1", "2", "3", "4", "5" };
        var expectedValues = new[] { 1, 2, 3, 4, 5 };

        // Act
        var result = collection.GenerateRandom<int>();

        // Assert
        Assert.Contains(result, expectedValues);
    }

    [Fact]
    public void GenerateRandom_MixedTypeObjectCollection_ReturnsParsedItemFromCollection_RandomGeneric()
    {
        // Arrange
        var collection = new object?[] { "1", 2, "3.5", 4.5, null };
        var expectedValues = new[] { 1, 2, 3, 4, 0 };

        // Act
        var result = collection.GenerateRandom<int>();

        // Assert
        Assert.Contains(result, expectedValues);
    }

    [Fact]
    public void GenerateRandom_ObjectCollectionToFloat_ReturnsParsedItemFromCollection_RandomGeneric()
    {
        // Arrange
        var collection = new object?[] { "1.1", 2.2, "3.3", 4.4 };
        var expectedValues = new[] { 1.1f, 2.2f, 3.3f, 4.4f };

        // Act
        var result = collection.GenerateRandom<float>();

        // Assert
        Assert.Contains(result, expectedValues);
    }

    [Fact]
    public void GenerateRandom_ObjectCollectionToDateTime_ReturnsParsedItemFromCollection_RandomGeneric()
    {
        // Arrange
        var date1 = new DateTime(2020, 1, 1);
        var date2 = new DateTime(2021, 1, 1);
        var collection = new object?[] { date1, "2022-01-01", date2 };

        var expectedValues = new[]
        {
            date1,
            date2,
            new DateTime(2022, 1, 1)
        };

        // Act
        var result = collection.GenerateRandom<DateTime>();

        // Assert
        Assert.Contains(result, expectedValues);
    }

    [Fact]
    public void GenerateRandom_MultipleCallsReturnDifferentValues_RandomGeneric()
    {
        // Arrange
        var collection = new object?[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
        var results = new HashSet<int>();

        // Act
        for (var i = 0; i < 50; i++)
        {
            _ = results.Add(collection.GenerateRandom<int>());
        }

        // Assert
        Assert.True(results.Count >= 3);
    }

    [Fact]
    public void GenerateRandom_NullObjectParams_ReturnsDefault_RandomGenericParams()
    {
        // Arrange
        object?[]? parameters = null;

        // Act
        var result = YANRandom.GenerateRandom<int>(parameters);

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void GenerateRandom_EmptyObjectParams_ReturnsDefault_RandomGenericParams()
    {
        // Act
        var result = YANRandom.GenerateRandom(Array.Empty<int>());

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void GenerateRandom_SingleItemObjectParams_ReturnsParsedItem_RandomGenericParams()
    {
        // Act
        var result = YANRandom.GenerateRandom<int>(["42"]);

        // Assert
        Assert.Equal(42, result);
    }

    [Fact]
    public void GenerateRandom_MultipleItemObjectParams_ReturnsParsedItemFromParams_RandomGenericParams()
    {
        // Arrange
        var expectedValues = new[] { 1, 2, 3, 4, 5 };

        // Act
        var result = YANRandom.GenerateRandom<int>("1", "2", "3", "4", "5");

        // Assert
        Assert.Contains(result, expectedValues);
    }

    [Fact]
    public void GenerateRandom_MixedTypeObjectParams_ReturnsParsedItemFromParams_RandomGenericParams()
    {
        // Arrange
        var expectedValues = new[] { 1, 2, 3, 4, 0 };

        // Act
        var result = YANRandom.GenerateRandom<int>("1", 2, "3.5", 4.5, null);

        // Assert
        Assert.Contains(result, expectedValues);
    }

    [Fact]
    public void GenerateRandom_ObjectParamsToFloat_ReturnsParsedItemFromParams_RandomGenericParams()
    {
        // Arrange
        var expectedValues = new[] { 1.1f, 2.2f, 3.3f, 4.4f };

        // Act
        var result = YANRandom.GenerateRandom<float>("1.1", 2.2, "3.3", 4.4);

        // Assert
        Assert.Contains(result, expectedValues);
    }

    [Fact]
    public void GenerateRandom_ObjectParamsToDateTime_ReturnsParsedItemFromParams_RandomGenericParams()
    {
        // Arrange
        var date1 = new DateTime(2020, 1, 1);
        var date2 = new DateTime(2021, 1, 1);

        var expectedValues = new[]
        {
            date1,
            date2,
            new DateTime(2022, 1, 1)
        };

        // Act
        var result = YANRandom.GenerateRandom<DateTime>(date1, "2022-01-01", date2);

        // Assert
        Assert.Contains(result, expectedValues);
    }

    [Fact]
    public void GenerateRandom_MultipleCallsReturnDifferentValues_RandomGenericParams()
    {
        // Arrange
        var parameters = new object?[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
        var results = new HashSet<int>();

        // Act
        for (var i = 0; i < 50; i++)
        {
            _ = results.Add(YANRandom.GenerateRandom<int>(parameters));
        }

        // Assert
        Assert.True(results.Count >= 3);
    }

    #endregion
}
