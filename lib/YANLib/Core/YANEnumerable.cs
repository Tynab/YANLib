using static System.Math;
using static System.Nullable;

namespace YANLib.Core;

public static partial class YANEnumerable
{
    /// <summary>
    /// Divides a collection of elements into chunks of a specified size.
    /// If the source collection is <see langword="null"/> or empty, or if the chunk size is zero, yields no results.
    /// </summary>
    /// <param name="srcs">The source collection of elements to be chunked. Can be <see langword="null"/>.</param>
    /// <param name="chunkSize">The size of each chunk. Can be <see langword="null"/>, resulting in a default size of 0.</param>
    /// <returns>An enumerable collection of lists, each containing a chunk of elements from the source collection.</returns>
    public static IEnumerable<List<T>> ChunkBySize<T>(this IEnumerable<T>? srcs, object? chunkSize)
    {
        var size = (int)chunkSize.ToUint();

        if (srcs.IsEmptyOrNull() || size is 0)
        {
            yield break;
        }

        var srcsList = srcs.ToList();
        var cnt = srcsList.Count;

        for (var i = 0; i < cnt; i += size)
        {
            yield return srcsList.GetRange(i, Min(size, cnt - i));
        }
    }

    /// <summary>
    /// Divides a collection (ICollection) of elements into chunks of a specified size.
    /// If the source collection is <see langword="null"/> or empty, or if the chunk size is zero, yields no results.
    /// </summary>
    /// <param name="srcs">The source ICollection of elements to be chunked. Can be <see langword="null"/>.</param>
    /// <param name="chunkSize">The size of each chunk. Can be <see langword="null"/>, resulting in a default size of 0.</param>
    /// <returns>An enumerable collection of lists, each containing a chunk of elements from the source collection.</returns>
    public static IEnumerable<List<T>> ChunkBySize<T>(this ICollection<T>? srcs, object? chunkSize)
    {
        var size = (int)chunkSize.ToUint();

        if (srcs.IsEmptyOrNull() || size is 0)
        {
            yield break;
        }

        var cnt = srcs.Count;

        for (var i = 0; i < cnt; i += size)
        {
            yield return srcs.ToList().GetRange(i, Min(size, cnt - i));
        }
    }

    /// <summary>
    /// Divides an array of elements into chunks of a specified size.
    /// If the source array is <see langword="null"/> or empty, or if the chunk size is zero, yields no results.
    /// </summary>
    /// <param name="srcs">The source array of elements to be chunked. Can be <see langword="null"/>.</param>
    /// <param name="chunkSize">The size of each chunk. Can be <see langword="null"/>, resulting in a default size of 0.</param>
    /// <returns>An enumerable collection of lists, each containing a chunk of elements from the source array.</returns>
    public static IEnumerable<List<T>> ChunkBySize<T>(this T[]? srcs, object? chunkSize)
    {
        var size = (int)chunkSize.ToUint();

        if (srcs.IsEmptyOrNull() || size is 0)
        {
            yield break;
        }

        var cnt = srcs.Length;

        for (var i = 0; i < cnt; i += size)
        {
            yield return srcs.ToList().GetRange(i, Min(size, cnt - i));
        }
    }

    /// <summary>
    /// Divides a list of elements into chunks of a specified size.
    /// If the source list is <see langword="null"/> or empty, or if the chunk size is zero, yields no results.
    /// </summary>
    /// <param name="srcs">The source list of elements to be chunked. Can be <see langword="null"/>.</param>
    /// <param name="chunkSize">The size of each chunk. Can be <see langword="null"/>, resulting in a default size of 0.</param>
    /// <returns>An enumerable collection of lists, each containing a chunk of elements from the source list.</returns>
    public static IEnumerable<List<T>> ChunkBySize<T>(this List<T>? srcs, object? chunkSize)
    {
        var size = (int)chunkSize.ToUint();

        if (srcs.IsEmptyOrNull() || size is 0)
        {
            yield break;
        }

        var cnt = srcs.Count;

        for (var i = 0; i < cnt; i += size)
        {
            yield return srcs.GetRange(i, Min(size, cnt - i));
        }
    }

    public static IEnumerable<T>? Clean<T>(this IEnumerable<T>? srcs)
    {
        if (srcs.IsEmptyOrNull())
        {
            return srcs;
        }

        var t = typeof(T);

        return t.IsClass || GetUnderlyingType(t).IsNotNull() ? srcs.Where(x => x.IsNotNull()) : srcs;
    }

