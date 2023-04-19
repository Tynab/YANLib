namespace YANLib.Nullable;

public partial class YANNum
{
    /// <summary>
    /// Converts the specified value to a single-precision floating-point number.
    /// Returns the converted <see cref="float"/> value, or <see langword="default"/> if the conversion fails.
    /// </summary>
    /// <typeparam name="T">The type of the value to be converted, which must be a value type.</typeparam>
    /// <param name="num">The value to be converted.</param>
    /// <returns>The converted <see cref="float"/> value, or <see langword="default"/> if the conversion fails.</returns>
    public static float? ToFloat<T>(this T num) where T : struct
    {
        try
        {
            return Convert.ToSingle(num);
        }
        catch
        {
            return default;
        }
    }

    /// <summary>
    /// Converts an enumerable of value-type objects of type <typeparamref name="T"/> to an <see cref="IEnumerable{float}"/> containing the float representations of the objects.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> objects.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the value-type objects to be converted.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="nums">The enumerable of value-type objects to be converted.</param>
    /// <returns>An <see cref="IEnumerable{float}"/> containing the float representations of the objects.</returns>
    public static IEnumerable<float?> ToFloat<T>(params T[] nums) where T : struct
    {
        if (nums is null || nums.Length < 1)
        {
            yield break;
        }
        for (var i = 0; i < nums.Length; i++)
        {
            yield return nums[i].ToFloat();
        }
    }

    /// <summary>
    /// Converts an enumerable of value-type objects of type <typeparamref name="T"/> to an <see cref="IEnumerable{float}"/> containing the float representations of the objects.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> objects.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the value-type objects to be converted.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="nums">The enumerable of value-type objects to be converted.</param>
    /// <returns>An <see cref="IEnumerable{float}"/> containing the float representations of the objects.</returns>
    public static IEnumerable<float?> ToFloat<T>(this IEnumerable<T> nums) where T : struct
    {
        if (nums is null || !nums.Any())
        {
            yield break;
        }
        foreach (var num in nums)
        {
            yield return num.ToFloat();
        }
    }

    /// <summary>
    /// Converts an enumerable of value-type objects of type <typeparamref name="T"/> to an <see cref="IEnumerable{float}"/> containing the float representations of the objects.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> objects.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the value-type objects to be converted.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="nums">The enumerable of value-type objects to be converted.</param>
    /// <returns>An <see cref="IEnumerable{float}"/> containing the float representations of the objects.</returns>
    public static IEnumerable<float?> ToFloat<T>(this IReadOnlyCollection<T> nums) where T : struct
    {
        if (nums is null || nums.Count < 1)
        {
            yield break;
        }
        foreach (var num in nums)
        {
            yield return num.ToFloat();
        }
    }

    /// <summary>
    /// Converts an enumerable of value-type objects of type <typeparamref name="T"/> to an <see cref="IEnumerable{float}"/> containing the float representations of the objects.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> objects.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the value-type objects to be converted.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="nums">The enumerable of value-type objects to be converted.</param>
    /// <returns>An <see cref="IEnumerable{float}"/> containing the float representations of the objects.</returns>
    public static IEnumerable<float?> ToFloat<T>(this IReadOnlyList<T> nums) where T : struct
    {
        if (nums is null || nums.Count < 1)
        {
            yield break;
        }
        for (var i = 0; i < nums.Count; i++)
        {
            yield return nums[i].ToFloat();
        }
    }

    /// <summary>
    /// Parses the string representation of a <see cref="float"/> using the default format.
    /// Returns the parsed <see cref="float"/> value, or <see langword="default"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="float"/> value, or <see langword="default"/> if the parsing fails.</returns>
    public static float? ToFloat(this string str) => float.TryParse(str, out var num) ? num : default;

    /// <summary>
    /// Converts an enumerable of strings <paramref name="strs"/> to an <see cref="IEnumerable{float}"/> containing the float representations of the strings.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> strings.
    /// </summary>
    /// <param name="strs">The enumerable of strings to be converted to float.</param>
    /// <returns>An <see cref="IEnumerable{float}"/> containing the float representations of the strings.</returns>
    public static IEnumerable<float?> ToFloat(params string[] strs)
    {
        if (strs is null || strs.Length < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Length; i++)
        {
            yield return strs[i].ToFloat();
        }
    }

