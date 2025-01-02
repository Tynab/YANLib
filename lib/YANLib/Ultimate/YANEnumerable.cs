using YANLib.Object;
using YANLib.Text;

namespace YANLib.Ultimate;

public static partial class YANEnumerable
{
    public static IEnumerable<T?> Clean<T>(this IEnumerable<T?>? srcs)
    {
        if (srcs.IsNullOEmpty())
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
        if (srcs.IsNullOEmpty())
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
        if (srcs.IsNullOEmpty())
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

    public static IEnumerable<IEnumerable<T?>> Cleans<T>(this IEnumerable<IEnumerable<T?>?>? srcs, bool? deepClean = null)
    {
        if (srcs.IsNullOEmpty())
        {
            yield break;
        }

        foreach (var src in srcs)
        {
            if (src.IsNotNullNEmpty())
            {
                yield return deepClean.HasValue && deepClean.Value ? src.Clean() : src;
            }
        }
    }

    public static IEnumerable<IEnumerable<T?>> Cleans<T>(this IEnumerable<ICollection<T?>?>? srcs, bool? deepClean = null)
    {
        if (srcs.IsNullOEmpty())
        {
            yield break;
        }

        foreach (var src in srcs)
        {
            if (src.IsNotNullNEmpty())
            {
                yield return deepClean.HasValue && deepClean.Value ? src.Clean() : src;
            }
        }
    }

    public static IEnumerable<IEnumerable<T?>> Cleans<T>(this IEnumerable<T?[]?>? srcs, bool? deepClean = null)
    {
        if (srcs.IsNullOEmpty())
        {
            yield break;
        }

        foreach (var src in srcs)
        {
            if (src.IsNotNullNEmpty())
            {
                yield return deepClean.HasValue && deepClean.Value ? src.Clean() : src;
            }
        }
    }

    public static IEnumerable<IEnumerable<T?>> Cleans<T>(this ICollection<IEnumerable<T?>?>? srcs, bool? deepClean = null)
    {
        if (srcs.IsNullOEmpty())
        {
            yield break;
        }

        foreach (var src in srcs)
        {
            if (src.IsNotNullNEmpty())
            {
                yield return deepClean.HasValue && deepClean.Value ? src.Clean() : src;
            }
        }
    }

    public static IEnumerable<IEnumerable<T?>> Cleans<T>(this ICollection<ICollection<T?>?>? srcs, bool? deepClean = null)
    {
        if (srcs.IsNullOEmpty())
        {
            yield break;
        }

        foreach (var src in srcs)
        {
            if (src.IsNotNullNEmpty())
            {
                yield return deepClean.HasValue && deepClean.Value ? src.Clean() : src;
            }
        }
    }

    public static IEnumerable<IEnumerable<T?>> Cleans<T>(this ICollection<T?[]?>? srcs, bool? deepClean = null)
    {
        if (srcs.IsNullOEmpty())
        {
            yield break;
        }

        foreach (var src in srcs)
        {
            if (src.IsNotNullNEmpty())
            {
                yield return deepClean.HasValue && deepClean.Value ? src.Clean() : src;
            }
        }
    }

    public static IEnumerable<IEnumerable<T?>> Cleans<T>(this IEnumerable<T?>?[]? srcs, bool? deepClean = null)
    {
        if (srcs.IsNullOEmpty())
        {
            yield break;
        }

        foreach (var src in srcs)
        {
            if (src.IsNotNullNEmpty())
            {
                yield return deepClean.HasValue && deepClean.Value ? src.Clean() : src;
            }
        }
    }

    public static IEnumerable<IEnumerable<T?>> Cleans<T>(this ICollection<T?>?[]? srcs, bool? deepClean = null)
    {
        if (srcs.IsNullOEmpty())
        {
            yield break;
        }

        foreach (var src in srcs)
        {
            if (src.IsNotNullNEmpty())
            {
                yield return deepClean.HasValue && deepClean.Value ? src.Clean() : src;
            }
        }
    }

    public static IEnumerable<IEnumerable<T?>> Cleans<T>(this T?[]?[]? srcs, bool? deepClean = null)
    {
        if (srcs.IsNullOEmpty())
        {
            yield break;
        }

        foreach (var src in srcs)
        {
            if (src.IsNotNullNEmpty())
            {
                yield return deepClean.HasValue && deepClean.Value ? src.Clean() : src;
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
        if (srcs.IsNullOEmpty())
        {
            yield break;
        }

        foreach (var src in srcs)
        {
            if (src.IsNotNullNWhiteSpace())
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
        if (srcs.IsNullOEmpty())
        {
            yield break;
        }

        foreach (var src in srcs)
        {
            if (src.IsNotNullNWhiteSpace())
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
        if (srcs.IsNullOEmpty())
        {
            yield break;
        }

        foreach (var src in srcs)
        {
            if (src.IsNotNullNWhiteSpace())
            {
                yield return src;
            }
        }
    }

    public static IEnumerable<IEnumerable<string?>?>? Cleans(this IEnumerable<IEnumerable<string?>?>? srcs, bool? deepClean = null)
    {
        if (srcs.IsNullOEmpty())
        {
            yield break;
        }

        foreach (var src in srcs)
        {
            if (src.IsNotNullNEmpty())
            {
                yield return deepClean.HasValue && deepClean.Value ? src.Clean() : src;
            }
        }
    }

    public static IEnumerable<IEnumerable<string?>?>? Cleans(this IEnumerable<ICollection<string?>?>? srcs, bool? deepClean = null)
    {
        if (srcs.IsNullOEmpty())
        {
            yield break;
        }

        foreach (var src in srcs)
        {
            if (src.IsNotNullNEmpty())
            {
                yield return deepClean.HasValue && deepClean.Value ? src.Clean() : src;
            }
        }
    }

    public static IEnumerable<IEnumerable<string?>?>? Cleans(this IEnumerable<string?[]?>? srcs, bool? deepClean = null)
    {
        if (srcs.IsNullOEmpty())
        {
            yield break;
        }

        foreach (var src in srcs)
        {
            if (src.IsNotNullNEmpty())
            {
                yield return deepClean.HasValue && deepClean.Value ? src.Clean() : src;
            }
        }
    }

    public static IEnumerable<IEnumerable<string?>?>? Cleans(this ICollection<IEnumerable<string?>?>? srcs, bool? deepClean = null)
    {
        if (srcs.IsNullOEmpty())
        {
            yield break;
        }

        foreach (var src in srcs)
        {
            if (src.IsNotNullNEmpty())
            {
                yield return deepClean.HasValue && deepClean.Value ? src.Clean() : src;
            }
        }
    }

    public static IEnumerable<IEnumerable<string?>?>? Cleans(this ICollection<ICollection<string?>?>? srcs, bool? deepClean = null)
    {
        if (srcs.IsNullOEmpty())
        {
            yield break;
        }

        foreach (var src in srcs)
        {
            if (src.IsNotNullNEmpty())
            {
                yield return deepClean.HasValue && deepClean.Value ? src.Clean() : src;
            }
        }
    }

    public static IEnumerable<IEnumerable<string?>?>? Cleans(this ICollection<string?[]?>? srcs, bool? deepClean = null)
    {
        if (srcs.IsNullOEmpty())
        {
            yield break;
        }

        foreach (var src in srcs)
        {
            if (src.IsNotNullNEmpty())
            {
                yield return deepClean.HasValue && deepClean.Value ? src.Clean() : src;
            }
        }
    }

    public static IEnumerable<IEnumerable<string?>?>? Cleans(this IEnumerable<string?>?[]? srcs, bool? deepClean = null)
    {
        if (srcs.IsNullOEmpty())
        {
            yield break;
        }

        foreach (var src in srcs)
        {
            if (src.IsNotNullNEmpty())
            {
                yield return deepClean.HasValue && deepClean.Value ? src.Clean() : src;
            }
        }
    }

    public static IEnumerable<IEnumerable<string?>?>? Cleans(this ICollection<string?>?[]? srcs, bool? deepClean = null)
    {
        if (srcs.IsNullOEmpty())
        {
            yield break;
        }

        foreach (var src in srcs)
        {
            if (src.IsNotNullNEmpty())
            {
                yield return deepClean.HasValue && deepClean.Value ? src.Clean() : src;
            }
        }
    }

    public static IEnumerable<IEnumerable<string?>?>? Cleans(this string?[]?[]? srcs, bool? deepClean = null)
    {
        if (srcs.IsNullOEmpty())
        {
            yield break;
        }

        foreach (var src in srcs)
        {
            if (src.IsNotNullNEmpty())
            {
                yield return deepClean.HasValue && deepClean.Value ? src.Clean() : src;
            }
        }
    }
}
