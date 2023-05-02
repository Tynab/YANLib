namespace YANLib.Nullable;

public partial class YANNum
{
    
    public static short? ToShort<T>(this T num) where T : struct
    {
        try
        {
            return Convert.ToInt16(num);
        }
        catch
        {
            return default;
        }
    }

    public static IEnumerable<short?> ToShort<T>(this IEnumerable<T> nums) where T : struct
    {
        if (nums is null || !nums.Any())
        {
            yield break;
        }
        foreach (var num in nums)
        {
            yield return num.ToShort();
        }
    }

    public static short? ToShort(this string str) => short.TryParse(str, out var num) ? num : default;

    public static IEnumerable<short?> ToShort(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToShort();
        }
    }

    public static short? ToShort<T>(this string str, T dfltVal) where T : struct => short.TryParse(str, out var num) ? num : dfltVal.ToShort();

    public static IEnumerable<short?> ToShort<T>(this IEnumerable<string> strs, T dfltVal) where T : struct
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToShort(dfltVal);
        }
    }

    public static short? GenerateRandomShort<T1, T2>(T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToShort();
        var maxValue = max.ToShort();
        return minValue.HasValue && maxValue.HasValue ? minValue > maxValue ? default : new Random().Next(minValue.Value, maxValue.Value).ToShort() : default;
    }

    public static IEnumerable<short?> GenerateRandomShorts<T1, T2, T>(T1 min, T2 max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < YANLib.YANNum.ToUlong(size); i++)
        {
            yield return GenerateRandomShort(min, max);
        }
    }

    public static short? GenerateRandomShort() => GenerateRandomShort(short.MinValue, short.MaxValue);

    public static short? GenerateRandomShort<T>(T max) where T : struct => GenerateRandomShort(short.MinValue, max);
}
