namespace YANLib.Tests.Library;

public partial class YANExpressionTest
{
    #region PropertyExpression

    [Fact]
    public void PropertyExpression_ValidProperty_ReturnsExpression_Expression()
    {
        // Arrange
        var parameterName = "p";
        var propertyName = "Name";

        // Act
        var result = YANExpression.PropertyExpression<TestClass>(parameterName, propertyName);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(typeof(Func<TestClass, object>), result.Type);

        var func = result.Compile();
        var testObj = new TestClass
        {
            Name = "Test",
            Age = 30
        };

        Assert.Equal("Test", func(testObj));
    }

    [Fact]
    public void PropertyExpression_ValidNumericProperty_ReturnsExpression_Expression()
    {
        // Arrange
        var parameterName = "p";
        var propertyName = "Age";

        // Act
        var result = YANExpression.PropertyExpression<TestClass>(parameterName, propertyName);

        // Assert
        Assert.NotNull(result);

        var func = result.Compile();
        var testObj = new TestClass
        {
            Name = "Test",
            Age = 30
        };

        Assert.Equal(30, func(testObj));
    }

    [Fact]
    public void PropertyExpression_ValidBoolProperty_ReturnsExpression_Expression()
    {
        // Arrange
        var parameterName = "p";
        var propertyName = "IsActive";

        // Act
        var result = YANExpression.PropertyExpression<TestClass>(parameterName, propertyName);

        // Assert
        Assert.NotNull(result);

        var func = result.Compile();
        var testObj = new TestClass
        {
            IsActive = true
        };

        Assert.Equal(true, func(testObj));
    }

    [Fact]
    public void PropertyExpression_ValidDateTimeProperty_ReturnsExpression_Expression()
    {
        // Arrange
        var parameterName = "p";
        var propertyName = "CreatedDate";
        var date = new DateTime(2023, 6, 15);

        // Act
        var result = YANExpression.PropertyExpression<TestClass>(parameterName, propertyName);

        // Assert
        Assert.NotNull(result);

        var func = result.Compile();
        var testObj = new TestClass
        {
            CreatedDate = date
        };

        Assert.Equal(date, func(testObj));
    }

    [Fact]
    public void PropertyExpression_NullParameterName_ThrowsArgumentException_Expression()
    {
        // Arrange
        string? parameterName = null;
        var propertyName = "Name";

        // Act
        var exception = Assert.Throws<ArgumentException>(() => YANExpression.PropertyExpression<TestClass>(parameterName!, propertyName));

        // Assert
        Assert.Contains("Parameter name cannot be null or whitespace", exception.Message);
    }

    [Fact]
    public void PropertyExpression_EmptyParameterName_ThrowsArgumentException_Expression()
    {
        // Arrange
        var parameterName = "";
        var propertyName = "Name";

        // Act
        var exception = Assert.Throws<ArgumentException>(() => YANExpression.PropertyExpression<TestClass>(parameterName, propertyName));

        // Assert
        Assert.Contains("Parameter name cannot be null or whitespace", exception.Message);
    }

    [Fact]
    public void PropertyExpression_WhitespaceParameterName_ThrowsArgumentException_Expression()
    {
        // Arrange
        var parameterName = "   ";
        var propertyName = "Name";

        // Act
        var exception = Assert.Throws<ArgumentException>(() => YANExpression.PropertyExpression<TestClass>(parameterName, propertyName));

        // Assert
        Assert.Contains("Parameter name cannot be null or whitespace", exception.Message);
    }

    [Fact]
    public void PropertyExpression_NullPropertyName_ThrowsArgumentException_Expression()
    {
        // Arrange
        var parameterName = "p";
        string? propertyName = null;

        // Act
        var exception = Assert.Throws<ArgumentException>(() => YANExpression.PropertyExpression<TestClass>(parameterName, propertyName!));

        // Assert
        Assert.Contains("Property name cannot be null or whitespace", exception.Message);
    }

    [Fact]
    public void PropertyExpression_EmptyPropertyName_ThrowsArgumentException_Expression()
    {
        // Arrange
        var parameterName = "p";
        var propertyName = "";

        // Act
        var exception = Assert.Throws<ArgumentException>(() => YANExpression.PropertyExpression<TestClass>(parameterName, propertyName));

        // Assert
        Assert.Contains("Property name cannot be null or whitespace", exception.Message);
    }

    [Fact]
    public void PropertyExpression_WhitespacePropertyName_ThrowsArgumentException_Expression()
    {
        // Arrange
        var parameterName = "p";
        var propertyName = "   ";

        // Act
        var exception = Assert.Throws<ArgumentException>(() => YANExpression.PropertyExpression<TestClass>(parameterName, propertyName));

        // Assert
        Assert.Contains("Property name cannot be null or whitespace", exception.Message);
    }

    [Fact]
    public void PropertyExpression_NonExistentProperty_ThrowsArgumentException_Expression()
    {
        // Arrange
        var parameterName = "p";
        var propertyName = "NonExistentProperty";

        // Act
        var exception = Assert.Throws<ArgumentException>(() => YANExpression.PropertyExpression<TestClass>(parameterName, propertyName));

        // Assert
        Assert.Contains("does not contain a property named", exception.Message);
    }

    [Fact]
    public void PropertyExpression_CachingWorks_ReturnsSameInstance_Expression()
    {
        // Arrange
        var parameterName = "p";
        var propertyName = "Name";

        // Act
        var result1 = YANExpression.PropertyExpression<TestClass>(parameterName, propertyName);
        var result2 = YANExpression.PropertyExpression<TestClass>(parameterName, propertyName);

        // Assert
        Assert.Same(result1, result2);
    }

    [Fact]
    public void PropertyExpression_DifferentTypes_ReturnsDifferentExpressions_Expression()
    {
        // Arrange
        var parameterName = "p";
        var propertyName = "Name";

        // Act
        var result1 = YANExpression.PropertyExpression<TestClass>(parameterName, propertyName);
        var result2 = YANExpression.PropertyExpression<AnotherTestClass>(parameterName, propertyName);

        // Assert
        Assert.NotSame(result1, result2);
    }

    #endregion

    private class TestClass
    {
        public string? Name { get; set; }

        public int Age { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }
    }

    private class AnotherTestClass
    {
        public string? Name { get; set; }
    }
}
