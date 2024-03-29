﻿using YANLib.Core;
using static System.DateTime;
using static System.Globalization.CultureInfo;
using static System.Globalization.DateTimeFormatInfo;
using static System.Globalization.DateTimeStyles;
using static System.Linq.Enumerable;
using static System.Math;
using static YANLib.Core.YANNum;

namespace YANLib.Nullable;

public static partial class YANDateTime
{
    public static DateTime? ToDateTime(this string? str, DateTime? dfltVal = null) => str.IsWhiteSpaceOrNull()
        ? dfltVal
        : TryParse(str, out var dt)
        ? dt
        : dfltVal;

    public static IEnumerable<DateTime?>? ToDateTimes(this IEnumerable<string?>? strs, DateTime? dfltVal = null) => strs.IsEmptyOrNull()
        ? default
        : strs.Select(x => x.ToDateTime(dfltVal));

    public static IEnumerable<DateTime?>? ToDateTimes(this ICollection<string?>? strs, DateTime? dfltVal = null) => strs.IsEmptyOrNull()
        ? default
        : strs.Select(x => x.ToDateTime(dfltVal));

    public static IEnumerable<DateTime?>? ToDateTimes(this string?[]? strs, DateTime? dfltVal = null) => strs.IsEmptyOrNull()
        ? default
        : strs.Select(x => x.ToDateTime(dfltVal));

    public static DateTime? ToDateTime(this string? str, IEnumerable<string?>? fmts = null) => str.IsWhiteSpaceOrNull()
        ? default
        : fmts.IsEmptyOrNull()
        ? TryParse(str, out var dt)
            ? dt
            : default
        : TryParseExact(str, fmts.ToArray(), InvariantCulture, None, out dt)
        ? dt
        : default;

    public static IEnumerable<DateTime?>? ToDateTimes(this IEnumerable<string?>? strs, IEnumerable<string?>? fmts = null) => strs.IsEmptyOrNull()
        ? default
        : strs.Select(x => x.ToDateTime(fmts));

    public static IEnumerable<DateTime?>? ToDateTimes(this ICollection<string?>? strs, IEnumerable<string?>? fmts = null) => strs.IsEmptyOrNull()
        ? default
        : strs.Select(x => x.ToDateTime(fmts));

    public static IEnumerable<DateTime?>? ToDateTimes(this string?[]? strs, IEnumerable<string?>? fmts = null) => strs.IsEmptyOrNull()
        ? default
        : strs.Select(x => x.ToDateTime(fmts));

    public static DateTime? ToDateTime(this string? str, ICollection<string?>? fmts = null) => str.IsWhiteSpaceOrNull()
        ? default
        : fmts.IsEmptyOrNull()
        ? TryParse(str, out var dt)
            ? dt
            : default
        : TryParseExact(str, fmts.ToArray(), InvariantCulture, None, out dt)
        ? dt
        : default;

    public static IEnumerable<DateTime?>? ToDateTimes(this IEnumerable<string?>? strs, ICollection<string?>? fmts = null) => strs.IsEmptyOrNull()
        ? default
        : strs.Select(x => x.ToDateTime(fmts));

    public static IEnumerable<DateTime?>? ToDateTimes(this ICollection<string?>? strs, ICollection<string?>? fmts = null) => strs.IsEmptyOrNull()
        ? default
        : strs.Select(x => x.ToDateTime(fmts));

    public static IEnumerable<DateTime?>? ToDateTimes(this string?[]? strs, ICollection<string?>? fmts = null) => strs.IsEmptyOrNull()
        ? default
        : strs.Select(x => x.ToDateTime(fmts));

    public static DateTime? ToDateTime(this string? str, params string?[]? fmts) => str.IsWhiteSpaceOrNull()
        ? default
        : fmts.IsEmptyOrNull()
        ? TryParse(str, out var dt)
            ? dt
            : default
        : TryParseExact(str, fmts, InvariantCulture, None, out dt)
        ? dt
        : default;

    public static IEnumerable<DateTime?>? ToDateTimes(this IEnumerable<string?>? strs, params string?[]? fmts) => strs.IsEmptyOrNull()
        ? default
        : strs.Select(x => x.ToDateTime(fmts));

