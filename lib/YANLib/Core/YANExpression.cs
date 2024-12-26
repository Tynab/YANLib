using System.Linq.Expressions;
using static System.Linq.Expressions.Expression;

namespace YANLib.Core;

public static class YANExpression
{
    public static Expression<Func<T, object>> PropertyExpression<T>(string parameterName, string propertyName)
    {
        var parameter = Parameter(typeof(T), parameterName);

        return Lambda<Func<T, object>>(Convert(Property(parameter, propertyName), typeof(object)), parameter);
    }
}