    public static IEnumerable<T>? Clean<T>(this ICollection<T>? srcs)
    {
        if (srcs.IsEmptyOrNull())
        {
            return srcs;
        }

        var t = typeof(T);

        return t.IsClass || GetUnderlyingType(t).IsNotNull() ? srcs.Where(x => x.IsNotNull()) : srcs;
    }

    public static IEnumerable<T>? Clean<T>(params T[]? srcs)
    {
        if (srcs.IsEmptyOrNull())
        {
            return srcs;
        }

        var t = typeof(T);

        return t.IsClass || GetUnderlyingType(t).IsNotNull() ? srcs.Where(x => x.IsNotNull()) : srcs;
    }

    public static void Clean<T>(this List<T>? srcs)
    {
        if (srcs.IsEmptyOrNull())
        {
            return;
        }

        var t = typeof(T);

        if (t.IsClass || GetUnderlyingType(t).IsNotNull())
        {
            _ = srcs.RemoveAll(x => x.IsNull());
        }
    }

    public static IEnumerable<IEnumerable<T>?>? Cleans<T>(this IEnumerable<IEnumerable<T>?>? srcs, bool? deepClean = null) => srcs.IsEmptyOrNull()
        ? srcs
        : (deepClean.HasValue && deepClean.Value ? srcs.Select(x => x.Clean()) : srcs).Where(x => x.IsNotEmptyAndNull());

    public static IEnumerable<IEnumerable<T>?>? Cleans<T>(this IEnumerable<ICollection<T>?>? srcs, bool? deepClean = null) => srcs.IsEmptyOrNull()
        ? srcs
        : (deepClean.HasValue && deepClean.Value ? srcs.Select(x => x.Clean()) : srcs).Where(x => x.IsNotEmptyAndNull());

    public static IEnumerable<IEnumerable<T>?>? Cleans<T>(this IEnumerable<T[]?>? srcs, bool? deepClean = null) => srcs.IsEmptyOrNull()
        ? srcs
        : (deepClean.HasValue && deepClean.Value ? srcs.Select(x => x.Clean()) : srcs).Where(x => x.IsNotEmptyAndNull());

    public static IEnumerable<IEnumerable<T>?>? Cleans<T>(this ICollection<IEnumerable<T>?>? srcs, bool? deepClean = null) => srcs.IsEmptyOrNull()
        ? srcs
        : (deepClean.HasValue && deepClean.Value ? srcs.Select(x => x.Clean()) : srcs).Where(x => x.IsNotEmptyAndNull());

    public static IEnumerable<IEnumerable<T>?>? Cleans<T>(this ICollection<ICollection<T>?>? srcs, bool? deepClean = null) => srcs.IsEmptyOrNull()
        ? srcs
        : (deepClean.HasValue && deepClean.Value ? srcs.Select(x => x.Clean()) : srcs).Where(x => x.IsNotEmptyAndNull());

    public static IEnumerable<IEnumerable<T>?>? Cleans<T>(this ICollection<T[]?>? srcs, bool? deepClean = null) => srcs.IsEmptyOrNull()
        ? srcs
        : (deepClean.HasValue && deepClean.Value ? srcs.Select(x => x.Clean()) : srcs).Where(x => x.IsNotEmptyAndNull());

    public static IEnumerable<IEnumerable<T>?>? Cleans<T>(this IEnumerable<T>?[]? srcs, bool? deepClean = null) => srcs.IsEmptyOrNull()
        ? srcs
        : (deepClean.HasValue && deepClean.Value ? srcs.Select(x => x.Clean()) : srcs).Where(x => x.IsNotEmptyAndNull());

    public static IEnumerable<IEnumerable<T>?>? Cleans<T>(this ICollection<T>?[]? srcs, bool? deepClean = null) => srcs.IsEmptyOrNull()
        ? srcs
        : (deepClean.HasValue && deepClean.Value ? srcs.Select(x => x.Clean()) : srcs).Where(x => x.IsNotEmptyAndNull());

    public static IEnumerable<IEnumerable<T>?>? Cleans<T>(this T[]?[]? srcs, bool? deepClean = null) => srcs.IsEmptyOrNull()
        ? srcs
        : (deepClean.HasValue && deepClean.Value ? srcs.Select(x => x.Clean()) : srcs).Where(x => x.IsNotEmptyAndNull());

