using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

/// <summary>
/// Provides generic extension methods for working with collections of objects that can be converted to nullable DateTime.
/// </summary>
/// <remarks>
/// This partial class contains generic methods for processing collections of objects that can be converted to DateTime,
/// allowing for more type-specific operations.
/// </remarks>
public static partial class YANDateTime
{
    /// <summary>
    /// Changes the time zone of all objects of type <typeparamref name="T"/> in the specified collection after converting them to DateTime.
    /// </summary>
    /// <typeparam name="T">The type of the objects in the collection.</typeparam>
    /// <param name="input">The collection of objects to convert to DateTime and change the time zone of. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <param name="tzSrc">The source time zone offset in hours. If <c>null</c>, defaults to <c>0</c>.</param>
    /// <param name="tzDst">The destination time zone offset in hours. If <c>null</c>, defaults to <c>0</c>.</param>
    /// <returns>A new collection containing the DateTime objects adjusted to the destination time zone, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This generic version allows for type-specific processing of collections.
    /// Objects that cannot be converted to DateTime will result in <c>null</c> elements in the returned collection.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<DateTime?>? ChangeTimeZones<T>(this IEnumerable<T?>? input, object? tzSrc = null, object? tzDst = null) => input.ChangeTimeZonesImplement(tzSrc, tzDst);
}