    public static IEnumerable<DateTime?>? ToDateTimes(this ICollection<string?>? strs, params string?[]? fmts) => strs.IsEmptyOrNull()
        ? default
        : strs.Select(x => x.ToDateTime(fmts));

    public static IEnumerable<DateTime?>? ToDateTimes(this string?[]? strs, params string?[]? fmts) => strs.IsEmptyOrNull()
        ? default
        : strs.Select(x => x.ToDateTime(fmts));

    public static DateTime? ToDateTime(this string? str, DateTime? dfltVal = null, IEnumerable<string?>? fmts = null) => str.IsWhiteSpaceOrNull()
        ? dfltVal
        : fmts.IsEmptyOrNull()
        ? TryParse(str, out var dt)
            ? dt
            : dfltVal
        : TryParseExact(str, fmts.ToArray(), InvariantCulture, None, out dt)
        ? dt
        : dfltVal;

    public static IEnumerable<DateTime?>? ToDateTimes(this IEnumerable<string?>? strs, DateTime? dfltVal = null, IEnumerable<string?>? fmts = null) => strs.IsEmptyOrNull()
        ? default
        : strs.Select(x => x.ToDateTime(dfltVal, fmts));

    public static IEnumerable<DateTime?>? ToDateTimes(this ICollection<string?>? strs, DateTime? dfltVal = null, IEnumerable<string?>? fmts = null) => strs.IsEmptyOrNull()
        ? default
        : strs.Select(x => x.ToDateTime(dfltVal, fmts));

    public static IEnumerable<DateTime?>? ToDateTimes(this string?[]? strs, DateTime? dfltVal = null, IEnumerable<string?>? fmts = null) => strs.IsEmptyOrNull()
        ? default
        : strs.Select(x => x.ToDateTime(dfltVal, fmts));

    public static DateTime? ToDateTime(this string? str, DateTime? dfltVal = null, ICollection<string?>? fmts = null) => str.IsWhiteSpaceOrNull()
        ? dfltVal
        : fmts.IsEmptyOrNull()
        ? TryParse(str, out var dt)
            ? dt
            : dfltVal
        : TryParseExact(str, fmts.ToArray(), InvariantCulture, None, out dt)
        ? dt
        : dfltVal;

    public static IEnumerable<DateTime?>? ToDateTimes(this IEnumerable<string?>? strs, DateTime? dfltVal = null, ICollection<string?>? fmts = null) => strs.IsEmptyOrNull()
        ? default
        : strs.Select(x => x.ToDateTime(dfltVal, fmts));

    public static IEnumerable<DateTime?>? ToDateTimes(this ICollection<string?>? strs, DateTime? dfltVal = null, ICollection<string?>? fmts = null) => strs.IsEmptyOrNull()
        ? default
        : strs.Select(x => x.ToDateTime(dfltVal, fmts));

    public static IEnumerable<DateTime?>? ToDateTimes(this string?[]? strs, DateTime? dfltVal = null, ICollection<string?>? fmts = null) => strs.IsEmptyOrNull()
        ? default
        : strs.Select(x => x.ToDateTime(dfltVal, fmts));

    public static DateTime? ToDateTime(this string? str, DateTime? dfltVal = null, params string?[]? fmts) => str.IsWhiteSpaceOrNull()
        ? dfltVal
        : fmts.IsEmptyOrNull()
        ? TryParse(str, out var dt)
            ? dt
            : dfltVal
        : TryParseExact(str, fmts, InvariantCulture, None, out dt)
        ? dt
        : dfltVal;

    public static IEnumerable<DateTime?>? ToDateTimes(this IEnumerable<string?>? strs, DateTime? dfltVal = null, params string?[]? fmts) => strs.IsEmptyOrNull()
        ? default
        : strs.Select(x => x.ToDateTime(dfltVal, fmts));

    public static IEnumerable<DateTime?>? ToDateTimes(this ICollection<string?>? strs, DateTime? dfltVal = null, params string?[]? fmts) => strs.IsEmptyOrNull()
        ? default
        : strs.Select(x => x.ToDateTime(dfltVal, fmts));

    public static IEnumerable<DateTime?>? ToDateTimes(this string?[]? strs, DateTime? dfltVal = null, params string?[]? fmts) => strs.IsEmptyOrNull()
        ? default
        : strs.Select(x => x.ToDateTime(dfltVal, fmts));

