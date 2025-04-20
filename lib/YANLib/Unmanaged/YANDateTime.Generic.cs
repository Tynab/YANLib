using System.Diagnostics;
using YANLib.Implementation.Unmanaged;
using static YANLib.Implementation.Unmanaged.YANDateTime;

namespace YANLib.Unmanaged;

public static partial class YANDateTime
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? GetWeekOfYear<T>(this object? input) => input.GetWeekOfYearImplement<T>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? GetWeekOfYears<T>(this IEnumerable<object?>? input) => input.GetWeekOfYearsImplement<T>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? GetWeekOfYears<T>(params object?[]? input) => input.GetWeekOfYearsImplement<T>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? TotalMonth<T>(object? input1, object? input2) => TotalMonthImplement<T>(input1, input2);
}
