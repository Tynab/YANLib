namespace YANLib;

public static partial class YANNum
{
    
    public static byte ToByte<T>(this T num) where T : struct
    {
        try
        {
            return Convert.ToByte(num);
        }
        catch
        {
            return default;
        }
    }

    public static IEnumerable<byte> ToByte<T>(this IEnumerable<T> nums) where T : struct
    {
        if (nums is null || !nums.Any())
        {
            yield break;
        }
        foreach (var num in nums)
        {
            yield return num.ToByte();
        }
    }

    public static byte ToByte(this string str) => byte.TryParse(str, out var num) ? num : default;

    public static IEnumerable<byte> ToByte(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToByte();
        }
    }

    public static byte ToByte<T>(this string str, T dfltVal) where T : struct => byte.TryParse(str, out var num) ? num : dfltVal.ToByte();

    public static IEnumerable<byte> ToByte<T>(this IEnumerable<string> strs, T dfltVal) where T : struct
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToByte(dfltVal);
        }
    }

    public static byte GenerateRandomByte<T1, T2>(T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToByte();
        var maxValue = max.ToByte();
        return minValue > maxValue ? default : new Random().Next(minValue, maxValue).ToByte();
    }

    public static IEnumerable<byte> GenerateRandomBytes<T1, T2, T>(T1 min, T2 max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomByte(min, max);
        }
    }

    public static byte GenerateRandomByte() => GenerateRandomByte(byte.MinValue, byte.MaxValue);

    public static byte GenerateRandomByte<T>(T max) where T : struct => GenerateRandomByte(byte.MinValue, max);
}
