namespace YANLib.Nullable;

public static partial class YANNum
{
    /// <summary>
    /// Converts the specified value to a <see cref="nuint"/> (an unsigned integer type representing a pointer or a handle).
    /// Returns the converted <see cref="nuint"/> value, or <see langword="default"/> if the conversion fails.
    /// </summary>
    /// <typeparam name="T">The type of the value to be converted, which must be a value type.</typeparam>
    /// <param name="num">The value to be converted.</param>
    /// <returns>The converted <see cref="nuint"/> value, or <see langword="default"/> if the conversion fails.</returns>
    public static nuint? ToNuint<T>(this T? num) where T : struct
    {
        try
        {
            return new UIntPtr(Convert.ToUInt64(num));
        }
        catch
        {
            return default;
        }
    }

    /// <summary>
    /// Converts an enumerable of value-type objects of type <typeparamref name="T"/> to an enumerable of <see cref="nuint"/> values, which represent the unsigned integer equivalent of the objects.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> objects.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the value-type objects to be converted.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="nums">The enumerable of value-type objects to be converted.</param>
    /// <returns>An enumerable of <see cref="nuint"/> values representing the unsigned integer equivalent of the objects.</returns>
    public static IEnumerable<nuint?> ToNuint<T>(params T?[] nums) where T : struct
    {
        if (nums is null || nums.Length < 1)
        {
            yield break;
        }
        for (var i = 0; i < nums.Length; i++)
        {
            yield return nums[i].ToNuint();
        }
    }

    /// <summary>
    /// Converts an enumerable of value-type objects of type <typeparamref name="T"/> to an enumerable of <see cref="nuint"/> values, which represent the unsigned integer equivalent of the objects.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> objects.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the value-type objects to be converted.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="nums">The enumerable of value-type objects to be converted.</param>
    /// <returns>An enumerable of <see cref="nuint"/> values representing the unsigned integer equivalent of the objects.</returns>
    public static IEnumerable<nuint?> ToNuint<T>(this IEnumerable<T?> nums) where T : struct
    {
        if (nums is null || !nums.Any())
        {
            yield break;
        }
        foreach (var num in nums)
        {
            yield return num.ToNuint();
        }
    }

    /// <summary>
    /// Converts an enumerable of value-type objects of type <typeparamref name="T"/> to an enumerable of <see cref="nuint"/> values, which represent the unsigned integer equivalent of the objects.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> objects.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the value-type objects to be converted.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="nums">The enumerable of value-type objects to be converted.</param>
    /// <returns>An enumerable of <see cref="nuint"/> values representing the unsigned integer equivalent of the objects.</returns>
    public static IEnumerable<nuint?> ToNuint<T>(this IReadOnlyCollection<T?> nums) where T : struct
    {
        if (nums is null || nums.Count < 1)
        {
            yield break;
        }
        foreach (var num in nums)
        {
            yield return num.ToNuint();
        }
    }

    /// <summary>
    /// Converts an enumerable of value-type objects of type <typeparamref name="T"/> to an enumerable of <see cref="nuint"/> values, which represent the unsigned integer equivalent of the objects.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> objects.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the value-type objects to be converted.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="nums">The enumerable of value-type objects to be converted.</param>
    /// <returns>An enumerable of <see cref="nuint"/> values representing the unsigned integer equivalent of the objects.</returns>
    public static IEnumerable<nuint?> ToNuint<T>(this IReadOnlyList<T?> nums) where T : struct
    {
        if (nums is null || nums.Count < 1)
        {
            yield break;
        }
        for (var i = 0; i < nums.Count; i++)
        {
            yield return nums[i].ToNuint();
        }
    }

    /// <summary>
    /// Converts an enumerable of value-type objects of type <typeparamref name="T"/> to an enumerable of <see cref="nuint"/> values, which represent the unsigned integer equivalent of the objects.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> objects.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the value-type objects to be converted.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="nums">The enumerable of value-type objects to be converted.</param>
    /// <returns>An enumerable of <see cref="nuint"/> values representing the unsigned integer equivalent of the objects.</returns>
    public static IEnumerable<nuint?> ToNuint<T>(this IReadOnlySet<T?> nums) where T : struct
    {
        if (nums is null || nums.Count < 1)
        {
            yield break;
        }
        foreach (var num in nums)
        {
            yield return num.ToNuint();
        }
    }

