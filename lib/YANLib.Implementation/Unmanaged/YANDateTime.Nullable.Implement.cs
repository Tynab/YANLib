using System.Diagnostics;
using YANLib.Implementation.Object;
using static System.Linq.Enumerable;
using static System.Threading.Tasks.Parallel;

namespace YANLib.Implementation.Unmanaged;

internal static partial class YANDateTime
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static DateTime? ChangeTimeZoneImplement(this object? input, object? tzSrc = null, object? tzDst = null)
    {
        var dt = input is DateTime d ? d : input.ParseImplement<DateTime?>();

        return dt.HasValue ? dt.Value.ChangeTimeZoneImplement(tzSrc, tzDst) : default(DateTime?);
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
    internal static IEnumerable<DateTime?>? ChangeTimeZonesImplement(this IEnumerable<object?>? input, object? tzSrc = null, object? tzDst = null)
        => input.IsNullEmptyImplement() ? default : input.GetCountImplement() < 1_000 ? input.Select(x => x.ChangeTimeZoneImplement(tzSrc, tzDst)) : input.AsParallel().Select(x => x.ChangeTimeZoneImplement(tzSrc, tzDst));
}
