using System.Diagnostics;
using static System.Linq.Enumerable;
using static System.Threading.Tasks.Parallel;

namespace YANLib.Implementation;

internal static partial class YANDateTime
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<int>? GetWeekOfYearsImplement<T>(this IEnumerable<T?>? input)
        => input.IsNullEmptyImplement() ? default : input.GetCountImplement() < 1_000 ? input.Select(static x => x.GetWeekOfYearImplement()) : input.AsParallel().Select(x => x.GetWeekOfYearImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? GetWeekOfYearsImplement<T>(this System.Collections.IEnumerable? input) => input is null ? default : input.Cast<object?>().GetWeekOfYearsImplement<T>();

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
        => input.IsNullEmptyImplement() ? input : input.GetCountImplement() < 1_000 ? input.Select(x => x.ChangeTimeZoneImplement(tzSrc, tzDst)) : input.AsParallel().Select(x => x.ChangeTimeZoneImplement(tzSrc, tzDst));
}
