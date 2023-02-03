using static System.DateTime;
using static System.Globalization.CultureInfo;
using static System.Globalization.DateTimeFormatInfo;
using static System.Globalization.DateTimeStyles;
using static System.Math;

namespace YANLib;

public static partial class YANDateTime
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static DateTime ParseDateTime(string s) => TryParse(s, out var dt) ? dt : Today;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="fmt"></param>
    /// <returns></returns>
    public static DateTime ParseDateTime(string s, string fmt) => TryParseExact(s, fmt, InvariantCulture, None, out var dt) ? dt : Today;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="fmt"></param>
    /// <param name="dfltVal"></param>
    /// <returns></returns>
    public static DateTime ParseDateTime(string s, string fmt, DateTime dfltVal) => TryParseExact(s, fmt, InvariantCulture, None, out var dt) ? dt : dfltVal;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="fmt"></param>
    /// <returns></returns>
    public static DateTime ParseDateTimeMin(string s, string fmt) => TryParseExact(s, fmt, InvariantCulture, None, out var dt) ? dt : MinValue;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="fmt"></param>
    /// <returns></returns>
    public static DateTime ParseDateTimeMax(string s, string fmt) => TryParseExact(s, fmt, InvariantCulture, None, out var dt) ? dt : MaxValue;

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static DateTime RandomDateTime() => MinValue.AddDays(new Random().Next((MaxValue - MinValue).Days));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="max"></param>
    /// <returns></returns>
    public static DateTime RandomDateTime(DateTime max) => (max > Today ? Today : MinValue).AddDays(new Random().Next((MaxValue - MinValue).Days));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static DateTime RandomDateTime(DateTime min, DateTime max) => min > max ? Today : min.AddDays(new Random().Next((MaxValue - MinValue).Days));

    /// <summary>
    /// Returns the week of year that includes the date in the specified <see cref="DateTime"/> value.
    /// </summary>
    /// <param name="dt">Input datetime.</param>
    /// <returns>The positive integer that represents the week of the year that includes the date in the <paramref name="dt"/> parameter.</returns>
    public static int GetWeekOfYear(this DateTime dt) => CurrentInfo.Calendar.GetWeekOfYear(dt, CurrentInfo.CalendarWeekRule, CurrentInfo.FirstDayOfWeek);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dt1"></param>
    /// <param name="dt2"></param>
    /// <returns></returns>
    public static int TotalMonths(DateTime dt1, DateTime dt2) => Abs((dt1.Year - dt2.Year) * 12 + dt1.Month - dt2.Month);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="tzSrc"></param>
    /// <param name="tzDst"></param>
    /// <returns></returns>
    public static DateTime ChangeTimeZone(this DateTime dt, int tzSrc, int tzDst)
    {
        var diff = tzDst - tzSrc;
        if (diff < 0 && (dt - MinValue).TotalHours >= Abs(diff))
        {
            dt.AddHours(diff);
        }
        else if (diff > 0 && (MaxValue - dt).TotalHours >= diff)
        {
            dt.AddHours(diff);
        }
        return dt;
    }
}
