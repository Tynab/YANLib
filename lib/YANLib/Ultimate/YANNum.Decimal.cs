﻿namespace YANLib.Ultimate;

public static partial class YANNum
{
    public static IEnumerable<decimal> ToDecimal<T>(this IEnumerable<T> nums) where T : struct
    {
        if (nums is null || !nums.Any())
        {
            yield break;
        }

        foreach (var num in nums)
        {
            yield return num.ToDecimal();
        }
    }

    public static IEnumerable<decimal> ToDecimal(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }

        foreach (var num in strs)
        {
            yield return YANLib.YANNum.ToDecimal(num);
        }
    }

    public static IEnumerable<decimal> ToDecimal<T>(this IEnumerable<string> strs, T dfltVal) where T : struct
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }

        foreach (var num in strs)
        {
            yield return num.ToDecimal(dfltVal);
        }
    }

    public static IEnumerable<decimal> GenerateRandomDecimals<T1, T2, T>(T1 min, T2 max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return YANLib.YANNum.GenerateRandomDecimal(min, max);
        }
    }
}
