using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

public static partial class YANUnmanaged
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T>? Parses<T>(this IEnumerable<object?>? input, object? defaultValue = null, IEnumerable<string?>? format = null) where T : unmanaged => input.ParsesImplement<T>(defaultValue, format);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T>? Parses<T>(this IEnumerable<object?>? input, object? defaultValue = null, params string?[]? format) where T : unmanaged => input.ParsesImplement<T>(defaultValue, format);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T>? Parses<T>(this System.Collections.IEnumerable? input, object? defaultValue = null, IEnumerable<string?>? format = null) where T : unmanaged => input.ParsesImplement<T>(defaultValue, format);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T>? Parses<T>(this System.Collections.IEnumerable? input, object? defaultValue = null, params string?[]? format) where T : unmanaged => input.ParsesImplement<T>(defaultValue, format);
}
