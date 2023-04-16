namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Converts the specified value to a decimal.
    /// Returns the converted <see cref="decimal"/> value, or <see langword="default"/> if the conversion fails.
    /// </summary>
    /// <typeparam name="T">The type of the value to be converted, which must be a value type.</typeparam>
    /// <param name="num">The value to be converted.</param>
    /// <returns>The converted <see cref="decimal"/> value, or <see langword="default"/> if the conversion fails.</returns>
    public static decimal ToDecimal<T>(this T num) where T : struct
    {
        try
        {
            return Convert.ToDecimal(num);
        }
        catch
        {
            return default;
        }
    }

    public static IEnumerable<decimal> ToDecimal<T>(params T[] nums) where T : struct
    {
        if (nums is null || nums.Length < 1)
        {
            yield break;
        }
        for (var i = 0; i < nums.Length; i++)
        {
            yield return nums[i].ToDecimal();
        }
    }

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

    public static IEnumerable<decimal> ToDecimal<T>(this IReadOnlyCollection<T> nums) where T : struct
    {
        if (nums is null || nums.Count < 1)
        {
            yield break;
        }
        foreach (var num in nums)
        {
            yield return num.ToDecimal();
        }
    }

    public static IEnumerable<decimal> ToDecimal<T>(this IReadOnlyList<T> nums) where T : struct
    {
        if (nums is null || nums.Count < 1)
        {
            yield break;
        }
        for (var i = 0; i < nums.Count; i++)
        {
            yield return nums[i].ToDecimal();
        }
    }

    public static IEnumerable<decimal> ToDecimal<T>(this IReadOnlySet<T> nums) where T : struct
    {
        if (nums is null || nums.Count < 1)
        {
            yield break;
        }
        foreach (var num in nums)
        {
            yield return num.ToDecimal();
        }
    }

    /// <summary>
    /// Parses the string representation of a decimal using the default format.
    /// Returns the parsed <see cref="decimal"/> value, or <see langword="default"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="decimal"/> value, or <see langword="default"/> if the parsing fails.</returns>
    public static decimal ToDecimal(this string str) => decimal.TryParse(str, out var num) ? num : default;

    public static IEnumerable<decimal> ToDecimal<T>(params string[] strs) where T : struct
    {
        if (strs is null || strs.Length < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Length; i++)
        {
            yield return strs[i].ToDecimal();
        }
    }

    public static IEnumerable<decimal> ToDecimal<T>(this IEnumerable<string> strs) where T : struct
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToDecimal();
        }
    }

    public static IEnumerable<decimal> ToDecimal<T>(this IReadOnlyCollection<string> strs) where T : struct
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToDecimal();
        }
    }

    public static IEnumerable<decimal> ToDecimal<T>(this IReadOnlyList<string> strs) where T : struct
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Count; i++)
        {
            yield return strs[i].ToDecimal();
        }
    }

    public static IEnumerable<decimal> ToDecimal<T>(this IReadOnlySet<string> strs) where T : struct
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToDecimal();
        }
    }

    /// <summary>
    /// Parses the string representation of a decimal using the default format.
    /// Returns the parsed <see cref="decimal"/> value, or <paramref name="dfltVal"/> if the parsing fails.
    /// </summary>
    /// <typeparam name="T">The type of the default value to be returned, which must be a value type.</typeparam>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="decimal"/> value, or <paramref name="dfltVal"/> if the parsing fails.</returns>
    public static decimal ToDecimal<T>(this string str, T dfltVal) where T : struct => decimal.TryParse(str, out var num) ? num : dfltVal.ToDecimal();

    public static IEnumerable<decimal> ToDecimal<T>(T dfltVal, params string[] strs) where T : struct
    {
        if (strs is null || strs.Length < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Length; i++)
        {
            yield return strs[i].ToDecimal(dfltVal);
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

    public static IEnumerable<decimal> ToDecimal<T>(this IReadOnlyCollection<string> strs, T dfltVal) where T : struct
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToDecimal(dfltVal);
        }
    }

    public static IEnumerable<decimal> ToDecimal<T>(this IReadOnlyList<string> strs, T dfltVal) where T : struct
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Count; i++)
        {
            yield return strs[i].ToDecimal(dfltVal);
        }
    }

    public static IEnumerable<decimal> ToDecimal<T>(this IReadOnlySet<string> strs, T dfltVal) where T : struct
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToDecimal(dfltVal);
        }
    }

    /// <summary>
    /// Generates a random <see cref="decimal"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, <see langword="default"/> is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="decimal"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static decimal GenerateRandomDecimal<T1, T2>(T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToDecimal();
        var maxValue = max.ToDecimal();
        return minValue > maxValue ? default : new Random().NextDecimal(minValue, maxValue);
    }

    public static IEnumerable<decimal> GenerateRandomDecimal<T1, T2, T>(T1 min, T2 max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomDecimal(min, max);
        }
    }

    /// <summary>
    /// Generates a random <see cref="decimal"/> value between <see cref="decimal.MinValue"/> and <see cref="decimal.MaxValue"/>.
    /// </summary>
    /// <returns>A random <see cref="decimal"/> value between <see cref="decimal.MinValue"/> and <see cref="decimal.MaxValue"/>.</returns>
    public static decimal GenerateRandomDecimal() => GenerateRandomDecimal(decimal.MinValue, decimal.MaxValue);

    /// <summary>
    /// Generates a random <see cref="decimal"/> value between <see cref="decimal.MinValue"/> and <paramref name="max"/>.
    /// </summary>
    /// <typeparam name="T">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="decimal"/> value between <see cref="decimal.MinValue"/> and <paramref name="max"/>.</returns>
    public static decimal GenerateRandomDecimal<T>(T max) where T : struct => GenerateRandomDecimal(decimal.MinValue, max);
}
