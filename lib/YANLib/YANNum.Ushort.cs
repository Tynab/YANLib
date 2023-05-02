namespace YANLib;

public static partial class YANNum
{
    
    public static ushort ToUshort<T>(this T num) where T : struct
    {
        try
        {
            return Convert.ToUInt16(num);
        }
        catch
        {
            return default;
        }
    }

    public static IEnumerable<ushort> ToUshort<T>(this IEnumerable<T> nums) where T : struct
    {
        if (nums is null || !nums.Any())
        {
            yield break;
        }
        foreach (var num in nums)
        {
            yield return num.ToUshort();
        }
    }

    public static ushort ToUshort(this string str) => ushort.TryParse(str, out var num) ? num : default;

    public static IEnumerable<ushort> ToUshort(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToUshort();
        }
    }

    public static ushort ToUshort<T>(this string str, T dfltVal) where T : struct => ushort.TryParse(str, out var num) ? num : dfltVal.ToUshort();

    public static IEnumerable<ushort> ToUshort<T>(this IEnumerable<string> strs, T dfltVal) where T : struct
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToUshort(dfltVal);
        }
    }

    public static ushort GenerateRandomUshort<T1, T2>(T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToUshort();
        var maxValue = max.ToUshort();
        return minValue > maxValue ? default : new Random().Next(minValue, maxValue).ToUshort();
    }

    public static IEnumerable<ushort> GenerateRandomUshorts<T1, T2, T>(T1 min, T2 max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomUshort(min, max);
        }
    }

    public static ushort GenerateRandomUshort() => GenerateRandomUshort(ushort.MinValue, ushort.MaxValue);

    public static ushort GenerateRandomUshort<T>(T max) where T : struct => GenerateRandomUshort(ushort.MinValue, max);
}
