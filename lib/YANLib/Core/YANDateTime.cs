using YANLib.Object;
using YANLib.Text;
using YANLib.Unmanaged;
using static System.DateTime;
using static System.Globalization.DateTimeFormatInfo;
using static System.Linq.Enumerable;
using static System.Math;
using static YANLib.YANRandom;

namespace YANLib.Core;

public static partial class YANDateTime
{
    /// <summary>
    /// Generates a random <see cref="DateTime"/> object between the specified minimum and maximum values.
    /// If the minimum value is greater than the maximum value, returns the default <see cref="DateTime"/>.
    /// </summary>
    /// <param name="min">The minimum <see cref="DateTime"/> value that can be generated.</param>
    /// <param name="max">The maximum <see cref="DateTime"/> value that can be generated.</param>
    /// <returns>A randomly generated <see cref="DateTime"/> object between the specified minimum and maximum values, or the default <see cref="DateTime"/> if min is greater than max.</returns>
    public static DateTime GenerateRandomDateTime(DateTime min, DateTime max) => min > max ? default : min.AddTicks(GenerateRandom<long>((max - min).Ticks));

    /// <summary>
    /// Generates a collection of random <see cref="DateTime"/> objects of the specified size, each within the specified minimum and maximum range.
    /// If the specified size is invalid (non-positive), yields no results.
    /// </summary>
    /// <param name="size">The number of random <see cref="DateTime"/> objects to generate. The size is converted to an integer and should be a positive value.</param>
    /// <param name="min">The minimum <see cref="DateTime"/> value that can be generated for each object.</param>
    /// <param name="max">The maximum <see cref="DateTime"/> value that can be generated for each object.</param>
    /// <returns>An enumerable collection of randomly generated <see cref="DateTime"/> objects within the specified range.</returns>
    public static IEnumerable<DateTime> GenerateRandomDateTimes(object? size, DateTime min, DateTime max) => Range(0, size.To<uint>().To<int>()).Select(i => GenerateRandomDateTime(min, max));

    /// <summary>
    /// Gets the week of the year for the specified <see cref="DateTime"/>.
    /// The calculation is based on the current culture's calendar and week rule settings.
    /// </summary>
    /// <param name="dt">The <see cref="DateTime"/> to calculate the week of the year for.</param>
    /// <returns>The week of the year for the specified <see cref="DateTime"/>.</returns>
    public static int GetWeekOfYear(this DateTime dt) => CurrentInfo.Calendar.GetWeekOfYear(dt, CurrentInfo.CalendarWeekRule, CurrentInfo.FirstDayOfWeek);

    /// <summary>
    /// Gets the week of the year for the specified nullable <see cref="DateTime"/>.
    /// If the <see cref="DateTime"/> is <see langword="null"/>, returns the default integer value.
    /// The calculation is based on the current culture's calendar and week rule settings.
    /// </summary>
    /// <param name="dt">The nullable <see cref="DateTime"/> to calculate the week of the year for. Can be <see langword="null"/>.</param>
    /// <returns>The week of the year for the specified <see cref="DateTime"/>, or the default integer value if <see cref="DateTime"/> is <see langword="null"/>.</returns>
    public static int GetWeekOfYear(this DateTime? dt) => dt.HasValue ? CurrentInfo.Calendar.GetWeekOfYear(dt.Value, CurrentInfo.CalendarWeekRule, CurrentInfo.FirstDayOfWeek) : default;

    /// <summary>
    /// Determines the week number of the year for each <see cref="DateTime"/> object in a collection.
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each <see cref="DateTime"/> object in the collection is evaluated to find its corresponding week number in the year.
    /// </summary>
    /// <param name="dts">The collection of <see cref="DateTime"/> objects. Can be <see langword="null"/>.</param>
    /// <returns>
    /// An enumerable collection of integers representing the week numbers for each <see cref="DateTime"/> object in the collection, or <see langword="null"/> if the input collection is <see langword="null"/> or empty.
    /// </returns>
    public static IEnumerable<int>? GetWeekOfYears(this IEnumerable<DateTime>? dts) => dts.IsNullOEmpty() ? default : dts.Select(x => x.GetWeekOfYear());

    /// <summary>
    /// Determines the week number of the year for each <see cref="DateTime"/> object in a collection (ICollection).
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each <see cref="DateTime"/> object in the collection is evaluated to find its corresponding week number in the year.
    /// </summary>
    /// <param name="dts">The ICollection of <see cref="DateTime"/> objects. Can be <see langword="null"/>.</param>
    /// <returns>
    /// An enumerable collection of integers representing the week numbers for each <see cref="DateTime"/> object in the collection, or <see langword="null"/> if the input collection is <see langword="null"/> or empty.
    /// </returns>
    public static IEnumerable<int>? GetWeekOfYears(this ICollection<DateTime>? dts) => dts.IsNullOEmpty() ? default : dts.Select(x => x.GetWeekOfYear());

