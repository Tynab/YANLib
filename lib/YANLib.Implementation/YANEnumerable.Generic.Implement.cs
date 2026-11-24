using static System.Linq.Enumerable;

namespace YANLib.Implementation;

internal static partial class YANEnumerable
{
    internal static T?[] ToArrayImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? [] : [.. (input is Array x ? x : input.ToArray()).ParsesImplement<T?>() ?? Enumerable.Empty<T?>()];

    internal static T?[] ToArrayImplement<T>(this System.Collections.IEnumerable? input) => input is null ? [] : [.. (input is Array x ? x : input.Cast<object?>().ToArray()).ParsesImplement<T?>() ?? Enumerable.Empty<T?>()];

    internal static List<T?> ToListImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? [] : [.. (input as List<object?> ?? [.. input]).ParsesImplement<T?>() ?? Enumerable.Empty<T?>()];

    internal static List<T?> ToListImplement<T>(this System.Collections.IEnumerable? input) => input is null ? [] : [.. (input as List<object?> ?? [.. input.Cast<object?>()]).ParsesImplement<T?>() ?? Enumerable.Empty<T?>()];

    internal static HashSet<T?> ToHashSetImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? [] : [.. (input as HashSet<object?> ?? [.. input]).ParsesImplement<T?>() ?? Enumerable.Empty<T?>()];

    internal static HashSet<T?> ToHashSetImplement<T>(this System.Collections.IEnumerable? input) => input is null ? [] : [.. (input as HashSet<object?> ?? [.. input.Cast<object?>()]).ParsesImplement<T?>() ?? Enumerable.Empty<T?>()];

    internal static Dictionary<TKey, TValue?> ToDictionaryImplement<T, TKey, TValue, TK, TV>(this IEnumerable<object?>? input, Func<T, TK> keySelector, Func<T, TV> elementSelector) where TKey : unmanaged where TK : unmanaged
    {
        if (input.IsNullEmptyImplement())
        {
            return [];
        }

        var dict = new Dictionary<TKey, TValue?>();

        foreach (var obj in input)
        {
            if (obj is T item)
            {
                dict.Add(keySelector(item).ParseImplement<TKey>(), elementSelector(item).ParseImplement<TValue?>());
            }
        }

        return dict;
    }

    internal static ILookup<TKey?, TElement?> ToLookupImplement<T, TKey, TElement, TK, TE>(this IEnumerable<object?>? input, Func<T, TK> keySelector, Func<T, TE> elementSelector) => input.IsNullEmptyImplement()
        ? Empty<(TKey? Key, TElement? Element)>().ToLookup(p => p.Key, p => p.Element)
        : input.OfType<T>().ToLookup(x => keySelector(x).ParseImplement<TKey?>(), x => elementSelector(x).ParseImplement<TElement?>());
}
