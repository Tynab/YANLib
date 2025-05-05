using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

/// <summary>
/// Provides extension methods for working with collections of objects that can be converted to nullable DateTime.
/// </summary>
/// <remarks>
/// This partial class contains methods for processing collections of objects that can be converted to DateTime,
/// including changing time zones for lists and enumerable collections.
/// </remarks>
public static partial class YANDateTime
{
    /// <summary>
    /// Changes the time zone of all objects in the specified list after converting them to DateTime.
    /// </summary>
    /// <param name="input">The list of objects to convert to DateTime and change the time zone of. If <c>null</c> or empty, no action is taken.</param>
    /// <param name="tzSrc">The source time zone offset in hours. If <c>null</c>, defaults to <c>0</c>.</param>
    /// <param name="tzDst">The destination time zone offset in hours. If <c>null</c>, defaults to <c>0</c>.</param>
    /// <remarks>
    /// This method modifies the list in-place, changing each object to a DateTime adjusted to the destination time zone.
    /// Objects that cannot be converted to DateTime will be set to <c>null</c>.
    /// For large lists (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void ChangeTimeZone(this List<object?>? input, object? tzSrc = null, object? tzDst = null) => input.ChangeTimeZoneImplement(tzSrc, tzDst);

    /// <summary>
    /// Changes the time zone of all objects in the specified collection after converting them to DateTime.
    /// </summary>
    /// <param name="input">The collection of objects to convert to DateTime and change the time zone of. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <param name="tzSrc">The source time zone offset in hours. If <c>null</c>, defaults to <c>0</c>.</param>
    /// <param name="tzDst">The destination time zone offset in hours. If <c>null</c>, defaults to <c>0</c>.</param>
    /// <returns>A new collection containing the DateTime objects adjusted to the destination time zone, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// Unlike <see cref="ChangeTimeZone(List{object}, object, object)"/>, this method does not modify the original collection but returns a new one.
    /// Objects that cannot be converted to DateTime will result in <c>null</c> elements in the returned collection.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<DateTime?>? ChangeTimeZones(this IEnumerable<object?>? input, object? tzSrc = null, object? tzDst = null) => input.ChangeTimeZonesImplement(tzSrc, tzDst);

    /// <summary>
    /// Changes the time zone of all objects in the specified non-generic collection after converting them to DateTime.
    /// </summary>
    /// <param name="input">The non-generic collection of objects to convert to DateTime and change the time zone of. If <c>null</c>, returns <c>null</c>.</param>
    /// <param name="tzSrc">The source time zone offset in hours. If <c>null</c>, defaults to <c>0</c>.</param>
    /// <param name="tzDst">The destination time zone offset in hours. If <c>null</c>, defaults to <c>0</c>.</param>
    /// <returns>A new collection containing the DateTime objects adjusted to the destination time zone, or <c>null</c> if the input is <c>null</c>.</returns>
    /// <remarks>
    /// This method first casts the non-generic collection to a generic collection of objects before processing.
    /// Objects that cannot be converted to DateTime will result in <c>null</c> elements in the returned collection.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<DateTime?>? ChangeTimeZones(this System.Collections.IEnumerable? input, object? tzSrc = null, object? tzDst = null) => input.ChangeTimeZonesImplement(tzSrc, tzDst);
}
