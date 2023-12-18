using static YANLib.YANDateTime;

namespace YANLib.Ultimate;

public static partial class YANDateTime
{
    /// <summary>
    /// Converts a collection of string representations of dates and times to their <see cref="DateTime"/> equivalents using the specified format.
    /// If the collection is <see langword="null"/> or empty, yields no results.
    /// Each string in the collection is attempted to be converted to a <see cref="DateTime"/> using the specified format. If the conversion fails, the specified default value is used.
    /// </summary>
    /// <param name="strs">The collection of strings to be converted to <see cref="DateTime"/>. Can be <see langword="null"/>.</param>
    /// <param name="fmt">The format of the input strings. Can be <see langword="null"/>.</param>
    /// <param name="dfltVal">The default <see cref="DateTime"/> value to use if the conversion fails. Can be <see langword="null"/>, resulting in a default <see cref="DateTime"/>.</param>
    /// <returns>An enumerable collection of <see cref="DateTime"/> values, each representing the converted equivalent of an element in the input collection or the specified default value if the conversion fails.</returns>
    public static IEnumerable<DateTime> ToDateTimes(this IEnumerable<string?>? strs, string? fmt = null, DateTime? dfltVal = null)
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
    /// Generates a collection of <see cref="DateTime"/> values within the specified range and of the specified size.
    /// </summary>
    /// <param name="size">The number of random <see cref="DateTime"/> values to generate. If <see langword="null"/>, results in a default size of 0.</param>
    /// <param name="min">The minimum <see cref="DateTime"/> value for each generated value. Can be <see langword="null"/>.</param>
    /// <param name="max">The maximum <see cref="DateTime"/> value for each generated value. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of <see cref="DateTime"/> values, each randomly generated within the specified range.</returns>
    public static IEnumerable<DateTime> GenerateRandomDateTimes(object? size, DateTime? min = null, DateTime? max = null)
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomDateTime(min, max);
        }
    }

    /// <summary>
    /// Converts a collection of <see cref="DateTime"/> values to their respective week numbers of the year.
    /// If the collection is <see langword="null"/> or empty, yields no results.
    /// </summary>
    /// <param name="dts">The collection of <see cref="DateTime"/> values. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of integers, each representing the week number of the year for the corresponding <see cref="DateTime"/> value.</returns>
    public static IEnumerable<int> GetWeekOfYears(this IEnumerable<DateTime?> dts)
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
    /// Changes the time zones of a collection of <see cref="DateTime"/> values.
    /// If the collection is <see langword="null"/> or empty, yields no results.
    /// Each <see cref="DateTime"/> value is adjusted to a new time zone, with any adjustments that fall outside the valid range resulting in a default <see cref="DateTime"/>.
    /// </summary>
    /// <param name="dts">The collection of <see cref="DateTime"/> values to change the time zones for. Can be <see langword="null"/>.</param>
    /// <param name="tzSrc">The source time zone. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of <see cref="DateTime"/> values adjusted to the new time zones.</returns>
    public static IEnumerable<DateTime> ChangeTimeZones(this IEnumerable<DateTime?> dts, object? tzSrc = null, object? tzDst = null)
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
