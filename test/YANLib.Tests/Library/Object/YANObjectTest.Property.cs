namespace YANLib.Tests.Library.Object;

public partial class YANObjectTest
{
    #region AllPropertiesDefault

    [Fact]
    public void AllPropertiesDefault_NullObject_ReturnsFalse_Property()
    {
        // Arrange
        TestClass? obj = null;

        // Act
        var result = obj.AllPropertiesDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefault_ObjectWithAllDefaultProperties_ReturnsTrue_Property()
    {
        // Arrange
        var obj = new TestClass();

        // Act
        var result = obj.AllPropertiesDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesDefault_ObjectWithSomeNonDefaultProperties_ReturnsFalse_Property()
    {
        // Arrange
        var obj = new TestClass
        {
            Id = 1
        };

        // Act
        var result = obj.AllPropertiesDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefaults_NullCollection_ReturnsFalse_Property()
    {
        // Arrange
        IEnumerable<TestClass?>? collection = null;

        // Act
        var result = collection.AllPropertiesDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefaults_EmptyCollection_ReturnsFalse_Property()
    {
        // Arrange
        var collection = Array.Empty<TestClass?>();

        // Act
        var result = collection.AllPropertiesDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefaults_CollectionWithAllDefaultObjects_ReturnsTrue_Property()
    {
        // Arrange
        var collection = new TestClass?[]
        {
            new(),
            new(),
            new()
        };

        // Act
        var result = collection.AllPropertiesDefaults();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesDefaults_CollectionWithSomeNonDefaultObjects_ReturnsFalse_Property()
    {
        // Arrange
        var collection = new TestClass?[]
        {
            new(),
            new() { Id = 1 },
            new()
        };

        // Act
        var result = collection.AllPropertiesDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefaults_ParamsOverload_AllDefaultObjects_ReturnsTrue_Property()
    {
        // Act
        var result = YANObject.AllPropertiesDefaults(new TestClass(), new TestClass(), new TestClass());

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesDefault_WithSpecificPropertyNames_AllDefaultValues_ReturnsTrue_Property()
    {
        // Arrange
        var obj = new TestClass
        {
            Id = 1,
            Name = "Test"
        };

        var propertyNames = new[] { "Active", "Date" };

        // Act
        var result = obj.AllPropertiesDefault(propertyNames);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesDefault_WithSpecificPropertyNames_SomeNonDefaultValues_ReturnsFalse_Property()
    {
        // Arrange
        var obj = new TestClass
        {
            Id = 1,
            Name = "Test"
        };

        var propertyNames = new[] { "Id", "Date" };

        // Act
        var result = obj.AllPropertiesDefault(propertyNames);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefaults_WithSpecificPropertyNames_AllDefaultValues_ReturnsTrue_Property()
    {
        // Arrange
        var collection = new TestClass?[]
        {
            new() { Id = 1, Name = "Test1" },
            new() { Id = 2, Name = "Test2" }
        };

        var propertyNames = new[] { "Active", "Date" };

        // Act
        var result = collection.AllPropertiesDefaults(propertyNames);

        // Assert
        Assert.True(result);
    }

    #endregion

    #region AllPropertiesNotDefault

    [Fact]
    public void AllPropertiesNotDefault_NullObject_ReturnsFalse_Property()
    {
        // Arrange
        TestClass? obj = null;

        // Act
        var result = obj.AllPropertiesNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_ObjectWithAllNonDefaultProperties_ReturnsTrue_Property()
    {
        // Arrange
        var obj = new TestClass
        {
            Id = 1,
            Name = "Test",
            Active = true,
            Date = DateTime.Now
        };

        // Act
        var result = obj.AllPropertiesNotDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_ObjectWithSomeDefaultProperties_ReturnsFalse_Property()
    {
        // Arrange
        var obj = new TestClass
        {
            Id = 1,
            Name = "Test"
        };

        // Act
        var result = obj.AllPropertiesNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_NullCollection_ReturnsFalse_Property()
    {
        // Arrange
        IEnumerable<TestClass?>? collection = null;

        // Act
        var result = collection.AllPropertiesNotDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_EmptyCollection_ReturnsFalse_Property()
    {
        // Arrange
        var collection = Array.Empty<TestClass?>();

        // Act
        var result = collection.AllPropertiesNotDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_CollectionWithAllNonDefaultObjects_ReturnsTrue_Property()
    {
        // Arrange
        var collection = new TestClass?[]
        {
            new() { Id = 1, Name = "Test1", Active = true, Date = DateTime.Now },
            new() { Id = 2, Name = "Test2", Active = true, Date = DateTime.Now }
        };

        // Act
        var result = collection.AllPropertiesNotDefaults();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_CollectionWithSomeDefaultProperties_ReturnsFalse_Property()
    {
        // Arrange
        var collection = new TestClass?[]
        {
            new() { Id = 1, Name = "Test1", Active = true, Date = DateTime.Now },
            new() { Id = 2, Name = "Test2" }
        };

        // Act
        var result = collection.AllPropertiesNotDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_WithSpecificPropertyNames_AllNonDefaultValues_ReturnsTrue_Property()
    {
        // Arrange
        var obj = new TestClass
        {
            Id = 1,
            Name = "Test"
        };

        var propertyNames = new[] { "Id", "Name" };

        // Act
        var result = obj.AllPropertiesNotDefault(propertyNames);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_WithSpecificPropertyNames_SomeDefaultValues_ReturnsFalse_Property()
    {
        // Arrange
        var obj = new TestClass
        {
            Id = 1,
            Name = "Test"
        };

        var propertyNames = new[] { "Id", "Date" };

        // Act
        var result = obj.AllPropertiesNotDefault(propertyNames);

        // Assert
        Assert.False(result);
    }

    #endregion

    #region AnyPropertiesDefault

    [Fact]
    public void AnyPropertiesDefault_NullObject_ReturnsFalse_Property()
    {
        // Arrange
        TestClass? obj = null;

        // Act
        var result = obj.AnyPropertiesDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefault_ObjectWithAllNonDefaultProperties_ReturnsFalse_Property()
    {
        // Arrange
        var obj = new TestClass
        {
            Id = 1,
            Name = "Test",
            Active = true,
            Date = DateTime.Now
        };

        // Act
        var result = obj.AnyPropertiesDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefault_ObjectWithSomeDefaultProperties_ReturnsTrue_Property()
    {
        // Arrange
        var obj = new TestClass
        {
            Id = 1,
            Name = "Test"
        };

        // Act
        var result = obj.AnyPropertiesDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesDefaults_NullCollection_ReturnsFalse_Property()
    {
        // Arrange
        IEnumerable<TestClass?>? collection = null;

        // Act
        var result = collection.AnyPropertiesDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefaults_EmptyCollection_ReturnsFalse_Property()
    {
        // Arrange
        var collection = Array.Empty<TestClass?>();

        // Act
        var result = collection.AnyPropertiesDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefaults_CollectionWithNoDefaultProperties_ReturnsFalse_Property()
    {
        // Arrange
        var collection = new TestClass?[]
        {
            new() { Id = 1, Name = "Test1", Active = true, Date = DateTime.Now },
            new() { Id = 2, Name = "Test2", Active = true, Date = DateTime.Now }
        };

        // Act
        var result = collection.AnyPropertiesDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefaults_CollectionWithSomeDefaultProperties_ReturnsTrue_Property()
    {
        // Arrange
        var collection = new TestClass?[]
        {
            new() { Id = 1, Name = "Test1", Active = true, Date = DateTime.Now },
            new() { Id = 2, Name = "Test2" }
        };

        // Act
        var result = collection.AnyPropertiesDefaults();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesDefault_WithSpecificPropertyNames_NoDefaultValues_ReturnsFalse_Property()
    {
        // Arrange
        var obj = new TestClass
        {
            Id = 1,
            Name = "Test"
        };

        var propertyNames = new[] { "Id", "Name" };

        // Act
        var result = obj.AnyPropertiesDefault(propertyNames);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefault_WithSpecificPropertyNames_SomeDefaultValues_ReturnsTrue_Property()
    {
        // Arrange
        var obj = new TestClass
        {
            Id = 1,
            Name = "Test"
        };

        var propertyNames = new[] { "Id", "Date" };

        // Act
        var result = obj.AnyPropertiesDefault(propertyNames);

        // Assert
        Assert.True(result);
    }

    #endregion

    #region AnyPropertiesNotDefault

    [Fact]
    public void AnyPropertiesNotDefault_NullObject_ReturnsFalse_Property()
    {
        // Arrange
        TestClass? obj = null;

        // Act
        var result = obj.AnyPropertiesNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefault_ObjectWithAllDefaultProperties_ReturnsFalse_Property()
    {
        // Arrange
        var obj = new TestClass();

        // Act
        var result = obj.AnyPropertiesNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefault_ObjectWithSomeNonDefaultProperties_ReturnsTrue_Property()
    {
        // Arrange
        var obj = new TestClass
        {
            Id = 1
        };

        // Act
        var result = obj.AnyPropertiesNotDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesNotDefaults_NullCollection_ReturnsFalse_Property()
    {
        // Arrange
        IEnumerable<TestClass?>? collection = null;

        // Act
        var result = collection.AnyPropertiesNotDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefaults_EmptyCollection_ReturnsFalse_Property()
    {
        // Arrange
        var collection = Array.Empty<TestClass?>();

        // Act
        var result = collection.AnyPropertiesNotDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefaults_CollectionWithAllDefaultObjects_ReturnsFalse_Property()
    {
        // Arrange
        var collection = new TestClass?[]
        {
            new(),
            new(),
            new()
        };

        // Act
        var result = collection.AnyPropertiesNotDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefaults_CollectionWithSomeNonDefaultObjects_ReturnsTrue_Property()
    {
        // Arrange
        var collection = new TestClass?[]
        {
            new(),
            new() { Id = 1 },
            new()
        };

        // Act
        var result = collection.AnyPropertiesNotDefaults();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesNotDefault_WithSpecificPropertyNames_AllDefaultValues_ReturnsFalse_Property()
    {
        // Arrange
        var obj = new TestClass();
        var propertyNames = new[] { "Id", "Name" };

        // Act
        var result = obj.AnyPropertiesNotDefault(propertyNames);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefault_WithSpecificPropertyNames_SomeNonDefaultValues_ReturnsTrue_Property()
    {
        // Arrange
        var obj = new TestClass
        {
            Id = 1
        };

        var propertyNames = new[] { "Id", "Name" };

        // Act
        var result = obj.AnyPropertiesNotDefault(propertyNames);

        // Assert
        Assert.True(result);
    }

    #endregion
}
