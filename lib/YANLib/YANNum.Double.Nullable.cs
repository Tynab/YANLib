namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Converts the specified value to a double.
    /// Returns the converted <see cref="double"/> value, or <see langword="default"/> if the conversion fails.
    /// </summary>
    /// <typeparam name="T">The type of the value to be converted, which must be a value type.</typeparam>
    /// <param name="num">The value to be converted.</param>
    /// <returns>The converted <see cref="double"/> value, or <see langword="default"/> if the conversion fails.</returns>
    public static double ToDouble<T>(this T? num) where T : struct
    {
        try
        {
            return Convert.ToDouble(num);
        }
        catch
        {
            return default;
        }
    }

    public static IEnumerable<double> ToDouble<T>(params T?[] nums) where T : struct
    {
        if (nums is null || nums.Length < 1)
        {
            yield break;
        }
        for (var i = 0; i < nums.Length; i++)
        {
            yield return nums[i].ToDouble();
        }
    }

    public static IEnumerable<double> ToDouble<T>(this IEnumerable<T?> nums) where T : struct
    {
        if (nums is null || !nums.Any())
        {
            yield break;
        }
        foreach (var num in nums)
        {
            yield return num.ToDouble();
        }
    }

    public static IEnumerable<double> ToDouble<T>(this IReadOnlyCollection<T?> nums) where T : struct
    {
        if (nums is null || nums.Count < 1)
        {
            yield break;
        }
        foreach (var num in nums)
        {
            yield return num.ToDouble();
        }
    }

    public static IEnumerable<double> ToDouble<T>(this IReadOnlyList<T?> nums) where T : struct
    {
        if (nums is null || nums.Count < 1)
        {
            yield break;
        }
        for (var i = 0; i < nums.Count; i++)
        {
            yield return nums[i].ToDouble();
        }
    }

    public static IEnumerable<double> ToDouble<T>(this IReadOnlySet<T?> nums) where T : struct
    {
        if (nums is null || nums.Count < 1)
        {
            yield break;
        }
        foreach (var num in nums)
        {
            yield return num.ToDouble();
        }
    }

    /// <summary>
    /// Parses the string representation of a double using the default format.
    /// Returns the parsed <see cref="double"/> value, or <paramref name="dfltVal"/> if the parsing fails.
    /// </summary>
    /// <typeparam name="T">The type of the default value to be returned, which must be a value type.</typeparam>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="double"/> value, or <paramref name="dfltVal"/> if the parsing fails.</returns>
    public static double ToDouble<T>(this string str, T? dfltVal) where T : struct => dfltVal.HasValue ? str.ToDouble(dfltVal.Value) : default;

    public static IEnumerable<double> ToDouble<T>(T? dfltVal, params string[] strs) where T : struct
    {
        if (strs is null || strs.Length < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Length; i++)
        {
            yield return strs[i].ToDouble(dfltVal);
        }
    }

    public static IEnumerable<double> ToDouble<T>(this IEnumerable<string> strs, T? dfltVal) where T : struct
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToDouble(dfltVal);
        }
    }

    public static IEnumerable<double> ToDouble<T>(this IReadOnlyCollection<string> strs, T? dfltVal) where T : struct
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToDouble(dfltVal);
        }
    }

    public static IEnumerable<double> ToDouble<T>(this IReadOnlyList<string> strs, T? dfltVal) where T : struct
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Count; i++)
        {
            yield return strs[i].ToDouble(dfltVal);
        }
    }

    public static IEnumerable<double> ToDouble<T>(this IReadOnlySet<string> strs, T? dfltVal) where T : struct
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToDouble(dfltVal);
        }
    }

    /// <summary>
    /// Generates a random <see cref="double"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, <see langword="default"/> is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="double"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static double GenerateRandomDouble<T1, T2>(T1? min, T2 max) where T1 : struct where T2 : struct => min.HasValue ? GenerateRandomDouble(min.Value, max) : default;

    public static IEnumerable<double> GenerateRandomDouble<T1, T2, T>(T1? min, T2 max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomDouble(min, max);
        }
    }

    public static IEnumerable<double> GenerateRandomDouble<T1, T2, T>(T1? min, T2 max, T? size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomDouble(min, max);
        }
    }

    /// <summary>
    /// Generates a random <see cref="double"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, <see langword="default"/> is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="double"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static double GenerateRandomDouble<T1, T2>(T1 min, T2? max) where T1 : struct where T2 : struct => max.HasValue ? GenerateRandomDouble(min, max.Value) : default;

    public static IEnumerable<double> GenerateRandomDouble<T1, T2, T>(T1 min, T2? max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomDouble(min, max);
        }
    }

    public static IEnumerable<double> GenerateRandomDouble<T1, T2, T>(T1 min, T2? max, T? size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomDouble(min, max);
        }
    }

    /// <summary>
    /// Generates a random <see cref="double"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, <see langword="default"/> is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="double"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static double GenerateRandomDouble<T1, T2>(T1? min, T2? max) where T1 : struct where T2 : struct => min.HasValue ? GenerateRandomDouble(min.Value, max) : default;

    public static IEnumerable<double> GenerateRandomDouble<T1, T2, T>(T1? min, T2? max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomDouble(min, max);
        }
    }

    public static IEnumerable<double> GenerateRandomDouble<T1, T2, T>(T1? min, T2? max, T? size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomDouble(min, max);
        }
    }

    /// <summary>
    /// Generates a random <see cref="double"/> value between <see cref="double.MinValue"/> and <paramref name="max"/>.
    /// </summary>
    /// <typeparam name="T">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="double"/> value between <see cref="double.MinValue"/> and <paramref name="max"/>.</returns>
    public static double GenerateRandomDouble<T>(T? max) where T : struct => max.HasValue ? GenerateRandomDouble(double.MinValue, max.Value) : default;
}
