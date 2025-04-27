using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

public static partial class YANDateTime
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<int>? GetWeekOfYears<T>(this IEnumerable<T?>? input) => input.GetWeekOfYearsImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<int>? GetWeekOfYears<T>(params T?[]? input) => input.GetWeekOfYearsImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? GetWeekOfYears<T>(this System.Collections.IEnumerable? input) => input.GetWeekOfYearsImplement<T>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void ChangeTimeZone(this List<DateTime>? input, object? tzSrc = null, object? tzDst = null) => input.ChangeTimeZoneImplement(tzSrc, tzDst);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<DateTime>? ChangeTimeZones(this IEnumerable<DateTime>? input, object? tzSrc = null, object? tzDst = null) => input.ChangeTimeZonesImplement(tzSrc, tzDst);
}
