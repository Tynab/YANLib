namespace YANLib;

public static partial class YANNum
{
    
    public static nint ToNint<T>(this T? num) where T : struct
    {
        try
        {
            return new IntPtr(Convert.ToInt64(num));
        }
        catch
        {
            return default;
        }
    }

    public static IEnumerable<nint> ToNint<T>(this IEnumerable<T?> nums) where T : struct
    {
        if (nums is null || !nums.Any())
        {
            yield break;
        }
        foreach (var num in nums)
        {
            yield return num.ToNint();
        }
    }

    public static nint ToNint<T>(this string str, T? dfltVal) where T : struct => dfltVal.HasValue ? str.ToNint(dfltVal.Value) : default;

    public static IEnumerable<nint> ToNint<T>(this IEnumerable<string> strs, T? dfltVal) where T : struct
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToNint(dfltVal);
        }
    }

    public static nint GenerateRandomNint<T1, T2>(T1? min, T2 max) where T1 : struct where T2 : struct => min.HasValue ? GenerateRandomNint(min.Value, max) : default;

    public static IEnumerable<nint> GenerateRandomNints<T1, T2, T>(T1? min, T2 max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomNint(min, max);
        }
    }

    public static IEnumerable<nint> GenerateRandomNints<T1, T2, T>(T1? min, T2 max, T? size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomNint(min, max);
        }
    }

    public static nint GenerateRandomNint<T1, T2>(T1 min, T2? max) where T1 : struct where T2 : struct => max.HasValue ? GenerateRandomNint(min, max.Value) : default;

    public static IEnumerable<nint> GenerateRandomNints<T1, T2, T>(T1 min, T2? max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomNint(min, max);
        }
    }

    public static IEnumerable<nint> GenerateRandomNints<T1, T2, T>(T1 min, T2? max, T? size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomNint(min, max);
        }
    }

    public static nint GenerateRandomNint<T1, T2>(T1? min, T2? max) where T1 : struct where T2 : struct => min.HasValue ? GenerateRandomNint(min.Value, max) : default;

    public static IEnumerable<nint> GenerateRandomNints<T1, T2, T>(T1? min, T2? max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomNint(min, max);
        }
    }

    public static IEnumerable<nint> GenerateRandomNints<T1, T2, T>(T1? min, T2? max, T? size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomNint(min, max);
        }
    }

    public static nint GenerateRandomNint<T>(T? max) where T : struct => max.HasValue ? GenerateRandomNint(nint.MinValue, max.Value) : default;
}
