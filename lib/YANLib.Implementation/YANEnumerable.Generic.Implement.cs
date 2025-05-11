using System.Diagnostics;
using static System.Linq.Enumerable;

namespace YANLib.Implementation;

internal static partial class YANEnumerable
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T[] ToArrayImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? [] : [.. (input is Array x ? x : input.ToArray()).ParsesImplement<T>()!];

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T[] ToArrayImplement<T>(this System.Collections.IEnumerable? input) => input.IsNullImplement() ? [] : [.. (input is Array x ? x : input.Cast<object?>().ToArray()).ParsesImplement<T>()!];

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static List<T> ToListImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? [] : [.. (input as List<object?> ?? [.. input]).ParsesImplement<T>()!];

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static List<T> ToListImplement<T>(this System.Collections.IEnumerable? input) => input.IsNullImplement() ? [] : [.. (input as List<object?> ?? [.. input.Cast<object?>()]).ParsesImplement<T>()!];

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static HashSet<T> ToHashSetImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? [] : [.. (input as HashSet<object?> ?? [.. input]).ParsesImplement<T>()!];

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static HashSet<T> ToHashSetImplement<T>(this System.Collections.IEnumerable? input) => input.IsNullImplement() ? [] : [.. (input as HashSet<object?> ?? [.. input.Cast<object?>()]).ParsesImplement<T>()!];

    [DebuggerHidden]
    [DebuggerStepThrough]
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

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static ILookup<TKey?, TElement?> ToLookupImplement<T, TKey, TElement, TK, TE>(this IEnumerable<object?>? input, Func<T, TK> keySelector, Func<T, TE> elementSelector) => input.IsNullEmptyImplement()
        ? Empty<(TKey? Key, TElement? Element)>().ToLookup(p => p.Key, p => p.Element)
        : input.OfType<T>().ToLookup(x => keySelector(x).ParseImplement<TKey?>(), x => elementSelector(x).ParseImplement<TElement?>());
}
