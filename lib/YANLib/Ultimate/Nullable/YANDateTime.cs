﻿using YANLib.Core;
using static YANLib.Nullable.YANDateTime;

namespace YANLib.Ultimate.Nullable;

public static partial class YANDateTime
{
    public static IEnumerable<DateTime?>? ToDateTimes(this IEnumerable<string?>? strs, DateTime? dfltVal = null)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.ToDateTime(dfltVal);
        }
    }

    public static IEnumerable<DateTime?>? ToDateTimes(this ICollection<string?>? strs, DateTime? dfltVal = null)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.ToDateTime(dfltVal);
        }
    }

    public static IEnumerable<DateTime?>? ToDateTimes(this string?[]? strs, DateTime? dfltVal = null)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.ToDateTime(dfltVal);
        }
    }

    public static IEnumerable<DateTime?>? ToDateTimes(this IEnumerable<string?>? strs, IEnumerable<string?>? fmts = null)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return YANLib.Nullable.YANDateTime.ToDateTime(str, fmts);
        }
    }

    public static IEnumerable<DateTime?>? ToDateTimes(this ICollection<string?>? strs, IEnumerable<string?>? fmts = null)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return YANLib.Nullable.YANDateTime.ToDateTime(str, fmts);
        }
    }

    public static IEnumerable<DateTime?>? ToDateTimes(this string?[]? strs, IEnumerable<string?>? fmts = null)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return YANLib.Nullable.YANDateTime.ToDateTime(str, fmts);
        }
    }

    public static IEnumerable<DateTime?>? ToDateTimes(this IEnumerable<string?>? strs, ICollection<string?>? fmts = null)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return YANLib.Nullable.YANDateTime.ToDateTime(str, fmts);
        }
    }

    public static IEnumerable<DateTime?>? ToDateTimes(this ICollection<string?>? strs, ICollection<string?>? fmts = null)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return YANLib.Nullable.YANDateTime.ToDateTime(str, fmts);
        }
    }

    public static IEnumerable<DateTime?>? ToDateTimes(this string?[]? strs, ICollection<string?>? fmts = null)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return YANLib.Nullable.YANDateTime.ToDateTime(str, fmts);
        }
    }

    public static IEnumerable<DateTime?>? ToDateTimes(this IEnumerable<string?>? strs, params string?[]? fmts)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return YANLib.Nullable.YANDateTime.ToDateTime(str, fmts);
        }
    }

    public static IEnumerable<DateTime?>? ToDateTimes(this ICollection<string?>? strs, params string?[]? fmts)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return YANLib.Nullable.YANDateTime.ToDateTime(str, fmts);
        }
    }

    public static IEnumerable<DateTime?>? ToDateTimes(this string?[]? strs, params string?[]? fmts)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return YANLib.Nullable.YANDateTime.ToDateTime(str, fmts);
        }
    }

    public static IEnumerable<DateTime?>? ToDateTimes(this IEnumerable<string?>? strs, DateTime? dfltVal = null, IEnumerable<string?>? fmts = null)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.ToDateTime(dfltVal, fmts);
        }
    }

    public static IEnumerable<DateTime?>? ToDateTimes(this ICollection<string?>? strs, DateTime? dfltVal = null, IEnumerable<string?>? fmts = null)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.ToDateTime(dfltVal, fmts);
        }
    }

    public static IEnumerable<DateTime?>? ToDateTimes(this string?[]? strs, DateTime? dfltVal = null, IEnumerable<string?>? fmts = null)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.ToDateTime(dfltVal, fmts);
        }
    }

    public static IEnumerable<DateTime?>? ToDateTimes(this IEnumerable<string?>? strs, DateTime? dfltVal = null, ICollection<string?>? fmts = null)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.ToDateTime(dfltVal, fmts);
        }
    }

    public static IEnumerable<DateTime?>? ToDateTimes(this ICollection<string?>? strs, DateTime? dfltVal = null, ICollection<string?>? fmts = null)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.ToDateTime(dfltVal, fmts);
        }
    }

    public static IEnumerable<DateTime?>? ToDateTimes(this string?[]? strs, DateTime? dfltVal = null, ICollection<string?>? fmts = null)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.ToDateTime(dfltVal, fmts);
        }
    }

    public static IEnumerable<DateTime?>? ToDateTimes(this IEnumerable<string?>? strs, DateTime? dfltVal = null, params string?[]? fmts)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.ToDateTime(dfltVal, fmts);
        }
    }

    public static IEnumerable<DateTime?>? ToDateTimes(this ICollection<string?>? strs, DateTime? dfltVal = null, params string?[]? fmts)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.ToDateTime(dfltVal, fmts);
        }
    }

    public static IEnumerable<DateTime?>? ToDateTimes(this string?[]? strs, DateTime? dfltVal = null, params string?[]? fmts)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.ToDateTime(dfltVal, fmts);
        }
    }

    /// <summary>
    /// Generates a collection of random nullable <see cref="DateTime"/> values within the specified range and of the specified size.
    /// </summary>
    /// <param name="size">The number of random <see cref="DateTime"/> values to generate. Can be <see langword="null"/>, resulting in a default size of 0.</param>
    /// <param name="min">The minimum <see cref="DateTime"/> value for each generated value. Can be <see langword="null"/>.</param>
    /// <param name="max">The maximum <see cref="DateTime"/> value for each generated value. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of randomly generated nullable <see cref="DateTime"/> values.</returns>
    public static IEnumerable<DateTime?> GenerateRandomDateTimes(object? size, DateTime? min = null, DateTime? max = null)
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomDateTime(min, max);
        }
    }

    /// <summary>
    /// Converts a collection of nullable <see cref="DateTime"/> values to their respective week numbers of the year.
    /// If the collection is <see langword="null"/> or empty, yields no results.
    /// Each <see cref="DateTime"/> value is converted to its corresponding week number based on the current culture's calendar and rules.
    /// </summary>
    /// <param name="dts">The collection of nullable <see cref="DateTime"/> values. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of integers representing the week numbers of the year for each <see cref="DateTime"/> value.</returns>
    public static IEnumerable<int?> GetWeekOfYears(this IEnumerable<DateTime?>? dts)
    {
        if (dts.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var dt in dts)
        {
            yield return YANLib.Nullable.YANDateTime.GetWeekOfYear(dt);
        }
    }

    /// <summary>
    /// Converts a collection (ICollection) of nullable <see cref="DateTime"/> values to their respective week numbers of the year.
    /// If the collection is <see langword="null"/> or empty, yields no results.
    /// Each <see cref="DateTime"/> value is converted to its corresponding week number based on the current culture's calendar and rules.
    /// </summary>
    /// <param name="dts">The ICollection of nullable <see cref="DateTime"/> values. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of integers representing the week numbers of the year for each <see cref="DateTime"/> value.</returns>
    public static IEnumerable<int?> GetWeekOfYears(this ICollection<DateTime?>? dts)
    {
        if (dts.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var dt in dts)
        {
            yield return YANLib.Nullable.YANDateTime.GetWeekOfYear(dt);
        }
    }

    /// <summary>
    /// Converts an array of nullable <see cref="DateTime"/> values to their respective week numbers of the year.
    /// If the array is <see langword="null"/> or empty, yields no results.
    /// Each <see cref="DateTime"/> value is converted to its corresponding week number based on the current culture's calendar and rules.
    /// </summary>
    /// <param name="dts">The array of nullable <see cref="DateTime"/> values. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of integers representing the week numbers of the year for each <see cref="DateTime"/> value.</returns>
    public static IEnumerable<int?> GetWeekOfYears(this DateTime?[]? dts)
    {
        if (dts.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var dt in dts)
        {
            yield return YANLib.Nullable.YANDateTime.GetWeekOfYear(dt);
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
    /// <returns>An enumerable collection of nullable <see cref="DateTime"/> values adjusted to the new time zone.</returns>
    public static IEnumerable<DateTime?> ChangeTimeZones(this IEnumerable<DateTime?>? dts, object? tzSrc = null, object? tzDst = null)
    {
        if (dts.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var dt in dts)
        {
            yield return YANLib.Nullable.YANDateTime.ChangeTimeZone(dt, tzSrc, tzDst);
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
    /// <returns>An enumerable collection of nullable <see cref="DateTime"/> values adjusted to the new time zone.</returns>
    public static IEnumerable<DateTime?> ChangeTimeZones(this ICollection<DateTime?>? dts, object? tzSrc = null, object? tzDst = null)
    {
        if (dts.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var dt in dts)
        {
            yield return YANLib.Nullable.YANDateTime.ChangeTimeZone(dt, tzSrc, tzDst);
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
    /// <returns>An enumerable collection of nullable <see cref="DateTime"/> values adjusted to the new time zone.</returns>
    public static IEnumerable<DateTime?> ChangeTimeZones(this DateTime?[]? dts, object? tzSrc = null, object? tzDst = null)
    {
        if (dts.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var dt in dts)
        {
            yield return YANLib.Nullable.YANDateTime.ChangeTimeZone(dt, tzSrc, tzDst);
        }
    }
}
