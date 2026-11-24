using static System.Linq.Enumerable;

namespace YANLib.Implementation;

internal static partial class YANUnmanaged
{
    internal static IEnumerable<T?>? ParsesImplement<T>(this IEnumerable<object?>? input)
        => input.IsNullEmptyImplement() ? default : input.Select(static x => x.ParseImplement<T?>());

    internal static IEnumerable<T?>? ParsesImplement<T>(this System.Collections.IEnumerable? input) => input is null ? default : input.Cast<object?>().ParsesImplement<T>();

    internal static IEnumerable<T?>? ParsesWithImplement<T>(this IEnumerable<object?>? input, IFormatProvider? provider)
        => input.IsNullEmptyImplement() ? default : input.Select(x => x.ParseWithImplement<T?>(provider));

    internal static IEnumerable<T?>? ParsesWithImplement<T>(this System.Collections.IEnumerable? input, IFormatProvider? provider) => input is null ? default : input.Cast<object?>().ParsesWithImplement<T>(provider);

    internal static ILookup<TKey?, TElement?> ParsesImplement<TKey, TElement>(this ILookup<object?, object?>? input) => input.IsNullEmptyImplement()
        ? Empty<(TKey? Key, TElement? Element)>().ToLookup(p => p.Key, p => p.Element)
        : input.SelectMany(g => g, (g, x) => new
        {
            g.Key,
            Element = x
        }).ToList().ToLookup(x => x.Key is TKey k ? k : x.Key.ParseImplement<TKey?>(), x => x.Element is TElement e ? e : x.Element.ParseImplement<TElement?>());
}
