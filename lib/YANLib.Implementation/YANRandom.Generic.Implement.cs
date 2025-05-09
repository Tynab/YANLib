using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YANLib.Implementation;

internal static partial class YANRandom
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T GenerateRandomImplement<T>(this IEnumerable<object?>? input) where T : unmanaged
    {
        if (input.IsNullEmptyImplement())
        {
            return default;
        }

        var list = input as IList<object?> ?? [.. input];

        return list[GenerateRandomImplement<int>(0, list.Count)].ParseImplement<T>();
    }
}
