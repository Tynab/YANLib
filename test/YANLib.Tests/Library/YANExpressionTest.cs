namespace YANLib.Tests.Library;

public partial class YANExpressionTest
{
    #region PropertyExpression

    [Fact]
    public void PropertyExpression_StringProperty_ReturnsCorrectExpression()
    {
        // Arrange
        var parameterName = "x";
        var propertyName = "StringProperty";

        // Act
        var expression = YANExpression.PropertyExpression<TestClass>(parameterName, propertyName);
        var func = expression.Compile();
        var result = func(new TestClass());

        // Assert
        Assert.Equal("Test String", result);
        Assert.Equal(parameterName, expression.Parameters[0].Name);
        Assert.Equal(typeof(object), expression.ReturnType);
    }

    [Fact]
    public void PropertyExpression_IntProperty_ReturnsCorrectExpression()
    {
        // Arrange
        var parameterName = "x";
        var propertyName = "IntProperty";

        // Act
        var expression = YANExpression.PropertyExpression<TestClass>(parameterName, propertyName);
        var func = expression.Compile();
        var result = func(new TestClass());

        // Assert
        Assert.Equal(42, result);
        Assert.Equal(parameterName, expression.Parameters[0].Name);
        Assert.Equal(typeof(object), expression.ReturnType);
    }

    [Fact]
    public void PropertyExpression_BoolProperty_ReturnsCorrectExpression()
    {
        // Arrange
        var parameterName = "x";
        var propertyName = "BoolProperty";

        // Act
        var expression = YANExpression.PropertyExpression<TestClass>(parameterName, propertyName);
        var func = expression.Compile();
        var result = func(new TestClass());

        // Assert
        Assert.Equal(true, result);
        Assert.Equal(parameterName, expression.Parameters[0].Name);
        Assert.Equal(typeof(object), expression.ReturnType);
    }

    [Fact]
    public void PropertyExpression_DateProperty_ReturnsCorrectExpression()
    {
        // Arrange
        var parameterName = "x";
        var propertyName = "DateProperty";

        // Act
        var expression = YANExpression.PropertyExpression<TestClass>(parameterName, propertyName);
        var func = expression.Compile();
        var result = func(new TestClass());

        // Assert
        Assert.Equal(new DateTime(2023, 7, 15), result);
        Assert.Equal(parameterName, expression.Parameters[0].Name);
        Assert.Equal(typeof(object), expression.ReturnType);
    }

    [Fact]
    public void PropertyExpression_NestedProperty_ReturnsCorrectExpression()
    {
        // Arrange
        var parameterName = "x";
        var propertyName = "NestedProperty";

        // Act
        var expression = YANExpression.PropertyExpression<TestClass>(parameterName, propertyName);
        var func = expression.Compile();
        var result = func(new TestClass());

        // Assert
        Assert.NotNull(result);
        _ = Assert.IsType<TestNestedClass>(result);
        Assert.Equal(parameterName, expression.Parameters[0].Name);
        Assert.Equal(typeof(object), expression.ReturnType);
    }

    [Fact]
    public void PropertyExpression_ListProperty_ReturnsCorrectExpression()
    {
        // Arrange
        var parameterName = "x";
        var propertyName = "ListProperty";

        // Act
        var expression = YANExpression.PropertyExpression<TestClass>(parameterName, propertyName);
        var func = expression.Compile();
        var result = func(new TestClass()) as List<string>;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Equal("Item1", result[0]);
        Assert.Equal("Item2", result[1]);
        Assert.Equal(parameterName, expression.Parameters[0].Name);
        Assert.Equal(typeof(object), expression.ReturnType);
    }

    [Fact]
    public void PropertyExpression_DifferentParameterName_ReturnsCorrectExpression()
    {
        // Arrange
        var parameterName = "testParam";
        var propertyName = "StringProperty";

        // Act
        var expression = YANExpression.PropertyExpression<TestClass>(parameterName, propertyName);
        var func = expression.Compile();
        var result = func(new TestClass());

        // Assert
        Assert.Equal("Test String", result);
        Assert.Equal(parameterName, expression.Parameters[0].Name);
        Assert.Equal(typeof(object), expression.ReturnType);
    }

    [Fact]
    public void PropertyExpression_SamePropertyMultipleCalls_ReturnsCachedExpression()
    {
        // Arrange
        var parameterName = "x";
        var propertyName = "StringProperty";

        // Act
        var expression1 = YANExpression.PropertyExpression<TestClass>(parameterName, propertyName);
        var expression2 = YANExpression.PropertyExpression<TestClass>(parameterName, propertyName);

        // Assert
        Assert.Same(expression1, expression2);
    }

