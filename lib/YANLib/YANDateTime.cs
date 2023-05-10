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
    /// Converts the specified string representation of a date and time to its <see cref="DateTime"/> equivalent.
    /// Returns the resulting <see cref="DateTime"/> object if the conversion is successful, otherwise returns default.
    /// </summary>
    /// <param name="str">The string to be converted to <see cref="DateTime"/>.</param>
    /// <returns>The <see cref="DateTime"/> equivalent of the input string, or default if the conversion fails.</returns>
    public static DateTime ToDateTime(this string str) => TryParse(str, out var dt) ? dt : default;

    /// <summary>
    /// Converts a collection of string representations of dates and times to their <see cref="DateTime"/> equivalents.
    /// Returns an enumerable collection of <see cref="DateTime"/> objects for each successfully converted input string, and skips any strings that fail to convert.
    /// </summary>
    /// <param name="strs">The collection of strings to be converted to <see cref="DateTime"/>.</param>
    /// <returns>An enumerable collection of <see cref="DateTime"/> objects for each successfully converted input string.</returns>
    public static IEnumerable<DateTime>? ToDateTime(this IEnumerable<string> strs) => strs.IsEmptyOrNull() ? default : strs.Select(s => s.ToDateTime());

    /// <summary>
    /// Converts the specified string representation of a date and time to its <see cref="DateTime"/> equivalent using the specified format.
    /// Returns the resulting <see cref="DateTime"/> object if the conversion is successful, otherwise returns default.
    /// </summary>
    /// <param name="str">The string to be converted to <see cref="DateTime"/>.</param>
    /// <param name="fmt">The format of the input string.</param>
    /// <returns>The <see cref="DateTime"/> equivalent of the input string in the specified format, or default if the conversion fails.</returns>
    public static DateTime ToDateTime(this string str, string fmt) => TryParseExact(str, fmt, InvariantCulture, None, out var dt) ? dt : default;

    /// <summary>
    /// Converts a collection of string representations of dates and times to their <see cref="DateTime"/> equivalents using the specified format.
    /// Returns an enumerable collection of <see cref="DateTime"/> objects for each successfully converted input string in the specified format, and skips any strings that fail to convert.
    /// </summary>
    /// <param name="strs">The collection of strings to be converted to <see cref="DateTime"/>.</param>
    /// <param name="fmt">The format of the input strings.</param>
    /// <returns>An enumerable collection of <see cref="DateTime"/> objects for each successfully converted input string in the specified format.</returns>
    public static IEnumerable<DateTime>? ToDateTime(this IEnumerable<string> strs, string fmt) => strs.IsEmptyOrNull() ? default : strs.Select(s => s.ToDateTime(fmt));

    /// <summary>
    /// Converts the specified string representation of a date and time to its <see cref="DateTime"/> equivalent using the specified format.
    /// Returns the resulting <see cref="DateTime"/> object if the conversion is successful, otherwise returns the specified default value.
    /// </summary>
    /// <param name="str">The string to be converted to <see cref="DateTime"/>.</param>
    /// <param name="fmt">The format of the input string.</param>
    /// <param name="dfltVal">The default value to return if the conversion fails.</param>
    /// <returns>The <see cref="DateTime"/> equivalent of the input string in the specified format, or the specified default value if the conversion fails.</returns>
    public static DateTime ToDateTime(this string str, string fmt, DateTime dfltVal) => TryParseExact(str, fmt, InvariantCulture, None, out var dt) ? dt : dfltVal;

    /// <summary>
    /// Converts a collection of string representations of dates and times to their <see cref="DateTime"/> equivalents using the specified format.
    /// Returns an enumerable collection of <see cref="DateTime"/> objects for each successfully converted input string in the specified format, and returns the specified default value for any strings that fail to convert.
    /// </summary>
    /// <param name="strs">The collection of strings to be converted to <see cref="DateTime"/>.</param>
    /// <param name="fmt">The format of the input strings.</param>
    /// <param name="dfltVal">The default value to return for any strings that fail to convert.</param>
    /// <returns>An enumerable collection of <see cref="DateTime"/> objects for each successfully converted input string in the specified format, and the specified default value for any strings that fail to convert.</returns>
    public static IEnumerable<DateTime>? ToDateTime(this IEnumerable<string> strs, string fmt, DateTime dfltVal) => strs.IsEmptyOrNull() ? default : strs.Select(s => s.ToDateTime(fmt, dfltVal));

    /// <summary>
    /// Generates a random <see cref="DateTime"/> object between the specified minimum and maximum values.
    /// </summary>
    /// <param name="min">The minimum <see cref="DateTime"/> value that can be generated.</param>
    /// <param name="max">The maximum <see cref="DateTime"/> value that can be generated.</param>
    /// <returns>A randomly generated <see cref="DateTime"/> object between the specified minimum and maximum values.</returns>
    public static DateTime GenerateRandomDateTime(DateTime min, DateTime max) => min > max ? default : min.AddTicks((long)GenerateRandomUlong((max - min).Ticks));

    /// <summary>
    /// Generates a random <see cref="DateTime"/> object between the minimum value of <see cref="DateTime"/> and maximum value of <see cref="DateTime"/>.
    /// </summary>
    /// <returns>A randomly generated <see cref="DateTime"/> object between the minimum value of <see cref="DateTime"/> and maximum value of <see cref="DateTime"/>.</returns>
    public static DateTime GenerateRandomDateTime() => GenerateRandomDateTime(MinValue, MaxValue);

    /// <summary>
    /// Generates a random <see cref="DateTime"/> object between the minimum <see cref="DateTime"/> value and the specified maximum value.
    /// </summary>
    /// <param name="max">The maximum <see cref="DateTime"/> value that can be generated.</param>
    /// <returns>A randomly generated <see cref="DateTime"/> object between the minimum <see cref="DateTime"/> value and the specified maximum value.</returns>
    public static DateTime GenerateRandomDateTime(DateTime max) => GenerateRandomDateTime(max > Today ? Today : MinValue, max);

    public static IEnumerable<DateTime> GenerateRandomDateTimes<T>(DateTime min, DateTime max, T size) where T : struct => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomDateTime(min, max));

    public static int GetWeekOfYear(this DateTime dt) => CurrentInfo.Calendar.GetWeekOfYear(dt, CurrentInfo.CalendarWeekRule, CurrentInfo.FirstDayOfWeek);

    public static IEnumerable<int>? GetWeekOfYear(this IEnumerable<DateTime> dts) => dts.IsEmptyOrNull() ? default : dts.Select(d => d.GetWeekOfYear());

    public static int TotalMonths(DateTime dt1, DateTime dt2) => Abs((dt1.Year - dt2.Year) * 12 + dt1.Month - dt2.Month);

    public static DateTime ChangeTimeZone<T1, T2>(this DateTime dt, T1 tzSrc, T2 tzDst) where T1 : struct where T2 : struct
    {
        var diff = tzDst.ToInt() - tzSrc.ToInt();
        return diff switch
        {
            < 0 when (dt - MinValue).TotalHours < Abs(diff) => default,
            > 0 when (MaxValue - dt).TotalHours < diff => default,
            _ => dt.AddHours(diff)
        };
    }

    public static IEnumerable<DateTime>? ChangeTimeZone<T1, T2>(this IEnumerable<DateTime> dts, T1 tzSrc, T2 tzDst) where T1 : struct where T2 : struct => dts.IsEmptyOrNull() ? default : dts.Select(d => d.ChangeTimeZone(tzSrc, tzDst));

    public static DateTime ChangeTimeZone<T>(this DateTime dt, T tzDst) where T : struct => dt.ChangeTimeZone(0, tzDst);

    public static IEnumerable<DateTime>? ChangeTimeZone<T>(this IEnumerable<DateTime> dts, T tzDst) where T : struct => dts.IsEmptyOrNull() ? default : dts.Select(d => d.ChangeTimeZone(tzDst));
}
