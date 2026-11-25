using System.Collections.Immutable;
using static System.Collections.Immutable.ImmutableSortedDictionary;

namespace YANLib.Implementation;

internal static partial class YANEnumerable
{
    internal static ImmutableArray<T> ToImmutableArrayImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? [] : [.. (input is ImmutableArray<object?> x ? x : [.. input]).ParsesImplement<T>()!];

    internal static ImmutableArray<T> ToImmutableArrayImplement<T>(this System.Collections.IEnumerable? input)
        => input is null ? [] : [.. (input is ImmutableArray<object?> x ? x : [.. input.Cast<object?>()]).ParsesImplement<T>() ?? Enumerable.Empty<T>()];

    internal static ImmutableList<T> ToImmutableListImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? [] : [.. (input as ImmutableList<object?> ?? input).ParsesImplement<T>()!];

    internal static ImmutableList<T> ToImmutableListImplement<T>(this System.Collections.IEnumerable? input) => input is null ? [] : [.. (input as ImmutableList<object?> ?? input).ParsesImplement<T>() ?? Enumerable.Empty<T>()];

    internal static ImmutableHashSet<T> ToImmutableHashSetImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? [] : [.. (input as ImmutableHashSet<object?> ?? input).ParsesImplement<T>()!];

    internal static ImmutableHashSet<T> ToImmutableHashSetImplement<T>(this System.Collections.IEnumerable? input) => input is null ? [] : [.. (input as ImmutableHashSet<object?> ?? input).ParsesImplement<T>() ?? Enumerable.Empty<T>()];

    internal static ImmutableDictionary<TKey, TValue?> ToImmutableDictionaryImplement<T, TKey, TValue, TK, TV>(this IEnumerable<object?>? input, Func<T, TK> keySelector, Func<T, TV> elementSelector) where TKey : unmanaged where TK : unmanaged
        => input.IsNullEmptyImplement() ? ImmutableDictionary<TKey, TValue?>.Empty : ImmutableDictionary.CreateRange(ToDictionaryCore<T, TKey, TValue, TK, TV>(input, keySelector, elementSelector, null));

    internal static ImmutableDictionary<TKey, TValue?> ToImmutableDictionaryImplement<T, TKey, TValue, TK, TV>(
        this IEnumerable<object?>? input,
        Func<T, TK> keySelector,
        Func<T, TV> elementSelector,
        Func<TValue?, TValue?, TValue?> onDuplicate
    ) where TKey : unmanaged where TK : unmanaged
    {
        ArgumentNullException.ThrowIfNull(onDuplicate);

        return input.IsNullEmptyImplement() ? ImmutableDictionary<TKey, TValue?>.Empty : ImmutableDictionary.CreateRange(ToDictionaryCore<T, TKey, TValue, TK, TV>(input, keySelector, elementSelector, onDuplicate));
    }

    internal static ImmutableStack<T> ToImmutableStackImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? [] : [.. (input as ImmutableStack<object?> ?? input).ParsesImplement<T>()!];

    internal static ImmutableStack<T> ToImmutableStackImplement<T>(this System.Collections.IEnumerable? input) => input is null ? [] : [.. (input as ImmutableStack<object?> ?? input).ParsesImplement<T>() ?? Enumerable.Empty<T>()];

    internal static ImmutableQueue<T> ToImmutableQueueImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? [] : [.. (input as ImmutableQueue<object?> ?? input).ParsesImplement<T>()!];

    internal static ImmutableQueue<T> ToImmutableQueueImplement<T>(this System.Collections.IEnumerable? input) => input is null ? [] : [.. (input as ImmutableQueue<object?> ?? input).ParsesImplement<T>() ?? Enumerable.Empty<T>()];

    internal static ImmutableSortedSet<T> ToImmutableSortedSetImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? [] : [.. (input as ImmutableSortedSet<object?> ?? input).ParsesImplement<T>()!];

    internal static ImmutableSortedSet<T> ToImmutableSortedSetImplement<T>(this System.Collections.IEnumerable? input) => input is null ? [] : [.. (input as ImmutableSortedSet<object?> ?? input).ParsesImplement<T>() ?? Enumerable.Empty<T>()];

    internal static ImmutableSortedDictionary<TKey, TValue?> ToImmutableSortedDictionaryImplement<T, TKey, TValue, TK, TV>(this IEnumerable<object?>? input, Func<T, TK> keySelector, Func<T, TV> elementSelector) where TKey : unmanaged where TK : unmanaged
        => input.IsNullEmptyImplement() ? ImmutableSortedDictionary<TKey, TValue?>.Empty : CreateRange(ToDictionaryCore<T, TKey, TValue, TK, TV>(input, keySelector, elementSelector, null));

    internal static ImmutableSortedDictionary<TKey, TValue?> ToImmutableSortedDictionaryImplement<T, TKey, TValue, TK, TV>(
        this IEnumerable<object?>? input,
        Func<T, TK> keySelector,
        Func<T, TV> elementSelector,
        Func<TValue?, TValue?, TValue?> onDuplicate
    ) where TKey : unmanaged where TK : unmanaged
    {
        ArgumentNullException.ThrowIfNull(onDuplicate);

        return input.IsNullEmptyImplement() ? ImmutableSortedDictionary<TKey, TValue?>.Empty : CreateRange(ToDictionaryCore<T, TKey, TValue, TK, TV>(input, keySelector, elementSelector, onDuplicate));
    }
}
