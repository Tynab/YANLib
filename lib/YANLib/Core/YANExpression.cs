using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
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
