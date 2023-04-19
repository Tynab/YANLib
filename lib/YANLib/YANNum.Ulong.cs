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

    /// <summary>
    /// Converts an enumerable of value-type objects of type <typeparamref name="T"/> to an <see cref="IEnumerable{ulong}"/> containing the ulong representations of the objects.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> objects.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the value-type objects to be converted.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="nums">The enumerable of value-type objects to be converted.</param>
    /// <returns>An <see cref="IEnumerable{ulong}"/> containing the ulong representations of the objects.</returns>
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

    /// <summary>
    /// Converts an enumerable of value-type objects of type <typeparamref name="T"/> to an <see cref="IEnumerable{ulong}"/> containing the ulong representations of the objects.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> objects.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the value-type objects to be converted.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="nums">The enumerable of value-type objects to be converted.</param>
    /// <returns>An <see cref="IEnumerable{ulong}"/> containing the ulong representations of the objects.</returns>
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

    /// <summary>
    /// Converts an enumerable of value-type objects of type <typeparamref name="T"/> to an <see cref="IEnumerable{ulong}"/> containing the ulong representations of the objects.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> objects.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the value-type objects to be converted.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="nums">The enumerable of value-type objects to be converted.</param>
    /// <returns>An <see cref="IEnumerable{ulong}"/> containing the ulong representations of the objects.</returns>
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

    /// <summary>
    /// Converts an enumerable of value-type objects of type <typeparamref name="T"/> to an <see cref="IEnumerable{ulong}"/> containing the ulong representations of the objects.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> objects.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the value-type objects to be converted.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="nums">The enumerable of value-type objects to be converted.</param>
    /// <returns>An <see cref="IEnumerable{ulong}"/> containing the ulong representations of the objects.</returns>
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

    /// <summary>
    /// Parses the string representation of an unsigned long integer using the default format.
    /// Returns the parsed <see cref="ulong"/> value, or <see langword="default"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="ulong"/> value, or <see langword="default"/> if the parsing fails.</returns>
    public static ulong ToUlong(this string str) => ulong.TryParse(str, out var num) ? num : default;

    /// <summary>
    /// Converts an enumerable of strings <paramref name="strs"/> to an <see cref="IEnumerable{ulong}"/> containing the ulong representations of the strings.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> strings.
    /// </summary>
    /// <param name="strs">The enumerable of strings to be converted.</param>
    /// <returns>An <see cref="IEnumerable{ulong}"/> containing the ulong representations of the strings.</returns>
    public static IEnumerable<ulong> ToUlong(params string[] strs)
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

    /// <summary>
    /// Converts an enumerable of strings <paramref name="strs"/> to an <see cref="IEnumerable{ulong}"/> containing the ulong representations of the strings.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> strings.
    /// </summary>
    /// <param name="strs">The enumerable of strings to be converted.</param>
    /// <returns>An <see cref="IEnumerable{ulong}"/> containing the ulong representations of the strings.</returns>
    public static IEnumerable<ulong> ToUlong(this IEnumerable<string> strs)
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

    /// <summary>
    /// Converts an enumerable of strings <paramref name="strs"/> to an <see cref="IEnumerable{ulong}"/> containing the ulong representations of the strings.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> strings.
    /// </summary>
    /// <param name="strs">The enumerable of strings to be converted.</param>
    /// <returns>An <see cref="IEnumerable{ulong}"/> containing the ulong representations of the strings.</returns>
    public static IEnumerable<ulong> ToUlong(this IReadOnlyCollection<string> strs)
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
    /// Converts an enumerable of strings <paramref name="strs"/> to an <see cref="IEnumerable{ulong}"/> containing the ulong representations of the strings.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> strings.
    /// </summary>
    /// <param name="strs">The enumerable of strings to be converted.</param>
    /// <returns>An <see cref="IEnumerable{ulong}"/> containing the ulong representations of the strings.</returns>
    public static IEnumerable<ulong> ToUlong(this IReadOnlyList<string> strs)
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

    /// <summary>
    /// Parses the string representation of an <see cref="ulong"/> using the default format.
    /// Returns the parsed <see cref="ulong"/> value, or <paramref name="dfltVal"/> if the parsing fails.
    /// </summary>
    /// <typeparam name="T">The type of the default value to be returned, which must be a value type.</typeparam>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="ulong"/> value, or <paramref name="dfltVal"/> if the parsing fails.</returns>
    public static ulong ToUlong<T>(this string str, T dfltVal) where T : struct => ulong.TryParse(str, out var num) ? num : dfltVal.ToUlong();

    /// <summary>
    /// Converts an enumerable of strings <paramref name="strs"/> to an <see cref="IEnumerable{ulong}"/> containing the ulong representations of the strings.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> strings.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the default value to be used when converting strings to ulong.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="dfltVal">The default value to be used when converting strings to ulong.</param>
    /// <param name="strs">The enumerable of strings to be converted.</param>
    /// <returns>An <see cref="IEnumerable{ulong}"/> containing the ulong representations of the strings.</returns>
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

    /// <summary>
    /// Converts an enumerable of strings <paramref name="strs"/> to an <see cref="IEnumerable{ulong}"/> containing the ulong representations of the strings.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> strings.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the default value to be used when converting strings to ulong.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="dfltVal">The default value to be used when converting strings to ulong.</param>
    /// <param name="strs">The enumerable of strings to be converted.</param>
    /// <returns>An <see cref="IEnumerable{ulong}"/> containing the ulong representations of the strings.</returns>
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

    /// <summary>
    /// Converts an enumerable of strings <paramref name="strs"/> to an <see cref="IEnumerable{ulong}"/> containing the ulong representations of the strings.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> strings.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the default value to be used when converting strings to ulong.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="dfltVal">The default value to be used when converting strings to ulong.</param>
    /// <param name="strs">The enumerable of strings to be converted.</param>
    /// <returns>An <see cref="IEnumerable{ulong}"/> containing the ulong representations of the strings.</returns>
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

    /// <summary>
    /// Converts an enumerable of strings <paramref name="strs"/> to an <see cref="IEnumerable{ulong}"/> containing the ulong representations of the strings.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> strings.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the default value to be used when converting strings to ulong.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="dfltVal">The default value to be used when converting strings to ulong.</param>
    /// <param name="strs">The enumerable of strings to be converted.</param>
    /// <returns>An <see cref="IEnumerable{ulong}"/> containing the ulong representations of the strings.</returns>
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

    /// <summary>
    /// Generates an enumerable of random <see cref="ulong"/> values between <paramref name="min"/> and <paramref name="max"/>.
    /// The number of values generated is determined by the value of <paramref name="size"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, an empty sequence is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <typeparam name="T">The type of the size value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <param name="size">The number of random values to generate.</param>
    /// <returns>An <see cref="IEnumerable{ulong}"/> containing the generated random ulong values.</returns>
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
