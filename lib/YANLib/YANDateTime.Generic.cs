using System.Diagnostics;
using YANLib.Implementation;
using static YANLib.Implementation.YANDateTime;

namespace YANLib;

public static partial class YANDateTime
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? GetWeekOfYear<T>(this object? input) => input.GetWeekOfYearImplement<T>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? TotalMonth<T>(object? input1, object? input2) => TotalMonthImplement<T>(input1, input2);
}
