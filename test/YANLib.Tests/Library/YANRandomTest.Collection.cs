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

    #endregion
}