    [Fact]
    public void PropertyExpression_DifferentParameterNameSameProperty_ReturnsCachedExpression()
    {
        // Arrange
        var parameterName1 = "x";
        var parameterName2 = "y";
        var propertyName = "StringProperty";

        // Act
        var expression1 = YANExpression.PropertyExpression<TestClass>(parameterName1, propertyName);
        var expression2 = YANExpression.PropertyExpression<TestClass>(parameterName2, propertyName);

        // Assert
        Assert.Same(expression1, expression2);
    }

    [Fact]
    public void PropertyExpression_DifferentTypesSameProperty_ReturnsDifferentExpressions()
    {
        // Arrange
        var parameterName = "x";
        var propertyName = "ToString";

        // Act
        var expression1 = YANExpression.PropertyExpression<TestClass>(parameterName, propertyName);
        var expression2 = YANExpression.PropertyExpression<TestNestedClass>(parameterName, propertyName);

        // Assert
        Assert.NotSame(expression1, expression2);
    }

    [Fact]
    public void PropertyExpression_ModifyPropertyValue_ReflectsChanges()
    {
        // Arrange
        var parameterName = "x";
        var propertyName = "StringProperty";
        var testObj = new TestClass
        {
            StringProperty = "Original Value"
        };

        // Act
        var expression = YANExpression.PropertyExpression<TestClass>(parameterName, propertyName);
        var func = expression.Compile();
        var originalResult = func(testObj);

        testObj.StringProperty = "Modified Value";

        var modifiedResult = func(testObj);

        // Assert
        Assert.Equal("Original Value", originalResult);
        Assert.Equal("Modified Value", modifiedResult);
    }

    #endregion

    #region Error Cases

    [Fact]
    public void PropertyExpression_NullParameterName_ThrowsArgumentException()
    {
        // Arrange
        string? parameterName = null;
        var propertyName = "StringProperty";

        // Act
        var exception = Assert.Throws<ArgumentException>(() => YANExpression.PropertyExpression<TestClass>(parameterName!, propertyName));

        // Assert
        Assert.Equal("parameterName", exception.ParamName);
        Assert.Contains("Parameter name cannot be null or whitespace", exception.Message);
    }

    [Fact]
    public void PropertyExpression_EmptyParameterName_ThrowsArgumentException()
    {
        // Arrange
        var parameterName = "";
        var propertyName = "StringProperty";

        // Act
        var exception = Assert.Throws<ArgumentException>(() => YANExpression.PropertyExpression<TestClass>(parameterName, propertyName));

        // Assert
        Assert.Equal("parameterName", exception.ParamName);
        Assert.Contains("Parameter name cannot be null or whitespace", exception.Message);
    }

    [Fact]
    public void PropertyExpression_WhitespaceParameterName_ThrowsArgumentException()
    {
        // Arrange
        var parameterName = "   ";
        var propertyName = "StringProperty";

        // Act
        var exception = Assert.Throws<ArgumentException>(() => YANExpression.PropertyExpression<TestClass>(parameterName, propertyName));

        // Assert
        Assert.Equal("parameterName", exception.ParamName);
        Assert.Contains("Parameter name cannot be null or whitespace", exception.Message);
    }

    [Fact]
    public void PropertyExpression_NullPropertyName_ThrowsArgumentException()
    {
        // Arrange
        var parameterName = "x";
        string? propertyName = null;

        // Act
        var exception = Assert.Throws<ArgumentException>(() => YANExpression.PropertyExpression<TestClass>(parameterName, propertyName!));

        // Assert
        Assert.Equal("propertyName", exception.ParamName);
        Assert.Contains("Property name cannot be null or whitespace", exception.Message);
    }

    [Fact]
    public void PropertyExpression_EmptyPropertyName_ThrowsArgumentException()
    {
        // Arrange
        var parameterName = "x";
        var propertyName = "";

        // Act
        var exception = Assert.Throws<ArgumentException>(() => YANExpression.PropertyExpression<TestClass>(parameterName, propertyName));

        // Assert
        Assert.Equal("propertyName", exception.ParamName);
        Assert.Contains("Property name cannot be null or whitespace", exception.Message);
    }

    [Fact]
    public void PropertyExpression_WhitespacePropertyName_ThrowsArgumentException()
    {
        // Arrange
        var parameterName = "x";
        var propertyName = "   ";

        // Act
        var exception = Assert.Throws<ArgumentException>(() => YANExpression.PropertyExpression<TestClass>(parameterName, propertyName));

        // Assert
        Assert.Equal("propertyName", exception.ParamName);
        Assert.Contains("Property name cannot be null or whitespace", exception.Message);
    }

    [Fact]
    public void PropertyExpression_NonExistentProperty_ThrowsArgumentException()
    {
        // Arrange
        var parameterName = "x";
        var propertyName = "NonExistentProperty";

        // Act
        var exception = Assert.Throws<ArgumentException>(() => YANExpression.PropertyExpression<TestClass>(parameterName, propertyName));

        // Assert
        Assert.Equal("propertyName", exception.ParamName);
        Assert.Contains($"Type {typeof(TestClass).Name} does not contain a property named '{propertyName}'", exception.Message);
    }

