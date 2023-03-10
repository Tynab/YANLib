using static System.DateTime;
using static System.Globalization.CultureInfo;
using static System.Globalization.DateTimeFormatInfo;
using static System.Globalization.DateTimeStyles;
using static System.Math;
using static YANLib.YANNum;

namespace YANLib;

public static partial class YANDateTime
{
    /// <summary>
    /// Parses the string representation of a date and time using the default format. Returns the parsed <see cref="DateTime"/> value, or <see cref="Today"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="DateTime"/> value, or <see cref="Today"/> if the parsing fails.</returns>
    public static DateTime ParseDateTime(this string str) => TryParse(str, out var dt) ? dt : Today;

    /// <summary>
    /// Parses the string representation of a date and time using <paramref name="fmt"/>. Returns the parsed <see cref="DateTime"/> value, or <see cref="Today"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="fmt">The format of the string representation.</param>
    /// <returns>The parsed <see cref="DateTime"/> value, or <see cref="Today"/> if the parsing fails.</returns>
    public static DateTime ParseDateTime(this string str, string fmt) => TryParseExact(str, fmt, InvariantCulture, None, out var dt) ? dt : Today;

    /// <summary>
    /// Parses the string representation of a date and time using <paramref name="fmt"/>. Returns the parsed <see cref="DateTime"/> value, or <paramref name="dfltVal"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="fmt">The format of the string representation.</param>
    /// <param name="dfltVal">The default value to return if the parsing fails.</param>
    /// <returns>The parsed <see cref="DateTime"/> value, or <paramref name="dfltVal"/> if the parsing fails.</returns>
    public static DateTime ParseDateTime(this string str, string fmt, DateTime dfltVal) => TryParseExact(str, fmt, InvariantCulture, None, out var dt) ? dt : dfltVal;

    /// <summary>
    /// Parses the string representation of a date and time using <paramref name="fmt"/>. Returns the parsed <see cref="DateTime"/> value, or <see cref="MinValue"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="fmt">The format of the string representation.</param>
    /// <returns>The parsed <see cref="DateTime"/> value, or <see cref="MinValue"/> if the parsing fails.</returns>
    public static DateTime ParseDateTimeMin(this string str, string fmt) => TryParseExact(str, fmt, InvariantCulture, None, out var dt) ? dt : MinValue;

    /// <summary>
    /// Parses the string representation of a date and time using <paramref name="fmt"/>. Returns the parsed <see cref="DateTime"/> value, or <see cref="MaxValue"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="fmt">The format of the string representation.</param>
    /// <returns>The parsed <see cref="DateTime"/> value, or <see cref="MaxValue"/> if the parsing fails.</returns>
    public static DateTime ParseDateTimeMax(this string str, string fmt) => TryParseExact(str, fmt, InvariantCulture, None, out var dt) ? dt : MaxValue;

    /// <summary>
    /// Generates a random <see cref="DateTime"/> value between <paramref name="min"/> and <paramref name="max"/>. If <paramref name="min"/> is greater than <paramref name="max"/>, <see cref="Today"/> is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="DateTime"/> value.</param>
    /// <param name="max">The maximum <see cref="DateTime"/> value.</param>
    /// <returns>A random <see cref="DateTime"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static DateTime RandomDateTime(DateTime min, DateTime max) => min > max ? Today : min.AddTicks(RandomNumberLong((max - min).Ticks));

    /// <summary>
    /// Generates a random <see cref="DateTime"/> value between <see cref="MinValue"/> and <see cref="MaxValue"/> allowed by the <see cref="DateTime"/> type.
    /// </summary>
    /// <returns>A random <see cref="DateTime"/> value between <see cref="MinValue"/> and <see cref="MaxValue"/> allowed by the <see cref="DateTime"/> type.</returns>
    public static DateTime RandomDateTime() => RandomDateTime(MinValue, MaxValue);

    /// <summary>
    /// Generates a random <see cref="DateTime"/> value between the minimum value allowed by the <see cref="DateTime"/> type and <paramref name="max"/>. If <paramref name="max"/> is greater than <see cref="Today"/>, <see cref="Today"/> is used instead.
    /// </summary>
    /// <param name="max">The maximum <see cref="DateTime"/> value.</param>
    /// <returns>A random <see cref="DateTime"/> value between the minimum value allowed by the <see cref="DateTime"/> type and <paramref name="max"/>.</returns>
    public static DateTime RandomDateTime(DateTime max) => RandomDateTime(max > Today ? Today : MinValue, max);

    /// <summary>
    /// Returns the week of the year that the specified <see cref="DateTime"/> value falls in, according to the current culture's calendar, week rule, and first day of the week settings.
    /// </summary>
    /// <param name="dt">The <see cref="DateTime"/> value.</param>
    /// <returns>The week of the year that the specified <see cref="DateTime"/> value falls in.</returns>
    public static int GetWeekOfYear(this DateTime dt) => CurrentInfo.Calendar.GetWeekOfYear(dt, CurrentInfo.CalendarWeekRule, CurrentInfo.FirstDayOfWeek);

    /// <summary>
    /// Returns the total number of months between the two specified <see cref="DateTime"/> values, ignoring the day of the month.
    /// </summary>
    /// <param name="dt1">The first <see cref="DateTime"/> value.</param>
    /// <param name="dt2">The second <see cref="DateTime"/> value.</param>
    /// <returns>The total number of months between the two specified <see cref="DateTime"/> values, ignoring the day of the month.</returns>
    public static int TotalMonths(DateTime dt1, DateTime dt2) => Abs((dt1.Year - dt2.Year) * 12 + dt1.Month - dt2.Month);

    /// <summary>
    /// Returns a new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone.
    /// </summary>
    /// <param name="dt">The original <see cref="DateTime"/> value.</param>
    /// <param name="tzSrc">The time zone offset of the original <see cref="DateTime"/> value, in hours.</param>
    /// <param name="tzDst">The time zone offset to convert the original <see cref="DateTime"/> value to, in hours.</param>
    /// <returns>A new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone.</returns>
    public static DateTime ChangeTimeZone(this DateTime dt, int tzSrc, int tzDst)
    {
        var diff = tzDst - tzSrc;
        return diff switch
        {
            < 0 when (dt - MinValue).TotalHours < Abs(diff) => dt,
            > 0 when (MaxValue - dt).TotalHours < diff => dt,
            _ => dt.AddHours(diff)
        };
    }

    /// <summary>
    /// Returns a new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset of 0.
    /// </summary>
    /// <param name="dt">The original <see cref="DateTime"/> value.</param>
    /// <param name="tzDst">The time zone offset to convert the original <see cref="DateTime"/> value to, in hours.</param>
    /// <returns>A new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset of 0.</returns>
    public static DateTime ChangeTimeZone(this DateTime dt, int tzDst) => dt.ChangeTimeZone(0, tzDst);
}
