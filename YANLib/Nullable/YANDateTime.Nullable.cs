using static System.DateTime;
using static System.Globalization.CultureInfo;
using static System.Globalization.DateTimeStyles;

namespace YANLib.Nullable;

public static partial class YANDateTime
{
    /// <summary>
    /// Try parse <see cref="string"/> to <see cref="DateTime"/>, if failed return <paramref name="dfltVal"/> value with option string format <paramref name="fmt"/>.
    /// </summary>
    /// <param name="str">Input string</param>
    /// <param name="fmt">String format.</param>
    /// <param name="dfltVal">Default value.</param>
    /// <returns><see cref="DateTime"/> value.</returns>
    public static DateTime? ParseDateTime(this string str, string fmt, DateTime? dfltVal) => TryParseExact(str, fmt, InvariantCulture, None, out var dt) ? dt : dfltVal;

    /// <summary>
    /// Generate random <see cref="DateTime"/> value with <paramref name="min"/> and <paramref name="max"/> value.
    /// </summary>
    /// <param name="min">The inclusive lower bound of the random value returned.</param>
    /// <param name="max">The exclusive upper bound of the random value returned. <paramref name="max"/> must be greater than or equal to <paramref name="min"/>. If not, return null.</param>
    /// <returns><see cref="DateTime"/> random value.</returns>
    public static DateTime? RandomDateTime(DateTime? min, DateTime max) => min.HasValue ? RandomDateTime(min.Value, max) : null;

    /// <summary>
    /// Generate random <see cref="DateTime"/> value with <paramref name="min"/> and <paramref name="max"/> value.
    /// </summary>
    /// <param name="min">The inclusive lower bound of the random value returned.</param>
    /// <param name="max">The exclusive upper bound of the random value returned. <paramref name="max"/> must be greater than or equal to <paramref name="min"/>. If not, return null.</param>
    /// <returns><see cref="DateTime"/> random value.</returns>
    public static DateTime? RandomDateTime(DateTime min, DateTime? max) => max.HasValue ? RandomDateTime(min, max.Value) : null;

    /// <summary>
    /// Generate random <see cref="DateTime"/> value with <paramref name="min"/> and <paramref name="max"/> value.
    /// </summary>
    /// <param name="min">The inclusive lower bound of the random value returned.</param>
    /// <param name="max">The exclusive upper bound of the random value returned. <paramref name="max"/> must be greater than or equal to <paramref name="min"/>. If not, return null.</param>
    /// <returns><see cref="DateTime"/> random value.</returns>
    public static DateTime? RandomDateTime(DateTime? min, DateTime? max) => min.HasValue ? RandomDateTime(min.Value, max) : RandomDateTime(max);

