using YANLib.Object;
using YANLib.Unmanaged;

namespace YANLib.Tests.Library.Object;

public partial class YANObjectTest
{
    private class TestCopyClass
    {
        public int Number { get; set; }

        public string? Text { get; set; }
    }

    private class TestTimeZoneClass
    {
        public DateTime Date { get; set; }

        public string? Name { get; set; }

        public TestTimeZoneClass? Nested { get; set; }

        public List<TestTimeZoneClass>? List { get; set; }
    }

    #region IsDefault
    [Fact]
    public void IsDefault_NullObject_ReturnsTrue()
    {
        // Arrange
        object? input = default;

        // Act
        var result = input.IsNull() || input.IsDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsDefault_NonNullObject_ReturnsFalse()
    {
        // Arrange
        var input = new object();

        // Act
        var result = input.IsDefault();

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNotDefault
    [Fact]
    public void IsNotDefault_NullObject_ReturnsFalse()
    {
        // Arrange
        object? input = default;

        // Act
        var result = input.IsNotNull() && !input.IsNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotDefault_NonNullObject_ReturnsTrue()
    {
        // Arrange
        var input = new object();

        // Act
        var result = input.IsNotDefault();

        // Assert
        Assert.True(result);
    }
    #endregion

    #region IsNull
    [Fact]
    public void IsNull_NullObject_ReturnsTrue()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.IsNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNull_NonNullObject_ReturnsFalse()
    {
        // Arrange
        var input = new object();

        // Act
        var result = input.IsNull();

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNotNull
    [Fact]
    public void IsNotNull_NullObject_ReturnsFalse()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.IsNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNull_NonNullObject_ReturnsTrue()
    {
        // Arrange
        var input = new object();

        // Act
        var result = input.IsNotNull();

        // Assert
        Assert.True(result);
    }
    #endregion

    #region IsNullEmpty
    [Fact]
    public void IsNullEmpty_NullIEnumerable_ReturnsTrue()
    {
        // Arrange
        IEnumerable<int>? input = null;

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullEmpty_EmptyIEnumerable_ReturnsTrue()
    {
        // Arrange
        IEnumerable<int> input = [];

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullEmpty_NonEmptyIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<int> input = [1, 2];

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNotNullEmpty
    [Fact]
    public void IsNotNullEmpty_NullIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<int>? input = null;

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullEmpty_EmptyIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<int> input = [];

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullEmpty_NonEmptyIEnumerable_ReturnsTrue()
    {
        // Arrange
        IEnumerable<int> input = [1, 2];

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.True(result);
    }
    #endregion

    #region AllNull
    [Fact]
    public void AllNull_NullIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object>? input = null;

        // Act
        var result = input.AllNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNull_EmptyIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object> input = [];

        // Act
        var result = input.AllNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNull_AllNullIEnumerable_ReturnsTrue()
    {
        // Arrange
        IEnumerable<object?> input = [null, null];

        // Act
        var result = input.AllNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNull_NonNullIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object?> input = [new object(), null];

        // Act
        var result = input.AllNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNull_NullParams_ReturnsFalse()
    {
        // Arrange
        object[]? input = null;

        // Act
        var result = YANObject.AllNull(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNull_EmptyParams_ReturnsFalse()
    {
        // Arrange
        object[] input = [];

        // Act
        var result = YANObject.AllNull(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNull_AllNullParams_ReturnsTrue()
    {
        // Act
        var result = YANObject.AllNull<object>(null, null);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNull_NonNullParams_ReturnsFalse()
    {
        // Act
        var result = YANObject.AllNull(null, new object());

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllNullEmpty
    [Fact]
    public void AllNullEmpty_NullIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object>? input = null;

        // Act
        var result = input.AllNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_EmptyIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object> input = [];

        // Act
        var result = input.AllNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_AllNullAndDefaultProperties_ReturnsTrue()
    {
        // Arrange
        var obj = new
        {
            Value = default(string)
        };

        IEnumerable<object?> input = [null, obj];

        // Act
        var result = input.AllNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNullEmpty_NonNullAndEmptyProperties_ReturnsFalse()
    {
        // Arrange
        var obj = new
        {
            Value = "Test"
        };

        IEnumerable<object?> input = [null, obj];

        // Act
        var result = input.AllNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_NullParams_ReturnsFalse()
    {
        // Arrange
        object[]? input = null;

        // Act
        var result = input.AllNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_EmptyParams_ReturnsFalse()
    {
        // Arrange
        object[] input = [];

        // Act
        var result = input.AllNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_AllNullAndDefaultParams_ReturnsTrue()
    {
        // Arrange
        var obj = new
        {
            Value = default(string)
        };

        // Act
        var result = YANObject.AllNullEmpty<object>(null, obj);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNullEmpty_NonNullAndNonDefaultParams_ReturnsFalse()
    {
        // Arrange
        var obj = new
        {
            Value = "Test"
        };

        // Act
        var result = YANObject.AllNullEmpty<object>(null, obj);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNull
    [Fact]
    public void AnyNull_NullIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object>? input = null;

        // Act
        var result = input.AnyNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNull_EmptyIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object> input = [];

        // Act
        var result = input.AnyNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNull_AtLeastOneNullElementInIEnumerable_ReturnsTrue()
    {
        // Arrange
        IEnumerable<object?> input = [null, new object()];

        // Act
        var result = input.AnyNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNull_AllNonNullElementsInIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object> input = [new object(), new object()];

        // Act
        var result = input.AnyNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNull_NullParams_ReturnsFalse()
    {
        // Arrange
        object[]? input = null;

        // Act
        var result = YANObject.AnyNull(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNull_EmptyParams_ReturnsFalse()
    {
        // Arrange
        object[] input = [];

        // Act
        var result = YANObject.AnyNull(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNull_AtLeastOneNullParams_ReturnsTrue()
    {
        // Arrange
        var obj = new object();

        // Act
        var result = YANObject.AnyNull(null, obj);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNull_AllNonNullParams_ReturnsFalse()
    {
        // Arrange
        var obj = new object();

        // Act
        var result = YANObject.AnyNull(obj, new object());

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNullEmpty
    [Fact]
    public void AnyNullEmpty_NullIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object>? input = null;

        // Act
        var result = input.AnyNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullEmpty_EmptyIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object> input = [];

        // Act
        var result = input.AnyNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullEmpty_AtLeastOneNullElementInIEnumerable_ReturnsTrue()
    {
        // Arrange
        IEnumerable<object?> input = [null, new object()];

        // Act
        var result = input.AnyNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullEmpty_AtLeastOneElementWithDefaultPropertiesInIEnumerable_ReturnsTrue()
    {
        // Arrange
        var obj = new
        {
            Value = default(string)
        };

        IEnumerable<object> input = [new object(), obj];

        // Act
        var result = input.AnyNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullEmpty_AllElementsNonNullAndNonDefaultInIEnumerable_ReturnsFalse()
    {
        // Arrange
        var obj1 = new
        {
            Value = "Test 1"
        };

        var obj2 = new
        {
            Value = "Test 2"
        };

        IEnumerable<object> input = [obj1, obj2];

        // Act
        var result = input.AnyNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullEmpty_NullParams_ReturnsFalse()
    {
        // Arrange
        object[]? input = null;

        // Act
        var result = YANObject.AnyNullEmpty(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullEmpty_EmptyParams_ReturnsFalse()
    {
        // Arrange
        object[] input = [];

        // Act
        var result = YANObject.AnyNullEmpty(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullEmpty_AtLeastOneNullParams_ReturnsTrue()
    {
        // Act
        var result = YANObject.AnyNullEmpty(null, new object());

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullEmpty_AtLeastOneElementWithDefaultPropertiesInParams_ReturnsTrue()
    {
        // Arrange
        var obj = new
        {
            Value = default(string)
        };

        // Act
        var result = YANObject.AnyNullEmpty(new object(), obj);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullEmpty_AllElementsNonNullAndNonDefaultParams_ReturnsFalse()
    {
        // Arrange
        var obj1 = new
        {
            Value = "Test 1"
        };

        var obj2 = new
        {
            Value = "Test 2"
        };

        // Act
        var result = YANObject.AnyNullEmpty(obj1, obj2);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllNotNull
    [Fact]
    public void AllNotNull_NullIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object>? input = null;

        // Act
        var result = input.AllNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNull_EmptyIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object> input = [];

        // Act
        var result = input.AllNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNull_AllNonNullElementsInIEnumerable_ReturnsTrue()
    {
        // Arrange
        IEnumerable<object> input = [new object(), new object()];

        // Act
        var result = input.AllNotNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNull_AtLeastOneNullElementInIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object?> input = [null, new object()];

        // Act
        var result = input.AllNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNull_NullParams_ReturnsFalse()
    {
        // Arrange
        object[]? input = null;

        // Act
        var result = YANObject.AllNotNull(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNull_EmptyParams_ReturnsFalse()
    {
        // Arrange
        object[] input = [];

        // Act
        var result = YANObject.AllNotNull(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNull_AllNonNullParams_ReturnsTrue()
    {
        // Act
        var result = YANObject.AllNotNull(new object(), new object());

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNull_AtLeastOneNullParams_ReturnsFalse()
    {
        // Arrange
        var obj = new object();

        // Act
        var result = YANObject.AllNotNull(null, obj);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllNotNullEmpty
    [Fact]
    public void AllNotNullEmpty_NullIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object>? input = null;

        // Act
        var result = input.AllNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullEmpty_EmptyIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object> input = [];

        // Act
        var result = input.AllNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullEmpty_AllNonNullAndNonDefaultElementsInIEnumerable_ReturnsTrue()
    {
        // Arrange
        var obj1 = new
        {
            Value = "Test 1"
        };

        var obj2 = new
        {
            Value = "Test 2"
        };

        IEnumerable<object> input = [obj1, obj2];

        // Act
        var result = input.AllNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNullEmpty_AtLeastOneNullElementInIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object?> input = [null, new object()];

        // Act
        var result = input.AllNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullEmpty_AtLeastOneElementWithDefaultPropertiesInIEnumerable_ReturnsFalse()
    {
        // Arrange
        var obj = new
        {
            Value = default(string)
        };

        IEnumerable<object> input = [new object(), obj];

        // Act
        var result = input.AllNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullEmpty_NullParams_ReturnsFalse()
    {
        // Arrange
        object[]? input = null;

        // Act
        var result = YANObject.AllNotNullEmpty(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullEmpty_EmptyParams_ReturnsFalse()
    {
        // Arrange
        object[] input = [];

        // Act
        var result = YANObject.AllNotNullEmpty(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullEmpty_AllNonNullAndNonDefaultParams_ReturnsTrue()
    {
        // Arrange
        var obj1 = new
        {
            Value = "Test 1"
        };

        var obj2 = new
        {
            Value = "Test 2"
        };

        // Act
        var result = YANObject.AllNotNullEmpty(obj1, obj2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNullEmpty_AtLeastOneNullParams_ReturnsFalse()
    {
        // Arrange
        var obj = new object();

        // Act
        var result = YANObject.AllNotNullEmpty(null, obj);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullEmpty_AtLeastOneElementWithDefaultPropertiesInParams_ReturnsFalse()
    {
        // Arrange
        var obj = new
        {
            Value = default(string)
        };

        // Act
        var result = YANObject.AllNotNullEmpty(new object(), obj);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotNull
    [Fact]
    public void AnyNotNull_NullIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object>? input = null;

        // Act
        var result = input.AnyNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNull_EmptyIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object> input = [];

        // Act
        var result = input.AnyNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNull_AllNullElementsInIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object?> input = [null, null];

        // Act
        var result = input.AnyNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNull_AtLeastOneNonNullElementInIEnumerable_ReturnsTrue()
    {
        // Arrange
        IEnumerable<object?> input = [null, new object()];

        // Act
        var result = input.AnyNotNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNull_Params_NullInput_ReturnsFalse()
    {
        // Arrange
        object?[]? input = null;

        // Act
        var result = YANObject.AnyNotNull(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNull_Params_EmptyInput_ReturnsFalse()
    {
        // Arrange
        object?[] input = [];

        // Act
        var result = YANObject.AnyNotNull(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNull_Params_AllNullElements_ReturnsFalse()
    {
        // Arrange
        object?[] input = [null, null];

        // Act
        var result = YANObject.AnyNotNull(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNull_Params_AtLeastOneNonNullElement_ReturnsTrue()
    {
        // Arrange
        object?[] input = [null, new object()];

        // Act
        var result = YANObject.AnyNotNull(input);

        // Assert
        Assert.True(result);
    }
    #endregion

    #region AnyNotNullEmpty
    [Fact]
    public void AnyNotNullEmpty_NullIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object>? input = null;

        // Act
        var result = input.AnyNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNullEmpty_EmptyIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object> input = [];

        // Act
        var result = input.AnyNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNullEmpty_AllNullElementsInIEnumerable_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object?> input = [null, null];

        // Act
        var result = input.AnyNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNullEmpty_AtLeastOneNonNullElementInIEnumerable_ReturnsTrue()
    {
        // Arrange
        IEnumerable<object?> input = [null, new object()];

        // Act
        var result = input.AnyNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNullEmpty_AtLeastOneElementWithDefaultPropertiesInIEnumerable_ReturnsTrue()
    {
        // Arrange
        var obj = new
        {
            Value = default(string)
        };

        IEnumerable<object?> input = [null, obj];

        // Act
        var result = input.AnyNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNullEmpty_NullParams_ReturnsFalse()
    {
        // Arrange
        object[]? input = null;

        // Act
        var result = YANObject.AnyNotNullEmpty(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNullEmpty_EmptyParams_ReturnsFalse()
    {
        // Arrange
        object[] input = [];

        // Act
        var result = YANObject.AnyNotNullEmpty(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNullEmpty_AllNullParams_ReturnsFalse()
    {
        // Act
        var result = YANObject.AnyNotNullEmpty<object>(null, null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNullEmpty_AtLeastOneNonNullParams_ReturnsTrue()
    {
        // Arrange
        var obj = new object();

        // Act
        var result = YANObject.AnyNotNullEmpty(null, obj);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNullEmpty_AtLeastOneElementWithDefaultPropertiesInParams_ReturnsTrue()
    {
        // Arrange
        var obj = new
        {
            Value = default(string)
        };

        // Act
        var result = YANObject.AnyNotNullEmpty(null, obj);

        // Assert
        Assert.True(result);
    }
    #endregion

    #region ChangeTimeZoneAllProperty
    [Fact]
    public void ChangeTimeZoneAllProperty_NullInput_ReturnsNull()
    {
        // Arrange
        TestTimeZoneClass? input = null;

        // Act
        var result = input.ChangeTimeZoneAllProperty(new object(), new object());

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_DateTimeProperty_UpdatesDateTime()
    {
        // Arrange
        var originalDate = new DateTime(2020, 1, 1, 12, 0, 0);
        var tzSrc = 0;
        var tzDst = "7";
        var input = new TestTimeZoneClass
        {
            Date = originalDate,
            Name = "Test"
        };

        // Act
        var result = input.ChangeTimeZoneAllProperty(tzSrc, tzDst);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(originalDate.AddHours(Math.Abs(tzDst.Parse<double>() - tzSrc)), result.Date);
        Assert.Equal("Test", result.Name);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_NestedObject_UpdatesNestedDateTime()
    {
        // Arrange
        var originalDate = new DateTime(2020, 1, 1, 12, 0, 0);
        var tzSrc = 0;
        var tzDst = "7";
        var nested = new TestTimeZoneClass
        {
            Date = originalDate,
            Name = "Nested"
        };

        var input = new TestTimeZoneClass
        {
            Date = originalDate,
            Name = "Parent",
            Nested = nested
        };

        // Act
        var result = input.ChangeTimeZoneAllProperty(tzSrc, tzDst);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(originalDate.AddHours(Math.Abs(tzDst.Parse<double>() - tzSrc)), result.Date);
        Assert.NotNull(result.Nested);
        Assert.Equal(originalDate.AddHours(Math.Abs(tzDst.Parse<double>() - tzSrc)), result.Nested.Date);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_ListProperty_UpdatesDateTimeInListItems()
    {
        // Arrange
        var originalDate = new DateTime(2020, 1, 1, 12, 0, 0);
        var tzSrc = 0;
        var tzDst = "7";
        var item1 = new TestTimeZoneClass
        {
            Date = originalDate,
            Name = "Item 1"
        };

        var item2 = new TestTimeZoneClass
        {
            Date = originalDate,
            Name = "Item 2"
        };

        var input = new TestTimeZoneClass
        {
            Date = originalDate,
            Name = "Parent",
            List = [item1, item2]
        };

        // Act
        var result = input.ChangeTimeZoneAllProperty(tzSrc, tzDst);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(originalDate.AddHours(Math.Abs(tzDst.Parse<double>() - tzSrc)), result.Date);
        Assert.NotNull(result.List);

        foreach (var item in result.List)
        {
            Assert.Equal(originalDate.AddHours(Math.Abs(tzDst.Parse<double>() - tzSrc)), item.Date);
        }
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_NullTimeZoneParameters_DoesNotChangeDateTime()
    {
        // Arrange
        var originalDate = new DateTime(2020, 1, 1, 12, 0, 0);
        var input = new TestTimeZoneClass
        {
            Date = originalDate,
            Name = "Test"
        };

        // Act
        var result = input.ChangeTimeZoneAllProperty();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(originalDate, result.Date);
    }
    #endregion

    #region ChangeTimeZoneAllProperties
    [Fact]
    public void ChangeTimeZoneAllProperties_NullIEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<TestTimeZoneClass>? input = null;

        // Act
        var result = input.ChangeTimeZoneAllProperties(new object(), new object());

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ChangeTimeZoneAllProperties_EmptyIEnumerable_ReturnsEmpty()
    {
        // Arrange
        IEnumerable<TestTimeZoneClass> input = [];

        // Act
        var result = input.ChangeTimeZoneAllProperties(new object(), new object());

        // Assert
        Assert.Empty(result!);
    }

    [Fact]
    public void ChangeTimeZoneAllProperties_ValidIEnumerable_UpdatesDateTime()
    {
        // Arrange
        var originalDate = new DateTime(2020, 1, 1, 12, 0, 0);
        var tzSrc = 0;
        var tzDst = "7";
        var obj1 = new TestTimeZoneClass
        {
            Date = originalDate,
            Name = "Test 1"
        };

        var obj2 = new TestTimeZoneClass
        {
            Date = originalDate,
            Name = "Test 2"
        };

        IEnumerable<TestTimeZoneClass> input = [obj1, obj2];

        // Act
        var result = input.ChangeTimeZoneAllProperties(tzSrc, tzDst);

        // Assert
        Assert.NotNull(result);

        foreach (var item in result)
        {
            Assert.Equal(originalDate.AddHours(Math.Abs(tzDst.Parse<double>() - tzSrc)), item!.Date);
        }
    }
    #endregion

    #region Copy
    [Fact]
    public void Copy_NullInput_ReturnsNull()
    {
        // Arrange
        TestCopyClass? input = null;

        // Act
        var result = input.Copy();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Copy_NonNullInput_ReturnsCopyWithSameProperties()
    {
        // Arrange
        var input = new TestCopyClass
        {
            Number = 1,
            Text = "Hello"
        };

        // Act
        var result = input.Copy();

        // Assert
        Assert.NotNull(result);
        Assert.NotSame(input, result);
        Assert.Equal(input.Number, result.Number);
        Assert.Equal(input.Text, result.Text);
    }
    #endregion
}
