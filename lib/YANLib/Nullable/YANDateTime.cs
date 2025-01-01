using YANLib.Object;
using YANLib.Text;
using YANLib.Unmanaged;
using static System.DateTime;
using static System.Globalization.DateTimeFormatInfo;
using static System.Linq.Enumerable;
using static System.Math;

namespace YANLib.Nullable;

public static partial class YANDateTime
{
    /// <summary>
    /// Gets the week of the year for a specified <see cref="DateTime"/>.
    /// Returns <see langword="null"/> if the <see cref="DateTime"/> is <see langword="null"/>.
    /// </summary>
    /// <param name="dt">The <see cref="DateTime"/> to calculate the week of the year for. Can be <see langword="null"/>.</param>
    /// <returns>The week of the year, or <see langword="null"/> if the <see cref="DateTime"/> is <see langword="null"/>.</returns>
    public static int? GetWeekOfYear(this DateTime? dt) => dt.HasValue ? CurrentInfo.Calendar.GetWeekOfYear(dt.Value, CurrentInfo.CalendarWeekRule, CurrentInfo.FirstDayOfWeek) : default;

    /// <summary>
    /// Converts a collection of nullable <see cref="DateTime"/> values to their respective week numbers of the year.
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each <see cref="DateTime"/> value is converted to its corresponding week number based on the current culture's calendar and rules.
    /// </summary>
    /// <param name="dts">The collection of nullable <see cref="DateTime"/> values. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of integers representing the week numbers of the year for each <see cref="DateTime"/> value, or <see langword="null"/> if the input collection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<int?>? GetWeekOfYears(this IEnumerable<DateTime?>? dts) => dts.IsNullOEmpty() ? default : dts.Select(x => x.GetWeekOfYear());

    /// <summary>
    /// Converts a collection (ICollection) of nullable <see cref="DateTime"/> values to their respective week numbers of the year.
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each <see cref="DateTime"/> value is converted to its corresponding week number based on the current culture's calendar and rules.
    /// </summary>
    /// <param name="dts">The ICollection of nullable <see cref="DateTime"/> values. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of integers representing the week numbers of the year for each <see cref="DateTime"/> value, or <see langword="null"/> if the input ICollection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<int?>? GetWeekOfYears(this ICollection<DateTime?>? dts) => dts.IsNullOEmpty() ? default : dts.Select(x => x.GetWeekOfYear());

    /// <summary>
    /// Converts an array of nullable <see cref="DateTime"/> values to their respective week numbers of the year.
    /// If the array is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each <see cref="DateTime"/> value is converted to its corresponding week number based on the current culture's calendar and rules.
    /// </summary>
    /// <param name="dts">The array of nullable <see cref="DateTime"/> values. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of integers representing the week numbers of the year for each <see cref="DateTime"/> value, or <see langword="null"/> if the input array is <see langword="null"/> or empty.</returns>
    public static IEnumerable<int?>? GetWeekOfYears(this DateTime?[]? dts) => dts.IsNullOEmpty() ? default : dts.Select(x => x.GetWeekOfYear());

    /// <summary>
    /// Changes the time zone of a given <see cref="DateTime"/>.
    /// Returns <see langword="null"/> if the <see cref="DateTime"/> is <see langword="null"/> or if the adjusted time falls outside the valid range of <see cref="DateTime"/>.
    /// </summary>
    /// <param name="dt">The <see cref="DateTime"/> to change the time zone for. Can be <see langword="null"/>.</param>
    /// <param name="tzSrc">The source time zone. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone. Can be <see langword="null"/>.</param>
    /// <returns>The <see cref="DateTime"/> adjusted to the new time zone, or <see langword="null"/> if the adjustment is invalid.</returns>
    public static DateTime? ChangeTimeZone(this DateTime? dt, object? tzSrc = null, object? tzDst = null)
    {
        if (!dt.HasValue)
        {
            return default;
        }

        var diff = tzDst.To<int>() - tzSrc.To<int>();

        return diff switch
        {
            < 0 when (dt.Value - MinValue).TotalHours < Abs(diff) => default,
            > 0 when (MaxValue - dt.Value).TotalHours < diff => default,
            _ => dt.Value.AddHours(diff)
        };
    }

    /// <summary>
    /// Adjusts the time zone of each nullable <see cref="DateTime"/> in the specified IEnumerable collection.
    /// Converts the date and time from the source time zone to the destination time zone.
    /// If the collection is <see langword="null"/> or empty, or if any conversion results in an invalid date, returns <see langword="null"/> for that date.
    /// </summary>
    /// <param name="dts">The collection of nullable <see cref="DateTime"/> values to be adjusted. Can be <see langword="null"/>.</param>
    /// <param name="tzSrc">The source time zone. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of nullable <see cref="DateTime"/> values adjusted to the new time zone, or <see langword="null"/> for dates that result in an invalid conversion.</returns>
    public static IEnumerable<DateTime?>? ChangeTimeZones(this IEnumerable<DateTime?>? dts, object? tzSrc = null, object? tzDst = null) => dts.IsNullOEmpty()
        ? default
        : dts.Select(x => x.ChangeTimeZone(tzSrc, tzDst));

    /// <summary>
    /// Adjusts the time zone of each nullable <see cref="DateTime"/> in the specified ICollection collection.
    /// Converts the date and time from the source time zone to the destination time zone.
    /// If the collection is <see langword="null"/> or empty, or if any conversion results in an invalid date, returns <see langword="null"/> for that date.
    /// </summary>
    /// <param name="dts">The ICollection of nullable <see cref="DateTime"/> values to be adjusted. Can be <see langword="null"/>.</param>
    /// <param name="tzSrc">The source time zone. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of nullable <see cref="DateTime"/> values adjusted to the new time zone, or <see langword="null"/> for dates that result in an invalid conversion.</returns>
    public static IEnumerable<DateTime?>? ChangeTimeZones(this ICollection<DateTime?>? dts, object? tzSrc = null, object? tzDst = null) => dts.IsNullOEmpty()
        ? default
        : dts.Select(x => x.ChangeTimeZone(tzSrc, tzDst));

    /// <summary>
    /// Adjusts the time zone of each nullable <see cref="DateTime"/> in the specified array.
    /// Converts the date and time from the source time zone to the destination time zone.
    /// If the array is <see langword="null"/> or empty, or if any conversion results in an invalid date, returns <see langword="null"/> for that date.
    /// </summary>
    /// <param name="dts">The array of nullable <see cref="DateTime"/> values to be adjusted. Can be <see langword="null"/>.</param>
    /// <param name="tzSrc">The source time zone. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of nullable <see cref="DateTime"/> values adjusted to the new time zone, or <see langword="null"/> for dates that result in an invalid conversion.</returns>
    public static IEnumerable<DateTime?>? ChangeTimeZones(this DateTime?[]? dts, object? tzSrc = null, object? tzDst = null) => dts.IsNullOEmpty()
        ? default
        : dts.Select(x => x.ChangeTimeZone(tzSrc, tzDst));
}
