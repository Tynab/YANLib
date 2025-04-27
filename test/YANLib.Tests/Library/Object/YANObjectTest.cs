namespace YANLib.Tests.Library.Object;

public partial class YANObjectTest
{
    #region IsNull

    [Fact]
    public void IsNull_NullObject_ReturnsTrue()
    {
        // Arrange
        object? obj = null;

        // Act
        var result = obj.IsNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNull_NonNullObject_ReturnsFalse()
    {
        // Arrange
        object obj = new();

        // Act
        var result = obj.IsNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNull_NullObject_ReturnsFalse()
    {
        // Arrange
        object? obj = null;

        // Act
        var result = obj.IsNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNull_NonNullObject_ReturnsTrue()
    {
        // Arrange
        object obj = new();

        // Act
        var result = obj.IsNotNull();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region IsDefault

    [Fact]
    public void IsDefault_DefaultInt_ReturnsTrue()
    {
        // Arrange
        int value = default;

        // Act
        var result = value.IsDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsDefault_NonDefaultInt_ReturnsFalse()
    {
        // Arrange
        var value = 42;

        // Act
        var result = value.IsDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsDefault_DefaultString_ReturnsTrue()
    {
        // Arrange
        string? value = default;

        // Act
        var result = value.IsDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsDefault_NonDefaultString_ReturnsFalse()
    {
        // Arrange
        var value = "test";

        // Act
        var result = value.IsDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsDefault_DefaultDateTime_ReturnsTrue()
    {
        // Arrange
        DateTime value = default;

        // Act
        var result = value.IsDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsDefault_NonDefaultDateTime_ReturnsFalse()
    {
        // Arrange
        var value = DateTime.Now;

        // Act
        var result = value.IsDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotDefault_DefaultInt_ReturnsFalse()
    {
        // Arrange
        int value = default;

        // Act
        var result = value.IsNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotDefault_NonDefaultInt_ReturnsTrue()
    {
        // Arrange
        var value = 42;

        // Act
        var result = value.IsNotDefault();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region IsNullEmpty

    [Fact]
    public void IsNullEmpty_NullCollection_ReturnsTrue()
    {
        // Arrange
        IEnumerable<int>? collection = null;

        // Act
        var result = collection.IsNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullEmpty_EmptyCollection_ReturnsTrue()
    {
        // Arrange
        var collection = Array.Empty<int>();

        // Act
        var result = collection.IsNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullEmpty_NonEmptyCollection_ReturnsFalse()
    {
        // Arrange
        var collection = new[] { 1, 2, 3 };

        // Act
        var result = collection.IsNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullEmpty_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<int>? collection = null;

        // Act
        var result = collection.IsNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullEmpty_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var collection = Array.Empty<int>();

        // Act
        var result = collection.IsNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullEmpty_NonEmptyCollection_ReturnsTrue()
    {
        // Arrange
        var collection = new[] { 1, 2, 3 };

        // Act
        var result = collection.IsNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region ChangeTimeZoneAllProperty

    [Fact]
    public void ChangeTimeZoneAllProperty_NullObject_ReturnsNull()
    {
        // Arrange
        TestClass? obj = null;

        // Act
        var result = obj.ChangeTimeZoneAllProperty();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_ObjectWithDateTimeProperty_ChangesTimeZone()
    {
        // Arrange
        var date = new DateTime(2023, 1, 1, 12, 0, 0, DateTimeKind.Utc);
        var obj = new TestClass
        {
            Date = date
        };

        var tzSrc = TimeSpan.Zero;
        var tzDst = TimeSpan.FromHours(7);

        // Act
        var result = obj.ChangeTimeZoneAllProperty(tzSrc, tzDst);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new DateTime(2023, 1, 1, 19, 0, 0), result.Date);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_ObjectWithNestedDateTimeProperty_ChangesTimeZone()
    {
        // Arrange
        var date = new DateTime(2023, 1, 1, 12, 0, 0, DateTimeKind.Utc);
        var nested = new TestClass
        {
            Date = date
        };

        var obj = new TestClassWithNested
        {
            Nested = nested
        };

        var tzSrc = TimeSpan.Zero;
        var tzDst = TimeSpan.FromHours(7);

        // Act
        var result = obj.ChangeTimeZoneAllProperty(tzSrc, tzDst);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.Nested);
        Assert.Equal(new DateTime(2023, 1, 1, 19, 0, 0), result.Nested.Date);
    }

    #endregion

    #region Copy

    [Fact]
    public void Copy_NullObject_ReturnsNull()
    {
        // Arrange
        TestClass? obj = null;

        // Act
        var result = obj.Copy();

        // Assert
        Assert.Equal(obj, result);
    }

    [Fact]
    public void Copy_ObjectWithProperties_CreatesShallowCopy()
    {
        // Arrange
        var obj = new TestClass
        {
            Id = 1,
            Name = "Test",
            Date = DateTime.Now
        };

        // Act
        var result = obj.Copy();

        // Assert
        Assert.NotSame(obj, result);
        Assert.Equal(obj.Id, result.Id);
        Assert.Equal(obj.Name, result.Name);
        Assert.Equal(obj.Date, result.Date);
    }

    [Fact]
    public void Copy_ObjectWithReferenceProperties_CreatesShallowCopy()
    {
        // Arrange
        var nested = new TestClass
        {
            Id = 2,
            Name = "Nested"
        };

        var obj = new TestClassWithNested
        {
            Id = 1,
            Name = "Test",
            Nested = nested
        };

        // Act
        var result = obj.Copy();

        // Assert
        Assert.NotSame(obj, result);
        Assert.Equal(obj.Id, result.Id);
        Assert.Equal(obj.Name, result.Name);
        Assert.Same(obj.Nested, result.Nested);
    }

    #endregion

    private class TestClass
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public bool Active { get; set; }

        public DateTime Date { get; set; }
    }

    private class TestClassWithNested : TestClass
    {
        public TestClass? Nested { get; set; }
    }
}
