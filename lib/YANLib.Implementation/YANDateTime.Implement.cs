using System.Diagnostics;
using YANLib.Implementation.Object;
using YANLib.Implementation.Unmanaged;
using static System.DateTime;
using static System.Globalization.DateTimeFormatInfo;
using static System.Linq.Enumerable;
using static System.Math;
using static System.Threading.Tasks.Parallel;

namespace YANLib.Implementation;

internal static partial class YANDateTime
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? GetWeekOfYearImplement<T>(this object? input) where T : unmanaged
    {
        var dt = input.ParseImplement<DateTime?>();

        return dt.HasValue ? CurrentInfo.Calendar.GetWeekOfYear(dt.Value, CurrentInfo.CalendarWeekRule, CurrentInfo.FirstDayOfWeek).ParseImplement<T?>() : default;
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? GetWeekOfYearsImplement<T>(this IEnumerable<object?>? input) where T : unmanaged
        => input.IsNullEmptyImplement() ? default : input.Count() < 1_000 ? input.Select(x => x.GetWeekOfYearImplement<T>()) : input.AsParallel().Select(x => x.GetWeekOfYearImplement<T>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? TotalMonthImplement<T>(object? input1, object? input2) where T : unmanaged
    {
        var dt1 = input1.ParseImplement<DateTime?>();
        var dt2 = input2.ParseImplement<DateTime?>();

        return dt1.HasValue && dt2.HasValue ? Abs((dt1.Value.Year - dt2.Value.Year) * 12 + dt1.Value.Month - dt2.Value.Month).ParseImplement<T?>() : default;
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static DateTime ChangeTimeZoneImplement(this object? input, object? tzSrc = null, object? tzDst = null)
    {
        var dt = input.ParseImplement<DateTime?>();

        if (dt.HasValue)
        {
            var diff = tzDst.ParseImplement<int>() - tzSrc.ParseImplement<int>();

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

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static void ChangeTimeZoneImplement(this List<object?>? input, object? tzSrc = null, object? tzDst = null)
    {
        if (input.IsNullEmptyImplement())
        {
            return;
        }

        if (input.Count < 1_000)
        {
            for (var i = 0; i < input.Count; i++)
            {
                input[i] = input[i].ChangeTimeZoneImplement(tzSrc, tzDst);
            }
        }
        else
        {
            _ = For(0, input.Count, i => input[i] = input[i].ChangeTimeZoneImplement(tzSrc, tzDst));
        }
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<DateTime>? ChangeTimeZonesImplement(this IEnumerable<object?>? input, object? tzSrc = null, object? tzDst = null)
        => input.IsNullEmptyImplement() ? default : input.Count() < 1_000 ? input.Select(x => x.ChangeTimeZoneImplement(tzSrc, tzDst)) : input.AsParallel().Select(x => x.ChangeTimeZoneImplement(tzSrc, tzDst));
}
