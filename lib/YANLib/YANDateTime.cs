using System.Diagnostics;
using YANLib.Implementation;
using static YANLib.Implementation.YANDateTime;

namespace YANLib;

/// <summary>
/// Provides extension methods for working with DateTime objects and related operations.
/// </summary>
/// <remarks>
/// This class contains methods for calculating week numbers, time differences between dates,
/// and performing time zone conversions on DateTime objects.
/// </remarks>
public static partial class YANDateTime
{
    /// <summary>
    /// Gets the week number of the year for the specified date.
    /// </summary>
    /// <typeparam name="T">The type of the input object that can be converted to a DateTime.</typeparam>
    /// <param name="input">The input object to get the week number from. If <c>null</c>, returns <c>0</c>.</param>
    /// <returns>The week number of the year for the specified date, or <c>0</c> if the input is <c>null</c> or cannot be converted to a DateTime.</returns>
    /// <remarks>
    /// The week number is calculated based on the current culture's calendar, week rule, and first day of the week.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static int GetWeekOfYear<T>(this T? input) => input.GetWeekOfYearImplement();

    /// <summary>
    /// Calculates the total number of months between two dates.
    /// </summary>
    /// <typeparam name="T">The type of the input objects that can be converted to DateTime.</typeparam>
    /// <param name="input1">The first date. If <c>null</c>, returns <c>0</c>.</param>
    /// <param name="input2">The second date. If <c>null</c>, returns <c>0</c>.</param>
    /// <returns>The absolute number of months between the two dates, or <c>0</c> if either input is <c>null</c> or cannot be converted to a DateTime.</returns>
    /// <remarks>
    /// The calculation is based on the difference in years and months, not on the exact number of days.
    /// The result is always a positive number, regardless of which date comes first.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static int TotalMonth<T>(T? input1, T? input2) => TotalMonthImplement(input1, input2);

    /// <summary>
    /// Changes the time zone of the specified DateTime.
    /// </summary>
    /// <param name="input">The DateTime to change the time zone of.</param>
    /// <param name="tzSrc">The source time zone offset in hours. If <c>null</c>, defaults to <c>0</c>.</param>
    /// <param name="tzDst">The destination time zone offset in hours. If <c>null</c>, defaults to <c>0</c>.</param>
    /// <returns>The DateTime adjusted to the destination time zone.</returns>
    /// <remarks>
    /// This method adjusts the time by adding the difference between the source and destination time zones.
    /// If the adjustment would result in a DateTime outside the valid range, the original DateTime is returned.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static DateTime ChangeTimeZone(this DateTime input, object? tzSrc = null, object? tzDst = null) => input.ChangeTimeZoneImplement(tzSrc, tzDst);
}
