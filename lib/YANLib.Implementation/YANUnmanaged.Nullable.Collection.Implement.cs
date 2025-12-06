using System.Diagnostics;
using static System.Linq.Enumerable;

namespace YANLib.Implementation;

internal static partial class YANUnmanaged
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? ParsesImplement<T>(this IEnumerable<object?>? input)
        => input.IsNullEmptyImplement() ? default : input.GetCountImplement() < 1_000 ? input.Select(static x => x.ParseImplement<T?>()) : input.AsParallel().Select(static x => x.ParseImplement<T?>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? ParsesImplement<T>(this System.Collections.IEnumerable? input) => input is null ? default : input.Cast<object?>().ParsesImplement<T>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static ILookup<TKey?, TElement?> ParsesImplement<TKey, TElement>(this ILookup<object?, object?>? input) => input.IsNullEmptyImplement()
        ? Empty<(TKey? Key, TElement? Element)>().ToLookup(p => p.Key, p => p.Element)
        : input.SelectMany(g => g, (g, x) => new
        {
            g.Key,
            Element = x
        }).ToList().ToLookup(x => x.Key is TKey k ? k : x.Key.ParseImplement<TKey?>(), x => x.Element is TElement e ? e : x.Element.ParseImplement<TElement?>());
}
