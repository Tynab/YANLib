using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

/// <summary>
/// Provides extension methods for working with collections of DateTime objects.
/// </summary>
/// <remarks>
/// This partial class contains methods for processing collections of dates, including
/// calculating week numbers and performing time zone conversions on multiple DateTime objects.
/// </remarks>
public static partial class YANDateTime
{
    /// <summary>
    /// Gets the week numbers of the year for a collection of objects that can be converted to DateTime.
    /// </summary>
    /// <typeparam name="T">The type of the input objects that can be converted to DateTime.</typeparam>
    /// <param name="input">The collection of objects to get the week numbers from. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection of week numbers corresponding to each input object, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<int>? GetWeekOfYears<T>(this IEnumerable<T?>? input) => input.GetWeekOfYearsImplement();

    /// <summary>
    /// Gets the week numbers of the year for an array of objects that can be converted to DateTime.
    /// </summary>
    /// <typeparam name="T">The type of the input objects that can be converted to DateTime.</typeparam>
    /// <param name="input">The array of objects to get the week numbers from. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection of week numbers corresponding to each input object, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to process an array of objects without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<int>? GetWeekOfYears<T>(params T?[]? input) => input.GetWeekOfYearsImplement();

    /// <summary>
    /// Gets the week numbers of the year for a non-generic collection of objects that can be converted to DateTime.
    /// </summary>
    /// <typeparam name="T">The type to convert the week numbers to.</typeparam>
    /// <param name="input">The non-generic collection of objects to get the week numbers from. If <c>null</c>, returns <c>null</c>.</param>
    /// <returns>A collection of week numbers of type <typeparamref name="T"/> corresponding to each input object, or <c>null</c> if the input is <c>null</c>.</returns>
    /// <remarks>
    /// This method first casts the non-generic collection to a generic collection of objects before processing.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? GetWeekOfYears<T>(this System.Collections.IEnumerable? input) => input.GetWeekOfYearsImplement<T>();

    /// <summary>
    /// Changes the time zone of all DateTime objects in the specified list.
    /// </summary>
    /// <param name="input">The list of DateTime objects to change the time zone of. If <c>null</c> or empty, no action is taken.</param>
    /// <param name="tzSrc">The source time zone offset in hours. If <c>null</c>, defaults to <c>0</c>.</param>
    /// <param name="tzDst">The destination time zone offset in hours. If <c>null</c>, defaults to <c>0</c>.</param>
    /// <remarks>
    /// This method modifies the list in-place, changing each DateTime to the destination time zone.
    /// For large lists (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void ChangeTimeZone(this List<DateTime>? input, object? tzSrc = null, object? tzDst = null) => input.ChangeTimeZoneImplement(tzSrc, tzDst);

    /// <summary>
    /// Changes the time zone of all DateTime objects in the specified list.
    /// </summary>
    /// <param name="input">The list of DateTime objects to change the time zone of. If <c>null</c> or empty, no action is taken.</param>
    /// <param name="tzSrc">The source time zone offset in hours. If <c>null</c>, defaults to <c>0</c>.</param>
    /// <param name="tzDst">The destination time zone offset in hours. If <c>null</c>, defaults to <c>0</c>.</param>
    /// <remarks>
    /// This method modifies the list in-place, changing each DateTime to the destination time zone.
    /// For large lists (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<DateTime>? ChangeTimeZones(this IEnumerable<DateTime>? input, object? tzSrc = null, object? tzDst = null) => input.ChangeTimeZonesImplement(tzSrc, tzDst);
}
