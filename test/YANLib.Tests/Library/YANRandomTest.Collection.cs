using System.Collections;

namespace YANLib.Tests.Library;

public partial class YANRandomTest
{
    #region GenerateRandoms

    [Fact]
    public void GenerateRandoms_Int_WithSize_ReturnsCollectionOfSpecifiedSize_RandomCollection()
    {
        // Arrange
        var size = 10;

        // Act
        var result = YANRandom.GenerateRandoms<int>(size: size).ToList();

        // Assert
        Assert.Equal(size, result.Count);
        Assert.All(result, static item => Assert.IsType<int>(item));
    }

    [Fact]
    public void GenerateRandoms_Double_WithMinMaxSize_ReturnsCollectionInRange_RandomCollection()
    {
        // Arrange
        var min = -100.5;
        var max = 100.5;
        var size = 10;

        // Act
        var result = YANRandom.GenerateRandoms<double>(min, max, size).ToList();

        // Assert
        Assert.Equal(size, result.Count);
        Assert.All(result, item => Assert.True(item >= min && item <= max));
    }

    [Fact]
    public void GenerateRandoms_DateTime_WithSize_ReturnsCollectionOfRandomDates_RandomCollection()
    {
        // Arrange
        var size = 10;

        // Act
        var result = YANRandom.GenerateRandoms<DateTime>(size: size).ToList();

        // Assert
        Assert.Equal(size, result.Count);
        Assert.All(result, static item => Assert.IsType<DateTime>(item));
    }

