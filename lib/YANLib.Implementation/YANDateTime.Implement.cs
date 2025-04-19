using System.Diagnostics;
using YANLib.Implementation.Object;
using YANLib.Implementation.Unmanaged;
using static System.DateTime;
using static System.Linq.Enumerable;
using static System.Math;
using static System.Threading.Tasks.Parallel;

namespace YANLib.Implementation;

internal static partial class YANDateTime
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static int GetWeekOfYearImplement<T>(this T? input) where T : unmanaged => input.GetWeekOfYearImplement<int>().ParseImplement<int>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<int>? GetWeekOfYearsImplement<T>(this IEnumerable<T?>? input) where T : unmanaged
        => input.IsNullEmptyImplement() ? default : input.GetCountImplement() < 1_000 ? input.Select(static x => x.GetWeekOfYearImplement()) : input.AsParallel().Select(x => x.GetWeekOfYearImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static int TotalMonthImplement<T>(T? input1, T? input2) where T : unmanaged => TotalMonthImplement<int>(input1, input2).ParseImplement<int>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static DateTime ChangeTimeZoneImplement(this object? input, object? tzSrc = null, object? tzDst = null)
    {
        var dt = input.ParseImplement<DateTime?>();

        if (dt.HasValue)
        {
            var diff = tzDst.ParseImplement<int>() - tzSrc.ParseImplement<int>();

            return diff switch
            {
                0 => dt.Value,
                < 0 when (dt.Value - MinValue).TotalHours < Abs(diff) => dt.Value,
                > 0 when (MaxValue - dt.Value).TotalHours < diff => dt.Value,
                _ => dt.Value.AddHours(diff)
            };
        }

        return default;
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static void ChangeTimeZoneImplement(this List<object?>? input, object? tzSrc = null, object? tzDst = null)
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
    internal static IEnumerable<DateTime>? ChangeTimeZonesImplement(this IEnumerable<object?>? input, object? tzSrc = null, object? tzDst = null)
        => input.IsNullEmptyImplement() ? default : input.GetCountImplement() < 1_000 ? input.Select(x => x.ChangeTimeZoneImplement(tzSrc, tzDst)) : input.AsParallel().Select(x => x.ChangeTimeZoneImplement(tzSrc, tzDst));
}
