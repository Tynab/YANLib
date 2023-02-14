using static System.DateTime;
using static System.Globalization.CultureInfo;
using static System.Globalization.DateTimeStyles;

namespace YANLib.Nullable;

public static partial class YANDateTime
{
    /// <summary>
    /// Parses the specified <paramref name="str"/> as a <see cref="DateTime"/> using the specified format string <paramref name="fmt"/> and returns the result. If the parsing fails, returns the specified default value <paramref name="dfltVal"/> instead.
    /// </summary>
    /// <param name="str">The string to parse as a <see cref="DateTime"/>.</param>
    /// <param name="fmt">The format string to use for parsing the <see cref="DateTime"/>.</param>
    /// <param name="dfltVal">The default value to return if parsing fails.</param>
    /// <returns>The parsed <see cref="DateTime"/>, or the default value if parsing fails.</returns>
    public static DateTime? ParseDateTime(this string str, string fmt, DateTime? dfltVal) => TryParseExact(str, fmt, InvariantCulture, None, out var dt) ? dt : dfltVal;

    /// <summary>
    /// Generates a random <see cref="DateTime"/> between the specified minimum value and maximum value. If the minimum value is null, returns null.
    /// </summary>
    /// <param name="min">The minimum value of the range to generate a random <see cref="DateTime"/> from.</param>
    /// <param name="max">The maximum value of the range to generate a random <see cref="DateTime"/> from.</param>
    /// <returns>A random <see cref="DateTime"/> between the minimum and maximum values, or null if the minimum value is null.</returns>
    public static DateTime? RandomDateTime(DateTime? min, DateTime max) => min.HasValue ? RandomDateTime(min.Value, max) : null;

    /// <summary>
    /// Generates a random <see cref="DateTime"/> between the specified minimum value and maximum value. If the maximum value is null, returns null.
    /// </summary>
    /// <param name="min">The minimum value of the range to generate a random <see cref="DateTime"/> from.</param>
    /// <param name="max">The maximum value of the range to generate a random <see cref="DateTime"/> from.</param>
    /// <returns>A random <see cref="DateTime"/> between the minimum and maximum values, or null if the maximum value is null.</returns>
    public static DateTime? RandomDateTime(DateTime min, DateTime? max) => max.HasValue ? RandomDateTime(min, max.Value) : null;

    /// <summary>
    /// Generates a random <see cref="DateTime"/> between the specified minimum value and maximum value. If both the minimum value and maximum value are null, returns null. If only the maximum value is null, generates a random <see cref="DateTime"/> between the minimum value and the current date and time. If only the minimum value is null, generates a random <see cref="DateTime"/> between the current date and time and the maximum value.
    /// </summary>
    /// <param name="min">The minimum value of the range to generate a random <see cref="DateTime"/> from.</param>
    /// <param name="max">The maximum value of the range to generate a random <see cref="DateTime"/> from.</param>
    /// <returns>A random <see cref="DateTime"/> between the minimum and maximum values, or null if both values are null.</returns>
    public static DateTime? RandomDateTime(DateTime? min, DateTime? max) => min.HasValue ? RandomDateTime(min.Value, max) : RandomDateTime(max);

    /// <summary>
    /// Generates a random <see cref="DateTime"/> between the current date and time and the specified maximum value. If the maximum value is null, returns null.
    /// </summary>
    /// <param name="max">The maximum value of the range to generate a random <see cref="DateTime"/> from.</param>
    /// <returns>A random <see cref="DateTime"/> between the current date and time and the maximum value, or null if the maximum value is null.</returns>
    public static DateTime? RandomDateTime(DateTime? max)
    {
        var maxVal = max ?? MinValue;
        return RandomDateTime(maxVal > Today ? Today : maxVal, maxVal);
    }

    /// <summary>
    /// Gets the week of the year for the specified nullable <see cref="DateTime"/> value. If the nullable value is null, returns null.
    /// </summary>
    /// <param name="dt">The nullable <see cref="DateTime"/> value to get the week of the year for.</param>
    /// <returns>The week of the year for the specified nullable <see cref="DateTime"/> value, or null if the nullable value is null.</returns>
    public static int? GetWeekOfYear(this DateTime? dt) => dt.HasValue ? dt.Value.GetWeekOfYear() : null;

    /// <summary>
    /// Gets the total number of months between two <see cref="DateTime"/> values. If the first <see cref="DateTime"/> value is null, returns null.
    /// </summary>
    /// <param name="dt1">The first <see cref="DateTime"/> value to get the total number of months between.</param>
    /// <param name="dt2">The second <see cref="DateTime"/> value to get the total number of months between.</param>
    /// <returns>The total number of months between the two <see cref="DateTime"/> values, or null if the first <see cref="DateTime"/> value is null.</returns>
    public static int? TotalMonths(DateTime? dt1, DateTime dt2) => dt1.HasValue ? YANLib.YANDateTime.TotalMonths(dt1.Value, dt2) : null;

