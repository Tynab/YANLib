using System.Diagnostics;

namespace YANLib.Implementation;

internal static partial class YANUnmanaged
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? ParsesImplement<T>(this IEnumerable<object?>? input)
        => input.IsNullEmptyImplement() ? default : input.GetCountImplement() < 1_000 ? input.Select(static x => x.ParseImplement<T?>()) : input.AsParallel().Select(x => x.ParseImplement<T?>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? ParsesImplement<T>(this System.Collections.IEnumerable input) => input.IsNullImplement() ? default : input.Cast<object?>().ParsesImplement<T>();
}
