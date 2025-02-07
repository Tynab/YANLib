using YANLib.Object;

namespace YANLib.Tests.Library.Object;

public partial class YANObjectTest
{
    #region AllPropertiesNotDefault
    [Fact]
    public void AllPropertiesNotDefault_NullInput_ReturnsFalse()
    {
        // Arrange
        TestPropertiesClass? input = null;

        // Act
        var result = input.AllPropertiesNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_AllPropertiesNonDefault_ReturnsTrue()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        // Act
        var result = input.AllPropertiesNotDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_WithDefaultProperty_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = default,
            Text = "Hello"
        };

        // Act
        var result = input.AllPropertiesNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_IEnumerable_NullInput_ReturnsFalse()
    {
        // Arrange
        IEnumerable<TestPropertiesClass>? input = null;

        // Act
        var result = input.AllPropertiesNotDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_IEnumerable_EmptyInput_ReturnsFalse()
    {
        // Arrange
        IEnumerable<TestPropertiesClass> input = [];

        // Act
        var result = input.AllPropertiesNotDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_IEnumerable_AllObjectsNonDefault_ReturnsTrue()
    {
        // Arrange
        var obj1 = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        var obj2 = new TestPropertiesClass
        {
            Number = 2,
            Text = "World"
        };

        IEnumerable<TestPropertiesClass> input = [obj1, obj2];

        // Act
        var result = input.AllPropertiesNotDefaults();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_IEnumerable_OneObjectHasDefault_ReturnsFalse()
    {
        // Arrange
        var obj1 = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        var obj2 = new TestPropertiesClass
        {
            Number = default,
            Text = "World"
        };

        IEnumerable<TestPropertiesClass> input = [obj1, obj2];

        // Act
        var result = input.AllPropertiesNotDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_Params_NullInput_ReturnsFalse()
    {
        // Arrange
        TestPropertiesClass[]? input = null;

        // Act
        var result = YANObject.AllPropertiesNotDefaults(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_Params_EmptyInput_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<TestPropertiesClass>();

        // Act
        var result = YANObject.AllPropertiesNotDefaults(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_Params_AllObjectsNonDefault_ReturnsTrue()
    {
        // Arrange
        var obj1 = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        var obj2 = new TestPropertiesClass
        {
            Number = 2,
            Text = "World"
        };

        // Act
        var result = YANObject.AllPropertiesNotDefaults(obj1, obj2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_Params_OneObjectHasDefault_ReturnsFalse()
    {
        // Arrange
        var obj1 = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        var obj2 = new TestPropertiesClass
        {
            Number = default,
            Text = "World"
        };

        // Act
        var result = YANObject.AllPropertiesNotDefaults(obj1, obj2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_WithNames_NullInput_ReturnsFalse()
    {
        // Arrange
        TestPropertiesClass? input = null;
        var names = new List<string?> { nameof(TestPropertiesClass.Number), nameof(TestPropertiesClass.Text) };

        // Act
        var result = input.AllPropertiesNotDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_WithNames_NullNames_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        IEnumerable<string?>? names = null;

        // Act
        var result = input.AllPropertiesNotDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_WithNames_AllNamesNullWhiteSpace_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        var names = new List<string?> { " ", string.Empty, null };

        // Act
        var result = input.AllPropertiesNotDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_WithNames_SpecifiedPropertyNonDefault_ReturnsTrue()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = null
        };

        var names = new List<string?> { nameof(TestPropertiesClass.Number) };

        // Act
        var result = input.AllPropertiesNotDefault(names);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_WithNames_SpecifiedPropertyDefault_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = default,
            Text = "Hello"
        };

        var names = new List<string?> { nameof(TestPropertiesClass.Number) };

        // Act
        var result = input.AllPropertiesNotDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_WithNames_NonMatchingPropertyNames_ReturnsTrue()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        var names = new List<string?> { "NonExistent" };

        // Act
        var result = input.AllPropertiesNotDefault(names);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_IEnumerable_WithNames_NullInput_ReturnsFalse()
    {
        // Arrange
        IEnumerable<TestPropertiesClass>? input = null;
        var names = new List<string?> { nameof(TestPropertiesClass.Number), nameof(TestPropertiesClass.Text) };

        // Act
        var result = input.AllPropertiesNotDefaults(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_IEnumerable_WithNames_NullNames_ReturnsFalse()
    {
        // Arrange
        var obj = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        IEnumerable<TestPropertiesClass> input = [obj];
        IEnumerable<string?>? names = null;

        // Act
        var result = input.AllPropertiesNotDefaults(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_IEnumerable_WithNames_EmptyNames_ReturnsFalse()
    {
        // Arrange
        var obj = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        IEnumerable<TestPropertiesClass> input = [obj];
        var names = new List<string?>();

        // Act
        var result = input.AllPropertiesNotDefaults(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_IEnumerable_WithNames_NamesWithWhiteSpace_ReturnsFalse()
    {
        // Arrange
        var obj = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        IEnumerable<TestPropertiesClass> input = [obj];
        var names = new List<string?> { " ", string.Empty, null };

        // Act
        var result = input.AllPropertiesNotDefaults(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_IEnumerable_WithNames_AllObjectsSpecifiedPropertiesNonDefault_ReturnsTrue()
    {
        // Arrange
        var obj1 = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        var obj2 = new TestPropertiesClass
        {
            Number = 2,
            Text = "World"
        };

        IEnumerable<TestPropertiesClass> input = [obj1, obj2];
        var names = new List<string?> { nameof(TestPropertiesClass.Number) };

        // Act
        var result = input.AllPropertiesNotDefaults(names);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_IEnumerable_WithNames_OneObjectSpecifiedPropertyDefault_ReturnsFalse()
    {
        // Arrange
        var obj1 = new TestPropertiesClass
        {
            Number = default,
            Text = "Hello"
        };

        var obj2 = new TestPropertiesClass
        {
            Number = 2,
            Text = "World"
        };

        IEnumerable<TestPropertiesClass> input = [obj1, obj2];
        var names = new List<string?> { nameof(TestPropertiesClass.Number) };

        // Act
        var result = input.AllPropertiesNotDefaults(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_Params_WithNames_NullInput_ReturnsFalse()
    {
        // Arrange
        TestPropertiesClass? input = null;

        // Act
        var result = input.AllPropertiesNotDefault(nameof(TestPropertiesClass.Number), nameof(TestPropertiesClass.Text));

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_Params_WithNames_NullNames_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        string[]? names = null;

        // Act
        var result = input.AllPropertiesNotDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_Params_WithNames_EmptyNames_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        // Act
        var result = input.AllPropertiesNotDefault([]);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_Params_WithNames_AllNamesWhiteSpace_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        // Act
        var result = input.AllPropertiesNotDefault(" ", string.Empty, null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_Params_WithNames_SpecifiedPropertyNonDefault_ReturnsTrue()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = default
        };

        // Act
        var result = input.AllPropertiesNotDefault(nameof(TestPropertiesClass.Number));

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_Params_WithNames_SpecifiedPropertyDefault_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = default,
            Text = "Hello"
        };

        // Act
        var result = input.AllPropertiesNotDefault(nameof(TestPropertiesClass.Number));

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefault_Params_WithNames_NonMatchingNames_ReturnsTrue()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        // Act
        var result = input.AllPropertiesNotDefault("NonExistent");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_Params_WithNames_NullInput_ReturnsFalse()
    {
        // Arrange
        IEnumerable<TestPropertiesClass>? input = null;

        // Act
        var result = YANObject.AllPropertiesNotDefaults(input, nameof(TestPropertiesClass.Number), nameof(TestPropertiesClass.Text));

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_Params_WithNames_NullNames_ReturnsFalse()
    {
        // Arrange
        var obj = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        IEnumerable<TestPropertiesClass> input = [obj];
        string[]? names = null;

        // Act
        var result = YANObject.AllPropertiesNotDefaults(input, names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_Params_WithNames_EmptyNames_ReturnsFalse()
    {
        // Arrange
        var obj = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        IEnumerable<TestPropertiesClass> input = [obj];

        // Act
        var result = YANObject.AllPropertiesNotDefaults(input, Array.Empty<string>());

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_Params_WithNames_AllNamesWhiteSpace_ReturnsFalse()
    {
        // Arrange
        var obj = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        IEnumerable<TestPropertiesClass> input = [obj];

        // Act
        var result = YANObject.AllPropertiesNotDefaults(input, " ", string.Empty, null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_Params_WithNames_AllObjectsSpecifiedPropertiesNonDefault_ReturnsTrue()
    {
        // Arrange
        var obj1 = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        var obj2 = new TestPropertiesClass
        {
            Number = 2,
            Text = "World"
        };

        IEnumerable<TestPropertiesClass> input = [obj1, obj2];

        // Act
        var result = YANObject.AllPropertiesNotDefaults(input, nameof(TestPropertiesClass.Number));

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesNotDefaults_Params_WithNames_OneObjectSpecifiedPropertyDefault_ReturnsFalse()
    {
        // Arrange
        var obj1 = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        var obj2 = new TestPropertiesClass
        {
            Number = default,
            Text = "World"
        };

        IEnumerable<TestPropertiesClass> input = [obj1, obj2];

        // Act
        var result = YANObject.AllPropertiesNotDefaults(input, nameof(TestPropertiesClass.Number));

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllPropertiesDefault
    [Fact]
    public void AllPropertiesDefault_NullInput_ReturnsFalse()
    {
        // Arrange
        TestPropertiesClass? input = null;

        // Act
        var result = input.AllPropertiesDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefault_AllPropertiesDefault_ReturnsTrue()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = default,
            Text = default
        };

        // Act
        var result = input.AllPropertiesDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesDefault_WithNonDefaultProperty_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = default
        };

        // Act
        var result = input.AllPropertiesDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefaults_IEnumerable_NullInput_ReturnsFalse()
    {
        // Arrange
        IEnumerable<TestPropertiesClass>? input = null;

        // Act
        var result = input.AllPropertiesDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefaults_IEnumerable_EmptyInput_ReturnsFalse()
    {
        // Arrange
        IEnumerable<TestPropertiesClass> input = [];

        // Act
        var result = input.AllPropertiesDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefaults_IEnumerable_AllObjectsDefault_ReturnsTrue()
    {
        // Arrange
        var obj1 = new TestPropertiesClass
        {
            Number = default,
            Text = default
        };

        var obj2 = new TestPropertiesClass
        {
            Number = default,
            Text = default
        };

        IEnumerable<TestPropertiesClass> input = [obj1, obj2];

        // Act
        var result = input.AllPropertiesDefaults();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesDefaults_IEnumerable_OneObjectNotDefault_ReturnsFalse()
    {
        // Arrange
        var obj1 = new TestPropertiesClass
        {
            Number = default,
            Text = default
        };

        var obj2 = new TestPropertiesClass
        {
            Number = 1,
            Text = default
        };

        IEnumerable<TestPropertiesClass> input = [obj1, obj2];

        // Act
        var result = input.AllPropertiesDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefaults_Params_NullInput_ReturnsFalse()
    {
        // Arrange
        TestPropertiesClass[]? input = null;

        // Act
        var result = YANObject.AllPropertiesDefaults(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefaults_Params_EmptyInput_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<TestPropertiesClass>();

        // Act
        var result = YANObject.AllPropertiesDefaults(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefaults_Params_AllObjectsDefault_ReturnsTrue()
    {
        // Arrange
        var obj1 = new TestPropertiesClass
        {
            Number = default,
            Text = default
        };

        var obj2 = new TestPropertiesClass
        {
            Number = default,
            Text = default
        };

        // Act
        var result = YANObject.AllPropertiesDefaults(obj1, obj2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesDefaults_Params_OneObjectNotDefault_ReturnsFalse()
    {
        // Arrange
        var obj1 = new TestPropertiesClass
        {
            Number = default,
            Text = default
        };

        var obj2 = new TestPropertiesClass
        {
            Number = 1,
            Text = default
        };

        // Act
        var result = YANObject.AllPropertiesDefaults(obj1, obj2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefault_WithNames_NullInput_ReturnsFalse()
    {
        // Arrange
        TestPropertiesClass? input = null;
        var names = new List<string?> { nameof(TestPropertiesClass.Number), nameof(TestPropertiesClass.Text) };

        // Act
        var result = input.AllPropertiesDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefault_WithNames_NullNames_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        IEnumerable<string?>? names = null;

        // Act
        var result = input.AllPropertiesDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefault_WithNames_AllNamesNullWhiteSpace_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        var names = new List<string?> { " ", string.Empty, null };

        // Act
        var result = input.AllPropertiesDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefault_WithNames_SpecifiedPropertyDefault_ReturnsTrue()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = default,
            Text = "Hello"
        };

        var names = new List<string?> { nameof(TestPropertiesClass.Number) };

        // Act
        var result = input.AllPropertiesDefault(names);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesDefault_WithNames_SpecifiedPropertyNonDefault_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = default
        };

        var names = new List<string?> { nameof(TestPropertiesClass.Number) };

        // Act
        var result = input.AllPropertiesDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefault_WithNames_NonMatchingPropertyNames_ReturnsTrue()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        var names = new List<string?> { "NonExistent" };

        // Act
        var result = input.AllPropertiesDefault(names);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesDefaults_IEnumerable_WithNames_NullInput_ReturnsFalse()
    {
        // Arrange
        IEnumerable<TestPropertiesClass>? input = null;
        var names = new List<string?> { nameof(TestPropertiesClass.Number), nameof(TestPropertiesClass.Text) };

        // Act
        var result = input.AllPropertiesDefaults(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefaults_IEnumerable_WithNames_NullNames_ReturnsFalse()
    {
        // Arrange
        var obj = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        IEnumerable<TestPropertiesClass> input = [obj];
        IEnumerable<string?>? names = null;

        // Act
        var result = input.AllPropertiesDefaults(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefaults_IEnumerable_WithNames_EmptyNames_ReturnsFalse()
    {
        // Arrange
        var obj = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        IEnumerable<TestPropertiesClass> input = [obj];
        var names = new List<string?>();

        // Act
        var result = input.AllPropertiesDefaults(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefaults_IEnumerable_WithNames_NamesWithWhiteSpace_ReturnsFalse()
    {
        // Arrange
        var obj = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        IEnumerable<TestPropertiesClass> input = [obj];
        var names = new List<string?> { " ", string.Empty, null };

        // Act
        var result = input.AllPropertiesDefaults(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefaults_IEnumerable_WithNames_AllObjectsSpecifiedPropertiesDefault_ReturnsTrue()
    {
        // Arrange
        var obj1 = new TestPropertiesClass
        {
            Number = default,
            Text = "Hello"
        };

        var obj2 = new TestPropertiesClass
        {
            Number = default,
            Text = "World"
        };

        IEnumerable<TestPropertiesClass> input = [obj1, obj2];
        var names = new List<string?> { nameof(TestPropertiesClass.Number) };

        // Act
        var result = input.AllPropertiesDefaults(names);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesDefaults_IEnumerable_WithNames_OneObjectSpecifiedPropertyNonDefault_ReturnsFalse()
    {
        // Arrange
        var obj1 = new TestPropertiesClass
        {
            Number = default,
            Text = "Hello"
        };

        var obj2 = new TestPropertiesClass
        {
            Number = 1,
            Text = "World"
        };

        IEnumerable<TestPropertiesClass> input = [obj1, obj2];
        var names = new List<string?> { nameof(TestPropertiesClass.Number) };

        // Act
        var result = input.AllPropertiesDefaults(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefault_Params_WithNames_NullInput_ReturnsFalse()
    {
        // Arrange
        TestPropertiesClass? input = null;

        // Act
        var result = input.AllPropertiesDefault(nameof(TestPropertiesClass.Number), nameof(TestPropertiesClass.Text));

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefault_Params_WithNames_NullNames_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        string[]? names = null;

        // Act
        var result = input.AllPropertiesDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefault_Params_WithNames_EmptyNames_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        // Act
        var result = input.AllPropertiesDefault([]);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefault_Params_WithNames_AllNamesWhiteSpace_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        // Act
        var result = input.AllPropertiesDefault(" ", string.Empty, null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefault_Params_WithNames_SpecifiedPropertyDefault_ReturnsTrue()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = default,
            Text = "Hello"
        };

        // Act
        var result = input.AllPropertiesDefault(nameof(TestPropertiesClass.Number));

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesDefault_Params_WithNames_SpecifiedPropertyNonDefault_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = default
        };

        // Act
        var result = input.AllPropertiesDefault(nameof(TestPropertiesClass.Number));

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefault_Params_WithNames_NonMatchingNames_ReturnsTrue()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        // Act
        var result = input.AllPropertiesDefault("NonExistent");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesDefaults_Params_WithNames_NullInput_ReturnsFalse()
    {
        // Arrange
        IEnumerable<TestPropertiesClass>? input = null;

        // Act
        var result = YANObject.AllPropertiesDefaults(input, nameof(TestPropertiesClass.Number), nameof(TestPropertiesClass.Text));

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefaults_Params_WithNames_NullNames_ReturnsFalse()
    {
        // Arrange
        var obj = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        IEnumerable<TestPropertiesClass> input = [obj];
        string[]? names = null;

        // Act
        var result = YANObject.AllPropertiesDefaults(input, names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefaults_Params_WithNames_EmptyNames_ReturnsFalse()
    {
        // Arrange
        var obj = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        IEnumerable<TestPropertiesClass> input = [obj];

        // Act
        var result = YANObject.AllPropertiesDefaults(input, Array.Empty<string>());

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefaults_Params_WithNames_AllNamesWhiteSpace_ReturnsFalse()
    {
        // Arrange
        var obj = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        IEnumerable<TestPropertiesClass> input = [obj];

        // Act
        var result = YANObject.AllPropertiesDefaults(input, " ", string.Empty, null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPropertiesDefaults_Params_WithNames_AllObjectsSpecifiedPropertiesDefault_ReturnsTrue()
    {
        // Arrange:
        var obj1 = new TestPropertiesClass
        {
            Number = default,
            Text = "Hello"
        };

        var obj2 = new TestPropertiesClass
        {
            Number = default,
            Text = "World"
        };

        IEnumerable<TestPropertiesClass> input = [obj1, obj2];

        // Act
        var result = YANObject.AllPropertiesDefaults(input, nameof(TestPropertiesClass.Number));

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPropertiesDefaults_Params_WithNames_OneObjectSpecifiedPropertyNonDefault_ReturnsFalse()
    {
        // Arrange
        var obj1 = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        var obj2 = new TestPropertiesClass
        {
            Number = default,
            Text = "World"
        };

        IEnumerable<TestPropertiesClass> input = [obj1, obj2];

        // Act
        var result = YANObject.AllPropertiesDefaults(input, nameof(TestPropertiesClass.Number));

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyPropertiesNotDefault
    [Fact]
    public void AnyPropertiesNotDefault_NullInput_ReturnsFalse()
    {
        // Arrange
        TestPropertiesClass? input = null;

        // Act
        var result = input.AnyPropertiesNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefault_AllPropertiesDefault_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = default,
            Text = default
        };

        // Act
        var result = input.AnyPropertiesNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefault_WithNonDefaultProperty_ReturnsTrue()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = default
        };

        // Act
        var result = input.AnyPropertiesNotDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesNotDefaults_IEnumerable_NullInput_ReturnsFalse()
    {
        // Arrange
        IEnumerable<TestPropertiesClass?>? input = null;

        // Act
        var result = input.AnyPropertiesNotDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefaults_IEnumerable_EmptyInput_ReturnsFalse()
    {
        // Arrange
        IEnumerable<TestPropertiesClass?> input = [];

        // Act
        var result = input.AnyPropertiesNotDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefaults_IEnumerable_AllObjectsDefault_ReturnsFalse()
    {
        // Arrange
        var obj1 = new TestPropertiesClass
        {
            Number = default,
            Text = default
        };

        var obj2 = new TestPropertiesClass
        {
            Number = default,
            Text = default
        };

        IEnumerable<TestPropertiesClass?> input = [obj1, obj2];

        // Act
        var result = input.AnyPropertiesNotDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefaults_IEnumerable_OneObjectNotDefault_ReturnsTrue()
    {
        // Arrange
        var obj1 = new TestPropertiesClass
        {
            Number = default,
            Text = default
        };

        var obj2 = new TestPropertiesClass
        {
            Number = 1,
            Text = default
        };

        IEnumerable<TestPropertiesClass?> input = [obj1, obj2];

        // Act
        var result = input.AnyPropertiesNotDefaults();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesNotDefaults_Params_NullInput_ReturnsFalse()
    {
        // Arrange
        TestPropertiesClass?[]? input = null;

        // Act
        var result = YANObject.AnyPropertiesNotDefaults(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefaults_Params_EmptyInput_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<TestPropertiesClass?>();

        // Act
        var result = YANObject.AnyPropertiesNotDefaults(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefaults_Params_AllObjectsDefault_ReturnsFalse()
    {
        // Arrange
        var obj1 = new TestPropertiesClass
        {
            Number = default,
            Text = default
        };

        var obj2 = new TestPropertiesClass
        {
            Number = default,
            Text = default
        };

        // Act
        var result = YANObject.AnyPropertiesNotDefaults(obj1, obj2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefaults_Params_OneObjectNotDefault_ReturnsTrue()
    {
        // Arrange
        var obj1 = new TestPropertiesClass
        {
            Number = default,
            Text = default
        };

        var obj2 = new TestPropertiesClass
        {
            Number = default,
            Text = "Hello"
        };

        // Act
        var result = YANObject.AnyPropertiesNotDefaults(obj1, obj2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesNotDefault_WithNames_NullInput_ReturnsFalse()
    {
        // Arrange
        TestPropertiesClass? input = null;
        var names = new List<string?> { nameof(TestPropertiesClass.Number), nameof(TestPropertiesClass.Text) };

        // Act
        var result = input.AnyPropertiesNotDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefault_WithNames_NullNames_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        IEnumerable<string?>? names = null;

        // Act
        var result = input.AnyPropertiesNotDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefault_WithNames_AllNamesNullWhiteSpace_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        var names = new List<string?> { " ", string.Empty, null };

        // Act
        var result = input.AnyPropertiesNotDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefault_WithNames_SpecifiedPropertyNonDefault_ReturnsTrue()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = default
        };

        var names = new List<string?> { nameof(TestPropertiesClass.Number) };

        // Act
        var result = input.AnyPropertiesNotDefault(names);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesNotDefault_WithNames_SpecifiedPropertyDefault_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = default,
            Text = "Hello"
        };

        var names = new List<string?> { nameof(TestPropertiesClass.Number) };

        // Act
        var result = input.AnyPropertiesNotDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefault_WithNames_NonMatchingPropertyNames_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        var names = new List<string?> { "NonExistent" };

        // Act
        var result = input.AnyPropertiesNotDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefaults_IEnumerable_WithNames_NullInput_ReturnsFalse()
    {
        // Arrange
        IEnumerable<TestPropertiesClass?>? input = null;
        var names = new List<string?> { nameof(TestPropertiesClass.Number), nameof(TestPropertiesClass.Text) };

        // Act
        var result = input.AnyPropertiesNotDefaults(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefaults_IEnumerable_WithNames_NullNames_ReturnsFalse()
    {
        // Arrange
        var obj = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        IEnumerable<TestPropertiesClass?> input = [obj];
        IEnumerable<string?>? names = null;

        // Act
        var result = input.AnyPropertiesNotDefaults(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefaults_IEnumerable_WithNames_EmptyNames_ReturnsFalse()
    {
        // Arrange
        var obj = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        IEnumerable<TestPropertiesClass?> input = [obj];
        var names = new List<string?>();

        // Act
        var result = input.AnyPropertiesNotDefaults(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefaults_IEnumerable_WithNames_NamesWithWhiteSpace_ReturnsFalse()
    {
        // Arrange
        var obj = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        IEnumerable<TestPropertiesClass?> input = [obj];
        var names = new List<string?> { " ", string.Empty, null };

        // Act
        var result = input.AnyPropertiesNotDefaults(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefaults_IEnumerable_WithNames_OneObjectSpecifiedPropertyNonDefault_ReturnsTrue()
    {
        // Arrange
        var obj1 = new TestPropertiesClass
        {
            Number = default,
            Text = "Hello"
        };

        var obj2 = new TestPropertiesClass
        {
            Number = 1,
            Text = "World"
        };

        IEnumerable<TestPropertiesClass?> input = [obj1, obj2];
        var names = new List<string?> { nameof(TestPropertiesClass.Number) };

        // Act
        var result = input.AnyPropertiesNotDefaults(names);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesNotDefaults_IEnumerable_WithNames_AllObjectsSpecifiedPropertiesDefault_ReturnsFalse()
    {
        // Arrange
        var obj1 = new TestPropertiesClass
        {
            Number = default,
            Text = "Hello"
        };

        var obj2 = new TestPropertiesClass
        {
            Number = default,
            Text = "World"
        };

        IEnumerable<TestPropertiesClass?> input = [obj1, obj2];
        var names = new List<string?> { nameof(TestPropertiesClass.Number) };

        // Act
        var result = input.AnyPropertiesNotDefaults(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefault_Params_WithNames_NullInput_ReturnsFalse()
    {
        // Arrange
        TestPropertiesClass? input = null;

        // Act
        var result = input.AnyPropertiesNotDefault(nameof(TestPropertiesClass.Number), nameof(TestPropertiesClass.Text));

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefault_Params_WithNames_NullNames_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        string[]? names = null;

        // Act
        var result = input.AnyPropertiesNotDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefault_Params_WithNames_EmptyNames_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        // Act
        var result = input.AnyPropertiesNotDefault([]);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefault_Params_WithNames_AllNamesWhiteSpace_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        // Act
        var result = input.AnyPropertiesNotDefault(" ", string.Empty, null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefault_Params_WithNames_SpecifiedPropertyNonDefault_ReturnsTrue()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = default
        };

        // Act
        var result = input.AnyPropertiesNotDefault(nameof(TestPropertiesClass.Number));

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesNotDefault_Params_WithNames_SpecifiedPropertyDefault_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = default,
            Text = "Hello"
        };

        // Act
        var result = input.AnyPropertiesNotDefault(nameof(TestPropertiesClass.Number));

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefault_Params_WithNames_NonMatchingNames_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        // Act
        var result = input.AnyPropertiesNotDefault("NonExistent");

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefaults_Params_WithNames_NullInput_ReturnsFalse()
    {
        // Arrange
        IEnumerable<TestPropertiesClass?>? input = null;

        // Act
        var result = YANObject.AnyPropertiesNotDefaults(input, nameof(TestPropertiesClass.Number), nameof(TestPropertiesClass.Text));

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefaults_Params_WithNames_NullNames_ReturnsFalse()
    {
        // Arrange
        var obj = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        IEnumerable<TestPropertiesClass?> input = [obj];
        string[]? names = null;

        // Act
        var result = YANObject.AnyPropertiesNotDefaults(input, names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefaults_Params_WithNames_EmptyNames_ReturnsFalse()
    {
        // Arrange
        var obj = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        IEnumerable<TestPropertiesClass?> input = [obj];

        // Act
        var result = YANObject.AnyPropertiesNotDefaults(input, Array.Empty<string>());

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefaults_Params_WithNames_AllNamesWhiteSpace_ReturnsFalse()
    {
        // Arrange
        var obj = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        IEnumerable<TestPropertiesClass?> input = [obj];

        // Act
        var result = YANObject.AnyPropertiesNotDefaults(input, " ", string.Empty, null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesNotDefaults_Params_WithNames_OneObjectSpecifiedPropertyNonDefault_ReturnsTrue()
    {
        // Arrange
        var obj1 = new TestPropertiesClass
        {
            Number = default,
            Text = "Hello"
        };

        var obj2 = new TestPropertiesClass
        {
            Number = 1,
            Text = "World"
        };

        IEnumerable<TestPropertiesClass?> input = [obj1, obj2];

        // Act
        var result = YANObject.AnyPropertiesNotDefaults(input, nameof(TestPropertiesClass.Number));

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesNotDefaults_Params_WithNames_AllObjectsSpecifiedPropertiesDefault_ReturnsFalse()
    {
        // Arrange
        var obj1 = new TestPropertiesClass
        {
            Number = default,
            Text = "Hello"
        };

        var obj2 = new TestPropertiesClass
        {
            Number = default,
            Text = "World"
        };

        IEnumerable<TestPropertiesClass?> input = [obj1, obj2];

        // Act
        var result = YANObject.AnyPropertiesNotDefaults(input, nameof(TestPropertiesClass.Number));

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyPropertiesDefault
    [Fact]
    public void AnyPropertiesDefault_NullInput_ReturnsFalse()
    {
        // Arrange
        TestPropertiesClass? input = null;

        // Act
        var result = input.AnyPropertiesDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefault_AllPropertiesNonDefault_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        // Act
        var result = input.AnyPropertiesDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefault_WithDefaultProperty_ReturnsTrue()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = default,
            Text = "Hello"
        };

        // Act
        var result = input.AnyPropertiesDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesDefaults_IEnumerable_NullInput_ReturnsFalse()
    {
        // Arrange
        IEnumerable<TestPropertiesClass?>? input = null;

        // Act
        var result = input.AnyPropertiesDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefaults_IEnumerable_EmptyInput_ReturnsFalse()
    {
        // Arrange
        IEnumerable<TestPropertiesClass?> input = [];

        // Act
        var result = input.AnyPropertiesDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefaults_IEnumerable_AllObjectsNonDefault_ReturnsFalse()
    {
        // Arrange
        var obj1 = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        var obj2 = new TestPropertiesClass
        {
            Number = 2,
            Text = "World"
        };

        IEnumerable<TestPropertiesClass?> input = [obj1, obj2];

        // Act
        var result = input.AnyPropertiesDefaults();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefaults_IEnumerable_OneObjectHasDefault_ReturnsTrue()
    {
        // Arrange
        var obj1 = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        var obj2 = new TestPropertiesClass
        {
            Number = default,
            Text = "World"
        };

        IEnumerable<TestPropertiesClass?> input = [obj1, obj2];

        // Act
        var result = input.AnyPropertiesDefaults();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesDefaults_Params_NullInput_ReturnsFalse()
    {
        // Arrange
        TestPropertiesClass?[]? input = null;

        // Act
        var result = YANObject.AnyPropertiesDefaults(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefaults_Params_EmptyInput_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<TestPropertiesClass?>();

        // Act
        var result = YANObject.AnyPropertiesDefaults(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefaults_Params_AllObjectsNonDefault_ReturnsFalse()
    {
        // Arrange
        var obj1 = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        var obj2 = new TestPropertiesClass
        {
            Number = 2,
            Text = "World"
        };

        // Act
        var result = YANObject.AnyPropertiesDefaults(obj1, obj2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefaults_Params_OneObjectHasDefault_ReturnsTrue()
    {
        // Arrange
        var obj1 = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        var obj2 = new TestPropertiesClass
        {
            Number = default,
            Text = "World"
        };

        // Act
        var result = YANObject.AnyPropertiesDefaults(obj1, obj2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesDefault_WithNames_NullInput_ReturnsFalse()
    {
        // Arrange
        TestPropertiesClass? input = null;
        var names = new List<string?> { nameof(TestPropertiesClass.Number), nameof(TestPropertiesClass.Text) };

        // Act
        var result = input.AnyPropertiesDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefault_WithNames_NullNames_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        IEnumerable<string?>? names = null;

        // Act
        var result = input.AnyPropertiesDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefault_WithNames_AllNamesNullWhiteSpace_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        var names = new List<string?> { " ", string.Empty, null };

        // Act
        var result = input.AnyPropertiesDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefault_WithNames_SpecifiedPropertyDefault_ReturnsTrue()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = default,
            Text = "Hello"
        };

        var names = new List<string?> { nameof(TestPropertiesClass.Number) };

        // Act
        var result = input.AnyPropertiesDefault(names);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesDefault_WithNames_SpecifiedPropertyNonDefault_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = default
        };

        var names = new List<string?> { nameof(TestPropertiesClass.Number) };

        // Act
        var result = input.AnyPropertiesDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefault_WithNames_NonMatchingPropertyNames_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };
        var names = new List<string?> { "NonExistent" };

        // Act
        var result = input.AnyPropertiesDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefaults_IEnumerable_WithNames_NullInput_ReturnsFalse()
    {
        // Arrange
        IEnumerable<TestPropertiesClass?>? input = null;
        var names = new List<string?> { nameof(TestPropertiesClass.Number), nameof(TestPropertiesClass.Text) };

        // Act
        var result = input.AnyPropertiesDefaults(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefaults_IEnumerable_WithNames_NullNames_ReturnsFalse()
    {
        // Arrange
        var obj = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        IEnumerable<TestPropertiesClass?> input = [obj];
        IEnumerable<string?>? names = null;

        // Act
        var result = input.AnyPropertiesDefaults(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefaults_IEnumerable_WithNames_EmptyNames_ReturnsFalse()
    {
        // Arrange
        var obj = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        IEnumerable<TestPropertiesClass?> input = [obj];
        var names = new List<string?>();

        // Act
        var result = input.AnyPropertiesDefaults(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefaults_IEnumerable_WithNames_NamesWithWhiteSpace_ReturnsFalse()
    {
        // Arrange
        var obj = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        IEnumerable<TestPropertiesClass?> input = [obj];
        var names = new List<string?> { " ", string.Empty, null };

        // Act
        var result = input.AnyPropertiesDefaults(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefaults_IEnumerable_WithNames_OneObjectSpecifiedPropertyDefault_ReturnsTrue()
    {
        // Arrange
        var obj1 = new TestPropertiesClass
        {
            Number = default,
            Text = "Hello"
        };

        var obj2 = new TestPropertiesClass
        {
            Number = 1,
            Text = "World"
        };

        IEnumerable<TestPropertiesClass?> input = [obj1, obj2];
        var names = new List<string?> { nameof(TestPropertiesClass.Number) };

        // Act
        var result = input.AnyPropertiesDefaults(names);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesDefaults_IEnumerable_WithNames_AllObjectsSpecifiedPropertiesNonDefault_ReturnsFalse()
    {
        // Arrange
        var obj1 = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        var obj2 = new TestPropertiesClass
        {
            Number = 2,
            Text = "World"
        };

        IEnumerable<TestPropertiesClass?> input = [obj1, obj2];
        var names = new List<string?> { nameof(TestPropertiesClass.Number) };

        // Act
        var result = input.AnyPropertiesDefaults(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefault_Params_WithNames_NullInput_ReturnsFalse()
    {
        // Arrange
        TestPropertiesClass? input = null;

        // Act
        var result = input.AnyPropertiesDefault(nameof(TestPropertiesClass.Number), nameof(TestPropertiesClass.Text));

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefault_Params_WithNames_NullNames_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        string[]? names = null;

        // Act
        var result = input.AnyPropertiesDefault(names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefault_Params_WithNames_EmptyNames_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        // Act
        var result = input.AnyPropertiesDefault([]);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefault_Params_WithNames_AllNamesWhiteSpace_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        // Act
        var result = input.AnyPropertiesDefault(" ", string.Empty, null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefault_Params_WithNames_SpecifiedPropertyDefault_ReturnsTrue()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = default,
            Text = "Hello"
        };

        // Act
        var result = input.AnyPropertiesDefault(nameof(TestPropertiesClass.Number));

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesDefault_Params_WithNames_SpecifiedPropertyNonDefault_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = default
        };

        // Act
        var result = input.AnyPropertiesDefault(nameof(TestPropertiesClass.Number));

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefault_Params_WithNames_NonMatchingNames_ReturnsFalse()
    {
        // Arrange
        var input = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        // Act
        var result = input.AnyPropertiesDefault("NonExistent");

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefaults_Params_WithNames_NullInput_ReturnsFalse()
    {
        // Arrange
        IEnumerable<TestPropertiesClass?>? input = null;

        // Act
        var result = YANObject.AnyPropertiesDefaults(input, nameof(TestPropertiesClass.Number), nameof(TestPropertiesClass.Text));

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefaults_Params_WithNames_NullNames_ReturnsFalse()
    {
        // Arrange
        var obj = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        IEnumerable<TestPropertiesClass?> input = [obj];
        string[]? names = null;

        // Act
        var result = YANObject.AnyPropertiesDefaults(input, names);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefaults_Params_WithNames_EmptyNames_ReturnsFalse()
    {
        // Arrange
        var obj = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        IEnumerable<TestPropertiesClass?> input = [obj];

        // Act
        var result = YANObject.AnyPropertiesDefaults(input, Array.Empty<string>());

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefaults_Params_WithNames_AllNamesWhiteSpace_ReturnsFalse()
    {
        // Arrange
        var obj = new TestPropertiesClass
        {
            Number = 1,
            Text = "Hello"
        };

        IEnumerable<TestPropertiesClass?> input = [obj];

        // Act
        var result = YANObject.AnyPropertiesDefaults(input, " ", string.Empty, null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPropertiesDefaults_Params_WithNames_OneObjectSpecifiedPropertyDefault_ReturnsTrue()
    {
        // Arrange
        var obj1 = new TestPropertiesClass
        {
            Number = default,
            Text = "Hello"
        };

        var obj2 = new TestPropertiesClass
        {
            Number = 1,
            Text = "World"
        };

        IEnumerable<TestPropertiesClass?> input = [obj1, obj2];

        // Act
        var result = YANObject.AnyPropertiesDefaults(input, nameof(TestPropertiesClass.Number));

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPropertiesDefaults_Params_WithNames_AllObjectsSpecifiedPropertiesNonDefault_ReturnsFalse()
    {
        // Arrange
        var obj1 = new TestPropertiesClass
        {
            Number = 1,
            Text = default
        };

        var obj2 = new TestPropertiesClass
        {
            Number = 2,
            Text = default
        };

        IEnumerable<TestPropertiesClass?> input = [obj1, obj2];

        // Act
        var result = YANObject.AnyPropertiesDefaults(input, nameof(TestPropertiesClass.Number));

        // Assert
        Assert.False(result);
    }
    #endregion
}

public class TestPropertiesClass
{
    public int Number { get; set; }

    public string? Text { get; set; }
}