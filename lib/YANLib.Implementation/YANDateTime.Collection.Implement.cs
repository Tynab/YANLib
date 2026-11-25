using static System.Linq.Enumerable;
using static System.Threading.Tasks.Parallel;

namespace YANLib.Implementation;

internal static partial class YANDateTime
{
    internal static IEnumerable<int>? GetWeekOfYearsImplement<T>(this IEnumerable<T?>? input)
        => input.IsNullEmptyImplement() ? default : input.Select(static x => x.GetWeekOfYearImplement());

    internal static IEnumerable<T?>? GetWeekOfYearsImplement<T>(this System.Collections.IEnumerable? input) => input is null ? default : input.Cast<object?>().GetWeekOfYearsImplement<T>();

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

    internal static IEnumerable<DateTime>? ChangeTimeZonesImplement(this IEnumerable<DateTime>? input, object? tzSrc = null, object? tzDst = null)
        => input.IsNullEmptyImplement() ? input : input.Select(x => x.ChangeTimeZoneImplement(tzSrc, tzDst));
}
