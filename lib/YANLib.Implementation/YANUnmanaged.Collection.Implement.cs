using System.Diagnostics;

namespace YANLib.Implementation;

internal static partial class YANUnmanaged
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T>? ParsesImplement<T>(this IEnumerable<object?>? input, object? defaultValue = null, IEnumerable<string?>? format = null) where T : unmanaged
        => input.IsNullEmptyImplement() ? default : input.GetCountImplement() < 1_000 ? input.Select(x => x.ParseImplement<T>(defaultValue, format)) : input.AsParallel().Select(x => x.ParseImplement<T>(defaultValue, format));

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T>? ParsesImplement<T>(this System.Collections.IEnumerable? input, object? defaultValue = null, IEnumerable<string?>? format = null) where T : unmanaged
        => input.IsNullImplement() ? default : input.Cast<object?>().ParsesImplement<T>(defaultValue, format);

    [DebuggerHidden]
    [DebuggerStepThrough]
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