    public static void Cleans<T>(this List<IEnumerable<T>?>? srcs, bool? deepClean = null)
    {
        if (srcs.IsEmptyOrNull())
        {
            return;
        }

        if (deepClean.HasValue && deepClean.Value)
        {
            srcs.ForEach(x => x = x.Clean());
        }

        _ = srcs.RemoveAll(x => x.IsEmptyOrNull());
    }

    public static void Cleans<T>(this List<ICollection<T>?>? srcs, bool? deepClean = null)
    {
        if (srcs.IsEmptyOrNull())
        {
            return;
        }

        if (deepClean.HasValue && deepClean.Value)
        {
            srcs.ForEach(x => x = (ICollection<T>?)x.Clean());
        }

        _ = srcs.RemoveAll(x => x.IsEmptyOrNull());
    }

    public static void Cleans<T>(this List<T[]?>? srcs, bool? deepClean = null)
    {
        if (srcs.IsEmptyOrNull())
        {
            return;
        }

        if (deepClean.HasValue && deepClean.Value)
        {
            srcs.ForEach(x => x = x.Clean()?.ToArray());
        }

        _ = srcs.RemoveAll(x => x.IsEmptyOrNull());
    }

    public static void Cleans<T>(this List<List<T>?>? srcs, bool? deepClean = null)
    {
        if (srcs.IsEmptyOrNull())
        {
            return;
        }

        if (deepClean.HasValue && deepClean.Value)
        {
            srcs.ForEach(x => x.Clean());
        }

        _ = srcs.RemoveAll(x => x.IsEmptyOrNull());
    }

    /// <summary>
    /// Filters out <see langword="null"/>, empty, or white-space strings from a collection of strings.
    /// If the collection is <see langword="null"/> or empty, it is returned as-is.
    /// Applicable to collections of strings, removing elements that are <see langword="null"/>, empty, or consist only of white-space characters.
    /// </summary>
    /// <param name="srcs">The collection of strings to be filtered. Can be <see langword="null"/>.</param>
    /// <returns>A filtered collection with <see langword="null"/>, empty, or white-space strings removed, or the original collection if it is <see langword="null"/> or empty.</returns>
    public static IEnumerable<string?>? Clean(this IEnumerable<string?>? srcs) => srcs.IsEmptyOrNull() ? srcs : srcs.Where(x => x.IsNotWhiteSpaceAndNull());

    /// <summary>
    /// Filters out <see langword="null"/>, empty, or white-space strings from a collection (ICollection) of strings.
    /// If the collection is <see langword="null"/> or empty, it is returned as-is.
    /// Applicable to collections of strings, removing elements that are <see langword="null"/>, empty, or consist only of white-space characters.
    /// </summary>
    /// <param name="srcs">The ICollection of strings to be filtered. Can be <see langword="null"/>.</param>
    /// <returns>A filtered collection with <see langword="null"/>, empty, or white-space strings removed, or the original collection if it is <see langword="null"/> or empty.</returns>
    public static IEnumerable<string?>? Clean(this ICollection<string?>? srcs) => srcs.IsEmptyOrNull() ? srcs : srcs.Where(x => x.IsNotWhiteSpaceAndNull());

    /// <summary>
    /// Filters out <see langword="null"/>, empty, or white-space strings from an array of strings.
    /// If the array is <see langword="null"/> or empty, it is returned as-is.
    /// Applicable to arrays of strings, removing elements that are <see langword="null"/>, empty, or consist only of white-space characters.
    /// </summary>
    /// <param name="srcs">The array of strings to be filtered. Can be <see langword="null"/>.</param>
    /// <returns>A filtered array with <see langword="null"/>, empty, or white-space strings removed, or the original array if it is <see langword="null"/> or empty.</returns>
    public static IEnumerable<string?>? Clean(params string?[]? srcs) => srcs.IsEmptyOrNull() ? srcs : srcs.Where(x => x.IsNotWhiteSpaceAndNull());

    public static IEnumerable<IEnumerable<string?>?>? Cleans(this IEnumerable<IEnumerable<string?>?>? srcs, bool? deepClean = null) => srcs.IsEmptyOrNull()
        ? srcs
        : (deepClean.HasValue && deepClean.Value ? srcs.Select(x => x.Clean()) : srcs).Where(x => x.IsNotEmptyAndNull());

