using static System.DateTime;
using static System.Globalization.CultureInfo;
using static System.Globalization.DateTimeFormatInfo;
using static System.Globalization.DateTimeStyles;
using static System.Linq.Enumerable;
using static System.Math;
using static YANLib.YANNum;

namespace YANLib;

public static partial class YANDateTime
{
    /// <summary>
    /// Converts the specified string representation of a date and time to its <see cref="DateTime"/> equivalent using the specified format.
    /// If the string is <see langword="null"/>, white-space, or fails to convert, returns the specified default value or the default of <see cref="DateTime"/>.
    /// </summary>
    /// <param name="str">The string to be converted to <see cref="DateTime"/>. Can be <see langword="null"/>.</param>
    /// <param name="fmt">The format of the input string. Can be <see langword="null"/>.</param>
    /// <param name="dfltVal">The default <see cref="DateTime"/> value to return if the conversion fails. Can be <see langword="null"/>.</param>
    /// <returns>The <see cref="DateTime"/> equivalent of the input string, or the specified default value if the conversion fails.</returns>
    public static DateTime ToDateTime(this string? str, string? fmt = null, DateTime? dfltVal = null)
    {
        var dfltDt = dfltVal ?? default;

        return str.IsWhiteSpaceOrNull() ? dfltDt : fmt.IsWhiteSpaceOrNull() ? TryParse(str, out var dt) ? dt : dfltDt : TryParseExact(str, fmt, InvariantCulture, None, out dt) ? dt : dfltDt;
    }

    /// <summary>
    /// Converts a collection of string representations of dates and times to their <see cref="DateTime"/> equivalents using the specified format.
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>. Each string that fails to convert results in the specified default value or the default of <see cref="DateTime"/>.
    /// </summary>
    /// <param name="strs">The collection of strings to be converted to <see cref="DateTime"/>. Can be <see langword="null"/>.</param>
    /// <param name="fmt">The format of the input strings. Can be <see langword="null"/>.</param>
    /// <param name="dfltVal">The default <see cref="DateTime"/> value to return for each string that fails to convert. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of <see cref="DateTime"/> objects, each representing the converted equivalent of an input string, or the specified default value for any failed conversions.</returns>
    public static IEnumerable<DateTime>? ToDateTimes(this IEnumerable<string?>? strs, string? fmt = null, DateTime? dfltVal = null) => strs.IsEmptyOrNull() ? default : strs.Select(s => s.ToDateTime(fmt, dfltVal));

    /// <summary>
    /// Generates a random <see cref="DateTime"/> within the specified range.
    /// If the range is invalid or unspecified, it defaults from <see cref="DateTime.MinValue"/> to <see cref="DateTime.MaxValue"/>.
    /// </summary>
    /// <param name="min">The minimum <see cref="DateTime"/> bound. Can be <see langword="null"/>.</param>
    /// <param name="max">The maximum <see cref="DateTime"/> bound. Can be <see langword="null"/>.</param>
    /// <returns>A randomly generated <see cref="DateTime"/> within the specified range, or default if the range is invalid.</returns>
    public static DateTime GenerateRandomDateTime(DateTime? min = null, DateTime? max = null)
    {
        var minDt = min ?? MinValue;
        var maxDt = max ?? MaxValue;

        return minDt > maxDt ? default : minDt.AddTicks((long)GenerateRandomUlong((maxDt - minDt).Ticks));
    }

