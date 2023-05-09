namespace YANLib.Ultimate;

public static partial class YANDateTime
{
    /// <summary>
    /// Converts a collection of string representations of dates and times to their <see cref="DateTime"/> equivalents.
    /// Returns an enumerable collection of <see cref="DateTime"/> objects for each successfully converted input string, and skips any strings that fail to convert.
    /// </summary>
    /// <param name="strs">The collection of strings to be converted to <see cref="DateTime"/>.</param>
    /// <returns>An enumerable collection of <see cref="DateTime"/> objects for each successfully converted input string.</returns>
    public static IEnumerable<DateTime> ToDateTime(this IEnumerable<string> strs)
    {
        if (strs.AllWhiteSpaceOrNull())
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.ToDateTime();
        }
    }

    /// <summary>
    /// Converts a collection of string representations of dates and times to their <see cref="DateTime"/> equivalents using the specified format.
    /// Returns an enumerable collection of <see cref="DateTime"/> objects for each successfully converted input string in the specified format, and skips any strings that fail to convert.
    /// </summary>
    /// <param name="strs">The collection of strings to be converted to <see cref="DateTime"/>.</param>
    /// <param name="fmt">The format of the input strings.</param>
    /// <returns>An enumerable collection of <see cref="DateTime"/> objects for each successfully converted input string in the specified format.</returns>
    public static IEnumerable<DateTime> ToDateTime(this IEnumerable<string> strs, string fmt)
    {
        if (strs.AllWhiteSpaceOrNull())
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.ToDateTime(fmt);
        }
    }

    /// <summary>
    /// Converts a collection of string representations of dates and times to their <see cref="DateTime"/> equivalents using the specified format.
    /// Returns an enumerable collection of <see cref="DateTime"/> objects for each successfully converted input string in the specified format, and returns the specified default value for any strings that fail to convert.
    /// </summary>
    /// <param name="strs">The collection of strings to be converted to <see cref="DateTime"/>.</param>
    /// <param name="fmt">The format of the input strings.</param>
    /// <param name="dfltVal">The default value to return for any strings that fail to convert.</param>
    /// <returns>An enumerable collection of <see cref="DateTime"/> objects for each successfully converted input string in the specified format, and the specified default value for any strings that fail to convert.</returns>
    public static IEnumerable<DateTime> ToDateTime(this IEnumerable<string> strs, string fmt, DateTime dfltVal)
    {
        if (strs.AllWhiteSpaceOrNull())
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.ToDateTime(fmt, dfltVal);
        }
    }

    public static IEnumerable<DateTime> GenerateRandomDateTimes<T>(DateTime min, DateTime max, T size) where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return YANLib.YANDateTime.GenerateRandomDateTime(min, max);
        }
    }

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
}