    /// <summary>
    /// Generates a random <see cref="DateTime"/> within the specified range.
    /// Returns <see langword="null"/> if the minimum date is greater than the maximum date.
    /// </summary>
    /// <param name="min">The minimum <see cref="DateTime"/> value. Can be <see langword="null"/>.</param>
    /// <param name="max">The maximum <see cref="DateTime"/> value. Can be <see langword="null"/>.</param>
    /// <returns>A randomly generated <see cref="DateTime"/>, or <see langword="null"/> if the range is invalid.</returns>
    public static DateTime? GenerateRandomDateTime(DateTime? min = null, DateTime? max = null)
    {
        var minDt = min ?? MinValue;
        var maxDt = max ?? MaxValue;

        return minDt > maxDt ? default : minDt.AddTicks((long)GenerateRandomUlong((maxDt - minDt).Ticks));
    }

    /// <summary>
    /// Generates a collection of random <see cref="DateTime"/> values within the specified range and of the specified size.
    /// </summary>
    /// <param name="size">The number of random <see cref="DateTime"/> values to generate. Can be <see langword="null"/>.</param>
    /// <param name="min">The minimum <see cref="DateTime"/> value for each generated value. Can be <see langword="null"/>.</param>
    /// <param name="max">The maximum <see cref="DateTime"/> value for each generated value. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of randomly generated <see cref="DateTime"/> values.</returns>
    public static IEnumerable<DateTime?> GenerateRandomDateTimes(object? size, DateTime? min = null, DateTime? max = null) => Range(0, (int)Core.YANNum.ToUint(size)).Select(i => GenerateRandomDateTime(min, max));

    /// <summary>
    /// Gets the week of the year for a specified <see cref="DateTime"/>.
    /// Returns <see langword="null"/> if the <see cref="DateTime"/> is <see langword="null"/>.
    /// </summary>
    /// <param name="dt">The <see cref="DateTime"/> to calculate the week of the year for. Can be <see langword="null"/>.</param>
    /// <returns>The week of the year, or <see langword="null"/> if the <see cref="DateTime"/> is <see langword="null"/>.</returns>
    public static int? GetWeekOfYear(this DateTime? dt) => dt.HasValue ? CurrentInfo.Calendar.GetWeekOfYear(dt.Value, CurrentInfo.CalendarWeekRule, CurrentInfo.FirstDayOfWeek) : default;

    /// <summary>
    /// Converts a collection of nullable <see cref="DateTime"/> values to their respective week numbers of the year.
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each <see cref="DateTime"/> value is converted to its corresponding week number based on the current culture's calendar and rules.
    /// </summary>
    /// <param name="dts">The collection of nullable <see cref="DateTime"/> values. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of integers representing the week numbers of the year for each <see cref="DateTime"/> value, or <see langword="null"/> if the input collection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<int?>? GetWeekOfYears(this IEnumerable<DateTime?>? dts) => dts.IsEmptyOrNull() ? default : dts.Select(x => x.GetWeekOfYear());

    /// <summary>
    /// Converts a collection (ICollection) of nullable <see cref="DateTime"/> values to their respective week numbers of the year.
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each <see cref="DateTime"/> value is converted to its corresponding week number based on the current culture's calendar and rules.
    /// </summary>
    /// <param name="dts">The ICollection of nullable <see cref="DateTime"/> values. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of integers representing the week numbers of the year for each <see cref="DateTime"/> value, or <see langword="null"/> if the input ICollection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<int?>? GetWeekOfYears(this ICollection<DateTime?>? dts) => dts.IsEmptyOrNull() ? default : dts.Select(x => x.GetWeekOfYear());

    /// <summary>
    /// Converts an array of nullable <see cref="DateTime"/> values to their respective week numbers of the year.
    /// If the array is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each <see cref="DateTime"/> value is converted to its corresponding week number based on the current culture's calendar and rules.
    /// </summary>
    /// <param name="dts">The array of nullable <see cref="DateTime"/> values. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of integers representing the week numbers of the year for each <see cref="DateTime"/> value, or <see langword="null"/> if the input array is <see langword="null"/> or empty.</returns>
    public static IEnumerable<int?>? GetWeekOfYears(this DateTime?[]? dts) => dts.IsEmptyOrNull() ? default : dts.Select(x => x.GetWeekOfYear());

