namespace YANLib.Tests.Library;

public partial class YANRandomTest
{
    #region GenerateRandoms

    [Fact]
    public void GenerateRandoms_NullableInt_WithSize_ReturnsCollectionOfSpecifiedSize_RandomNullableCollection()
    {
        // Arrange
        var size = 10;

        // Act
        var result = YANRandom.GenerateRandoms<int?>(size).ToList();

        // Assert
        Assert.Equal(size, result.Count);
        Assert.All(result, item => Assert.IsType<int>(item));
    }

    [Fact]
    public void GenerateRandoms_NullableDateTime_WithSize_ReturnsCollectionOfRandomDates_RandomNullableCollection()
    {
        // Arrange
        var size = 10;

        // Act
        var result = YANRandom.GenerateRandoms<DateTime?>(size).ToList();

        // Assert
        Assert.Equal(size, result.Count);
        Assert.All(result, item => Assert.IsType<DateTime>(item));
    }

    [Fact]
    public void GenerateRandoms_String_WithSize_ReturnsCollectionOfRandomStrings_RandomNullableCollection()
    {
        // Arrange
        var size = 10;

        // Act
        var result = YANRandom.GenerateRandoms<string>(size).ToList();

        // Assert
        Assert.Equal(size, result.Count);
        Assert.All(result, item =>
        {
            _ = Assert.IsType<string>(item);
            Assert.NotNull(item);
            Assert.True(item.All(c => char.IsLower(c) && char.IsLetter(c)));
        });
    }

    [Fact]
    public void GenerateRandoms_ZeroSize_ReturnsEmptyCollection_RandomNullableCollection()
    {
        // Arrange
        var size = 0;

        // Act
        var result = YANRandom.GenerateRandoms<int?>(size).ToList();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GenerateRandoms_LargeSize_UsesParallelProcessing_RandomNullableCollection()
    {
        // Arrange
        var size = 2000;

        // Act
        var result = YANRandom.GenerateRandoms<int?>(size).ToList();

        // Assert
        Assert.Equal(size, result.Count);
    }

    [Fact]
    public void GenerateRandoms_NullableDouble_WithSize_ReturnsCollectionOfRandomDoubles_RandomNullableCollection()
    {
        // Arrange
        var size = 10;

        // Act
        var result = YANRandom.GenerateRandoms<double?>(size).ToList();

        // Assert
        Assert.Equal(size, result.Count);
        Assert.All(result, item =>
        {
            _ = Assert.IsType<double>(item);
            Assert.True(double.IsFinite((double)item));
        });
    }

    #endregion
}
