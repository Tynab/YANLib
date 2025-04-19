using System.Diagnostics;
using YANLib.Implementation.Object;
using YANLib.Implementation.Unmanaged;
using static System.Globalization.DateTimeFormatInfo;
using static System.Linq.Enumerable;
using static System.Math;

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
        => input.IsNullEmptyImplement() ? default : input.GetCountImplement() < 1_000 ? input.Select(static x => x.GetWeekOfYearImplement<T>()) : input.AsParallel().Select(x => x.GetWeekOfYearImplement<T>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? TotalMonthImplement<T>(object? input1, object? input2) where T : unmanaged
    {
        var dt1 = input1.ParseImplement<DateTime?>();
        var dt2 = input2.ParseImplement<DateTime?>();

        return dt1.HasValue && dt2.HasValue ? Abs((dt1.Value.Year - dt2.Value.Year) * 12 + dt1.Value.Month - dt2.Value.Month).ParseImplement<T?>() : default;
    }
}
