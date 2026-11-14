using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

/// <summary>
/// Provides extension methods for process management on collections.
/// </summary>
/// <remarks>
/// This partial class contains methods for managing multiple system processes at once.
/// </remarks>
public static partial class YANProcess
{
    /// <summary>
    /// Kills all processes with names matching any of the specified names.
    /// </summary>
    /// <param name="names">
    /// The collection of process names (or executable paths) to kill. If <c>null</c> or empty, no action is taken; <c>null</c> or whitespace elements are skipped
    /// and the other names are still processed.
    /// </param>
    /// <returns>A task that represents the asynchronous kill operation.</returns>
    /// <exception cref="Exception">
    /// When a process cannot be killed (for example <see cref="InvalidOperationException"/> when it is an ancestor of the calling process), the other processes
    /// (for all names) are still killed and every process handle is disposed; then the first exception is rethrown with its original type.
    /// </exception>
    /// <remarks>
    /// Each name is matched as described for <see cref="KillAllProcessesByName(string?)"/>: the file name as given first, then without its extension if nothing matched.
    /// The calling process is never killed. Each process is killed together with its entire process tree (all descendants, whatever their names), except a matching
    /// process that is an ancestor of the calling process: .NET refuses to kill that tree, so that process keeps running and the refusal counts as a failure.
    /// It waits for each process to exit before completing.
    /// The operation is performed in parallel for all process names.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static async Task KillAllProcessesByNames(this IEnumerable<string?>? names) => await names.KillAllProcessesByNamesImplement();

    /// <summary>
    /// Kills all processes with names matching any of the specified names.
    /// </summary>
    /// <param name="names">
    /// The array of process names (or executable paths) to kill. If <c>null</c> or empty, no action is taken; <c>null</c> or whitespace elements are skipped
    /// and the other names are still processed.
    /// </param>
    /// <returns>A task that represents the asynchronous kill operation.</returns>
    /// <exception cref="Exception">
    /// When a process cannot be killed (for example <see cref="InvalidOperationException"/> when it is an ancestor of the calling process), the other processes
    /// (for all names) are still killed and every process handle is disposed; then the first exception is rethrown with its original type.
    /// </exception>
    /// <remarks>
    /// This method provides a convenient way to kill processes by name without having to explicitly create a collection.
    /// Each name is matched as described for <see cref="KillAllProcessesByName(string?)"/>: the file name as given first, then without its extension if nothing matched.
    /// The calling process is never killed. Each process is killed together with its entire process tree (all descendants, whatever their names), except a matching
    /// process that is an ancestor of the calling process: .NET refuses to kill that tree, so that process keeps running and the refusal counts as a failure.
    /// It waits for each process to exit before completing.
    /// The operation is performed in parallel for all process names.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static async Task KillAllProcessesByNames(params string?[]? names) => await names.KillAllProcessesByNamesImplement();
}
