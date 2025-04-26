using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

public static partial class YANProcess
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static async Task KillAllProcessesByName(this string? name) => await name.KillAllProcessesByNameImplement();
}
