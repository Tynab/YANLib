using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

public static partial class YANDateTime
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<DateTime?>? ChangeTimeZones<T>(this IEnumerable<T?>? input, object? tzSrc = null, object? tzDst = null) => input.ChangeTimeZonesImplement(tzSrc, tzDst);
}
