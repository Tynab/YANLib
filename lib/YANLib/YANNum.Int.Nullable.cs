namespace YANLib;

public static partial class YANNum
{

    public static int ToInt<T>(this T? num) where T : struct
    {
        try
        {
            return Convert.ToInt32(num);
        }
        catch
        {
            return default;
        }
    }

    public static IEnumerable<int> ToInt<T>(this IEnumerable<T?> nums) where T : struct
    {
        if (nums is null || !nums.Any())
        {
            yield break;
        }

        foreach (var num in nums)
        {
            yield return num.ToInt();
        }
    }

    public static int ToInt<T>(this string str, T? dfltVal) where T : struct => dfltVal.HasValue ? str.ToInt(dfltVal.Value) : default;

    public static IEnumerable<int> ToInt<T>(this IEnumerable<string> strs, T? dfltVal) where T : struct
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }

        foreach (var num in strs)
        {
            yield return num.ToInt(dfltVal);
        }
    }

    public static int GenerateRandomInt<T1, T2>(T1? min, T2 max) where T1 : struct where T2 : struct => min.HasValue ? GenerateRandomInt(min.Value, max) : default;

    public static IEnumerable<int> GenerateRandomInts<T1, T2, T>(T1? min, T2 max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomInt(min, max);
        }
    }

    public static IEnumerable<int> GenerateRandomInts<T1, T2, T>(T1? min, T2 max, T? size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomInt(min, max);
        }
    }

    public static int GenerateRandomInt<T1, T2>(T1 min, T2? max) where T1 : struct where T2 : struct => max.HasValue ? GenerateRandomInt(min, max.Value) : default;

    public static IEnumerable<int> GenerateRandomInts<T1, T2, T>(T1 min, T2? max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomInt(min, max);
        }
    }

    public static IEnumerable<int> GenerateRandomInts<T1, T2, T>(T1 min, T2? max, T? size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomInt(min, max);
        }
    }

    public static int GenerateRandomInt<T1, T2>(T1? min, T2? max) where T1 : struct where T2 : struct => min.HasValue ? GenerateRandomInt(min.Value, max) : default;

    public static IEnumerable<int> GenerateRandomInts<T1, T2, T>(T1? min, T2? max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomInt(min, max);
        }
    }

    public static IEnumerable<int> GenerateRandomInts<T1, T2, T>(T1? min, T2? max, T? size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomInt(min, max);
        }
    }

    public static int GenerateRandomInt<T>(T? max) where T : struct => max.HasValue ? GenerateRandomInt(int.MinValue, max.Value) : default;
}
