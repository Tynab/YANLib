namespace YANLib.Tests.Library;

public partial class YANRandomTest
{
    #region GenerateRandoms

    [Fact]
    public void GenerateRandoms_NullObjectCollection_ReturnsEmptyCollection_RandomGenericCollection()
    {
        // Arrange
        IEnumerable<object?>? collection = null;
        var size = 5;

        // Act
        var result = collection.GenerateRandoms<int>(size).ToList();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GenerateRandoms_EmptyObjectCollection_ReturnsEmptyCollection_RandomGenericCollection()
    {
        // Arrange
        var collection = Array.Empty<object?>();
        var size = 5;

        // Act
        var result = collection.GenerateRandoms<int>(size).ToList();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GenerateRandoms_ObjectCollectionWithSize_ReturnsCollectionOfSpecifiedSize_RandomGenericCollection()
    {
        // Arrange
        var collection = new object?[] { "1", 2, "3", 4, "5" };
        var size = 10;
        var expected = new[] { 1, 2, 3, 4, 5 };

        // Act
        var result = collection.GenerateRandoms<int>(size).ToList();

        // Assert
        Assert.Equal(size, result.Count);
        Assert.All(result, item => Assert.Contains(item, expected));
    }

    [Fact]
    public void GenerateRandoms_ObjectCollectionWithSizeNoDuplicates_ReturnsCollectionWithoutDuplicates_RandomGenericCollection()
    {
        // Arrange
        var collection = new object?[] { "1", 2, "3", 4, "5" };
        var size = 5;
        var expected = new[] { 1, 2, 3, 4, 5 };

        // Act
        var result = collection.GenerateRandoms<int>(size, allowDuplicates: false).ToList();

        // Assert
        Assert.Equal(size, result.Count);
        Assert.Equal(result.Count, result.Distinct().Count());
        Assert.All(result, item => Assert.Contains(item, expected));
    }

    [Fact]
    public void GenerateRandoms_ObjectCollectionWithSizeGreaterThanCollectionNoDuplicates_ReturnsCollectionOfMaxPossibleSize_RandomGenericCollection()
    {
        // Arrange
        var collection = new object?[] { "1", 2, "3", 4, "5" };
        var size = 10;
        var expected = new[] { 1, 2, 3, 4, 5 };

        // Act
        var result = collection.GenerateRandoms<int>(size, allowDuplicates: false).ToList();

        // Assert
        Assert.Equal(collection.Length, result.Count);
        Assert.Equal(result.Count, result.Distinct().Count());
        Assert.All(result, item => Assert.Contains(item, expected));
    }

    [Fact]
    public void GenerateRandoms_ObjectCollectionWithZeroSize_ReturnsEmptyCollection_RandomGenericCollection()
    {
        // Arrange
        var collection = new object?[] { "1", 2, "3", 4, "5" };
        var size = 0;

        // Act
        var result = collection.GenerateRandoms<int>(size).ToList();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GenerateRandoms_ObjectCollectionWithLargeSize_UsesParallelProcessing_RandomGenericCollection()
    {
        // Arrange
        var collection = new List<object?>();

        for (var i = 1; i <= 100; i++)
        {
            collection.Add(i);
        }

        var size = 2000;

        // Act
        var result = collection.GenerateRandoms<int>(size).ToList();

        // Assert
        Assert.Equal(size, result.Count);
        Assert.All(result, static item => Assert.InRange(item, 1, 100));
    }

    [Fact]
    public void GenerateRandoms_MixedTypeObjectCollection_ReturnsParsedValues_RandomGenericCollection()
    {
        // Arrange
        var collection = new object?[] { "1", 2.5, "3.7", 4, null, "invalid" };
        var size = 10;
        var expected = new[] { 1, 2, 3, 4, default };

        // Act
        var result = collection.GenerateRandoms<int>(size).ToList();

        // Assert
        Assert.Equal(size, result.Count);
        Assert.All(result, item => Assert.Contains(item, expected));
    }

    [Fact]
    public void GenerateRandoms_ObjectCollectionToFloat_ReturnsParsedValues_RandomGenericCollection()
    {
        // Arrange
        var collection = new object?[] { "1.1", 2.2, "3.3", 4 };
        var size = 10;
        var expectedValues = new[] { 1.1f, 2.2f, 3.3f, 4f };

        // Act
        var result = collection.GenerateRandoms<float>(size).ToList();

        // Assert
        Assert.Equal(size, result.Count);
        Assert.All(result, item => Assert.Contains(item, expectedValues));
    }

    [Fact]
    public void GenerateRandoms_ObjectCollectionToDateTime_ReturnsParsedValues_RandomGenericCollection()
    {
        // Arrange
        var date1 = new DateTime(2020, 1, 1);
        var date2 = new DateTime(2021, 1, 1);
        var collection = new object?[] { date1, "2022-01-01", date2 };
        var size = 10;

        var expectedValues = new[]
        {
            date1,
            date2,
            new DateTime(2022, 1, 1)
        };

        // Act
        var result = collection.GenerateRandoms<DateTime>(size).ToList();

        // Assert
        Assert.Equal(size, result.Count);
        Assert.All(result, item => Assert.Contains(item, expectedValues));
    }

    [Fact]
    public void GenerateRandoms_ObjectCollectionWithAllInvalidValues_ReturnsDefaultValues_RandomGenericCollection()
    {
        // Arrange
        var collection = new object?[] { "invalid", "also invalid", null };
        var size = 5;

        // Act
        var result = collection.GenerateRandoms<int>(size).ToList();

        // Assert
        Assert.Equal(size, result.Count);
        Assert.All(result, static item => Assert.Equal(0, item));
    }

    [Fact]
    public void GenerateRandoms_ObjectCollectionToBool_ReturnsParsedValues_RandomGenericCollection()
    {
        // Arrange
        var collection = new object?[] { "true", false, "True", "1", 0 };
        var size = 10;

        // Act
        var result = collection.GenerateRandoms<bool>(size).ToList();

        // Assert
        Assert.Equal(size, result.Count);
        Assert.All(result, static item => Assert.IsType<bool>(item));
    }

    #endregion
}
