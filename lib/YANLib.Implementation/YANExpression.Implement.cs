using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq.Expressions;
using static System.Linq.Expressions.Expression;
using static System.Reflection.BindingFlags;

namespace YANLib.Implementation;

internal static partial class YANExpression
{
    private static readonly ConcurrentDictionary<(Type Type, string PropertyName), LambdaExpression> Cache = new();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static Expression<Func<T, object>> PropertyExpressionImplement<T>(string parameterName, string propertyName)
    {
        if (parameterName.IsNullWhiteSpaceImplement())
        {
            throw new ArgumentException("Parameter name cannot be null or whitespace.", nameof(parameterName));
        }

        if (propertyName.IsNullWhiteSpaceImplement())
        {
            throw new ArgumentException("Property name cannot be null or whitespace.", nameof(propertyName));
        }

        var key = (typeof(T), propertyName);

        if (Cache.TryGetValue(key, out var existing))
        {
            return (Expression<Func<T, object>>)existing;
        }

        var propInfo = typeof(T).GetProperty(propertyName, Instance | Public | IgnoreCase) ?? throw new ArgumentException($"Type {typeof(T).Name} does not contain a property named '{propertyName}'.", nameof(propertyName));
        var parameter = Parameter(typeof(T), parameterName);
        Expression body = Property(parameter, propInfo);

        if (body.Type.IsValueType)
        {
            body = Convert(body, typeof(object));
        }

        var lambda = Lambda<Func<T, object>>(body, parameter);

        Cache[key] = lambda;

        return lambda;
    }
}