    /// <summary>
    /// Converts an enumerable of strings <paramref name="strs"/> to an <see cref="IEnumerable{float}"/> containing the float representations of the strings.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> strings.
    /// </summary>
    /// <param name="strs">The enumerable of strings to be converted to float.</param>
    /// <returns>An <see cref="IEnumerable{float}"/> containing the float representations of the strings.</returns>
    public static IEnumerable<float?> ToFloat(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToFloat();
        }
    }

    /// <summary>
    /// Converts an enumerable of strings <paramref name="strs"/> to an <see cref="IEnumerable{float}"/> containing the float representations of the strings.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> strings.
    /// </summary>
    /// <param name="strs">The enumerable of strings to be converted to float.</param>
    /// <returns>An <see cref="IEnumerable{float}"/> containing the float representations of the strings.</returns>
    public static IEnumerable<float?> ToFloat(this IReadOnlyCollection<string> strs)
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToFloat();
        }
    }

    /// <summary>
    /// Converts an enumerable of strings <paramref name="strs"/> to an <see cref="IEnumerable{float}"/> containing the float representations of the strings.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> strings.
    /// </summary>
    /// <param name="strs">The enumerable of strings to be converted to float.</param>
    /// <returns>An <see cref="IEnumerable{float}"/> containing the float representations of the strings.</returns>
    public static IEnumerable<float?> ToFloat(this IReadOnlyList<string> strs)
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Count; i++)
        {
            yield return strs[i].ToFloat();
        }
    }

    /// <summary>
    /// Parses the string representation of a float using the default format.
    /// Returns the parsed <see cref="float"/> value, or <paramref name="dfltVal"/> if the parsing fails.
    /// </summary>
    /// <typeparam name="T">The type of the default value to be returned, which must be a value type.</typeparam>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="float"/> value, or <paramref name="dfltVal"/> if the parsing fails.</returns>
    public static float? ToFloat<T>(this string str, T dfltVal) where T : struct => float.TryParse(str, out var num) ? num : dfltVal.ToFloat();

    /// <summary>
    /// Converts an enumerable of strings <paramref name="strs"/> to an <see cref="IEnumerable{float}"/> containing the float representations of the strings, using a default value <paramref name="dfltVal"/> for parsing invalid or null strings.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> strings.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the default value for parsing invalid or null strings.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="dfltVal">The default value to be used for parsing invalid or null strings.</param>
    /// <param name="strs">The enumerable of strings to be converted to float.</param>
    /// <returns>An <see cref="IEnumerable{float}"/> containing the float representations of the strings.</returns>
    public static IEnumerable<float?> ToFloat<T>(T dfltVal, params string[] strs) where T : struct
    {
        if (strs is null || strs.Length < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Length; i++)
        {
            yield return strs[i].ToFloat(dfltVal);
        }
    }

    /// <summary>
    /// Converts an enumerable of strings <paramref name="strs"/> to an <see cref="IEnumerable{float}"/> containing the float representations of the strings, using a default value <paramref name="dfltVal"/> for parsing invalid or null strings.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> strings.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the default value for parsing invalid or null strings.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="dfltVal">The default value to be used for parsing invalid or null strings.</param>
    /// <param name="strs">The enumerable of strings to be converted to float.</param>
    /// <returns>An <see cref="IEnumerable{float}"/> containing the float representations of the strings.</returns>
    public static IEnumerable<float?> ToFloat<T>(this IEnumerable<string> strs, T dfltVal) where T : struct
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToFloat(dfltVal);
        }
    }

    /// <summary>
    /// Converts an enumerable of strings <paramref name="strs"/> to an <see cref="IEnumerable{float}"/> containing the float representations of the strings, using a default value <paramref name="dfltVal"/> for parsing invalid or null strings.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> strings.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the default value for parsing invalid or null strings.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="dfltVal">The default value to be used for parsing invalid or null strings.</param>
    /// <param name="strs">The enumerable of strings to be converted to float.</param>
    /// <returns>An <see cref="IEnumerable{float}"/> containing the float representations of the strings.</returns>
    public static IEnumerable<float?> ToFloat<T>(this IReadOnlyCollection<string> strs, T dfltVal) where T : struct
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToFloat(dfltVal);
        }
    }

    /// <summary>
    /// Converts an enumerable of strings <paramref name="strs"/> to an <see cref="IEnumerable{float}"/> containing the float representations of the strings, using a default value <paramref name="dfltVal"/> for parsing invalid or null strings.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> strings.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the default value for parsing invalid or null strings.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="dfltVal">The default value to be used for parsing invalid or null strings.</param>
    /// <param name="strs">The enumerable of strings to be converted to float.</param>
    /// <returns>An <see cref="IEnumerable{float}"/> containing the float representations of the strings.</returns>
    public static IEnumerable<float?> ToFloat<T>(this IReadOnlyList<string> strs, T dfltVal) where T : struct
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Count; i++)
        {
            yield return strs[i].ToFloat(dfltVal);
        }
    }

    /// <summary>
    /// Generates a random <see cref="float"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, <see langword="default"/> is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="float"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static float? GenerateRandomFloat<T1, T2>(T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToFloat();
        var maxValue = max.ToFloat();
        return minValue.HasValue && maxValue.HasValue ? minValue > maxValue ? default : new Random().NextSingle(minValue.Value, maxValue.Value) : default;
    }

    /// <summary>
    /// Generates an enumerable of random <see cref="float"/> values between <paramref name="min"/> and <paramref name="max"/>, with the specified <paramref name="size"/> of elements.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, an empty sequence is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <typeparam name="T">The type of the size of elements, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <param name="size">The size of elements to be generated.</param>
    /// <returns>An <see cref="IEnumerable{float}"/> containing random float values between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static IEnumerable<float?> GenerateRandomFloat<T1, T2, T>(T1 min, T2 max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < YANLib.YANNum.ToUlong(size); i++)
        {
            yield return GenerateRandomFloat(min, max);
        }
    }

    /// <summary>
    /// Generates a random <see cref="float"/> value between <see cref="float.MinValue"/> and <see cref="float.MaxValue"/>.
    /// </summary>
    /// <returns>A random <see cref="float"/> value between <see cref="float.MinValue"/> and <see cref="float.MaxValue"/>.</returns>
    public static float? GenerateRandomFloat() => GenerateRandomFloat(float.MinValue, float.MaxValue);

    /// <summary>
    /// Generates a random <see cref="float"/> value between <see cref="float.MinValue"/> and <paramref name="max"/>.
    /// </summary>
    /// <typeparam name="T">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="float"/> value between <see cref="float.MinValue"/> and <paramref name="max"/>.</returns>
    public static float? GenerateRandomFloat<T>(T max) where T : struct => GenerateRandomFloat(float.MinValue, max);
}
