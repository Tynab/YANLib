using System.Collections.Immutable;
using System.Diagnostics;
using static System.Collections.Immutable.ImmutableSortedDictionary;

namespace YANLib.Implementation;

internal static partial class YANEnumerable
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static ImmutableArray<T> ToImmutableArrayImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? [] : [.. (input is ImmutableArray<object?> x ? x : [.. input]).ParsesImplement<T>()!];

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static ImmutableArray<T> ToImmutableArrayImplement<T>(this System.Collections.IEnumerable? input)
        => input is null ? [] : [.. (input is ImmutableArray<object?> x ? x : [.. input.Cast<object?>()]).ParsesImplement<T>()!];

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static ImmutableList<T> ToImmutableListImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? [] : [.. (input as ImmutableList<object?> ?? input).ParsesImplement<T>()!];

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static ImmutableList<T> ToImmutableListImplement<T>(this System.Collections.IEnumerable? input) => input is null ? [] : [.. (input as ImmutableList<object?> ?? input).ParsesImplement<T>()!];

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static ImmutableHashSet<T> ToImmutableHashSetImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? [] : [.. (input as ImmutableHashSet<object?> ?? input).ParsesImplement<T>()!];

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static ImmutableHashSet<T> ToImmutableHashSetImplement<T>(this System.Collections.IEnumerable? input) => input is null ? [] : [.. (input as ImmutableHashSet<object?> ?? input).ParsesImplement<T>()!];

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static ImmutableDictionary<TKey, TValue?> ToImmutableDictionaryImplement<T, TKey, TValue, TK, TV>(this IEnumerable<object?>? input, Func<T, TK> keySelector, Func<T, TV> elementSelector) where TKey : unmanaged where TK : unmanaged
    {
        if (input.IsNullEmptyImplement())
        {
            return ImmutableDictionary<TKey, TValue?>.Empty;
        }

        var dict = new Dictionary<TKey, TValue?>();

        foreach (var obj in input)
        {
            if (obj is T item)
            {
                dict.Add(keySelector(item).ParseImplement<TKey>(), elementSelector(item).ParseImplement<TValue?>());
            }
        }

        return ImmutableDictionary.CreateRange(dict);
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static ImmutableStack<T> ToImmutableStackImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? [] : [.. (input as ImmutableStack<object?> ?? input).ParsesImplement<T>()!];

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static ImmutableStack<T> ToImmutableStackImplement<T>(this System.Collections.IEnumerable? input) => input is null ? [] : [.. (input as ImmutableStack<object?> ?? input).ParsesImplement<T>()!];

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static ImmutableQueue<T> ToImmutableQueueImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? [] : [.. (input as ImmutableQueue<object?> ?? input).ParsesImplement<T>()!];

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static ImmutableQueue<T> ToImmutableQueueImplement<T>(this System.Collections.IEnumerable? input) => input is null ? [] : [.. (input as ImmutableQueue<object?> ?? input).ParsesImplement<T>()!];

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static ImmutableSortedSet<T> ToImmutableSortedSetImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? [] : [.. (input as ImmutableSortedSet<object?> ?? input).ParsesImplement<T>()!];

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static ImmutableSortedSet<T> ToImmutableSortedSetImplement<T>(this System.Collections.IEnumerable? input) => input is null ? [] : [.. (input as ImmutableSortedSet<object?> ?? input).ParsesImplement<T>()!];

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static ImmutableSortedDictionary<TKey, TValue?> ToImmutableSortedDictionaryImplement<T, TKey, TValue, TK, TV>(this IEnumerable<object?>? input, Func<T, TK> keySelector, Func<T, TV> elementSelector) where TKey : unmanaged where TK : unmanaged
    {
        if (input.IsNullEmptyImplement())
        {
            return ImmutableSortedDictionary<TKey, TValue?>.Empty;
        }

        var dict = new Dictionary<TKey, TValue?>();

        foreach (var obj in input)
        {
            if (obj is T item)
            {
                dict.Add(keySelector(item).ParseImplement<TKey>(), elementSelector(item).ParseImplement<TValue?>());
            }
        }

        return CreateRange(dict);
    }
}
