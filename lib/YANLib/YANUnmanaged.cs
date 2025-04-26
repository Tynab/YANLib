using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

public static partial class YANUnmanaged
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T Parse<T>(this object? input, object? defaultValue = null, IEnumerable<string?>? format = null) where T : unmanaged => input.ParseImplement<T>(defaultValue, format);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T Parse<T>(this object? input, object? defaultValue = null, params string?[]? format) where T : unmanaged => input.ParseImplement<T>(defaultValue, format);
}