    /// <summary>
    /// Determines the week number of the year for each <see cref="DateTime"/> object in an array.
    /// If the array is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each <see cref="DateTime"/> object in the array is evaluated to find its corresponding week number in the year.
    /// </summary>
    /// <param name="dts">The array of <see cref="DateTime"/> objects. Can be <see langword="null"/>.</param>
    /// <returns>An array of integers representing the week numbers for each <see cref="DateTime"/> object in the array, or <see langword="null"/> if the input array is <see langword="null"/> or empty.</returns>
    public static IEnumerable<int>? GetWeekOfYears(params DateTime[]? dts) => dts.IsNullOEmpty() ? default : dts.Select(x => x.GetWeekOfYear());

    /// <summary>
    /// Determines the week number of the year for each nullable <see cref="DateTime"/> object in a collection.
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each nullable <see cref="DateTime"/> object in the collection is evaluated to find its corresponding week number in the year. Null values are ignored.
    /// </summary>
    /// <param name="dts">The collection of nullable <see cref="DateTime"/> objects. Can be <see langword="null"/>.</param>
    /// <returns>
    /// An enumerable collection of integers representing the week numbers for each non-null <see cref="DateTime"/> object in the collection, or <see langword="null"/> if the input collection is <see langword="null"/> or empty.
    /// </returns>
    public static IEnumerable<int>? GetWeekOfYears(this IEnumerable<DateTime?>? dts) => dts.IsNullOEmpty() ? default : dts.Select(x => x.GetWeekOfYear());

    /// <summary>
    /// Determines the week number of the year for each nullable <see cref="DateTime"/> object in a collection (ICollection).
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each nullable <see cref="DateTime"/> object in the collection is evaluated to find its corresponding week number in the year. Null values are ignored.
    /// </summary>
    /// <param name="dts">The ICollection of nullable <see cref="DateTime"/> objects. Can be <see langword="null"/>.</param>
    /// <returns>
    /// An enumerable collection of integers representing the week numbers for each non-null <see cref="DateTime"/> object in the collection, or <see langword="null"/> if the input collection is <see langword="null"/> or empty.
    /// </returns>
    public static IEnumerable<int>? GetWeekOfYears(this ICollection<DateTime?>? dts) => dts.IsNullOEmpty() ? default : dts.Select(x => x.GetWeekOfYear());

    /// <summary>
    /// Determines the week number of the year for each nullable <see cref="DateTime"/> object in an array.
    /// If the array is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each nullable <see cref="DateTime"/> object in the array is evaluated to find its corresponding week number in the year. Null values are ignored.
    /// </summary>
    /// <param name="dts">The array of nullable <see cref="DateTime"/> objects. Can be <see langword="null"/>.</param>
    /// <returns>An array of integers representing the week numbers for each non-null <see cref="DateTime"/> object in the array, or <see langword="null"/> if the input array is <see langword="null"/> or empty.</returns>
    public static IEnumerable<int>? GetWeekOfYears(params DateTime?[]? dts) => dts.IsNullOEmpty() ? default : dts.Select(x => x.GetWeekOfYear());

    /// <summary>
    /// Calculates the total number of months between two <see cref="DateTime"/> objects.
    /// The result is the absolute difference in months, disregarding which date is earlier or later.
    /// </summary>
    /// <param name="dt1">The first <see cref="DateTime"/> object.</param>
    /// <param name="dt2">The second <see cref="DateTime"/> object.</param>
    /// <returns>The absolute difference in months between the two <see cref="DateTime"/> objects.</returns>
    public static int TotalMonth(DateTime dt1, DateTime dt2) => Abs((dt1.Year - dt2.Year) * 12 + dt1.Month - dt2.Month);

    /// <summary>
    /// Adjusts the <see cref="DateTime"/> object to a different time zone based on the specified source and destination time zone offsets.
    /// If the calculated time difference would result in a date and time outside the <see cref="DateTime"/> range, the original <see cref="DateTime"/> is returned.
    /// </summary>
    /// <param name="dt">The <see cref="DateTime"/> object to be adjusted.</param>
    /// <param name="tzSrc">The source time zone offset. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone offset. Can be <see langword="null"/>.</param>
    /// <returns>A <see cref="DateTime"/> object adjusted to the new time zone, or the original <see cref="DateTime"/> if the adjustment is not feasible.</returns>
    public static DateTime ChangeTimeZone(this DateTime dt, object? tzSrc = null, object? tzDst = null)
    {
        var diff = tzDst.To<int>() - tzSrc.To<int>();

        return diff switch
        {
            0 => dt,
            < 0 when (dt - MinValue).TotalHours < Abs(diff) => dt,
            > 0 when (MaxValue - dt).TotalHours < diff => dt,
            _ => dt.AddHours(diff)
        };
    }

