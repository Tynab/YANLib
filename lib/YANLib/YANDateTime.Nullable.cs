using System.Linq;
using static System.DateTime;
using static System.Linq.Enumerable;

namespace YANLib;

public static partial class YANDateTime
{
    /// <summary>
    /// Converts the specified string representation of a date and time to its <see cref="DateTime"/> equivalent using the specified format.
    /// Returns the resulting <see cref="DateTime"/> object if the conversion is successful, otherwise returns the specified default value.
    /// </summary>
    /// <param name="str">The string to be converted to <see cref="DateTime"/>.</param>
    /// <param name="fmt">The format of the input string.</param>
    /// <param name="dfltVal">The default value to return if the conversion fails.</param>
    /// <returns>The <see cref="DateTime"/> equivalent of the input string in the specified format, or the specified default value if the conversion fails.</returns>
    public static DateTime ToDateTime(this string str, string fmt, DateTime? dfltVal) => dfltVal.HasValue ? str.ToDateTime(fmt, dfltVal.Value) : default;

    /// <summary>
    /// Converts a collection of string representations of dates and times to their <see cref="DateTime"/> equivalents using the specified format.
    /// Returns an enumerable collection of <see cref="DateTime"/> objects for each successfully converted input string in the specified format, and returns the specified default value for any strings that fail to convert.
    /// </summary>
    /// <param name="strs">The collection of strings to be converted to <see cref="DateTime"/>.</param>
    /// <param name="fmt">The format of the input strings.</param>
    /// <param name="dfltVal">The default value to return for any strings that fail to convert.</param>
    /// <returns>An enumerable collection of <see cref="DateTime"/> objects for each successfully converted input string in the specified format, and the specified default value for any strings that fail to convert.</returns>
    public static IEnumerable<DateTime>? ToDateTime(this IEnumerable<string> strs, string fmt, DateTime? dfltVal) => strs.AllWhiteSpaceOrNull() ? default : strs.Select(s => s.ToDateTime(fmt, dfltVal));

    /// <summary>
    /// Generates a random <see cref="DateTime"/> object between the specified minimum and maximum values.
    /// </summary>
    /// <param name="min">The minimum <see cref="DateTime"/> value that can be generated.</param>
    /// <param name="max">The maximum <see cref="DateTime"/> value that can be generated.</param>
    /// <returns>A randomly generated <see cref="DateTime"/> object between the specified minimum and maximum values.</returns>
    public static DateTime GenerateRandomDateTime(DateTime? min, DateTime max) => min.HasValue ? GenerateRandomDateTime(min.Value, max) : default;

    /// <summary>
    /// Generates a random <see cref="DateTime"/> object between the specified minimum and maximum values.
    /// </summary>
    /// <param name="min">The minimum <see cref="DateTime"/> value that can be generated.</param>
    /// <param name="max">The maximum <see cref="DateTime"/> value that can be generated.</param>
    /// <returns>A randomly generated <see cref="DateTime"/> object between the specified minimum and maximum values.</returns>
    public static DateTime GenerateRandomDateTime(DateTime min, DateTime? max) => max.HasValue ? GenerateRandomDateTime(min, max.Value) : default;

    /// <summary>
    /// Generates a random <see cref="DateTime"/> object between the specified minimum and maximum values.
    /// </summary>
    /// <param name="min">The minimum <see cref="DateTime"/> value that can be generated.</param>
    /// <param name="max">The maximum <see cref="DateTime"/> value that can be generated.</param>
    /// <returns>A randomly generated <see cref="DateTime"/> object between the specified minimum and maximum values.</returns>
    public static DateTime GenerateRandomDateTime(DateTime? min, DateTime? max) => min.HasValue ? GenerateRandomDateTime(min.Value, max) : GenerateRandomDateTime(max);

    /// <summary>
    /// Generates a random <see cref="DateTime"/> object between the minimum <see cref="DateTime"/> value and the specified maximum value.
    /// </summary>
    /// <param name="max">The maximum <see cref="DateTime"/> value that can be generated.</param>
    /// <returns>A randomly generated <see cref="DateTime"/> object between the minimum <see cref="DateTime"/> value and the specified maximum value.</returns>
    public static DateTime GenerateRandomDateTime(DateTime? max) => max.HasValue ? GenerateRandomDateTime(max.Value) : default;

