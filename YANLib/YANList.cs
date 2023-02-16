using static System.Math;

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
        for (var i = 0; i < srcs?.Count; i += chunkSize)
        {
            yield return srcs.GetRange(i, Min(chunkSize, srcs.Count - i));
        }
    }
}