    /// <summary>
    /// Adjusts each <see cref="DateTime"/> object in a list to a different time zone based on the specified source and destination time zone offsets.
    /// The adjustment is applied in place, modifying the original list. If the list is <see langword="null"/> or empty, no action is taken.
    /// </summary>
    /// <param name="dts">The list of <see cref="DateTime"/> objects to be adjusted. Can be <see langword="null"/>.</param>
    /// <param name="tzSrc">The source time zone offset. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone offset. Can be <see langword="null"/>.</param>
    public static void ChangeTimeZone(this List<DateTime>? dts, object? tzSrc = null, object? tzDst = null)
    {
        if (dts.IsNullOEmpty())
        {
            return;
        }

        dts.ForEach(x => x = x.ChangeTimeZone(tzSrc, tzDst));
    }

    /// <summary>
    /// Adjusts each <see cref="DateTime"/> object in a collection to a different time zone based on the specified source and destination time zone offsets.
    /// If the collection is <see langword="null"/> or empty, it is returned as-is.
    /// Each <see cref="DateTime"/> object in the collection is adjusted to the new time zone.
    /// </summary>
    /// <param name="dts">The collection of <see cref="DateTime"/> objects to be adjusted. Can be <see langword="null"/>.</param>
    /// <param name="tzSrc">The source time zone offset. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone offset. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of <see cref="DateTime"/> objects adjusted to the new time zone, or the original collection if it is <see langword="null"/> or empty.</returns>
    public static IEnumerable<DateTime>? ChangeTimeZones(this IEnumerable<DateTime>? dts, object? tzSrc = null, object? tzDst = null) => dts.IsNullOEmpty()
        ? dts
        : dts.Select(x => x.ChangeTimeZone(tzSrc, tzDst));

    /// <summary>
    /// Adjusts each <see cref="DateTime"/> object in a collection (ICollection) to a different time zone based on the specified source and destination time zone offsets.
    /// If the collection is <see langword="null"/> or empty, it is returned as-is.
    /// Each <see cref="DateTime"/> object in the collection is adjusted to the new time zone.
    /// </summary>
    /// <param name="dts">The ICollection of <see cref="DateTime"/> objects to be adjusted. Can be <see langword="null"/>.</param>
    /// <param name="tzSrc">The source time zone offset. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone offset. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of <see cref="DateTime"/> objects adjusted to the new time zone, or the original collection if it is <see langword="null"/> or empty.</returns>
    public static IEnumerable<DateTime>? ChangeTimeZones(this ICollection<DateTime>? dts, object? tzSrc = null, object? tzDst = null) => dts.IsNullOEmpty()
        ? dts
        : dts.Select(x => x.ChangeTimeZone(tzSrc, tzDst));

    /// <summary>
    /// Adjusts each <see cref="DateTime"/> object in an array to a different time zone based on the specified source and destination time zone offsets.
    /// If the array is <see langword="null"/> or empty, it is returned as-is.
    /// Each <see cref="DateTime"/> object in the array is adjusted to the new time zone.
    /// </summary>
    /// <param name="dts">The array of <see cref="DateTime"/> objects to be adjusted. Can be <see langword="null"/>.</param>
    /// <param name="tzSrc">The source time zone offset. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone offset. Can be <see langword="null"/>.</param>
    /// <returns>An array of <see cref="DateTime"/> objects adjusted to the new time zone, or the original array if it is <see langword="null"/> or empty.</returns>
    public static IEnumerable<DateTime>? ChangeTimeZones(this DateTime[]? dts, object? tzSrc = null, object? tzDst = null) => dts.IsNullOEmpty()
        ? dts
        : dts.Select(x => x.ChangeTimeZone(tzSrc, tzDst));

