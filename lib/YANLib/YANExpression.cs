using System.Diagnostics;
using System.Linq.Expressions;
using static YANLib.Implementation.YANExpression;

namespace YANLib;

public static partial class YANExpression
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static Expression<Func<T, object>> PropertyExpression<T>(string parameterName, string propertyName) => PropertyExpressionImplement<T>(parameterName, propertyName);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void ClearExpressionCache() => ClearExpressionCacheImplement();
}
