using static System.Nullable;

namespace YANLib;

public static partial class YANList
{
    /// <summary>
    /// Splits a given <see cref="List{T}"/> into smaller chunks of a specified size.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="srcs">The source list to be chunked.</param>
    /// <param name="chunkSize">The maximum number of elements in each chunk.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="List{T}"/>s, where each inner list has a maximum size of <paramref name="chunkSize"/>.</returns>
    public static IEnumerable<List<T>> ChunkBySize<T>(this List<T> srcs, int chunkSize)
    {
        var cnt = srcs?.Count ?? 0;
        if (srcs == null || cnt < 1 || chunkSize < 1)
        {
            yield break;
        }
        for (var i = 0; i < cnt; i += chunkSize)
        {
            yield return srcs.GetRange(i, i + chunkSize > cnt ? cnt - i : chunkSize);
        }
    }

    /// <summary>
    /// Cleans a given <see cref="IList{T}"/> by removing null or whitespace elements depending on the type of T.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="srcs">The source list to be cleaned.</param>
    /// <returns>A new <see cref="IList{T}"/> that contains only non-null or non-whitespace elements.</returns>
    public static IList<T>? Clean<T>(this IList<T> srcs)
    {
        if (srcs?.Count > 0)
        {
            var t = typeof(T);
            if (t.IsClass || GetUnderlyingType(t) != null)
            {
                return srcs.ClnPrcYld().ToList();
            }
        }
        return srcs;
    }

    /// <summary>
    /// Cleans a given list string by removing null or whitespace elements, returning a new list that contains only non-null and non-whitespace elements.
    /// </summary>
    /// <param name="srcs">The source list to be cleaned.</param>
    /// <returns>A new list string that contains only non-null or non-whitespace elements, or null if the input list is null.</returns>
    public static IList<string>? Clean(this IList<string> srcs) => srcs?.Count > 0 ? srcs.ClnPrcYld().ToList() : srcs;

    // Clean process yield
    private static IEnumerable<T> ClnPrcYld<T>(this IList<T> srcs)
    {
        for (var i = 0; i < srcs?.Count; i++)
        {
            if (srcs[i] != null)
            {
                yield return srcs[i];
            }
        }
    }

    // Clean process yield
    private static IEnumerable<string> ClnPrcYld(this IList<string> srcs)
    {
        for (var i = 0; i < srcs?.Count; i++)
        {
            if (!string.IsNullOrWhiteSpace(srcs[i]))
            {
                yield return srcs[i];
            }
        }
    }
}
