using System.Diagnostics;
using static System.DateTime;

namespace YANLib.Implementation;

internal static partial class YANDateTime
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static int GetWeekOfYearImplement<T>(this T? input) => input.GetWeekOfYearImplement<int>().ParseImplement<int>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static int TotalMonthImplement<T>(T? input1, T? input2) => TotalMonthImplement<int>(input1, input2).ParseImplement<int>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static DateTime ChangeTimeZoneImplement(this DateTime input, object? tzSrc = null, object? tzDst = null)
    {
        var diff = tzDst.ParseImplement<int>() - tzSrc.ParseImplement<int>();

        return diff switch
        {
            0 => input,
            < 0 when (input - MinValue).TotalHours < diff.AbsImplement() => input,
            > 0 when (MaxValue - input).TotalHours < diff => input,
            _ => input.AddHours(diff)
        };
    }
}
