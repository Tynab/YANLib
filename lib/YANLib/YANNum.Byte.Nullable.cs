namespace YANLib;

public static partial class YANNum
{
    
    public static byte ToByte<T>(this T? num) where T : struct
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

    public static IEnumerable<byte> ToByte<T>(this IEnumerable<T?> nums) where T : struct
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

    public static byte ToByte<T>(this string str, T? dfltVal) where T : struct => dfltVal.HasValue ? str.ToByte(dfltVal.Value) : default;

    public static IEnumerable<byte> ToByte<T>(this IEnumerable<string> strs, T? dfltVal) where T : struct
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

    public static byte GenerateRandomByte<T1, T2>(T1? min, T2 max) where T1 : struct where T2 : struct => min.HasValue ? GenerateRandomByte(min.Value, max) : default;

    public static IEnumerable<byte> GenerateRandomBytes<T1, T2, T>(T1? min, T2 max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomByte(min, max);
        }
    }

    public static IEnumerable<byte> GenerateRandomBytes<T1, T2, T>(T1? min, T2 max, T? size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomByte(min, max);
        }
    }

    public static byte GenerateRandomByte<T1, T2>(T1 min, T2? max) where T1 : struct where T2 : struct => max.HasValue ? GenerateRandomByte(min, max.Value) : default;

    public static IEnumerable<byte> GenerateRandomBytes<T1, T2, T>(T1 min, T2? max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomByte(min, max);
        }
    }

    public static IEnumerable<byte> GenerateRandomBytes<T1, T2, T>(T1 min, T2? max, T? size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomByte(min, max);
        }
    }

    public static byte GenerateRandomByte<T1, T2>(T1? min, T2? max) where T1 : struct where T2 : struct => min.HasValue ? GenerateRandomByte(min.Value, max) : default;

    public static IEnumerable<byte> GenerateRandomBytes<T1, T2, T>(T1? min, T2? max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomByte(min, max);
        }
    }

    public static IEnumerable<byte> GenerateRandomBytes<T1, T2, T>(T1? min, T2? max, T? size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomByte(min, max);
        }
    }

    public static byte GenerateRandomByte<T>(T? max) where T : struct => max.HasValue ? GenerateRandomByte(byte.MinValue, max.Value) : default;
}
