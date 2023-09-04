namespace YANLib.Ultimate;

public static partial class YANNum
{
    public static IEnumerable<float> ToFloat<T>(this IEnumerable<T?> nums) where T : struct
    {
        if (nums.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var num in nums)
        {
            yield return num.ToFloat();
        }
    }

    public static IEnumerable<float> ToFloat<T>(this IEnumerable<string> strs, T? dfltVal) where T : struct
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var num in strs)
        {
            yield return num.ToFloat(dfltVal);
        }
    }

    public static IEnumerable<float> GenerateRandomFloats<T1, T2, T>(T1? min, T2 max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return YANLib.YANNum.GenerateRandomFloat(min, max);
        }
    }

    public static IEnumerable<float> GenerateRandomFloats<T1, T2, T>(T1? min, T2 max, T? size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return YANLib.YANNum.GenerateRandomFloat(min, max);
        }
    }

    public static IEnumerable<float> GenerateRandomFloats<T1, T2, T>(T1 min, T2? max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return YANLib.YANNum.GenerateRandomFloat(min, max);
        }
    }

    public static IEnumerable<float> GenerateRandomFloats<T1, T2, T>(T1 min, T2? max, T? size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return YANLib.YANNum.GenerateRandomFloat(min, max);
        }
    }

    public static IEnumerable<float> GenerateRandomFloats<T1, T2, T>(T1? min, T2? max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return YANLib.YANNum.GenerateRandomFloat(min, max);
        }
    }

    public static IEnumerable<float> GenerateRandomFloats<T1, T2, T>(T1? min, T2? max, T? size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return YANLib.YANNum.GenerateRandomFloat(min, max);
        }
    }
}
