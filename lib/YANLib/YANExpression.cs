using System.Diagnostics;
using System.Linq.Expressions;
using static YANLib.Implementation.YANExpression;

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
    /// The property is looked up among the readable, non-indexer public instance properties of <typeparamref name="T"/>, inherited ones included:
    /// an exact (case-sensitive) match wins over a case-insensitive one, and for a property hidden with <c>new</c> the most-derived one is used.
    /// If no property matches, a public parameterless instance method with a return value and that name is called instead (<c>x => x.Method()</c>),
    /// e.g. <c>ToString</c> or <c>GetType</c>; validate untrusted names (such as user-supplied sort fields) with
    /// <see cref="YANObject.IsValidField{T}(string)"/> first.
    /// If the property is a value type, it will be automatically boxed to an object.
    /// The expression tree (not a compiled delegate) is cached per type, parameter name and property name, so repeated calls return the same instance;
    /// <see cref="LambdaExpression.Compile()"/> is not cached. The cache is never trimmed and grows with every distinct combination.
    /// </remarks>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="parameterName"/> or <paramref name="propertyName"/> is null or whitespace,
    /// or when neither a property nor a suitable parameterless method with the specified name exists on type <typeparamref name="T"/>.
    /// </exception>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static Expression<Func<T, object>> PropertyExpression<T>(string parameterName, string propertyName) => PropertyExpressionImplement<T>(parameterName, propertyName);
}
