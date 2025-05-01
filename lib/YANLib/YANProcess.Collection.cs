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
    /// <param name="names">The collection of process names to kill. If <c>null</c>, empty, or contains only <c>null</c> or whitespace elements, no action is taken.</param>
    /// <returns>A task that represents the asynchronous kill operation.</returns>
    /// <remarks>
    /// This method finds all processes with names matching any in the specified collection (without file extensions) and kills them.
    /// It waits for each process to exit before completing.
    /// The operation is performed in parallel for all process names.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static async Task KillAllProcessesByNames(this IEnumerable<string?>? names) => await names.KillAllProcessesByNamesImplement();

    /// <summary>
    /// Kills all processes with names matching any of the specified names.
    /// </summary>
    /// <param name="names">The array of process names to kill. If <c>null</c>, empty, or contains only <c>null</c> or whitespace elements, no action is taken.</param>
    /// <returns>A task that represents the asynchronous kill operation.</returns>
    /// <remarks>
    /// This method provides a convenient way to kill processes by name without having to explicitly create a collection.
    /// It finds all processes with names matching any in the specified array (without file extensions) and kills them.
    /// It waits for each process to exit before completing.
    /// The operation is performed in parallel for all process names.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static async Task KillAllProcessesByNames(params string?[]? names) => await names.KillAllProcessesByNamesImplement();
}
