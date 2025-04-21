using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq.Expressions;
using YANLib.Implementation.Object;
using YANLib.Implementation.Text;
using static System.Linq.Expressions.Expression;
using static System.Reflection.BindingFlags;
using static System.Type;

namespace YANLib.Implementation;

internal static partial class YANExpression
{
    private static readonly ConcurrentDictionary<(Type Type, string PropertyName, string ParameterName), LambdaExpression> Cache = new();

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

        var key = (typeof(T), propertyName, parameterName);

        if (Cache.TryGetValue(key, out var existing))
        {
            return (Expression<Func<T, object>>)existing;
        }

        Expression body;
        var parameter = Parameter(typeof(T), parameterName);
        var propInfo = typeof(T).GetProperty(propertyName, Public | Instance);

        if (propInfo.IsNotNullImplement())
        {
            body = Property(parameter, propInfo);
        }
        else
        {
            var methodInfo = typeof(T).GetMethod(propertyName, Public | Instance, null, EmptyTypes, null);

            body = methodInfo.IsNotNullImplement() ? Constant(methodInfo.GetType(), typeof(object)) : throw new ArgumentException($"Type {typeof(T).Name} does not contain a property named '{propertyName}'.", nameof(propertyName));
        }

        if (body.Type.IsValueType)
        {
            body = Convert(body, typeof(object));
        }

        var lambda = Lambda<Func<T, object>>(body, parameter);

        Cache[key] = lambda;

        return lambda;
    }

    internal static void ClearExpressionCacheImplement() => Cache.Clear();
}
