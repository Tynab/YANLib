namespace YANLib.Nullable;

public partial class YANNum
{
    
    public static long? ToLong<T>(this T num) where T : struct
    {
        try
        {
            return Convert.ToInt64(num);
        }
        catch
        {
            return default;
        }
    }

    public static IEnumerable<long?> ToLong<T>(this IEnumerable<T> nums) where T : struct
    {
        if (nums is null || !nums.Any())
        {
            yield break;
        }
        foreach (var num in nums)
        {
            yield return num.ToLong();
        }
    }

    public static long? ToLong(this string str) => long.TryParse(str, out var num) ? num : default;

    public static IEnumerable<long?> ToLong(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToLong();
        }
    }

    public static long? ToLong<T>(this string str, T dfltVal) where T : struct => long.TryParse(str, out var num) ? num : dfltVal.ToLong();

    public static IEnumerable<long?> ToLong<T>(this IEnumerable<string> strs, T dfltVal) where T : struct
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToLong(dfltVal);
        }
    }

    public static long? GenerateRandomLong<T1, T2>(T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToLong();
        var maxValue = max.ToLong();
        return minValue.HasValue && maxValue.HasValue ? minValue > maxValue ? default : new Random().NextInt64(minValue.Value, maxValue.Value) : default;
    }

    public static IEnumerable<long?> GenerateRandomLongs<T1, T2, T>(T1 min, T2 max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < YANLib.YANNum.ToUlong(size); i++)
        {
            yield return GenerateRandomLong(min, max);
        }
    }

    public static long? GenerateRandomLong() => GenerateRandomLong(long.MinValue, long.MaxValue);

    public static long? GenerateRandomLong<T>(T max) where T : struct => GenerateRandomLong(long.MinValue, max);
}
