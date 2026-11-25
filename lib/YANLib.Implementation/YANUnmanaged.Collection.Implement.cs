
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

    internal static Dictionary<TKey, TValue?> ParsesImplement<TKey, TValue>(this IDictionary<object, object?>? input) where TKey : unmanaged
    {
        if (input.IsNullEmptyImplement())
        {
            return [];
        }

        var copy = new Dictionary<object, object?>(input);
        var result = new Dictionary<TKey, TValue?>(copy.Count);

        foreach (var pair in copy)
        {
            result.Add(pair.Key is TKey k ? k : pair.Key.ParseImplement<TKey>(), pair.Value is TValue v ? v : pair.Value.ParseImplement<TValue?>());
        }

        return result;
    }
}
