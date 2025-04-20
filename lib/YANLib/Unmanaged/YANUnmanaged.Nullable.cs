using System.Diagnostics;
using YANLib.Implementation.Unmanaged;

namespace YANLib.Unmanaged;

public static partial class YANUnmanaged
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Parse<T>(this object? input) => input.ParseImplement<T>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Parses<T>(this IEnumerable<object?>? input) => input.ParsesImplement<T>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Parses<T>(params object?[]? input) => input.ParsesImplement<T>();
}
