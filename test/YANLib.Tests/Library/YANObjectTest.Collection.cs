namespace YANLib.Tests.Library;

public partial class YANObjectTest
{
    #region AllNull

    [Fact]
    public void AllNull_NullCollection_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.AllNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNull_EmptyCollection_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<object?> input = [];

        // Act
        var result = input.AllNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNull_CollectionWithAllNulls_ReturnsTrue_ObjectCollection()
    {
        // Arrange
        IEnumerable<object?> input = [null, null, null];

        // Act
        var result = input.AllNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNull_CollectionWithSomeNulls_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<object?> input = [null, new(), null];

        // Act
        var result = input.AllNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNull_CollectionWithNoNulls_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<object?> input = [new(), new()];

        // Act
        var result = input.AllNull();

        // Assert
        Assert.False(result);
    }

    #endregion

    #region AnyNull

    [Fact]
    public void AnyNull_NullCollection_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.AnyNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNull_EmptyCollection_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<object?> input = [];

        // Act
        var result = input.AnyNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNull_CollectionWithSomeNulls_ReturnsTrue_ObjectCollection()
    {
        // Arrange
        IEnumerable<object?> input = [new(), null, new()];

        // Act
        var result = input.AnyNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNull_CollectionWithNoNulls_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<object?> input = [new(), new()];

        // Act
        var result = input.AnyNull();

        // Assert
        Assert.False(result);
    }

    #endregion

    #region AllNotNull

    [Fact]
    public void AllNotNull_NullCollection_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.AllNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNull_EmptyCollection_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<object?> input = [];

        // Act
        var result = input.AllNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNull_CollectionWithAllNonNulls_ReturnsTrue_ObjectCollection()
    {
        // Arrange
        IEnumerable<object?> input = [new(), new(), new()];

        // Act
        var result = input.AllNotNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNull_CollectionWithSomeNulls_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<object?> input = [new(), null, new()];

        // Act
        var result = input.AllNotNull();

        // Assert
        Assert.False(result);
    }

    #endregion

    #region AnyNotNull

    [Fact]
    public void AnyNotNull_NullCollection_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.AnyNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNull_EmptyCollection_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<object?> input = [];

        // Act
        var result = input.AnyNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNull_CollectionWithSomeNonNulls_ReturnsTrue_ObjectCollection()
    {
        // Arrange
        IEnumerable<object?> input = [null, new(), null];

        // Act
        var result = input.AnyNotNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNull_CollectionWithAllNulls_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<object?> input = [null, null, null];

        // Act
        var result = input.AnyNotNull();

        // Assert
        Assert.False(result);
    }

    #endregion

    #region AllDefault

    [Fact]
    public void AllDefault_NullCollection_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<int?>? input = null;

        // Act
        var result = input.AllDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllDefault_EmptyCollection_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<int?> input = [];

        // Act
        var result = input.AllDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllDefault_CollectionWithAllDefaults_ReturnsTrue_ObjectCollection()
    {
        // Arrange
        IEnumerable<int?> input = [0, 0, 0];

        // Act
        var result = input.AllDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllDefault_CollectionWithSomeDefaults_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<int?> input = [0, 1, 0];

        // Act
        var result = input.AllDefault();

        // Assert
        Assert.False(result);
    }

    #endregion

    #region AnyDefault

    [Fact]
    public void AnyDefault_NullCollection_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<int?>? input = null;

        // Act
        var result = input.AnyDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyDefault_EmptyCollection_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<int?> input = [];

        // Act
        var result = input.AnyDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyDefault_CollectionWithSomeDefaults_ReturnsTrue_ObjectCollection()
    {
        // Arrange
        IEnumerable<int?> input = [1, 0, 2];

        // Act
        var result = input.AnyDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyDefault_CollectionWithNoDefaults_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<int?> input = [1, 2, 3];

        // Act
        var result = input.AnyDefault();

        // Assert
        Assert.False(result);
    }

    #endregion

