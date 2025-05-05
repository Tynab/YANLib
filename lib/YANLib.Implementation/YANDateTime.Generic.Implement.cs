using System.Diagnostics;
using static System.Globalization.DateTimeFormatInfo;

namespace YANLib.Implementation;

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
    internal static T? TotalMonthImplement<T>(object? input1, object? input2)
    {
        var dt1 = input1 is DateTime d1 ? d1 : input1.ParseImplement<DateTime?>();
        var dt2 = input2 is DateTime d2 ? d2 : input2.ParseImplement<DateTime?>();

        return dt1.HasValue && dt2.HasValue ? ((dt1.Value.Year - dt2.Value.Year) * 12 + dt1.Value.Month - dt2.Value.Month).AbsImplement().ParseImplement<T?>() : default;
    }
}
