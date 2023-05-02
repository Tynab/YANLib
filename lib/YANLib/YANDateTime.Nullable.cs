using static System.DateTime;

namespace YANLib;

public static partial class YANDateTime
{
    
    public static DateTime ToDateTime(this string str, string fmt, DateTime? dfltVal) => dfltVal.HasValue ? str.ToDateTime(fmt, dfltVal.Value) : default;

    public static IEnumerable<DateTime> ToDateTime(this IEnumerable<string> strs, string fmt, DateTime? dfltVal)
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

    public static DateTime GenerateRandomDateTime(DateTime? min, DateTime max) => min.HasValue ? GenerateRandomDateTime(min.Value, max) : default;

    public static IEnumerable<DateTime> GenerateRandomDateTimes<T>(DateTime? min, DateTime max, T size) where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomDateTime(min, max);
        }
    }

    public static IEnumerable<DateTime> GenerateRandomDateTimes<T>(DateTime? min, DateTime max, T? size) where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomDateTime(min, max);
        }
    }

    public static DateTime GenerateRandomDateTime(DateTime min, DateTime? max) => max.HasValue ? GenerateRandomDateTime(min, max.Value) : default;

    public static IEnumerable<DateTime> GenerateRandomDateTimes<T>(DateTime min, DateTime? max, T size) where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomDateTime(min, max);
        }
    }

    public static IEnumerable<DateTime> GenerateRandomDateTimes<T>(DateTime min, DateTime? max, T? size) where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomDateTime(min, max);
        }
    }

    public static DateTime GenerateRandomDateTime(DateTime? min, DateTime? max) => min.HasValue ? GenerateRandomDateTime(min.Value, max) : GenerateRandomDateTime(max);

    public static IEnumerable<DateTime> GenerateRandomDateTimes<T>(DateTime? min, DateTime? max, T size) where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomDateTime(min, max);
        }
    }

    public static IEnumerable<DateTime> GenerateRandomDateTimes<T>(DateTime? min, DateTime? max, T? size) where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomDateTime(min, max);
        }
    }

    public static DateTime GenerateRandomDateTime(DateTime? max) => max.HasValue ? GenerateRandomDateTime(max.Value) : default;

    public static int GetWeekOfYear(this DateTime? dt) => dt.HasValue ? dt.Value.GetWeekOfYear() : default;

    public static IEnumerable<int> GetWeekOfYear(this IEnumerable<DateTime?> dts)
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

    public static int TotalMonths(DateTime? dt1, DateTime dt2) => dt1.HasValue ? TotalMonths(dt1.Value, dt2) : default;

    public static int TotalMonths(DateTime dt1, DateTime? dt2) => dt2.HasValue ? TotalMonths(dt1, dt2.Value) : default;

    public static int TotalMonths(DateTime? dt1, DateTime? dt2) => dt1.HasValue ? TotalMonths(dt1.Value, dt2) : default;

    public static DateTime ChangeTimeZone<T1, T2>(this DateTime? dt, T1 tzSrc, T2 tzDst) where T1 : struct where T2 : struct => dt.HasValue ? dt.Value.ChangeTimeZone(tzSrc, tzDst) : default;

    public static IEnumerable<DateTime> ChangeTimeZone<T1, T2>(this IEnumerable<DateTime?> dts, T1 tzSrc, T2 tzDst) where T1 : struct where T2 : struct
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

    public static void ChangeTimeZone<T1, T2>(this IList<DateTime?> dts, T1 tzSrc, T2 tzDst) where T1 : struct where T2 : struct
    {
        if (dts is not null && dts.Count > 0)
        {
            for (var i = 0; i < dts.Count; i++)
            {
                dts[i] = dts[i].ChangeTimeZone(tzSrc, tzDst);
            }
        }
    }

    public static DateTime ChangeTimeZone<T1, T2>(this DateTime dt, T1? tzSrc, T2 tzDst) where T1 : struct where T2 : struct => tzSrc.HasValue ? dt.ChangeTimeZone(tzSrc.Value, tzDst) : dt.ChangeTimeZone(tzDst);

    public static IEnumerable<DateTime> ChangeTimeZone<T1, T2>(this IEnumerable<DateTime> dts, T1? tzSrc, T2 tzDst) where T1 : struct where T2 : struct
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

    public static void ChangeTimeZone<T1, T2>(this IList<DateTime> dts, T1? tzSrc, T2 tzDst) where T1 : struct where T2 : struct
    {
        if (dts is not null && dts.Count > 0)
        {
            for (var i = 0; i < dts.Count; i++)
            {
                dts[i] = dts[i].ChangeTimeZone(tzSrc, tzDst);
            }
        }
    }

    public static DateTime ChangeTimeZone<T1, T2>(this DateTime dt, T1 tzSrc, T2? tzDst) where T1 : struct where T2 : struct => tzDst.HasValue ? dt.ChangeTimeZone(tzSrc, tzDst.Value) : dt;

    public static IEnumerable<DateTime> ChangeTimeZone<T1, T2>(this IEnumerable<DateTime> dts, T1 tzSrc, T2? tzDst) where T1 : struct where T2 : struct
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

    public static void ChangeTimeZone<T1, T2>(this IList<DateTime> dts, T1 tzSrc, T2? tzDst) where T1 : struct where T2 : struct
    {
        if (dts is not null && dts.Count > 0)
        {
            for (var i = 0; i < dts.Count; i++)
            {
                dts[i] = dts[i].ChangeTimeZone(tzSrc, tzDst);
            }
        }
    }

    public static DateTime ChangeTimeZone<T1, T2>(this DateTime? dt, T1? tzSrc, T2 tzDst) where T1 : struct where T2 : struct => dt.HasValue ? dt.Value.ChangeTimeZone(tzSrc, tzDst) : default;

    public static IEnumerable<DateTime> ChangeTimeZone<T1, T2>(this IEnumerable<DateTime?> dts, T1? tzSrc, T2 tzDst) where T1 : struct where T2 : struct
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

    public static void ChangeTimeZone<T1, T2>(this IList<DateTime?> dts, T1? tzSrc, T2 tzDst) where T1 : struct where T2 : struct
    {
        if (dts is not null && dts.Count > 0)
        {
            for (var i = 0; i < dts.Count; i++)
            {
                dts[i] = dts[i].ChangeTimeZone(tzSrc, tzDst);
            }
        }
    }

    public static DateTime ChangeTimeZone<T1, T2>(this DateTime? dt, T1 tzSrc, T2? tzDst) where T1 : struct where T2 : struct => dt.HasValue ? dt.Value.ChangeTimeZone(tzSrc, tzDst) : default;

    public static IEnumerable<DateTime> ChangeTimeZone<T1, T2>(this IEnumerable<DateTime?> dts, T1 tzSrc, T2? tzDst) where T1 : struct where T2 : struct
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

    public static void ChangeTimeZone<T1, T2>(this IList<DateTime?> dts, T1 tzSrc, T2? tzDst) where T1 : struct where T2 : struct
    {
        if (dts is not null && dts.Count > 0)
        {
            for (var i = 0; i < dts.Count; i++)
            {
                dts[i] = dts[i].ChangeTimeZone(tzSrc, tzDst);
            }
        }
    }

    public static DateTime ChangeTimeZone<T1, T2>(this DateTime dt, T1? tzSrc, T2? tzDst) where T1 : struct where T2 : struct => tzSrc.HasValue ? dt.ChangeTimeZone(tzSrc.Value, tzDst) : dt.ChangeTimeZone(tzDst);

    public static IEnumerable<DateTime> ChangeTimeZone<T1, T2>(this IEnumerable<DateTime> dts, T1? tzSrc, T2? tzDst) where T1 : struct where T2 : struct
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

    public static void ChangeTimeZone<T1, T2>(this IList<DateTime> dts, T1? tzSrc, T2? tzDst) where T1 : struct where T2 : struct
    {
        if (dts is not null && dts.Count > 0)
        {
            for (var i = 0; i < dts.Count; i++)
            {
                dts[i] = dts[i].ChangeTimeZone(tzSrc, tzDst);
            }
        }
    }

    public static DateTime ChangeTimeZone<T1, T2>(this DateTime? dt, T1? tzSrc, T2? tzDst) where T1 : struct where T2 : struct => dt.HasValue ? dt.Value.ChangeTimeZone(tzSrc, tzDst) : default;

    public static IEnumerable<DateTime> ChangeTimeZone<T1, T2>(this IEnumerable<DateTime?> dts, T1? tzSrc, T2? tzDst) where T1 : struct where T2 : struct
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

    public static void ChangeTimeZone<T1, T2>(this IList<DateTime?> dts, T1? tzSrc, T2? tzDst) where T1 : struct where T2 : struct
    {
        if (dts is not null && dts.Count > 0)
        {
            for (var i = 0; i < dts.Count; i++)
            {
                dts[i] = dts[i].ChangeTimeZone(tzSrc, tzDst);
            }
        }
    }

    public static DateTime ChangeTimeZone<T>(this DateTime? dt, T tzDst) where T : struct => dt.ChangeTimeZone(0, tzDst);

    public static IEnumerable<DateTime> ChangeTimeZone<T>(this IEnumerable<DateTime?> dts, T tzDst) where T : struct
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

    public static void ChangeTimeZone<T>(this IList<DateTime?> dts, T tzDst) where T : struct
    {
        if (dts is not null && dts.Count > 0)
        {
            for (var i = 0; i < dts.Count; i++)
            {
                dts[i] = dts[i].ChangeTimeZone(tzDst);
            }
        }
    }

    public static DateTime ChangeTimeZone<T>(this DateTime dt, T? tzDst) where T : struct => dt.ChangeTimeZone(0, tzDst);

    public static IEnumerable<DateTime> ChangeTimeZone<T>(this IEnumerable<DateTime> dts, T? tzDst) where T : struct
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

    public static void ChangeTimeZone<T>(this IList<DateTime> dts, T? tzDst) where T : struct
    {
        if (dts is not null && dts.Count > 0)
        {
            for (var i = 0; i < dts.Count; i++)
            {
                dts[i] = dts[i].ChangeTimeZone(tzDst);
            }
        }
    }

    public static DateTime ChangeTimeZone<T>(this DateTime? dt, T? tzDst) where T : struct => dt.ChangeTimeZone(0, tzDst);

    public static IEnumerable<DateTime> ChangeTimeZone<T>(this IEnumerable<DateTime?> dts, T? tzDst) where T : struct
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

    public static void ChangeTimeZone<T>(this IList<DateTime?> dts, T? tzDst) where T : struct
    {
        if (dts is not null && dts.Count > 0)
        {
            for (var i = 0; i < dts.Count; i++)
            {
                dts[i] = dts[i].ChangeTimeZone(tzDst);
            }
        }
    }
}
