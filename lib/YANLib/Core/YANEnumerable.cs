﻿using static System.Math;
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
    public static IEnumerable<List<T?>> ChunkBySize<T>(this IEnumerable<T?>? srcs, object? chunkSize)
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
    public static IEnumerable<List<T?>> ChunkBySize<T>(this ICollection<T?>? srcs, object? chunkSize)
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
    public static IEnumerable<List<T?>> ChunkBySize<T>(this T?[]? srcs, object? chunkSize)
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
    public static IEnumerable<List<T?>> ChunkBySize<T>(this List<T?>? srcs, object? chunkSize)
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

    public static IEnumerable<T?>? Clean<T>(this IEnumerable<T?>? srcs)
    {
        if (srcs.IsEmptyOrNull())
        {
            return srcs;
        }

        var t = typeof(T);

        return t.IsClass || GetUnderlyingType(t).IsNotNull() ? srcs.Where(x => x.IsNotNull()) : srcs;
    }

    public static IEnumerable<T?>? Clean<T>(this ICollection<T?>? srcs)
    {
        if (srcs.IsEmptyOrNull())
        {
            return srcs;
        }

        var t = typeof(T);

        return t.IsClass || GetUnderlyingType(t).IsNotNull() ? srcs.Where(x => x.IsNotNull()) : srcs;
    }

    public static IEnumerable<T?>? Clean<T>(params T?[]? srcs)
    {
        if (srcs.IsEmptyOrNull())
        {
            return srcs;
        }

        var t = typeof(T);

        return t.IsClass || GetUnderlyingType(t).IsNotNull() ? srcs.Where(x => x.IsNotNull()) : srcs;
    }

    public static IEnumerable<string?>? Clean(this IEnumerable<string?>? srcs) => srcs.IsEmptyOrNull() ? srcs : srcs.Where(x => x.IsNotWhiteSpaceAndNull());

    public static IEnumerable<string?>? Clean(this ICollection<string?>? srcs) => srcs.IsEmptyOrNull() ? srcs : srcs.Where(x => x.IsNotWhiteSpaceAndNull());

    public static IEnumerable<string?>? Clean(params string?[]? srcs) => srcs.IsEmptyOrNull() ? srcs : srcs.Where(x => x.IsNotWhiteSpaceAndNull());
}
