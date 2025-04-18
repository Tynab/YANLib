using System.Diagnostics;
using System.Linq.Expressions;
using static YANLib.Implementation.YANExpression;

namespace YANLib;

/// <summary>
/// Provides methods to build LINQ <see cref="Expression{TDelegate}"/> trees
/// for common scenarios, such as accessing a property by name.
/// </summary>
public static partial class YANExpression
{
    /// <summary>
    /// Creates a lambda expression that, given an instance of <typeparamref name="T"/>,
    /// accesses the specified property and converts its value to <see cref="object"/>.
    /// </summary>
    /// <typeparam name="T">The type of the input parameter.</typeparam>
    /// <param name="parameterName">
    /// The name to use for the lambda parameter (e.g. "x" in <c>x => x.Property</c>).
    /// </param>
    /// <param name="propertyName">
    /// The name of the property on <typeparamref name="T"/> to access.
    /// </param>
    /// <returns>
    /// An <see cref="Expression{Func{T, object}}"/> representing
    /// <c>param => (object)param.&lt;propertyName&gt;</c>.
    /// </returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static Expression<Func<T, object>> PropertyExpression<T>(string parameterName, string propertyName) => PropertyExpressionImplement<T>(parameterName, propertyName);
}
