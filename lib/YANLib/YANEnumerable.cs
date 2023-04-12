using static System.Math;
using static System.Nullable;
using static YANLib.YANNum;

namespace YANLib;

public static partial class YANEnumerable
{
    /// <summary>
    /// Splits a given <see cref="List{T}"/> into smaller chunks of a specified size.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <typeparam name="T1">The type of the chunk size, which must be a value type.</typeparam>
    /// <param name="srcs">The source list to be chunked.</param>
    /// <param name="chunkSize">The maximum number of elements in each chunk.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="List{T}"/>s, where each inner list has a maximum size of <paramref name="chunkSize"/>.</returns>
    public static IEnumerable<List<T>> ChunkBySize<T, T1>(this List<T> srcs, T1 chunkSize) where T1 : struct
    {
        var size = chunkSize.ToInt();
        if (srcs is null || srcs.Count <= 0 && size <= 0)
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
    /// Removes <see langword="null"/> values from the specified objects and returns an <see cref="IEnumerable{T}"/> containing the non-null values.
    /// If the type <typeparamref name="T"/> is a class or a nullable value type, the method checks for <see langword="null"/> values and excludes them.
    /// If <typeparamref name="T"/> is a non-nullable value type, the method returns all objects in the input enumerable without modification.
    /// </summary>
    /// <typeparam name="T">The type of the objects to clean.</typeparam>
    /// <param name="srcs">The objects to clean.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing the non-null values.</returns>
    public static IEnumerable<T> Clean<T>(params T[] srcs)
    {
        if (srcs is null || srcs.Length <= 0)
        {
            yield break;
        }
        var t = typeof(T);
        var cnt = srcs.Length;
        if (t.IsClass || GetUnderlyingType(t) != null)
        {
            for (var i = 0; i < cnt; i++)
            {
                var item = srcs[i];
                if (item != null)
                {
                    yield return item;
                }
            }
        }
        else
        {
            for (var i = 0; i < cnt; i++)
            {
                yield return srcs[i];
            }
        }
    }

    /// <summary>
    /// Removes <see langword="null"/> values from the specified objects and returns an <see cref="IEnumerable{T}"/> containing the non-null values.
    /// If the type <typeparamref name="T"/> is a class or a nullable value type, the method checks for <see langword="null"/> values and excludes them.
    /// If <typeparamref name="T"/> is a non-nullable value type, the method returns all objects in the input enumerable without modification.
    /// </summary>
    /// <typeparam name="T">The type of the objects to clean.</typeparam>
    /// <param name="srcs">The objects to clean.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing the non-null values.</returns>
    public static IEnumerable<T> Clean<T>(this IEnumerable<T> srcs)
    {
        if (srcs is null || !srcs.Any())
        {
            yield break;
        }
        var t = typeof(T);
        if (t.IsClass || GetUnderlyingType(t) != null)
        {
            foreach (var item in srcs)
            {
                if (item != null)
                {
                    yield return item;
                }
            }
        }
        else
        {
            foreach (var item in srcs)
            {
                yield return item;
            }
        }
    }

    /// <summary>
    /// Removes <see langword="null"/> values from the specified objects and returns an <see cref="IEnumerable{T}"/> containing the non-null values.
    /// If the type <typeparamref name="T"/> is a class or a nullable value type, the method checks for <see langword="null"/> values and excludes them.
    /// If <typeparamref name="T"/> is a non-nullable value type, the method returns all objects in the input enumerable without modification.
    /// </summary>
    /// <typeparam name="T">The type of the objects to clean.</typeparam>
    /// <param name="srcs">The objects to clean.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing the non-null values.</returns>
    public static IEnumerable<T> Clean<T>(this IReadOnlyCollection<T> srcs)
    {
        if (srcs is null || srcs.Count <= 0)
        {
            yield break;
        }
        var t = typeof(T);
        if (t.IsClass || GetUnderlyingType(t) != null)
        {
            foreach (var item in srcs)
            {
                if (item != null)
                {
                    yield return item;
                }
            }
        }
        else
        {
            foreach (var item in srcs)
            {
                yield return item;
            }
        }
    }

    /// <summary>
    /// Removes <see langword="null"/> values from the specified objects and returns an <see cref="IEnumerable{T}"/> containing the non-null values.
    /// If the type <typeparamref name="T"/> is a class or a nullable value type, the method checks for <see langword="null"/> values and excludes them.
    /// If <typeparamref name="T"/> is a non-nullable value type, the method returns all objects in the input enumerable without modification.
    /// </summary>
    /// <typeparam name="T">The type of the objects to clean.</typeparam>
    /// <param name="srcs">The objects to clean.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing the non-null values.</returns>
    public static IEnumerable<T> Clean<T>(this IReadOnlyList<T> srcs)
    {
        if (srcs is null || srcs.Count <= 0)
        {
            yield break;
        }
        var t = typeof(T);
        var cnt = srcs.Count;
        if (t.IsClass || GetUnderlyingType(t) != null)
        {
            for (var i = 0; i < cnt; i++)
            {
                var item = srcs[i];
                if (item != null)
                {
                    yield return item;
                }
            }
        }
        else
        {
            for (var i = 0; i < cnt; i++)
            {
                yield return srcs[i];
            }
        }
    }

    /// <summary>
    /// Removes <see langword="null"/> values from the specified objects and returns an <see cref="IEnumerable{T}"/> containing the non-null values.
    /// If the type <typeparamref name="T"/> is a class or a nullable value type, the method checks for <see langword="null"/> values and excludes them.
    /// If <typeparamref name="T"/> is a non-nullable value type, the method returns all objects in the input enumerable without modification.
    /// </summary>
    /// <typeparam name="T">The type of the objects to clean.</typeparam>
    /// <param name="srcs">The objects to clean.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing the non-null values.</returns>
    public static IEnumerable<T> Clean<T>(this IReadOnlySet<T> srcs)
    {
        if (srcs is null || srcs.Count <= 0)
        {
            yield break;
        }
        var t = typeof(T);
        if (t.IsClass || GetUnderlyingType(t) != null)
        {
            foreach (var item in srcs)
            {
                if (item != null)
                {
                    yield return item;
                }
            }
        }
        else
        {
            foreach (var item in srcs)
            {
                yield return item;
            }
        }
    }

    /// <summary>
    /// Removes <see langword="null"/> values and empty strings from the specified enumerable of strings, and returns an <see cref="IEnumerable{string}"/> containing the non-null and non-empty strings.
    /// </summary>
    /// <param name="srcs">The enumerable of strings to clean.</param>
    /// <returns>An <see cref="IEnumerable{string}"/> containing the non-null and non-empty strings.</returns>
    public static IEnumerable<string> Clean(params string[] srcs)
    {
        if (srcs is null || srcs.Length <= 0)
        {
            yield break;
        }
        var cnt = srcs.Length;
        for (var i = 0; i < cnt; i++)
        {
            var item = srcs[i];
            if (item.HasCharater())
            {
                yield return item;
            }
        }
    }

    /// <summary>
    /// Removes <see langword="null"/> values and empty strings from the specified enumerable of strings, and returns an <see cref="IEnumerable{string}"/> containing the non-null and non-empty strings.
    /// </summary>
    /// <param name="srcs">The enumerable of strings to clean.</param>
    /// <returns>An <see cref="IEnumerable{string}"/> containing the non-null and non-empty strings.</returns>
    public static IEnumerable<string> Clean(this IEnumerable<string> srcs)
    {
        if (srcs is null || !srcs.Any())
        {
            yield break;
        }
        foreach (var item in srcs)
        {
            if (item.HasCharater())
            {
                yield return item;
            }
        }
    }

    /// <summary>
    /// Removes <see langword="null"/> values and empty strings from the specified enumerable of strings, and returns an <see cref="IEnumerable{string}"/> containing the non-null and non-empty strings.
    /// </summary>
    /// <param name="srcs">The enumerable of strings to clean.</param>
    /// <returns>An <see cref="IEnumerable{string}"/> containing the non-null and non-empty strings.</returns>
    public static IEnumerable<string> Clean(this IReadOnlyCollection<string> srcs)
    {
        if (srcs is null || srcs.Count <= 0)
        {
            yield break;
        }
        foreach (var item in srcs)
        {
            if (item.HasCharater())
            {
                yield return item;
            }
        }
    }

    /// <summary>
    /// Removes <see langword="null"/> values and empty strings from the specified enumerable of strings, and returns an <see cref="IEnumerable{string}"/> containing the non-null and non-empty strings.
    /// </summary>
    /// <param name="srcs">The enumerable of strings to clean.</param>
    /// <returns>An <see cref="IEnumerable{string}"/> containing the non-null and non-empty strings.</returns>
    public static IEnumerable<string> Clean(this IReadOnlyList<string> srcs)
    {
        if (srcs is null || srcs.Count <= 0)
        {
            yield break;
        }
        var cnt = srcs.Count;
        for (var i = 0; i < cnt; i++)
        {
            var item = srcs[i];
            if (item.HasCharater())
            {
                yield return item;
            }
        }
    }

    /// <summary>
    /// Removes <see langword="null"/> values and empty strings from the specified enumerable of strings, and returns an <see cref="IEnumerable{string}"/> containing the non-null and non-empty strings.
    /// </summary>
    /// <param name="srcs">The enumerable of strings to clean.</param>
    /// <returns>An <see cref="IEnumerable{string}"/> containing the non-null and non-empty strings.</returns>
    public static IEnumerable<string> Clean(this IReadOnlySet<string> srcs)
    {
        if (srcs is null || srcs.Count <= 0)
        {
            yield break;
        }
        foreach (var item in srcs)
        {
            if (item.HasCharater())
            {
                yield return item;
            }
        }
    }
}
