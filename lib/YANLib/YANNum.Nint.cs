namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Converts the specified value to a native integer (nint).
    /// Returns the converted <see cref="nint"/> value, or <see langword="default"/> if the conversion fails.
    /// </summary>
    /// <typeparam name="T">The type of the value to be converted, which must be a value type.</typeparam>
    /// <param name="num">The value to be converted.</param>
    /// <returns>The converted <see cref="nint"/> value, or <see langword="default"/> if the conversion fails.</returns>
    public static nint ToNint<T>(this T num) where T : struct
    {
        try
        {
            return new IntPtr(Convert.ToInt64(num));
        }
        catch
        {
            return default;
        }
    }

    public static IEnumerable<nint> ToNint<T>(params T[] nums) where T : struct
    {
        if (nums is null || nums.Length < 1)
        {
            yield break;
        }
        for (var i = 0; i < nums.Length; i++)
        {
            yield return nums[i].ToNint();
        }
    }

    public static IEnumerable<nint> ToNint<T>(this IEnumerable<T> nums) where T : struct
    {
        if (nums is null || !nums.Any())
        {
            yield break;
        }
        foreach (var num in nums)
        {
            yield return num.ToNint();
        }
    }

    public static IEnumerable<nint> ToNint<T>(this IReadOnlyCollection<T> nums) where T : struct
    {
        if (nums is null || nums.Count < 1)
        {
            yield break;
        }
        foreach (var num in nums)
        {
            yield return num.ToNint();
        }
    }

    public static IEnumerable<nint> ToNint<T>(this IReadOnlyList<T> nums) where T : struct
    {
        if (nums is null || nums.Count < 1)
        {
            yield break;
        }
        for (var i = 0; i < nums.Count; i++)
        {
            yield return nums[i].ToNint();
        }
    }

    public static IEnumerable<nint> ToNint<T>(this IReadOnlySet<T> nums) where T : struct
    {
        if (nums is null || nums.Count < 1)
        {
            yield break;
        }
        foreach (var num in nums)
        {
            yield return num.ToNint();
        }
    }

    /// <summary>
    /// Parses the string representation of a nint using the default format.
    /// Returns the parsed <see cref="nint"/> value, or <see langword="default"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="nint"/> value, or <see langword="default"/> if the parsing fails.</returns>
    public static nint ToNint(this string str) => nint.TryParse(str, out var num) ? num : default;

    public static IEnumerable<nint> ToNint<T>(params string[] strs) where T : struct
    {
        if (strs is null || strs.Length < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Length; i++)
        {
            yield return strs[i].ToNint();
        }
    }

    public static IEnumerable<nint> ToNint<T>(this IEnumerable<string> strs) where T : struct
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToNint();
        }
    }

    public static IEnumerable<nint> ToNint<T>(this IReadOnlyCollection<string> strs) where T : struct
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToNint();
        }
    }

    public static IEnumerable<nint> ToNint<T>(this IReadOnlyList<string> strs) where T : struct
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Count; i++)
        {
            yield return strs[i].ToNint();
        }
    }

    public static IEnumerable<nint> ToNint<T>(this IReadOnlySet<string> strs) where T : struct
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToNint();
        }
    }

    /// <summary>
    /// Parses the string representation of a nint using the default format.
    /// Returns the parsed <see cref="nint"/> value, or <paramref name="dfltVal"/> if the parsing fails.
    /// </summary>
    /// <typeparam name="T">The type of the default value to be returned, which must be a value type.</typeparam>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="nint"/> value, or <paramref name="dfltVal"/> if the parsing fails.</returns>
    public static nint ToNint<T>(this string str, T dfltVal) where T : struct => nint.TryParse(str, out var num) ? num : dfltVal.ToNint();

    public static IEnumerable<nint> ToNint<T>(T dfltVal, params string[] strs) where T : struct
    {
        if (strs is null || strs.Length < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Length; i++)
        {
            yield return strs[i].ToNint(dfltVal);
        }
    }

    public static IEnumerable<nint> ToNint<T>(this IEnumerable<string> strs, T dfltVal) where T : struct
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToNint(dfltVal);
        }
    }

    public static IEnumerable<nint> ToNint<T>(this IReadOnlyCollection<string> strs, T dfltVal) where T : struct
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToNint(dfltVal);
        }
    }

    public static IEnumerable<nint> ToNint<T>(this IReadOnlyList<string> strs, T dfltVal) where T : struct
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Count; i++)
        {
            yield return strs[i].ToNint(dfltVal);
        }
    }

    public static IEnumerable<nint> ToNint<T>(this IReadOnlySet<string> strs, T dfltVal) where T : struct
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToNint(dfltVal);
        }
    }

    /// <summary>
    /// Generates a random <see cref="IntPtr"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, <see langword="default"/> is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="IntPtr"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static nint GenerateRandomNint<T1, T2>(T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToNint();
        var maxValue = max.ToNint();
        return minValue > maxValue ? default : new Random().NextInt64(minValue, maxValue).ToNint();
    }

    public static IEnumerable<nint> GenerateRandomNint<T1, T2, T>(T1 min, T2 max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomNint(min, max);
        }
    }

    /// <summary>
    /// Generates a random <see cref="nint"/> value between <see cref="nint.MinValue"/> and <see cref="nint.MaxValue"/>.
    /// </summary>
    /// <returns>A random <see cref="nint"/> value between <see cref="nint.MinValue"/> and <see cref="nint.MaxValue"/>.</returns>
    public static nint GenerateRandomNint() => GenerateRandomNint(nint.MinValue, nint.MaxValue);

    /// <summary>
    /// Generates a random <see cref="nint"/> value between <see cref="nint.MinValue"/> and <paramref name="max"/>.
    /// </summary>
    /// <typeparam name="T">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="nint"/> value between <see cref="nint.MinValue"/> and <paramref name="max"/>.</returns>
    public static nint GenerateRandomNint<T>(T max) where T : struct => GenerateRandomNint(nint.MinValue, max);
}
