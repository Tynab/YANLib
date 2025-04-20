using System.Diagnostics;
using YANLib.Implementation.Object;
using static System.DateTime;
using static System.Linq.Enumerable;
using static System.Threading.Tasks.Parallel;

namespace YANLib.Implementation.Unmanaged;

internal static partial class YANDateTime
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static int GetWeekOfYearImplement<T>(this T? input) => input.GetWeekOfYearImplement<int>().ParseImplement<int>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<int>? GetWeekOfYearsImplement<T>(this IEnumerable<T?>? input)
        => input.IsNullEmptyImplement() ? default : input.GetCountImplement() < 1_000 ? input.Select(static x => x.GetWeekOfYearImplement()) : input.AsParallel().Select(x => x.GetWeekOfYearImplement());

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

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static void ChangeTimeZoneImplement(this List<DateTime>? input, object? tzSrc = null, object? tzDst = null)
    {
        if (input.IsNullEmptyImplement())
        {
            return;
        }

        if (input.Count < 1_000)
        {
            for (var i = 0; i < input.Count; i++)
            {
                input[i] = input[i].ChangeTimeZoneImplement(tzSrc, tzDst);
            }
        }
        else
        {
            _ = For(0, input.Count, i => input[i] = input[i].ChangeTimeZoneImplement(tzSrc, tzDst));
        }
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<DateTime>? ChangeTimeZonesImplement(this IEnumerable<DateTime>? input, object? tzSrc = null, object? tzDst = null)
        => input.IsNullEmptyImplement() ? default : input.GetCountImplement() < 1_000 ? input.Select(x => x.ChangeTimeZoneImplement(tzSrc, tzDst)) : input.AsParallel().Select(x => x.ChangeTimeZoneImplement(tzSrc, tzDst));
}
