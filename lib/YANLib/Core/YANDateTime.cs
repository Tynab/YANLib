using static System.DateTime;
using static System.Globalization.CultureInfo;
using static System.Globalization.DateTimeFormatInfo;
using static System.Globalization.DateTimeStyles;
using static System.Linq.Enumerable;
using static System.Math;
using static YANLib.Core.YANNum;

namespace YANLib.Core;

public static partial class YANDateTime
{
    public static DateTime ToDateTime(this string? str, string? fmt = null, DateTime dfltVal = default) => str.IsWhiteSpaceOrNull()
        ? dfltVal
        : fmt.IsWhiteSpaceOrNull()
        ? TryParse(str, out var dt)
            ? dt
            : dfltVal
        : TryParseExact(str, fmt, InvariantCulture, None, out dt)
        ? dt
        : dfltVal;

    public static IEnumerable<DateTime>? ToDateTimes(this IEnumerable<string?>? strs, string? fmt = null, DateTime dfltVal = default) => strs.IsEmptyOrNull()
        ? default
        : strs.Select(x => x.ToDateTime(fmt, dfltVal));

    public static IEnumerable<DateTime>? ToDateTimes(this ICollection<string?>? strs, string? fmt = null, DateTime dfltVal = default) => strs.IsEmptyOrNull()
        ? default
        : strs.Select(x => x.ToDateTime(fmt, dfltVal));

    public static IEnumerable<DateTime>? ToDateTimes(this string?[]? strs, string? fmt = null, DateTime dfltVal = default) => strs.IsEmptyOrNull()
        ? default
        : strs.Select(x => x.ToDateTime(fmt, dfltVal));

    /// <summary>
    /// Generates a random <see cref="DateTime"/> object between the specified minimum and maximum values.
    /// If the minimum value is greater than the maximum value, returns the default <see cref="DateTime"/>.
    /// </summary>
    /// <param name="min">The minimum <see cref="DateTime"/> value that can be generated.</param>
    /// <param name="max">The maximum <see cref="DateTime"/> value that can be generated.</param>
    /// <returns>A randomly generated <see cref="DateTime"/> object between the specified minimum and maximum values, or the default <see cref="DateTime"/> if min is greater than max.</returns>
    public static DateTime GenerateRandomDateTime(DateTime min, DateTime max) => min > max ? default : min.AddTicks((long)GenerateRandomUlong((max - min).Ticks));

    /// <summary>
    /// Generates a collection of random <see cref="DateTime"/> objects of the specified size, each within the specified minimum and maximum range.
    /// If the specified size is invalid (non-positive), yields no results.
    /// </summary>
    /// <param name="size">The number of random <see cref="DateTime"/> objects to generate. The size is converted to an integer and should be a positive value.</param>
    /// <param name="min">The minimum <see cref="DateTime"/> value that can be generated for each object.</param>
    /// <param name="max">The maximum <see cref="DateTime"/> value that can be generated for each object.</param>
    /// <returns>An enumerable collection of randomly generated <see cref="DateTime"/> objects within the specified range.</returns>
    public static IEnumerable<DateTime> GenerateRandomDateTimes(object? size, DateTime min, DateTime max) => Range(0, (int)size.ToUint()).Select(i => GenerateRandomDateTime(min, max));

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

    public static IEnumerable<int>? GetWeekOfYears(this IEnumerable<DateTime>? dts) => dts.IsEmptyOrNull() ? default : dts.Select(x => x.GetWeekOfYear());

    public static IEnumerable<int>? GetWeekOfYears(this ICollection<DateTime>? dts) => dts.IsEmptyOrNull() ? default : dts.Select(x => x.GetWeekOfYear());

    public static IEnumerable<int>? GetWeekOfYears(params DateTime[]? dts) => dts.IsEmptyOrNull() ? default : dts.Select(x => x.GetWeekOfYear());

    public static IEnumerable<int>? GetWeekOfYears(this IEnumerable<DateTime?>? dts) => dts.IsEmptyOrNull() ? default : dts.Select(x => x.GetWeekOfYear());

