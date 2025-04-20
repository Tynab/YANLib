using System.Diagnostics;
using YANLib.Implementation.Object;
using static System.Globalization.DateTimeFormatInfo;
using static System.Linq.Enumerable;

namespace YANLib.Implementation.Unmanaged;

internal static partial class YANDateTime
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? GetWeekOfYearImplement<T>(this object? input)
    {
        var dt = input is DateTime d ? d : input.ParseImplement<DateTime?>();

        return dt.HasValue ? CurrentInfo.Calendar.GetWeekOfYear(dt.Value, CurrentInfo.CalendarWeekRule, CurrentInfo.FirstDayOfWeek).ParseImplement<T?>() : default;
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? GetWeekOfYearsImplement<T>(this IEnumerable<object?>? input)
        => input.IsNullEmptyImplement() ? default : input.GetCountImplement() < 1_000 ? input.Select(static x => x.GetWeekOfYearImplement<T>()) : input.AsParallel().Select(x => x.GetWeekOfYearImplement<T>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? TotalMonthImplement<T>(object? input1, object? input2)
    {
        var dt1 = input1 is DateTime d1 ? d1 : input1.ParseImplement<DateTime?>();
        var dt2 = input2 is DateTime d2 ? d2 : input2.ParseImplement<DateTime?>();

        return dt1.HasValue && dt2.HasValue ? ((dt1.Value.Year - dt2.Value.Year) * 12 + dt1.Value.Month - dt2.Value.Month).AbsImplement().ParseImplement<T?>() : default;
    }
}
