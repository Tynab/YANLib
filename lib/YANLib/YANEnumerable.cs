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
    /// Returns a new <see cref="IEnumerable{T}"/> containing only the non-null values from the given array <paramref name="srcs"/>.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="srcs">The array to be cleaned.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing only the non-null values from <paramref name="srcs"/>.</returns>
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
    /// Returns a new <see cref="IEnumerable{T}"/> containing only the non-null values from the given <paramref name="srcs"/> <see cref="IEnumerable{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of elements in the <paramref name="srcs"/> <see cref="IEnumerable{T}"/>.</typeparam>
    /// <param name="srcs">The <see cref="IEnumerable{T}"/> to be cleaned.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing only the non-null values from <paramref name="srcs"/>.</returns>
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
    /// Returns a new <see cref="IEnumerable{T}"/> containing only the non-null values from the given <paramref name="srcs"/> <see cref="ICollection{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of elements in the <paramref name="srcs"/> <see cref="ICollection{T}"/>.</typeparam>
    /// <param name="srcs">The <see cref="ICollection{T}"/> to be cleaned.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing only the non-null values from <paramref name="srcs"/>.</returns>
    public static IEnumerable<T> Clean<T>(this ICollection<T> srcs)
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
    /// Returns a new <see cref="IEnumerable{T}"/> containing only the non-null values from the given <paramref name="srcs"/> <see cref="IList{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of elements in the <paramref name="srcs"/> <see cref="IList{T}"/>.</typeparam>
    /// <param name="srcs">The <see cref="IList{T}"/> to be cleaned.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing only the non-null values from <paramref name="srcs"/>.</returns>
    public static IEnumerable<T> Clean<T>(this IList<T> srcs)
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
    /// Returns a new <see cref="IEnumerable{T}"/> containing only the non-null values from the given <paramref name="srcs"/> <see cref="ISet{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of elements in the <paramref name="srcs"/> <see cref="ISet{T}"/>.</typeparam>
    /// <param name="srcs">The <see cref="ISet{T}"/> to be cleaned.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing only the non-null values from <paramref name="srcs"/>.</returns>
    public static IEnumerable<T> Clean<T>(this ISet<T> srcs)
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
    /// Returns a new <see cref="IEnumerable{T}"/> containing only the non-empty values from the given <paramref name="srcs"/> array of strings.
    /// </summary>
    /// <param name="srcs">The array of strings to be cleaned.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing only the non-empty values from <paramref name="srcs"/>.</returns>
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
    /// Returns a new <see cref="IEnumerable{T}"/> containing only the non-empty values from the given <paramref name="srcs"/> <see cref="IEnumerable{T}"/> of strings.
    /// </summary>
    /// <param name="srcs">The <see cref="IEnumerable{T}"/> of strings to be cleaned.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing only the non-empty values from <paramref name="srcs"/>.</returns>
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
    /// Returns a new <see cref="IEnumerable{T}"/> containing only the non-empty values from the given <paramref name="srcs"/> <see cref="ICollection{T}"/> of strings.
    /// </summary>
    /// <param name="srcs">The <see cref="ICollection{T}"/> of strings to be cleaned.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing only the non-empty values from <paramref name="srcs"/>.</returns>
    public static IEnumerable<string> Clean(this ICollection<string> srcs)
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
    /// Returns a new <see cref="IEnumerable{T}"/> containing only the non-empty values from the given <paramref name="srcs"/> <see cref="IList{T}"/> of strings.
    /// </summary>
    /// <param name="srcs">The <see cref="IList{T}"/> of strings to be cleaned.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing only the non-empty values from <paramref name="srcs"/>.</returns>
    public static IEnumerable<string> Clean(this IList<string> srcs)
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
    /// Returns a new <see cref="IEnumerable{T}"/> containing only the non-empty values from the given <paramref name="srcs"/> <see cref="ISet{T}"/> of strings.
    /// </summary>
    /// <param name="srcs">The <see cref="ISet{T}"/> of strings to be cleaned.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing only the non-empty values from <paramref name="srcs"/>.</returns>
    public static IEnumerable<string> Clean(this ISet<string> srcs)
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
