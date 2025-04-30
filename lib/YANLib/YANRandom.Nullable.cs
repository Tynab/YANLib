using System.Diagnostics;

namespace YANLib;

public static partial class YANRandom
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? GenerateRandom<T>() => Implementation.YANRandom.GenerateRandomImplement<T>();
}
