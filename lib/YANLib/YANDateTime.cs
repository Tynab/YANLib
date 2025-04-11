using System.Diagnostics;
using YANLib.Implementation;
using static YANLib.Implementation.YANDateTime;

namespace YANLib;

public static partial class YANDateTime
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? GetWeekOfYear<T>(this object? input) where T : unmanaged => input.GetWeekOfYearImplement<T>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? GetWeekOfYears<T>(this IEnumerable<object?>? input) where T : unmanaged => input.GetWeekOfYearsImplement<T>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? GetWeekOfYears<T>(params object?[]? input) where T : unmanaged => input.GetWeekOfYearsImplement<T>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? TotalMonth<T>(object? input1, object? input2) where T : unmanaged => TotalMonthImplement<T>(input1, input2);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static DateTime ChangeTimeZone(this object? input, object? tzSrc = null, object? tzDst = null) => input.ChangeTimeZoneImplement(tzSrc, tzDst);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void ChangeTimeZone(this List<object?>? input, object? tzSrc = null, object? tzDst = null) => input.ChangeTimeZoneImplement(tzSrc, tzDst);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<DateTime>? ChangeTimeZones(this IEnumerable<object?>? input, object? tzSrc = null, object? tzDst = null) => input.ChangeTimeZonesImplement(tzSrc, tzDst);
}
