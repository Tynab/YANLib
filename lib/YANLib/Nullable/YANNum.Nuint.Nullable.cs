namespace YANLib.Nullable;

public static partial class YANNum
{
    
    public static nuint? ToNuint<T>(this T? num) where T : struct
    {
        try
        {
            return new UIntPtr(Convert.ToUInt64(num));
        }
        catch
        {
            return default;
        }
    }

    public static IEnumerable<nuint?> ToNuint<T>(this IEnumerable<T?> nums) where T : struct
    {
        if (nums is null || !nums.Any())
        {
            yield break;
        }
        foreach (var num in nums)
        {
            yield return num.ToNuint();
        }
    }

    public static nuint? ToNuint<T>(this string str, T? dfltVal) where T : struct => dfltVal.HasValue ? str.ToNuint(dfltVal.Value) : default;

    public static IEnumerable<nuint?> ToNuint<T>(this IEnumerable<string> strs, T? dfltVal) where T : struct
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToNuint(dfltVal);
        }
    }

    public static nuint? GenerateRandomNuint<T1, T2>(T1? min, T2 max) where T1 : struct where T2 : struct => min.HasValue ? GenerateRandomNuint(min.Value, max) : default;

    public static IEnumerable<nuint?> GenerateRandomNuints<T1, T2, T>(T1? min, T2 max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < YANLib.YANNum.ToUlong(size); i++)
        {
            yield return GenerateRandomNuint(min, max);
        }
    }

    public static IEnumerable<nuint?> GenerateRandomNuints<T1, T2, T>(T1? min, T2 max, T? size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < YANLib.YANNum.ToUlong(size); i++)
        {
            yield return GenerateRandomNuint(min, max);
        }
    }

    public static nuint? GenerateRandomNuint<T1, T2>(T1 min, T2? max) where T1 : struct where T2 : struct => max.HasValue ? GenerateRandomNuint(min, max.Value) : default;

    public static IEnumerable<nuint?> GenerateRandomNuints<T1, T2, T>(T1 min, T2? max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < YANLib.YANNum.ToUlong(size); i++)
        {
            yield return GenerateRandomNuint(min, max);
        }
    }

    public static IEnumerable<nuint?> GenerateRandomNuints<T1, T2, T>(T1 min, T2? max, T? size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < YANLib.YANNum.ToUlong(size); i++)
        {
            yield return GenerateRandomNuint(min, max);
        }
    }

    public static nuint? GenerateRandomNuint<T1, T2>(T1? min, T2? max) where T1 : struct where T2 : struct => min.HasValue ? GenerateRandomNuint(min.Value, max) : default;

    public static IEnumerable<nuint?> GenerateRandomNuints<T1, T2, T>(T1? min, T2? max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < YANLib.YANNum.ToUlong(size); i++)
        {
            yield return GenerateRandomNuint(min, max);
        }
    }

    public static IEnumerable<nuint?> GenerateRandomNuints<T1, T2, T>(T1? min, T2? max, T? size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < YANLib.YANNum.ToUlong(size); i++)
        {
            yield return GenerateRandomNuint(min, max);
        }
    }

    public static nuint? GenerateRandomNuint<T>(T? max) where T : struct => max.HasValue ? GenerateRandomNuint(nuint.MinValue, max.Value) : default;
}