    /// <summary>
    /// Generate random <see cref="DateTime"/> value with <paramref name="max"/> value.
    /// </summary>
    /// <param name="max">The exclusive upper bound of the random value to be generated. <paramref name="max"/> must be greater than or equal to null. If not, the inclusive lower bound of the random value flexible to <see cref="MinValue"/>.</param>
    /// <returns><see cref="DateTime"/> random value.</returns>
    public static DateTime? RandomDateTime(DateTime? max)
    {
        if (max.HasValue)
        {
            var maxVal = max.Value;
            return RandomDateTime(maxVal > Today ? Today : MinValue, maxVal);
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Returns the week of year that includes the date in the specified <see cref="DateTime"/> value.
    /// </summary>
    /// <param name="dt">Input date time.</param>
    /// <returns>The positive integer that represents the week of the year that includes the date in the <paramref name="dt"/> parameter.</returns>
    public static int? GetWeekOfYear(this DateTime? dt) => dt.HasValue ? dt.Value.GetWeekOfYear() : null;

    /// <summary>
    /// Get the value of current <see cref="TimeSpan"/> structure expressed in whole and fractional month.
    /// </summary>
    /// <param name="dt1">The first of date time to total.</param>
    /// <param name="dt2">The second of date time to total.</param>
    /// <returns>The total number of month represented by this instance.</returns>
    public static int? TotalMonths(DateTime? dt1, DateTime dt2) => dt1.HasValue ? YANLib.YANDateTime.TotalMonths(dt1.Value, dt2) : null;

    /// <summary>
    /// Get the value of current <see cref="TimeSpan"/> structure expressed in whole and fractional month.
    /// </summary>
    /// <param name="dt1">The first of date time to total.</param>
    /// <param name="dt2">The second of date time to total.</param>
    /// <returns>The total number of month represented by this instance.</returns>
    public static int? TotalMonths(DateTime dt1, DateTime? dt2) => dt2.HasValue ? YANLib.YANDateTime.TotalMonths(dt1, dt2.Value) : null;

    /// <summary>
    /// Get the value of current <see cref="TimeSpan"/> structure expressed in whole and fractional month.
    /// </summary>
    /// <param name="dt1">The first of date time to total.</param>
    /// <param name="dt2">The second of date time to total.</param>
    /// <returns>The total number of month represented by this instance.</returns>
    public static int? TotalMonths(DateTime? dt1, DateTime? dt2) => dt1.HasValue ? TotalMonths(dt1.Value, dt2) : null;

    /// <summary>
    /// Change date time value by different time zone.
    /// </summary>
    /// <param name="dt">Input date time.</param>
    /// <param name="tzSrc">Time zone source.</param>
    /// <param name="tzDst">Time zone destination.</param>
    /// <returns>Date time value changed.</returns>
    public static DateTime? ChangeTimeZone(this DateTime? dt, int tzSrc, int tzDst) => dt.HasValue ? dt.Value.ChangeTimeZone(tzSrc, tzDst) : null;

    /// <summary>
    /// Change date time value by different time zone.
    /// </summary>
    /// <param name="dt">Input date time.</param>
    /// <param name="tzSrc">Time zone source.</param>
    /// <param name="tzDst">Time zone destination.</param>
    /// <returns>Date time value changed.</returns>
    public static DateTime? ChangeTimeZone(this DateTime dt, int? tzSrc, int tzDst) => tzSrc.HasValue ? dt.ChangeTimeZone(tzSrc.Value, tzDst) : dt.ChangeTimeZone(tzDst);

    /// <summary>
    /// Change date time value by different time zone.
    /// </summary>
    /// <param name="dt">Input date time.</param>
    /// <param name="tzSrc">Time zone source.</param>
    /// <param name="tzDst">Time zone destination.</param>
    /// <returns>Date time value changed.</returns>
    public static DateTime? ChangeTimeZone(this DateTime dt, int tzSrc, int? tzDst) => tzDst.HasValue ? dt.ChangeTimeZone(tzSrc, tzDst.Value) : dt;

    /// <summary>
    /// Change date time value by different time zone.
    /// </summary>
    /// <param name="dt">Input date time.</param>
    /// <param name="tzSrc">Time zone source.</param>
    /// <param name="tzDst">Time zone destination.</param>
    /// <returns>Date time value changed.</returns>
    public static DateTime? ChangeTimeZone(this DateTime? dt, int? tzSrc, int tzDst) => dt.HasValue ? dt.Value.ChangeTimeZone(tzSrc, tzDst) : null;

    /// <summary>
    /// Change date time value by different time zone.
    /// </summary>
    /// <param name="dt">Input date time.</param>
    /// <param name="tzSrc">Time zone source.</param>
    /// <param name="tzDst">Time zone destination.</param>
    /// <returns>Date time value changed.</returns>
    public static DateTime? ChangeTimeZone(this DateTime? dt, int tzSrc, int? tzDst) => dt.HasValue ? dt.Value.ChangeTimeZone(tzSrc, tzDst) : null;

    /// <summary>
    /// Change date time value by different time zone.
    /// </summary>
    /// <param name="dt">Input date time.</param>
    /// <param name="tzSrc">Time zone source.</param>
    /// <param name="tzDst">Time zone destination.</param>
    /// <returns>Date time value changed.</returns>
    public static DateTime? ChangeTimeZone(this DateTime dt, int? tzSrc, int? tzDst) => tzSrc.HasValue ? dt.ChangeTimeZone(tzSrc.Value, tzDst) : dt.ChangeTimeZone(tzDst);

    /// <summary>
    /// Change date time value by different time zone.
    /// </summary>
    /// <param name="dt">Input date time.</param>
    /// <param name="tzSrc">Time zone source.</param>
    /// <param name="tzDst">Time zone destination.</param>
    /// <returns>Date time value changed.</returns>
    public static DateTime? ChangeTimeZone(this DateTime? dt, int? tzSrc, int? tzDst) => dt.HasValue ? dt.Value.ChangeTimeZone(tzSrc, tzDst) : null;

    /// <summary>
    /// Change date time value from time zone 0 to time zone destination.
    /// </summary>
    /// <param name="dt">Input date time.</param>
    /// <param name="tzDst">Time zone destination.</param>
    /// <returns>Date time value changed.</returns>
    public static DateTime? ChangeTimeZone(this DateTime? dt, int tzDst) => dt.ChangeTimeZone(0, tzDst);

    /// <summary>
    /// Change date time value from time zone 0 to time zone destination.
    /// </summary>
    /// <param name="dt">Input date time.</param>
    /// <param name="tzDst">Time zone destination.</param>
    /// <returns>Date time value changed.</returns>
    public static DateTime? ChangeTimeZone(this DateTime dt, int? tzDst) => dt.ChangeTimeZone(0, tzDst);

    /// <summary>
    /// Change date time value from time zone 0 to time zone destination.
    /// </summary>
    /// <param name="dt">Input date time.</param>
    /// <param name="tzDst">Time zone destination.</param>
    /// <returns>Date time value changed.</returns>
    public static DateTime? ChangeTimeZone(this DateTime? dt, int? tzDst) => dt.ChangeTimeZone(0, tzDst);
}
