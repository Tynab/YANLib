
namespace YANLib.Implementation;

internal static partial class YANUnmanaged
{
    internal static IEnumerable<T>? ParsesImplement<T>(this IEnumerable<object?>? input, object? defaultValue = null, IEnumerable<string?>? format = null) where T : unmanaged
        => input.IsNullEmptyImplement() ? default : input.Select(x => x.ParseImplement<T>(defaultValue, format));

    internal static IEnumerable<T>? ParsesImplement<T>(this System.Collections.IEnumerable? input, object? defaultValue = null, IEnumerable<string?>? format = null) where T : unmanaged
        => input is null ? default : input.Cast<object?>().ParsesImplement<T>(defaultValue, format);

    internal static IEnumerable<T>? ParsesWithImplement<T>(this IEnumerable<object?>? input, IFormatProvider? provider, object? defaultValue, IEnumerable<string?>? format) where T : unmanaged
        => input.IsNullEmptyImplement() ? default : input.Select(x => x.ParseWithImplement<T>(provider, defaultValue, format));

    internal static IEnumerable<T>? ParsesWithImplement<T>(this System.Collections.IEnumerable? input, IFormatProvider? provider, object? defaultValue, IEnumerable<string?>? format) where T : unmanaged
        => input is null ? default : input.Cast<object?>().ParsesWithImplement<T>(provider, defaultValue, format);

    /// <summary>The parsed copy of <paramref name="input"/>, in its enumeration order; duplicate parsed keys as in <see cref="YANEnumerable.AddOrResolve"/>.</summary>
    private static Dictionary<TKey, TValue?> ParsesDictionary<TKey, TValue>(IDictionary<object, object?>? input, Func<TValue?, TValue?, TValue?>? onDuplicate) where TKey : unmanaged
    {
        if (input.IsNullEmptyImplement())
        {
            return [];
        }

        // Without onDuplicate, the input is copied under the default comparer, as in 8.3.3: two keys that are equal under object.Equals but kept
        // apart by the input's comparer (two distinct "1" strings under ReferenceEqualityComparer) throw ArgumentException from that copy. With
        // onDuplicate, the entries are only snapshotted, in enumeration order and without being re-keyed, so such keys reach onDuplicate.
        IReadOnlyCollection<KeyValuePair<object, object?>> entries = onDuplicate is null ? new Dictionary<object, object?>(input) : SnapshotEntries(input);
        var result = new Dictionary<TKey, TValue?>(entries.Count);

        foreach (var pair in entries)
        {
            YANEnumerable.AddOrResolve(result, pair.Key is TKey k ? k : pair.Key.ParseImplement<TKey>(), pair.Value is TValue v ? v : pair.Value.ParseImplement<TValue?>(), onDuplicate);
        }

        return result;
    }

    /// <summary>The entries of <paramref name="input"/>, in its enumeration order, without re-keying them under another comparer.</summary>
    private static List<KeyValuePair<object, object?>> SnapshotEntries(IDictionary<object, object?> input)
    {
        var entries = new List<KeyValuePair<object, object?>>(input.Count);

        foreach (var pair in input)
        {
            entries.Add(pair);
        }

        return entries;
    }

    internal static Dictionary<TKey, TValue?> ParsesImplement<TKey, TValue>(this IDictionary<object, object?>? input) where TKey : unmanaged => ParsesDictionary<TKey, TValue>(input, null);

    internal static Dictionary<TKey, TValue?> ParsesImplement<TKey, TValue>(this IDictionary<object, object?>? input, Func<TValue?, TValue?, TValue?> onDuplicate) where TKey : unmanaged
    {
        ArgumentNullException.ThrowIfNull(onDuplicate);

        return ParsesDictionary<TKey, TValue>(input, onDuplicate);
    }
}
