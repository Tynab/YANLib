using System.Diagnostics;

namespace YANLib.Implementation;

internal static partial class YANDateTime
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? GetWeekOfYearsImplement<T>(this IEnumerable<object?>? input)
        => input.IsNullEmptyImplement() ? default : input.Select(static x => x.GetWeekOfYearImplement<T>());
}
