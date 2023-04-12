using static System.DateTime;

namespace YANLib;

public static partial class YANDateTime
{
    /// <summary>
    /// Parses the string representation of a date and time using <paramref name="fmt"/>.
    /// Returns the parsed <see cref="DateTime"/> value, or <paramref name="dfltVal"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="fmt">The format of the string representation.</param>
    /// <param name="dfltVal">The default value to return if the parsing fails.</param>
    /// <returns>The parsed <see cref="DateTime"/> value, or <paramref name="dfltVal"/> if the parsing fails.</returns>
    public static DateTime ToDateTime(this string str, string fmt, DateTime? dfltVal) => dfltVal.HasValue ? str.ToDateTime(fmt, dfltVal.Value) : default;

    /// <summary>
    /// Converts an enumerable of strings representing date/time values to an <see cref="IEnumerable{DateTime}"/> containing the parsed DateTime values.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only whitespace strings.
    /// </summary>
    /// <param name="strs">The enumerable of strings to convert to DateTime values.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the parsed DateTime values.</returns>
    public static IEnumerable<DateTime> ToDateTime(string fmt, DateTime? dfltVal, params string[] strs)
    {
        if (strs.IsNullOrWhiteSpace())
        {
            yield break;
        }
        for (var i = 0; i < strs.Length; i++)
        {
            yield return strs[i].ToDateTime(fmt, dfltVal);
        }
    }

    /// <summary>
    /// Converts an enumerable of strings representing date/time values to an <see cref="IEnumerable{DateTime}"/> containing the parsed DateTime values.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only whitespace strings.
    /// </summary>
    /// <param name="strs">The enumerable of strings to convert to DateTime values.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the parsed DateTime values.</returns>
    public static IEnumerable<DateTime> ToDateTime(IEnumerable<string> strs, string fmt, DateTime? dfltVal)
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
    /// Converts an enumerable of strings representing date/time values to an <see cref="IEnumerable{DateTime}"/> containing the parsed DateTime values.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only whitespace strings.
    /// </summary>
    /// <param name="strs">The enumerable of strings to convert to DateTime values.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the parsed DateTime values.</returns>
    public static IEnumerable<DateTime> ToDateTime(IReadOnlyCollection<string> strs, string fmt, DateTime? dfltVal)
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
    /// Converts an enumerable of strings representing date/time values to an <see cref="IEnumerable{DateTime}"/> containing the parsed DateTime values.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only whitespace strings.
    /// </summary>
    /// <param name="strs">The enumerable of strings to convert to DateTime values.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the parsed DateTime values.</returns>
    public static IEnumerable<DateTime> ToDateTime(IReadOnlyList<string> strs, string fmt, DateTime? dfltVal)
    {
        if (strs.IsNullOrWhiteSpace())
        {
            yield break;
        }
        for (var i = 0; i < strs.Count; i++)
        {
            yield return strs[i].ToDateTime(fmt, dfltVal);
        }
    }

    /// <summary>
    /// Converts an enumerable of strings representing date/time values to an <see cref="IEnumerable{DateTime}"/> containing the parsed DateTime values.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only whitespace strings.
    /// </summary>
    /// <param name="strs">The enumerable of strings to convert to DateTime values.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the parsed DateTime values.</returns>
    public static IEnumerable<DateTime> ToDateTime(IReadOnlySet<string> strs, string fmt, DateTime? dfltVal)
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
    public static DateTime GenerateRandomDateTime(DateTime? min, DateTime max) => min.HasValue ? GenerateRandomDateTime(min.Value, max) : default;

    /// <summary>
    /// Generates an <see cref="IEnumerable{DateTime}"/> containing random DateTime values between <paramref name="min"/> and <paramref name="max"/>.
    /// The number of DateTime values generated is determined by the value of <paramref name="size"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, an empty sequence is returned.
    /// </summary>
    /// <typeparam name="T">The type of <paramref name="size"/>. Must be a value type.</typeparam>
    /// <param name="min">The minimum DateTime value.</param>
    /// <param name="max">The maximum DateTime value.</param>
    /// <param name="size">The number of DateTime values to generate.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing random DateTime values between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static IEnumerable<DateTime> GenerateRandomDateTimes<T>(DateTime? min, DateTime max, T size) where T : struct
    {
        var cnt = size.ToUlong();
        for (var i = 0ul; i < cnt; i++)
        {
            yield return GenerateRandomDateTime(min, max);
        }
    }

    /// <summary>
    /// Generates a random <see cref="DateTime"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, <see langword="default"/> is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="DateTime"/> value.</param>
    /// <param name="max">The maximum <see cref="DateTime"/> value.</param>
    /// <returns>A random <see cref="DateTime"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static DateTime GenerateRandomDateTime(DateTime min, DateTime? max) => max.HasValue ? GenerateRandomDateTime(min, max.Value) : default;

    /// <summary>
    /// Generates an <see cref="IEnumerable{DateTime}"/> containing random DateTime values between <paramref name="min"/> and <paramref name="max"/>.
    /// The number of DateTime values generated is determined by the value of <paramref name="size"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, an empty sequence is returned.
    /// </summary>
    /// <typeparam name="T">The type of <paramref name="size"/>. Must be a value type.</typeparam>
    /// <param name="min">The minimum DateTime value.</param>
    /// <param name="max">The maximum DateTime value.</param>
    /// <param name="size">The number of DateTime values to generate.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing random DateTime values between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static IEnumerable<DateTime> GenerateRandomDateTimes<T>(DateTime min, DateTime? max, T size) where T : struct
    {
        var cnt = size.ToUlong();
        for (var i = 0ul; i < cnt; i++)
        {
            yield return GenerateRandomDateTime(min, max);
        }
    }

    /// <summary>
    /// Generates a random <see cref="DateTime"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, <see langword="default"/> is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="DateTime"/> value.</param>
    /// <param name="max">The maximum <see cref="DateTime"/> value.</param>
    /// <returns>A random <see cref="DateTime"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static DateTime GenerateRandomDateTime(DateTime? min, DateTime? max) => min.HasValue ? GenerateRandomDateTime(min.Value, max) : GenerateRandomDateTime(max);

    /// <summary>
    /// Generates an <see cref="IEnumerable{DateTime}"/> containing random DateTime values between <paramref name="min"/> and <paramref name="max"/>.
    /// The number of DateTime values generated is determined by the value of <paramref name="size"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, an empty sequence is returned.
    /// </summary>
    /// <typeparam name="T">The type of <paramref name="size"/>. Must be a value type.</typeparam>
    /// <param name="min">The minimum DateTime value.</param>
    /// <param name="max">The maximum DateTime value.</param>
    /// <param name="size">The number of DateTime values to generate.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing random DateTime values between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static IEnumerable<DateTime> GenerateRandomDateTimes<T>(DateTime? min, DateTime? max, T size) where T : struct
    {
        var cnt = size.ToUlong();
        for (var i = 0ul; i < cnt; i++)
        {
            yield return GenerateRandomDateTime(min, max);
        }
    }

    /// <summary>
    /// Generates a random <see cref="DateTime"/> value between <see cref="MinValue"/> and <paramref name="max"/>.
    /// </summary>
    /// <param name="max">The maximum <see cref="DateTime"/> value.</param>
    /// <returns>A random <see cref="DateTime"/> value between <see cref="MinValue"/> and <paramref name="max"/>.</returns>
    public static DateTime GenerateRandomDateTime(DateTime? max) => max.HasValue ? GenerateRandomDateTime(max.Value) : default;

