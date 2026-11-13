namespace YANLib.Tests.Library;

public partial class YANObjectTest
{
    #region IsNull (obsolete shims restored after 8.3.3)

#pragma warning disable CS0618 // The shims are obsolete on purpose; these tests pin their 8.3.2 behaviour.
    [Fact]
    public void IsNull_NullObject_ReturnsTrue_Object()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.IsNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNull_NonNullObject_ReturnsFalse_Object()
    {
        // Arrange
        var input = new TestClass();

        // Act
        var result = input.IsNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNull_NullNullableValue_ReturnsTrue_Object()
    {
        // Arrange
        int? input = null;

        // Act
        var result = input.IsNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotNull_NullString_ReturnsFalse_Object()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.IsNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNull_NonNullObject_ReturnsTrue_Object()
    {
        // Arrange
        var input = new TestClass();

        // Act
        var result = input.IsNotNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNull_Shims_AreObsolete_Object()
    {
        // Arrange
        var methods = typeof(YANObject).GetMethods().Where(static x => x.Name is nameof(YANObject.IsNull) or nameof(YANObject.IsNotNull)).ToArray();

        // Assert
        Assert.Equal(2, methods.Length);
        Assert.All(methods, static x => Assert.NotNull(x.GetCustomAttributes(typeof(ObsoleteAttribute), false).SingleOrDefault()));
    }
#pragma warning restore CS0618

    #endregion

    #region IsDefault

    [Fact]
    public void IsDefault_DefaultInt_ReturnsTrue_Object()
    {
        // Arrange
        int input = default;

        // Act
        var result = input.IsDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsDefault_NonDefaultInt_ReturnsFalse_Object()
    {
        // Arrange
        var input = 42;

        // Act
        var result = input.IsDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsDefault_DefaultString_ReturnsTrue_Object()
    {
        // Arrange
        string? input = default;

        // Act
        var result = input.IsDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsDefault_NonDefaultString_ReturnsFalse_Object()
    {
        // Arrange
        var input = "test";

        // Act
        var result = input.IsDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsDefault_DerivedInstanceTypedAsBase_ReturnsFalse_Object()
    {
        // Arrange
        Animal input = new Dog();

        // Act
        var result = input.IsDefault();

        // Assert (8.3.3 returned true: the value was sent through Convert.ChangeType and became null)
        Assert.False(result);
    }

    [Fact]
    public void IsDefault_DateTimeWithOnlyMilliseconds_ReturnsFalse_Object()
    {
        // Arrange
        var input = new DateTime(1, 1, 1, 0, 0, 0, 1);

        // Act
        var result = input.IsDefault();

        // Assert (8.3.3 returned true: the value was round-tripped through ToString() and lost its millisecond)
        Assert.False(result);
    }

    #endregion

    #region IsNotDefault

    [Fact]
    public void IsNotDefault_DefaultInt_ReturnsFalse_Object()
    {
        // Arrange
        int input = default;

        // Act
        var result = input.IsNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotDefault_NonDefaultInt_ReturnsTrue_Object()
    {
        // Arrange
        var input = 42;

        // Act
        var result = input.IsNotDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotDefault_DefaultString_ReturnsFalse_Object()
    {
        // Arrange
        string? input = default;

        // Act
        var result = input.IsNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotDefault_NonDefaultString_ReturnsTrue_Object()
    {
        // Arrange
        var input = "test";

        // Act
        var result = input.IsNotDefault();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region IsNullDefault

    [Fact]
    public void IsNullDefault_NullObject_ReturnsTrue_Object()
    {
        // Arrange
        TestClass? input = null;

        // Act
        var result = input.IsNullDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullDefault_ObjectWithDefaultValues_ReturnsTrue_Object()
    {
        // Arrange
        var input = new TestClass();

        // Act
        var result = input.IsNullDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullDefault_ObjectWithNonDefaultValues_ReturnsFalse_Object()
    {
        // Arrange
        var input = new TestClass
        {
            StringProperty = "test",
            IntProperty = 42
        };

        // Act
        var result = input.IsNullDefault();

        // Assert
        Assert.False(result);
    }

    #endregion

    #region IsNotNullDefault

    [Fact]
    public void IsNotNullDefault_NullObject_ReturnsFalse_Object()
    {
        // Arrange
        TestClass? input = null;

        // Act
        var result = input.IsNotNullDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullDefault_ObjectWithDefaultValues_ReturnsFalse_Object()
    {
        // Arrange
        var input = new TestClass();

        // Act
        var result = input.IsNotNullDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullDefault_ObjectWithNonDefaultValues_ReturnsTrue_Object()
    {
        // Arrange
        var input = new TestClass
        {
            StringProperty = "test",
            IntProperty = 42
        };

        // Act
        var result = input.IsNotNullDefault();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region IsNullEmpty

    [Fact]
    public void IsNullEmpty_NullCollection_ReturnsTrue_Object()
    {
        // Arrange
        IEnumerable<int>? input = null;

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullEmpty_EmptyCollection_ReturnsTrue_Object()
    {
        // Arrange
        IEnumerable<int> input = [];

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullEmpty_NonEmptyCollection_ReturnsFalse_Object()
    {
        // Arrange
        IEnumerable<int> input = [1, 2, 3];

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.False(result);
    }

    #endregion

    #region IsNotNullEmpty

    [Fact]
    public void IsNotNullEmpty_NullCollection_ReturnsFalse_Object()
    {
        // Arrange
        IEnumerable<int>? input = null;

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullEmpty_EmptyCollection_ReturnsFalse_Object()
    {
        // Arrange
        IEnumerable<int> input = [];

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullEmpty_NonEmptyCollection_ReturnsTrue_Object()
    {
        // Arrange
        IEnumerable<int> input = [1, 2, 3];

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region ChangeTimeZoneAllProperty

    [Fact]
    public void ChangeTimeZoneAllProperty_NullObject_ReturnsNull_Object()
    {
        // Arrange
        TestClass? input = null;

        // Act
        var result = input.ChangeTimeZoneAllProperty();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_ObjectWithDateTimeProperty_ChangesTimeZone_Object()
    {
        // Arrange
        var input = new TestClass
        {
            DateProperty = new DateTime(2023, 1, 1, 12, 0, 0, DateTimeKind.Utc),
            StringProperty = "test",
            IntProperty = 42
        };

        var tzSrc = 0;
        var tzDst = 7;

        // Act
        var result = input.ChangeTimeZoneAllProperty(tzSrc, tzDst);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new DateTime(2023, 1, 1, 19, 0, 0), result.DateProperty);
        Assert.Equal("test", result.StringProperty);
        Assert.Equal(42, result.IntProperty);
    }

    #endregion

    #region Copy

    [Fact]
    public void Copy_ObjectWithProperties_CreatesCopy_Object()
    {
        // Arrange
        var input = new TestClass
        {
            DateProperty = new DateTime(2023, 1, 1),
            StringProperty = "test",
            IntProperty = 42
        };

        // Act
        var result = input.Copy();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(input.DateProperty, result.DateProperty);
        Assert.Equal(input.StringProperty, result.StringProperty);
        Assert.Equal(input.IntProperty, result.IntProperty);
        Assert.NotSame(input, result);
    }

    #endregion

    private class TestClass
    {
        public DateTime DateProperty { get; set; }

        public string? StringProperty { get; set; }

        public int IntProperty { get; set; }

        public string? Value { get; set; }
    }

    private class DateTimeTestClass
    {
        public DateTime DateProperty { get; set; }

        public string? StringProperty { get; set; }
    }

    private class Animal
    {
    }

    private sealed class Dog : Animal
    {
    }
}
