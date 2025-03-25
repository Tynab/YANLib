using YANLib.Object;
using YANLib.Text;
using YANLib.Unmanaged;
using static System.DateTime;
using static System.Globalization.DateTimeFormatInfo;
using static System.Linq.Enumerable;
using static System.Math;

namespace YANLib;

public static partial class YANDateTime
{
    public static T? GetWeekOfYear<T>(this object? input) where T : unmanaged
    {
        var dt = input.Parse<DateTime?>();

        return dt.HasValue ? CurrentInfo.Calendar.GetWeekOfYear(dt.Value, CurrentInfo.CalendarWeekRule, CurrentInfo.FirstDayOfWeek).Parse<T?>() : default;
    }

    public static IEnumerable<T?>? GetWeekOfYears<T>(this IEnumerable<object?>? input) where T : unmanaged => input.IsNullEmpty() ? default : input.Select(x => x.GetWeekOfYear<T>());

    public static IEnumerable<T?>? GetWeekOfYears<T>(params object?[]? input) where T : unmanaged => input.IsNullEmpty() ? default : input.Select(x => x.GetWeekOfYear<T>());

    public static T? TotalMonth<T>(object? input1, object? input2) where T : unmanaged
    {
        var dt1 = input1.Parse<DateTime?>();
        var dt2 = input2.Parse<DateTime?>();

        return dt1.HasValue && dt2.HasValue ? Abs((dt1.Value.Year - dt2.Value.Year) * 12 + dt1.Value.Month - dt2.Value.Month).Parse<T?>() : default;
    }

    public static DateTime ChangeTimeZone(this object? input, object? tzSrc = null, object? tzDst = null)
    {
        var dt = input.Parse<DateTime?>();

        if (dt.HasValue)
        {
            var diff = tzDst.Parse<int>() - tzSrc.Parse<int>();

            return diff switch
            {
                0 => dt.Value,
                < 0 when (dt.Value - MinValue).TotalHours < Abs(diff) => dt.Value,
                > 0 when (MaxValue - dt.Value).TotalHours < diff => dt.Value,
                _ => dt.Value.AddHours(diff)
            };
        }

        return default;
    }

    public static void ChangeTimeZone(this List<object?>? input, object? tzSrc = null, object? tzDst = null)
    {
        if (input.IsNullEmpty())
        {
            return;
        }

        input.ForEach(x => x = x.ChangeTimeZone(tzSrc, tzDst));
    }

    public static IEnumerable<DateTime>? ChangeTimeZones(this IEnumerable<object?>? input, object? tzSrc = null, object? tzDst = null) => input.IsNullEmpty() ? default : input.Select(x => x.ChangeTimeZone(tzSrc, tzDst));

    public static IEnumerable<DateTime>? ChangeTimeZones(this ICollection<object?>? input, object? tzSrc = null, object? tzDst = null) => input.IsNullEmpty() ? default : input.Select(x => x.ChangeTimeZone(tzSrc, tzDst));

    public static IEnumerable<DateTime>? ChangeTimeZones(this object?[]? input, object? tzSrc = null, object? tzDst = null) => input.IsNullEmpty() ? default : input.Select(x => x.ChangeTimeZone(tzSrc, tzDst));
}
