using YANLib.Core;
using static YANLib.Core.YANDateTime;

namespace YANLib.Ultimate.Core;

public static partial class YANDateTime
{
    /// <summary>
    /// Converts a collection of string representations of dates and times to their respective <see cref="DateTime"/> equivalents, using an optional format and default value.
    /// If the collection is <see langword="null"/> or empty, yields no results.
    /// Each string in the collection is converted to a <see cref="DateTime"/> value using the specified format; if conversion fails, the default value is used.
    /// </summary>
    /// <param name="strs">The collection of strings to be converted to <see cref="DateTime"/>. Can be <see langword="null"/>.</param>
    /// <param name="fmt">The format of the input strings. Can be <see langword="null"/> or empty for standard parsing.</param>
    /// <param name="dfltVal">The default <see cref="DateTime"/> value to use if conversion fails.</param>
    /// <returns>An enumerable collection of <see cref="DateTime"/> values representing the converted results.</returns>
    public static IEnumerable<DateTime> ToDateTimes(this IEnumerable<string?>? strs, string? fmt = null, DateTime dfltVal = default)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.ToDateTime(fmt, dfltVal);
        }
    }

    /// <summary>
    /// Converts a collection (ICollection) of string representations of dates and times to their respective <see cref="DateTime"/> equivalents, using an optional format and default value.
    /// If the collection is <see langword="null"/> or empty, yields no results.
    /// Each string in the collection is converted to a <see cref="DateTime"/> value using the specified format; if conversion fails, the default value is used.
    /// </summary>
    /// <param name="strs">The ICollection of strings to be converted to <see cref="DateTime"/>. Can be <see langword="null"/>.</param>
    /// <param name="fmt">The format of the input strings. Can be <see langword="null"/> or empty for standard parsing.</param>
    /// <param name="dfltVal">The default <see cref="DateTime"/> value to use if conversion fails.</param>
    /// <returns>An enumerable collection of <see cref="DateTime"/> values representing the converted results.</returns>
    public static IEnumerable<DateTime> ToDateTimes(this ICollection<string?>? strs, string? fmt = null, DateTime dfltVal = default)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.ToDateTime(fmt, dfltVal);
        }
    }

    /// <summary>
    /// Converts an array of string representations of dates and times to their respective <see cref="DateTime"/> equivalents, using an optional format and default value.
    /// If the array is <see langword="null"/> or empty, yields no results.
    /// Each string in the array is converted to a <see cref="DateTime"/> value using the specified format; if conversion fails, the default value is used.
    /// </summary>
    /// <param name="strs">The array of strings to be converted to <see cref="DateTime"/>. Can be <see langword="null"/>.</param>
    /// <param name="fmt">The format of the input strings. Can be <see langword="null"/> or empty for standard parsing.</param>
    /// <param name="dfltVal">The default <see cref="DateTime"/> value to use if conversion fails.</param>
    /// <returns>An enumerable collection of <see cref="DateTime"/> values representing the converted results.</returns>
    public static IEnumerable<DateTime> ToDateTimes(this string?[]? strs, string? fmt = null, DateTime dfltVal = default)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.ToDateTime(fmt, dfltVal);
        }
    }

    /// <summary>
    /// Generates a collection of random <see cref="DateTime"/> objects of the specified size, each within the specified minimum and maximum range.
    /// If the specified size is invalid (non-positive), yields no results.
    /// </summary>
    /// <param name="size">The number of random <see cref="DateTime"/> objects to generate. The size is converted to an unsigned long and should be a positive value.</param>
    /// <param name="min">The minimum <see cref="DateTime"/> value that can be generated for each object.</param>
    /// <param name="max">The maximum <see cref="DateTime"/> value that can be generated for each object.</param>
    /// <returns>An enumerable collection of randomly generated <see cref="DateTime"/> objects within the specified range.</returns>
    public static IEnumerable<DateTime> GenerateRandomDateTimes(object? size, DateTime min, DateTime max)
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomDateTime(min, max);
        }
    }

    /// <summary>
    /// Converts a collection of non-nullable <see cref="DateTime"/> values to their respective week numbers of the year.
    /// If the collection is <see langword="null"/> or empty, yields no results.
    /// Each <see cref="DateTime"/> value is converted to its corresponding week number based on the current culture's calendar and rules.
    /// </summary>
    /// <param name="dts">The collection of non-nullable <see cref="DateTime"/> values. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of integers representing the week numbers of the year for each <see cref="DateTime"/> value.</returns>
    public static IEnumerable<int> GetWeekOfYears(this IEnumerable<DateTime>? dts)
    {
        if (dts.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var dt in dts)
        {
            yield return dt.GetWeekOfYear();
        }
    }

    /// <summary>
    /// Converts a collection (ICollection) of non-nullable <see cref="DateTime"/> values to their respective week numbers of the year.
    /// If the collection is <see langword="null"/> or empty, yields no results.
    /// Each <see cref="DateTime"/> value is converted to its corresponding week number based on the current culture's calendar and rules.
    /// </summary>
    /// <param name="dts">The ICollection of non-nullable <see cref="DateTime"/> values. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of integers representing the week numbers of the year for each <see cref="DateTime"/> value.</returns>
    public static IEnumerable<int> GetWeekOfYears(this ICollection<DateTime>? dts)
    {
        if (dts.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var dt in dts)
        {
            yield return dt.GetWeekOfYear();
        }
    }

    /// <summary>
    /// Converts an array of non-nullable <see cref="DateTime"/> values to their respective week numbers of the year.
    /// If the array is <see langword="null"/> or empty, yields no results.
    /// Each <see cref="DateTime"/> value is converted to its corresponding week number based on the current culture's calendar and rules.
    /// </summary>
    /// <param name="dts">The array of non-nullable <see cref="DateTime"/> values. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of integers representing the week numbers of the year for each <see cref="DateTime"/> value.</returns>
    public static IEnumerable<int> GetWeekOfYears(this DateTime[]? dts)
    {
        if (dts.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var dt in dts)
        {
            yield return dt.GetWeekOfYear();
        }
    }

    /// <summary>
    /// Converts a collection of nullable <see cref="DateTime"/> values to their respective week numbers of the year.
    /// If the collection is <see langword="null"/> or empty, yields no results.
    /// Each <see cref="DateTime"/> value is converted to its corresponding week number based on the current culture's calendar and rules.
    /// </summary>
    /// <param name="dts">The collection of nullable <see cref="DateTime"/> values. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of integers representing the week numbers of the year for each <see cref="DateTime"/> value.</returns>
    public static IEnumerable<int> GetWeekOfYears(this IEnumerable<DateTime?>? dts)
    {
        if (dts.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var dt in dts)
        {
            yield return dt.GetWeekOfYear();
        }
    }

    /// <summary>
    /// Converts a collection (ICollection) of nullable <see cref="DateTime"/> values to their respective week numbers of the year.
    /// If the collection is <see langword="null"/> or empty, yields no results.
    /// Each <see cref="DateTime"/> value is converted to its corresponding week number based on the current culture's calendar and rules.
    /// </summary>
    /// <param name="dts">The ICollection of nullable <see cref="DateTime"/> values. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of integers representing the week numbers of the year for each <see cref="DateTime"/> value.</returns>
    public static IEnumerable<int> GetWeekOfYears(this ICollection<DateTime?>? dts)
    {
        if (dts.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var dt in dts)
        {
            yield return dt.GetWeekOfYear();
        }
    }

    /// <summary>
    /// Converts an array of nullable <see cref="DateTime"/> values to their respective week numbers of the year.
    /// If the array is <see langword="null"/> or empty, yields no results.
    /// Each <see cref="DateTime"/> value is converted to its corresponding week number based on the current culture's calendar and rules.
    /// </summary>
    /// <param name="dts">The array of nullable <see cref="DateTime"/> values. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of integers representing the week numbers of the year for each <see cref="DateTime"/> value.</returns>
    public static IEnumerable<int> GetWeekOfYears(this DateTime?[]? dts)
    {
        if (dts.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var dt in dts)
        {
            yield return dt.GetWeekOfYear();
        }
    }

    /// <summary>
    /// Adjusts the time zone of each nullable <see cref="DateTime"/> in the specified IEnumerable collection.
    /// Converts the date and time from the source time zone to the destination time zone.
    /// If the collection is <see langword="null"/> or empty, yields no results.
    /// </summary>
    /// <param name="dts">The collection of nullable <see cref="DateTime"/> values to be adjusted. Can be <see langword="null"/>.</param>
    /// <param name="tzSrc">The source time zone. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of <see cref="DateTime"/> values adjusted to the new time zone.</returns>
    public static IEnumerable<DateTime> ChangeTimeZones(this IEnumerable<DateTime?>? dts, object? tzSrc = null, object? tzDst = null)
    {
        if (dts.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var dt in dts)
        {
            yield return dt.ChangeTimeZone(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Adjusts the time zone of each non-nullable <see cref="DateTime"/> in the specified IEnumerable collection.
    /// Converts the date and time from the source time zone to the destination time zone.
    /// If the collection is <see langword="null"/> or empty, yields no results.
    /// </summary>
    /// <param name="dts">The collection of non-nullable <see cref="DateTime"/> values to be adjusted. Can be <see langword="null"/>.</param>
    /// <param name="tzSrc">The source time zone. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of <see cref="DateTime"/> values adjusted to the new time zone.</returns>
    public static IEnumerable<DateTime> ChangeTimeZones(this IEnumerable<DateTime>? dts, object? tzSrc = null, object? tzDst = null)
    {
        if (dts.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var dt in dts)
        {
            yield return dt.ChangeTimeZone(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Adjusts the time zone of each nullable <see cref="DateTime"/> in the specified ICollection collection.
    /// Converts the date and time from the source time zone to the destination time zone.
    /// If the collection is <see langword="null"/> or empty, yields no results.
    /// </summary>
    /// <param name="dts">The ICollection of nullable <see cref="DateTime"/> values to be adjusted. Can be <see langword="null"/>.</param>
    /// <param name="tzSrc">The source time zone. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of <see cref="DateTime"/> values adjusted to the new time zone.</returns>
    public static IEnumerable<DateTime> ChangeTimeZones(this ICollection<DateTime?>? dts, object? tzSrc = null, object? tzDst = null)
    {
        if (dts.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var dt in dts)
        {
            yield return dt.ChangeTimeZone(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Adjusts the time zone of each non-nullable <see cref="DateTime"/> in the specified ICollection collection.
    /// Converts the date and time from the source time zone to the destination time zone.
    /// If the collection is <see langword="null"/> or empty, yields no results.
    /// </summary>
    /// <param name="dts">The ICollection of non-nullable <see cref="DateTime"/> values to be adjusted. Can be <see langword="null"/>.</param>
    /// <param name="tzSrc">The source time zone. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of <see cref="DateTime"/> values adjusted to the new time zone.</returns>
    public static IEnumerable<DateTime> ChangeTimeZones(this ICollection<DateTime>? dts, object? tzSrc = null, object? tzDst = null)
    {
        if (dts.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var dt in dts)
        {
            yield return dt.ChangeTimeZone(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Adjusts the time zone of each nullable <see cref="DateTime"/> in the specified array.
    /// Converts the date and time from the source time zone to the destination time zone.
    /// If the array is <see langword="null"/> or empty, yields no results.
    /// </summary>
    /// <param name="dts">The array of nullable <see cref="DateTime"/> values to be adjusted. Can be <see langword="null"/>.</param>
    /// <param name="tzSrc">The source time zone. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of <see cref="DateTime"/> values adjusted to the new time zone.</returns>
    public static IEnumerable<DateTime> ChangeTimeZones(this DateTime?[]? dts, object? tzSrc = null, object? tzDst = null)
    {
        if (dts.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var dt in dts)
        {
            yield return dt.ChangeTimeZone(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Adjusts the time zone of each non-nullable <see cref="DateTime"/> in the specified array.
    /// Converts the date and time from the source time zone to the destination time zone.
    /// If the array is <see langword="null"/> or empty, yields no results.
    /// </summary>
    /// <param name="dts">The array of non-nullable <see cref="DateTime"/> values to be adjusted. Can be <see langword="null"/>.</param>
    /// <param name="tzSrc">The source time zone. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of <see cref="DateTime"/> values adjusted to the new time zone.</returns>
    public static IEnumerable<DateTime> ChangeTimeZones(this DateTime[]? dts, object? tzSrc = null, object? tzDst = null)
    {
        if (dts.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var dt in dts)
        {
            yield return dt.ChangeTimeZone(tzSrc, tzDst);
        }
    }
}
