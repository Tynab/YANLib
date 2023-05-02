namespace YANLib;

public static partial class YANNum
{
    
    public static ulong ToUlong<T>(this T? num) where T : struct
    {
        try
        {
            return Convert.ToUInt64(num);
        }
        catch
        {
            return default;
        }
    }

    public static IEnumerable<ulong> ToUlong<T>(this IEnumerable<T?> nums) where T : struct
    {
        if (nums is null || !nums.Any())
        {
            yield break;
        }
        foreach (var num in nums)
        {
            yield return num.ToUlong();
        }
    }

    public static ulong ToUlong<T>(this string str, T? dfltVal) where T : struct => dfltVal.HasValue ? str.ToUlong(dfltVal.Value) : default;

    public static IEnumerable<ulong> ToUlong<T>(this IEnumerable<string> strs, T? dfltVal) where T : struct
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToUlong(dfltVal);
        }
    }

    public static ulong GenerateRandomUlong<T1, T2>(T1? min, T2 max) where T1 : struct where T2 : struct => min.HasValue ? GenerateRandomUlong(min.Value, max) : default;

    public static IEnumerable<ulong> GenerateRandomUlongs<T1, T2, T>(T1? min, T2 max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomUlong(min, max);
        }
    }

    public static IEnumerable<ulong> GenerateRandomUlongs<T1, T2, T>(T1? min, T2 max, T? size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomUlong(min, max);
        }
    }

    public static ulong GenerateRandomUlong<T1, T2>(T1 min, T2? max) where T1 : struct where T2 : struct => max.HasValue ? GenerateRandomUlong(min, max.Value) : default;

    public static IEnumerable<ulong> GenerateRandomUlongs<T1, T2, T>(T1 min, T2? max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomUlong(min, max);
        }
    }

    public static IEnumerable<ulong> GenerateRandomUlongs<T1, T2, T>(T1 min, T2? max, T? size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomUlong(min, max);
        }
    }

    public static ulong GenerateRandomUlong<T1, T2>(T1? min, T2? max) where T1 : struct where T2 : struct => min.HasValue ? GenerateRandomUlong(min.Value, max) : default;

    public static IEnumerable<ulong> GenerateRandomUlongs<T1, T2, T>(T1? min, T2? max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomUlong(min, max);
        }
    }

    public static IEnumerable<ulong> GenerateRandomUlongs<T1, T2, T>(T1? min, T2? max, T? size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomUlong(min, max);
        }
    }

    public static ulong GenerateRandomUlong<T>(T? max) where T : struct => max.HasValue ? GenerateRandomUlong(ulong.MinValue, max.Value) : default;
}
