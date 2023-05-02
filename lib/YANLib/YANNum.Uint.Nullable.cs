namespace YANLib;

public static partial class YANNum
{
    
    public static uint ToUint<T>(this T? num) where T : struct
    {
        try
        {
            return Convert.ToUInt32(num);
        }
        catch
        {
            return default;
        }
    }

    public static IEnumerable<uint> ToUint<T>(this IEnumerable<T?> nums) where T : struct
    {
        if (nums is null || !nums.Any())
        {
            yield break;
        }
        foreach (var num in nums)
        {
            yield return num.ToUint();
        }
    }

    public static uint ToUint<T>(this string str, T? dfltVal) where T : struct => dfltVal.HasValue ? str.ToUint(dfltVal.Value) : default;

    public static IEnumerable<uint> ToUint<T>(this IEnumerable<string> strs, T? dfltVal) where T : struct
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToUint(dfltVal);
        }
    }

    public static uint GenerateRandomUint<T1, T2>(T1? min, T2 max) where T1 : struct where T2 : struct => min.HasValue ? GenerateRandomUint(min.Value, max) : default;

    public static IEnumerable<uint> GenerateRandomUints<T1, T2, T>(T1? min, T2 max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomUint(min, max);
        }
    }

    public static IEnumerable<uint> GenerateRandomUints<T1, T2, T>(T1? min, T2 max, T? size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomUint(min, max);
        }
    }

    public static uint GenerateRandomUint<T1, T2>(T1 min, T2? max) where T1 : struct where T2 : struct => max.HasValue ? GenerateRandomUint(min, max.Value) : default;

    public static IEnumerable<uint> GenerateRandomUints<T1, T2, T>(T1 min, T2? max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomUint(min, max);
        }
    }

    public static IEnumerable<uint> GenerateRandomUints<T1, T2, T>(T1 min, T2? max, T? size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomUint(min, max);
        }
    }

    public static uint GenerateRandomUint<T1, T2>(T1? min, T2? max) where T1 : struct where T2 : struct => min.HasValue ? GenerateRandomUint(min.Value, max) : default;

    public static IEnumerable<uint> GenerateRandomUints<T1, T2, T>(T1? min, T2? max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomUint(min, max);
        }
    }

    public static IEnumerable<uint> GenerateRandomUints<T1, T2, T>(T1? min, T2? max, T? size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomUint(min, max);
        }
    }

    public static uint GenerateRandomUint<T>(T? max) where T : struct => max.HasValue ? GenerateRandomUint(uint.MinValue, max.Value) : default;
}
