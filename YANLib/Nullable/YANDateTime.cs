using static System.DateTime;
using static System.Globalization.CultureInfo;
using static System.Globalization.DateTimeStyles;
using static System.Math;
using static YANLib.YANNum;

namespace YANLib.Nullable;

public static partial class YANDateTime
{
    /// <summary>
    /// Parses the string representation of a date and time using the default format.
    /// Returns the parsed <see cref="DateTime"/> value, or <see langword="null"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="DateTime"/> value, or <see langword="null"/> if the parsing fails.</returns>
    public static DateTime? ToDateTime(this string str) => TryParse(str, out var dt) ? dt : null;

    /// <summary>
    /// Parses the string representation of a date and time using <paramref name="fmt"/>.
    /// Returns the parsed <see cref="DateTime"/> value, or <see langword="null"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="fmt">The format of the string representation of the date and time.</param>
    /// <returns>The parsed <see cref="DateTime"/> value, or <see langword="null"/> if the parsing fails.</returns>
    public static DateTime? ToDateTime(this string str, string fmt) => TryParseExact(str, fmt, InvariantCulture, None, out var dt) ? dt : null;

    /// <summary>
    /// Generates a random nullable <see cref="DateTime"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, <see langword="null"/> is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="DateTime"/> value.</param>
    /// <param name="max">The maximum <see cref="DateTime"/> value.</param>
    /// <returns>A random nullable <see cref="DateTime"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static DateTime? GenRandomDateTime(DateTime min, DateTime max) => min > max ? null : min.AddTicks(GenRandomLong((max - min).Ticks));

    /// <summary>
    /// Returns a new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone.
    /// </summary>
    /// <param name="dt">The original <see cref="DateTime"/> value.</param>
    /// <param name="tzDst">The time zone offset to convert the original <see cref="DateTime"/> value to, in hours.</param>
    /// <returns>A new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone.</returns>
    public static DateTime? ChangeTimeZone(this DateTime dt, int tzSrc, int tzDst)
    {
        var diff = tzDst - tzSrc;
        return diff switch
        {
            < 0 when (dt - MinValue).TotalHours < Abs(diff) => null,
            > 0 when (MaxValue - dt).TotalHours < diff => null,
            _ => dt.AddHours(diff)
        };
    }

    /// <summary>
    /// Returns a new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with <paramref name="tzDst"/>.
    /// </summary>
    /// <param name="dt">The original <see cref="DateTime"/> value.</param>
    /// <param name="tzDst">The time zone offset to convert the original <see cref="DateTime"/> value to, in hours.</param>
    /// <returns>A new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with <paramref name="tzDst"/>.</returns>
    public static DateTime? ChangeTimeZone(this DateTime dt, int tzDst) => dt.ChangeTimeZone(0, tzDst);
}
