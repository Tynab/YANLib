using System.Diagnostics;
using YANLib.Implementation;
using static YANLib.Implementation.YANDateTime;

namespace YANLib;

/// <summary>
/// Provides extension methods for working with nullable DateTime objects.
/// </summary>
/// <remarks>
/// This partial class contains methods specifically designed to handle nullable DateTime objects
/// and objects that can be converted to nullable DateTime.
/// </remarks>
public static partial class YANDateTime
{
    /// <summary>
    /// Changes the time zone of the specified object after converting it to a nullable DateTime.
    /// </summary>
    /// <param name="input">The object to convert to DateTime and change the time zone of. If <c>null</c> or cannot be converted to DateTime, returns <c>null</c>.</param>
    /// <param name="tzSrc">The source time zone offset in hours. If <c>null</c>, defaults to <c>0</c>.</param>
    /// <param name="tzDst">The destination time zone offset in hours. If <c>null</c>, defaults to <c>0</c>.</param>
    /// <returns>The DateTime adjusted to the destination time zone, or <c>null</c> if the input is <c>null</c> or cannot be converted to a DateTime.</returns>
    /// <remarks>
    /// This method first attempts to convert the input object to a DateTime. If successful, it adjusts the time by adding
    /// the difference between the source and destination time zones. If the adjustment would result in a DateTime outside
    /// the valid range, the original DateTime is returned.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static DateTime? ChangeTimeZone(this object? input, object? tzSrc = null, object? tzDst = null) => input.ChangeTimeZoneImplement(tzSrc, tzDst);
}
