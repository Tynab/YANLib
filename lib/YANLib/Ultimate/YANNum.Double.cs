namespace YANLib.Ultimate;

public static partial class YANNum
{
    public static IEnumerable<double> ToDouble<T>(this IEnumerable<T> nums) where T : struct
    {
        if (nums.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var num in nums)
        {
            yield return num.ToDouble();
        }
    }

    public static IEnumerable<double> ToDouble(this IEnumerable<string> strs)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var num in strs)
        {
            yield return YANLib.YANNum.ToDouble(num);
        }
    }

    public static IEnumerable<double> ToDouble<T>(this IEnumerable<string> strs, T dfltVal) where T : struct
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var num in strs)
        {
            yield return num.ToDouble(dfltVal);
        }
    }

    public static IEnumerable<double> GenerateRandomDoubles<T1, T2, T>(T1 min, T2 max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return YANLib.YANNum.GenerateRandomDouble(min, max);
        }
    }
}