    /// <summary>
    /// Generates an <see cref="IEnumerable{DateTime}"/> containing random DateTime values between <see cref="DateTime.MinValue"/> and <paramref name="max"/>.
    /// The maximum DateTime value to generate is determined by the value of <paramref name="max"/>.
    /// The number of DateTime values generated is determined by the value of <paramref name="size"/>.
    /// </summary>
    /// <typeparam name="T">The type of <paramref name="size"/>. Must be a value type.</typeparam>
    /// <param name="max">The maximum DateTime value to generate.</param>
    /// <param name="size">The number of DateTime values to generate.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing random DateTime values between <see cref="DateTime.MinValue"/> and <paramref name="max"/>.</returns>
    public static IEnumerable<DateTime> GenerateRandomDateTimes<T>(DateTime? max, T size) where T : struct
    {
        var cnt = size.ToUlong();
        for (var i = 0ul; i < cnt; i++)
        {
            yield return GenerateRandomDateTime(max);
        }
    }

    /// <summary>
    /// Returns the week of the year that the specified <see cref="DateTime"/> value falls in, according to the current culture's calendar, week rule, and first day of the week settings.
    /// </summary>
    /// <param name="dt">The <see cref="DateTime"/> value.</param>
    /// <returns>The week of the year that the specified <see cref="DateTime"/> value falls in.</returns>
    public static int GetWeekOfYear(this DateTime? dt) => dt.HasValue ? dt.Value.GetWeekOfYear() : default;

    /// <summary>
    /// Returns an <see cref="IEnumerable{int}"/> containing the week of the year for each specified <see cref="DateTime"/> value.
    /// The week of the year is calculated according to the ISO-8601 standard, where the first week of the year is the week that contains the first Thursday of the year.
    /// If any of the input <see cref="DateTime"/> values is <see langword="null"/>, no value will be returned for that input.
    /// </summary>
    /// <param name="dts">The <see cref="DateTime"/> values to get the week of the year for.</param>
    /// <returns>An <see cref="IEnumerable{int}"/> containing the week of the year for each specified <see cref="DateTime"/> value.</returns>
    public static IEnumerable<int> GetWeekOfYear(params DateTime?[] dts)
    {
        if (dts is null || dts.Length > 0)
        {
            yield break;
        }
        for (var i = 0; i < dts.Length; i++)
        {
            yield return dts[i].GetWeekOfYear();
        }
    }

    /// <summary>
    /// Returns an <see cref="IEnumerable{int}"/> containing the week of the year for each specified <see cref="DateTime"/> value.
    /// The week of the year is calculated according to the ISO-8601 standard, where the first week of the year is the week that contains the first Thursday of the year.
    /// If any of the input <see cref="DateTime"/> values is <see langword="null"/>, no value will be returned for that input.
    /// </summary>
    /// <param name="dts">The <see cref="DateTime"/> values to get the week of the year for.</param>
    /// <returns>An <see cref="IEnumerable{int}"/> containing the week of the year for each specified <see cref="DateTime"/> value.</returns>
    public static IEnumerable<int> GetWeekOfYear(this IEnumerable<DateTime?> dts)
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
    /// Returns an <see cref="IEnumerable{int}"/> containing the week of the year for each specified <see cref="DateTime"/> value.
    /// The week of the year is calculated according to the ISO-8601 standard, where the first week of the year is the week that contains the first Thursday of the year.
    /// If any of the input <see cref="DateTime"/> values is <see langword="null"/>, no value will be returned for that input.
    /// </summary>
    /// <param name="dts">The <see cref="DateTime"/> values to get the week of the year for.</param>
    /// <returns>An <see cref="IEnumerable{int}"/> containing the week of the year for each specified <see cref="DateTime"/> value.</returns>
    public static IEnumerable<int> GetWeekOfYear(this IReadOnlyCollection<DateTime?> dts)
    {
        if (dts is null || dts.Count > 0)
        {
            yield break;
        }
        foreach (var dt in dts)
        {
            yield return dt.GetWeekOfYear();
        }
    }

    /// <summary>
    /// Returns an <see cref="IEnumerable{int}"/> containing the week of the year for each specified <see cref="DateTime"/> value.
    /// The week of the year is calculated according to the ISO-8601 standard, where the first week of the year is the week that contains the first Thursday of the year.
    /// If any of the input <see cref="DateTime"/> values is <see langword="null"/>, no value will be returned for that input.
    /// </summary>
    /// <param name="dts">The <see cref="DateTime"/> values to get the week of the year for.</param>
    /// <returns>An <see cref="IEnumerable{int}"/> containing the week of the year for each specified <see cref="DateTime"/> value.</returns>
    public static IEnumerable<int> GetWeekOfYear(this IReadOnlyList<DateTime?> dts)
    {
        if (dts is null || dts.Count > 0)
        {
            yield break;
        }
        for (var i = 0; i < dts.Count; i++)
        {
            yield return dts[i].GetWeekOfYear();
        }
    }

