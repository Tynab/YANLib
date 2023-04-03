namespace YANLib.Collection;

public static partial class YANCollection
{
    // Clean process yield
    internal static IEnumerable<T> ClnPrcYld<T>(this IEnumerable<T> srcs)
    {
        foreach (var src in srcs)
        {
            if (src != null)
            {
                yield return src;
            }
        }
    }

    // Clean process yield
    internal static IEnumerable<string> ClnPrcYld(this IEnumerable<string> srcs)
    {
        foreach (var src in srcs)
        {
            if (!string.IsNullOrWhiteSpace(src))
            {
                yield return src;
            }
        }
    }
}
