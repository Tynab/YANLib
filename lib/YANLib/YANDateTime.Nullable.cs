using System.Diagnostics;
using YANLib.Implementation;
using static YANLib.Implementation.YANDateTime;

namespace YANLib;

public static partial class YANDateTime
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static DateTime? ChangeTimeZone(this object? input, object? tzSrc = null, object? tzDst = null) => input.ChangeTimeZoneImplement(tzSrc, tzDst);
}
