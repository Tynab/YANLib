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
    /// Parses the string representation of a date and time using the default format.
    /// Returns the parsed <see cref="DateTime"/> value, or <see langword="default"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="DateTime"/> value, or <see langword="default"/> if the parsing fails.</returns>
    public static DateTime ToDateTime(this string str) => TryParse(str, out var dt) ? dt : default;

    /// <summary>
    /// Converts an enumerable of strings representing date/time values to an <see cref="IEnumerable{DateTime}"/> containing the parsed DateTime values.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only whitespace strings.
    /// </summary>
    /// <param name="strs">The enumerable of strings to convert to DateTime values.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the parsed DateTime values.</returns>
    public static IEnumerable<DateTime> ToDateTime(IEnumerable<string> strs)
    {
        if (strs.IsNullOrWhiteSpace())
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.ToDateTime();
        }
    }

    /// <summary>
    /// Parses the string representation of a date and time using <paramref name="fmt"/>.
    /// Returns the parsed <see cref="DateTime"/> value, or <see langword="default"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="fmt">The format of the string representation.</param>
    /// <returns>The parsed <see cref="DateTime"/> value, or <see langword="default"/> if the parsing fails.</returns>
    public static DateTime ToDateTime(this string str, string fmt) => TryParseExact(str, fmt, InvariantCulture, None, out var dt) ? dt : default;

    /// <summary>
    /// Converts an enumerable of strings representing date/time values in a specified format to an <see cref="IEnumerable{DateTime}"/> containing the parsed DateTime values.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only whitespace strings.
    /// </summary>
    /// <param name="fmt">The format of the date/time values in the input strings.</param>
    /// <param name="strs">The enumerable of strings to convert to DateTime values.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the parsed DateTime values.</returns>
    public static IEnumerable<DateTime> ToDateTime(IEnumerable<string> strs, string fmt)
    {
        if (strs.IsNullOrWhiteSpace())
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.ToDateTime(fmt);
        }
    }

    /// <summary>
    /// Parses the string representation of a date and time using <paramref name="fmt"/>.
    /// Returns the parsed <see cref="DateTime"/> value, or <paramref name="dfltVal"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="fmt">The format of the string representation.</param>
    /// <param name="dfltVal">The default value to return if the parsing fails.</param>
    /// <returns>The parsed <see cref="DateTime"/> value, or <paramref name="dfltVal"/> if the parsing fails.</returns>
    public static DateTime ToDateTime(this string str, string fmt, DateTime dfltVal) => TryParseExact(str, fmt, InvariantCulture, None, out var dt) ? dt : dfltVal;

    /// <summary>
    /// Converts an enumerable of strings representing date/time values in a specified format to an <see cref="IEnumerable{DateTime}"/> containing the parsed DateTime values.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only whitespace strings.
    /// If a string cannot be parsed to a valid DateTime value, the default value specified by <paramref name="dfltVal"/> is used instead.
    /// </summary>
    /// <param name="fmt">The format of the date/time values in the input strings.</param>
    /// <param name="dfltVal">The default DateTime value to be used for strings that cannot be parsed to valid DateTime values.</param>
    /// <param name="strs">The enumerable of strings to convert to DateTime values.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the parsed DateTime values.</returns>
    public static IEnumerable<DateTime> ToDateTime(IEnumerable<string> strs, string fmt, DateTime dfltVal)
    {
        if (strs.IsNullOrWhiteSpace())
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.ToDateTime(fmt, dfltVal);
        }
    }

    /// <summary>
    /// Generates a random <see cref="DateTime"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, <see langword="default"/> is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="DateTime"/> value.</param>
    /// <param name="max">The maximum <see cref="DateTime"/> value.</param>
    /// <returns>A random <see cref="DateTime"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static DateTime GenerateRandomDateTime(DateTime min, DateTime max) => min > max ? default : min.AddTicks(GenerateRandomLong((max - min).Ticks));

    /// <summary>
    /// Generates an <see cref="IEnumerable{DateTime}"/> containing random DateTime values between <paramref name="min"/> and <paramref name="max"/>.
    /// The number of DateTime values generated is determined by the value of <paramref name="size"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, an empty sequence is returned.
    /// </summary>
    /// <typeparam name="T">
    /// The type of <paramref name="size"/>.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="min">The minimum DateTime value.</param>
    /// <param name="max">The maximum DateTime value.</param>
    /// <param name="size">The number of DateTime values to generate.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing random DateTime values between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static IEnumerable<DateTime> GenerateRandomDateTimes<T>(DateTime min, DateTime max, T size) where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomDateTime(min, max);
        }
    }

    /// <summary>
    /// Generates a random <see cref="DateTime"/> value between <see cref="MinValue"/> and <see cref="MaxValue"/>.
    /// </summary>
    /// <returns>A random <see cref="DateTime"/> value between <see cref="MinValue"/> and <see cref="MaxValue"/>.</returns>
    public static DateTime GenerateRandomDateTime() => GenerateRandomDateTime(MinValue, MaxValue);

    /// <summary>
    /// Generates a random <see cref="DateTime"/> value between <see cref="MinValue"/> and <paramref name="max"/>.
    /// </summary>
    /// <param name="max">The maximum <see cref="DateTime"/> value.</param>
    /// <returns>A random <see cref="DateTime"/> value between <see cref="MinValue"/> and <paramref name="max"/>.</returns>
    public static DateTime GenerateRandomDateTime(DateTime max) => GenerateRandomDateTime(max > Today ? Today : MinValue, max);

    /// <summary>
    /// Returns the week of the year that the specified <see cref="DateTime"/> value falls in, according to the current culture's calendar, week rule, and first day of the week settings.
    /// </summary>
    /// <param name="dt">The <see cref="DateTime"/> value.</param>
    /// <returns>The week of the year that the specified <see cref="DateTime"/> value falls in.</returns>
    public static int GetWeekOfYear(this DateTime dt) => CurrentInfo.Calendar.GetWeekOfYear(dt, CurrentInfo.CalendarWeekRule, CurrentInfo.FirstDayOfWeek);

    /// <summary>
    /// Gets the week of the year for an enumerable of DateTime values using the default calendar of the current culture.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/> or empty.
    /// </summary>
    /// <param name="dts">The enumerable of DateTime values for which to get the week of the year.</param>
    /// <returns>An <see cref="IEnumerable{Int32}"/> containing the week of the year values for the input DateTime values.</returns>
    public static IEnumerable<int> GetWeekOfYear(this IEnumerable<DateTime> dts)
    {
        if (dts is null || !dts.Any())
        {
            yield break;
        }
        foreach (var dt in dts)
        {
            yield return dt.GetWeekOfYear();
        }
    }

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
    /// <typeparam name="T1">The type of the original time zone offset, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone offset, which must be a value type.</typeparam>
    /// <param name="dt">The original <see cref="DateTime"/> value.</param>
    /// <param name="tzSrc">The time zone offset of the original <see cref="DateTime"/> value, in hours.</param>
    /// <param name="tzDst">The time zone offset to convert the original <see cref="DateTime"/> value to, in hours.</param>
    /// <returns>A new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone.</returns>
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

    /// <summary>
    /// Converts an enumerable of DateTime values from one time zone to another using the specified source and destination time zones.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/> or empty.
    /// </summary>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone to convert from.</param>
    /// <param name="tzDst">The destination time zone to convert to.</param>
    /// <param name="dts">The enumerable of DateTime values to convert.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the DateTime values converted to the destination time zone.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T1, T2>(this IEnumerable<DateTime> dts, T1 tzSrc, T2 tzDst) where T1 : struct where T2 : struct
    {
        if (dts is null || !dts.Any())
        {
            yield break;
        }
        foreach (var dt in dts)
        {
            yield return dt.ChangeTimeZone(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Converts an list of DateTime values from one time zone to another using the specified source and destination time zones, and updates the original list in-place.
    /// If the input list is <see langword="null"/> or empty, no action is taken.
    /// </summary>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="dts">The list of DateTime values to convert and update.</param>
    /// <param name="tzSrc">The source time zone to convert from.</param>
    /// <param name="tzDst">The destination time zone to convert to.</param>
    public static void ChangeTimeZoneRef<T1, T2>(this IList<DateTime> dts, T1 tzSrc, T2 tzDst) where T1 : struct where T2 : struct
    {
        if (dts is not null && dts.Count > 0)
        {
            for (var i = 0; i < dts.Count; i++)
            {
                dts[i] = dts[i].ChangeTimeZone(tzSrc, tzDst);
            }
        }
    }

    /// <summary>
    /// Returns a new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset of 0.
    /// </summary>
    /// <typeparam name="T">The type of the time zone offset to convert the original <see cref="DateTime"/> value to, which must be a value type.</typeparam>
    /// <param name="dt">The original <see cref="DateTime"/> value.</param>
    /// <param name="tzDst">The time zone offset to convert the original <see cref="DateTime"/> value to, in hours.</param>
    /// <returns>A new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset of 0.</returns>
    public static DateTime ChangeTimeZone<T>(this DateTime dt, T tzDst) where T : struct => dt.ChangeTimeZone(0, tzDst);

    /// <summary>
    /// Converts an array of DateTime values from one time zone to another using the specified destination time zone, and returns an <see cref="IEnumerable{DateTime}"/> containing the DateTime values converted to the destination time zone.
    /// Returns an empty sequence if the input array is <see langword="null"/> or empty.
    /// </summary>
    /// <typeparam name="T">The type of the destination time zone.</typeparam>
    /// <param name="tzDst">The destination time zone to convert to.</param>
    /// <param name="dts">The array of DateTime values to convert.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the DateTime values converted to the destination time zone.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T>(this IEnumerable<DateTime> dts, T tzDst) where T : struct
    {
        if (dts is null || !dts.Any())
        {
            yield break;
        }
        foreach (var dt in dts)
        {
            yield return dt.ChangeTimeZone(tzDst);
        }
    }

    /// <summary>
    /// Converts a list of DateTime values from one time zone to another using the specified destination time zone, and updates the original list in place with the DateTime values converted to the destination time zone.
    /// If the input list is <see langword="null"/> or empty, no changes will be made.
    /// </summary>
    /// <typeparam name="T">The type of the destination time zone.</typeparam>
    /// <param name="dts">The list of DateTime values to convert.</param>
    /// <param name="tzDst">The destination time zone to convert to.</param>
    public static void ChangeTimeZoneRef<T>(this IList<DateTime> dts, T tzDst) where T : struct
    {
        if (dts is not null && dts.Count > 0)
        {
            for (var i = 0; i < dts.Count; i++)
            {
                dts[i] = dts[i].ChangeTimeZone(tzDst);
            }
        }
    }
}
