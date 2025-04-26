using System.Diagnostics;

namespace YANLib.Implementation;

internal static partial class YANDateTime
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static DateTime? ChangeTimeZoneImplement(this object? input, object? tzSrc = null, object? tzDst = null)
    {
        var dt = input is DateTime d ? d : input.ParseImplement<DateTime?>();

        return dt.HasValue ? dt.Value.ChangeTimeZoneImplement(tzSrc, tzDst) : default(DateTime?);
    }
}
