using System.Diagnostics;
using System.Linq.Expressions;

namespace YANLib;

/// <summary>
/// Provides extension methods for working with expressions.
/// </summary>
/// <remarks>
/// This class contains methods for creating and manipulating expressions,
/// which are useful for dynamic property access and reflection-based operations.
/// </remarks>
public static partial class YANExpression
{
    /// <summary>
    /// Creates a strongly-typed expression that accesses a property of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type containing the property to access.</typeparam>
    /// <param name="parameterName">The name of the parameter in the resulting lambda expression. Cannot be null or whitespace.</param>
    /// <param name="propertyName">The name of the property to access. Cannot be null or whitespace.</param>
    /// <returns>A lambda expression that accesses the specified property on an object of type <typeparamref name="T"/>.</returns>
    /// <remarks>
    /// This method creates an expression of the form: <c>x => x.PropertyName</c> where x is the parameter name.
    /// The resulting expression is cached for better performance when the same property is accessed multiple times.
    /// If the property is a value type, it will be automatically boxed to an object.
    /// </remarks>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="parameterName"/> or <paramref name="propertyName"/> is null or whitespace,
    /// or when the specified property does not exist on type <typeparamref name="T"/>.
    /// </exception>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static Expression<Func<T, object>> PropertyExpression<T>(string parameterName, string propertyName) => PropertyExpressionImplement<T>(parameterName, propertyName);
}