    /// <summary>
    /// Gets the total number of months between two <see cref="DateTime"/> values. If the second <see cref="DateTime"/> value is null, returns null.
    /// </summary>
    /// <param name="dt1">The first <see cref="DateTime"/> value to get the total number of months between.</param>
    /// <param name="dt2">The second <see cref="DateTime"/> value to get the total number of months between.</param>
    /// <returns>The total number of months between the two <see cref="DateTime"/> values, or null if the second <see cref="DateTime"/> value is null.</returns>
    public static int? TotalMonths(DateTime dt1, DateTime? dt2) => dt2.HasValue ? YANLib.YANDateTime.TotalMonths(dt1, dt2.Value) : null;

    /// <summary>
    /// Gets the total number of months between two <see cref="DateTime"/> values. If the first <see cref="DateTime"/> value is null, returns null.
    /// </summary>
    /// <param name="dt1">The first <see cref="DateTime"/> value to get the total number of months between.</param>
    /// <param name="dt2">The second <see cref="DateTime"/> value to get the total number of months between.</param>
    /// <returns>The total number of months between the two <see cref="DateTime"/> values, or null if the first <see cref="DateTime"/> value is null.</returns>
    public static int? TotalMonths(DateTime? dt1, DateTime? dt2) => dt1.HasValue ? TotalMonths(dt1.Value, dt2) : null;

    /// <summary>
    /// Converts the value of the current <see cref="DateTime"/> object to a new time zone. If the current <see cref="DateTime"/> value is null, returns null.
    /// </summary>
    /// <param name="dt">The current <see cref="DateTime"/> object to be converted.</param>
    /// <param name="tzSrc">The time zone identifier to convert from.</param>
    /// <param name="tzDst">The time zone identifier to convert to.</param>
    /// <returns>A <see cref="DateTime"/> object whose value is the converted time of the current <see cref="DateTime"/> object, or null if the current <see cref="DateTime"/> value is null.</returns>
    public static DateTime? ChangeTimeZone(this DateTime? dt, int tzSrc, int tzDst) => dt.HasValue ? dt.Value.ChangeTimeZone(tzSrc, tzDst) : null;

    /// <summary>
    /// Converts the value of the current <see cref="DateTime"/> object to a new time zone. If the current <see cref="DateTime"/> value is null, returns null.
    /// </summary>
    /// <param name="dt">The current <see cref="DateTime"/> object to be converted.</param>
    /// <param name="tzSrc">The time zone identifier to convert from, or null to use the local time zone.</param>
    /// <param name="tzDst">The time zone identifier to convert to.</param>
    /// <returns>A <see cref="DateTime"/> object whose value is the converted time of the current <see cref="DateTime"/> object, or null if the current <see cref="DateTime"/> value is null.</returns>
    public static DateTime? ChangeTimeZone(this DateTime dt, int? tzSrc, int tzDst) => tzSrc.HasValue ? dt.ChangeTimeZone(tzSrc.Value, tzDst) : dt.ChangeTimeZone(tzDst);

    /// <summary>
    /// Converts the specified date and time from the source time zone to the destination time zone.
    /// </summary>
    /// <param name="dt">The date and time to convert.</param>
    /// <param name="tzSrc">The source time zone offset from Coordinated Universal Time (UTC), in hours.</param>
    /// <param name="tzDst">The destination time zone offset from Coordinated Universal Time (UTC), in hours.</param>
    /// <returns>The date and time in the destination time zone, or <see langword="null"/> if <paramref name="dt"/> is <see langword="null"/>.</returns>
    public static DateTime? ChangeTimeZone(this DateTime dt, int tzSrc, int? tzDst) => tzDst.HasValue ? dt.ChangeTimeZone(tzSrc, tzDst.Value) : dt;

    /// <summary>
    /// Converts a nullable <see cref="DateTime"/> value to a new <paramref name="tzDst"/> time zone while assuming the source time zone to be <paramref name="tzSrc"/>.
    /// </summary>
    /// <param name="dt">The nullable <see cref="DateTime"/> value to convert.</param>
    /// <param name="tzSrc">An optional <see cref="int"/> value representing the source time zone offset in hours.</param>
    /// <param name="tzDst">An <see cref="int"/> value representing the destination time zone offset in hours.</param>
    /// <returns>A nullable <see cref="DateTime"/> object in the new <paramref name="tzDst"/> time zone or null if the input <paramref name="dt"/> is null.</returns>
    public static DateTime? ChangeTimeZone(this DateTime? dt, int? tzSrc, int tzDst) => dt.HasValue ? dt.Value.ChangeTimeZone(tzSrc, tzDst) : null;

