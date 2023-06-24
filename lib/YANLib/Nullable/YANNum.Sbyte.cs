namespace YANLib.Nullable;

public static partial class YANNum
{

    public static sbyte? ToSbyte<T>(this T num) where T : struct
    {
        try
        {
            return Convert.ToSByte(num);
        }
        catch
        {
            return default;
        }
    }

    public static IEnumerable<sbyte?> ToSbyte<T>(this IEnumerable<T> nums) where T : struct
    {
        if (nums is null || !nums.Any())
        {
            yield break;
        }
        foreach (var num in nums)
        {
            yield return num.ToSbyte();
        }
    }

    public static sbyte? ToSbyte(this string str) => sbyte.TryParse(str, out var num) ? num : default;

    public static IEnumerable<sbyte?> ToSbyte(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToSbyte();
        }
    }

    public static sbyte? ToSbyte<T>(this string str, T dfltVal) where T : struct => sbyte.TryParse(str, out var num) ? num : dfltVal.ToSbyte();

    public static IEnumerable<sbyte?> ToSbyte<T>(this IEnumerable<string> strs, T dfltVal) where T : struct
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToSbyte(dfltVal);
        }
    }

    public static sbyte? GenerateRandomSbyte<T1, T2>(T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToSbyte();
        var maxValue = max.ToSbyte();
        return minValue.HasValue && maxValue.HasValue ? minValue > maxValue ? default : new Random().Next(minValue.Value, maxValue.Value).ToSbyte() : default;
    }

    public static IEnumerable<sbyte?> GenerateRandomSbytes<T1, T2, T>(T1 min, T2 max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < YANLib.YANNum.ToUlong(size); i++)
        {
            yield return GenerateRandomSbyte(min, max);
        }
    }

    public static sbyte? GenerateRandomSbyte() => GenerateRandomSbyte(sbyte.MinValue, sbyte.MaxValue);

    public static sbyte? GenerateRandomSbyte<T>(T max) where T : struct => GenerateRandomSbyte(sbyte.MinValue, max);
}
