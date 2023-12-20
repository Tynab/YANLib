using static System.Nullable;

namespace YANLib.Ultimate;

public static partial class YANEnumerable
{
    /// <summary>
    /// Removes <see langword="null"/> elements from a collection of nullable or class type elements.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection. Must be a class or nullable type.</typeparam>
    /// <param name="srcs">The collection of elements to be cleaned. Can contain <see langword="null"/> values.</param>
    /// <returns>An enumerable collection with <see langword="null"/> elements removed.</returns>
    private static IEnumerable<T?> CleanNullableOrClass<T>(IEnumerable<T?> srcs)
    {
        foreach (var src in srcs)
        {
            if (src is not null)
            {
                yield return src;
            }
        }
    }

    /// <summary>
    /// Cleans the collection of elements by removing <see langword="null"/> values.
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Applies cleaning only if the type <typeparamref name="T"/> is a class or nullable type; otherwise, returns the collection unchanged.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection. Can be any type.</typeparam>
    /// <param name="srcs">The collection of elements to be cleaned. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of elements with <see langword="null"/> values removed, or the original collection if <typeparamref name="T"/> is not a class or nullable type.</returns>
    public static IEnumerable<T?>? Clean<T>(this IEnumerable<T?>? srcs)
    {
        if (srcs.IsEmptyOrNull())
        {
            return default;
        }

        var t = typeof(T);

        return t.IsClass || GetUnderlyingType(t) is not null ? CleanNullableOrClass(srcs) : srcs;
    }

    /// <summary>
    /// Cleans the collection (ICollection) of elements by removing <see langword="null"/> values.
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Applies cleaning only if the type <typeparamref name="T"/> is a class or nullable type; otherwise, returns the collection unchanged.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection. Can be any type.</typeparam>
    /// <param name="srcs">The ICollection of elements to be cleaned. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of elements with <see langword="null"/> values removed, or the original collection if <typeparamref name="T"/> is not a class or nullable type.</returns>
    public static IEnumerable<T?>? Clean<T>(this ICollection<T?>? srcs)
    {
        if (srcs.IsEmptyOrNull())
        {
            return default;
        }

        var t = typeof(T);

        return t.IsClass || GetUnderlyingType(t) is not null ? CleanNullableOrClass(srcs) : srcs;
    }

    /// <summary>
    /// Cleans an array of elements by removing <see langword="null"/> values.
    /// If the array is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Applies cleaning only if the type <typeparamref name="T"/> is a class or nullable type; otherwise, returns the array unchanged.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array. Can be any type.</typeparam>
    /// <param name="srcs">The array of elements to be cleaned. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of elements with <see langword="null"/> values removed, or the original array if <typeparamref name="T"/> is not a class or nullable type.</returns>
    public static IEnumerable<T?>? Clean<T>(this T?[]? srcs)
    {
        if (srcs.IsEmptyOrNull())
        {
            return default;
        }

        var t = typeof(T);

        return t.IsClass || GetUnderlyingType(t) is not null ? CleanNullableOrClass(srcs) : srcs;
    }

    /// <summary>
    /// Cleans a collection of strings by removing <see langword="null"/> and white-space strings.
    /// If the collection is <see langword="null"/> or empty, yields no results.
    /// Each string in the collection is checked; only non-null and non-white-space strings are yielded.
    /// </summary>
    /// <param name="srcs">The collection of strings to be cleaned. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of strings with <see langword="null"/> and white-space strings removed.</returns>
    public static IEnumerable<string?> Clean(this IEnumerable<string?>? srcs)
    {
        if (srcs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var src in srcs)
        {
            if (src.IsNotWhiteSpaceAndNull())
            {
                yield return src;
            }
        }
    }

    /// <summary>
    /// Cleans a collection (ICollection) of strings by removing <see langword="null"/> and white-space strings.
    /// If the collection is <see langword="null"/> or empty, yields no results.
    /// Each string in the collection is checked; only non-null and non-white-space strings are yielded.
    /// </summary>
    /// <param name="srcs">The ICollection of strings to be cleaned. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of strings with <see langword="null"/> and white-space strings removed.</returns>
    public static IEnumerable<string?> Clean(this ICollection<string?>? srcs)
    {
        if (srcs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var src in srcs)
        {
            if (src.IsNotWhiteSpaceAndNull())
            {
                yield return src;
            }
        }
    }

    /// <summary>
    /// Cleans an array of strings by removing <see langword="null"/> and white-space strings.
    /// If the array is <see langword="null"/> or empty, yields no results.
    /// Each string in the array is checked; only non-null and non-white-space strings are yielded.
    /// </summary>
    /// <param name="srcs">The array of strings to be cleaned. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of strings with <see langword="null"/> and white-space strings removed.</returns>
    public static IEnumerable<string?> Clean(this string?[]? srcs)
    {
        if (srcs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var src in srcs)
        {
            if (src.IsNotWhiteSpaceAndNull())
            {
                yield return src;
            }
        }
    }
}
