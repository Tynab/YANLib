namespace YANLib.Ultimate;

public static partial class YANNum
{
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

    public static IEnumerable<byte> ToByte(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return YANLib.YANNum.ToByte(str);
        }
    }

    public static IEnumerable<byte> ToByte<T>(this IEnumerable<string> strs, T dfltVal) where T : struct
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.ToByte(dfltVal);
        }
    }

    public static IEnumerable<byte> GenerateRandomBytes<T1, T2, T>(T1 min, T2 max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return YANLib.YANNum.GenerateRandomByte(min, max);
        }
    }
}
