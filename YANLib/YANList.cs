using static System.Math;

namespace YANLib;

public static partial class YANList
{
    /// <summary>
    /// Check if list has item.
    /// </summary>
    /// <typeparam name="T">Object type.</typeparam>
    /// <param name="list">Input list.</param>
    /// <returns>List has item or not.</returns>
    public static bool HasItem<T>(this List<T> list) => list != null && list.Count > 0;

    /// <summary>
    /// Split list by size.
    /// </summary>
    /// <typeparam name="T">Object type.</typeparam>
    /// <param name="list">Input list.</param>
    /// <param name="size">Number of item to split.</param>
    /// <returns>Split list.</returns>
    public static IEnumerable<List<T>> SplitListBySize<T>(this List<T> list, int size)
    {
        for (var i = 0; i < list.Count; i += size)
        {
            yield return list.GetRange(i, Min(size, list.Count - i));
        }
    }
}
