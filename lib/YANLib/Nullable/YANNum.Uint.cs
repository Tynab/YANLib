namespace YANLib.Nullable;

public static partial class YANNum
{

    public static uint? ToUint<T>(this T num) where T : struct
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

    public static IEnumerable<uint?> ToUint<T>(this IEnumerable<T> nums) where T : struct
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

    public static uint? ToUint(this string str) => uint.TryParse(str, out var num) ? num : default;

    public static IEnumerable<uint?> ToUint(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }

        foreach (var num in strs)
        {
            yield return num.ToUint();
        }
    }

    public static uint? ToUint<T>(this string str, T dfltVal) where T : struct => uint.TryParse(str, out var num) ? num : dfltVal.ToUint();

    public static IEnumerable<uint?> ToUint<T>(this IEnumerable<string> strs, T dfltVal) where T : struct
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

    public static uint? GenerateRandomUint<T1, T2>(T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToUint();
        var maxValue = max.ToUint();

        return minValue.HasValue && maxValue.HasValue ? minValue > maxValue ? default : new Random().NextInt64(minValue.Value, maxValue.Value).ToUint() : default;
    }

    public static IEnumerable<uint?> GenerateRandomUints<T1, T2, T>(T1 min, T2 max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < YANLib.YANNum.ToUlong(size); i++)
        {
            yield return GenerateRandomUint(min, max);
        }
    }

    public static uint? GenerateRandomUint() => GenerateRandomUint(uint.MinValue, uint.MaxValue);

    public static uint? GenerateRandomUint<T>(T max) where T : struct => GenerateRandomUint(uint.MinValue, max);
}
