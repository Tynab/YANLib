using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq.Expressions;
using static System.Linq.Expressions.Expression;
using static System.Reflection.BindingFlags;
using static System.Type;

namespace YANLib.Implementation;

internal static partial class YANExpression
{
    private static readonly ConcurrentDictionary<(Type Type, string ParameterName, string PropertyName), LambdaExpression> Cache = new();

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

        return (Expression<Func<T, object>>)Cache.GetOrAdd((typeof(T), parameterName, propertyName), static key => CreatePropertyExpression<T>(key.ParameterName, key.PropertyName));
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static Expression<Func<T, object>> CreatePropertyExpression<T>(string parameterName, string propertyName)
    {
        var parameter = Parameter(typeof(T), parameterName);
        Expression body;

        if (typeof(T).GetPropertyImplement(propertyName) is { } propInfo)
        {
            body = Property(parameter, propInfo);
        }
        else
        {
            var methodInfo = typeof(T).GetMethod(propertyName, Instance | Public, null, EmptyTypes, null) ?? typeof(T).GetMethod(propertyName, Instance | Public | IgnoreCase, null, EmptyTypes, null);

            body = methodInfo is { IsGenericMethodDefinition: false, ReturnType: { IsByRef: false, IsByRefLike: false, IsPointer: false } returnType } && returnType != typeof(void)
                ? Call(parameter, methodInfo)
                : throw new ArgumentException($"Type {typeof(T).Name} does not contain a property named '{propertyName}'.", nameof(propertyName));
        }

        if (body.Type.IsValueType)
        {
            body = Convert(body, typeof(object));
        }

        return Lambda<Func<T, object>>(body, parameter);
    }
}
