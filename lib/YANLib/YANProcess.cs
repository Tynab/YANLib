using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

/// <summary>
/// Provides extension methods for process management.
/// </summary>
/// <remarks>
/// This class contains methods for managing system processes, including killing processes by name.
/// </remarks>
public static partial class YANProcess
{
    /// <summary>
    /// Kills all processes with the specified name.
    /// </summary>
    /// <param name="name">The name of the processes to kill. If <c>null</c> or whitespace, or if the name extracted from it is empty (for example <c>".exe"</c> or a path ending in a directory separator), no action is taken.</param>
    /// <returns>A task that represents the asynchronous kill operation.</returns>
    /// <remarks>
    /// This method finds all processes with the specified name (without file extension) and kills them.
    /// It waits for each process to exit before completing.
    /// Every matching process is attempted and disposed even if terminating one of them fails; the first failure (for example a <see cref="System.ComponentModel.Win32Exception"/>) is rethrown once every attempt has completed.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static async Task KillAllProcessesByName(this string? name) => await name.KillAllProcessesByNameImplement();
}