    /// <summary>
    /// Generates a collection of random <see cref="DateTime"/> values within the specified range and of the specified size.
    /// </summary>
    /// <param name="size">The number of random <see cref="DateTime"/> values to generate. If <see langword="null"/> or not convertible to a positive integer, defaults to a size of 0.</param>
    /// <param name="min">The minimum <see cref="DateTime"/> bound for each generated value. Can be <see langword="null"/>.</param>
    /// <param name="max">The maximum <see cref="DateTime"/> bound for each generated value. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of randomly generated <see cref="DateTime"/> values within the specified range.</returns>
    public static IEnumerable<DateTime> GenerateRandomDateTimes(object? size, DateTime? min = null, DateTime? max = null) => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomDateTime(min, max));

    /// <summary>
    /// Gets the week of the year for the specified <see cref="DateTime"/>.
    /// Returns default if the <see cref="DateTime"/> is <see langword="null"/>.
    /// </summary>
    /// <param name="dt">The <see cref="DateTime"/> to calculate the week of the year for. Can be <see langword="null"/>.</param>
    /// <returns>The week of the year, or default if the <see cref="DateTime"/> is <see langword="null"/>.</returns>
    public static int GetWeekOfYear(this DateTime? dt) => dt.HasValue ? CurrentInfo.Calendar.GetWeekOfYear(dt.Value, CurrentInfo.CalendarWeekRule, CurrentInfo.FirstDayOfWeek) : default;

    /// <summary>
    /// Converts a collection of <see cref="DateTime"/> values to their respective weeks of the year.
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// </summary>
    /// <param name="dts">The collection of <see cref="DateTime"/> values. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of weeks of the year, or <see langword="null"/> if the input collection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<int>? GetWeekOfYears(this IEnumerable<DateTime?> dts) => dts.IsEmptyOrNull() ? default : dts.Select(d => d.GetWeekOfYear());

    /// <summary>
    /// Calculates the total number of months between two <see cref="DateTime"/> values.
    /// If either date is <see langword="null"/>, it defaults to <see cref="DateTime.MaxValue"/> or <see cref="DateTime.MinValue"/>.
    /// </summary>
    /// <param name="dt1">The first <see cref="DateTime"/>. Can be <see langword="null"/>.</param>
    /// <param name="dt2">The second <see cref="DateTime"/>. Can be <see langword="null"/>.</param>
    /// <returns>The total number of months between the two dates.</returns>
    public static int TotalMonths(DateTime? dt1 = null, DateTime? dt2 = null)
    {
        var d1 = dt1 ?? MaxValue;
        var d2 = dt2 ?? MinValue;

        return Abs((d1.Year - d2.Year) * 12 + d1.Month - d2.Month);
    }

    /// <summary>
    /// Changes the time zone of the given <see cref="DateTime"/>.
    /// If the <see cref="DateTime"/> is <see langword="null"/>, returns default.
    /// Returns default if the time zone change results in a date outside the valid range of <see cref="DateTime"/>.
    /// </summary>
    /// <param name="dt">The <see cref="DateTime"/> to change the time zone for. Can be <see langword="null"/>.</param>
    /// <param name="tzSrc">The source time zone as an object. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone as an object. Can be <see langword="null"/>.</param>
    /// <returns>The <see cref="DateTime"/> adjusted to the new time zone, or default if the adjustment is outside the valid range.</returns>
    public static DateTime ChangeTimeZone(this DateTime? dt, object? tzSrc = null, object? tzDst = null)
    {
        if (dt.HasValue)
        {
            var diff = tzDst.ToInt() - tzSrc.ToInt();

            return diff switch
            {
                < 0 when (dt.Value - MinValue).TotalHours < Abs(diff) => default,
                > 0 when (MaxValue - dt.Value).TotalHours < diff => default,
                _ => dt.Value.AddHours(diff)
            };
        }
        else
        {
            return default;
        }
    }

    /// <summary>
    /// Changes the time zones of a collection of <see cref="DateTime"/> values.
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each <see cref="DateTime"/> value is adjusted to the new time zone, returning default for any adjustments outside the valid range.
    /// </summary>
    /// <param name="dts">The collection of <see cref="DateTime"/> values to change the time zones for. Can be <see langword="null"/>.</param>
    /// <param name="tzSrc">The source time zone as an object. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone as an object. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of <see cref="DateTime"/> values adjusted to the new time zone, or <see langword="null"/> if the input collection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<DateTime>? ChangeTimeZones(this IEnumerable<DateTime?> dts, object? tzSrc = null, object? tzDst = null) => dts.IsEmptyOrNull() ? default : dts.Select(d => d.ChangeTimeZone(tzSrc, tzDst));
}
