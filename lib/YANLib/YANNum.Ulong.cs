using System.Numerics;

namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Converts the specified value to an unsigned long integer.
    /// Returns the converted <see cref="ulong"/> value, or <see langword="default"/> if the conversion fails.
    /// </summary>
    /// <typeparam name="T">The type of the value to be converted, which must be a value type.</typeparam>
    /// <param name="num">The value to be converted.</param>
    /// <returns>The converted <see cref="ulong"/> value, or <see langword="default"/> if the conversion fails.</returns>
    public static ulong ToUlong<T>(this T num) where T : struct
    {
        try
        {
            return Convert.ToUInt64(num);
        }
        catch
        {
            return default;
        }
    }

    public static IEnumerable<ulong> ToUlong<T>(params T[] nums) where T : struct
    {
        if (nums is null || nums.Length < 1)
        {
            yield break;
        }
        for (var i = 0; i < nums.Length; i++)
        {
            yield return nums[i].ToUlong();
        }
    }

    public static IEnumerable<ulong> ToUlong<T>(this IEnumerable<T> nums) where T : struct
    {
        if (nums is null || !nums.Any())
        {
            yield break;
        }
        foreach (var num in nums)
        {
            yield return num.ToUlong();
        }
    }

    public static IEnumerable<ulong> ToUlong<T>(this IReadOnlyCollection<T> nums) where T : struct
    {
        if (nums is null || nums.Count < 1)
        {
            yield break;
        }
        foreach (var num in nums)
        {
            yield return num.ToUlong();
        }
    }

    public static IEnumerable<ulong> ToUlong<T>(this IReadOnlyList<T> nums) where T : struct
    {
        if (nums is null || nums.Count < 1)
        {
            yield break;
        }
        for (var i = 0; i < nums.Count; i++)
        {
            yield return nums[i].ToUlong();
        }
    }

    public static IEnumerable<ulong> ToUlong<T>(this IReadOnlySet<T> nums) where T : struct
    {
        if (nums is null || nums.Count < 1)
        {
            yield break;
        }
        foreach (var num in nums)
        {
            yield return num.ToUlong();
        }
    }

    /// <summary>
    /// Parses the string representation of an unsigned long integer using the default format.
    /// Returns the parsed <see cref="ulong"/> value, or <see langword="default"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="ulong"/> value, or <see langword="default"/> if the parsing fails.</returns>
    public static ulong ToUlong(this string str) => ulong.TryParse(str, out var num) ? num : default;

    public static IEnumerable<ulong> ToUlong<T>(params string[] strs) where T : struct
    {
        if (strs is null || strs.Length < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Length; i++)
        {
            yield return strs[i].ToUlong();
        }
    }

    public static IEnumerable<ulong> ToUlong<T>(this IEnumerable<string> strs) where T : struct
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToUlong();
        }
    }

    public static IEnumerable<ulong> ToUlong<T>(this IReadOnlyCollection<string> strs) where T : struct
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToUlong();
        }
    }

    public static IEnumerable<ulong> ToUlong<T>(this IReadOnlyList<string> strs) where T : struct
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Count; i++)
        {
            yield return strs[i].ToUlong();
        }
    }

    public static IEnumerable<ulong> ToUlong<T>(this IReadOnlySet<string> strs) where T : struct
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToUlong();
        }
    }

    /// <summary>
    /// Parses the string representation of an <see cref="ulong"/> using the default format.
    /// Returns the parsed <see cref="ulong"/> value, or <paramref name="dfltVal"/> if the parsing fails.
    /// </summary>
    /// <typeparam name="T">The type of the default value to be returned, which must be a value type.</typeparam>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="ulong"/> value, or <paramref name="dfltVal"/> if the parsing fails.</returns>
    public static ulong ToUlong<T>(this string str, T dfltVal) where T : struct => ulong.TryParse(str, out var num) ? num : dfltVal.ToUlong();

    public static IEnumerable<ulong> ToUlong<T>(T dfltVal, params string[] strs) where T : struct
    {
        if (strs is null || strs.Length < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Length; i++)
        {
            yield return strs[i].ToUlong(dfltVal);
        }
    }

    public static IEnumerable<ulong> ToUlong<T>(this IEnumerable<string> strs, T dfltVal) where T : struct
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToUlong(dfltVal);
        }
    }

    public static IEnumerable<ulong> ToUlong<T>(this IReadOnlyCollection<string> strs, T dfltVal) where T : struct
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToUlong(dfltVal);
        }
    }

    public static IEnumerable<ulong> ToUlong<T>(this IReadOnlyList<string> strs, T dfltVal) where T : struct
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Count; i++)
        {
            yield return strs[i].ToUlong(dfltVal);
        }
    }

    public static IEnumerable<ulong> ToUlong<T>(this IReadOnlySet<string> strs, T dfltVal) where T : struct
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToUlong(dfltVal);
        }
    }

    /// <summary>
    /// Generates a random <see cref="ulong"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, <see langword="default"/> is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="ulong"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static ulong GenerateRandomUlong<T1, T2>(T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToUlong();
        var maxValue = max.ToUlong();
        return minValue > maxValue ? default : (new Random().NextInt64(long.MinValue, (long)(maxValue - (minValue - (BigInteger)long.MinValue))) - long.MinValue).ToUlong() + minValue;
    }

    public static IEnumerable<ulong> GenerateRandomUlong<T1, T2, T>(T1 min, T2 max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomUlong(min, max);
        }
    }

    /// <summary>
    /// Generates a random <see cref="ulong"/> value between <see cref="ulong.MinValue"/> and <see cref="ulong.MaxValue"/>.
    /// </summary>
    /// <returns>A random <see cref="ulong"/> value between <see cref="ulong.MinValue"/> and <see cref="ulong.MaxValue"/>.</returns>
    public static ulong GenerateRandomUlong() => GenerateRandomUlong(ulong.MinValue, ulong.MaxValue);

    /// <summary>
    /// Generates a random <see cref="ulong"/> value between <see cref="ulong.MinValue"/> and <paramref name="max"/>.
    /// </summary>
    /// <typeparam name="T">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="ulong"/> value between <see cref="ulong.MinValue"/> and <paramref name="max"/>.</returns>
    public static ulong GenerateRandomUlong<T>(T max) where T : struct => GenerateRandomUlong(ulong.MinValue, max);
}
