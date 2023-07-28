using static System.Math;
using static System.Nullable;
using static YANLib.YANNum;

namespace YANLib;

public static partial class YANEnumerable
{

    public static IEnumerable<List<T>> ChunkBySize<T, T1>(this List<T> srcs, T1 chunkSize) where T1 : struct
    {
        var size = chunkSize.ToInt();

        if (srcs.IsEmptyOrNull() && size < 1)
        {
            yield break;
        }

        var cnt = srcs.Count;

        for (var i = 0; i < cnt; i += size)
        {
            yield return srcs.GetRange(i, Min(size, cnt - i));
        }
    }

    public static IEnumerable<T> Clean<T>(this IEnumerable<T> srcs)
    {
        if (srcs.IsEmptyOrNull())
        {
            yield break;
        }

        var t = typeof(T);

        if (t.IsClass || GetUnderlyingType(t) is not null)
        {
            foreach (var src in srcs)
            {
                if (src is not null)
                {
                    yield return src;
                }
            }
        }
        else
        {
            foreach (var src in srcs)
            {
                yield return src;
            }
        }
    }

    public static IEnumerable<string> Clean(this IEnumerable<string> srcs)
    {
        if (srcs is null || !srcs.Any())
        {
            yield break;
        }

        foreach (var src in srcs)
        {
            if (src.IsNotWhiteSpaceAndNull())
            {
                yield return src;
            }
        }
    }

    public static bool IsEmptyOrNull<T>(this IEnumerable<T> srcs) => srcs is null || !srcs.Any();

    public static bool IsEmptyOrNull<T>(this ICollection<T> srcs) => srcs is null || srcs.Count < 1;

    public static bool IsNotEmptyAndNull<T>(this IEnumerable<T> srcs) => srcs is not null && srcs.Any();

    public static bool IsNotEmptyAndNull<T>(this ICollection<T> srcs) => srcs is not null && srcs.Count > 0;

    public static bool AllEmptyOrNull<T>(this IEnumerable<T?> srcs) where T : class => !srcs.Any(x => x is not null || x.AnyPropertiesNotDefault());

    public static bool AnyEmptyOrNull<T>(this IEnumerable<T?> srcs) where T : class => srcs.Any(x => x is null || x.AllPropertiesDefault());

    public static bool AllNotEmptyAndNull<T>(this IEnumerable<T?> srcs) where T : class => !srcs.Any(x => x is null || x.AllPropertiesDefault());

    public static bool AnyNotEmptyAndNull<T>(this IEnumerable<T?> srcs) where T : class => srcs.Any(x => x is not null || x.AnyPropertiesNotDefault());
}
