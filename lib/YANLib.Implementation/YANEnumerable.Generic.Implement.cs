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

    /// <summary>
    /// Adds <paramref name="key"/> and <paramref name="value"/>; for a key that is already there, <see cref="Dictionary{TKey, TValue}.Add"/>
    /// throws <see cref="ArgumentException"/> when <paramref name="onDuplicate"/> is <c>null</c>, otherwise the key gets
    /// <paramref name="onDuplicate"/>(stored value, <paramref name="value"/>). An exception from <paramref name="onDuplicate"/> propagates.
    /// </summary>
    internal static void AddOrResolve<TKey, TValue>(Dictionary<TKey, TValue> dictionary, TKey key, TValue value, Func<TValue, TValue, TValue>? onDuplicate) where TKey : notnull
    {
        if (onDuplicate is null)
        {
            dictionary.Add(key, value);
        }
        else if (!dictionary.TryAdd(key, value))
        {
            dictionary[key] = onDuplicate(dictionary[key], value);
        }
    }

    /// <summary>The dictionary of the <typeparamref name="T"/> elements of a non-empty <paramref name="input"/>, in input order (see <see cref="AddOrResolve"/>).</summary>
    private static Dictionary<TKey, TValue?> ToDictionaryCore<T, TKey, TValue, TK, TV>(IEnumerable<object?> input, Func<T, TK> keySelector, Func<T, TV> elementSelector, Func<TValue?, TValue?, TValue?>? onDuplicate)
        where TKey : unmanaged where TK : unmanaged
    {
        var dict = new Dictionary<TKey, TValue?>();

        foreach (var obj in input)
        {
            if (obj is T item)
            {
                AddOrResolve(dict, keySelector(item).ParseImplement<TKey>(), elementSelector(item).ParseImplement<TValue?>(), onDuplicate);
            }
        }

        return dict;
    }

    internal static Dictionary<TKey, TValue?> ToDictionaryImplement<T, TKey, TValue, TK, TV>(this IEnumerable<object?>? input, Func<T, TK> keySelector, Func<T, TV> elementSelector) where TKey : unmanaged where TK : unmanaged
        => input.IsNullEmptyImplement() ? [] : ToDictionaryCore<T, TKey, TValue, TK, TV>(input, keySelector, elementSelector, null);

    internal static Dictionary<TKey, TValue?> ToDictionaryImplement<T, TKey, TValue, TK, TV>(this IEnumerable<object?>? input, Func<T, TK> keySelector, Func<T, TV> elementSelector, Func<TValue?, TValue?, TValue?> onDuplicate)
        where TKey : unmanaged where TK : unmanaged
    {
        ArgumentNullException.ThrowIfNull(onDuplicate);

        return input.IsNullEmptyImplement() ? [] : ToDictionaryCore<T, TKey, TValue, TK, TV>(input, keySelector, elementSelector, onDuplicate);
    }

    internal static ILookup<TKey?, TElement?> ToLookupImplement<T, TKey, TElement, TK, TE>(this IEnumerable<object?>? input, Func<T, TK> keySelector, Func<T, TE> elementSelector) => input.IsNullEmptyImplement()
        ? Empty<(TKey? Key, TElement? Element)>().ToLookup(p => p.Key, p => p.Element)
        : input.OfType<T>().ToLookup(x => keySelector(x).ParseImplement<TKey?>(), x => elementSelector(x).ParseImplement<TElement?>());
}