    /// <summary>
    /// Changes the time zone of a given <see cref="DateTime"/>.
    /// Returns <see langword="null"/> if the <see cref="DateTime"/> is <see langword="null"/> or if the adjusted time falls outside the valid range of <see cref="DateTime"/>.
    /// </summary>
    /// <param name="dt">The <see cref="DateTime"/> to change the time zone for. Can be <see langword="null"/>.</param>
    /// <param name="tzSrc">The source time zone. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone. Can be <see langword="null"/>.</param>
    /// <returns>The <see cref="DateTime"/> adjusted to the new time zone, or <see langword="null"/> if the adjustment is invalid.</returns>
    public static DateTime? ChangeTimeZone(this DateTime? dt, object? tzSrc = null, object? tzDst = null)
    {
        if (!dt.HasValue)
        {
            return default;
        }

        var diff = Core.YANNum.ToInt(tzDst) - Core.YANNum.ToInt(tzSrc);

        return diff switch
        {
            < 0 when (dt.Value - MinValue).TotalHours < Abs(diff) => default,
            > 0 when (MaxValue - dt.Value).TotalHours < diff => default,
            _ => dt.Value.AddHours(diff)
        };
    }

    /// <summary>
    /// Adjusts the time zone of each nullable <see cref="DateTime"/> in the specified IEnumerable collection.
    /// Converts the date and time from the source time zone to the destination time zone.
    /// If the collection is <see langword="null"/> or empty, or if any conversion results in an invalid date, returns <see langword="null"/> for that date.
    /// </summary>
    /// <param name="dts">The collection of nullable <see cref="DateTime"/> values to be adjusted. Can be <see langword="null"/>.</param>
    /// <param name="tzSrc">The source time zone. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of nullable <see cref="DateTime"/> values adjusted to the new time zone, or <see langword="null"/> for dates that result in an invalid conversion.</returns>
    public static IEnumerable<DateTime?>? ChangeTimeZones(this IEnumerable<DateTime?>? dts, object? tzSrc = null, object? tzDst = null) => dts.IsEmptyOrNull()
        ? default
        : dts.Select(x => x.ChangeTimeZone(tzSrc, tzDst));

    /// <summary>
    /// Adjusts the time zone of each nullable <see cref="DateTime"/> in the specified ICollection collection.
    /// Converts the date and time from the source time zone to the destination time zone.
    /// If the collection is <see langword="null"/> or empty, or if any conversion results in an invalid date, returns <see langword="null"/> for that date.
    /// </summary>
    /// <param name="dts">The ICollection of nullable <see cref="DateTime"/> values to be adjusted. Can be <see langword="null"/>.</param>
    /// <param name="tzSrc">The source time zone. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of nullable <see cref="DateTime"/> values adjusted to the new time zone, or <see langword="null"/> for dates that result in an invalid conversion.</returns>
    public static IEnumerable<DateTime?>? ChangeTimeZones(this ICollection<DateTime?>? dts, object? tzSrc = null, object? tzDst = null) => dts.IsEmptyOrNull()
        ? default
        : dts.Select(x => x.ChangeTimeZone(tzSrc, tzDst));

    /// <summary>
    /// Adjusts the time zone of each nullable <see cref="DateTime"/> in the specified array.
    /// Converts the date and time from the source time zone to the destination time zone.
    /// If the array is <see langword="null"/> or empty, or if any conversion results in an invalid date, returns <see langword="null"/> for that date.
    /// </summary>
    /// <param name="dts">The array of nullable <see cref="DateTime"/> values to be adjusted. Can be <see langword="null"/>.</param>
    /// <param name="tzSrc">The source time zone. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of nullable <see cref="DateTime"/> values adjusted to the new time zone, or <see langword="null"/> for dates that result in an invalid conversion.</returns>
    public static IEnumerable<DateTime?>? ChangeTimeZones(this DateTime?[]? dts, object? tzSrc = null, object? tzDst = null) => dts.IsEmptyOrNull()
        ? default
        : dts.Select(x => x.ChangeTimeZone(tzSrc, tzDst));
}
