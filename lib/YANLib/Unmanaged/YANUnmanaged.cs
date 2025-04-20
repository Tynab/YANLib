using System.Diagnostics;
using YANLib.Implementation.Unmanaged;

namespace YANLib.Unmanaged;

public static partial class YANUnmanaged
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T Parse<T>(this object? input, object? defaultValue = null, IEnumerable<string?>? format = null) where T : unmanaged => input.ParseImplement<T>(defaultValue, format);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T Parse<T>(this object? input, object? defaultValue = null, params string?[]? format) where T : unmanaged => input.ParseImplement<T>(defaultValue, format);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T>? Parses<T>(this IEnumerable<object?>? input, object? defaultValue = null, IEnumerable<string?>? format = null) where T : unmanaged => input.ParsesImplement<T>(defaultValue, format);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T>? Parses<T>(this IEnumerable<object?>? input, object? defaultValue = null, params string?[]? format) where T : unmanaged => input.ParsesImplement<T>(defaultValue, format);
}
