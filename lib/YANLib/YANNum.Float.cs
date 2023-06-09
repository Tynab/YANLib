namespace YANLib;

public static partial class YANNum
{

    public static float ToFloat<T>(this T num) where T : struct
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

    public static IEnumerable<float> ToFloat<T>(this IEnumerable<T> nums) where T : struct
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

    public static float ToFloat(this string str) => float.TryParse(str, out var num) ? num : default;

    public static IEnumerable<float> ToFloat(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToFloat();
        }
    }

    public static float ToFloat<T>(this string str, T dfltVal) where T : struct => float.TryParse(str, out var num) ? num : dfltVal.ToFloat();

    public static IEnumerable<float> ToFloat<T>(this IEnumerable<string> strs, T dfltVal) where T : struct
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

    public static float GenerateRandomFloat<T1, T2>(T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToFloat();
        var maxValue = max.ToFloat();
        return minValue > maxValue ? default : new Random().NextSingle(minValue, maxValue);
    }

    public static IEnumerable<float> GenerateRandomFloats<T1, T2, T>(T1 min, T2 max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomFloat(min, max);
        }
    }

    public static float GenerateRandomFloat() => GenerateRandomFloat(float.MinValue, float.MaxValue);

    public static float GenerateRandomFloat<T>(T max) where T : struct => GenerateRandomFloat(float.MinValue, max);
}
