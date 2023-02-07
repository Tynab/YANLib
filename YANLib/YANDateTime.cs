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
    /// Try parse <see cref="string"/> to <see cref="DateTime"/>, if failed return <see cref="Today"/>.
    /// </summary>
    /// <param name="str">Input string</param>
    /// <returns><see cref="DateTime"/> value.</returns>
    public static DateTime ParseDateTime(this string str) => TryParse(str, out var dt) ? dt : Today;

    /// <summary>
    /// Try parse <see cref="string"/> to <see cref="DateTime"/>, if failed return <see cref="Today"/> with option string format <paramref name="fmt"/>.
    /// </summary>
    /// <param name="str">Input string</param>
    /// <param name="fmt">String format.</param>
    /// <returns><see cref="DateTime"/> value.</returns>
    public static DateTime ParseDateTime(this string str, string fmt) => TryParseExact(str, fmt, InvariantCulture, None, out var dt) ? dt : Today;

    /// <summary>
    /// Try parse <see cref="string"/> to <see cref="DateTime"/>, if failed return <paramref name="dfltVal"/> value with option string format <paramref name="fmt"/>.
    /// </summary>
    /// <param name="str">Input string</param>
    /// <param name="fmt">String format.</param>
    /// <param name="dfltVal">Default value.</param>
    /// <returns><see cref="DateTime"/> value.</returns>
    public static DateTime ParseDateTime(this string str, string fmt, DateTime dfltVal) => TryParseExact(str, fmt, InvariantCulture, None, out var dt) ? dt : dfltVal;

    /// <summary>
    /// Try parse <see cref="string"/> to <see cref="DateTime"/>, if failed return <see cref="MinValue"/> with option string format <paramref name="fmt"/>.
    /// </summary>
    /// <param name="str">Input string</param>
    /// <param name="fmt">String format.</param>
    /// <returns><see cref="DateTime"/> value.</returns>
    public static DateTime ParseDateTimeMin(this string str, string fmt) => TryParseExact(str, fmt, InvariantCulture, None, out var dt) ? dt : MinValue;

    /// <summary>
    /// Try parse <see cref="string"/> to <see cref="DateTime"/>, if failed return <see cref="MaxValue"/> with option string format <paramref name="fmt"/>.
    /// </summary>
    /// <param name="str">Input string</param>
    /// <param name="fmt">String format.</param>
    /// <returns><see cref="DateTime"/> value.</returns>
    public static DateTime ParseDateTimeMax(this string str, string fmt) => TryParseExact(str, fmt, InvariantCulture, None, out var dt) ? dt : MaxValue;

    /// <summary>
    /// Generate random <see cref="DateTime"/> value with <paramref name="min"/> and <paramref name="max"/> value.
    /// </summary>
    /// <param name="min">The inclusive lower bound of the random value returned.</param>
    /// <param name="max">The exclusive upper bound of the random value returned. <paramref name="max"/> must be greater than or equal to <paramref name="min"/>. If not, return <see cref="Today"/>.</param>
    /// <returns><see cref="DateTime"/> random value.</returns>
    public static DateTime RandomDateTime(DateTime min, DateTime max) => min > max ? Today : min.AddTicks(RandomNumberLong((max - min).Ticks));

    /// <summary>
    /// Generate random <see cref="DateTime"/> value.
    /// </summary>
    /// <returns><see cref="DateTime"/> random value.</returns>
    public static DateTime RandomDateTime() => RandomDateTime(MinValue, MaxValue);

    /// <summary>
    /// Generate random <see cref="DateTime"/> value with <paramref name="max"/> value.
    /// </summary>
    /// <param name="max">The exclusive upper bound of the random value to be generated. <paramref name="max"/> must be greater than or equal to <see cref="Today"/>. If not, the inclusive lower bound of the random value flexible to <see cref="MinValue"/>.</param>
    /// <returns><see cref="DateTime"/> random value.</returns>
    public static DateTime RandomDateTime(DateTime max) => RandomDateTime(max > Today ? Today : MinValue, max);

    /// <summary>
    /// Returns the week of year that includes the date in the specified <see cref="DateTime"/> value.
    /// </summary>
    /// <param name="dt">Input date time.</param>
    /// <returns>The positive integer that represents the week of the year that includes the date in the <paramref name="dt"/> parameter.</returns>
    public static int GetWeekOfYear(this DateTime dt) => CurrentInfo.Calendar.GetWeekOfYear(dt, CurrentInfo.CalendarWeekRule, CurrentInfo.FirstDayOfWeek);

    /// <summary>
    /// Get the value of current <see cref="TimeSpan"/> structure expressed in whole and fractional month.
    /// </summary>
    /// <param name="dt1">The first of date time to total.</param>
    /// <param name="dt2">The second of date time to total.</param>
    /// <returns>The total number of month represented by this instance.</returns>
    public static int TotalMonths(DateTime dt1, DateTime dt2) => Abs((dt1.Year - dt2.Year) * 12 + dt1.Month - dt2.Month);

    /// <summary>
    /// Change date time value by different time zone.
    /// </summary>
    /// <param name="dt">Input date time.</param>
    /// <param name="tzSrc">Time zone source.</param>
    /// <param name="tzDst">Time zone destination.</param>
    /// <returns>Date time value changed.</returns>
    public static DateTime ChangeTimeZone(this DateTime dt, int tzSrc, int tzDst)
    {
        var diff = tzDst - tzSrc;
        return diff < 0 ? (dt - MinValue).TotalHours < Abs(diff) ? dt : dt.AddHours(diff) : (MaxValue - dt).TotalHours < diff ? dt : dt.AddHours(diff);
    }

    /// <summary>
    /// Change date time value from time zone 0 to time zone destination.
    /// </summary>
    /// <param name="dt">Input date time.</param>
    /// <param name="tzDst">Time zone destination.</param>
    /// <returns>Date time value changed.</returns>
    public static DateTime ChangeTimeZone(this DateTime dt, int tzDst) => dt.ChangeTimeZone(0, tzDst);
}
