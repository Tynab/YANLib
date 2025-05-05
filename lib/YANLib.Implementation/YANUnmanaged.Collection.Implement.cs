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
}
