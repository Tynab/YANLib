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
    /// <param name="name">
    /// The name of the processes to kill, or a path to their executable (only the file name is used). If <c>null</c> or whitespace, or if no file name is left
    /// (for example a directory path or <c>".exe"</c>), no action is taken.
    /// </param>
    /// <returns>A task that represents the asynchronous kill operation.</returns>
    /// <exception cref="Exception">
    /// When a process cannot be killed (for example <see cref="System.ComponentModel.Win32Exception"/> for access denied, or <see cref="AggregateException"/> when part of its
    /// process tree could not be killed), the other processes are still killed and every process handle is disposed; the first exception is then rethrown with its original type.
    /// </exception>
    /// <remarks>
    /// <para>
    /// The file name is matched as given, so a process whose name contains a dot (for example <c>my.app</c>) can be targeted. Only when no process has that name and the name has
    /// an extension (for example <c>"notepad.exe"</c> or <c>"MyApp.dll"</c>), the processes named without the extension are killed instead.
    /// The calling process itself is never killed, even when it has the specified name.
    /// </para>
    /// <para>
    /// Each process is killed with <see cref="Process.Kill(bool)"/> and <c>entireProcessTree: true</c>: all of its descendant processes are killed too,
    /// whatever their names. If a matching process is an ancestor of the calling process (for example the shell or host that started it), the calling process is killed with it.
    /// </para>
    /// <para>
    /// It waits for each process to exit before completing.
    /// </para>
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static async Task KillAllProcessesByName(this string? name) => await name.KillAllProcessesByNameImplement();

    /// <summary>
    /// Gets the processes that <see cref="KillAllProcessesByName(string?)"/> would kill for the specified name or path, without killing them.
    /// </summary>
    /// <param name="processNameOrPath">The process name, or a path to its executable (only the file name is used).</param>
    /// <returns>The matching processes (an empty array when no file name is left). The caller must dispose them.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static Process[] GetProcessesByFileName(this string? processNameOrPath) => processNameOrPath.GetProcessesByFileNameImplement();

    /// <summary>
    /// Kills every process in the sequence (with its process tree) except the calling process, waits for each to exit and disposes every process handle.
    /// </summary>
    /// <param name="processes">The processes to kill.</param>
    /// <returns>A task that represents the asynchronous kill operation; it rethrows the first failure after all processes have been tried.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static Task KillAndDispose(this IEnumerable<Process> processes) => processes.KillAndDisposeImplement();
}
