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
    /// Converts the specified string representation of a date and time to its <see cref="DateTime"/> equivalent, using an optional format and default value.
    /// If the string is null, empty, or white space, returns the default value.
    /// If a format is provided, it attempts to parse the string using the specified format; otherwise, it uses standard date and time parsing.
    /// </summary>
    /// <param name="str">The string to be converted to <see cref="DateTime"/>. Can be null or white space.</param>
    /// <param name="fmt">The format of the input string. Can be null or white space.</param>
    /// <param name="dfltVal">The default <see cref="DateTime"/> value to return if parsing fails.</param>
    /// <returns>The <see cref="DateTime"/> equivalent of the input string, or the default value if parsing fails.</returns>
    public static DateTime ToDateTime(this string? str, string? fmt = null, DateTime dfltVal = default) => str.IsWhiteSpaceOrNull()
        ? dfltVal
        : fmt.IsWhiteSpaceOrNull()
        ? TryParse(str, out var dt)
            ? dt
            : dfltVal
        : TryParseExact(str, fmt, InvariantCulture, None, out dt)
        ? dt
        : dfltVal;

    /// <summary>
    /// Converts a collection of string representations of dates and times to their respective <see cref="DateTime"/> equivalents, using an optional format and default value.
    /// If the collection is null or empty, returns null.
    /// Each string in the collection is converted to a <see cref="DateTime"/> value; if conversion fails, the default value is used.
    /// </summary>
    /// <param name="strs">The collection of strings to be converted to <see cref="DateTime"/>. Can be null.</param>
    /// <param name="fmt">The format of the input strings. Can be null or white space.</param>
    /// <param name="dfltVal">The default <see cref="DateTime"/> value to return if parsing fails.</param>
    /// <returns>An enumerable collection of <see cref="DateTime"/> values representing the converted results, or the default value for strings that fail to convert.</returns>
    public static IEnumerable<DateTime>? ToDateTimes(this IEnumerable<string?>? strs, string? fmt = null, DateTime dfltVal = default) => strs.IsEmptyOrNull()
        ? default
        : strs.Select(x => x.ToDateTime(fmt, dfltVal));

    /// <summary>
    /// Converts a collection (ICollection) of string representations of dates and times to their respective <see cref="DateTime"/> equivalents, using an optional format and default value.
    /// If the collection is null or empty, returns null.
    /// Each string in the collection is converted to a <see cref="DateTime"/> value; if conversion fails, the default value is used.
    /// </summary>
    /// <param name="strs">The ICollection of strings to be converted to <see cref="DateTime"/>. Can be null.</param>
    /// <param name="fmt">The format of the input strings. Can be null or white space.</param>
    /// <param name="dfltVal">The default <see cref="DateTime"/> value to return if parsing fails.</param>
    /// <returns>An enumerable collection of <see cref="DateTime"/> values representing the converted results, or the default value for strings that fail to convert.</returns>
    public static IEnumerable<DateTime>? ToDateTimes(this ICollection<string?>? strs, string? fmt = null, DateTime dfltVal = default) => strs.IsEmptyOrNull()
        ? default
        : strs.Select(x => x.ToDateTime(fmt, dfltVal));

    /// <summary>
    /// Converts an array of string representations of dates and times to their respective <see cref="DateTime"/> equivalents, using an optional format and default value.
    /// If the array is null or empty, returns null.
    /// Each string in the array is converted to a <see cref="DateTime"/> value; if conversion fails, the default value is used.
    /// </summary>
    /// <param name="strs">The array of strings to be converted to <see cref="DateTime"/>. Can be null.</param>
    /// <param name="fmt">The format of the input strings. Can be null or white space.</param>
    /// <param name="dfltVal">The default <see cref="DateTime"/> value to return if parsing fails.</param>
    /// <returns>An enumerable collection of <see cref="DateTime"/> values representing the converted results, or the default value for strings that fail to convert.</returns>
    public static IEnumerable<DateTime>? ToDateTimes(this string?[]? strs, string? fmt = null, DateTime dfltVal = default) => strs.IsEmptyOrNull()
        ? default
        : strs.Select(x => x.ToDateTime(fmt, dfltVal));

    /// <summary>
    /// Generates a random <see cref="DateTime"/> object between the specified minimum and maximum values.
    /// If the minimum value is greater than the maximum value, returns the default <see cref="DateTime"/>.
    /// </summary>
    /// <param name="min">The minimum <see cref="DateTime"/> value that can be generated.</param>
    /// <param name="max">The maximum <see cref="DateTime"/> value that can be generated.</param>
    /// <returns>A randomly generated <see cref="DateTime"/> object between the specified minimum and maximum values, or the default <see cref="DateTime"/> if min is greater than max.</returns>
    public static DateTime GenerateRandomDateTime(DateTime min, DateTime max) => min > max ? default : min.AddTicks((long)GenerateRandomUlong((max - min).Ticks));

    /// <summary>
    /// Generates a collection of random <see cref="DateTime"/> objects of the specified size, each within the specified minimum and maximum range.
    /// If the specified size is invalid (non-positive), yields no results.
    /// </summary>
    /// <param name="size">The number of random <see cref="DateTime"/> objects to generate. The size is converted to an integer and should be a positive value.</param>
    /// <param name="min">The minimum <see cref="DateTime"/> value that can be generated for each object.</param>
    /// <param name="max">The maximum <see cref="DateTime"/> value that can be generated for each object.</param>
    /// <returns>An enumerable collection of randomly generated <see cref="DateTime"/> objects within the specified range.</returns>
    public static IEnumerable<DateTime> GenerateRandomDateTimes(object? size, DateTime min, DateTime max) => Range(0, (int)size.ToUint()).Select(i => GenerateRandomDateTime(min, max));

    /// <summary>
    /// Gets the week of the year for the specified <see cref="DateTime"/>.
    /// The calculation is based on the current culture's calendar and week rule settings.
    /// </summary>
    /// <param name="dt">The <see cref="DateTime"/> to calculate the week of the year for.</param>
    /// <returns>The week of the year for the specified <see cref="DateTime"/>.</returns>
    public static int GetWeekOfYear(this DateTime dt) => CurrentInfo.Calendar.GetWeekOfYear(dt, CurrentInfo.CalendarWeekRule, CurrentInfo.FirstDayOfWeek);

    /// <summary>
    /// Gets the week of the year for the specified nullable <see cref="DateTime"/>.
    /// If the <see cref="DateTime"/> is <see langword="null"/>, returns the default integer value.
    /// The calculation is based on the current culture's calendar and week rule settings.
    /// </summary>
    /// <param name="dt">The nullable <see cref="DateTime"/> to calculate the week of the year for. Can be <see langword="null"/>.</param>
    /// <returns>The week of the year for the specified <see cref="DateTime"/>, or the default integer value if <see cref="DateTime"/> is <see langword="null"/>.</returns>
    public static int GetWeekOfYear(this DateTime? dt) => dt.HasValue ? CurrentInfo.Calendar.GetWeekOfYear(dt.Value, CurrentInfo.CalendarWeekRule, CurrentInfo.FirstDayOfWeek) : default;

    /// <summary>
    /// Converts a collection of nullable <see cref="DateTime"/> values to their respective week numbers of the year.
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// </summary>
    /// <param name="dts">The collection of nullable <see cref="DateTime"/> values. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of integers representing the week numbers of the year, or <see langword="null"/> if the input collection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<int>? GetWeekOfYears(this IEnumerable<DateTime?>? dts) => dts.IsEmptyOrNull() ? default : dts.Select(x => x.GetWeekOfYear());

    /// <summary>
    /// Converts a collection of <see cref="DateTime"/> values to their respective week numbers of the year.
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// </summary>
    /// <param name="dts">The collection of <see cref="DateTime"/> values. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of integers representing the week numbers of the year, or <see langword="null"/> if the input collection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<int>? GetWeekOfYears(this IEnumerable<DateTime>? dts) => dts.IsEmptyOrNull() ? default : dts.Select(x => x.GetWeekOfYear());

    /// <summary>
    /// Converts a collection (ICollection) of nullable <see cref="DateTime"/> values to their respective week numbers of the year.
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// </summary>
    /// <param name="dts">The ICollection of nullable <see cref="DateTime"/> values. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of integers representing the week numbers of the year, or <see langword="null"/> if the input ICollection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<int>? GetWeekOfYears(this ICollection<DateTime?>? dts) => dts.IsEmptyOrNull() ? default : dts.Select(x => x.GetWeekOfYear());

    /// <summary>
    /// Converts a collection (ICollection) of <see cref="DateTime"/> values to their respective week numbers of the year.
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// </summary>
    /// <param name="dts">The ICollection of <see cref="DateTime"/> values. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of integers representing the week numbers of the year, or <see langword="null"/> if the input ICollection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<int>? GetWeekOfYears(this ICollection<DateTime>? dts) => dts.IsEmptyOrNull() ? default : dts.Select(x => x.GetWeekOfYear());

    /// <summary>
    /// Converts an array of nullable <see cref="DateTime"/> values to their respective week numbers of the year.
    /// If the array is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// </summary>
    /// <param name="dts">The array of nullable <see cref="DateTime"/> values. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of integers representing the week numbers of the year, or <see langword="null"/> if the input array is <see langword="null"/> or empty.</returns>
    public static IEnumerable<int>? GetWeekOfYears(this DateTime?[]? dts) => dts.IsEmptyOrNull() ? default : dts.Select(x => x.GetWeekOfYear());

    /// <summary>
    /// Converts an array of <see cref="DateTime"/> values to their respective week numbers of the year.
    /// If the array is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// </summary>
    /// <param name="dts">The array of <see cref="DateTime"/> values. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of integers representing the week numbers of the year, or <see langword="null"/> if the input array is <see langword="null"/> or empty.</returns>
    public static IEnumerable<int>? GetWeekOfYears(this DateTime[]? dts) => dts.IsEmptyOrNull() ? default : dts.Select(x => x.GetWeekOfYear());

    public static int TotalMonth(DateTime dt1, DateTime dt2) => Abs((dt1.Year - dt2.Year) * 12 + dt1.Month - dt2.Month);

    /// <summary>
    /// Changes the time zone of the given <see cref="DateTime"/>.
    /// Adjusts the <see cref="DateTime"/> by the difference in hours between the source and destination time zones.
    /// If the adjustment results in a date outside the valid range of <see cref="DateTime"/>, returns the default <see cref="DateTime"/>.
    /// </summary>
    /// <param name="dt">The <see cref="DateTime"/> to change the time zone for.</param>
    /// <param name="tzSrc">The source time zone. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone. Can be <see langword="null"/>.</param>
    /// <returns>The <see cref="DateTime"/> adjusted to the new time zone, or the default <see cref="DateTime"/> if the adjustment results in an invalid date.</returns>
    public static DateTime ChangeTimeZone(this DateTime dt, object? tzSrc = null, object? tzDst = null)
    {
        var diff = tzDst.ToInt() - tzSrc.ToInt();

        return diff switch
        {
            < 0 when (dt - MinValue).TotalHours < Abs(diff) => default,
            > 0 when (MaxValue - dt).TotalHours < diff => default,
            _ => dt.AddHours(diff)
        };
    }

    /// <summary>
    /// Changes the time zone of a nullable <see cref="DateTime"/>.
    /// If the <see cref="DateTime"/> has a value, adjusts it by the difference in hours between the source and destination time zones.
    /// If the adjustment results in a date outside the valid range of <see cref="DateTime"/>, or if the <see cref="DateTime"/> is <see langword="null"/>, returns the default <see cref="DateTime"/>.
    /// </summary>
    /// <param name="dt">The nullable <see cref="DateTime"/> to change the time zone for. Can be <see langword="null"/>.</param>
    /// <param name="tzSrc">The source time zone. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone. Can be <see langword="null"/>.</param>
    /// <returns>The <see cref="DateTime"/> adjusted to the new time zone, or the default <see cref="DateTime"/> if the adjustment results in an invalid date or if <see cref="DateTime"/> is <see langword="null"/>.</returns>
    public static DateTime ChangeTimeZone(this DateTime? dt, object? tzSrc = null, object? tzDst = null)
    {
        if (!dt.HasValue)
        {
            return default;
        }

        var diff = tzDst.ToInt() - tzSrc.ToInt();

        return diff switch
        {
            < 0 when (dt.Value - MinValue).TotalHours < Abs(diff) => default,
            > 0 when (MaxValue - dt.Value).TotalHours < diff => default,
            _ => dt.Value.AddHours(diff)
        };
    }

    /// <summary>
    /// Changes the time zones of a collection of nullable <see cref="DateTime"/> values.
    /// Adjusts each <see cref="DateTime"/> in the collection by the difference in hours between the source and destination time zones.
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// </summary>
    /// <param name="dts">The collection of nullable <see cref="DateTime"/> values to change the time zones for. Can be <see langword="null"/>.</param>
    /// <param name="tzSrc">The source time zone. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of nullable <see cref="DateTime"/> values adjusted to the new time zones, or <see langword="null"/> if the input collection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<DateTime>? ChangeTimeZones(this IEnumerable<DateTime?>? dts, object? tzSrc = null, object? tzDst = null) => dts.IsEmptyOrNull()
        ? default
        : dts.Select(x => x.ChangeTimeZone(tzSrc, tzDst));

    /// <summary>
    /// Changes the time zones of a collection of <see cref="DateTime"/> values.
    /// Adjusts each <see cref="DateTime"/> in the collection by the difference in hours between the source and destination time zones.
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// </summary>
    /// <param name="dts">The collection of <see cref="DateTime"/> values to change the time zones for. Can be <see langword="null"/>.</param>
    /// <param name="tzSrc">The source time zone. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of <see cref="DateTime"/> values adjusted to the new time zones, or <see langword="null"/> if the input collection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<DateTime>? ChangeTimeZones(this IEnumerable<DateTime>? dts, object? tzSrc = null, object? tzDst = null) => dts.IsEmptyOrNull()
        ? default
        : dts.Select(x => x.ChangeTimeZone(tzSrc, tzDst));

    /// <summary>
    /// Changes the time zones of a collection (ICollection) of nullable <see cref="DateTime"/> values.
    /// Adjusts each <see cref="DateTime"/> in the collection by the difference in hours between the source and destination time zones.
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// </summary>
    /// <param name="dts">The ICollection of nullable <see cref="DateTime"/> values to change the time zones for. Can be <see langword="null"/>.</param>
    /// <param name="tzSrc">The source time zone. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of nullable <see cref="DateTime"/> values adjusted to the new time zones, or <see langword="null"/> if the input ICollection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<DateTime>? ChangeTimeZones(this ICollection<DateTime?>? dts, object? tzSrc = null, object? tzDst = null) => dts.IsEmptyOrNull()
        ? default
        : dts.Select(x => x.ChangeTimeZone(tzSrc, tzDst));

    /// <summary>
    /// Changes the time zones of a collection (ICollection) of <see cref="DateTime"/> values.
    /// Adjusts each <see cref="DateTime"/> in the collection by the difference in hours between the source and destination time zones.
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// </summary>
    /// <param name="dts">The ICollection of <see cref="DateTime"/> values to change the time zones for. Can be <see langword="null"/>.</param>
    /// <param name="tzSrc">The source time zone. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of <see cref="DateTime"/> values adjusted to the new time zones, or <see langword="null"/> if the input ICollection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<DateTime>? ChangeTimeZones(this ICollection<DateTime>? dts, object? tzSrc = null, object? tzDst = null) => dts.IsEmptyOrNull()
        ? default
        : dts.Select(x => x.ChangeTimeZone(tzSrc, tzDst));

    /// <summary>
    /// Changes the time zones of an array of nullable <see cref="DateTime"/> values.
    /// Adjusts each <see cref="DateTime"/> in the array by the difference in hours between the source and destination time zones.
    /// If the array is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// </summary>
    /// <param name="dts">The array of nullable <see cref="DateTime"/> values to change the time zones for. Can be <see langword="null"/>.</param>
    /// <param name="tzSrc">The source time zone. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of nullable <see cref="DateTime"/> values adjusted to the new time zones, or <see langword="null"/> if the input array is <see langword="null"/> or empty.</returns>
    public static IEnumerable<DateTime>? ChangeTimeZones(this DateTime?[]? dts, object? tzSrc = null, object? tzDst = null) => dts.IsEmptyOrNull()
        ? default
        : dts.Select(x => x.ChangeTimeZone(tzSrc, tzDst));

    /// <summary>
    /// Changes the time zones of an array of <see cref="DateTime"/> values.
    /// Adjusts each <see cref="DateTime"/> in the array by the difference in hours between the source and destination time zones.
    /// If the array is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// </summary>
    /// <param name="dts">The array of <see cref="DateTime"/> values to change the time zones for. Can be <see langword="null"/>.</param>
    /// <param name="tzSrc">The source time zone. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of <see cref="DateTime"/> values adjusted to the new time zones, or <see langword="null"/> if the input array is <see langword="null"/> or empty.</returns>
    public static IEnumerable<DateTime>? ChangeTimeZones(this DateTime[]? dts, object? tzSrc = null, object? tzDst = null) => dts.IsEmptyOrNull()
        ? default
        : dts.Select(x => x.ChangeTimeZone(tzSrc, tzDst));
}