    public static IEnumerable<IEnumerable<string?>?>? Cleans(this IEnumerable<ICollection<string?>?>? srcs, bool? deepClean = null) => srcs.IsEmptyOrNull()
        ? srcs
        : (deepClean.HasValue && deepClean.Value ? srcs.Select(x => x.Clean()) : srcs).Where(x => x.IsNotEmptyAndNull());

    public static IEnumerable<IEnumerable<string?>?>? Cleans(this IEnumerable<string?[]?>? srcs, bool? deepClean = null) => srcs.IsEmptyOrNull()
        ? srcs
        : (deepClean.HasValue && deepClean.Value ? srcs.Select(x => x.Clean()) : srcs).Where(x => x.IsNotEmptyAndNull());

    public static IEnumerable<IEnumerable<string?>?>? Cleans(this ICollection<IEnumerable<string?>?>? srcs, bool? deepClean = null) => srcs.IsEmptyOrNull()
        ? srcs
        : (deepClean.HasValue && deepClean.Value ? srcs.Select(x => x.Clean()) : srcs).Where(x => x.IsNotEmptyAndNull());

    public static IEnumerable<IEnumerable<string?>?>? Cleans(this ICollection<ICollection<string?>?>? srcs, bool? deepClean = null) => srcs.IsEmptyOrNull()
        ? srcs
        : (deepClean.HasValue && deepClean.Value ? srcs.Select(x => x.Clean()) : srcs).Where(x => x.IsNotEmptyAndNull());

    public static IEnumerable<IEnumerable<string?>?>? Cleans(this ICollection<string?[]?>? srcs, bool? deepClean = null) => srcs.IsEmptyOrNull()
        ? srcs
        : (deepClean.HasValue && deepClean.Value ? srcs.Select(x => x.Clean()) : srcs).Where(x => x.IsNotEmptyAndNull());

    public static IEnumerable<IEnumerable<string?>?>? Cleans(this IEnumerable<string?>?[]? srcs, bool? deepClean = null) => srcs.IsEmptyOrNull()
        ? srcs
        : (deepClean.HasValue && deepClean.Value ? srcs.Select(x => x.Clean()) : srcs).Where(x => x.IsNotEmptyAndNull());

    public static IEnumerable<IEnumerable<string?>?>? Cleans(this ICollection<string?>?[]? srcs, bool? deepClean = null) => srcs.IsEmptyOrNull()
        ? srcs
        : (deepClean.HasValue && deepClean.Value ? srcs.Select(x => x.Clean()) : srcs).Where(x => x.IsNotEmptyAndNull());

    public static IEnumerable<IEnumerable<string?>?>? Cleans(this string?[]?[]? srcs, bool? deepClean = null) => srcs.IsEmptyOrNull()
        ? srcs
        : (deepClean.HasValue && deepClean.Value ? srcs.Select(x => x.Clean()) : srcs).Where(x => x.IsNotEmptyAndNull());

    public static void Cleans(this List<IEnumerable<string?>?>? srcs, bool? deepClean = null)
    {
        if (srcs.IsEmptyOrNull())
        {
            return;
        }

        if (deepClean.HasValue && deepClean.Value)
        {
            srcs.ForEach(x => x = x.Clean());
        }

        _ = srcs.RemoveAll(x => x.IsEmptyOrNull());
    }

    public static void Cleans(this List<ICollection<string?>?>? srcs, bool? deepClean = null)
    {
        if (srcs.IsEmptyOrNull())
        {
            return;
        }

        if (deepClean.HasValue && deepClean.Value)
        {
            srcs.ForEach(x => x = (ICollection<string?>?)x.Clean());
        }

        _ = srcs.RemoveAll(x => x.IsEmptyOrNull());
    }

    public static void Cleans(this List<string?[]?>? srcs, bool? deepClean = null)
    {
        if (srcs.IsEmptyOrNull())
        {
            return;
        }

        if (deepClean.HasValue && deepClean.Value)
        {
            srcs.ForEach(x => x = x.Clean()?.ToArray());
        }

        _ = srcs.RemoveAll(x => x.IsEmptyOrNull());
    }

    public static void Cleans(this List<List<string?>?>? srcs, bool? deepClean = null)
    {
        if (srcs.IsEmptyOrNull())
        {
            return;
        }

        if (deepClean.HasValue && deepClean.Value)
        {
            srcs.ForEach(x => x.Clean());
        }

        _ = srcs.RemoveAll(x => x.IsEmptyOrNull());
    }

}
