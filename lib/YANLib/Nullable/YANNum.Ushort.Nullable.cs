namespace YANLib.Nullable;

public static partial class YANNum
{

    public static ushort? ToUshort<T>(this T? num) where T : struct
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

    public static IEnumerable<ushort?> ToUshort<T>(this IEnumerable<T?> nums) where T : struct
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

    public static ushort? ToUshort<T>(this string str, T? dfltVal) where T : struct => dfltVal.HasValue ? str.ToUshort(dfltVal.Value) : default;

    public static IEnumerable<ushort?> ToUshort<T>(this IEnumerable<string> strs, T? dfltVal) where T : struct
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

    public static ushort? GenerateRandomUshort<T1, T2>(T1? min, T2 max) where T1 : struct where T2 : struct => min.HasValue ? GenerateRandomUshort(min.Value, max) : default;

    public static IEnumerable<ushort?> GenerateRandomUshorts<T1, T2, T>(T1? min, T2 max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < YANLib.YANNum.ToUlong(size); i++)
        {
            yield return GenerateRandomUshort(min, max);
        }
    }

    public static IEnumerable<ushort?> GenerateRandomUshorts<T1, T2, T>(T1? min, T2 max, T? size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < YANLib.YANNum.ToUlong(size); i++)
        {
            yield return GenerateRandomUshort(min, max);
        }
    }

    public static ushort? GenerateRandomUshort<T1, T2>(T1 min, T2? max) where T1 : struct where T2 : struct => max.HasValue ? GenerateRandomUshort(min, max.Value) : default;

    public static IEnumerable<ushort?> GenerateRandomUshorts<T1, T2, T>(T1 min, T2? max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < YANLib.YANNum.ToUlong(size); i++)
        {
            yield return GenerateRandomUshort(min, max);
        }
    }

    public static IEnumerable<ushort?> GenerateRandomUshorts<T1, T2, T>(T1 min, T2? max, T? size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < YANLib.YANNum.ToUlong(size); i++)
        {
            yield return GenerateRandomUshort(min, max);
        }
    }

    public static ushort? GenerateRandomUshort<T1, T2>(T1? min, T2? max) where T1 : struct where T2 : struct => min.HasValue ? GenerateRandomUshort(min.Value, max) : default;

    public static IEnumerable<ushort?> GenerateRandomUshorts<T1, T2, T>(T1? min, T2? max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < YANLib.YANNum.ToUlong(size); i++)
        {
            yield return GenerateRandomUshort(min, max);
        }
    }

    public static IEnumerable<ushort?> GenerateRandomUshorts<T1, T2, T>(T1? min, T2? max, T? size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < YANLib.YANNum.ToUlong(size); i++)
        {
            yield return GenerateRandomUshort(min, max);
        }
    }

    public static ushort? GenerateRandomUshort<T>(T? max) where T : struct => max.HasValue ? GenerateRandomUshort(ushort.MinValue, max.Value) : default;
}
