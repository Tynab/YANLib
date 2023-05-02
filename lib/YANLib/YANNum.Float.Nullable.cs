namespace YANLib;

public partial class YANNum
{
    
    public static float ToFloat<T>(this T? num) where T : struct
    {
        try
        {
            return Convert.ToSingle(num);
        }
        catch
        {
            return default;
        }
    }

    public static IEnumerable<float> ToFloat<T>(this IEnumerable<T?> nums) where T : struct
    {
        if (nums is null || !nums.Any())
        {
            yield break;
        }
        foreach (var num in nums)
        {
            yield return num.ToFloat();
        }
    }

    public static float ToFloat<T>(this string str, T? dfltVal) where T : struct => dfltVal.HasValue ? str.ToFloat(dfltVal.Value) : default;

    public static IEnumerable<float> ToFloat<T>(this IEnumerable<string> strs, T? dfltVal) where T : struct
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToFloat(dfltVal);
        }
    }

    public static float GenerateRandomFloat<T1, T2>(T1? min, T2 max) where T1 : struct where T2 : struct => min.HasValue ? GenerateRandomFloat(min.Value, max) : default;

    public static IEnumerable<float> GenerateRandomFloats<T1, T2, T>(T1? min, T2 max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomFloat(min, max);
        }
    }

    public static IEnumerable<float> GenerateRandomFloats<T1, T2, T>(T1? min, T2 max, T? size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomFloat(min, max);
        }
    }

    public static float GenerateRandomFloat<T1, T2>(T1 min, T2? max) where T1 : struct where T2 : struct => max.HasValue ? GenerateRandomFloat(min, max.Value) : default;

    public static IEnumerable<float> GenerateRandomFloats<T1, T2, T>(T1 min, T2? max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomFloat(min, max);
        }
    }

    public static IEnumerable<float> GenerateRandomFloats<T1, T2, T>(T1 min, T2? max, T? size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomFloat(min, max);
        }
    }

    public static float GenerateRandomFloat<T1, T2>(T1? min, T2? max) where T1 : struct where T2 : struct => min.HasValue ? GenerateRandomFloat(min.Value, max) : default;

    public static IEnumerable<float> GenerateRandomFloats<T1, T2, T>(T1? min, T2? max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomFloat(min, max);
        }
    }

    public static IEnumerable<float> GenerateRandomFloats<T1, T2, T>(T1? min, T2? max, T? size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomFloat(min, max);
        }
    }

    public static float GenerateRandomFloat<T>(T? max) where T : struct => max.HasValue ? GenerateRandomFloat(float.MinValue, max.Value) : default;
}
