namespace YANLib.Tests.Library.Object;

public partial class YANObjectTest
{
    #region AllNull

    [Fact]
    public void AllNull_NullCollection_ReturnsFalse_Collection()
    {
        // Arrange
        IEnumerable<string?>? collection = null;

        // Act
        var result = collection.AllNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNull_EmptyCollection_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = Array.Empty<string?>();

        // Act
        var result = collection.AllNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNull_AllNullElements_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new string?[] { null, null, null };

        // Act
        var result = collection.AllNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNull_MixedElements_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = new string?[] { null, "test", null };

        // Act
        var result = collection.AllNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNull_ParamsOverload_AllNullElements_ReturnsTrue_Collection()
    {
        // Act
        var result = YANObject.AllNull<string?>(null, null, null);

        // Assert
        Assert.True(result);
    }

    #endregion

    #region AnyNull

    [Fact]
    public void AnyNull_NullCollection_ReturnsFalse_Collection()
    {
        // Arrange
        IEnumerable<string?>? collection = null;

        // Act
        var result = collection.AnyNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNull_EmptyCollection_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = Array.Empty<string?>();

        // Act
        var result = collection.AnyNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNull_NoNullElements_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = new string?[] { "a", "b", "c" };

        // Act
        var result = collection.AnyNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNull_SomeNullElements_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new string?[] { "a", null, "c" };

        // Act
        var result = collection.AnyNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNull_ParamsOverload_SomeNullElements_ReturnsTrue_Collection()
    {
        // Act
        var result = YANObject.AnyNull("a", null, "c");

        // Assert
        Assert.True(result);
    }

    #endregion

    #region AllNotNull

    [Fact]
    public void AllNotNull_NullCollection_ReturnsFalse_Collection()
    {
        // Arrange
        IEnumerable<string?>? collection = null;

        // Act
        var result = collection.AllNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNull_EmptyCollection_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = Array.Empty<string?>();

        // Act
        var result = collection.AllNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNull_AllNonNullElements_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new string?[] { "a", "b", "c" };

        // Act
        var result = collection.AllNotNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNull_MixedElements_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = new string?[] { "a", null, "c" };

        // Act
        var result = collection.AllNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNull_ParamsOverload_AllNonNullElements_ReturnsTrue_Collection()
    {
        // Act
        var result = YANObject.AllNotNull("a", "b", "c");

        // Assert
        Assert.True(result);
    }

    #endregion

    #region AnyNotNull

    [Fact]
    public void AnyNotNull_NullCollection_ReturnsFalse_Collection()
    {
        // Arrange
        IEnumerable<string?>? collection = null;

        // Act
        var result = collection.AnyNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNull_EmptyCollection_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = Array.Empty<string?>();

        // Act
        var result = collection.AnyNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNull_AllNullElements_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = new string?[] { null, null, null };

        // Act
        var result = collection.AnyNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNull_SomeNonNullElements_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new string?[] { null, "b", null };

        // Act
        var result = collection.AnyNotNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNull_ParamsOverload_SomeNonNullElements_ReturnsTrue_Collection()
    {
        // Act
        var result = YANObject.AnyNotNull(null, "b", null);

        // Assert
        Assert.True(result);
    }

    #endregion

    #region AllDefault

    [Fact]
    public void AllDefault_NullCollection_ReturnsFalse_Collection()
    {
        // Arrange
        IEnumerable<int?>? collection = null;

        // Act
        var result = collection.AllDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllDefault_EmptyCollection_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = Array.Empty<int?>();

        // Act
        var result = collection.AllDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllDefault_AllDefaultElements_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new int?[] { default, default, default };

        // Act
        var result = collection.AllDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllDefault_MixedElements_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = new int?[] { default, 42, default };

        // Act
        var result = collection.AllDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllDefault_ParamsOverload_AllDefaultElements_ReturnsTrue_Collection()
    {
        // Act
        var result = YANObject.AllDefault<int?>(default, default, default);

        // Assert
        Assert.True(result);
    }

    #endregion

    #region AnyDefault

    [Fact]
    public void AnyDefault_NullCollection_ReturnsFalse_Collection()
    {
        // Arrange
        IEnumerable<int?>? collection = null;

        // Act
        var result = collection.AnyDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyDefault_EmptyCollection_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = Array.Empty<int?>();

        // Act
        var result = collection.AnyDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyDefault_NoDefaultElements_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = new int?[] { 1, 2, 3 };

        // Act
        var result = collection.AnyDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyDefault_SomeDefaultElements_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new int?[] { 1, default, 3 };

        // Act
        var result = collection.AnyDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyDefault_ParamsOverload_SomeDefaultElements_ReturnsTrue_Collection()
    {
        // Act
        var result = YANObject.AnyDefault(1, default(int?), 3);

        // Assert
        Assert.True(result);
    }

    #endregion

    #region AllNotDefault

    [Fact]
    public void AllNotDefault_NullCollection_ReturnsFalse_Collection()
    {
        // Arrange
        IEnumerable<int?>? collection = null;

        // Act
        var result = collection.AllNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotDefault_EmptyCollection_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = Array.Empty<int?>();

        // Act
        var result = collection.AllNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotDefault_AllNonDefaultElements_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new int?[] { 1, 2, 3 };

        // Act
        var result = collection.AllNotDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotDefault_MixedElements_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = new int?[] { 1, default, 3 };

        // Act
        var result = collection.AllNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotDefault_ParamsOverload_AllNonDefaultElements_ReturnsTrue_Collection()
    {
        // Act
        var result = YANObject.AllNotDefault(1, 2, 3);

        // Assert
        Assert.True(result);
    }

    #endregion

    #region AnyNotDefault

    [Fact]
    public void AnyNotDefault_NullCollection_ReturnsFalse_Collection()
    {
        // Arrange
        IEnumerable<int?>? collection = null;

        // Act
        var result = collection.AnyNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotDefault_EmptyCollection_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = Array.Empty<int?>();

        // Act
        var result = collection.AnyNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotDefault_AllDefaultElements_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = new int?[] { default, default, default };

        // Act
        var result = collection.AnyNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotDefault_SomeNonDefaultElements_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new int?[] { default, 2, default };

        // Act
        var result = collection.AnyNotDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotDefault_ParamsOverload_SomeNonDefaultElements_ReturnsTrue_Collection()
    {
        // Act
        var result = YANObject.AnyNotDefault(default(int?), 2, default);

        // Assert
        Assert.True(result);
    }

    #endregion

    #region AllNullEmpty

    [Fact]
    public void AllNullEmpty_NullCollection_ReturnsFalse_Collection()
    {
        // Arrange
        IEnumerable<TestClass?>? collection = null;

        // Act
        var result = collection.AllNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_EmptyCollection_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = Array.Empty<TestClass?>();

        // Act
        var result = collection.AllNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_AllNullOrEmptyObjects_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new TestClass?[]
        {
            null,
            new(),
            null
        };

        // Act
        var result = collection.AllNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNullEmpty_MixedObjects_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = new TestClass?[]
        {
            null,
            new() { Id = 1, Name = "Test" },
            new()
        };

        // Act
        var result = collection.AllNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_ParamsOverload_AllNullOrEmptyObjects_ReturnsTrue_Collection()
    {
        // Act
        var result = YANObject.AllNullEmpty(null, new TestClass(), null);

        // Assert
        Assert.True(result);
    }

    #endregion

    #region AnyNullEmpty

    [Fact]
    public void AnyNullEmpty_NullCollection_ReturnsFalse_Collection()
    {
        // Arrange
        IEnumerable<TestClass?>? collection = null;

        // Act
        var result = collection.AnyNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullEmpty_EmptyCollection_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = Array.Empty<TestClass?>();

        // Act
        var result = collection.AnyNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullEmpty_NoNullOrEmptyObjects_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = new TestClass?[]
        {
            new() { Id = 1 },
            new() { Name = "Test" }
        };

        // Act
        var result = collection.AnyNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullEmpty_SomeNullOrEmptyObjects_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new TestClass?[]
        {
            new() { Id = 1 },
            null,
            new() { Name = "Test" }
        };

        // Act
        var result = collection.AnyNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullEmpty_ParamsOverload_SomeNullOrEmptyObjects_ReturnsTrue_Collection()
    {
        // Act
        var result = YANObject.AnyNullEmpty(new TestClass { Id = 1 }, null, new TestClass { Name = "Test" });

        // Assert
        Assert.True(result);
    }

    #endregion

    #region AllNotNullEmpty

    [Fact]
    public void AllNotNullEmpty_NullCollection_ReturnsFalse_Collection()
    {
        // Arrange
        IEnumerable<TestClass?>? collection = null;

        // Act
        var result = collection.AllNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullEmpty_EmptyCollection_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = Array.Empty<TestClass?>();

        // Act
        var result = collection.AllNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullEmpty_AllNonNullNonEmptyObjects_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new TestClass?[]
        {
            new() { Id = 1 },
            new() { Name = "Test" },
            new() { Id = 2, Name = "Test2" }
        };

        // Act
        var result = collection.AllNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNullEmpty_MixedObjects_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = new TestClass?[]
        {
            new() { Id = 1 },
            null,
            new() { Name = "Test" }
        };

        // Act
        var result = collection.AllNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullEmpty_ParamsOverload_AllNonNullNonEmptyObjects_ReturnsTrue_Collection()
    {
        // Act
        var result = YANObject.AllNotNullEmpty(new TestClass { Id = 1 }, new TestClass { Name = "Test" }, new TestClass { Id = 2, Name = "Test2" });

        // Assert
        Assert.True(result);
    }

    #endregion

    #region AnyNotNullEmpty

    [Fact]
    public void AnyNotNullEmpty_NullCollection_ReturnsFalse_Collection()
    {
        // Arrange
        IEnumerable<TestClass?>? collection = null;

        // Act
        var result = collection.AnyNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNullEmpty_EmptyCollection_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = Array.Empty<TestClass?>();

        // Act
        var result = collection.AnyNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNullEmpty_AllNullOrEmptyObjects_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = new TestClass?[]
        {
            null,
            new(),
            null
        };

        // Act
        var result = collection.AnyNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNullEmpty_SomeNonNullNonEmptyObjects_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new TestClass?[]
        {
            null,
            new() { Id = 1, Name = "Test" },
            new()
        };

        // Act
        var result = collection.AnyNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNullEmpty_ParamsOverload_SomeNonNullNonEmptyObjects_ReturnsTrue_Collection()
    {
        // Act
        var result = YANObject.AnyNotNullEmpty(null, new TestClass { Id = 1, Name = "Test" }, new TestClass());

        // Assert
        Assert.True(result);
    }

    #endregion

    #region ChangeTimeZoneAllProperties

    [Fact]
    public void ChangeTimeZoneAllProperties_NullCollection_ReturnsNull_Collection()
    {
        // Arrange
        IEnumerable<TestClass?>? collection = null;

        // Act
        var result = collection.ChangeTimeZoneAllProperties();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ChangeTimeZoneAllProperties_EmptyCollection_ReturnsEmpty_Collection()
    {
        // Arrange
        var collection = Array.Empty<TestClass?>();

        // Act
        var result = collection.ChangeTimeZoneAllProperties();

        // Assert
        Assert.Empty(result!);
    }

    [Fact]
    public void ChangeTimeZoneAllProperties_CollectionWithDateTimeProperties_ChangesTimeZones_Collection()
    {
        // Arrange
        var date1 = new DateTime(2023, 1, 1, 12, 0, 0, DateTimeKind.Utc);
        var date2 = new DateTime(2023, 1, 2, 12, 0, 0, DateTimeKind.Utc);
        var collection = new TestClass?[]
        {
            new() { Id = 1, Name = "Test1", Date = date1 },
            new() { Id = 2, Name = "Test2", Date = date2 }
        };

        var tzSrc = TimeSpan.Zero;
        var tzDst = TimeSpan.FromHours(7);

        // Act
        var result = collection.ChangeTimeZoneAllProperties(tzSrc, tzDst)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Length);
        Assert.Equal(new DateTime(2023, 1, 1, 19, 0, 0), result[0]!.Date);
        Assert.Equal(new DateTime(2023, 1, 2, 19, 0, 0), result[1]!.Date);
    }

    #endregion
}
