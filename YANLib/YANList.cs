using static System.Math;

namespace YANLib;

public static partial class YANList
{
    /// <summary>
    /// Chunks a list into smaller lists of a specified size.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="source">The source list to chunk.</param>
    /// <param name="chunkSize">The size of each chunk.</param>
    /// <returns>An enumerable of chunked lists.</returns>
    public static IEnumerable<List<T>> ChunkBySize<T>(this List<T> source, int chunkSize)
    {
        for (var i = 0; i < source?.Count; i += chunkSize)
        {
            yield return source.GetRange(i, Min(chunkSize, source.Count - i));
        }
    }
}