    public static IEnumerable<int>? GetWeekOfYears(this ICollection<DateTime?>? dts) => dts.IsEmptyOrNull() ? default : dts.Select(x => x.GetWeekOfYear());

    public static IEnumerable<int>? GetWeekOfYears(params DateTime?[]? dts) => dts.IsEmptyOrNull() ? default : dts.Select(x => x.GetWeekOfYear());

    public static int TotalMonth(DateTime dt1, DateTime dt2) => Abs((dt1.Year - dt2.Year) * 12 + dt1.Month - dt2.Month);

    public static DateTime ChangeTimeZone(this DateTime dt, object? tzSrc = null, object? tzDst = null)
    {
        var diff = tzDst.ToInt() - tzSrc.ToInt();

        return diff switch
        {
            0 => dt,
            < 0 when (dt - MinValue).TotalHours < Abs(diff) => dt,
            > 0 when (MaxValue - dt).TotalHours < diff => dt,
            _ => dt.AddHours(diff)
        };
    }

    public static DateTime ChangeTimeZone(this DateTime? dt, object? tzSrc = null, object? tzDst = null)
    {
        if (!dt.HasValue)
        {
            return default;
        }

        var diff = tzDst.ToInt() - tzSrc.ToInt();

        return diff switch
        {
            0 => dt.Value,
            < 0 when (dt.Value - MinValue).TotalHours < Abs(diff) => dt.Value,
            > 0 when (MaxValue - dt.Value).TotalHours < diff => dt.Value,
            _ => dt.Value.AddHours(diff)
        };
    }

    public static void ChangeTimeZone(this List<DateTime>? dts, object? tzSrc = null, object? tzDst = null)
    {
        if (dts.IsEmptyOrNull())
        {
            return;
        }

        dts.ForEach(x => x = x.ChangeTimeZone(tzSrc, tzDst));
    }

    public static IEnumerable<DateTime>? ChangeTimeZones(this IEnumerable<DateTime>? dts, object? tzSrc = null, object? tzDst = null) => dts.IsEmptyOrNull()
        ? dts
        : dts.Select(x => x.ChangeTimeZone(tzSrc, tzDst));

    public static IEnumerable<DateTime>? ChangeTimeZones(this ICollection<DateTime>? dts, object? tzSrc = null, object? tzDst = null) => dts.IsEmptyOrNull()
        ? dts
        : dts.Select(x => x.ChangeTimeZone(tzSrc, tzDst));

    public static IEnumerable<DateTime>? ChangeTimeZones(this DateTime[]? dts, object? tzSrc = null, object? tzDst = null) => dts.IsEmptyOrNull()
        ? dts
        : dts.Select(x => x.ChangeTimeZone(tzSrc, tzDst));

    public static void ChangeTimeZone(this List<DateTime?>? dts, object? tzSrc = null, object? tzDst = null)
    {
        if (dts.IsEmptyOrNull())
        {
            return;
        }

        dts.ForEach(x => x = x.ChangeTimeZone(tzSrc, tzDst));
    }

    public static IEnumerable<DateTime>? ChangeTimeZones(this IEnumerable<DateTime?>? dts, object? tzSrc = null, object? tzDst = null) => dts.IsEmptyOrNull()
        ? default
        : dts.Select(x => x.ChangeTimeZone(tzSrc, tzDst));

    public static IEnumerable<DateTime>? ChangeTimeZones(this ICollection<DateTime?>? dts, object? tzSrc = null, object? tzDst = null) => dts.IsEmptyOrNull()
        ? default
        : dts.Select(x => x.ChangeTimeZone(tzSrc, tzDst));

    public static IEnumerable<DateTime>? ChangeTimeZones(this DateTime?[]? dts, object? tzSrc = null, object? tzDst = null) => dts.IsEmptyOrNull()
        ? default
        : dts.Select(x => x.ChangeTimeZone(tzSrc, tzDst));
}
