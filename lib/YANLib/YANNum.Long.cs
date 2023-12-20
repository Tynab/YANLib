﻿using static System.Linq.Enumerable;

namespace YANLib;

public static partial class YANNum
{
    public static long ToLong(this object? num, object? dfltVal = null)
    {
        try
        {
            return Convert.ToInt64(num);
        }
        catch
        {
            return dfltVal is null ? default : dfltVal.ToLong();
        }
    }

    public static IEnumerable<long>? ToLong(this IEnumerable<object?> nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToLong(dfltVal));

    public static long GenerateRandomLong(object? min = null, object? max = null)
    {
        var minValue = min is null ? long.MinValue : min.ToLong();
        var maxValue = max is null ? long.MaxValue : max.ToLong();

        return minValue > maxValue ? default : new Random().NextInt64(minValue, maxValue);
    }

    public static IEnumerable<long> GenerateRandomLongs(object? min = null, object? max = null, object? size = null) => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomLong(min, max));
}
