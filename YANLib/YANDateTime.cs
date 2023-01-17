using System;
using System.Collections.Generic;
using System.Globalization;
using static System.Globalization.DateTimeFormatInfo;
using static System.Globalization.CultureInfo;
using static System.Globalization.DateTimeStyles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.DateTime;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;

namespace YANLib;

public static class YANDateTime
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
    /// Get week of year advanced.
    /// </summary>
    /// <param name="dt">Input datetime.</param>
    /// <returns>Number week of year.</returns>
    public static int GetWeekOfYear(this DateTime dt) => CurrentInfo.Calendar.GetWeekOfYear(dt, CurrentInfo.CalendarWeekRule, CurrentInfo.FirstDayOfWeek);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dt1"></param>
    /// <param name="dt2"></param>
    /// <returns></returns>
    public static int TotalMonths(DateTime dt1, DateTime dt2) => Math.Abs((dt1.Year - dt2.Year) * 12 + dt1.Month - dt2.Month);
}
