using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

public static partial class YANUnmanaged
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Parse<T>(this object? input) => input.ParseImplement<T>();
}
