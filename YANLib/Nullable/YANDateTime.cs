using static System.DateTime;
using static System.Globalization.CultureInfo;
using static System.Globalization.DateTimeStyles;
using static System.Math;
using static YANLib.YANNum;

namespace YANLib.Nullable;

public static partial class YANDateTime
{
    /// <summary>
    /// Try parse <see cref="string"/> to <see cref="DateTime"/>, if failed return null.
    /// </summary>
    /// <param name="str">Input string</param>
    /// <returns><see cref="DateTime"/> value.</returns>
    public static DateTime? ParseDateTime(this string str) => TryParse(str, out var dt) ? dt : null;

    /// <summary>
    /// Try parse <see cref="string"/> to <see cref="DateTime"/>, if failed return null with option string format <paramref name="fmt"/>.
    /// </summary>
    /// <param name="str">Input string</param>
    /// <param name="fmt">String format.</param>
    /// <returns><see cref="DateTime"/> value.</returns>
    public static DateTime? ParseDateTime(this string str, string fmt) => TryParseExact(str, fmt, InvariantCulture, None, out var dt) ? dt : null;

    /// <summary>
    /// Generate random <see cref="DateTime"/> value with <paramref name="min"/> and <paramref name="max"/> value.
    /// </summary>
    /// <param name="min">The inclusive lower bound of the random value returned.</param>
    /// <param name="max">The exclusive upper bound of the random value returned. <paramref name="max"/> must be greater than or equal to <paramref name="min"/>. If not, return null.</param>
    /// <returns><see cref="DateTime"/> random value.</returns>
    public static DateTime? RandomDateTime(DateTime min, DateTime max) => min > max ? null : min.AddTicks(RandomNumberLong((max - min).Ticks));

    /// <summary>
    /// Change date time value by different time zone.
    /// </summary>
    /// <param name="dt">Input date time.</param>
    /// <param name="tzSrc">Time zone source.</param>
    /// <param name="tzDst">Time zone destination.</param>
    /// <returns>Date time value changed.</returns>
    public static DateTime? ChangeTimeZone(this DateTime dt, int tzSrc, int tzDst)
    {
        var diff = tzDst - tzSrc;
        return diff < 0 ? (dt - MinValue).TotalHours < Abs(diff) ? null : dt.AddHours(diff) : (MaxValue - dt).TotalHours < diff ? null : dt.AddHours(diff);
    }

    /// <summary>
    /// Change date time value from time zone 0 to time zone destination.
    /// </summary>
    /// <param name="dt">Input date time.</param>
    /// <param name="tzDst">Time zone destination.</param>
    /// <returns>Date time value changed.</returns>
    public static DateTime? ChangeTimeZone(this DateTime dt, int tzDst) => dt.ChangeTimeZone(0, tzDst);
}