    /// <summary>
    /// Returns an <see cref="IEnumerable{int}"/> containing the week of the year for each specified <see cref="DateTime"/> value.
    /// The week of the year is calculated according to the ISO-8601 standard, where the first week of the year is the week that contains the first Thursday of the year.
    /// If any of the input <see cref="DateTime"/> values is <see langword="null"/>, no value will be returned for that input.
    /// </summary>
    /// <param name="dts">The <see cref="DateTime"/> values to get the week of the year for.</param>
    /// <returns>An <see cref="IEnumerable{int}"/> containing the week of the year for each specified <see cref="DateTime"/> value.</returns>
    public static IEnumerable<int> GetWeekOfYear(this IReadOnlySet<DateTime?> dts)
    {
        if (dts is null || dts.Count > 0)
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
    public static int TotalMonths(DateTime? dt1, DateTime dt2) => dt1.HasValue ? TotalMonths(dt1.Value, dt2) : default;

    /// <summary>
    /// Returns the total number of months between the two specified <see cref="DateTime"/> values, ignoring the day of the month.
    /// </summary>
    /// <param name="dt1">The first <see cref="DateTime"/> value.</param>
    /// <param name="dt2">The second <see cref="DateTime"/> value.</param>
    /// <returns>The total number of months between the two specified <see cref="DateTime"/> values, ignoring the day of the month.</returns>
    public static int TotalMonths(DateTime dt1, DateTime? dt2) => dt2.HasValue ? TotalMonths(dt1, dt2.Value) : default;

    /// <summary>
    /// Returns the total number of months between the two specified <see cref="DateTime"/> values, ignoring the day of the month.
    /// </summary>
    /// <param name="dt1">The first <see cref="DateTime"/> value.</param>
    /// <param name="dt2">The second <see cref="DateTime"/> value.</param>
    /// <returns>The total number of months between the two specified <see cref="DateTime"/> values, ignoring the day of the month.</returns>
    public static int TotalMonths(DateTime? dt1, DateTime? dt2) => dt1.HasValue ? TotalMonths(dt1.Value, dt2) : default;

    /// <summary>
    /// Returns a new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone.
    /// </summary>
    /// <typeparam name="T1">The type of the original time zone offset, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone offset, which must be a value type.</typeparam>
    /// <param name="dt">The original <see cref="DateTime"/> value.</param>
    /// <param name="tzSrc">The time zone offset of the original <see cref="DateTime"/> value, in hours.</param>
    /// <param name="tzDst">The time zone offset to convert the original <see cref="DateTime"/> value to, in hours.</param>
    /// <returns>A new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone.</returns>
    public static DateTime ChangeTimeZone<T1, T2>(this DateTime? dt, T1 tzSrc, T2 tzDst) where T1 : struct where T2 : struct => dt.HasValue ? dt.Value.ChangeTimeZone(tzSrc, tzDst) : default;

    /// <summary>
    /// Returns an <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to a different time zone, based on the source and destination time zones specified.
    /// The source and destination time zones are specified as generic type parameters <typeparamref name="T1"/> and <typeparamref name="T2"/> respectively, and must be of a struct type that represents a valid time zone identifier.
    /// If any of the input <see cref="DateTime"/> values is <see langword="null"/>, no value will be returned for that input.
    /// </summary>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="dts">The <see cref="DateTime"/> values to convert to the destination time zone.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to the destination time zone.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T1, T2>(T1 tzSrc, T2 tzDst, params DateTime?[] dts) where T1 : struct where T2 : struct
    {
        if (dts is null || dts.Length <= 0)
        {
            yield break;
        }
        for (var i = 0; i < dts.Length; i++)
        {
            yield return dts[i].ChangeTimeZone(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Returns an <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to a different time zone, based on the source and destination time zones specified.
    /// The source and destination time zones are specified as generic type parameters <typeparamref name="T1"/> and <typeparamref name="T2"/> respectively, and must be of a struct type that represents a valid time zone identifier.
    /// If any of the input <see cref="DateTime"/> values is <see langword="null"/>, no value will be returned for that input.
    /// </summary>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="dts">The <see cref="DateTime"/> values to convert to the destination time zone.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to the destination time zone.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T1, T2>(this IEnumerable<DateTime?> dts, T1 tzSrc, T2 tzDst) where T1 : struct where T2 : struct
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
    /// Returns an <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to a different time zone, based on the source and destination time zones specified.
    /// The source and destination time zones are specified as generic type parameters <typeparamref name="T1"/> and <typeparamref name="T2"/> respectively, and must be of a struct type that represents a valid time zone identifier.
    /// If any of the input <see cref="DateTime"/> values is <see langword="null"/>, no value will be returned for that input.
    /// </summary>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="dts">The <see cref="DateTime"/> values to convert to the destination time zone.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to the destination time zone.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T1, T2>(this IReadOnlyCollection<DateTime?> dts, T1 tzSrc, T2 tzDst) where T1 : struct where T2 : struct
    {
        if (dts is null || dts.Count <= 0)
        {
            yield break;
        }
        foreach (var dt in dts)
        {
            yield return dt.ChangeTimeZone(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Returns an <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to a different time zone, based on the source and destination time zones specified.
    /// The source and destination time zones are specified as generic type parameters <typeparamref name="T1"/> and <typeparamref name="T2"/> respectively, and must be of a struct type that represents a valid time zone identifier.
    /// If any of the input <see cref="DateTime"/> values is <see langword="null"/>, no value will be returned for that input.
    /// </summary>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="dts">The <see cref="DateTime"/> values to convert to the destination time zone.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to the destination time zone.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T1, T2>(this IReadOnlyList<DateTime?> dts, T1 tzSrc, T2 tzDst) where T1 : struct where T2 : struct
    {
        if (dts is null || dts.Count <= 0)
        {
            yield break;
        }
        for (var i = 0; i < dts.Count; i++)
        {
            yield return dts[i].ChangeTimeZone(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Returns an <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to a different time zone, based on the source and destination time zones specified.
    /// The source and destination time zones are specified as generic type parameters <typeparamref name="T1"/> and <typeparamref name="T2"/> respectively, and must be of a struct type that represents a valid time zone identifier.
    /// If any of the input <see cref="DateTime"/> values is <see langword="null"/>, no value will be returned for that input.
    /// </summary>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="dts">The <see cref="DateTime"/> values to convert to the destination time zone.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to the destination time zone.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T1, T2>(this IReadOnlySet<DateTime?> dts, T1 tzSrc, T2 tzDst) where T1 : struct where T2 : struct
    {
        if (dts is null || dts.Count <= 0)
        {
            yield break;
        }
        foreach (var dt in dts)
        {
            yield return dt.ChangeTimeZone(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Returns a new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone.
    /// </summary>
    /// <typeparam name="T1">The type of the original time zone offset, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone offset, which must be a value type.</typeparam>
    /// <param name="dt">The original <see cref="DateTime"/> value.</param>
    /// <param name="tzSrc">The time zone offset of the original <see cref="DateTime"/> value, in hours.</param>
    /// <param name="tzDst">The time zone offset to convert the original <see cref="DateTime"/> value to, in hours.</param>
    /// <returns>A new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone.</returns>
    public static DateTime ChangeTimeZone<T1, T2>(this DateTime dt, T1? tzSrc, T2 tzDst) where T1 : struct where T2 : struct => tzSrc.HasValue ? dt.ChangeTimeZone(tzSrc.Value, tzDst) : dt.ChangeTimeZone(tzDst);

    /// <summary>
    /// Returns an <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to a different time zone, based on the source and destination time zones specified.
    /// The source and destination time zones are specified as generic type parameters <typeparamref name="T1"/> and <typeparamref name="T2"/> respectively, and must be of a struct type that represents a valid time zone identifier.
    /// If any of the input <see cref="DateTime"/> values is <see langword="null"/>, no value will be returned for that input.
    /// </summary>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="dts">The <see cref="DateTime"/> values to convert to the destination time zone.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to the destination time zone.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T1, T2>(T1? tzSrc, T2 tzDst, params DateTime[] dts) where T1 : struct where T2 : struct
    {
        if (dts is null || dts.Length <= 0)
        {
            yield break;
        }
        for (var i = 0; i < dts.Length; i++)
        {
            yield return dts[i].ChangeTimeZone(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Returns an <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to a different time zone, based on the source and destination time zones specified.
    /// The source and destination time zones are specified as generic type parameters <typeparamref name="T1"/> and <typeparamref name="T2"/> respectively, and must be of a struct type that represents a valid time zone identifier.
    /// If any of the input <see cref="DateTime"/> values is <see langword="null"/>, no value will be returned for that input.
    /// </summary>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="dts">The <see cref="DateTime"/> values to convert to the destination time zone.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to the destination time zone.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T1, T2>(this IEnumerable<DateTime> dts, T1? tzSrc, T2 tzDst) where T1 : struct where T2 : struct
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
    /// Returns an <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to a different time zone, based on the source and destination time zones specified.
    /// The source and destination time zones are specified as generic type parameters <typeparamref name="T1"/> and <typeparamref name="T2"/> respectively, and must be of a struct type that represents a valid time zone identifier.
    /// If any of the input <see cref="DateTime"/> values is <see langword="null"/>, no value will be returned for that input.
    /// </summary>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="dts">The <see cref="DateTime"/> values to convert to the destination time zone.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to the destination time zone.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T1, T2>(this IReadOnlyCollection<DateTime> dts, T1? tzSrc, T2 tzDst) where T1 : struct where T2 : struct
    {
        if (dts is null || dts.Count <= 0)
        {
            yield break;
        }
        foreach (var dt in dts)
        {
            yield return dt.ChangeTimeZone(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Returns an <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to a different time zone, based on the source and destination time zones specified.
    /// The source and destination time zones are specified as generic type parameters <typeparamref name="T1"/> and <typeparamref name="T2"/> respectively, and must be of a struct type that represents a valid time zone identifier.
    /// If any of the input <see cref="DateTime"/> values is <see langword="null"/>, no value will be returned for that input.
    /// </summary>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="dts">The <see cref="DateTime"/> values to convert to the destination time zone.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to the destination time zone.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T1, T2>(this IReadOnlyList<DateTime> dts, T1? tzSrc, T2 tzDst) where T1 : struct where T2 : struct
    {
        if (dts is null || dts.Count <= 0)
        {
            yield break;
        }
        for (var i = 0; i < dts.Count; i++)
        {
            yield return dts[i].ChangeTimeZone(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Returns an <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to a different time zone, based on the source and destination time zones specified.
    /// The source and destination time zones are specified as generic type parameters <typeparamref name="T1"/> and <typeparamref name="T2"/> respectively, and must be of a struct type that represents a valid time zone identifier.
    /// If any of the input <see cref="DateTime"/> values is <see langword="null"/>, no value will be returned for that input.
    /// </summary>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="dts">The <see cref="DateTime"/> values to convert to the destination time zone.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to the destination time zone.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T1, T2>(this IReadOnlySet<DateTime> dts, T1? tzSrc, T2 tzDst) where T1 : struct where T2 : struct
    {
        if (dts is null || dts.Count <= 0)
        {
            yield break;
        }
        foreach (var dt in dts)
        {
            yield return dt.ChangeTimeZone(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Returns a new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone.
    /// </summary>
    /// <typeparam name="T1">The type of the original time zone offset, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone offset, which must be a value type.</typeparam>
    /// <param name="dt">The original <see cref="DateTime"/> value.</param>
    /// <param name="tzSrc">The time zone offset of the original <see cref="DateTime"/> value, in hours.</param>
    /// <param name="tzDst">The time zone offset to convert the original <see cref="DateTime"/> value to, in hours.</param>
    /// <returns>A new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone.</returns>
    public static DateTime ChangeTimeZone<T1, T2>(this DateTime dt, T1 tzSrc, T2? tzDst) where T1 : struct where T2 : struct => tzDst.HasValue ? dt.ChangeTimeZone(tzSrc, tzDst.Value) : dt;

    public static IEnumerable<DateTime> ChangeTimeZone<T1, T2>(T1 tzSrc, T2? tzDst, params DateTime[] dts) where T1 : struct where T2 : struct
    {
        if (dts is null || dts.Length <= 0)
        {
            yield break;
        }
        for (var i = 0; i < dts.Length; i++)
        {
            yield return dts[i].ChangeTimeZone(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Returns an <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to a different time zone, based on the source and destination time zones specified.
    /// The source and destination time zones are specified as generic type parameters <typeparamref name="T1"/> and <typeparamref name="T2"/> respectively, and must be of a struct type that represents a valid time zone identifier.
    /// If any of the input <see cref="DateTime"/> values is <see langword="null"/>, no value will be returned for that input.
    /// </summary>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="dts">The <see cref="DateTime"/> values to convert to the destination time zone.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to the destination time zone.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T1, T2>(this IEnumerable<DateTime> dts, T1 tzSrc, T2? tzDst) where T1 : struct where T2 : struct
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
    /// Returns an <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to a different time zone, based on the source and destination time zones specified.
    /// The source and destination time zones are specified as generic type parameters <typeparamref name="T1"/> and <typeparamref name="T2"/> respectively, and must be of a struct type that represents a valid time zone identifier.
    /// If any of the input <see cref="DateTime"/> values is <see langword="null"/>, no value will be returned for that input.
    /// </summary>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="dts">The <see cref="DateTime"/> values to convert to the destination time zone.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to the destination time zone.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T1, T2>(this IReadOnlyCollection<DateTime> dts, T1 tzSrc, T2? tzDst) where T1 : struct where T2 : struct
    {
        if (dts is null || dts.Count <= 0)
        {
            yield break;
        }
        foreach (var dt in dts)
        {
            yield return dt.ChangeTimeZone(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Returns an <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to a different time zone, based on the source and destination time zones specified.
    /// The source and destination time zones are specified as generic type parameters <typeparamref name="T1"/> and <typeparamref name="T2"/> respectively, and must be of a struct type that represents a valid time zone identifier.
    /// If any of the input <see cref="DateTime"/> values is <see langword="null"/>, no value will be returned for that input.
    /// </summary>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="dts">The <see cref="DateTime"/> values to convert to the destination time zone.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to the destination time zone.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T1, T2>(this IReadOnlyList<DateTime> dts, T1 tzSrc, T2? tzDst) where T1 : struct where T2 : struct
    {
        if (dts is null || dts.Count <= 0)
        {
            yield break;
        }
        for (var i = 0; i < dts.Count; i++)
        {
            yield return dts[i].ChangeTimeZone(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Returns an <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to a different time zone, based on the source and destination time zones specified.
    /// The source and destination time zones are specified as generic type parameters <typeparamref name="T1"/> and <typeparamref name="T2"/> respectively, and must be of a struct type that represents a valid time zone identifier.
    /// If any of the input <see cref="DateTime"/> values is <see langword="null"/>, no value will be returned for that input.
    /// </summary>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="dts">The <see cref="DateTime"/> values to convert to the destination time zone.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to the destination time zone.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T1, T2>(this IReadOnlySet<DateTime> dts, T1 tzSrc, T2? tzDst) where T1 : struct where T2 : struct
    {
        if (dts is null || dts.Count <= 0)
        {
            yield break;
        }
        foreach (var dt in dts)
        {
            yield return dt.ChangeTimeZone(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Returns a new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone.
    /// </summary>
    /// <typeparam name="T1">The type of the original time zone offset, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone offset, which must be a value type.</typeparam>
    /// <param name="dt">The original <see cref="DateTime"/> value.</param>
    /// <param name="tzSrc">The time zone offset of the original <see cref="DateTime"/> value, in hours.</param>
    /// <param name="tzDst">The time zone offset to convert the original <see cref="DateTime"/> value to, in hours.</param>
    /// <returns>A new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone.</returns>
    public static DateTime ChangeTimeZone<T1, T2>(this DateTime? dt, T1? tzSrc, T2 tzDst) where T1 : struct where T2 : struct => dt.HasValue ? dt.Value.ChangeTimeZone(tzSrc, tzDst) : default;

    /// <summary>
    /// Returns an <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to a different time zone, based on the source and destination time zones specified.
    /// The source and destination time zones are specified as generic type parameters <typeparamref name="T1"/> and <typeparamref name="T2"/> respectively, and must be of a struct type that represents a valid time zone identifier.
    /// If any of the input <see cref="DateTime"/> values is <see langword="null"/>, no value will be returned for that input.
    /// </summary>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="dts">The <see cref="DateTime"/> values to convert to the destination time zone.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to the destination time zone.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T1, T2>(T1? tzSrc, T2 tzDst, params DateTime?[] dts) where T1 : struct where T2 : struct
    {
        if (dts is null || dts.Length <= 0)
        {
            yield break;
        }
        for (var i = 0; i < dts.Length; i++)
        {
            yield return dts[i].ChangeTimeZone(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Returns an <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to a different time zone, based on the source and destination time zones specified.
    /// The source and destination time zones are specified as generic type parameters <typeparamref name="T1"/> and <typeparamref name="T2"/> respectively, and must be of a struct type that represents a valid time zone identifier.
    /// If any of the input <see cref="DateTime"/> values is <see langword="null"/>, no value will be returned for that input.
    /// </summary>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="dts">The <see cref="DateTime"/> values to convert to the destination time zone.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to the destination time zone.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T1, T2>(this IEnumerable<DateTime?> dts, T1? tzSrc, T2 tzDst) where T1 : struct where T2 : struct
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
    /// Returns an <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to a different time zone, based on the source and destination time zones specified.
    /// The source and destination time zones are specified as generic type parameters <typeparamref name="T1"/> and <typeparamref name="T2"/> respectively, and must be of a struct type that represents a valid time zone identifier.
    /// If any of the input <see cref="DateTime"/> values is <see langword="null"/>, no value will be returned for that input.
    /// </summary>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="dts">The <see cref="DateTime"/> values to convert to the destination time zone.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to the destination time zone.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T1, T2>(this IReadOnlyCollection<DateTime?> dts, T1? tzSrc, T2 tzDst) where T1 : struct where T2 : struct
    {
        if (dts is null || dts.Count <= 0)
        {
            yield break;
        }
        foreach (var dt in dts)
        {
            yield return dt.ChangeTimeZone(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Returns an <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to a different time zone, based on the source and destination time zones specified.
    /// The source and destination time zones are specified as generic type parameters <typeparamref name="T1"/> and <typeparamref name="T2"/> respectively, and must be of a struct type that represents a valid time zone identifier.
    /// If any of the input <see cref="DateTime"/> values is <see langword="null"/>, no value will be returned for that input.
    /// </summary>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="dts">The <see cref="DateTime"/> values to convert to the destination time zone.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to the destination time zone.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T1, T2>(this IReadOnlyList<DateTime?> dts, T1? tzSrc, T2 tzDst) where T1 : struct where T2 : struct
    {
        if (dts is null || dts.Count <= 0)
        {
            yield break;
        }
        for (var i = 0; i < dts.Count; i++)
        {
            yield return dts[i].ChangeTimeZone(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Returns an <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to a different time zone, based on the source and destination time zones specified.
    /// The source and destination time zones are specified as generic type parameters <typeparamref name="T1"/> and <typeparamref name="T2"/> respectively, and must be of a struct type that represents a valid time zone identifier.
    /// If any of the input <see cref="DateTime"/> values is <see langword="null"/>, no value will be returned for that input.
    /// </summary>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="dts">The <see cref="DateTime"/> values to convert to the destination time zone.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to the destination time zone.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T1, T2>(this IReadOnlySet<DateTime?> dts, T1? tzSrc, T2 tzDst) where T1 : struct where T2 : struct
    {
        if (dts is null || dts.Count <= 0)
        {
            yield break;
        }
        foreach (var dt in dts)
        {
            yield return dt.ChangeTimeZone(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Returns a new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone.
    /// </summary>
    /// <typeparam name="T1">The type of the original time zone offset, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone offset, which must be a value type.</typeparam>
    /// <param name="dt">The original <see cref="DateTime"/> value.</param>
    /// <param name="tzSrc">The time zone offset of the original <see cref="DateTime"/> value, in hours.</param>
    /// <param name="tzDst">The time zone offset to convert the original <see cref="DateTime"/> value to, in hours.</param>
    /// <returns>A new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone.</returns>
    public static DateTime ChangeTimeZone<T1, T2>(this DateTime? dt, T1 tzSrc, T2? tzDst) where T1 : struct where T2 : struct => dt.HasValue ? dt.Value.ChangeTimeZone(tzSrc, tzDst) : default;

    /// <summary>
    /// Returns an <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to a different time zone, based on the source and destination time zones specified.
    /// The source and destination time zones are specified as generic type parameters <typeparamref name="T1"/> and <typeparamref name="T2"/> respectively, and must be of a struct type that represents a valid time zone identifier.
    /// If any of the input <see cref="DateTime"/> values is <see langword="null"/>, no value will be returned for that input.
    /// </summary>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="dts">The <see cref="DateTime"/> values to convert to the destination time zone.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to the destination time zone.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T1, T2>(T1 tzSrc, T2? tzDst, params DateTime?[] dts) where T1 : struct where T2 : struct
    {
        if (dts is null || dts.Length <= 0)
        {
            yield break;
        }
        for (var i = 0; i < dts.Length; i++)
        {
            yield return dts[i].ChangeTimeZone(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Returns an <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to a different time zone, based on the source and destination time zones specified.
    /// The source and destination time zones are specified as generic type parameters <typeparamref name="T1"/> and <typeparamref name="T2"/> respectively, and must be of a struct type that represents a valid time zone identifier.
    /// If any of the input <see cref="DateTime"/> values is <see langword="null"/>, no value will be returned for that input.
    /// </summary>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="dts">The <see cref="DateTime"/> values to convert to the destination time zone.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to the destination time zone.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T1, T2>(this IEnumerable<DateTime?> dts, T1 tzSrc, T2? tzDst) where T1 : struct where T2 : struct
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
    /// Returns an <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to a different time zone, based on the source and destination time zones specified.
    /// The source and destination time zones are specified as generic type parameters <typeparamref name="T1"/> and <typeparamref name="T2"/> respectively, and must be of a struct type that represents a valid time zone identifier.
    /// If any of the input <see cref="DateTime"/> values is <see langword="null"/>, no value will be returned for that input.
    /// </summary>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="dts">The <see cref="DateTime"/> values to convert to the destination time zone.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to the destination time zone.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T1, T2>(this IReadOnlyCollection<DateTime?> dts, T1 tzSrc, T2? tzDst) where T1 : struct where T2 : struct
    {
        if (dts is null || dts.Count <= 0)
        {
            yield break;
        }
        foreach (var dt in dts)
        {
            yield return dt.ChangeTimeZone(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Returns an <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to a different time zone, based on the source and destination time zones specified.
    /// The source and destination time zones are specified as generic type parameters <typeparamref name="T1"/> and <typeparamref name="T2"/> respectively, and must be of a struct type that represents a valid time zone identifier.
    /// If any of the input <see cref="DateTime"/> values is <see langword="null"/>, no value will be returned for that input.
    /// </summary>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="dts">The <see cref="DateTime"/> values to convert to the destination time zone.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to the destination time zone.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T1, T2>(this IReadOnlyList<DateTime?> dts, T1 tzSrc, T2? tzDst) where T1 : struct where T2 : struct
    {
        if (dts is null || dts.Count <= 0)
        {
            yield break;
        }
        for (var i = 0; i < dts.Count; i++)
        {
            yield return dts[i].ChangeTimeZone(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Returns an <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to a different time zone, based on the source and destination time zones specified.
    /// The source and destination time zones are specified as generic type parameters <typeparamref name="T1"/> and <typeparamref name="T2"/> respectively, and must be of a struct type that represents a valid time zone identifier.
    /// If any of the input <see cref="DateTime"/> values is <see langword="null"/>, no value will be returned for that input.
    /// </summary>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="dts">The <see cref="DateTime"/> values to convert to the destination time zone.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to the destination time zone.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T1, T2>(this IReadOnlySet<DateTime?> dts, T1 tzSrc, T2? tzDst) where T1 : struct where T2 : struct
    {
        if (dts is null || dts.Count <= 0)
        {
            yield break;
        }
        foreach (var dt in dts)
        {
            yield return dt.ChangeTimeZone(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Returns a new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone.
    /// </summary>
    /// <typeparam name="T1">The type of the original time zone offset, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone offset, which must be a value type.</typeparam>
    /// <param name="dt">The original <see cref="DateTime"/> value.</param>
    /// <param name="tzSrc">The time zone offset of the original <see cref="DateTime"/> value, in hours.</param>
    /// <param name="tzDst">The time zone offset to convert the original <see cref="DateTime"/> value to, in hours.</param>
    /// <returns>A new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone.</returns>
    public static DateTime ChangeTimeZone<T1, T2>(this DateTime dt, T1? tzSrc, T2? tzDst) where T1 : struct where T2 : struct => tzSrc.HasValue ? dt.ChangeTimeZone(tzSrc.Value, tzDst) : dt.ChangeTimeZone(tzDst);

    /// <summary>
    /// Returns an <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to a different time zone, based on the source and destination time zones specified.
    /// The source and destination time zones are specified as generic type parameters <typeparamref name="T1"/> and <typeparamref name="T2"/> respectively, and must be of a struct type that represents a valid time zone identifier.
    /// If any of the input <see cref="DateTime"/> values is <see langword="null"/>, no value will be returned for that input.
    /// </summary>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="dts">The <see cref="DateTime"/> values to convert to the destination time zone.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to the destination time zone.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T1, T2>(T1? tzSrc, T2? tzDst, params DateTime[] dts) where T1 : struct where T2 : struct
    {
        if (dts is null || dts.Length <= 0)
        {
            yield break;
        }
        for (var i = 0; i < dts.Length; i++)
        {
            yield return dts[i].ChangeTimeZone(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Returns an <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to a different time zone, based on the source and destination time zones specified.
    /// The source and destination time zones are specified as generic type parameters <typeparamref name="T1"/> and <typeparamref name="T2"/> respectively, and must be of a struct type that represents a valid time zone identifier.
    /// If any of the input <see cref="DateTime"/> values is <see langword="null"/>, no value will be returned for that input.
    /// </summary>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="dts">The <see cref="DateTime"/> values to convert to the destination time zone.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to the destination time zone.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T1, T2>(this IEnumerable<DateTime> dts, T1? tzSrc, T2? tzDst) where T1 : struct where T2 : struct
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
    /// Returns an <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to a different time zone, based on the source and destination time zones specified.
    /// The source and destination time zones are specified as generic type parameters <typeparamref name="T1"/> and <typeparamref name="T2"/> respectively, and must be of a struct type that represents a valid time zone identifier.
    /// If any of the input <see cref="DateTime"/> values is <see langword="null"/>, no value will be returned for that input.
    /// </summary>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="dts">The <see cref="DateTime"/> values to convert to the destination time zone.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to the destination time zone.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T1, T2>(this IReadOnlyCollection<DateTime> dts, T1? tzSrc, T2? tzDst) where T1 : struct where T2 : struct
    {
        if (dts is null || dts.Count <= 0)
        {
            yield break;
        }
        foreach (var dt in dts)
        {
            yield return dt.ChangeTimeZone(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Returns an <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to a different time zone, based on the source and destination time zones specified.
    /// The source and destination time zones are specified as generic type parameters <typeparamref name="T1"/> and <typeparamref name="T2"/> respectively, and must be of a struct type that represents a valid time zone identifier.
    /// If any of the input <see cref="DateTime"/> values is <see langword="null"/>, no value will be returned for that input.
    /// </summary>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="dts">The <see cref="DateTime"/> values to convert to the destination time zone.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to the destination time zone.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T1, T2>(this IReadOnlyList<DateTime> dts, T1? tzSrc, T2? tzDst) where T1 : struct where T2 : struct
    {
        if (dts is null || dts.Count <= 0)
        {
            yield break;
        }
        for (var i = 0; i < dts.Count; i++)
        {
            yield return dts[i].ChangeTimeZone(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Returns an <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to a different time zone, based on the source and destination time zones specified.
    /// The source and destination time zones are specified as generic type parameters <typeparamref name="T1"/> and <typeparamref name="T2"/> respectively, and must be of a struct type that represents a valid time zone identifier.
    /// If any of the input <see cref="DateTime"/> values is <see langword="null"/>, no value will be returned for that input.
    /// </summary>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="dts">The <see cref="DateTime"/> values to convert to the destination time zone.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to the destination time zone.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T1, T2>(this IReadOnlySet<DateTime> dts, T1? tzSrc, T2? tzDst) where T1 : struct where T2 : struct
    {
        if (dts is null || dts.Count <= 0)
        {
            yield break;
        }
        foreach (var dt in dts)
        {
            yield return dt.ChangeTimeZone(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Returns a new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone.
    /// </summary>
    /// <typeparam name="T1">The type of the original time zone offset, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone offset, which must be a value type.</typeparam>
    /// <param name="dt">The original <see cref="DateTime"/> value.</param>
    /// <param name="tzSrc">The time zone offset of the original <see cref="DateTime"/> value, in hours.</param>
    /// <param name="tzDst">The time zone offset to convert the original <see cref="DateTime"/> value to, in hours.</param>
    /// <returns>A new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone.</returns>
    public static DateTime ChangeTimeZone<T1, T2>(this DateTime? dt, T1? tzSrc, T2? tzDst) where T1 : struct where T2 : struct => dt.HasValue ? dt.Value.ChangeTimeZone(tzSrc, tzDst) : default;

    /// <summary>
    /// Returns an <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to a different time zone, based on the source and destination time zones specified.
    /// The source and destination time zones are specified as generic type parameters <typeparamref name="T1"/> and <typeparamref name="T2"/> respectively, and must be of a struct type that represents a valid time zone identifier.
    /// If any of the input <see cref="DateTime"/> values is <see langword="null"/>, no value will be returned for that input.
    /// </summary>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="dts">The <see cref="DateTime"/> values to convert to the destination time zone.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to the destination time zone.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T1, T2>(T1? tzSrc, T2? tzDst, params DateTime?[] dts) where T1 : struct where T2 : struct
    {
        if (dts is null || dts.Length <= 0)
        {
            yield break;
        }
        for (var i = 0; i < dts.Length; i++)
        {
            yield return dts[i].ChangeTimeZone(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Returns an <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to a different time zone, based on the source and destination time zones specified.
    /// The source and destination time zones are specified as generic type parameters <typeparamref name="T1"/> and <typeparamref name="T2"/> respectively, and must be of a struct type that represents a valid time zone identifier.
    /// If any of the input <see cref="DateTime"/> values is <see langword="null"/>, no value will be returned for that input.
    /// </summary>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="dts">The <see cref="DateTime"/> values to convert to the destination time zone.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to the destination time zone.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T1, T2>(this IEnumerable<DateTime?> dts, T1? tzSrc, T2? tzDst) where T1 : struct where T2 : struct
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
    /// Returns an <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to a different time zone, based on the source and destination time zones specified.
    /// The source and destination time zones are specified as generic type parameters <typeparamref name="T1"/> and <typeparamref name="T2"/> respectively, and must be of a struct type that represents a valid time zone identifier.
    /// If any of the input <see cref="DateTime"/> values is <see langword="null"/>, no value will be returned for that input.
    /// </summary>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="dts">The <see cref="DateTime"/> values to convert to the destination time zone.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to the destination time zone.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T1, T2>(this IReadOnlyCollection<DateTime?> dts, T1? tzSrc, T2? tzDst) where T1 : struct where T2 : struct
    {
        if (dts is null || dts.Count <= 0)
        {
            yield break;
        }
        foreach (var dt in dts)
        {
            yield return dt.ChangeTimeZone(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Returns an <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to a different time zone, based on the source and destination time zones specified.
    /// The source and destination time zones are specified as generic type parameters <typeparamref name="T1"/> and <typeparamref name="T2"/> respectively, and must be of a struct type that represents a valid time zone identifier.
    /// If any of the input <see cref="DateTime"/> values is <see langword="null"/>, no value will be returned for that input.
    /// </summary>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="dts">The <see cref="DateTime"/> values to convert to the destination time zone.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to the destination time zone.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T1, T2>(this IReadOnlyList<DateTime?> dts, T1? tzSrc, T2? tzDst) where T1 : struct where T2 : struct
    {
        if (dts is null || dts.Count <= 0)
        {
            yield break;
        }
        for (var i = 0; i < dts.Count; i++)
        {
            yield return dts[i].ChangeTimeZone(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Returns an <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to a different time zone, based on the source and destination time zones specified.
    /// The source and destination time zones are specified as generic type parameters <typeparamref name="T1"/> and <typeparamref name="T2"/> respectively, and must be of a struct type that represents a valid time zone identifier.
    /// If any of the input <see cref="DateTime"/> values is <see langword="null"/>, no value will be returned for that input.
    /// </summary>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="dts">The <see cref="DateTime"/> values to convert to the destination time zone.</param>
    /// <returns>An <see cref="IEnumerable{DateTime}"/> containing the <see cref="DateTime"/> values converted to the destination time zone.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T1, T2>(this IReadOnlySet<DateTime?> dts, T1? tzSrc, T2? tzDst) where T1 : struct where T2 : struct
    {
        if (dts is null || dts.Count <= 0)
        {
            yield break;
        }
        foreach (var dt in dts)
        {
            yield return dt.ChangeTimeZone(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Returns a new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset of 0.
    /// </summary>
    /// <typeparam name="T">The type of the time zone offset to convert the original <see cref="DateTime"/> value to, which must be a value type.</typeparam>
    /// <param name="dt">The original <see cref="DateTime"/> value.</param>
    /// <param name="tzDst">The time zone offset to convert the original <see cref="DateTime"/> value to, in hours.</param>
    /// <returns>A new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset of 0.</returns>
    public static DateTime ChangeTimeZone<T>(this DateTime? dt, T tzDst) where T : struct => dt.ChangeTimeZone(0, tzDst);

    /// <summary>
    /// Returns a new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset of 0.
    /// </summary>
    /// <typeparam name="T">The type of the time zone offset to convert the original <see cref="DateTime"/> value to, which must be a value type.</typeparam>
    /// <param name="dt">The original <see cref="DateTime"/> value.</param>
    /// <param name="tzDst">The time zone offset to convert the original <see cref="DateTime"/> value to, in hours.</param>
    /// <returns>A new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset of 0.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T>(T tzDst, params DateTime?[] dts) where T : struct
    {
        if (dts is null || dts.Length <= 0)
        {
            yield break;
        }
        for (var i = 0; i < dts.Length; i++)
        {
            yield return dts[i].ChangeTimeZone(tzDst);
        }
    }

    /// <summary>
    /// Returns a new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset of 0.
    /// </summary>
    /// <typeparam name="T">The type of the time zone offset to convert the original <see cref="DateTime"/> value to, which must be a value type.</typeparam>
    /// <param name="dt">The original <see cref="DateTime"/> value.</param>
    /// <param name="tzDst">The time zone offset to convert the original <see cref="DateTime"/> value to, in hours.</param>
    /// <returns>A new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset of 0.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T>(this IEnumerable<DateTime?> dts, T tzDst) where T : struct
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
    /// Returns a new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset of 0.
    /// </summary>
    /// <typeparam name="T">The type of the time zone offset to convert the original <see cref="DateTime"/> value to, which must be a value type.</typeparam>
    /// <param name="dt">The original <see cref="DateTime"/> value.</param>
    /// <param name="tzDst">The time zone offset to convert the original <see cref="DateTime"/> value to, in hours.</param>
    /// <returns>A new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset of 0.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T>(this IReadOnlyCollection<DateTime?> dts, T tzDst) where T : struct
    {
        if (dts is null || dts.Count <= 0)
        {
            yield break;
        }
        foreach (var dt in dts)
        {
            yield return dt.ChangeTimeZone(tzDst);
        }
    }

    /// <summary>
    /// Returns a new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset of 0.
    /// </summary>
    /// <typeparam name="T">The type of the time zone offset to convert the original <see cref="DateTime"/> value to, which must be a value type.</typeparam>
    /// <param name="dt">The original <see cref="DateTime"/> value.</param>
    /// <param name="tzDst">The time zone offset to convert the original <see cref="DateTime"/> value to, in hours.</param>
    /// <returns>A new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset of 0.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T>(this IReadOnlyList<DateTime?> dts, T tzDst) where T : struct
    {
        if (dts is null || dts.Count <= 0)
        {
            yield break;
        }
        for (var i = 0; i < dts.Count; i++)
        {
            yield return dts[i].ChangeTimeZone(tzDst);
        }
    }

    /// <summary>
    /// Returns a new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset of 0.
    /// </summary>
    /// <typeparam name="T">The type of the time zone offset to convert the original <see cref="DateTime"/> value to, which must be a value type.</typeparam>
    /// <param name="dt">The original <see cref="DateTime"/> value.</param>
    /// <param name="tzDst">The time zone offset to convert the original <see cref="DateTime"/> value to, in hours.</param>
    /// <returns>A new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset of 0.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T>(this IReadOnlySet<DateTime?> dts, T tzDst) where T : struct
    {
        if (dts is null || dts.Count <= 0)
        {
            yield break;
        }
        foreach (var dt in dts)
        {
            yield return dt.ChangeTimeZone(tzDst);
        }
    }

    /// <summary>
    /// Returns a new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset of 0.
    /// </summary>
    /// <typeparam name="T">The type of the time zone offset to convert the original <see cref="DateTime"/> value to, which must be a value type.</typeparam>
    /// <param name="dt">The original <see cref="DateTime"/> value.</param>
    /// <param name="tzDst">The time zone offset to convert the original <see cref="DateTime"/> value to, in hours.</param>
    /// <returns>A new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset of 0.</returns>
    public static DateTime ChangeTimeZone<T>(this DateTime dt, T? tzDst) where T : struct => dt.ChangeTimeZone(0, tzDst);

    /// <summary>
    /// Returns a new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset of 0.
    /// </summary>
    /// <typeparam name="T">The type of the time zone offset to convert the original <see cref="DateTime"/> value to, which must be a value type.</typeparam>
    /// <param name="dt">The original <see cref="DateTime"/> value.</param>
    /// <param name="tzDst">The time zone offset to convert the original <see cref="DateTime"/> value to, in hours.</param>
    /// <returns>A new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset of 0.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T>(T? tzDst, params DateTime[] dts) where T : struct
    {
        if (dts is null || dts.Length <= 0)
        {
            yield break;
        }
        for (var i = 0; i < dts.Length; i++)
        {
            yield return dts[i].ChangeTimeZone(tzDst);
        }
    }

    /// <summary>
    /// Returns a new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset of 0.
    /// </summary>
    /// <typeparam name="T">The type of the time zone offset to convert the original <see cref="DateTime"/> value to, which must be a value type.</typeparam>
    /// <param name="dt">The original <see cref="DateTime"/> value.</param>
    /// <param name="tzDst">The time zone offset to convert the original <see cref="DateTime"/> value to, in hours.</param>
    /// <returns>A new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset of 0.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T>(this IEnumerable<DateTime> dts, T? tzDst) where T : struct
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
    /// Returns a new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset of 0.
    /// </summary>
    /// <typeparam name="T">The type of the time zone offset to convert the original <see cref="DateTime"/> value to, which must be a value type.</typeparam>
    /// <param name="dt">The original <see cref="DateTime"/> value.</param>
    /// <param name="tzDst">The time zone offset to convert the original <see cref="DateTime"/> value to, in hours.</param>
    /// <returns>A new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset of 0.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T>(this IReadOnlyCollection<DateTime> dts, T? tzDst) where T : struct
    {
        if (dts is null || dts.Count <= 0)
        {
            yield break;
        }
        foreach (var dt in dts)
        {
            yield return dt.ChangeTimeZone(tzDst);
        }
    }

    /// <summary>
    /// Returns a new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset of 0.
    /// </summary>
    /// <typeparam name="T">The type of the time zone offset to convert the original <see cref="DateTime"/> value to, which must be a value type.</typeparam>
    /// <param name="dt">The original <see cref="DateTime"/> value.</param>
    /// <param name="tzDst">The time zone offset to convert the original <see cref="DateTime"/> value to, in hours.</param>
    /// <returns>A new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset of 0.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T>(this IReadOnlyList<DateTime> dts, T? tzDst) where T : struct
    {
        if (dts is null || dts.Count <= 0)
        {
            yield break;
        }
        for (var i = 0; i < dts.Count; i++)
        {
            yield return dts[i].ChangeTimeZone(tzDst);
        }
    }

    /// <summary>
    /// Returns a new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset of 0.
    /// </summary>
    /// <typeparam name="T">The type of the time zone offset to convert the original <see cref="DateTime"/> value to, which must be a value type.</typeparam>
    /// <param name="dt">The original <see cref="DateTime"/> value.</param>
    /// <param name="tzDst">The time zone offset to convert the original <see cref="DateTime"/> value to, in hours.</param>
    /// <returns>A new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset of 0.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T>(this IReadOnlySet<DateTime> dts, T? tzDst) where T : struct
    {
        if (dts is null || dts.Count <= 0)
        {
            yield break;
        }
        foreach (var dt in dts)
        {
            yield return dt.ChangeTimeZone(tzDst);
        }
    }

    /// <summary>
    /// Returns a new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset of 0.
    /// </summary>
    /// <typeparam name="T">The type of the time zone offset to convert the original <see cref="DateTime"/> value to, which must be a value type.</typeparam>
    /// <param name="dt">The original <see cref="DateTime"/> value.</param>
    /// <param name="tzDst">The time zone offset to convert the original <see cref="DateTime"/> value to, in hours.</param>
    /// <returns>A new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset of 0.</returns>
    public static DateTime ChangeTimeZone<T>(this DateTime? dt, T? tzDst) where T : struct => dt.ChangeTimeZone(0, tzDst);

    /// <summary>
    /// Returns a new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset of 0.
    /// </summary>
    /// <typeparam name="T">The type of the time zone offset to convert the original <see cref="DateTime"/> value to, which must be a value type.</typeparam>
    /// <param name="dt">The original <see cref="DateTime"/> value.</param>
    /// <param name="tzDst">The time zone offset to convert the original <see cref="DateTime"/> value to, in hours.</param>
    /// <returns>A new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset of 0.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T>(T? tzDst, params DateTime?[] dts) where T : struct
    {
        if (dts is null || dts.Length <= 0)
        {
            yield break;
        }
        for (var i = 0; i < dts.Length; i++)
        {
            yield return dts[i].ChangeTimeZone(tzDst);
        }
    }

    /// <summary>
    /// Returns a new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset of 0.
    /// </summary>
    /// <typeparam name="T">The type of the time zone offset to convert the original <see cref="DateTime"/> value to, which must be a value type.</typeparam>
    /// <param name="dt">The original <see cref="DateTime"/> value.</param>
    /// <param name="tzDst">The time zone offset to convert the original <see cref="DateTime"/> value to, in hours.</param>
    /// <returns>A new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset of 0.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T>(this IEnumerable<DateTime?> dts, T? tzDst) where T : struct
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
    /// Returns a new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset of 0.
    /// </summary>
    /// <typeparam name="T">The type of the time zone offset to convert the original <see cref="DateTime"/> value to, which must be a value type.</typeparam>
    /// <param name="dt">The original <see cref="DateTime"/> value.</param>
    /// <param name="tzDst">The time zone offset to convert the original <see cref="DateTime"/> value to, in hours.</param>
    /// <returns>A new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset of 0.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T>(this IReadOnlyCollection<DateTime?> dts, T? tzDst) where T : struct
    {
        if (dts is null || dts.Count <= 0)
        {
            yield break;
        }
        foreach (var dt in dts)
        {
            yield return dt.ChangeTimeZone(tzDst);
        }
    }

    /// <summary>
    /// Returns a new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset of 0.
    /// </summary>
    /// <typeparam name="T">The type of the time zone offset to convert the original <see cref="DateTime"/> value to, which must be a value type.</typeparam>
    /// <param name="dt">The original <see cref="DateTime"/> value.</param>
    /// <param name="tzDst">The time zone offset to convert the original <see cref="DateTime"/> value to, in hours.</param>
    /// <returns>A new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset of 0.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T>(this IReadOnlyList<DateTime?> dts, T? tzDst) where T : struct
    {
        if (dts is null || dts.Count <= 0)
        {
            yield break;
        }
        for (var i = 0; i < dts.Count; i++)
        {
            yield return dts[i].ChangeTimeZone(tzDst);
        }
    }

    /// <summary>
    /// Returns a new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset of 0.
    /// </summary>
    /// <typeparam name="T">The type of the time zone offset to convert the original <see cref="DateTime"/> value to, which must be a value type.</typeparam>
    /// <param name="dt">The original <see cref="DateTime"/> value.</param>
    /// <param name="tzDst">The time zone offset to convert the original <see cref="DateTime"/> value to, in hours.</param>
    /// <returns>A new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset of 0.</returns>
    public static IEnumerable<DateTime> ChangeTimeZone<T>(this IReadOnlySet<DateTime?> dts, T? tzDst) where T : struct
    {
        if (dts is null || dts.Count <= 0)
        {
            yield break;
        }
        foreach (var dt in dts)
        {
            yield return dt.ChangeTimeZone(tzDst);
        }
    }
}
