using System.Diagnostics;
using YANLib.Implementation.Unmanaged;
using static YANLib.Implementation.Unmanaged.YANDateTime;

namespace YANLib.Unmanaged;

public static partial class YANDateTime
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static int GetWeekOfYear<T>(this T? input) => input.GetWeekOfYearImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<int>? GetWeekOfYears<T>(this IEnumerable<T?>? input) => input.GetWeekOfYearsImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<int>? GetWeekOfYears<T>(params T?[]? input) => input.GetWeekOfYearsImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static int TotalMonth<T>(T? input1, T? input2) => TotalMonthImplement(input1, input2);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static DateTime ChangeTimeZone(this DateTime input, object? tzSrc = null, object? tzDst = null) => input.ChangeTimeZoneImplement(tzSrc, tzDst);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void ChangeTimeZone(this List<DateTime>? input, object? tzSrc = null, object? tzDst = null) => input.ChangeTimeZoneImplement(tzSrc, tzDst);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<DateTime>? ChangeTimeZones(this IEnumerable<DateTime>? input, object? tzSrc = null, object? tzDst = null) => input.ChangeTimeZonesImplement(tzSrc, tzDst);
}