    [Fact]
    public void GenerateRandoms_ZeroSize_ReturnsEmptyCollection_RandomCollection()
    {
        // Arrange
        var size = 0;

        // Act
        var result = YANRandom.GenerateRandoms<int>(size: size).ToList();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GenerateRandoms_LargeSize_UsesParallelProcessing_RandomCollection()
    {
        // Arrange
        var size = 2000;

        // Act
        var result = YANRandom.GenerateRandoms<int>(size: size).ToList();

        // Assert
        Assert.Equal(size, result.Count);
    }

    [Fact]
    public void GenerateRandoms_NullCollection_ReturnsEmptyCollection_RandomCollection()
    {
        // Arrange
        IEnumerable<int>? collection = null;
        var size = 5;

        // Act
        var result = collection.GenerateRandoms(size).ToList();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GenerateRandoms_EmptyCollection_ReturnsEmptyCollection_RandomCollection()
    {
        // Arrange
        var collection = Array.Empty<int>();
        var size = 5;

        // Act
        var result = collection.GenerateRandoms(size).ToList();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GenerateRandoms_CollectionWithSize_ReturnsCollectionOfSpecifiedSize_RandomCollection()
    {
        // Arrange
        var collection = new[] { 1, 2, 3, 4, 5 };
        var size = 10;

        // Act
        var result = collection.GenerateRandoms(size).ToList();

        // Assert
        Assert.Equal(size, result.Count);
        Assert.All(result, item => Assert.Contains(item, collection));
    }

    [Fact]
    public void GenerateRandoms_CollectionWithSizeNoDuplicates_ReturnsCollectionWithoutDuplicates_RandomCollection()
    {
        // Arrange
        var collection = new[] { 1, 2, 3, 4, 5 };
        var size = 5;

        // Act
        var result = collection.GenerateRandoms(size, allowDuplicates: false).ToList();

        // Assert
        Assert.Equal(size, result.Count);
        Assert.Equal(result.Count, result.Distinct().Count());
        Assert.All(result, item => Assert.Contains(item, collection));
    }

    [Fact]
    public void GenerateRandoms_CollectionWithSizeGreaterThanCollectionNoDuplicates_ReturnsCollectionOfMaxPossibleSize_RandomCollection()
    {
        // Arrange
        var collection = new[] { 1, 2, 3, 4, 5 };
        var size = 10;

        // Act
        var result = collection.GenerateRandoms(size, allowDuplicates: false).ToList();

        // Assert
        Assert.Equal(collection.Length, result.Count);
        Assert.Equal(result.Count, result.Distinct().Count());
        Assert.All(result, item => Assert.Contains(item, collection));
    }

    [Fact]
    public void GenerateRandoms_CollectionWithZeroSize_ReturnsEmptyCollection_RandomCollection()
    {
        // Arrange
        var collection = new[] { 1, 2, 3, 4, 5 };
        var size = 0;

        // Act
        var result = collection.GenerateRandoms(size).ToList();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GenerateRandoms_CollectionWithLargeSize_UsesParallelProcessing_RandomCollection()
    {
        // Arrange
        var collection = Enumerable.Range(1, 100).ToArray();
        var size = 2000;

        // Act
        var result = collection.GenerateRandoms(size).ToList();

        // Assert
        Assert.Equal(size, result.Count);
        Assert.All(result, item => Assert.Contains(item, collection));
    }

    [Fact]
    public void GenerateRandoms_DateTimeCollection_ReturnsRandomDatesFromCollection_RandomCollection()
    {
        // Arrange
        var collection = new[]
        {
            new DateTime(2020, 1, 1),
            new DateTime(2021, 1, 1),
            new DateTime(2022, 1, 1),
            new DateTime(2023, 1, 1)
        };

        var size = 10;

        // Act
        var result = collection.GenerateRandoms(size).ToList();

        // Assert
        Assert.Equal(size, result.Count);
        Assert.All(result, item => Assert.Contains(item, collection));
    }

    [Fact]
    public void GenerateRandoms_NullNonGenericCollection_ReturnsEmptyCollection_RandomCollection()
    {
        // Arrange
        IEnumerable? collection = null;
        var size = 5;

        // Act
        var result = collection.GenerateRandoms<int>(size).ToList();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GenerateRandoms_EmptyNonGenericCollection_ReturnsEmptyCollection_RandomCollection()
    {
        // Arrange
        var collection = new ArrayList();
        var size = 5;

        // Act
        var result = collection.GenerateRandoms<int>(size).ToList();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GenerateRandoms_NonGenericCollectionWithSize_ReturnsCollectionOfSpecifiedSize_RandomCollection()
    {
        // Arrange
        var collection = new ArrayList { 1, 2, 3, 4, 5 };
        var size = 10;

        // Act
        var result = collection.GenerateRandoms<int>(size).ToList();

        // Assert
        Assert.Equal(size, result.Count);
        Assert.All(result, item => Assert.Contains(item, collection.Cast<object>().Select(o => (int)o)));
    }

    [Fact]
    public void GenerateRandoms_NonGenericCollectionWithSizeNoDuplicates_ReturnsCollectionWithoutDuplicates_RandomCollection()
    {
        // Arrange
        var collection = new ArrayList { 1, 2, 3, 4, 5 };
        var size = 5;

        // Act
        var result = collection.GenerateRandoms<int>(size, allowDuplicates: false).ToList();

        // Assert
        Assert.Equal(size, result.Count);
        Assert.Equal(result.Count, result.Distinct().Count());
        Assert.All(result, item => Assert.Contains(item, collection.Cast<object>().Select(o => (int)o)));
    }

    [Fact]
    public void GenerateRandoms_NonGenericCollectionWithSizeGreaterThanCollectionNoDuplicates_ReturnsCollectionOfMaxPossibleSize_RandomCollection()
    {
        // Arrange
        var collection = new ArrayList { 1, 2, 3, 4, 5 };
        var size = 10;

        // Act
        var result = collection.GenerateRandoms<int>(size, allowDuplicates: false).ToList();

        // Assert
        Assert.Equal(collection.Count, result.Count);
        Assert.Equal(result.Count, result.Distinct().Count());
        Assert.All(result, item => Assert.Contains(item, collection.Cast<object>().Select(o => (int)o)));
    }

    [Fact]
    public void GenerateRandoms_NonGenericCollectionWithZeroSize_ReturnsEmptyCollection_RandomCollection()
    {
        // Arrange
        var collection = new ArrayList { 1, 2, 3, 4, 5 };
        var size = 0;

        // Act
        var result = collection.GenerateRandoms<int>(size).ToList();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GenerateRandoms_MixedTypeNonGenericCollection_ReturnsOnlyMatchingTypes_RandomCollection()
    {
        // Arrange
        var collection = new ArrayList { 1, "two", 3, "four", 5 };
        var size = 10;
        var expected = new[] { 1, 3, 5, default };

        // Act
        var result = collection.GenerateRandoms<int>(size).ToList();

        // Assert
        Assert.Equal(size, result.Count);
        Assert.All(result, item => Assert.Contains(item, expected));
    }

    [Fact]
    public void GenerateRandoms_NonGenericCollectionWithLargeSize_UsesParallelProcessing_RandomCollection()
    {
        // Arrange
        var collection = new ArrayList();

        for (var i = 1; i <= 100; i++)
        {
            _ = collection.Add(i);
        }

        var size = 2000;

        // Act
        var result = collection.GenerateRandoms<int>(size).ToList();

        // Assert
        Assert.Equal(size, result.Count);
        Assert.All(result, item => Assert.Contains(item, collection.Cast<object>().Select(o => (int)o)));
    }

    #endregion
}
