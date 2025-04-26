using System.Diagnostics;
using YANLib.Implementation;
using static YANLib.Implementation.YANDateTime;

namespace YANLib;

public static partial class YANDateTime
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static int GetWeekOfYear<T>(this T? input) => input.GetWeekOfYearImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static int TotalMonth<T>(T? input1, T? input2) => TotalMonthImplement(input1, input2);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static DateTime ChangeTimeZone(this DateTime input, object? tzSrc = null, object? tzDst = null) => input.ChangeTimeZoneImplement(tzSrc, tzDst);
}
