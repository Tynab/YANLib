using System.Diagnostics;
using YANLib.Implementation;
using static YANLib.Implementation.YANDateTime;

namespace YANLib;

/// <summary>
/// Provides extension methods for working with date and time values.
/// This class includes functionality for calculating week numbers, determining time differences,
/// and performing time zone conversions on both individual DateTime objects and collections.
/// </summary>
public static partial class YANDateTime
{
    /// <summary>
    /// Gets the week of the year for the specified date and converts it to the specified unmanaged type.
    /// </summary>
    /// <typeparam name="T">The unmanaged type to convert the week number to.</typeparam>
    /// <param name="input">The object representing a date to get the week number from. This will be parsed to a DateTime.</param>
    /// <returns>The week of the year as the specified type <typeparamref name="T"/>, or the default value of <typeparamref name="T"/> if the input cannot be parsed to a valid date.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? GetWeekOfYear<T>(this object? input) where T : unmanaged => input.GetWeekOfYearImplement<T>();

    /// <summary>
    /// Gets the week of the year for each date in the specified collection and converts each result to the specified unmanaged type.
    /// </summary>
    /// <typeparam name="T">The unmanaged type to convert the week numbers to.</typeparam>
    /// <param name="input">The collection of objects representing dates to get week numbers from. Each will be parsed to a DateTime.</param>
    /// <returns>A collection containing the week of the year for each date as the specified type <typeparamref name="T"/>, or <see langword="null"/> if the input collection is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? GetWeekOfYears<T>(this IEnumerable<object?>? input) where T : unmanaged => input.GetWeekOfYearsImplement<T>();

    /// <summary>
    /// Gets the week of the year for each date in the specified array and converts each result to the specified unmanaged type.
    /// </summary>
    /// <typeparam name="T">The unmanaged type to convert the week numbers to.</typeparam>
    /// <param name="input">The array of objects representing dates to get week numbers from. Each will be parsed to a DateTime.</param>
    /// <returns>A collection containing the week of the year for each date as the specified type <typeparamref name="T"/>, or <see langword="null"/> if the input array is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? GetWeekOfYears<T>(params object?[]? input) where T : unmanaged => input.GetWeekOfYearsImplement<T>();

    /// <summary>
    /// Calculates the total number of months between two dates and converts the result to the specified unmanaged type.
    /// </summary>
    /// <typeparam name="T">The unmanaged type to convert the month count to.</typeparam>
    /// <param name="input1">The first date object to compare. This will be parsed to a DateTime.</param>
    /// <param name="input2">The second date object to compare. This will be parsed to a DateTime.</param>
    /// <returns>The absolute number of months between the two dates as the specified type <typeparamref name="T"/>, or the default value of <typeparamref name="T"/> if either input cannot be parsed to a valid date.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? TotalMonth<T>(object? input1, object? input2) where T : unmanaged => TotalMonthImplement<T>(input1, input2);

    /// <summary>
    /// Converts a date and time from one time zone to another.
    /// </summary>
    /// <param name="input">The object representing a date and time to convert. This will be parsed to a DateTime.</param>
    /// <param name="tzSrc">The source time zone offset in hours. If <see langword="null"/>, defaults to 0.</param>
    /// <param name="tzDst">The destination time zone offset in hours. If <see langword="null"/>, defaults to 0.</param>
    /// <returns>
    /// A new DateTime representing the input date and time adjusted to the destination time zone.
    /// If the input cannot be parsed to a valid date, returns the default DateTime value.
    /// If the conversion would result in a DateTime outside the valid range, the original DateTime is returned unchanged.
    /// </returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static DateTime ChangeTimeZone(this object? input, object? tzSrc = null, object? tzDst = null) => input.ChangeTimeZoneImplement(tzSrc, tzDst);

    /// <summary>
    /// Converts each date and time in the specified list from one time zone to another, modifying the list in place.
    /// </summary>
    /// <param name="input">The list of objects representing dates and times to convert. Each will be parsed to a DateTime.</param>
    /// <param name="tzSrc">The source time zone offset in hours. If <see langword="null"/>, defaults to 0.</param>
    /// <param name="tzDst">The destination time zone offset in hours. If <see langword="null"/>, defaults to 0.</param>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void ChangeTimeZone(this List<object?>? input, object? tzSrc = null, object? tzDst = null) => input.ChangeTimeZoneImplement(tzSrc, tzDst);

    /// <summary>
    /// Converts each date and time in the specified collection from one time zone to another.
    /// </summary>
    /// <param name="input">The collection of objects representing dates and times to convert. Each will be parsed to a DateTime.</param>
    /// <param name="tzSrc">The source time zone offset in hours. If <see langword="null"/>, defaults to 0.</param>
    /// <param name="tzDst">The destination time zone offset in hours. If <see langword="null"/>, defaults to 0.</param>
    /// <returns>
    /// A collection containing each date and time adjusted to the destination time zone, or <see langword="null"/> if the input collection is <see langword="null"/> or empty.
    /// For large collections (1000+ items), the conversion is performed in parallel for better performance.
    /// </returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<DateTime>? ChangeTimeZones(this IEnumerable<object?>? input, object? tzSrc = null, object? tzDst = null) => input.ChangeTimeZonesImplement(tzSrc, tzDst);
}