    /// <summary>
    /// Parses the string representation of a <see cref="nuint"/> using the default format.
    /// Returns the parsed <see cref="nuint"/> value, or <paramref name="dfltVal"/> if the parsing fails.
    /// </summary>
    /// <typeparam name="T">The type of the default value to be returned, which must be a value type.</typeparam>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="nuint"/> value, or <paramref name="dfltVal"/> if the parsing fails.</returns>
    public static nuint? ToNuint<T>(this string str, T? dfltVal) where T : struct => dfltVal.HasValue ? str.ToNuint(dfltVal.Value) : default;

    /// <summary>
    /// Converts an enumerable of strings <paramref name="strs"/> to an enumerable of <see cref="nuint"/> values, which represent the unsigned integer equivalent of the strings.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> objects.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the default value to be used for conversion.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="dfltVal">The default value to be used for conversion in case of failure.</param>
    /// <param name="strs">The enumerable of strings to be converted.</param>
    /// <returns>An enumerable of <see cref="nuint"/> values representing the unsigned integer equivalent of the strings.</returns>
    public static IEnumerable<nuint?> ToNuint<T>(T? dfltVal, params string[] strs) where T : struct
    {
        if (strs is null || strs.Length < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Length; i++)
        {
            yield return strs[i].ToNuint(dfltVal);
        }
    }

