using System.Linq.Expressions;

namespace YANLib.Tests.Library;

public partial class YANExpressionTest
{
    private class TestClass
    {
        public int Number { get; set; }

        public string? Text { get; set; }
    }

    [Fact]
    public void PropertyExpression_ValidPropertyNumber_BuildsCorrectExpression()
    {
        // Arrange & Act
        var expr = YANExpression.PropertyExpression<TestClass>("t", nameof(TestClass.Number));

        // Assert
        Assert.Equal("t", expr.Parameters[0].Name);

        var unary = Assert.IsType<UnaryExpression>(expr.Body);

        Assert.Equal(typeof(object), unary.Type);

        var member = Assert.IsAssignableFrom<MemberExpression>(unary.Operand);

        Assert.Equal(nameof(TestClass.Number), member.Member.Name);
    }

    [Fact]
    public void PropertyExpression_ValidPropertyText_CompiledFunctionReturnsValue()
    {
        // Arrange
        var expr = YANExpression.PropertyExpression<TestClass>("x", nameof(TestClass.Text));
        var func = expr.Compile();
        var instance = new TestClass
        {
            Text = "hello"
        };

        // Act
        var result = func(instance);

        // Assert
        Assert.Equal("hello", result);
    }

    [Fact]
    public void PropertyExpression_InvalidPropertyName_ThrowsArgumentException() => Assert.Throws<ArgumentException>(() => YANExpression.PropertyExpression<TestClass>("t", "NonExistent"));
}
