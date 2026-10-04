using System.Diagnostics;
using static System.Linq.Enumerable;

namespace YANLib.Implementation;

internal static partial class YANDateTime
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<DateTime?>? ChangeTimeZonesImplement<T>(this IEnumerable<T?>? input, object? tzSrc = null, object? tzDst = null)
        => input.IsNullEmptyImplement() ? default : input.Select(x => x.ChangeTimeZoneImplement(tzSrc, tzDst));
}
