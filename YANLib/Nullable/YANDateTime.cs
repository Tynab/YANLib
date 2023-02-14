using static System.DateTime;
using static System.Globalization.CultureInfo;
using static System.Globalization.DateTimeStyles;
using static System.Math;
using static YANLib.YANNum;

namespace YANLib.Nullable;

public static partial class YANDateTime
{
    /// <summary>
    /// An extension method to parse a string into a nullable <see cref="DateTime"/> object.
    /// </summary>
    /// <param name="str">The string to be parsed into a <see cref="DateTime"/> object.</param>
    /// <returns>A nullable <see cref="DateTime"/> object parsed from the input string, or null if the parse operation fails.</returns>
    public static DateTime? ParseDateTime(this string str) => TryParse(str, out var dt) ? dt : null;

    /// <summary>
    /// Parses a string representation of a <see cref="DateTime"/> object using a specified format.
    /// </summary>
    /// <param name="str">The input string to be parsed as a <see cref="DateTime"/> object.</param>
    /// <param name="fmt">The format used to parse the string representation of a <see cref="DateTime"/> object.</param>
    /// <returns>A <see cref="DateTime"/> object represented by the input string, or null if the string cannot be parsed using the specified format.</returns>
    public static DateTime? ParseDateTime(this string str, string fmt) => TryParseExact(str, fmt, InvariantCulture, None, out var dt) ? dt : null;

    /// <summary>
    /// Generates a random <see cref="DateTime"/> object within a specified range.
    /// </summary>
    /// <param name="min">The minimum value of the range used to generate the random <see cref="DateTime"/> object.
    /// <param name="max">The maximum value of the range used to generate the random <see cref="DateTime"/> object.
    /// <returns>A random <see cref="DateTime"/> object within the specified range, or null if the minimum value is greater than the maximum value.
    public static DateTime? RandomDateTime(DateTime min, DateTime max) => min > max ? null : min.AddTicks(RandomNumberLong((max - min).Ticks));

    /// <summary>
    /// Converts a <see cref="DateTime"/> value from a source timezone to a destination timezone. The source timezone offset and destination timezone offset are provided in hours.
    /// </summary>
    /// <param name="dt">The <see cref="DateTime"/> value to convert.</param>
    /// <param name="tzSrc">The timezone offset, in hours, of the source timezone.</param>
    /// <param name="tzDst">The timezone offset, in hours, of the destination timezone.</param>
    /// <returns>The converted <see cref="DateTime"/> value, or null if the original value is null or the conversion is not possible due to out-of-range values.</returns>
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
    /// Converts a <see cref="DateTime"/> value to a new timezone based on the Daylight Saving Time offset, if provided. If no Daylight Saving Time offset is provided, the value is converted to the new timezone based on the standard time offset.
    /// </summary>
    /// <param name="dt">The <see cref="DateTime"/> value to convert.</param>
    /// <param name="tzDst">The Daylight Saving Time offset, in minutes, for the new timezone. If not provided, the standard time offset will be used.</param>
    /// <returns>The converted <see cref="DateTime"/> value, or null if the original value is null.</returns>
    public static DateTime? ChangeTimeZone(this DateTime dt, int tzDst) => dt.ChangeTimeZone(0, tzDst);
}
