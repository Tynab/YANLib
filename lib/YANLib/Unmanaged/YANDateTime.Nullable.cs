using System.Diagnostics;
using YANLib.Implementation.Unmanaged;
using static YANLib.Implementation.Unmanaged.YANDateTime;

namespace YANLib.Unmanaged;

public static partial class YANDateTime
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static DateTime? ChangeTimeZone(this object? input, object? tzSrc = null, object? tzDst = null) => input.ChangeTimeZoneImplement(tzSrc, tzDst);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void ChangeTimeZone(this List<object?>? input, object? tzSrc = null, object? tzDst = null) => input.ChangeTimeZoneImplement(tzSrc, tzDst);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<DateTime?>? ChangeTimeZones(this IEnumerable<object?>? input, object? tzSrc = null, object? tzDst = null) => input.ChangeTimeZonesImplement(tzSrc, tzDst);
}