    #endregion

    #region Advanced Usage

    [Fact]
    public void PropertyExpression_UseInLinqWhere_FiltersCorrectly()
    {
        // Arrange
        var items = new List<TestClass>
        {
            new() { IntProperty = 10 },
            new() { IntProperty = 20 },
            new() { IntProperty = 30 }
        };

        var parameterName = "x";
        var propertyName = "IntProperty";

        // Act
        var propExpression = YANExpression.PropertyExpression<TestClass>(parameterName, propertyName);
        var func = propExpression.Compile();
        var result = items.Where(x => (int)func(x) > 15).ToList();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal(20, result[0].IntProperty);
        Assert.Equal(30, result[1].IntProperty);
    }

    [Fact]
    public void PropertyExpression_UseInLinqOrderBy_SortsCorrectly()
    {
        // Arrange
        var items = new List<TestClass>
        {
            new() { IntProperty = 30 },
            new() { IntProperty = 10 },
            new() { IntProperty = 20 }
        };

        var parameterName = "x";
        var propertyName = "IntProperty";

        // Act
        var propExpression = YANExpression.PropertyExpression<TestClass>(parameterName, propertyName);
        var func = propExpression.Compile();
        var result = items.OrderBy(x => (int)func(x)).ToList();

        // Assert
        Assert.Equal(10, result[0].IntProperty);
        Assert.Equal(20, result[1].IntProperty);
        Assert.Equal(30, result[2].IntProperty);
    }

    [Fact]
    public void PropertyExpression_UseInLinqSelect_TransformsCorrectly()
    {
        // Arrange
        var items = new List<TestClass>
        {
            new() { StringProperty = "Apple" },
            new() { StringProperty = "Banana" },
            new() { StringProperty = "Cherry" }
        };

        var parameterName = "x";
        var propertyName = "StringProperty";

        // Act
        var propExpression = YANExpression.PropertyExpression<TestClass>(parameterName, propertyName);
        var func = propExpression.Compile();
        var result = items.Select(x => func(x).ToString()).ToList();

        // Assert
        Assert.Equal(3, result.Count);
        Assert.Equal("Apple", result[0]);
        Assert.Equal("Banana", result[1]);
        Assert.Equal("Cherry", result[2]);
    }

    #endregion

    #region Performance

    [Fact]
    public void PropertyExpression_CachingPerformance_FasterOnSubsequentCalls()
    {
        // Arrange
        var parameterName = "x";
        var propertyName = "StringProperty";

        // Act - First call (uncached)
        var sw1 = System.Diagnostics.Stopwatch.StartNew();

        _ = YANExpression.PropertyExpression<TestClass>(parameterName, propertyName);
        sw1.Stop();

        var firstCallTime = sw1.ElapsedTicks;

        // Act - Second call (cached)
        var sw2 = System.Diagnostics.Stopwatch.StartNew();

        _ = YANExpression.PropertyExpression<TestClass>(parameterName, propertyName);
        sw2.Stop();

        var secondCallTime = sw2.ElapsedTicks;

        // Assert
        Assert.True(secondCallTime < firstCallTime, $"Second call ({secondCallTime} ticks) should be faster than first call ({firstCallTime} ticks)");
    }

    #endregion

    #region Special Cases

    [Fact]
    public void PropertyExpression_NullableProperty_HandlesCorrectly()
    {
        // Arrange
        var testObj = new TestClass { NestedProperty = null };
        var parameterName = "x";
        var propertyName = "NestedProperty";

        // Act
        var expression = YANExpression.PropertyExpression<TestClass>(parameterName, propertyName);
        var func = expression.Compile();
        var result = func(testObj);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void PropertyExpression_InheritedProperty_AccessesCorrectly()
    {
        // Arrange
        var parameterName = "x";
        var propertyName = "ToString";

        // Act
        var expression = YANExpression.PropertyExpression<TestClass>(parameterName, propertyName);
        var func = expression.Compile();
        var result = func(new TestClass());

        // Assert
        Assert.NotNull(result);
        Assert.Contains("MethodInfo", result.ToString());
    }

    #endregion

    #region Test Classes

    private class TestClass
    {
        public string StringProperty { get; set; } = "Test String";

        public int IntProperty { get; set; } = 42;

        public bool BoolProperty { get; set; } = true;

        public DateTime DateProperty { get; set; } = new DateTime(2023, 7, 15);

        public TestNestedClass? NestedProperty { get; set; } = new TestNestedClass();

        public List<string> ListProperty { get; set; } = ["Item1", "Item2"];
    }

    private class TestNestedClass
    {
        public string NestedStringProperty { get; set; } = "Nested String";
    }

    #endregion

}
