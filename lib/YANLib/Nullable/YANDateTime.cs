using static System.DateTime;
using static System.Globalization.CultureInfo;
using static System.Globalization.DateTimeFormatInfo;
using static System.Globalization.DateTimeStyles;
using static System.Math;
using static YANLib.YANNum;

namespace YANLib.Nullable;

public static partial class YANDateTime
{
    
    public static DateTime? ToDateTime(this string str) => TryParse(str, out var dt) ? dt : default;

    
    public static IEnumerable<DateTime?> ToDateTime(this IEnumerable<string> strs)
    {
        if (strs.IsNullOrWhiteSpace())
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.ToDateTime();
        }
    }

    
    public static DateTime? ToDateTime(this string str, string fmt) => TryParseExact(str, fmt, InvariantCulture, None, out var dt) ? dt : default;

    
    public static IEnumerable<DateTime?> ToDateTime(this IEnumerable<string> strs, string fmt)
    {
        if (strs.IsNullOrWhiteSpace())
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.ToDateTime(fmt);
        }
    }

    
    public static DateTime? ToDateTime(this string str, string fmt, DateTime dfltVal) => TryParseExact(str, fmt, InvariantCulture, None, out var dt) ? dt : dfltVal;

    
    public static IEnumerable<DateTime?> ToDateTime(this IEnumerable<string> strs, string fmt, DateTime dfltVal)
    {
        if (strs.IsNullOrWhiteSpace())
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.ToDateTime(fmt, dfltVal);
        }
    }

    
    public static DateTime? GenerateRandomDateTime(DateTime min, DateTime max) => min > max ? default : min.AddTicks(GenerateRandomLong((max - min).Ticks));

    
    public static IEnumerable<DateTime?> GenerateRandomDateTimes<T>(DateTime min, DateTime max, T size) where T : struct
    {
        for (var i = 0ul; i < YANNum.ToUlong(size); i++)
        {
            yield return GenerateRandomDateTime(min, max);
        }
    }

    
    public static DateTime? GenerateRandomDateTime() => GenerateRandomDateTime(MinValue, MaxValue);

    
    public static DateTime? GenerateRandomDateTime(DateTime max) => GenerateRandomDateTime(max > Today ? Today : MinValue, max);

    
    public static int? GetWeekOfYear(this DateTime dt) => CurrentInfo.Calendar.GetWeekOfYear(dt, CurrentInfo.CalendarWeekRule, CurrentInfo.FirstDayOfWeek);

    
    public static IEnumerable<int?> GetWeekOfYear(this IEnumerable<DateTime> dts)
    {
        if (dts is null || !dts.Any())
        {
            yield break;
        }
        foreach (var dt in dts)
        {
            yield return dt.GetWeekOfYear();
        }
    }

    
    public static int? TotalMonths(DateTime dt1, DateTime dt2) => Abs((dt1.Year - dt2.Year) * 12 + dt1.Month - dt2.Month);

    
    public static DateTime? ChangeTimeZone<T1, T2>(this DateTime dt, T1 tzSrc, T2 tzDst) where T1 : struct where T2 : struct
    {
        var diff = tzDst.ToInt() - tzSrc.ToInt();
        return diff.HasValue ? diff switch
        {
            < 0 when (dt - MinValue).TotalHours < Abs(diff.Value) => default,
            > 0 when (MaxValue - dt).TotalHours < diff => default,
            _ => dt.AddHours(diff.Value)
        } : default;
    }

    
    public static IEnumerable<DateTime?> ChangeTimeZone<T1, T2>(this IEnumerable<DateTime> dts, T1 tzSrc, T2 tzDst) where T1 : struct where T2 : struct
    {
        if (dts is null || !dts.Any())
        {
            yield break;
        }
        foreach (var dt in dts)
        {
            yield return dt.ChangeTimeZone(tzSrc, tzDst);
        }
    }

    
    public static DateTime? ChangeTimeZone<T>(this DateTime dt, T tzDst) where T : struct => dt.ChangeTimeZone(0, tzDst);

    
    public static IEnumerable<DateTime?> ChangeTimeZone<T>(this IEnumerable<DateTime> dts, T tzDst) where T : struct
    {
        if (dts is null || !dts.Any())
        {
            yield break;
        }
        foreach (var dt in dts)
        {
            yield return dt.ChangeTimeZone(tzDst);
        }
    }
}
