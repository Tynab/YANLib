﻿using static System.Math;
using static System.Nullable;
using static YANLib.YANNum;

namespace YANLib;

public static partial class YANEnumerable
{
    
    public static IEnumerable<List<T>> ChunkBySize<T, T1>(this List<T> srcs, T1 chunkSize) where T1 : struct
    {
        var size = chunkSize.ToInt();
        if (srcs is null || srcs.Count < 1 && size < 1)
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
        if (srcs is null || !srcs.Any())
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

    public static void Clean<T>(this ICollection<T> srcs)
    {
        if (srcs is not null && srcs.Any())
        {
            var t = typeof(T);
            if (t.IsClass || GetUnderlyingType(t) is not null)
            {
                foreach (var src in srcs)
                {
                    if (src is null)
                    {
                        _ = srcs.Remove(src);
                    }
                }
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
            if (src.IsNotNullAndWhiteSpace())
            {
                yield return src;
            }
        }
    }

    public static void Clean(this ICollection<string> srcs)
    {
        if (srcs is not null && srcs.Any())
        {
            foreach (var src in srcs)
            {
                if (src.IsNullOrWhiteSpace())
                {
                    _ = srcs.Remove(src);
                }
            }
        }
    }
}
