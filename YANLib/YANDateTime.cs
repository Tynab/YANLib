using System.Globalization;
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
    /// Parses the string representation of a date and time and returns a <see cref="DateTime"/> object that represents the same value. If the parse operation fails, returns the current date and time.
    /// </summary>
    /// <param name="str">The string representation of a date and time to parse.</param>
    /// <returns>A <see cref="DateTime"/> object that represents the parsed value, or the current date and time if the parse operation fails.</returns>
    public static DateTime ParseDateTime(this string str) => TryParse(str, out var dt) ? dt : Today;

    /// <summary>
    /// Parses a string representation of a date and time to an equivalent <see cref="DateTime"/> value.
    /// </summary>
    /// <param name="str">The string representation of a date and time.</param>
    /// <param name="fmt">The format of the string representation of the date and time. <see cref="string"/>.</param>
    /// <returns>The <see cref="DateTime"/> value equivalent to the date and time represented in the <paramref name="str"/> parameter, or the current date and time if the <paramref name="str"/> parameter is not successfully parsed to a <see cref="DateTime"/> value. </returns>
    public static DateTime ParseDateTime(this string str, string fmt) => TryParseExact(str, fmt, InvariantCulture, None, out var dt) ? dt : Today;

    /// <summary>
    /// Converts the specified string representation of a date and time to its <see cref="DateTime"/> equivalent using the specified format. If the conversion fails, the default value is returned.
    /// </summary>
    /// <param name="str">A string that contains the date and time to convert.</param>
    /// <param name="fmt">The format of the string representation</param>
    /// <param name="dfltVal">The default value to return if the conversion fails</param>
    /// <returns>The equivalent <see cref="DateTime"/> value, or <paramref name="dfltVal"/> if the conversion fails</returns>
    public static DateTime ParseDateTime(this string str, string fmt, DateTime dfltVal) => TryParseExact(str, fmt, InvariantCulture, None, out var dt) ? dt : dfltVal;

    /// <summary>
    /// Parses the specified string representation of a date and time using the specified format and culture-specific format information. Returns the date and time equivalent to the date and time contained in <paramref name="str"/>, or the <see cref="MinValue"/> if the parse operation fails.
    /// </summary>
    /// <param name="str">A string containing a date and time to convert.</param>
    /// <param name="fmt">The format of the string representation to parse for a date and time value.</param>
    /// <returns>The date and time equivalent to the date and time contained in <paramref name="str"/>, or the <see cref="MinValue"/> if the parse operation fails.</returns>
    public static DateTime ParseDateTimeMin(this string str, string fmt) => TryParseExact(str, fmt, InvariantCulture, None, out var dt) ? dt : MinValue;

    /// <summary>
    /// Converts the string representation of a date and time to its <see cref="DateTime"/> equivalent using the specified format and returns the maximum possible value of <see cref="DateTime"/> if the conversion fails.
    /// </summary>
    /// <param name="str">A string containing a date and time to convert.</param>
    /// <param name="fmt">The format of the input string.</param>
    /// <returns>An object that is equivalent to the date and time contained in <paramref name="str"/>, if the conversion succeeded, or the maximum possible value of <see cref="DateTime"/> if the conversion failed.</returns>
    public static DateTime ParseDateTimeMax(this string str, string fmt) => TryParseExact(str, fmt, InvariantCulture, None, out var dt) ? dt : MaxValue;

    /// <summary>
    /// Generates a random <see cref="DateTime"/> between the minimum <paramref name="min"/> and maximum <paramref name="max"/> values. If the minimum value <paramref name="min"/> is greater than the maximum value <paramref name="max"/>, it returns the current date <see cref="Today"/>.
    /// </summary>
    /// <param name="min">The minimum <see cref="DateTime"/> value for the random date time.</param>
    /// <param name="max">The maximum <see cref="DateTime"/> value for the random date time.</param>
    /// <returns>A random <see cref="DateTime"/> between the specified minimum and maximum values.</returns>
    public static DateTime RandomDateTime(DateTime min, DateTime max) => min > max ? Today : min.AddTicks(RandomNumberLong((max - min).Ticks));

    /// <summary>
    /// Generates a random <see cref="DateTime"/> value between the <see cref="MinValue"/> and <see cref="MaxValue"/>.
    /// </summary>
    /// <returns>A random <see cref="DateTime"/> value.</returns>
    public static DateTime RandomDateTime() => RandomDateTime(MinValue, MaxValue);

    /// <summary>
    /// Generates a random <see cref="DateTime"/> between today or <see cref="MinValue"/> and the specified <paramref name="max"/>.
    /// </summary>
    /// <param name="max">The upper bound of the random <see cref="DateTime"/> generated. Must be greater than or equal to today or <see cref="MinValue"/>.</param>
    /// <returns>A random <see cref="DateTime"/> between today or <see cref="MinValue"/> and <paramref name="max"/>.</returns>
    public static DateTime RandomDateTime(DateTime max) => RandomDateTime(max > Today ? Today : MinValue, max);

    /// <summary>
    /// Gets the week of the year for the specified <see cref="DateTime"/> <paramref name="dt"/>. The week of the year is determined using the <see cref="CalendarWeekRule"/> and the <see cref="DayOfWeek"/> specified by the current <see cref="CultureInfo"/>.
    /// </summary>
    /// <param name="dt">The <see cref="DateTime"/> to get the week of the year for.</param>
    /// <returns>An integer representing the week of the year for the specified <see cref="DateTime"/> <paramref name="dt"/>.</returns>
    public static int GetWeekOfYear(this DateTime dt) => CurrentInfo.Calendar.GetWeekOfYear(dt, CurrentInfo.CalendarWeekRule, CurrentInfo.FirstDayOfWeek);

    /// <summary>
    /// Calculates the total number of months between two dates.
    /// </summary>
    /// <param name="dt1">The first date.</param>
    /// <param name="dt2">The second date.</param>
    /// <returns>The total number of months between two dates.</returns>
    public static int TotalMonths(DateTime dt1, DateTime dt2) => Abs((dt1.Year - dt2.Year) * 12 + dt1.Month - dt2.Month);

    /// <summary>
    /// Converts a <see cref="DateTime"/> value from a source timezone to a destination timezone. The source timezone offset and destination timezone offset are provided in hours.
    /// </summary>
    /// <param name="dt">The <see cref="DateTime"/> value to convert.</param>
    /// <param name="tzSrc">The timezone offset, in hours, of the source timezone.</param>
    /// <param name="tzDst">The timezone offset, in hours, of the destination timezone.</param>
    /// <returns>The converted <see cref="DateTime"/> value. If the conversion is not possible due to out-of-range values, the method returns the original value.</returns>
    public static DateTime ChangeTimeZone(this DateTime dt, int tzSrc, int tzDst)
    {
        var diff = tzDst - tzSrc;
        return diff < 0 ? (dt - MinValue).TotalHours < Abs(diff) ? dt : dt.AddHours(diff) : (MaxValue - dt).TotalHours < diff ? dt : dt.AddHours(diff);
    }

    /// <summary>
    /// Converts a <see cref="DateTime"/> value from the current timezone to a destination timezone. The current timezone offset is assumed to be 0, and the destination timezone offset is provided in hours.
    /// </summary>
    /// <param name="dt">The <see cref="DateTime"/> value to convert.</param>
    /// <param name="tzDst">The timezone offset, in hours, of the destination timezone.</param>
    /// <returns>The converted <see cref="DateTime"/> value.</returns>
    public static DateTime ChangeTimeZone(this DateTime dt, int tzDst) => dt.ChangeTimeZone(0, tzDst);
}