    public static IEnumerable<DateTime> GenerateRandomDateTimes<T>(DateTime? min, DateTime? max, T size) where T : struct => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomDateTime(min, max));

    public static IEnumerable<DateTime> GenerateRandomDateTimes<T>(DateTime? min, DateTime? max, T? size) where T : struct => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomDateTime(min, max));

    public static IEnumerable<DateTime> GenerateRandomDateTimes<T>(DateTime min, DateTime? max, T size) where T : struct => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomDateTime(min, max));

    public static IEnumerable<DateTime> GenerateRandomDateTimes<T>(DateTime min, DateTime? max, T? size) where T : struct => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomDateTime(min, max));

    public static IEnumerable<DateTime> GenerateRandomDateTimes<T>(DateTime? min, DateTime max, T size) where T : struct => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomDateTime(min, max));

    public static IEnumerable<DateTime> GenerateRandomDateTimes<T>(DateTime? min, DateTime max, T? size) where T : struct => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomDateTime(min, max));

    public static int GetWeekOfYear(this DateTime? dt) => dt.HasValue ? dt.Value.GetWeekOfYear() : default;

    public static IEnumerable<int>? GetWeekOfYear(this IEnumerable<DateTime?> dts) => dts is null || !dts.Any() ? default : dts.Select(d => d.GetWeekOfYear());

    public static int TotalMonths(DateTime? dt1, DateTime dt2) => dt1.HasValue ? TotalMonths(dt1.Value, dt2) : default;

    public static int TotalMonths(DateTime dt1, DateTime? dt2) => dt2.HasValue ? TotalMonths(dt1, dt2.Value) : default;

    public static int TotalMonths(DateTime? dt1, DateTime? dt2) => dt1.HasValue ? TotalMonths(dt1.Value, dt2) : default;

    public static DateTime ChangeTimeZone<T1, T2>(this DateTime? dt, T1 tzSrc, T2 tzDst) where T1 : struct where T2 : struct => dt.HasValue ? dt.Value.ChangeTimeZone(tzSrc, tzDst) : default;

    public static IEnumerable<DateTime>? ChangeTimeZone<T1, T2>(this IEnumerable<DateTime?> dts, T1 tzSrc, T2 tzDst) where T1 : struct where T2 : struct => dts is null || !dts.Any() ? default : dts.Select(d => d.ChangeTimeZone(tzSrc, tzDst));

    public static void ChangeTimeZone<T1, T2>(this IList<DateTime?> dts, T1 tzSrc, T2 tzDst) where T1 : struct where T2 : struct
    {
        if (dts is not null && dts.Count > 0)
        {
            for (var i = 0; i < dts.Count; i++)
            {
                dts[i] = dts[i].ChangeTimeZone(tzSrc, tzDst);
            }
        }
    }

    public static DateTime ChangeTimeZone<T1, T2>(this DateTime dt, T1? tzSrc, T2 tzDst) where T1 : struct where T2 : struct => tzSrc.HasValue ? dt.ChangeTimeZone(tzSrc.Value, tzDst) : dt.ChangeTimeZone(tzDst);

    public static IEnumerable<DateTime>? ChangeTimeZone<T1, T2>(this IEnumerable<DateTime> dts, T1? tzSrc, T2 tzDst) where T1 : struct where T2 : struct => dts is null || !dts.Any() ? default : dts.Select(d => d.ChangeTimeZone(tzSrc, tzDst));

    public static void ChangeTimeZone<T1, T2>(this IList<DateTime> dts, T1? tzSrc, T2 tzDst) where T1 : struct where T2 : struct
    {
        if (dts is not null && dts.Count > 0)
        {
            for (var i = 0; i < dts.Count; i++)
            {
                dts[i] = dts[i].ChangeTimeZone(tzSrc, tzDst);
            }
        }
    }

    public static DateTime ChangeTimeZone<T1, T2>(this DateTime dt, T1 tzSrc, T2? tzDst) where T1 : struct where T2 : struct => tzDst.HasValue ? dt.ChangeTimeZone(tzSrc, tzDst.Value) : dt;

    public static IEnumerable<DateTime>? ChangeTimeZone<T1, T2>(this IEnumerable<DateTime> dts, T1 tzSrc, T2? tzDst) where T1 : struct where T2 : struct => dts is null || !dts.Any() ? default : dts.Select(d => d.ChangeTimeZone(tzSrc, tzDst));

    public static void ChangeTimeZone<T1, T2>(this IList<DateTime> dts, T1 tzSrc, T2? tzDst) where T1 : struct where T2 : struct
    {
        if (dts is not null && dts.Count > 0)
        {
            for (var i = 0; i < dts.Count; i++)
            {
                dts[i] = dts[i].ChangeTimeZone(tzSrc, tzDst);
            }
        }
    }

    public static DateTime ChangeTimeZone<T1, T2>(this DateTime? dt, T1? tzSrc, T2 tzDst) where T1 : struct where T2 : struct => dt.HasValue ? dt.Value.ChangeTimeZone(tzSrc, tzDst) : default;

    public static IEnumerable<DateTime>? ChangeTimeZone<T1, T2>(this IEnumerable<DateTime?> dts, T1? tzSrc, T2 tzDst) where T1 : struct where T2 : struct => dts is null || !dts.Any() ? default : dts.Select(d => d.ChangeTimeZone(tzSrc, tzDst));

    public static void ChangeTimeZone<T1, T2>(this IList<DateTime?> dts, T1? tzSrc, T2 tzDst) where T1 : struct where T2 : struct
    {
        if (dts is not null && dts.Count > 0)
        {
            for (var i = 0; i < dts.Count; i++)
            {
                dts[i] = dts[i].ChangeTimeZone(tzSrc, tzDst);
            }
        }
    }

    public static DateTime ChangeTimeZone<T1, T2>(this DateTime? dt, T1 tzSrc, T2? tzDst) where T1 : struct where T2 : struct => dt.HasValue ? dt.Value.ChangeTimeZone(tzSrc, tzDst) : default;

    public static IEnumerable<DateTime>? ChangeTimeZone<T1, T2>(this IEnumerable<DateTime?> dts, T1 tzSrc, T2? tzDst) where T1 : struct where T2 : struct => dts is null || !dts.Any() ? default : dts.Select(d => d.ChangeTimeZone(tzSrc, tzDst));

    public static void ChangeTimeZone<T1, T2>(this IList<DateTime?> dts, T1 tzSrc, T2? tzDst) where T1 : struct where T2 : struct
    {
        if (dts is not null && dts.Count > 0)
        {
            for (var i = 0; i < dts.Count; i++)
            {
                dts[i] = dts[i].ChangeTimeZone(tzSrc, tzDst);
            }
        }
    }

    public static DateTime ChangeTimeZone<T1, T2>(this DateTime dt, T1? tzSrc, T2? tzDst) where T1 : struct where T2 : struct => tzSrc.HasValue ? dt.ChangeTimeZone(tzSrc.Value, tzDst) : dt.ChangeTimeZone(tzDst);

    public static IEnumerable<DateTime>? ChangeTimeZone<T1, T2>(this IEnumerable<DateTime> dts, T1? tzSrc, T2? tzDst) where T1 : struct where T2 : struct => dts is null || !dts.Any() ? default : dts.Select(d => d.ChangeTimeZone(tzSrc, tzDst));

    public static void ChangeTimeZone<T1, T2>(this IList<DateTime> dts, T1? tzSrc, T2? tzDst) where T1 : struct where T2 : struct
    {
        if (dts is not null && dts.Count > 0)
        {
            for (var i = 0; i < dts.Count; i++)
            {
                dts[i] = dts[i].ChangeTimeZone(tzSrc, tzDst);
            }
        }
    }

    public static DateTime ChangeTimeZone<T1, T2>(this DateTime? dt, T1? tzSrc, T2? tzDst) where T1 : struct where T2 : struct => dt.HasValue ? dt.Value.ChangeTimeZone(tzSrc, tzDst) : default;

    public static IEnumerable<DateTime>? ChangeTimeZone<T1, T2>(this IEnumerable<DateTime?> dts, T1? tzSrc, T2? tzDst) where T1 : struct where T2 : struct => dts is null || !dts.Any() ? default : dts.Select(d => d.ChangeTimeZone(tzSrc, tzDst));

    public static void ChangeTimeZone<T1, T2>(this IList<DateTime?> dts, T1? tzSrc, T2? tzDst) where T1 : struct where T2 : struct
    {
        if (dts is not null && dts.Count > 0)
        {
            for (var i = 0; i < dts.Count; i++)
            {
                dts[i] = dts[i].ChangeTimeZone(tzSrc, tzDst);
            }
        }
    }

    public static DateTime ChangeTimeZone<T>(this DateTime? dt, T tzDst) where T : struct => dt.ChangeTimeZone(0, tzDst);

    public static IEnumerable<DateTime>? ChangeTimeZone<T>(this IEnumerable<DateTime?> dts, T tzDst) where T : struct => dts is null || !dts.Any() ? default : dts.Select(d => d.ChangeTimeZone(tzDst));

    public static void ChangeTimeZone<T>(this IList<DateTime?> dts, T tzDst) where T : struct
    {
        if (dts is not null && dts.Count > 0)
        {
            for (var i = 0; i < dts.Count; i++)
            {
                dts[i] = dts[i].ChangeTimeZone(tzDst);
            }
        }
    }

    public static DateTime ChangeTimeZone<T>(this DateTime dt, T? tzDst) where T : struct => dt.ChangeTimeZone(0, tzDst);

    public static IEnumerable<DateTime>? ChangeTimeZone<T>(this IEnumerable<DateTime> dts, T? tzDst) where T : struct => dts is null || !dts.Any() ? default : dts.Select(d => d.ChangeTimeZone(tzDst));

    public static void ChangeTimeZone<T>(this IList<DateTime> dts, T? tzDst) where T : struct
    {
        if (dts is not null && dts.Count > 0)
        {
            for (var i = 0; i < dts.Count; i++)
            {
                dts[i] = dts[i].ChangeTimeZone(tzDst);
            }
        }
    }

    public static DateTime ChangeTimeZone<T>(this DateTime? dt, T? tzDst) where T : struct => dt.ChangeTimeZone(0, tzDst);

    public static IEnumerable<DateTime>? ChangeTimeZone<T>(this IEnumerable<DateTime?> dts, T? tzDst) where T : struct => dts is null || !dts.Any() ? default : dts.Select(d => d.ChangeTimeZone(tzDst));

    public static void ChangeTimeZone<T>(this IList<DateTime?> dts, T? tzDst) where T : struct
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
