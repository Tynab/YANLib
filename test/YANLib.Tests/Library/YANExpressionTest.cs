using System.Linq.Expressions;

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

    [Fact]
    public void PropertyExpression_SamePropertyDifferentParameterNames_UsesEachParameterName_Expression()
    {
        // Arrange
        var testObj = new ParameterNameTestClass { Name = "Test" };

        // Act
        var first = YANExpression.PropertyExpression<ParameterNameTestClass>("x", "Name");
        var second = YANExpression.PropertyExpression<ParameterNameTestClass>("u", "Name");

        // Assert (8.3.3 cached by type and property only and returned x => x.Name for "u")
        Assert.Equal("x", first.Parameters[0].Name);
        Assert.Equal("u", second.Parameters[0].Name);
        Assert.Equal("u => u.Name", second.ToString());
        Assert.Equal("Test", second.Compile()(testObj));
    }

    [Fact]
    public void PropertyExpression_ParameterlessMethod_CallsMethod_Expression()
    {
        // Arrange
        var testObj = new MethodTestClass { Name = "Test" };

        // Act
        var result = YANExpression.PropertyExpression<MethodTestClass>("p", "Describe");
        var lengthResult = YANExpression.PropertyExpression<MethodTestClass>("p", "nameLength");

        // Assert (8.3.3 built a constant System.Reflection.RuntimeMethodInfo type instead of the call)
        Assert.Equal("p => p.Describe()", result.ToString());
        Assert.Equal("Name: Test", result.Compile()(testObj));
        Assert.Equal(4, lengthResult.Compile()(testObj));
    }

    [Fact]
    public void PropertyExpression_VoidMethod_ThrowsArgumentException_Expression()
    {
        // Act
        var exception = Assert.Throws<ArgumentException>(() => YANExpression.PropertyExpression<MethodTestClass>("p", "Touch"));

        // Assert
        Assert.Equal("propertyName", exception.ParamName);
        Assert.Contains("does not contain a property named", exception.Message);
    }

    [Fact]
    public void PropertyExpression_GenericMethod_ThrowsArgumentException_Expression()
    {
        // Act
        var exception = Assert.Throws<ArgumentException>(() => YANExpression.PropertyExpression<MethodTestClass>("p", "Create"));

        // Assert
        Assert.Equal("propertyName", exception.ParamName);
    }

    [Fact]
    public void PropertyExpression_HiddenProperty_UsesMostDerived_Expression()
    {
        // Arrange
        var testObj = new HidingTestClass { Name = 5 };

        // Act
        var result = YANExpression.PropertyExpression<HidingTestClass>("x", "Name");

        // Assert (8.3.3 threw AmbiguousMatchException)
        Assert.Equal(typeof(int), ((UnaryExpression)result.Body).Operand.Type);
        Assert.Equal(5, result.Compile()(testObj));
    }

    [Fact]
    public void PropertyExpression_InheritedProperty_ReturnsExpression_Expression()
    {
        // Arrange
        var testObj = new HidingTestClass();

        // Act
        var result = YANExpression.PropertyExpression<HidingTestClass>("x", "Inherited");

        // Assert
        Assert.Equal("inherited", result.Compile()(testObj));
    }

    [Fact]
    public void PropertyExpression_NamesDifferingOnlyInCase_ExactMatchWins_Expression()
    {
        // Arrange
        var testObj = new CaseTestClass();

        // Act
        var upper = YANExpression.PropertyExpression<CaseTestClass>("x", "Name");
        var lower = YANExpression.PropertyExpression<CaseTestClass>("x", "name");

        // Assert (8.3.3 threw AmbiguousMatchException; a case-insensitive lookup alone could pick the wrong one)
        Assert.Equal("x => x.Name", upper.ToString());
        Assert.Equal("x => x.name", lower.ToString());
        Assert.Equal("Upper", upper.Compile()(testObj));
        Assert.Equal("lower", lower.Compile()(testObj));
    }

    [Fact]
    public void PropertyExpression_DifferentCase_FindsProperty_Expression()
    {
        // Arrange
        var testObj = new TestClass { Age = 7 };

        // Act
        var result = YANExpression.PropertyExpression<TestClass>("p", "aGE");

        // Assert
        Assert.Equal(7, result.Compile()(testObj));
    }

    [Fact]
    public void PropertyExpression_Indexer_ThrowsArgumentException_Expression()
    {
        // Act
        var exception = Assert.Throws<ArgumentException>(() => YANExpression.PropertyExpression<IndexerTestClass>("p", "Item"));

        // Assert
        Assert.Contains("does not contain a property named", exception.Message);
    }

    [Fact]
    public void PropertyExpression_ConcurrentFirstCalls_ReturnSameInstance_Expression()
    {
        // Each round uses a new spelling of the property name, so every round starts with a cache miss; the threads are released together
        // by a barrier. 8.3.3 did TryGetValue, build, then an unconditional insert, so racing callers each got their own expression.
        const int threadCount = 8;
        const int rounds = 64;
        const string propertyName = "ConcurrentPropertyName";

        for (var round = 0; round < rounds; round++)
        {
            // Arrange
            var spelling = new string([.. propertyName.Select((c, i) => i < 6 && (round >> i & 1) is 1 ? char.ToLowerInvariant(c) == c ? char.ToUpperInvariant(c) : char.ToLowerInvariant(c) : c)]);
            var results = new Expression<Func<ConcurrencyTestClass, object>>[threadCount];

            using var barrier = new Barrier(threadCount);

            var threads = Enumerable.Range(0, threadCount).Select(i => new Thread(() =>
            {
                barrier.SignalAndWait();
                results[i] = YANExpression.PropertyExpression<ConcurrencyTestClass>("p", spelling);
            })).ToArray();

            // Act
            foreach (var thread in threads)
            {
                thread.Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            // Assert
            Assert.All(results, x => Assert.Same(results[0], x));
        }
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

    private sealed class ParameterNameTestClass
    {
        public string? Name { get; set; }
    }

    private sealed class MethodTestClass
    {
        public string? Name { get; set; }

        public string Describe() => $"Name: {Name}";

        public int NameLength() => Name?.Length ?? 0;

        public void Touch()
        {
        }

        public T? Create<T>() => default;
    }

    private class HiddenTestClass
    {
        public string? Name { get; set; }

        public string Inherited => "inherited";
    }

    private sealed class HidingTestClass : HiddenTestClass
    {
        public new int Name { get; set; }
    }

    private sealed class CaseTestClass
    {
        public string Name { get; set; } = "Upper";

#pragma warning disable IDE1006 // Two properties that differ only in case are the point of this test type.
        public string name { get; set; } = "lower";
#pragma warning restore IDE1006
    }

    private sealed class IndexerTestClass
    {
        public int this[int index] => index;
    }

    private sealed class ConcurrencyTestClass
    {
        public string? ConcurrentPropertyName { get; set; }
    }
}
