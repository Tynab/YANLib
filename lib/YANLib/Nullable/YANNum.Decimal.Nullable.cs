namespace YANLib.Nullable;

public partial class YANNum
{
    
    public static decimal? ToDecimal<T>(this T? num) where T : struct
    {
        try
        {
            return Convert.ToDecimal(num);
        }
        catch
        {
            return default;
        }
    }

    public static IEnumerable<decimal?> ToDecimal<T>(this IEnumerable<T?> nums) where T : struct
    {
        if (nums is null || !nums.Any())
        {
            yield break;
        }
        foreach (var num in nums)
        {
            yield return num.ToDecimal();
        }
    }

    public static decimal? ToDecimal<T>(this string str, T? dfltVal) where T : struct => dfltVal.HasValue ? str.ToDecimal(dfltVal.Value) : default;

    public static IEnumerable<decimal?> ToDecimal<T>(this IEnumerable<string> strs, T? dfltVal) where T : struct
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToDecimal(dfltVal);
        }
    }

    public static decimal? GenerateRandomDecimal<T1, T2>(T1? min, T2 max) where T1 : struct where T2 : struct => min.HasValue ? GenerateRandomDecimal(min.Value, max) : default;

    public static IEnumerable<decimal?> GenerateRandomDecimals<T1, T2, T>(T1? min, T2 max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < YANLib.YANNum.ToUlong(size); i++)
        {
            yield return GenerateRandomDecimal(min, max);
        }
    }

    public static IEnumerable<decimal?> GenerateRandomDecimals<T1, T2, T>(T1? min, T2 max, T? size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < YANLib.YANNum.ToUlong(size); i++)
        {
            yield return GenerateRandomDecimal(min, max);
        }
    }

    public static decimal? GenerateRandomDecimal<T1, T2>(T1 min, T2? max) where T1 : struct where T2 : struct => max.HasValue ? GenerateRandomDecimal(min, max.Value) : default;

    public static IEnumerable<decimal?> GenerateRandomDecimals<T1, T2, T>(T1 min, T2? max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < YANLib.YANNum.ToUlong(size); i++)
        {
            yield return GenerateRandomDecimal(min, max);
        }
    }

    public static IEnumerable<decimal?> GenerateRandomDecimals<T1, T2, T>(T1 min, T2? max, T? size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < YANLib.YANNum.ToUlong(size); i++)
        {
            yield return GenerateRandomDecimal(min, max);
        }
    }

    public static decimal? GenerateRandomDecimal<T1, T2>(T1? min, T2? max) where T1 : struct where T2 : struct => min.HasValue ? GenerateRandomDecimal(min.Value, max) : default;

    public static IEnumerable<decimal?> GenerateRandomDecimals<T1, T2, T>(T1? min, T2? max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < YANLib.YANNum.ToUlong(size); i++)
        {
            yield return GenerateRandomDecimal(min, max);
        }
    }

    public static IEnumerable<decimal?> GenerateRandomDecimals<T1, T2, T>(T1? min, T2? max, T? size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < YANLib.YANNum.ToUlong(size); i++)
        {
            yield return GenerateRandomDecimal(min, max);
        }
    }

    public static decimal? GenerateRandomDecimal<T>(T? max) where T : struct => max.HasValue ? GenerateRandomDecimal(decimal.MinValue, max.Value) : default;
}
