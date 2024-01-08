using YANLib.Core;

namespace YANLib.Ultimate.Core;

public static partial class YANEnumerable
{
    public static IEnumerable<T?> Clean<T>(this IEnumerable<T?>? srcs)
    {
        if (srcs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var src in srcs)
        {
            if (src.IsNotNull())
            {
                yield return src;
            }
        }
    }

    public static IEnumerable<T?> Clean<T>(this ICollection<T?>? srcs)
    {
        if (srcs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var src in srcs)
        {
            if (src.IsNotNull())
            {
                yield return src;
            }
        }
    }

    public static IEnumerable<T?> Clean<T>(this T?[]? srcs)
    {
        if (srcs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var src in srcs)
        {
            if (src.IsNotNull())
            {
                yield return src;
            }
        }
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
