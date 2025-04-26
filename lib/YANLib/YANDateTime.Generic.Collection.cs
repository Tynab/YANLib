using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

public static partial class YANDateTime
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? GetWeekOfYears<T>(this IEnumerable<object?>? input) => input.GetWeekOfYearsImplement<T>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? GetWeekOfYears<T>(params object?[]? input) => input.GetWeekOfYearsImplement<T>();
}
