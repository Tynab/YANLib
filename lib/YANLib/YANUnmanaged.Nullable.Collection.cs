using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

public static partial class YANUnmanaged
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Parses<T>(this IEnumerable<object?>? input) => input.ParsesImplement<T>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Parses<T>(params object?[]? input) => input.ParsesImplement<T>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Parses<T>(this System.Collections.IEnumerable? input) => input.ParsesImplement<T>();
}