    /// <summary>
    /// Adjusts the nullable <see cref="DateTime"/> object to a different time zone based on the specified source and destination time zone offsets.
    /// If the nullable <see cref="DateTime"/> object does not have a value, returns the default <see cref="DateTime"/>.
    /// If the calculated time difference would result in a date and time outside the <see cref="DateTime"/> range, the original <see cref="DateTime"/> is returned.
    /// </summary>
    /// <param name="dt">The nullable <see cref="DateTime"/> object to be adjusted. Can be <see langword="null"/>.</param>
    /// <param name="tzSrc">The source time zone offset. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone offset. Can be <see langword="null"/>.</param>
    /// <returns>A <see cref="DateTime"/> object adjusted to the new time zone, or the original <see cref="DateTime"/> if the adjustment is not feasible or the nullable <see cref="DateTime"/> does not have a value.</returns>
    public static DateTime ChangeTimeZone(this DateTime? dt, object? tzSrc = null, object? tzDst = null)
    {
        if (!dt.HasValue)
        {
            return default;
        }

        var diff = tzDst.To<int>() - tzSrc.To<int>();

        return diff switch
        {
            0 => dt.Value,
            < 0 when (dt.Value - MinValue).TotalHours < Abs(diff) => dt.Value,
            > 0 when (MaxValue - dt.Value).TotalHours < diff => dt.Value,
            _ => dt.Value.AddHours(diff)
        };
    }

    /// <summary>
    /// Adjusts each nullable <see cref="DateTime"/> object in a list to a different time zone based on the specified source and destination time zone offsets.
    /// The adjustment is applied in place, modifying the original list. If the list is <see langword="null"/> or empty, no action is taken.
    /// </summary>
    /// <param name="dts">The list of nullable <see cref="DateTime"/> objects to be adjusted. Can be <see langword="null"/>.</param>
    /// <param name="tzSrc">The source time zone offset. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone offset. Can be <see langword="null"/>.</param>
    public static void ChangeTimeZone(this List<DateTime?>? dts, object? tzSrc = null, object? tzDst = null)
    {
        if (dts.IsNullOEmpty())
        {
            return;
        }

        dts.ForEach(x => x = x.ChangeTimeZone(tzSrc, tzDst));
    }

    /// <summary>
    /// Adjusts each nullable <see cref="DateTime"/> object in a collection to a different time zone based on the specified source and destination time zone offsets.
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each nullable <see cref="DateTime"/> object in the collection is adjusted to the new time zone. Null values are ignored.
    /// </summary>
    /// <param name="dts">The collection of nullable <see cref="DateTime"/> objects to be adjusted. Can be <see langword="null"/>.</param>
    /// <param name="tzSrc">The source time zone offset. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone offset. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of <see cref="DateTime"/> objects adjusted to the new time zone, or <see langword="null"/> if the input collection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<DateTime>? ChangeTimeZones(this IEnumerable<DateTime?>? dts, object? tzSrc = null, object? tzDst = null) => dts.IsNullOEmpty()
        ? default
        : dts.Select(x => x.ChangeTimeZone(tzSrc, tzDst));

    /// <summary>
    /// Adjusts each nullable <see cref="DateTime"/> object in a collection (ICollection) to a different time zone based on the specified source and destination time zone offsets.
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each nullable <see cref="DateTime"/> object in the collection is adjusted to the new time zone. Null values are ignored.
    /// </summary>
    /// <param name="dts">The ICollection of nullable <see cref="DateTime"/> objects to be adjusted. Can be <see langword="null"/>.</param>
    /// <param name="tzSrc">The source time zone offset. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone offset. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of <see cref="DateTime"/> objects adjusted to the new time zone, or <see langword="null"/> if the input collection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<DateTime>? ChangeTimeZones(this ICollection<DateTime?>? dts, object? tzSrc = null, object? tzDst = null) => dts.IsNullOEmpty()
        ? default
        : dts.Select(x => x.ChangeTimeZone(tzSrc, tzDst));

    /// <summary>
    /// Adjusts each nullable <see cref="DateTime"/> object in an array to a different time zone based on the specified source and destination time zone offsets.
    /// If the array is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each nullable <see cref="DateTime"/> object in the array is adjusted to the new time zone. Null values are ignored.
    /// </summary>
    /// <param name="dts">The array of nullable <see cref="DateTime"/> objects to be adjusted. Can be <see langword="null"/>.</param>
    /// <param name="tzSrc">The source time zone offset. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone offset. Can be <see langword="null"/>.</param>
    /// <returns>An array of <see cref="DateTime"/> objects adjusted to the new time zone, or <see langword="null"/> if the input array is <see langword="null"/> or empty.</returns>
    public static IEnumerable<DateTime>? ChangeTimeZones(this DateTime?[]? dts, object? tzSrc = null, object? tzDst = null) => dts.IsNullOEmpty()
        ? default
        : dts.Select(x => x.ChangeTimeZone(tzSrc, tzDst));
}