    /// <summary>
    /// Converts an enumerable of strings <paramref name="strs"/> to an enumerable of <see cref="nuint"/> values, which represent the unsigned integer equivalent of the strings.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> objects.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the default value to be used for conversion.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="dfltVal">The default value to be used for conversion in case of failure.</param>
    /// <param name="strs">The enumerable of strings to be converted.</param>
    /// <returns>An enumerable of <see cref="nuint"/> values representing the unsigned integer equivalent of the strings.</returns>
    public static IEnumerable<nuint?> ToNuint<T>(this IEnumerable<string> strs, T? dfltVal) where T : struct
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToNuint(dfltVal);
        }
    }

    /// <summary>
    /// Converts an enumerable of strings <paramref name="strs"/> to an enumerable of <see cref="nuint"/> values, which represent the unsigned integer equivalent of the strings.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> objects.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the default value to be used for conversion.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="dfltVal">The default value to be used for conversion in case of failure.</param>
    /// <param name="strs">The enumerable of strings to be converted.</param>
    /// <returns>An enumerable of <see cref="nuint"/> values representing the unsigned integer equivalent of the strings.</returns>
    public static IEnumerable<nuint?> ToNuint<T>(this IReadOnlyCollection<string> strs, T? dfltVal) where T : struct
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToNuint(dfltVal);
        }
    }

    /// <summary>
    /// Converts an enumerable of strings <paramref name="strs"/> to an enumerable of <see cref="nuint"/> values, which represent the unsigned integer equivalent of the strings.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> objects.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the default value to be used for conversion.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="dfltVal">The default value to be used for conversion in case of failure.</param>
    /// <param name="strs">The enumerable of strings to be converted.</param>
    /// <returns>An enumerable of <see cref="nuint"/> values representing the unsigned integer equivalent of the strings.</returns>
    public static IEnumerable<nuint?> ToNuint<T>(this IReadOnlyList<string> strs, T? dfltVal) where T : struct
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Count; i++)
        {
            yield return strs[i].ToNuint(dfltVal);
        }
    }

    /// <summary>
    /// Converts an enumerable of strings <paramref name="strs"/> to an enumerable of <see cref="nuint"/> values, which represent the unsigned integer equivalent of the strings.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> objects.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the default value to be used for conversion.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="dfltVal">The default value to be used for conversion in case of failure.</param>
    /// <param name="strs">The enumerable of strings to be converted.</param>
    /// <returns>An enumerable of <see cref="nuint"/> values representing the unsigned integer equivalent of the strings.</returns>
    public static IEnumerable<nuint?> ToNuint<T>(this IReadOnlySet<string> strs, T? dfltVal) where T : struct
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToNuint(dfltVal);
        }
    }

    /// <summary>
    /// Generates a random <see cref="nuint"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, <see langword="default"/> is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="nuint"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static nuint? GenerateRandomNuint<T1, T2>(T1? min, T2 max) where T1 : struct where T2 : struct => min.HasValue ? GenerateRandomNuint(min.Value, max) : default;

    /// <summary>
    /// Generates an enumerable of random <see cref="nuint"/> values between <paramref name="min"/> and <paramref name="max"/> with a specified size <paramref name="size"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, an empty sequence is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <typeparam name="T">The type of the size, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <param name="size">The size of the enumerable to be generated.</param>
    /// <returns>An enumerable of random <see cref="nuint"/> values between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static IEnumerable<nuint?> GenerateRandomNuint<T1, T2, T>(T1? min, T2 max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < YANLib.YANNum.ToUlong(size); i++)
        {
            yield return GenerateRandomNuint(min, max);
        }
    }

    /// <summary>
    /// Generates an enumerable of random <see cref="nuint"/> values between <paramref name="min"/> and <paramref name="max"/> with a specified size <paramref name="size"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, an empty sequence is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <typeparam name="T">The type of the size, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <param name="size">The size of the enumerable to be generated.</param>
    /// <returns>An enumerable of random <see cref="nuint"/> values between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static IEnumerable<nuint?> GenerateRandomNuint<T1, T2, T>(T1? min, T2 max, T? size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < YANLib.YANNum.ToUlong(size); i++)
        {
            yield return GenerateRandomNuint(min, max);
        }
    }

    /// <summary>
    /// Generates a random <see cref="nuint"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, <see langword="default"/> is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="nuint"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static nuint? GenerateRandomNuint<T1, T2>(T1 min, T2? max) where T1 : struct where T2 : struct => max.HasValue ? GenerateRandomNuint(min, max.Value) : default;

    /// <summary>
    /// Generates an enumerable of random <see cref="nuint"/> values between <paramref name="min"/> and <paramref name="max"/> with a specified size <paramref name="size"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, an empty sequence is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <typeparam name="T">The type of the size, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <param name="size">The size of the enumerable to be generated.</param>
    /// <returns>An enumerable of random <see cref="nuint"/> values between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static IEnumerable<nuint?> GenerateRandomNuint<T1, T2, T>(T1 min, T2? max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < YANLib.YANNum.ToUlong(size); i++)
        {
            yield return GenerateRandomNuint(min, max);
        }
    }

    /// <summary>
    /// Generates an enumerable of random <see cref="nuint"/> values between <paramref name="min"/> and <paramref name="max"/> with a specified size <paramref name="size"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, an empty sequence is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <typeparam name="T">The type of the size, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <param name="size">The size of the enumerable to be generated.</param>
    /// <returns>An enumerable of random <see cref="nuint"/> values between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static IEnumerable<nuint?> GenerateRandomNuint<T1, T2, T>(T1 min, T2? max, T? size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < YANLib.YANNum.ToUlong(size); i++)
        {
            yield return GenerateRandomNuint(min, max);
        }
    }

    /// <summary>
    /// Generates a random <see cref="nuint"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, <see langword="default"/> is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="nuint"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static nuint? GenerateRandomNuint<T1, T2>(T1? min, T2? max) where T1 : struct where T2 : struct => min.HasValue ? GenerateRandomNuint(min.Value, max) : default;

    /// <summary>
    /// Generates an enumerable of random <see cref="nuint"/> values between <paramref name="min"/> and <paramref name="max"/> with a specified size <paramref name="size"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, an empty sequence is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <typeparam name="T">The type of the size, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <param name="size">The size of the enumerable to be generated.</param>
    /// <returns>An enumerable of random <see cref="nuint"/> values between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static IEnumerable<nuint?> GenerateRandomNuint<T1, T2, T>(T1? min, T2? max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < YANLib.YANNum.ToUlong(size); i++)
        {
            yield return GenerateRandomNuint(min, max);
        }
    }

    /// <summary>
    /// Generates an enumerable of random <see cref="nuint"/> values between <paramref name="min"/> and <paramref name="max"/> with a specified size <paramref name="size"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, an empty sequence is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <typeparam name="T">The type of the size, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <param name="size">The size of the enumerable to be generated.</param>
    /// <returns>An enumerable of random <see cref="nuint"/> values between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static IEnumerable<nuint?> GenerateRandomNuint<T1, T2, T>(T1? min, T2? max, T? size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < YANLib.YANNum.ToUlong(size); i++)
        {
            yield return GenerateRandomNuint(min, max);
        }
    }

    /// <summary>
    /// Generates a random <see cref="nuint"/> value between <see cref="nuint.MinValue"/> and <paramref name="max"/>.
    /// </summary>
    /// <typeparam name="T">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="nuint"/> value between <see cref="nuint.MinValue"/> and <paramref name="max"/>.</returns>
    public static nuint? GenerateRandomNuint<T>(T? max) where T : struct => max.HasValue ? GenerateRandomNuint(nuint.MinValue, max.Value) : default;
}
