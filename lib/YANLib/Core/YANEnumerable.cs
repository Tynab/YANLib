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

    /// <summary>
    /// Filters out null values from a collection of nullable types or classes.
    /// If the collection is <see langword="null"/> or empty, it is returned as-is.
    /// Applicable to collections of reference types and nullable value types, removing elements that are <see langword="null"/>.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection. Can be a class or a nullable value type.</typeparam>
    /// <param name="srcs">The collection of elements to be filtered. Can be <see langword="null"/>.</param>
    /// <returns>A filtered collection with null elements removed, or the original collection if it is <see langword="null"/> or empty.</returns>
    public static IEnumerable<T>? Clean<T>(this IEnumerable<T>? srcs)
    {
        if (srcs.IsEmptyOrNull())
        {
            return srcs;
        }

        var t = typeof(T);

        return t.IsClass || GetUnderlyingType(t).IsNotNull() ? srcs.Where(x => x.IsNotNull()) : srcs;
    }

    /// <summary>
    /// Filters out null values from a collection (ICollection) of nullable types or classes.
    /// If the collection is <see langword="null"/> or empty, it is returned as-is.
    /// Applicable to collections of reference types and nullable value types, removing elements that are <see langword="null"/>.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection. Can be a class or a nullable value type.</typeparam>
    /// <param name="srcs">The ICollection of elements to be filtered. Can be <see langword="null"/>.</param>
    /// <returns>A filtered collection with null elements removed, or the original collection if it is <see langword="null"/> or empty.</returns>
    public static IEnumerable<T>? Clean<T>(this ICollection<T>? srcs)
    {
        if (srcs.IsEmptyOrNull())
        {
            return srcs;
        }

        var t = typeof(T);

        return t.IsClass || GetUnderlyingType(t).IsNotNull() ? srcs.Where(x => x.IsNotNull()) : srcs;
    }

    /// <summary>
    /// Filters out null values from an array of nullable types or classes.
    /// If the array is <see langword="null"/> or empty, it is returned as-is.
    /// Applicable to arrays of reference types and nullable value types, removing elements that are <see langword="null"/>.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array. Can be a class or a nullable value type.</typeparam>
    /// <param name="srcs">The array of elements to be filtered. Can be <see langword="null"/>.</param>
    /// <returns>A filtered array with null elements removed, or the original array if it is <see langword="null"/> or empty.</returns>
    public static IEnumerable<T>? Clean<T>(params T[]? srcs)
    {
        if (srcs.IsEmptyOrNull())
        {
            return srcs;
        }

        var t = typeof(T);

        return t.IsClass || GetUnderlyingType(t).IsNotNull() ? srcs.Where(x => x.IsNotNull()) : srcs;
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
}