    #region AllNotDefault

    [Fact]
    public void AllNotDefault_NullCollection_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<int?>? input = null;

        // Act
        var result = input.AllNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotDefault_EmptyCollection_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<int?> input = [];

        // Act
        var result = input.AllNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotDefault_CollectionWithAllNonDefaults_ReturnsTrue_ObjectCollection()
    {
        // Arrange
        IEnumerable<int?> input = [1, 2, 3];

        // Act
        var result = input.AllNotDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotDefault_CollectionWithSomeDefaults_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<int?> input = [1, 0, 3];

        // Act
        var result = input.AllNotDefault();

        // Assert
        Assert.False(result);
    }

    #endregion

    #region AnyNotDefault

    [Fact]
    public void AnyNotDefault_NullCollection_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<int?>? input = null;

        // Act
        var result = input.AnyNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotDefault_EmptyCollection_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<int?> input = [];

        // Act
        var result = input.AnyNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotDefault_CollectionWithSomeNonDefaults_ReturnsTrue_ObjectCollection()
    {
        // Arrange
        IEnumerable<int?> input = [0, 1, 0];

        // Act
        var result = input.AnyNotDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotDefault_CollectionWithAllDefaults_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<int?> input = [0, 0, 0];

        // Act
        var result = input.AnyNotDefault();

        // Assert
        Assert.False(result);
    }

    #endregion

    #region AllNullEmpty

    [Fact]
    public void AllNullEmpty_NullCollection_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<TestClass?>? input = null;

        // Act
        var result = input.AllNullDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_EmptyCollection_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<TestClass?> input = [];

        // Act
        var result = input.AllNullDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_CollectionWithAllNullOrEmptyObjects_ReturnsTrue_ObjectCollection()
    {
        // Arrange
        IEnumerable<TestClass?> input = [null, new()];

        // Act
        var result = input.AllNullDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNullEmpty_CollectionWithSomeNonEmptyObjects_ReturnsFalse_ObjectCollection()
    {
        // Arrange
        IEnumerable<TestClass?> input = [null, new() { Value = "test" }];

        // Act
        var result = input.AllNullDefault();

        // Assert
        Assert.False(result);
    }

    #endregion

    #region ChangeTimeZoneAllProperties

    [Fact]
    public void ChangeTimeZoneAllProperties_NullCollection_ReturnsNull_ObjectCollection()
    {
        // Arrange
        IEnumerable<TestClass?>? input = null;

        // Act
        var result = input.ChangeTimeZoneAllProperties();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ChangeTimeZoneAllProperties_EmptyCollection_ReturnsEmptyCollection_ObjectCollection()
    {
        // Arrange
        IEnumerable<TestClass?> input = [];

        // Act
        var result = input.ChangeTimeZoneAllProperties();

        // Assert
        Assert.Empty(result!);
    }

    [Fact]
    public void ChangeTimeZoneAllProperties_CollectionWithDateTimeProperties_ChangesTimeZones_ObjectCollection()
    {
        // Arrange
        IEnumerable<DateTimeTestClass?> input =
        [
            new() { DateProperty = new DateTime(2023, 1, 1, 12, 0, 0, DateTimeKind.Utc), StringProperty = "test1" },
            new() { DateProperty = new DateTime(2023, 1, 2, 12, 0, 0, DateTimeKind.Utc), StringProperty = "test2" }
        ];

        var tzSrc = TimeSpan.Zero;
        var tzDst = TimeSpan.FromHours(7);

        // Act
        var result = input.ChangeTimeZoneAllProperties(tzSrc, tzDst)?.ToList();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Equal(new DateTime(2023, 1, 1, 19, 0, 0), result[0]!.DateProperty);
        Assert.Equal("test1", result[0]!.StringProperty);
        Assert.Equal(new DateTime(2023, 1, 2, 19, 0, 0), result[1]!.DateProperty);
        Assert.Equal("test2", result[1]!.StringProperty);
    }

    #endregion
}