    /// <summary>
    /// Converts the time of the current nullable System.DateTime object to the specified destination time zone using the time zone offset of the source time zone.
    /// </summary>
    /// <param name="dt">The nullable System.DateTime object to convert.</param>
    /// <param name="tzSrc">The source time zone offset from Coordinated Universal Time (UTC), in hours.</param>
    /// <param name="tzDst">The destination time zone offset from Coordinated Universal Time (UTC), in hours.</param>
    /// <returns>The System.DateTime object with the converted time in the destination time zone, or null if the input is null.</returns>
    public static DateTime? ChangeTimeZone(this DateTime? dt, int tzSrc, int? tzDst) => dt.HasValue ? dt.Value.ChangeTimeZone(tzSrc, tzDst) : null;

    /// <summary>
    /// Convert a given <see cref="DateTime"/> from one time zone to another time zone.
    /// </summary>
    /// <param name="dt">The <see cref="DateTime"/> to be converted.</param>
    /// <param name="tzSrc">The source time zone offset from UTC, in hours. If null, the local time zone is used.</param>
    /// <param name="tzDst">The destination time zone offset from UTC, in hours. If null, the local time zone is used.</param>
    /// <returns>The converted <see cref="DateTime"/> object. If the input is null, returns null.</returns>
    public static DateTime? ChangeTimeZone(this DateTime dt, int? tzSrc, int? tzDst) => tzSrc.HasValue ? dt.ChangeTimeZone(tzSrc.Value, tzDst) : dt.ChangeTimeZone(tzDst);

    /// <summary>
    /// Converts the specified nullable DateTime value to the destination time zone using the source time zone. If either source or destination time zone is null, returns null.
    /// </summary>
    /// <param name="dt">The nullable DateTime value to convert</param>
    /// <param name="tzSrc">The source time zone offset in hours</param>
    /// <param name="tzDst">The destination time zone offset in hours</param>
    /// <returns>The nullable DateTime value in the destination time zone</returns>
    public static DateTime? ChangeTimeZone(this DateTime? dt, int? tzSrc, int? tzDst) => dt.HasValue ? dt.Value.ChangeTimeZone(tzSrc, tzDst) : null;

    /// <summary>
    /// Changes the time zone of a nullable <see cref="DateTime"/> object from its current time zone to the specified destination time zone.
    /// </summary>
    /// <param name="dt">The nullable <see cref="DateTime"/> object to be converted.</param>
    /// <param name="tzDst">The destination time zone offset from Coordinated Universal Time (UTC), in hours.</param>
    /// <returns>A nullable <see cref="DateTime"/> object that represents the same point in time as the input <see cref="DateTime"/> object but in the destination time zone, or <see langword="null"/> if the input is <see langword="null"/>.</returns>
    public static DateTime? ChangeTimeZone(this DateTime? dt, int tzDst) => dt.ChangeTimeZone(0, tzDst);

    /// <summary>
    /// Converts a <see cref="DateTime"/> value to a new timezone based on the Daylight Saving Time offset, if provided. If no Daylight Saving Time offset is provided, the value is converted to the new timezone based on the standard time offset.
    /// </summary>
    /// <param name="dt">The <see cref="DateTime"/> value to convert.</param>
    /// <param name="tzDst">The Daylight Saving Time offset, in hours, for the new timezone. If not provided, the standard time offset will be used.</param>
    /// <returns>The converted <see cref="DateTime"/> value, or null if the original value is null.</returns>
    public static DateTime? ChangeTimeZone(this DateTime dt, int? tzDst) => dt.ChangeTimeZone(0, tzDst);

    /// <summary>
    /// Converts the current <see cref="DateTime"/> value to a new date and time value with a different time zone, where the source time zone is unspecified (assumes UTC) and the destination time zone is specified by <paramref name="tzDst"/>.
    /// </summary>
    /// <param name="dt">The <see cref="Nullable{T}"/> of <see cref="DateTime"/> to convert.</param>
    /// <param name="tzDst">The destination time zone, expressed as the number of hours offset from UTC.</param>
    /// <returns>The converted <see cref="Nullable{T}"/> of <see cref="DateTime"/> value, or null if the input is null.</returns>
    public static DateTime? ChangeTimeZone(this DateTime? dt, int? tzDst) => dt.ChangeTimeZone(0, tzDst);
}
